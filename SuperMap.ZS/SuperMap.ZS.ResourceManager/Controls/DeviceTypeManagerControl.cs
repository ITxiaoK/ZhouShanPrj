using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Desktop;
using SuperMap.ZS.Common;
using SuperMap.Data;
using System.Xml.Linq;
using System.Diagnostics;

namespace SuperMap.ZS.ResourceManager
{
    public partial class DeviceTypeManagerControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;
        private List<ResourceTypeData> m_lstType;
        private List<Label> m_lstTypeData;

        public DeviceTypeManagerControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
            m_Application.Workspace.Closed += Workspace_Closed;
        }

        private void Workspace_Closed(object sender, WorkspaceClosedEventArgs args)
        {
            try
            {
                cmbDeviceType.DataSource = null;
                cmbSetDeviceType.DataSource = null;
                dgv_Data.Rows.Clear();
                dgv_TypeData.Rows.Clear();
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
                root.SetElementValue("CurrentTip", "设备分类");
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CommonPars.ScreenTipName);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void DeviceTypeManagerControl_Load(object sender, EventArgs e)
        {
            Recordset objRt = null;

            try
            {
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
                }
                if (m_lstType == null)
                {
                    m_lstType = new List<ResourceTypeData>();
                }
                if (m_lstTypeData == null)
                {
                    m_lstTypeData = new List<Label>();
                }
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ResourceTable"] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    ResourceTypeData data = new ResourceTypeData
                    {
                        Caption = Convert.ToString(objRt.GetFieldValue("SourceName")),
                        Name = Convert.ToString(objRt.GetFieldValue("SourceID")),
                        FieldID = Convert.ToString(objRt.GetFieldValue("TableField"))?.Split(',')[0],
                        FieldName = Convert.ToString(objRt.GetFieldValue("TableField"))?.Split(',')[1],
                        DatasetName = Convert.ToString(objRt.GetFieldValue("TableName")),
                    };
                    m_lstType.Add(data);

                    objRt.MoveNext();
                }
                GetData();
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
        }

        private void GetData()
        {
            try
            {
                cmbDeviceType.DataSource = null;
                cmbDeviceType.DataSource = m_lstType;
                cmbDeviceType.DisplayMember = "Caption";
                if (cmbDeviceType.Items.Count > 0)
                {
                    cmbDeviceType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void cmbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recordset objRtType = null;
            Recordset objRtData = null;

            try
            {
                //获取类型信息
                dgv_TypeData.Rows.Clear();
                m_lstTypeData.Clear();
                if (cmbDeviceType.SelectedItem == null)
                {
                    return;
                }
                ResourceTypeData typeData = cmbDeviceType.SelectedItem as ResourceTypeData;
                string strDatasetTypeName = typeData.DatasetName + "Type";
                if (!m_Application.Workspace.Datasources["Resource"].Datasets.Contains(strDatasetTypeName))
                {
                    return;
                }
                objRtType = (m_Application.Workspace.Datasources["Resource"].Datasets[strDatasetTypeName] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRtType.MoveFirst();
                while (!objRtType.IsEOF)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Convert.ToString(objRtType.GetFieldValue("TypeName")) });
                    dgv_TypeData.Rows.Add(row);

                    m_lstTypeData.Add(new Label { Text = Convert.ToString(objRtType.GetFieldValue("TypeName")), Tag = Convert.ToString(objRtType.GetFieldValue("TypeID")) });

                    objRtType.MoveNext();
                }

                cmbSetDeviceType.DataSource = null;
                cmbSetDeviceType.DataSource = m_lstTypeData;
                cmbSetDeviceType.DisplayMember = "Text";
                if (cmbSetDeviceType.Items.Count > 0)
                {
                    cmbSetDeviceType.SelectedIndex = 0;
                }

                //获取设备信息
                dgv_Data.Rows.Clear();
                if (m_Application.Workspace.Datasources["Resource"].Datasets[typeData.DatasetName] == null)
                {
                    return;
                }
                objRtData = (m_Application.Workspace.Datasources["Resource"].Datasets[typeData.DatasetName] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRtData.MoveFirst();
                while (!objRtData.IsEOF)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewCheckBoxCell());
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Convert.ToString(objRtData.GetFieldValue(typeData.FieldID)) });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Convert.ToString(objRtData.GetFieldValue(typeData.FieldName)) });
                    //if (objRtData.GetFieldValue("TypeID") != null)
                    //{
                    //    row.Cells.Add(new DataGridViewTextBoxCell { Value = Convert.ToString(objRtData.GetFieldValue("TypeID")) });
                    //}
                    row.Tag = objRtData.GetID();
                    dgv_Data.Rows.Add(row);

                    objRtData.MoveNext();
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                if (objRtType != null)
                {
                    objRtType.Close();
                    objRtType.Dispose();
                }
                if (objRtData != null)
                {
                    objRtData.Close();
                    objRtData.Dispose();
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lst = new List<string>();
                foreach (DataGridViewRow row in dgv_Data.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    cell.Value = true;
                    if (row.Cells[3].Value != null)
                    {
                        lst.Add(Convert.ToString(row.Cells[1].Value));
                    }
                }
                string msg = "";
                foreach (string str in lst)
                {
                    msg += str + ",";
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    msg = msg.Substring(0, msg.Length - 1);
                    m_Application.MessageBox.Show("以下数据已经设置类型！\n" + msg);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnSelectChange_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lst = new List<string>();
                foreach (DataGridViewRow row in dgv_Data.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    cell.Value = !Convert.ToBoolean(cell.Value);
                    if (Convert.ToBoolean(cell.Value) && row.Cells[3].Value != null)
                    {
                        lst.Add(Convert.ToString(row.Cells[1].Value));
                    }
                }
                string msg = "";
                foreach (string str in lst)
                {
                    msg += str + ",";
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    msg = msg.Substring(0, msg.Length - 1);
                    m_Application.MessageBox.Show("以下数据已经设置类型！\n" + msg);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnDataOK_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgv_Data.Rows)
                {
                    DataGridViewCheckBoxCell cell1 = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(cell1.EditedFormattedValue))
                    {
                        //Recordset objRt = null;

                        //try
                        //{
                        //    objRt = (m_Application.Workspace.Datasources["Resource"].Datasets[(cmbDeviceType.SelectedItem as ResourceTypeData).DatasetName] 
                        //        as DatasetVector).Query(new int[] { Convert.ToInt32(row.Tag) }, CursorType.Dynamic);
                        //    if (objRt != null && objRt.Edit())
                        //    {
                        //        objRt.SetFieldValue("TypeID", (cmbSetDeviceType.SelectedItem as Label).Tag);
                        //        if (objRt.Update())
                        //        {
                        //            row.Cells[3].Value = (cmbSetDeviceType.SelectedItem as Label).Text;
                        //        }
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    Log.OutputBox(ex);
                        //}
                        //finally
                        //{
                        //    if (objRt != null)
                        //    {
                        //        objRt.Close();
                        //        objRt.Dispose();
                        //    }
                        //}
                        row.Cells[3].Value = (cmbSetDeviceType.SelectedItem as Label).Text;
                        m_Application.MessageBox.Show("请修改保存代码");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void dgv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(dgv_Data.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue) && dgv_Data.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    m_Application.MessageBox.Show("已经设置类型！");
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
