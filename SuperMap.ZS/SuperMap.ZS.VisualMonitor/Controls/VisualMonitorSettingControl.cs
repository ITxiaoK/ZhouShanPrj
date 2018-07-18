using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.ZS.Common;
using SuperMap.ZS.Data;
using SuperMap.Desktop;

namespace SuperMap.ZS.VisualMonitor
{
    public partial class VisualMonitorSettingControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;

        public MonitorType MonitorType { get; set; } = MonitorType.SCADA;

        public VisualMonitorSettingControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
            m_Application.Workspace.Closed += Workspace_Closed;
        }

        private void Workspace_Closed(object sender, SuperMap.Data.WorkspaceClosedEventArgs args)
        {
            try
            {
                txt_Path.Text = "";
                dgv_Data.DataSource = null;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Title = "导入配置文件",
                    Filter = "Excel文件|*.xlsx|Excel文件|*.xls",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Multiselect = false,
                };
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    txt_Path.Text = openFile.FileName;
                    ExcelHelper excel = new ExcelHelper();
                    DataSet ds = excel.FromFile(openFile.FileName);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        m_Application.MessageBox.Show("未读到数据！若表中包含数据，请放在第一页中。");
                        return;
                    }
                    dgv_Data.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void VisualMonitorSettingControl_Load(object sender, EventArgs e)
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

        private void btnImport_Click(object sender, EventArgs e)
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

    public enum MonitorType
    {
        SCADA,
        Video,
        EntranceGuard,
        FireAlarm,
        Weather
    }
}
