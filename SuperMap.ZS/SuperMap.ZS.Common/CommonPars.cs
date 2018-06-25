using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.Common
{
    /// <summary>
    /// 系统通用参数
    /// </summary>
    public class CommonPars
    {

        /// <summary>
        /// 服务器中工程所在的根目录
        /// </summary>
        public static string DataRootDirInServer { get; set; }

        /// <summary>
        /// 服务器中原始工程数据目录
        /// </summary>
        public static string OriginalDirInServer { get; set; }

        /// <summary>
        /// 当前工作空间目录
        /// </summary>
        public static string CurrentWorkspaceDir { get; set; }
    }
}
