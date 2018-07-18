using SuperMap.Desktop;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.Workflow
{
    class EditWorkflowCtrlAction : CtrlAction
    {
#pragma warning disable CS0612 // 类型或成员已过时
        public EditWorkflowCtrlAction()
        {
        }
#pragma warning restore CS0612 // 类型或成员已过时

        public EditWorkflowCtrlAction(IBaseItem caller) : base(caller)
        {
        }

#pragma warning disable CS0612 // 类型或成员已过时
        public EditWorkflowCtrlAction(IBaseItem caller, IForm formClass) : base(caller, formClass)
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
                    IDockBar dockBar = Application.ActiveApplication.MainForm.DockBarManager[typeof(WorkflowInfoControl)];
                    if (dockBar != null)
                    {
                        dockBar.Visible = true;
                        (dockBar.Control as WorkflowInfoControl).WorkflowEditType = WorkflowEditType.Edit;
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
