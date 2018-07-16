using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.ZS.Common;
using System.Xml.Linq;
using System.Diagnostics;
using SuperMap.Desktop;
using SuperMap.Data;
using SuperMap.ZS.Data;

namespace SuperMap.ZS.SecurityManager
{
    public partial class UpdateDangerResourceInfoControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;

        public UpdateDangerResourceInfoControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
            m_Application.Workspace.Closed += Workspace_Closed;
        }

        private void Workspace_Closed(object sender, WorkspaceClosedEventArgs args)
        {
            try
            {
                txt_Path.Text = "";
                dgv_Data.Rows.Clear();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnScreenTip_Click(object sender, EventArgs e)
        {
            try
            {
                XElement root = XElement.Load(CommonPars.ScreenTipConfigFilePath);
                root.SetElementValue("CurrentTip", "重大危险源信息更新");
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CommonPars.ScreenTipName);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void UpdateDangerResourceInfoControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Filter = "Excel文件|*.xlsx",
                    InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop),
                    Multiselect = false,
                    Title = "导入文件"
                };
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    txt_Path.Text = openFile.FileName;
                    dgv_Data.Rows.Clear();
                    ExcelHelper excel = new ExcelHelper();
                    DataSet ds = excel.FromFile(openFile.FileName);
                    foreach (DataTable dt in ds.Tables)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = dt.TableName });

                        List<Label> lst = new List<Label>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            lst.Add(new Label { Text = col.ColumnName });
                        }

                        DataGridViewComboBoxCell cell1 = new DataGridViewComboBoxCell
                        {
                            AutoComplete = true,
                            DataSource = lst,
                            DisplayMember = "Text"
                        };
                        row.Cells.Add(cell1);
                        DataGridViewComboBoxCell cell2 = new DataGridViewComboBoxCell
                        {
                            AutoComplete = true,
                            DataSource = lst,
                            DisplayMember = "Text",
                        };
                        row.Cells.Add(cell2);
                        row.Tag = dt;

                        dgv_Data.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog
                {
                    Filter = "Excel文件|*.xlsx",
                    AddExtension = true,
                    InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop),
                    OverwritePrompt = true,
                };
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable
                    {
                        TableName = "重大危险源"
                    };                    

                    Recordset objRt = null;
                    try
                    {
                        objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["DangerResource"] as DatasetVector).GetRecordset(false, CursorType.Static);
                        foreach (FieldInfo info in objRt.GetFieldInfos())
                        {
                            if (info.Name.ToLower().Contains("sm"))
                            {
                                continue;
                            }
                            dt.Columns.Add(new DataColumn { ColumnName = info.Name, Caption = info.Caption });
                        }
                        objRt.MoveFirst();
                        while (!objRt.IsEOF)
                        {
                            DataRow row = dt.NewRow();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                row[i] = objRt.GetFieldValue(dt.Columns[i].ColumnName);
                            }
                            dt.Rows.Add(row);

                            objRt.MoveNext();
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.OutputBox(ex);
                    }
                    finally
                    {
                        if (objRt != null)
                        {
                            objRt.Close();
                            objRt.Dispose();
                        }
                    }
                    ds.Tables.Add(dt);
                    ExcelHelper excel = new ExcelHelper();
                    if (excel.ToFile(ds, saveFile.FileName))
                    {
                        m_Application.MessageBox.Show("数据导出成功！若提示文件损坏，请尝试修复。");
                    }
                    else
                    {
                        m_Application.MessageBox.Show("数据导出失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                bool isEmpty = false;
                foreach (DataGridViewRow row in dgv_Data.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null)
                        {
                            isEmpty = true;
                            break;
                        }
                    }
                    if (isEmpty)
                    {
                        m_Application.MessageBox.Show("请完整设置数据！");
                        break;
                    }
                }
                if (!isEmpty)
                {
                    if (m_Application.MessageBox.Show("导入数据会覆盖当前已有数据，是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        //删除数据集
                        m_Application.MessageBox.Show("请添加删除功能");
                    }
                }
                backgroundWorker.RunWorkerAsync(); // 运行 backgroundWorker 组件

                MessageTipForm form = new MessageTipForm(backgroundWorker);// 显示进度条窗体
                form.ShowDialog(this);
                form.Close();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else if (e.Cancelled)
                {
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            m_Application.MessageBox.Show("请添加数据导入功能");
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                string title = "任务进度({0}/{1})：";
                for (int i = 0; i < dgv_Data.Rows.Count; i++)
                {
                    DataTable dt = dgv_Data.Rows[i].Tag as DataTable;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataRow row = dt.Rows[j];

                        //填充数据处理

                        double value = (Convert.ToDouble(j) / dt.Rows.Count) * 100.0;
                        worker.ReportProgress((int)value, string.Format(title, (i + 1).ToString(), dgv_Data.Rows.Count.ToString()));
                        if (worker.CancellationPending)  // 如果用户取消则跳出处理数据代码 
                        {
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
