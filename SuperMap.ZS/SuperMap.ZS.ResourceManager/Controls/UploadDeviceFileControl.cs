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

namespace SuperMap.ZS.ResourceManager
{
    public partial class UploadDeviceFileControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;
        private List<ResourceTypeData> m_lstTypeData;
        private string[] m_SelectFiles;

        public UploadDeviceFileControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
            m_Application.Workspace.Closed += Workspace_Closed;
        }

        private void Workspace_Closed(object sender, WorkspaceClosedEventArgs args)
        {
            try
            {
                cmb_DeviceType.DataSource = null;
                cmb_DeviceType2.DataSource = null;
                dgv_Data.Rows.Clear();
                txt_FilePath.Text = "";
                rad_Type.Checked = true;
                m_lstTypeData.Clear();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void UploadDeviceFileControl_Load(object sender, EventArgs e)
        {
            Recordset objRt = null;

            try
            {
                if (m_lstTypeData == null)
                {
                    m_lstTypeData = new List<ResourceTypeData>();
                }
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
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

                    m_lstTypeData.Add(data);

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
                cmb_DeviceType.DataSource = null;
                cmb_DeviceType.DataSource = m_lstTypeData;
                cmb_DeviceType.DisplayMember = "Caption";
                cmb_DeviceType2.DataSource = null;
                cmb_DeviceType2.DataSource = m_lstTypeData;
                cmb_DeviceType2.DisplayMember = "Caption";
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void rad_Type_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton radioButton = sender as RadioButton;
                switch (radioButton.Name)
                {
                    case "rad_Type":
                        gb_Type.Enabled = true;
                        gb_Device.Enabled = false;
                        break;
                    case "rad_Device":
                        gb_Type.Enabled = false;
                        gb_Device.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void cmb_DeviceType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recordset objRt = null;
            try
            {
                if (cmb_DeviceType2.SelectedItem == null)
                {
                    return;
                }
                ResourceTypeData data = cmb_DeviceType2.SelectedItem as ResourceTypeData;
                if (!m_Application.Workspace.Datasources["Resource"].Datasets.Contains(data.DatasetName))
                {
                    return;
                }
                dgv_Data.Rows.Clear();
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets[data.DatasetName] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewCheckBoxCell());
                    DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell
                    {
                        Value = Convert.ToString(objRt.GetFieldValue(data.FieldID))
                    };
                    row.Cells.Add(cell1);
                    DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell
                    {
                        Value = Convert.ToString(objRt.GetFieldValue(data.FieldName))
                    };
                    row.Cells.Add(cell2);
                    row.Tag = objRt.GetID();
                    dgv_Data.Rows.Add(row);

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
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog
                {
                    Title = "选择上传的文件",
                    InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop),
                    Multiselect = true
                };
                if (open.ShowDialog() == DialogResult.OK)
                {
                    m_SelectFiles = open.FileNames;
                    txt_FilePath.Text = "共选择" + m_SelectFiles.Length.ToString() + "个文件。";
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
