using SuperMap.Data;
using SuperMap.Desktop;
using SuperMap.Desktop.UI;
using SuperMap.ZS.Common;
using SuperMap.ZS.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperMap.ZS.Startup
{
    public class NewWorkspaceCtrlAction : CtrlAction
    {
        private int m_TotleCount = 0;
        private int m_Count = 0;

#pragma warning disable CS0612 // 类型或成员已过时
        public NewWorkspaceCtrlAction()
        {
        }
#pragma warning restore CS0612 // 类型或成员已过时

        public NewWorkspaceCtrlAction(IBaseItem caller) : base(caller)
        {
        }

#pragma warning disable CS0612 // 类型或成员已过时
        public NewWorkspaceCtrlAction(IBaseItem caller, IForm formClass) : base(caller: caller, formClass: formClass)
#pragma warning restore CS0612 // 类型或成员已过时
        {
        }

        public override void Run()
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog()
                {
                    RootFolder = System.Environment.SpecialFolder.Desktop,
                    Description = "请选择要保存的文件夹，该目录存放您新建的工程文件。",
                    ShowNewFolderButton = true,
                };
                if(folder.ShowDialog() == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(folder.SelectedPath);
                    if (files.Length > 0)
                    {
                        UIMessageBox box = new UIMessageBox(MessageBoxUIStyle.iDesktopStyle);
                        if (box.Show("该文件夹不为空，是否覆盖？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            foreach (string file in files)
                            {
                                File.Delete(file);
                            }
                        }
                        else
                        {
                            return;
                        }

                        FTPController ftp = new FTPController();
                        ftp.OnUpdateComplete += Ftp_OnUpdateComplete;
                        ftp.UpdateOriginalData(folder.SelectedPath);
                        m_TotleCount = ftp.UpdateFilesCount;
                        CommonPars.CurrentWorkspaceDir = folder.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Desktop.Application.ActiveApplication.Output.Output(ex);
            }
        }

        private void Ftp_OnUpdateComplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                m_Count++;
                if (m_Count == m_TotleCount)
                {
                    foreach (string file in Directory.GetFiles(CommonPars.CurrentWorkspaceDir))
                    {
                        FileInfo info = new FileInfo(file);
                        if (info.Extension.Contains("smwu") || info.Extension.Contains("sxwu"))
                        {
                            WorkspaceConnectionInfo wsinfo = new WorkspaceConnectionInfo()
                            {
                                Server = info.FullName,
                                Type = (WorkspaceType)Enum.Parse(typeof(WorkspaceType), info.Extension.Substring(1).ToUpper()),
                            };
                            if (Desktop.Application.ActiveApplication.Workspace.Open(wsinfo))
                            {
                                Desktop.Application.ActiveApplication.CreateSceneWindow(Desktop.Application.ActiveApplication.Workspace.Scenes[0]);
                                Desktop.Application.ActiveApplication.Output.Output("工作空间【" + info.Name.Split('.')[0] + "】已创建！", InfoType.Information);
                            }
                            else
                            {
                                Desktop.Application.ActiveApplication.Output.Output("工作空间【" + info.Name.Split('.')[0] + "】创建失败！", InfoType.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                Desktop.Application.ActiveApplication.Output.Output(ex);
            }
        }
    }
}
