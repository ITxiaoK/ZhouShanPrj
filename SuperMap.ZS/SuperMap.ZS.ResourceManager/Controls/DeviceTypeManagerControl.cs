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
        private List<Label> m_lstType;

        public DeviceTypeManagerControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
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
                    m_lstType = new List<Label>();
                }
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ResourceTable"] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    m_lstType.Add(new Label { Text = Convert.ToString(objRt.GetFieldValue("SourceName")), Tag=Convert.ToString(objRt.GetFieldValue("TableName")) });

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
                cmbDeviceType.DisplayMember = "Text";
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
            Recordset objRt = null;

            try
            {
                dgv_TypeData.Rows.Clear();
                string strDatasetName = Convert.ToString((cmbDeviceType.SelectedItem as Label).Tag) + "Type";
                if (m_Application.Workspace.Datasources["Resource"].Datasets[strDatasetName] == null)
                {
                    return;
                }
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets[strDatasetName] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Convert.ToString(objRt.GetFieldValue("TypeName")) });
                    dgv_TypeData.Rows.Add(row);

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
    }
}
