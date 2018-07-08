using System;
using System.Linq;
using System.Runtime.InteropServices;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using System.Data;
using SuperMap.ZS.Common;

namespace SuperMap.ZS.Data
{
    /// <summary>
    /// Excel操作类
    /// </summary>
    public class ExcelHelper
    {
        private WorkbookPart m_WorkbookPart;

        /// <summary>
        /// 加载Excel数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="firstHeader">首行为标题，默认true</param>
        /// <returns></returns>
        public DataSet FromFile(string path, bool firstHeader = true)
        {
            DataSet dsResult = new DataSet();

            try
            {
                if (!File.Exists(path))
                {
                    Log.ShowError("当前文档正在被编辑，请关闭后操作！");
                    return dsResult;
                }

                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.IsReadOnly)
                {
                    Log.ShowError("当前文档正在被编辑，请关闭后操作！");
                    return dsResult;
                }

                //OpenSettings：Excel打开后的设置
                OpenSettings openSettings = new OpenSettings
                {
                    //设置Excel不自动保存
                    AutoSave = false
                };
                SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(path, true, openSettings);
                m_WorkbookPart = spreadsheetDocument.WorkbookPart;
                Sheets sheets = m_WorkbookPart.Workbook.Sheets;
                foreach(Sheet sheet in sheets)
                {
                    DataTable dt = new DataTable();
                    dt.TableName = sheet.Name;
                    WorksheetPart sheetPart = (WorksheetPart)spreadsheetDocument.WorkbookPart.GetPartById(sheet.Id);
                    
                    int rowIndex = 0;
                    foreach (Row row in sheetPart.Worksheet.Descendants<Row>())
                    {
                        DataRow dtRow = null;
                        int colIndex = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            if (firstHeader && rowIndex == 0)
                            {
                                dt.Columns.Add(GetCellValue(spreadsheetDocument, cell));
                            }
                            else if (dtRow == null)
                            {
                                dtRow = dt.NewRow();
                                dt.Rows.Add(dtRow);
                                dtRow[colIndex] = GetCellValue(spreadsheetDocument, cell);
                            }
                            else
                            {
                                dtRow[colIndex] = GetCellValue(spreadsheetDocument, cell);
                            }

                            colIndex++;
                        }

                        rowIndex++;
                    }

                    dsResult.Tables.Add(dt);
                }
                spreadsheetDocument.Close();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return dsResult;
        }

