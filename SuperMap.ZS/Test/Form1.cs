using SuperMap.ZS.Common;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select WorkspaceServerPath from workspaceserverinfo";
                DataSet dt = DbHelperMySQL.GetDataSet(DbHelperMySQL.Conn, CommandType.Text, sql);
                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    CommonPars.DataRootDirInServer = dt.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btn_TestDataSource_Click(object sender, EventArgs e)
        {
            DataSet dt = DbHelperMySQL.GetDataSet(DbHelperMySQL.Conn, CommandType.Text, "select * from test", null);
            lblResult.Text = dt.Tables[0].Rows.Count.ToString();
        }

        private void btnGetFTPData_Click(object sender, EventArgs e)
        {
            //FTPHelper ftp = new FTPHelper("192.168.245.129", "admin", "admin");
            //ftp.GotoDirectory("数据库部署包", false);
            //foreach (string name in ftp.GetDirectoryList())
            //{
            //    lblResult.Text += name + ",";
            //}
        }

        private void btnWorkspaceInfo_Click(object sender, EventArgs e)
        {
            WorkspaceInfo workspace = new WorkspaceInfo();

            foreach (WorkspaceInfo info in workspace.GetAllData())
            {
                lblResult.Text += info.WorkspaceName + ",";
            }
        }

        private void btnGetWorksoaceInfo_Click(object sender, EventArgs e)
        {
            WorkspaceInfo workspace = new WorkspaceInfo();
            lblResult.Text = (workspace.GetData(-1) as WorkspaceInfo).WorkspaceName;
        }

        private void btnUpdateWorkspaceInfo_Click(object sender, EventArgs e)
        {
            WorkspaceInfo workspace = new WorkspaceInfo
            {
                WorkspaceName = "",
                WorkspaceServerPath = "数据舟山数据",
                IsUpdate = true
            };
            lblResult.Text = workspace.Update(workspace).ToString();
        }

        private void btnNewWorkspaceInfo_Click(object sender, EventArgs e)
        {
            WorkspaceInfo workspace = new WorkspaceInfo
            {
                WorkspaceName = "黄土店",
                WorkspaceServerPath = "数据\\黄土店数据",
                IsUpdate = true
            };
            lblResult.Text = workspace.AddData(workspace).ToString();
        }

        private void btnDeleteWorkspaceInfo_Click(object sender, EventArgs e)
        {
            WorkspaceInfo workspace = new WorkspaceInfo();
            lblResult.Text = workspace.DeleteData(1).ToString();
        }

        private void btnCommitWorkspace_Click(object sender, EventArgs e)
        {
            string path = @"E:\数字工厂数据\workspace.smwu";
            FTPControllerForWorkspacceForWorkspace ftp = new FTPControllerForWorkspacceForWorkspace();
            ftp.OnCommitCompleted += Ftp_OnCommitCompleted;
            ftp.OnCommitProcess += Ftp_OnCommitProcess;
            if (!ftp.Exist(path))
            {
                ftp.Commit(path);
            }
            else
            {
                ftp.Delete(path);
                ftp.Commit(path);
            }
        }

        private void Ftp_OnCommitProcess(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            lblResult.Text = (e.BytesSent / e.TotalBytesToSend * 100) + "%";
        }

        private void Ftp_OnCommitCompleted(object sender, System.Net.UploadFileCompletedEventArgs e)
        {
            lblResult.Text = "上传完成";
        }

        private void btnDeleteWorkspace_Click(object sender, EventArgs e)
        {
            string path = @"E:\数字工厂数据\workspace.smwu";
            FTPControllerForWorkspacceForWorkspace ftp = new FTPControllerForWorkspacceForWorkspace();
            if (ftp.Exist(path))
            {
                lblResult.Text = ftp.Delete(path).ToString();
            }
        }

        private void btnDownWorkspace_Click(object sender, EventArgs e)
        {
            string path = @"E:\数字工厂数据\workspace.smwu";
            FTPControllerForWorkspacceForWorkspace ftp = new FTPControllerForWorkspacceForWorkspace();
            ftp.OnUpdateProcess += Ftp_OnUpdateProcess;
            ftp.OnUpdateComplete += Ftp_OnUpdateComplete;
            if (ftp.Exist(path))
            {
                ftp.Update(path);
            }
        }

        private void Ftp_OnUpdateComplete(object sender, AsyncCompletedEventArgs e)
        {
            lblResult.Text = "下载完成";
        }

        private void Ftp_OnUpdateProcess(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            lblResult.Text = (e.ProgressPercentage * 100) + "%";
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper excel = new ExcelHelper();
            DataSet dt = excel.FromFile(@"e:\test2.xlsx");
            dg_data.DataSource = dt;
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.TableName = "myTable";
            dt.Columns.Add("名称");
            dt.Columns.Add("成绩");
            dt.Columns.Add("评分");

            DataRow row1 = dt.NewRow();
            row1[0] = "张三";
            row1[1] = "79";
            row1[2] = "二";
            dt.Rows.Add(row1);
            DataRow row2 = dt.NewRow();
            row2[0] = "李四";
            row2[1] = "27";
            row2[2] = "五";
            dt.Rows.Add(row2);
            DataRow row3 = dt.NewRow();
            row3[0] = "王五";
            row3[1] = "47";
            row3[2] = "一";
            dt.Rows.Add(row3);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            ExcelHelper excel = new ExcelHelper();
            lblResult.Text = excel.ToFile(ds, @"e:\test2.xlsx").ToString();
        }
    }
}
