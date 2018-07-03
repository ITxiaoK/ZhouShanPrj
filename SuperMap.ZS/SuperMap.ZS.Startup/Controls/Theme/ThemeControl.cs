using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Xml.Linq;
using System.Text;
using SuperMap.ZS.Common;
using System.Diagnostics;
using SuperMap.Desktop;
using SuperMap.Realspace;
using SuperMap.Desktop.UI;
using System.Windows.Forms;
using SuperMap.UI;
using SuperMap.Data;

namespace SuperMap.ZS.Startup
{
    public partial class ThemeControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;
        
        public ThemeControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
        }

        private void btnScreenTip_Click(object sender, EventArgs e)
        {
            try
            {
                XElement root = XElement.Load(CommonPars.ScreenTipConfigFilePath);
                root.SetElementValue("CurrentTip", "专题制作");
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CommonPars.ScreenTipName);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnDrawData_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkTheme.SelectedItem == null)
                {
                    m_Application.MessageBox.Show("请选择要编辑的数据！");
                    return;
                }
                Layer3DDataset layer3DDataset = (chkTheme.SelectedItem as Label).Tag as Layer3DDataset;
                layer3DDataset.IsEditable = true;
                m_SceneControl.ObjectAdded += M_SceneControl_ObjectAdded;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void ThemeControl_Load(object sender, EventArgs e)
        {
            try
            {
                chkTheme.Items.Clear();
                List<Label> lstData = new List<Label>();
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
                    foreach (Layer3D layer in formScene.SceneControl.Scene.Layers)
                    {
                        if (layer is Layer3DDataset)
                        {
                            Layer3DDataset layer3DDataset = layer as Layer3DDataset;
                            if (layer3DDataset.Theme != null && layer3DDataset.Theme is Theme3D)
                            {
                                lstData.Add(new Label { Text = layer3DDataset.Caption, Tag = layer3DDataset });
                            }
                        }
                    }
                }
                chkTheme.DataSource = lstData;
                chkTheme.DisplayMember = "Text";
                chkTheme.ValueMember = "Tag";
                chkTheme.SetItemChecked(0, true);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_SceneControl_ObjectAdded(object sender, ObjectAddedEventArgs e)
        {
            Recordset objRt = null;
            try
            {
                if (chkTheme.SelectedItem == null)
                {
                    m_Application.MessageBox.Show("请选择要编辑的数据！");
                    return;
                }
                dg_Data.Rows.Clear();
                Layer3DDataset layer3DDataset = (chkTheme.SelectedItem as Label).Tag as Layer3DDataset;
                objRt = (layer3DDataset.Dataset as DatasetVector).GetRecordset(false, CursorType.Static);
                if (objRt.SeekID(e.ID))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.HeaderCell.Value = objRt.GetID().ToString();
                    for (int j = 0; j < dg_Data.ColumnCount; j++)
                    {
                        DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                        textBoxCell.Value = Convert.ToString(objRt.GetFieldValue(dg_Data.Columns[j].Name));
                        row.Cells.Add(textBoxCell);
                    }
                    dg_Data.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                objRt.Close();
                objRt.Dispose();
            }
        }

        private void chkTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void chkTheme_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.CurrentValue == CheckState.Checked) return;//取消选中就不用进行以下操作
                for (int i = 0; i < ((CheckedListBox)sender).Items.Count; i++)
                {
                    ((CheckedListBox)sender).SetItemChecked(i, false);//将所有选项设为不选中
                }
                e.NewValue = CheckState.Checked;//刷新
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btn_Commit_Click(object sender, EventArgs e)
        {
            Recordset objRt = null;
            try
            {
                if (chkTheme.SelectedItem == null)
                {
                    m_Application.MessageBox.Show("请选择要编辑的数据！");
                    return;
                }
                Layer3DDataset layer3DDataset = (chkTheme.SelectedItem as Label).Tag as Layer3DDataset;
                objRt = (layer3DDataset.Dataset as DatasetVector).GetRecordset(false, CursorType.Dynamic);
                foreach (DataGridViewRow row in dg_Data.Rows)
                {
                    int id = Convert.ToInt32(row.HeaderCell.Value);
                    if (objRt.SeekID(id) && objRt.Edit())
                    {
                        foreach (DataGridViewColumn column in dg_Data.Columns)
                        {
                            switch (objRt.GetFieldInfos()[column.Name].Type)
                            {
                                case FieldType.WText:
                                    objRt.SetFieldValue(column.Name, Convert.ToString(row.Cells[column.Name].Value));
                                    break;
                                case FieldType.Double:
                                    objRt.SetFieldValue(column.Name, Convert.ToDouble(row.Cells[column.Name].Value));
                                    break;
                                case FieldType.Int32:
                                    objRt.SetFieldValue(column.Name, Convert.ToInt32(row.Cells[column.Name].Value));
                                    break;
                            }
                        }
                        objRt.Update();
                    }
                }
                m_SceneControl.Refresh();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                objRt.Close();
                objRt.Dispose();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void GetData()
        {
            Recordset objRt = null;
            try
            {
                dg_Data.Rows.Clear();
                dg_Data.Columns.Clear();
                if (chkTheme.SelectedItem == null)
                {
                    m_Application.MessageBox.Show("请选择要编辑的数据！");
                    return;
                }
                Layer3DDataset layer3DDataset = (chkTheme.SelectedItem as Label).Tag as Layer3DDataset;
                objRt = (layer3DDataset.Dataset as DatasetVector).GetRecordset(false, CursorType.Static);
                for (int i = 0; i < objRt.FieldCount; i++)
                {
                    FieldInfo fieldInfo = objRt.GetFieldInfos()[i];
                    if (fieldInfo.Caption.ToLower().Contains("sm"))
                    {
                        continue;
                    }
                    dg_Data.Columns.Add(fieldInfo.Name, fieldInfo.Caption);
                }

                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.HeaderCell.Value = objRt.GetID().ToString();
                    for (int j = 0; j < dg_Data.ColumnCount; j++)
                    {
                        DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell
                        {
                            Value = Convert.ToString(objRt.GetFieldValue(dg_Data.Columns[j].Name))
                        };
                        row.Cells.Add(textBoxCell);
                    }
                    dg_Data.Rows.Add(row);

                    objRt.MoveNext();
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                objRt.Close();
                objRt.Dispose();
            }
        }

        private void dg_Data_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (chkTheme.SelectedItem == null)
                {
                    m_Application.MessageBox.Show("请选择要编辑的数据！");
                    return;
                }
                Layer3DDataset layer3DDataset = (chkTheme.SelectedItem as Label).Tag as Layer3DDataset;
                layer3DDataset.Selection.Add(Convert.ToInt32(dg_Data.Rows[e.RowIndex].HeaderCell.Value));
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void dg_Data_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Recordset objRt = null;

            try
            {
                if (chkTheme.SelectedItem == null)
                {
                    m_Application.MessageBox.Show("请选择要编辑的数据！");
                    return;
                }
                Layer3DDataset layer3DDataset = (chkTheme.SelectedItem as Label).Tag as Layer3DDataset;
                objRt = (layer3DDataset.Dataset as DatasetVector).GetRecordset(false, CursorType.Dynamic);
                int index = Convert.ToInt32(e.Row.HeaderCell.Value);
                if (objRt.SeekID(index))
                {
                    if (m_Application.MessageBox.Show("要删除第【" + index.ToString() + "】条数据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        objRt.Delete();
                        objRt.Update();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                m_SceneControl.Refresh();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                objRt.Close();
                objRt.Dispose();
            }
        }
    }
}