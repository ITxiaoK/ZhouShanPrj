using SuperMap.Desktop;
using SuperMap.ZS.Common;
using SuperMap.ZS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SuperMap.ZS.Startup
{
    public class DesktopPlugin : Plugin
    {
        public DesktopPlugin(PluginInfo pluginInfo) : base(pluginInfo)
        {
        }

        public override bool Initialize()
        {
            Init();
            Application.ActiveApplication.Workspace.Opened += Workspace_Opened;
            Application.ActiveApplication.Workspace.Closed += Workspace_Closed;

            return true;
        }

        private void Workspace_Closed(object sender, SuperMap.Data.WorkspaceClosedEventArgs args)
        {
            try
            {
                CommonPars.WorkspaceOpen = false;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void Workspace_Opened(object sender, SuperMap.Data.WorkspaceOpenedEventArgs e)
        {
            try
            {
                CommonPars.WorkspaceOpen = true;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        public override bool ExitInstance()
        {
            foreach (var item in System.Diagnostics.Process.GetProcessesByName(CommonPars.ScreenTipName))
            {
                item.Kill();
            }
            return true;
        }

        private void Init()
        {
            try
            {
                DirectoryInfo topDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
                CommonPars.ScreenTipConfigFilePath = topDir.Parent.FullName + "\\Configuration\\SuperMap.ZS.Config.xml";
                XElement root = XElement.Load(CommonPars.ScreenTipConfigFilePath);

                CommonPars.ScreenTipName = root.Element("ScreenTipProgremName").Value;
                CommonPars.ScreenTipType = (ScreenTipType)Enum.Parse(typeof(ScreenTipType), root.Element("ScreenTipType").Value);
                if (CommonPars.ScreenTipType == ScreenTipType.Next)
                {
                    MessageServer server = new MessageServer();
                    server.StartReceive();
                    server.OnReceived += Server_OnReceived;
                }

                string sql = "select * from workspaceserverinfo";
                DataSet dt = DbHelperMySQL.GetDataSet(DbHelperMySQL.Conn, CommandType.Text, sql);
                if(dt.Tables.Count >0&& dt.Tables[0].Rows.Count > 0)
                {
                    CommonPars.DataRootDirInServer = dt.Tables[0].Rows[0]["WorkspaceServerPath"].ToString();
                    CommonPars.OriginalDirInServer = dt.Tables[0].Rows[0]["OriginalDir"].ToString();
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void Server_OnReceived(object sender, ReceiveMessageData e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Message))
                {
                    Application.ActiveApplication.MainForm.SelectedTabID = e.Message;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
