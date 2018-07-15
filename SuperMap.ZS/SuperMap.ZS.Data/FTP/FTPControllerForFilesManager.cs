using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.Data
{
    /// <summary>
    /// FTP控制器，主要用于文档资料的管理
    /// </summary>
    public class FTPControllerForFilesManager
    {
        private FTPHelper m_ftp = new FTPHelper(new Uri("ftp://" + Properties.Settings.Default.FTP_IP), Properties.Settings.Default.FTP_User, Properties.Settings.Default.FTP_Password);
        private string m_RootDirName = "User";
        /// <summary>
        /// 上传文件完成的委托。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void UploadCompletedHandler(object sender, System.Net.UploadFileCompletedEventArgs e);
        /// <summary>
        /// 上传文件完成事件。
        /// </summary>
        public event UploadCompletedHandler OnUploadCompleted;

        /// <summary>
        /// 上传文件过程的委托。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void UploadProgressHandler(object sender, System.Net.UploadProgressChangedEventArgs e);
        /// <summary>
        /// 上传文件过程事件。
        /// </summary>
        public event UploadProgressHandler OnUploadProcess;

        /// <summary>
        /// 下载文件结束的委托。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DownloadCompleteHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
        /// <summary>
        /// 下载文件结束事件。
        /// </summary>
        public event DownloadCompleteHandler OnDownloadComplete;

        /// <summary>
        /// 下载文件过程的委托。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DownloadProcessHandler(object sender, System.Net.DownloadProgressChangedEventArgs e);
        /// <summary>
        /// 下载文件过程的事件。
        /// </summary>
        public event DownloadProcessHandler OnDownloadProcess;

        /// <summary>
        /// 文件资料的根目录，此项考虑与用户名挂钩，每个用户名新建一个文件夹，默认是User文件夹
        /// </summary>
        public string RootDirName
        {
            get
            {
                return m_RootDirName;
            }
            set
            {
                m_RootDirName = value;
                if (Exist(value, FTPDataType.Directory))
                {
                    m_ftp.GotoDirectory(value);
                }
                else
                {
                    m_ftp.MakeDirectory(value);
                }
            }
        }

        /// <summary>
        /// 判断当前是否为根目录
        /// </summary>
        public bool IsRoot
        {
            get
            {
                bool bResult = false;

                if (m_ftp.DirectoryPath.Equals("/" + CommonPars.DataRootDirInServer + "/" + m_RootDirName + "/"))
                {
                    bResult = true;
                }
                else
                {
                    bResult = false;
                }

                return bResult;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FTPControllerForFilesManager()
        {
            try
            {
                if (m_ftp.GotoDirectory(CommonPars.DataRootDirInServer))
                {
                    if (Exist(m_RootDirName, FTPDataType.Directory))
                    {
                        m_ftp.GotoDirectory(m_RootDirName);
                    }
                    else
                    {
                        m_ftp.MakeDirectory(m_RootDirName);
                    }
                }
                m_ftp.DownloadProgressChanged -= M_ftp2_DownloadProgressChanged;
                m_ftp.DownloadDataCompleted -= M_ftp2_DownloadDataCompleted;
                m_ftp.DownloadProgressChanged += M_ftp2_DownloadProgressChanged;
                m_ftp.DownloadDataCompleted += M_ftp2_DownloadDataCompleted;
                m_ftp.UploadFileCompleted -= M_ftp2_UploadFileCompleted;
                m_ftp.UploadProgressChanged -= M_ftp2_UploadProgressChanged;
                m_ftp.UploadFileCompleted += M_ftp2_UploadFileCompleted;
                m_ftp.UploadProgressChanged += M_ftp2_UploadProgressChanged;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public bool NewDirectory(string dirName)
        {
            bool bResult = false;

            try
            {
                if (!Exist(dirName, FTPDataType.Directory))
                {
                    bResult = m_ftp.MakeDirectory(dirName);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        /// <summary>
        /// 修改文件夹名称
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public bool RenameDirectory(string oldName, string newName)
        {
            bool bResult = false;

            try
            {
                if (Exist(oldName, FTPDataType.Directory))
                {
                    bResult = m_ftp.ReName(oldName, newName);
                }
                else
                {
                    Log.ShowError("文件夹不存在！");
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public bool DeleteDirectory(string dirName)
        {
            bool bResult = false;

            try
            {
                if (Exist(dirName, FTPDataType.Directory))
                {
                    if (m_ftp.GotoDirectory(dirName))
                    {
                        FileStruct[] dirs = m_ftp.ListDirectories();
                        foreach (FileStruct dir in dirs)
                        {
                            DeleteDirectory(dir.Name);
                        }
                        FileStruct[] files = m_ftp.ListFiles();
                        foreach (FileStruct file in files)
                        {
                            m_ftp.DeleteFile(file.Name);
                        }
                        if (m_ftp.ComeoutDirectory())
                        {
                            bResult = m_ftp.RemoveDirectory(dirName);
                        }
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
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool DeleteFile(string fileName)
        {
            bool bResult = false;

            try
            {
                if (Exist(fileName, FTPDataType.Doc))
                {
                    m_ftp.DeleteFile(fileName);
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
        /// 下载文件或文件夹
        /// </summary>
        /// <param name="fileName">要下载的文件名</param>
        /// <param name="savePath">本地存储的完整路径</param>
        /// <param name="dataType">文件名对应的文件类型，主要区分文件夹和文件</param>
        public void Download(string fileName, string savePath, FTPDataType dataType)
        {
            try
            {
                if (dataType == FTPDataType.Directory)
                {
                    if (Exist(fileName, FTPDataType.Directory))
                    {
                        if (m_ftp.GotoDirectory(fileName))
                        {
                            FileStruct[] dirs = m_ftp.ListDirectories();
                            foreach (FileStruct dir in dirs)
                            {
                                System.IO.Directory.CreateDirectory(savePath + "\\" + dir.Name);
                                Download(dir.Name, savePath + "\\" + dir.Name, FTPDataType.Directory);
                            }
                            FileStruct[] files = m_ftp.ListFiles();
                            foreach (FileStruct file in files)
                            {
                                m_ftp.DownloadFileAsync(file.Name, savePath + "\\" + file.Name);
                            }
                            m_ftp.ComeoutDirectory();
                        }
                    }
                }
                else
                {
                    m_ftp.DownloadFileAsync(fileName, savePath);
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
                OnDownloadComplete?.Invoke(sender, e);
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
                OnDownloadProcess?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        /// <summary>
        /// 进入目录
        /// </summary>
        /// <param name="dirName"></param>
        public void ComeInDirectory(string dirName)
        {
            try
            {
                if (Exist(dirName, FTPDataType.Directory))
                {
                    m_ftp.GotoDirectory(dirName);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        /// <summary>
        /// 返回上一级目录
        /// </summary>
        public void ComeOutDirectory()
        {
            try
            {
                m_ftp.ComeoutDirectory();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="path"></param>
        public void UploadFile(string path)
        {
            try
            {
                m_ftp.UploadFileAsync(path, true);

            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        /// <summary>
        /// 上传文件夹
        /// </summary>
        /// <param name="path"></param>
        public void UploadDirectory(string path)
        {
            try
            {
                //if (!System.IO.Directory.Exists(path))
                //{
                //    return;
                //}
                //System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(path);
                //foreach (System.IO.DirectoryInfo dirinfo in dirInfo.GetDirectories())
                //{
                //    UploadDirectory(dirinfo.FullName);
                //}
                //foreach (System.IO.FileInfo fileinfo in dirInfo.GetFiles())
                //{
                    
                //}
                //if (Exist(dirInfo.Name, FTPDataType.Directory))
                //{
                //    if (m_ftp.GotoDirectory(dirInfo.Name))
                //    {

                //    }
                //}
                //m_ftp.UploadFileAsync(path, true);

            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_ftp2_UploadProgressChanged(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            try
            {
                OnUploadProcess?.Invoke(sender, e);
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
                OnUploadCompleted?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Log.ShowError(m_ftp.ErrorMsg);
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<FTPDataInfo> GetData()
        {
            List<FTPDataInfo> lstResult = new List<FTPDataInfo>();

            try
            {
                FileStruct[] files = m_ftp.ListFiles();
                foreach (FileStruct file in files)
                {
                    FTPDataInfo info = new FTPDataInfo
                    {
                        Name = file.Name,
                        Path = m_ftp.DirectoryPath + file.Name,
                    };
                    string ext = file.Name.Split('.')[file.Name.Split('.').Length - 1];
                    switch (ext)
                    {
                        case "doc":
                        case "docx":
                            info.Type = FTPDataType.Doc;
                            break;
                        case "xls":
                        case "xlsx":
                            info.Type = FTPDataType.Excel;
                            break;
                        case "pdf":
                            info.Type = FTPDataType.PDF;
                            break;
                        case "rar":
                            info.Type = FTPDataType.RAR;
                            break;
                        case "ppt":
                        case "pptx":
                            info.Type = FTPDataType.PPT;
                            break;
                        case "mp4":
                        case "avi":
                        case "mov":
                        case "flv":
                        case "swf":
                            info.Type = FTPDataType.Video;
                            break;
                        case "jpg":
                        case "png":
                        case "bmp":
                        case "jpeg":
                        case "img":
                        case "tif":
                            info.Type = FTPDataType.Image;
                            break;
                        case "dwg":
                        case "dxf":
                            info.Type = FTPDataType.CAD;
                            break;
                        default:
                            info.Type = FTPDataType.Other;
                            break;
                    }
                    lstResult.Add(info);
                }

                FileStruct[] dirs = m_ftp.ListDirectories();
                foreach (FileStruct dir in dirs)
                {
                    FTPDataInfo info = new FTPDataInfo
                    {
                        Name = dir.Name,
                        Path = m_ftp.DirectoryPath + dir.Name,
                        Type = FTPDataType.Directory
                    };
                    lstResult.Add(info);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return lstResult;
        }

        /// <summary>
        /// 进入某一个文件夹
        /// </summary>
        /// <param name="dirName"></param>
        public void ChangeDirectory(string dirName)
        {
            try
            {
                if (Exist(dirName, FTPDataType.Directory))
                {
                    m_ftp.GotoDirectory(dirName);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private bool Exist(string name, FTPDataType type)
        {
            bool bResult = false;

            try
            {
                switch (type)
                {
                    case FTPDataType.Directory:
                        bResult = m_ftp.DirectoryExist(name);
                        break;
                    default:
                        bResult = m_ftp.FileExist(name);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }
    }

    /// <summary>
    /// FTP数据信息
    /// </summary>
    public class FTPDataInfo
    {
        /// <summary>
        /// 数据路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public FTPDataType Type { get; set; }

        /// <summary>
        /// 数据名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// FTP数据类型
    /// </summary>
    public enum FTPDataType
    {
        /// <summary>
        /// 文件夹
        /// </summary>
        Directory = 1,
        /// <summary>
        /// Word文档
        /// </summary>
        Doc = 2,
        /// <summary>
        /// PDF文档
        /// </summary>
        PDF = 3,
        /// <summary>
        /// Excel文档
        /// </summary>
        Excel = 4,
        /// <summary>
        /// PPT文档
        /// </summary>
        PPT = 5,
        /// <summary>
        /// 图片
        /// </summary>
        Image = 6,
        /// <summary>
        /// 视频
        /// </summary>
        Video = 7,
        /// <summary>
        /// 压缩文件
        /// </summary>
        RAR = 8,
        /// <summary>
        /// 其他文档
        /// </summary>
        Other = 9,
        /// <summary>
        /// CAD文档
        /// </summary>
        CAD = 10,
    }
}
