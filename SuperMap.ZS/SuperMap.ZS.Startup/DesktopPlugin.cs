using SuperMap.Desktop;
using SuperMap.ZS.Common;
using SuperMap.ZS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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

            return true;
        }

        public override bool ExitInstance()
        {
            return base.ExitInstance();
        }

        private void Init()
        {
            try
            {
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
    }
}
