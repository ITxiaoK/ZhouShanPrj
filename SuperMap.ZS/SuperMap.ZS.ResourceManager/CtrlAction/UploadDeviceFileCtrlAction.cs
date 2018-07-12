using SuperMap.Desktop;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.ResourceManager
{
    class UploadDeviceFileCtrlAction : CtrlAction
    {
        private Application m_Application;

#pragma warning disable CS0612 // 类型或成员已过时
        public UploadDeviceFileCtrlAction()
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

        public UploadDeviceFileCtrlAction(IBaseItem caller) : base(caller)
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
        public UploadDeviceFileCtrlAction(IBaseItem caller, IForm formClass) : base(caller: caller, formClass: formClass)
#pragma warning restore CS0612 // 类型或成员已过时
        {
        }

        public override void Run()
        {
            try
            {
                if (!CommonPars.WorkspaceOpen)
                {
                    Application.ActiveApplication.MessageBox.Show("未打开工程！");
                    return;
                }
                if (Application.ActiveApplication.MainForm.FormManager.Count == 0)
                {
                    Application.ActiveApplication.MessageBox.Show("未打开场景！");
                    return;
                }
                else if (!(Application.ActiveApplication.MainForm.FormManager.ActiveForm is IFormScene))
                {
                    Application.ActiveApplication.MessageBox.Show("未打开场景！");
                    return;
                }
                else
                {
                    IDockBar dockBar = Application.ActiveApplication.MainForm.DockBarManager[typeof(UploadDeviceFileControl)];
                    if (dockBar != null)
                    {
                        dockBar.Visible = true;
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