        private string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && (cell.DataType.Value == CellValues.SharedString || cell.DataType.Value == CellValues.String || cell.DataType.Value == CellValues.Number))
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else  //浮点数和日期对应的cell.DataType都为NULL
            {
                // DateTime.FromOADate((double.Parse(value)); 如果确定是日期就可以直接用过该方法转换为日期对象，可是无法确定DataType==NULL的时候这个CELL 数据到底是浮点型还是日期.(日期被自动转换为浮点
                return value;
            }
        }

        /// <summary>
        /// 保存Excel数据
        /// </summary>
        /// <param name="dataSet">数据集合</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public bool ToFile(DataSet dataSet, string path)
        {
            bool bResult = false;

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook);
                UInt32Value index = 1;
                m_WorkbookPart = spreadsheetDocument.AddWorkbookPart(); // Add a WorkbookPart to the document.
                m_WorkbookPart.Workbook = new Workbook();
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets()); // Add Sheets to the Workbook.
                foreach (DataTable table in dataSet.Tables)
                {
                    WorksheetPart worksheetPart = m_WorkbookPart.AddNewPart<WorksheetPart>(); // Add a WorksheetPart to the WorkbookPart.
                    Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = index++, Name = table.TableName };
                    sheets.Append(sheet);
                    AddWorksheetPart(table.TableName);
                    Worksheet worksheet = new Worksheet();

                    SheetData sheetData = new SheetData();
                    Row rowHeader = new Row();
                    foreach (DataColumn col in table.Columns)
                    {
                        Cell cell = new Cell();
                        CellValue cellValue = new CellValue();
                        cellValue.Text = col.ColumnName;
                        cell.Append(cellValue);

                        rowHeader.Append(cell);
                    }
                    sheetData.Append(rowHeader);

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow dtRow = table.Rows[i];
                        Row row = new Row();

                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            Cell cell = new Cell();
                            CellValue cellValue = new CellValue();
                            cellValue.Text = Convert.ToString(dtRow[j]);
                            cell.Append(cellValue);

                            row.Append(cell);
                        }

                        sheetData.Append(row);
                    }
                    worksheet.Append(sheetData);

                    worksheetPart.Worksheet = worksheet;
                }
                m_WorkbookPart.Workbook.Save();
                spreadsheetDocument.Close();

                bResult = true;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        //添加一个工作表
        private void AddWorksheetPart(string sheetName)
        {
            try
            {
                Sheet sheet = m_WorkbookPart.Workbook.Sheets.Elements<Sheet>().
                    FirstOrDefault(s => s != null && s.Name != null && s.Name == sheetName);
                WorksheetPart worksheetPart = null;
                if (sheet != null)
                {
                    worksheetPart = (WorksheetPart)m_WorkbookPart.GetPartById(sheet.Id);
                }
                else
                {
                    worksheetPart = m_WorkbookPart.AddNewPart<WorksheetPart>();
                }
                //Worksheet
                if (worksheetPart.Worksheet == null)
                {
                    worksheetPart.Worksheet = new Worksheet();
                }
                //Sheet
                if (sheet == null)
                {
                    sheet = m_WorkbookPart.Workbook.Sheets.Elements<Sheet>().LastOrDefault();
                    //定义默认的sheetId值，当工作薄中一个工作表也没有时，便以1作为新添加的Sheet元素的Id值
                    UInt32Value sheetId = 1;
                    if (sheet != null)
                    {
                        sheetId = sheet.SheetId + 1;
                    }
                    //AppendChild：添加一个子元素
                    m_WorkbookPart.Workbook.Sheets.AppendChild(new Sheet()
                    {
                        //Id为字符串类型的Id属性
                        Id = m_WorkbookPart.GetIdOfPart(worksheetPart),
                        //SheetId为数值类型的Id属性
                        SheetId = sheetId,
                        //工作表的名称
                        Name = sheetName
                    });
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        //获取工作表
        private WorksheetPart GetWorksheetPart(string sheetName)
        {
            WorksheetPart worksheetPart = null;

            try
            {
                //WorksheetPart
                Sheet sheet = m_WorkbookPart.Workbook.Sheets.Elements<Sheet>().FirstOrDefault(s => s != null && s.Name != null && s.Name == sheetName);
                if (sheet != null)
                {
                    worksheetPart = (WorksheetPart)m_WorkbookPart.GetPartById(sheet.Id);
                }
                else
                {
                    return null;
                }
                //Worksheet,SheetData
                if (worksheetPart.Worksheet == null || worksheetPart.Worksheet.Elements<SheetData>().FirstOrDefault() == null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return worksheetPart;
        }

        private Row AddRow(WorksheetPart worksheetPart, DataRow row)
        {
            Row rowResult = null;

            try
            {
                if (worksheetPart.Worksheet.Elements<SheetData>().FirstOrDefault() == null)
                {
                    //workbookPart.AddNewPart<WorksheetPart>()：添加一个新的WorksheetPart
                    worksheetPart.Worksheet.AppendChild(new SheetData
                    {
                        
                    });
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return rowResult;
        }
    }

    internal class OXSheet
    {
        //定义WorksheetPart子元素节点
        private WorksheetPart worksheetPart = null;
        private SharedStringTable sharedStringTable = null;
        //SheetData：记录非空单元格的位置及内容
        private SheetData sheetData = null;
        //指向当前行Row
        private Row currentRow = null;
        //根据ASCII码获取字母A的int编码值
        private int begin = 'A' - 1;
        public OXSheet(WorksheetPart worksheetPart, SharedStringTable sharedStringTable)
        {
            this.worksheetPart = worksheetPart;
            sheetData = worksheetPart.Worksheet.Elements<SheetData>().FirstOrDefault();
            currentRow = sheetData.Elements<Row>().LastOrDefault();
            if (currentRow == null)
            {
                AddRow();
            }
            this.sharedStringTable = sharedStringTable;
        }
        //添加一行
        public void AddRow()
        {
            currentRow = new Row();
            sheetData.AppendChild(currentRow);
        }
        //在当前行中添加一个的普通表格
        public void AddCell(object data)
        {
            addCell(data, -1);
        }
        //在当前行中添加一个指定表格样式的普通表格
        public void AddCell(object data, int styleIndex)
        {
            addCell(data, styleIndex);
        }
        private void addCell(object data, int styleIndex)
        {
            Cell cell = currentRow.AppendChild(new Cell()
            {
                //CellValue:单元格内容
                CellValue = new CellValue() { Text = data.ToString() },
                //DataType：单元格类型
                DataType = CellValues.String,
            });
            if (styleIndex != -1)
            {
                cell.StyleIndex = (uint)styleIndex;
            }
        }
        //在当前行中添加一个类型为共享字符串的表格
        public void AddSharedStringCell(object data)
        {
            addSharedStringCell(data, -1);
        }
        //在当前行中添加一个类型为共享字符串、指定表格样式的表格
        public void AddSharedStringCell(object data, int styleIndex)
        {
            addSharedStringCell(data, styleIndex);
        }
        private void addSharedStringCell(object data, int styleIndex)
        {
            Cell cell = currentRow.AppendChild(new Cell()
            {
                CellValue = new CellValue(
                    Convert.ToString(getSharedStringItemIndex(data.ToString()))),
                DataType = CellValues.SharedString,
            });
            if (styleIndex != -1)
            {
                cell.StyleIndex = (uint)styleIndex;
            }
        }
        //获取指定字符串在SharedStringTable中的索引值，不存在就创建
        private int getSharedStringItemIndex(string value)
        {
            //字符串从0开始标记
            int index = 0;
            //寻找是否有与value相同的字符串，若有，则将index设置为对应的标记值，并返回
            //SharedStringItem：共享字符串的数据类型
            //sharedStringTable：共享字符串表
            foreach (SharedStringItem item in sharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == value)
                {
                    return index;
                }
                index++;
            }
            //若没有与value相同的字符串，则添加一个字符串到共享字符串表中，并将其内容设置为value
            sharedStringTable.AppendChild(new SharedStringItem(new Text(value)));
            sharedStringTable.Save();
            return index;
        }
        //在当前行中添加一个超链接表格
        public void AddHyperLink(object data)
        {
            addHyperlink(data, -1);
        }
        //在当前行中添加一个超链接表格
        public void AddHyperLink(object data, int styleIndex)
        {
            addHyperlink(data, styleIndex);
        }
        private void addHyperlink(object data, int styleIndex)
        {
            Cell cell = currentRow.AppendChild(new Cell()
            {
                CellFormula = new CellFormula() { Text = string.Format("HYPERLINK({0}{1}{0},{0}{1}{0})", "\"", data.ToString()) },
                CellValue = new CellValue(data.ToString()),
                DataType = CellValues.String,
            });
            if (styleIndex != -1)
            {
                cell.StyleIndex = (uint)styleIndex;
            }
        }
        //指定行和列定位表格，写入数据
        public void Write(int rowIndex, int colIndex, object data)
        {
            Cell cell = getCell(getRow(rowIndex), colIndex);
            cell.CellValue = new CellValue(data.ToString());
        }
        //读取指定行和列的内容
        public string Read(int rowIndex, int colIndex)
        {
            Row row = getRow(rowIndex);
            Cell cell = getCell(row, colIndex);
            string value = string.Empty;
            if (cell.CellValue != null && cell.CellValue.InnerText != null)
            {
                value = cell.CellValue.InnerText;
                if (cell.DataType != null && cell.DataType == CellValues.SharedString)
                {
                    return sharedStringTable.ElementAt(Int32.Parse(value)).InnerText;
                }
                else
                {
                    return value;
                }
            }
            return value;
        }
        //根据行索引值获取列Row
        private Row getRow(int rowIndex)
        {
            Row row = sheetData.Elements<Row>().FirstOrDefault(r => r != null && r.RowIndex != null && r.RowIndex == rowIndex);
            if (row == null)
            {
                row = new Row() { RowIndex = (uint)rowIndex };
                Row lastRow = sheetData.Elements<Row>().LastOrDefault();
                if ((lastRow != null && lastRow.RowIndex != null && lastRow.RowIndex < rowIndex) || lastRow == null)
                {
                    sheetData.AppendChild(row);
                }
                else
                {
                    Row refRow = sheetData.Elements<Row>().FirstOrDefault(r => r != null && r.RowIndex != null && r.RowIndex > rowIndex);
                    sheetData.InsertBefore(row, refRow);
                }
            }
            return row;
        }
        //根据指定行和列索引获取单元格Cell
        private Cell getCell(Row row, int colIndex)
        {
            Cell cell = row.Elements<Cell>().FirstOrDefault(c => c != null && c.CellReference != null && c.CellReference.Value == getColNameByColIndex(colIndex) + row.RowIndex);
            if (cell == null)
            {
                cell = new Cell() { CellReference = getColNameByColIndex(colIndex) + row.RowIndex, DataType = CellValues.String };

                Cell lastCell = row.Elements<Cell>().LastOrDefault();
                if ((lastCell != null && getColIndexByCellReference(lastCell.CellReference.Value) < colIndex) || lastCell == null)
                {
                    row.AppendChild(cell);
                }
                else
                {
                    Cell nextCell = row.Elements<Cell>().FirstOrDefault(c => c != null && c.CellReference != null && getColIndexByCellReference(c.CellReference.Value) > colIndex);
                    row.InsertBefore(cell, nextCell);
                }
            }
            return cell;
        }
        //根据第一行中的表格内容，通过与给定的字符串进行匹配获取列的索引值
        public int GetColIndexByHeaderName(string headerName)
        {
            int index = 1;
            Row row = getRow(1);
            foreach (Cell cell in row.Elements<Cell>())
            {
                if (cell != null && cell.CellValue != null && cell.CellValue.InnerText != null &&
                    cell.CellValue.InnerText == headerName)
                {
                    return index;
                }
                index++;
            }
            row.AppendChild(new Cell() { CellValue = new CellValue() { Text = headerName.ToString() } });
            return index;
        }
        //根据表格的索引值(如A1)获取列的索引值
        private int getColIndexByCellReference(string cellReference)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[A-Z]{1,}");
            System.Text.RegularExpressions.Match match = regex.Match(cellReference);
            string value = match.Value;
            return getColIndexByColName(value);
        }
        //根据列的名称(如A)获取列的索引值
        private int getColIndexByColName(string colName)
        {
            int index = 0;
            char[] names = colName.ToCharArray();
            int length = names.Length;
            for (int i = 0; i < length; i++)
            {
                index += (names[i] - begin) * (int)Math.Pow(26, length - i - 1);
            }
            return index;
        }
        //根据列的索引值获取列名(如A)
        private string getColNameByColIndex(int index)
        {
            string colName = "";
            if (index < 0)
            {
                return colName;
            }
            while (index > 26)
            {
                colName += ((char)(index % 26 + begin)).ToString();
                index = index / 26;
            }
            colName += ((char)(index % 26 + begin)).ToString();
            return colName;
        }
        //保存工作表
        public void Save()
        {
            worksheetPart.Worksheet.Save();
        }
    }
}
