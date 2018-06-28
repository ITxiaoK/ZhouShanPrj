﻿using SuperMap.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.Startup
{
    public class AggregateCtrlAction : CtrlAction
    {
#pragma warning disable CS0612 // 类型或成员已过时
        public AggregateCtrlAction()
        {
        }
#pragma warning restore CS0612 // 类型或成员已过时

        public AggregateCtrlAction(IBaseItem caller) : base(caller)
        {
        }

#pragma warning disable CS0612 // 类型或成员已过时
        public AggregateCtrlAction(IBaseItem caller, IForm formClass) : base(caller: caller, formClass: formClass)
#pragma warning restore CS0612 // 类型或成员已过时
        {
        }

        public override void Run()
        {
            Application.ActiveApplication.MessageBox.Show("未实现的功能");
        }
    }
}
