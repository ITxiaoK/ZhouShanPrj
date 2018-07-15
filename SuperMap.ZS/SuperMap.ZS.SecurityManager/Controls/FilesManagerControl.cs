using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.ZS.Common;
using SuperMap.ZS.Data;
using SuperMap.Desktop;
using System.IO;

namespace SuperMap.ZS.SecurityManager
{
    public partial class FilesManagerControl : UserControl
    {
        private FTPControllerForFilesManager m_Ftp;
        private bool m_isNewName = false;
        private string m_oldName = "";
        private Desktop.Application m_Application;
        private int m_loadIndex = 1;

        public FilesManagerControl()
        {
            InitializeComponent();
        }

        private void FilesManagerControl_Load(object sender, EventArgs e)
        {
            try
            {
                m_Ftp = new FTPControllerForFilesManager();
                m_Ftp.OnDownloadProcess += M_Ftp_OnDownloadProcess;
                m_Ftp.OnDownloadComplete += M_Ftp_OnDownloadComplete;
                m_Ftp.OnUploadCompleted += M_Ftp_OnUploadCompleted;
                m_Ftp.OnUploadProcess += M_Ftp_OnUploadProcess;
                LoadData();
                m_Application = Desktop.Application.ActiveApplication;
                m_Application.Workspace.Closed += Workspace_Closed;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void Workspace_Closed(object sender, SuperMap.Data.WorkspaceClosedEventArgs args)
        {
            try
            {
                lstData.Items.Clear();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in lstData.Items)
                {
                    item.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnSelectChange_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in lstData.Items)
                {
                    item.Checked = !item.Checked;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void lstData_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                m_oldName = (sender as ListView).SelectedItems[0].Text;
                if (e.CancelEdit)
                {
                    m_oldName = "";
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void lstData_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                if (e.CancelEdit)
                {
                    return;
                }
                if (m_isNewName)
                {
                    m_Ftp.NewDirectory(e.Label);
                }
                else
                {
                    m_Ftp.RenameDirectory(m_oldName, e.Label);
                }

                m_isNewName = false;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = new ListViewItem
                {
                    ImageIndex = 0
                };
                lstData.Items.Add(item);
                item.BeginEdit();
                m_isNewName = true;
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
                lstData.Items.Clear();
                List<FTPDataInfo> lst = m_Ftp.GetData();
                if (!m_Ftp.IsRoot)
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = "上级目录",
                        ImageIndex = 0
                    };
                    lstData.Items.Add(item);
                }
                foreach (FTPDataInfo info in lst)
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = info.Name,
                        ImageIndex = Convert.ToInt32(info.Type),
                        Tag = info,
                    };
                    lstData.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnReName_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstData.SelectedItems.Count != 1)
                {
                    m_Application.MessageBox.Show("请选择一条数据");
                    return;
                }
                ListViewItem item = lstData.SelectedItems[0];
                item.BeginEdit();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_Application.MessageBox.Show("确定要删除这" + lstData.CheckedItems.Count + "项数据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (ListViewItem item in lstData.CheckedItems)
                    {
                        bool bResult = false;
                        if (m_Ftp.DeleteDirectory(item.Text))
                        {
                            bResult = true;
                        }
                        else if (m_Ftp.DeleteFile(item.Text))
                        {
                            bResult = true;
                        }
                        if (bResult)
                        {
                            m_Application.Output.Output("【" + item.Text + "】删除成功！", Desktop.InfoType.Information);
                            lstData.Items.Remove(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog
                {
                    Description = "下载文档资料。",
                    RootFolder = Environment.SpecialFolder.Desktop,
                    ShowNewFolderButton = true,
                };
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    m_loadIndex = 1;
                    foreach (ListViewItem item in lstData.CheckedItems)
                    {
                        FTPDataInfo info = item.Tag as FTPDataInfo;
                        if (info.Type == FTPDataType.Directory)
                        {
                            Directory.CreateDirectory(folder.SelectedPath + "\\" + info.Name);
                            m_Ftp.Download(info.Name, folder.SelectedPath + "\\" + info.Name, FTPDataType.Directory);
                        }
                        else
                        {
                            m_Ftp.Download(info.Name, folder.SelectedPath + "\\" + item.Text, FTPDataType.Other);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_Ftp_OnDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                m_loadIndex++;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_Ftp_OnDownloadProcess(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            try
            {
                m_Application.Output.ClearOutput();
                m_Application.Output.Output(string.Format("正在下载第【{0}】个文件，已完成【{1}】，共【{2}】个文件。",
                    m_loadIndex.ToString(), e.ProgressPercentage + "%", lstData.Items.Count.ToString()), InfoType.Information);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_Ftp_OnUploadProcess(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            try
            {
                m_Application.Output.ClearOutput();
                m_Application.Output.Output(string.Format("正在上传第【{0}】个文件，已完成【{1}】，共【{2}】个文件。",
                    m_loadIndex.ToString(), e.ProgressPercentage + "%", lstData.Items.Count.ToString()), InfoType.Information);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_Ftp_OnUploadCompleted(object sender, System.Net.UploadFileCompletedEventArgs e)
        {
            try
            {
                m_loadIndex++;
                LoadData();
                m_Application.MessageBox.Show("上传完成！");
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog
                {
                    Title = "上传文件",
                    InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Multiselect = true,
                };
                if (file.ShowDialog() == DialogResult.OK)
                {
                    string[] files = file.FileNames;
                    foreach (string fileName in files)
                    {
                        FileInfo info = new FileInfo(fileName);
                        m_Ftp.UploadFile(info.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnUploadDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog
                {
                    Description = "上传文件夹",
                    RootFolder = Environment.SpecialFolder.Desktop,
                    ShowNewFolderButton = true,
                };
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    m_Ftp.UploadDirectory(folder.SelectedPath);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem item = lstData.SelectedItems[0];
                if (item.Tag == null)
                {
                    m_Ftp.ComeOutDirectory();
                    LoadData();
                }
                else
                {
                    FTPDataInfo info = item.Tag as FTPDataInfo;
                    if (info.Type == FTPDataType.Directory)
                    {
                        m_Ftp.ComeInDirectory(info.Name);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
