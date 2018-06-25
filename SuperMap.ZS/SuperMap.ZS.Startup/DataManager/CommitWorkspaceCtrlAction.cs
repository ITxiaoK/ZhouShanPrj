using SuperMap.Desktop;
using SuperMap.ZS.Common;
using SuperMap.ZS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperMap.ZS.Startup
{
    public class CommitWorkspaceCtrlAction : CtrlAction
    {
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

            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
