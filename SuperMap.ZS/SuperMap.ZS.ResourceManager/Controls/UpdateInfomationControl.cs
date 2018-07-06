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

namespace SuperMap.ZS.ResourceManager
{
    public partial class UpdateInfomationControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;

        public UpdateInfomationControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
        }

        private void btnScreenTip_Click(object sender, EventArgs e)
        {
            try
            {
                XElement root = XElement.Load(CommonPars.ScreenTipConfigFilePath);
                root.SetElementValue("CurrentTip", "信息更新");
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CommonPars.ScreenTipName);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void UpdateInfomationControl_Load(object sender, EventArgs e)
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

        private void RadCheckChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton radio = sender as RadioButton;
                switch (radio.Name)
                {
                    case "radEditor":
                        groupBoxExport.Enabled = true;
                        groupBoxNew.Enabled = false;
                        break;
                    case "radNew":
                        groupBoxExport.Enabled = false;
                        groupBoxNew.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
