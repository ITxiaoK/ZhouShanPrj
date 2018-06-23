using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperMap.ZS.Common
{
    /// <summary>
    /// 日志记录器
    /// </summary>
    public class Log
    {
        private static string strLogPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="ex"></param>
        public static void OutputBox(Exception ex)
        {
            try
            {
                if (!Directory.Exists(strLogPath + @"\AppLog"))
                {
                    Directory.CreateDirectory(strLogPath + @"\AppLog");
                }

                string strLogFilePath = strLogPath + string.Format(@"\AppLog\App_{0}_{1}_{2}_{3}_{4}_{5}.log",
                    DateTime.Now.Year.ToString(),
                    DateTime.Now.Month.ToString(),
                    DateTime.Now.Day.ToString(),
                    DateTime.Now.Hour.ToString(),
                    DateTime.Now.Minute.ToString(),
                    DateTime.Now.Second.ToString());

                StreamWriter logWriter = File.CreateText(strLogFilePath);
                logWriter.WriteLine(ex.Message + "\n\t" + ex.StackTrace);
                logWriter.Close();
            }
            catch
            { }
        }

        /// <summary>
        /// 提示错误信息
        /// </summary>
        /// <param name="message"></param>
        public static void ShowError(string message)
        {
            try
            {
                MessageBox.Show(message);
            }
            catch
            {

                throw;
            }
        }
    }
}
