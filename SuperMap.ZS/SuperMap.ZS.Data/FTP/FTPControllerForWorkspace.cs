using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.Data
{
    /// <summary>
    /// FTP控制器，主要用于工作空间文件及文件夹的提交与更新
    /// </summary>
    public class FTPControllerForWorkspacceForWorkspace
    {
        private FTPHelper m_ftp = new FTPHelper(new Uri("ftp://" + Properties.Settings.Default.FTP_IP), Properties.Settings.Default.FTP_User, Properties.Settings.Default.FTP_Password);
        private string m_CurrentPath = "";

        /// <summary>
        /// 更新文件总数
        /// </summary>
        public int UpdateFilesCount { get; private set; } = 0;

        /// <summary>
        /// 提交文件总数
        /// </summary>
        public int CommitFilesCount { get; private set; } = 0;

        /// <summary>
        /// 提交文件完成的委托。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void CommitCompletedHandler(object sender, System.Net.UploadFileCompletedEventArgs e);
        /// <summary>
        /// 提交文件完成事件。
        /// </summary>
        public event CommitCompletedHandler OnCommitCompleted;

        /// <summary>
        /// 提交文件过程的委托。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CommitProgressHandler(object sender, System.Net.UploadProgressChangedEventArgs e);
        /// <summary>
        /// 提交文件过程事件。
        /// </summary>
        public event CommitProgressHandler OnCommitProcess;

        /// <summary>
        /// 更新文件结束的委托。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void UpdateCompleteHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
        /// <summary>
        /// 更新文件结束事件。
        /// </summary>
        public event UpdateCompleteHandler OnUpdateComplete;

        /// <summary>
        /// 更新文件过程的委托。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void UpdateProcessHandler(object sender, System.Net.DownloadProgressChangedEventArgs e);
        /// <summary>
        /// 更新文件过程的事件。
        /// </summary>
        public event UpdateProcessHandler OnUpdateProcess;

        /// <summary>
        /// 更新数据到本地
        /// </summary>
        /// <param name="workspacePath">本地工作空间路径</param>
        public void Update(string workspacePath)
        {
            try
            {
                string[] pars = workspacePath.Split('\\');
                string workspaceName = pars[pars.Length - 1].Split('.')[0];

                string destDir = workspacePath.Substring(0, workspacePath.LastIndexOf("\\"));
                Directory.Delete(destDir, true);
                Directory.CreateDirectory(destDir);

                //从数据库中获取工程名称的工作空间信息
                WorkspaceInfo existInfo = new WorkspaceInfo();
                existInfo = existInfo.GetData(workspaceName) as WorkspaceInfo;

                if (existInfo != null && existInfo.IsUpdate)
                {
                    ComeoutDir(m_ftp.DirectoryPath);
                    if (m_ftp.GotoDirectory(existInfo.WorkspaceServerPath))
                    {
                        m_CurrentPath = m_ftp.DirectoryPath;
                        FileStruct[] files = m_ftp.ListFiles();
                        UpdateFilesCount = files.Length;
                        m_ftp.DownloadProgressChanged -= M_ftp2_DownloadProgressChanged;
                        m_ftp.DownloadDataCompleted -= M_ftp2_DownloadDataCompleted;
                        m_ftp.DownloadProgressChanged += M_ftp2_DownloadProgressChanged;
                        m_ftp.DownloadDataCompleted += M_ftp2_DownloadDataCompleted;
                        foreach (FileStruct fs in files)
                        {
                            m_ftp.DownloadFileAsync(fs.Name, destDir + "\\" + fs.Name);
                        }
                        //修改数据库中工作空间信息数据表
                        existInfo.IsUpdate = false;
                        existInfo.Update(existInfo);
                    }

                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        /// <summary>
        /// 下载原始数据
        /// </summary>
        /// <param name="dirPath">要保存的本地目录</param>
        public void UpdateOriginalData(string dirPath)
        {
            try
            {
                ComeoutDir(m_ftp.DirectoryPath);
                if(m_ftp.DirectoryExist(CommonPars.DataRootDirInServer))
                {
                    if (m_ftp.GotoDirectory(CommonPars.DataRootDirInServer))
                    {
                        m_CurrentPath = m_ftp.DirectoryPath;
                        if (m_ftp.DirectoryExist(CommonPars.OriginalDirInServer))
                        {
                            if (m_ftp.GotoDirectory(CommonPars.OriginalDirInServer))
                            {
                                m_CurrentPath = m_ftp.DirectoryPath;
                                FileStruct[] files = m_ftp.ListFiles();
                                UpdateFilesCount = files.Length;
                                m_ftp.DownloadProgressChanged -= M_ftp2_DownloadProgressChanged;
                                m_ftp.DownloadDataCompleted -= M_ftp2_DownloadDataCompleted;
                                m_ftp.DownloadProgressChanged += M_ftp2_DownloadProgressChanged;
                                m_ftp.DownloadDataCompleted += M_ftp2_DownloadDataCompleted;
                                foreach (FileStruct fs in files)
                                {
                                    m_ftp.DownloadFileAsync(fs.Name, dirPath + "\\" + fs.Name);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        private void ComeoutDir(string dir)
        {
            try
            {
                if(!m_ftp.DirectoryPath.Equals("/"))
                {
                    if (m_ftp.ComeoutDirectory())
                    {
                        m_CurrentPath = m_ftp.DirectoryPath;
                        ComeoutDir(m_ftp.DirectoryPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_ftp2_DownloadDataCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                OnUpdateComplete?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        private void M_ftp2_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            try
            {
                OnUpdateProcess?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        /// <summary>
        /// 提交数据到服务器
        /// </summary>
        /// <param name="workspacePath">本地工作空间路径</param>
        public void Commit(string workspacePath)
        {
            try
            {
                string[] pars = workspacePath.Split('\\');
                string workspaceName = pars[pars.Length - 1].Split('.')[0];

                if (!m_ftp.DirectoryPath.Equals("/" + CommonPars.DataRootDirInServer + "/"))
                {
                    if (m_ftp.GotoDirectory(CommonPars.DataRootDirInServer))
                    {
                        m_CurrentPath = m_ftp.DirectoryPath;
                        if (m_ftp.DirectoryExist(workspaceName))
                        {
                            Delete(workspacePath);
                        }
                        if (m_ftp.MakeDirectory(workspaceName))
                        {
                            if (m_ftp.GotoDirectory(workspaceName))
                            {
                                m_CurrentPath = m_ftp.DirectoryPath;
                                string localDirPath = workspacePath.Substring(0, workspacePath.LastIndexOf("\\"));
                                m_ftp.UploadFileCompleted -= M_ftp2_UploadFileCompleted;
                                m_ftp.UploadProgressChanged -= M_ftp2_UploadProgressChanged;
                                m_ftp.UploadFileCompleted += M_ftp2_UploadFileCompleted;
                                m_ftp.UploadProgressChanged += M_ftp2_UploadProgressChanged;
                                string[] files = Directory.GetFiles(localDirPath);
                                CommitFilesCount = files.Length;
                                foreach (string filename in files)
                                {
                                    m_ftp.UploadFileAsync(filename, true);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (m_ftp.DirectoryExist(workspaceName))
                    {
                        Delete(workspacePath);
                    }
                    if (m_ftp.MakeDirectory("/" + workspaceName))
                    {
                        if (m_ftp.GotoDirectory(workspaceName))
                        {
                            m_CurrentPath = m_ftp.DirectoryPath;
                            string localDirPath = workspacePath.Substring(0, workspacePath.LastIndexOf("\\"));
                            m_ftp.UploadFileCompleted -= M_ftp2_UploadFileCompleted;
                            m_ftp.UploadProgressChanged -= M_ftp2_UploadProgressChanged;
                            m_ftp.UploadFileCompleted += M_ftp2_UploadFileCompleted;
                            m_ftp.UploadProgressChanged += M_ftp2_UploadProgressChanged;
                            foreach (string filename in Directory.GetFiles(localDirPath))
                            {
                                m_ftp.UploadFileAsync(filename, true);
                            }
                        }
                    }
                }

                WorkspaceInfo info = new WorkspaceInfo()
                {
                    IsUpdate = true,
                    WorkspaceName = workspaceName,
                    WorkspaceServerPath = CommonPars.DataRootDirInServer + "/" + workspaceName
                };

                info.AddData(info);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        private void M_ftp2_UploadProgressChanged(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            try
            {
                OnCommitProcess?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        private void M_ftp2_UploadFileCompleted(object sender, System.Net.UploadFileCompletedEventArgs e)
        {
            try
            {
                OnCommitCompleted?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        /// <summary>
        /// 判断服务器上是否有该工程的目录
        /// </summary>
        /// <param name="workspacePath">本地工作空间路径</param>
        /// <returns></returns>
        public bool Exist(string workspacePath)
        {
            bool bResult = false;

            try
            {
                string[] pars = workspacePath.Split('\\');
                string workspaceName = pars[pars.Length - 1].Split('.')[0];
                
                if (!m_ftp.DirectoryPath.Equals(m_CurrentPath))
                {
                    if (m_ftp.GotoDirectory(CommonPars.DataRootDirInServer))
                    {
                        m_CurrentPath = m_ftp.DirectoryPath;
                        if (m_ftp.DirectoryExist(workspaceName))
                        {
                            bResult = true;
                        }
                    }
                }
                else
                {
                    if (m_ftp.DirectoryExist(workspaceName))
                    {
                        bResult = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }

            return bResult;
        }

        /// <summary>
        /// 删除服务器上工程目录下的所有文件
        /// </summary>
        /// <param name="workspacePath">本地工作空间路径</param>
        /// <returns></returns>
        public bool Delete(string workspacePath)
        {
            bool bResult = false;

            try
            {
                string[] pars = workspacePath.Split('\\');
                string workspaceName = pars[pars.Length - 1].Split('.')[0];
                
                if (!m_ftp.DirectoryPath.Equals(m_CurrentPath))
                {
                    if (m_ftp.GotoDirectory(m_CurrentPath))
                    {
                        m_CurrentPath = m_ftp.DirectoryPath;
                        if (m_ftp.DirectoryExist(workspaceName))
                        {
                            if (m_ftp.GotoDirectory(workspaceName))
                            {
                                m_CurrentPath = m_ftp.DirectoryPath;
                                FileStruct[] files = m_ftp.ListFiles();
                                foreach (FileStruct fs in files)
                                {
                                    m_ftp.DeleteFile(fs.Name);
                                }
                                if (m_ftp.ComeoutDirectory())
                                {
                                    m_CurrentPath = m_ftp.DirectoryPath;
                                    if (m_ftp.RemoveDirectory(workspaceName))
                                    {
                                        WorkspaceInfo info = new WorkspaceInfo();
                                        bResult = info.DeleteData((info.GetData(workspaceName) as WorkspaceInfo).ID);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (m_ftp.DirectoryExist(workspaceName))
                    {
                        if (m_ftp.GotoDirectory(workspaceName))
                        {
                            m_CurrentPath = m_ftp.DirectoryPath;
                            FileStruct[] files = m_ftp.ListFiles();
                            foreach (FileStruct fs in files)
                            {
                                m_ftp.DeleteFile(fs.Name);
                            }
                            if (m_ftp.ComeoutDirectory())
                            {
                                m_CurrentPath = m_ftp.DirectoryPath;
                                if (m_ftp.RemoveDirectory(workspaceName))
                                {
                                    WorkspaceInfo info = new WorkspaceInfo();
                                    bResult = info.DeleteData((info.GetData(workspaceName) as WorkspaceInfo).ID);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }

            return bResult;
        }
    }
}
