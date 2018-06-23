using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.Data
{
    /// <summary>
    /// FTP控制器，主要用于文件及文件夹的提交与更新
    /// </summary>
    public class FTPController
    {
        private static FTPHelper m_ftp;
        private static string m_FTPPath = "";
        private static string m_CurrentPath = "";

        /// <summary>
        /// 更新数据到本地
        /// </summary>
        /// <param name="workspacePath">本地工作空间路径</param>
        public static bool Update(string workspacePath)
        {
            bool bResult = false;

            try
            {
                if (m_ftp == null)
                {
                    m_ftp = new FTPHelper(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_User, Properties.Settings.Default.FTP_Password);
                    m_FTPPath = m_ftp.CurrentDirPath;
                }

                string[] pars = workspacePath.Split('\\');
                string dirName = pars[pars.Length - 1].Split('.')[0];

                string destDir = workspacePath.Substring(0, workspacePath.LastIndexOf("\\"));
                Directory.Delete(destDir, true);
                Directory.CreateDirectory(destDir);

                //从数据库中获取工程名称的工作空间信息
                WorkspaceInfo existInfo = new WorkspaceInfo();
                existInfo = existInfo.GetData(dirName) as WorkspaceInfo;

                if (existInfo != null)
                {
                    //切换到FTP数据根目录
                    m_ftp.GotoDirectory(m_FTPPath + existInfo.WorkspaceServerPath, true);
                    //检查该工程文件夹是否存在
                    if (m_ftp.DirectoryExist(dirName))
                    {
                        bResult = false;
                    }
                    else
                    {
                        //获取这个文件夹下的所有文件列表
                        string[] files = m_ftp.GetFilesDetailList();
                        foreach (string file in files)
                        {
                            string fileName = file.Split(' ')[file.Split(' ').Length - 1];
                            string url = m_FTPPath + existInfo.WorkspaceServerPath + "/" + fileName;
                            m_ftp.Download(destDir, url, fileName);
                        }

                        //修改数据库中工作空间信息数据表
                        existInfo.IsUpdate = false;
                        bResult = existInfo.Update(existInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        /// <summary>
        /// 提交数据到服务器
        /// </summary>
        /// <param name="workspacePath">本地工作空间路径</param>
        public static bool Commit(string workspacePath)
        {
            bool bResult = false;

            try
            {
                if (m_ftp == null)
                {
                    m_ftp = new FTPHelper(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_User, Properties.Settings.Default.FTP_Password);
                    m_FTPPath = m_ftp.CurrentDirPath;
                }

                string[] pars = workspacePath.Split('\\');
                string dirName = pars[pars.Length - 1].Split('.')[0];

                //从数据库中获取工程名称的工作空间信息
                WorkspaceInfo existInfo = new WorkspaceInfo();
                existInfo = existInfo.GetData(dirName) as WorkspaceInfo;

                if (existInfo == null)
                {
                    //1、切换到FTP数据根目录
                    m_CurrentPath = m_FTPPath + CommonPars.DataRootDirInServer;
                    m_ftp.GotoDirectory(m_CurrentPath, true);
                    //2、检查该工程文件夹是否存在
                    if (m_ftp.DirectoryExist(dirName))
                    {
                        bResult = false;
                    }
                    else
                    {
                        //3、创建新的文件夹
                        m_ftp.MakeDir(dirName);
                        //4、切换到创建的目录下
                        m_CurrentPath = m_FTPPath + CommonPars.DataRootDirInServer + "/" + dirName;
                        m_ftp.GotoDirectory(m_CurrentPath, true);
                        //5、上传文件到新建的文件夹中
                        string localDirPath = workspacePath.Substring(0, workspacePath.LastIndexOf("\\"));
                        foreach (string filename in Directory.GetFiles(localDirPath))
                        {
                            m_ftp.Upload(filename);
                        }
                        //6、修改数据库中工作空间信息数据表
                        WorkspaceInfo info = new WorkspaceInfo()
                        {
                            IsUpdate = true,
                            WorkspaceName = dirName,
                            WorkspaceServerPath = CommonPars.DataRootDirInServer + "/" + dirName
                        };

                        bResult = info.AddData(info);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        /// <summary>
        /// 判断服务器上是否有该工程的目录
        /// </summary>
        /// <param name="workspacePath">本地工作空间路径</param>
        /// <returns></returns>
        public static bool Exist(string workspacePath)
        {
            bool bResult = false;

            try
            {
                if (m_ftp == null)
                {
                    m_ftp = new FTPHelper(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_User, Properties.Settings.Default.FTP_Password);
                    m_FTPPath = m_ftp.CurrentDirPath;
                }

                string[] pars = workspacePath.Split('\\');
                string dirName = pars[pars.Length - 1].Split('.')[0];

                //1、切换到FTP数据根目录
                m_CurrentPath = m_FTPPath + CommonPars.DataRootDirInServer;
                m_ftp.GotoDirectory(m_CurrentPath, true);
                //2、检查该工程文件夹是否存在
                if (m_ftp.DirectoryExist(dirName))
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        /// <summary>
        /// 删除服务器上工程目录下的所有文件
        /// </summary>
        /// <param name="workspacePath">本地工作空间路径</param>
        /// <returns></returns>
        public static bool Delete(string workspacePath)
        {
            bool bResult = false;

            try
            {
                if (m_ftp == null)
                {
                    m_ftp = new FTPHelper(Properties.Settings.Default.FTP_IP, Properties.Settings.Default.FTP_User, Properties.Settings.Default.FTP_Password);
                    m_FTPPath = m_ftp.CurrentDirPath;
                }

                string[] pars = workspacePath.Split('\\');
                string dirName = pars[pars.Length - 1].Split('.')[0];

                //1、切换到FTP数据根目录
                m_CurrentPath = m_FTPPath + CommonPars.DataRootDirInServer;
                m_ftp.GotoDirectory(m_CurrentPath, true);
                //2、检查该工程文件夹是否存在
                if (m_ftp.DirectoryExist(dirName))
                {
                    //3、检查文件夹下是否有文件，若有，删除
                    if (m_ftp.FileExist(dirName))
                    {
                        //4、切换到这个目录下
                        m_CurrentPath = m_FTPPath + CommonPars.DataRootDirInServer + "/" + dirName;
                        m_ftp.GotoDirectory(m_CurrentPath, true);
                        //4、获取这个文件夹下的所有文件列表
                        string[] files = m_ftp.GetFilesDetailList();
                        foreach(string file in files)
                        {
                            string name = m_CurrentPath + "/" + file.Split(' ')[file.Split(' ').Length - 1];
                            m_ftp.Delete(name);
                        }
                    }
                    m_CurrentPath = m_FTPPath + CommonPars.DataRootDirInServer;
                    m_ftp.GotoDirectory(m_CurrentPath, true);
                    m_ftp.RemoveDirectory(dirName);

                    WorkspaceInfo info = new WorkspaceInfo();
                    bResult = info.DeleteData((info.GetData(dirName) as WorkspaceInfo).ID);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }
    }
}
