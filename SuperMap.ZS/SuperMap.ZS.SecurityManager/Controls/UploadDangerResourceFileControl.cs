using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Desktop;
using SuperMap.Data;
using SuperMap.ZS.Common;

namespace SuperMap.ZS.SecurityManager
{
    public partial class UploadDangerResourceFileControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;
        private string[] m_SelectFiles;

        public UploadDangerResourceFileControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
            m_Application.Workspace.Closed += Workspace_Closed;
        }

        private void Workspace_Closed(object sender, WorkspaceClosedEventArgs args)
        {
            try
            {
                dgv_Data.Rows.Clear();
                txt_FilePath.Text = "";
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void UploadDangerResourceFileControl_Load(object sender, EventArgs e)
        {
            Recordset objRt = null;

            try
            {
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
                }

                dgv_Data.Rows.Clear();
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["DangerResource"] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewCheckBoxCell());
                    DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell
                    {
                        Value = Convert.ToString(objRt.GetFieldValue("ResourceID"))
                    };
                    row.Cells.Add(cell1);
                    DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell
                    {
                        Value = Convert.ToString(objRt.GetFieldValue("ResourceName"))
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
