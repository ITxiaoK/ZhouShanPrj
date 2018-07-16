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
using System.Xml.Linq;
using System.Diagnostics;

namespace SuperMap.ZS.SecurityManager
{
    public partial class DangerResourceLocationControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;

        public DangerResourceLocationControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
            m_Application.Workspace.Closed += Workspace_Closed;
        }

        private void Workspace_Closed(object sender, WorkspaceClosedEventArgs args)
        {
            try
            {
                dg_Data.Rows.Clear();
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
                root.SetElementValue("CurrentTip", "设备定位");
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CommonPars.ScreenTipName);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void DangerResourceLocationControl_Load(object sender, EventArgs e)
        {
            if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
            {
                m_SceneControl = formScene.SceneControl;
            }

            Recordset objRt = null;
            try
            {
                dg_Data.Rows.Clear();
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["DangerResource"] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell
                    {
                        Value = Convert.ToString(objRt.GetFieldValue("ResourceID"))
                    };
                    row.Cells.Add(cell1);

                    int isSet = 0;
                    if (objRt.GetFieldValue("Heading") == null && objRt.GetFieldValue("Altitude") == null)
                    {
                        isSet = 0;
                    }
                    else
                    {
                        isSet = 1;
                    }
                    DataGridViewCheckBoxCell cell2 = new DataGridViewCheckBoxCell
                    {
                        Value = isSet
                    };
                    row.Cells.Add(cell2);
                    row.Tag = objRt.GetID();
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
                if (objRt != null)
                {
                    objRt.Close();
                    objRt.Dispose();
                }
            }
        }

        private void btnGetCamera_Click(object sender, EventArgs e)
        {
            Recordset objRt = null;

            try
            {
                if (dg_Data.SelectedRows.Count == 0)
                {
                    m_Application.MessageBox.Show("未选中数据！");
                    return;
                }
                DataGridViewRow row = dg_Data.SelectedRows[0];
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["DangerResource"] as DatasetVector).GetRecordset(false, CursorType.Dynamic);
                if (objRt.SeekID(Convert.ToInt32(row.Tag)) && objRt.Edit())
                {
                    objRt.SetFieldValue("Longitude", m_SceneControl.Scene.Camera.Longitude);
                    objRt.SetFieldValue("Latitude", m_SceneControl.Scene.Camera.Latitude);
                    objRt.SetFieldValue("Altitude", m_SceneControl.Scene.Camera.Altitude);
                    objRt.SetFieldValue("Heading", m_SceneControl.Scene.Camera.Heading);
                    objRt.SetFieldValue("Tilt", m_SceneControl.Scene.Camera.Tilt);

                    if (objRt.Update())
                    {
                        m_Application.MessageBox.Show("视角保存成功！");
                    }
                    else
                    {
                        m_Application.MessageBox.Show("视角保存失败！");
                    }
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
    }
}
