using SuperMap.Data;
using SuperMap.Desktop;
using SuperMap.ZS.Common;
using SuperMap.ZS.Data;
using System;
using System.IO;

namespace SuperMap.ZS.Startup
{
    public class CommitWorkspaceCtrlAction : CtrlAction
    {
        private int m_TotleCount = 0;
        private int m_Count = 0;
        private string m_WorkspacePath;

#pragma warning disable CS0612 // 类型或成员已过时
        public CommitWorkspaceCtrlAction()
        {
        }
#pragma warning restore CS0612 // 类型或成员已过时

        public CommitWorkspaceCtrlAction(IBaseItem caller) : base(caller)
        {
        }

#pragma warning disable CS0612 // 类型或成员已过时
        public CommitWorkspaceCtrlAction(IBaseItem caller, IForm formClass) : base(caller: caller, formClass: formClass)
#pragma warning restore CS0612 // 类型或成员已过时
        {
        }

        public override void Run()
        {
            try
            {
                if (string.IsNullOrEmpty(Application.ActiveApplication.Workspace.ConnectionInfo.Server))
                {
                    Application.ActiveApplication.MessageBox.Show("请打开工程！", "提示", System.Windows.Forms.MessageBoxButtons.OK);
                    return;
                }
                if (Application.ActiveApplication.MessageBox.Show("确认提交【" + Application.ActiveApplication.Workspace.Caption + "】工程？", "提示",
                    System.Windows.Forms.MessageBoxButtons.OKCancel,
                    System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    m_WorkspacePath = Application.ActiveApplication.Workspace.ConnectionInfo.Server;
                    Application.ActiveApplication.Workspace.Closed += Workspace_Closed;
                    Application.ActiveApplication.Workspace.Close();
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void Workspace_Closed(object sender, WorkspaceClosedEventArgs args)
        {
            try
            {
                m_Count = 0;
                FTPControllerForWorkspacceForWorkspace ftp = new FTPControllerForWorkspacceForWorkspace();
                ftp.OnCommitCompleted += Ftp_OnCommitCompleted;
                ftp.OnCommitProcess += Ftp_OnCommitProcess;
                ftp.Commit(m_WorkspacePath);
                m_TotleCount = ftp.CommitFilesCount;

                Application.ActiveApplication.Output.IsTimePrefixAdded = true;
                Application.ActiveApplication.Output.Visible = true;

                Application.ActiveApplication.Workspace.Closed -= Workspace_Closed;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void Ftp_OnCommitProcess(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            try
            {
                Application.ActiveApplication.Output.ClearOutput();
                Application.ActiveApplication.Output.Output(string.Format("正在上传第【{0}】个文件，已完成【{1}】，共【{2}】个文件。",
                    m_Count.ToString(), e.ProgressPercentage + "%", m_TotleCount.ToString()), InfoType.Information);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void Ftp_OnCommitCompleted(object sender, System.Net.UploadFileCompletedEventArgs e)
        {
            try
            {
                m_Count++;

                if (m_Count == m_TotleCount)
                {
                    Application.ActiveApplication.Output.ClearOutput();
                    FileInfo fileinfo = new FileInfo(m_WorkspacePath);
                    Application.ActiveApplication.Output.Output("【" + fileinfo.Name.Split('.')[0] + "】工程上传完成！", InfoType.Information);
                    WorkspaceConnectionInfo info = new WorkspaceConnectionInfo()
                    {
                        Server = m_WorkspacePath,
                        Type = (WorkspaceType)Enum.Parse(typeof(WorkspaceType), fileinfo.Name.Split('.')[1].ToUpper()),
                    };
                    if (Application.ActiveApplication.Workspace.Open(info))
                    {
                        Application.ActiveApplication.Workspace.Caption = fileinfo.Name.Split('.')[0];
                        Application.ActiveApplication.Workspace.Save();
                        Application.ActiveApplication.CreateSceneWindow(Application.ActiveApplication.Workspace.Scenes[0]);
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
