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
using SuperMap.Realspace;

namespace SuperMap.ZS.Startup
{
    public partial class FlyRouteControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;
        private List<Label> lstData;

        public FlyRouteControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
        }

        private void btnScreenTip_Click(object sender, EventArgs e)
        {
            try
            {
                XElement root = XElement.Load(CommonPars.ScreenTipConfigFilePath);
                root.SetElementValue("CurrentTip", "飞行路线入库");
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CommonPars.ScreenTipName);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void FlyRouteControl_Load(object sender, EventArgs e)
        {
            try
            {
                chkFlyRoute.Items.Clear();
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void LoadData()
        {
            try
            {
                if (lstData == null)
                {
                    lstData = new List<Label>();
                }
                foreach (Route route in m_SceneControl.Scene.FlyManager.Routes)
                {
                    lstData.Add(new Label { Text = route.Name, Tag = route });
                }
                chkFlyRoute.DataSource = lstData;
                chkFlyRoute.DisplayMember = "Text";
                chkFlyRoute.ValueMember = "Tag";
                chkFlyRoute.SetItemChecked(0, true);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void FlyRouteControl_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                lstData.Clear();
                foreach (Route route in m_SceneControl.Scene.FlyManager.Routes)
                {
                    lstData.Add(new Label { Text = route.Name, Tag = route });
                }
                chkFlyRoute.DataSource = null;
                chkFlyRoute.DataSource = lstData;
                chkFlyRoute.DisplayMember = "Text";
                chkFlyRoute.ValueMember = "Tag";
                chkFlyRoute.SetItemChecked(0, true);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
