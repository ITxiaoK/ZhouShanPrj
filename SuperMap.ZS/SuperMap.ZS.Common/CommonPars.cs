using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// 工作空间是否已经打开
        /// </summary>
        public static bool WorkspaceOpen { get; set; } = false;

        /// <summary>
        /// 屏幕提示程序名称
        /// </summary>
        public static string ScreenTipName { get; set; }

        /// <summary>
        /// 屏幕提示配置文件路径
        /// </summary>
        public static string ScreenTipConfigFilePath { get; set; }

        /// <summary>
        /// 屏幕提示类型，默认是窗口轮播图形式。
        /// </summary>
        public static ScreenTipType ScreenTipType { get; set; } = ScreenTipType.Window;

        /// <summary>
        /// 打开数据是否为舟山数据，默认为false。
        /// </summary>
        public static bool IsZhouShanData { get; set; } = false;
    }

    /// <summary>
    /// 屏幕提示类型
    /// </summary>
    public enum ScreenTipType
    {
        /// <summary>
        /// Window显示，图片轮播
        /// </summary>
        Window = 1,
        /// <summary>
        /// 全屏提示，提示信息靠近要提示的内容
        /// </summary>
        Next = 2
    }
}
