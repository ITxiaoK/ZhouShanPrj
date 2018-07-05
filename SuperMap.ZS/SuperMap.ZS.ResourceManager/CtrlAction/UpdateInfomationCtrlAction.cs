using SuperMap.Desktop;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.ResourceManager
{
    class UpdateInfomationCtrlAction : CtrlAction
    {
        private Application m_Application;

#pragma warning disable CS0612 // 类型或成员已过时
        public UpdateInfomationCtrlAction()
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

        public UpdateInfomationCtrlAction(IBaseItem caller) : base(caller)
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
        public UpdateInfomationCtrlAction(IBaseItem caller, IForm formClass) : base(caller: caller, formClass: formClass)
#pragma warning restore CS0612 // 类型或成员已过时
        {
        }

        public override void Run()
        {
            try
            {
                m_Application.MessageBox.Show("未实现的功能");
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
