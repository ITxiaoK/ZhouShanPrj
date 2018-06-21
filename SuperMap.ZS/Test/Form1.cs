using SuperMap.ZS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_TestDataSource_Click(object sender, EventArgs e)
        {
            DataSet dt = DbHelperMySQL.GetDataSet(DbHelperMySQL.Conn, CommandType.Text, "select * from test", null);
            MessageBox.Show(dt.Tables[0].Rows.Count.ToString());
        }

        private void btnGetFTPData_Click(object sender, EventArgs e)
        {
            FTPHelper ftp = new FTPHelper("192.168.245.129", "admin", "admin");
            ftp.GotoDirectory("数据库部署包", false);
            foreach (string name in ftp.GetDirectoryList())
            {
                MessageBox.Show(name);
            }
        }
    }
}
