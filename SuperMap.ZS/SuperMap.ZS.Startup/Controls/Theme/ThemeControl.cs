using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Xml.Linq;
using System.Text;
using SuperMap.ZS.Common;
using System.Diagnostics;
using DevExpress.XtraEditors;
using SuperMap.Desktop;

namespace SuperMap.ZS.Startup
{
    public partial class ThemeControl : XtraUserControl
    {
        private Application m_Application;
        private MessageServer server;


        public ThemeControl()
        {
            InitializeComponent();
            m_Application = Application.ActiveApplication;
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

            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
