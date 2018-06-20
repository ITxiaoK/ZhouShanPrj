using SuperMap.Desktop;
using SuperMap.ZS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperMap.ZS.Startup
{
    class TestDataSourceCtrlAction : CtrlAction
    {
#pragma warning disable CS0612 // 类型或成员已过时
        public TestDataSourceCtrlAction()
        {
        }
#pragma warning restore CS0612 // 类型或成员已过时

        public TestDataSourceCtrlAction(IBaseItem caller) : base(caller)
        {
        }

#pragma warning disable CS0612 // 类型或成员已过时
        public TestDataSourceCtrlAction(IBaseItem caller, IForm formClass) : base(caller: caller, formClass: formClass)
#pragma warning restore CS0612 // 类型或成员已过时
        {
        }

        public override void Run()
        {
            DataSet dt = DbHelperMySQL.GetDataSet(DbHelperMySQL.Conn, CommandType.Text, "select * from test", null);
            MessageBox.Show(dt.Tables[0].Rows.Count.ToString());
        }
    }
}
