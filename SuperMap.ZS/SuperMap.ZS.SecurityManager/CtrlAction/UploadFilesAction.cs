using SuperMap.Desktop;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.SecurityManager
{
    class UploadFilesAction : CtrlAction
    {
        private Application m_Application;

#pragma warning disable CS0612 // 类型或成员已过时
        public UploadFilesAction()
        {
            try
            {
                m_Application = Application.ActiveApplication;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
#pragma warning restore CS0612 // 类型或成员已过时

        public UploadFilesAction(IBaseItem caller) : base(caller)
        {
            try
            {
                m_Application = Application.ActiveApplication;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

#pragma warning disable CS0612 // 类型或成员已过时
        public UploadFilesAction(IBaseItem caller, IForm formClass) : base(caller: caller, formClass: formClass)
#pragma warning restore CS0612 // 类型或成员已过时
        {
        }

        public override void Run()
        {
            try
            {
                if (!CommonPars.WorkspaceOpen)
                {
                    m_Application.MessageBox.Show("未打开工程！");
                    return;
                }
                if (m_Application.MainForm.FormManager.Count == 0)
                {
                    m_Application.MessageBox.Show("未打开场景！");
                    return;
                }
                else if (!(m_Application.MainForm.FormManager.ActiveForm is IFormScene))
                {
                    m_Application.MessageBox.Show("未打开场景！");
                    return;
                }
                else
                {
                    m_Application.MessageBox.Show("未实现的功能");
                    //IDockBar dockBar = Application.ActiveApplication.MainForm.DockBarManager[typeof(DeviceLocationControl)];
                    //if (dockBar != null)
                    //{
                    //    dockBar.Visible = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
