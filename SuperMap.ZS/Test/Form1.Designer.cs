namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_TestDataSource = new System.Windows.Forms.Button();
            this.btnGetFTPData = new System.Windows.Forms.Button();
            this.btnAllWorkspaceInfo = new System.Windows.Forms.Button();
            this.btnGetWorksoaceInfo = new System.Windows.Forms.Button();
            this.btnUpdateWorkspaceInfo = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnNewWorkspaceInfo = new System.Windows.Forms.Button();
            this.btnDeleteWorkspaceInfo = new System.Windows.Forms.Button();
            this.btnCommitWorkspace = new System.Windows.Forms.Button();
            this.btnDeleteWorkspace = new System.Windows.Forms.Button();
            this.btnDownWorkspace = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_TestDataSource
            // 
            this.btn_TestDataSource.Location = new System.Drawing.Point(12, 12);
            this.btn_TestDataSource.Name = "btn_TestDataSource";
            this.btn_TestDataSource.Size = new System.Drawing.Size(156, 23);
            this.btn_TestDataSource.TabIndex = 0;
            this.btn_TestDataSource.Text = "测试数据库";
            this.btn_TestDataSource.UseVisualStyleBackColor = true;
            this.btn_TestDataSource.Click += new System.EventHandler(this.btn_TestDataSource_Click);
            // 
            // btnGetFTPData
            // 
            this.btnGetFTPData.Location = new System.Drawing.Point(12, 41);
            this.btnGetFTPData.Name = "btnGetFTPData";
            this.btnGetFTPData.Size = new System.Drawing.Size(156, 23);
            this.btnGetFTPData.TabIndex = 1;
            this.btnGetFTPData.Text = "获取FTP数据";
            this.btnGetFTPData.UseVisualStyleBackColor = true;
            this.btnGetFTPData.Click += new System.EventHandler(this.btnGetFTPData_Click);
            // 
            // btnAllWorkspaceInfo
            // 
            this.btnAllWorkspaceInfo.Location = new System.Drawing.Point(12, 70);
            this.btnAllWorkspaceInfo.Name = "btnAllWorkspaceInfo";
            this.btnAllWorkspaceInfo.Size = new System.Drawing.Size(156, 23);
            this.btnAllWorkspaceInfo.TabIndex = 2;
            this.btnAllWorkspaceInfo.Text = "获取所有工作空间信息";
            this.btnAllWorkspaceInfo.UseVisualStyleBackColor = true;
            this.btnAllWorkspaceInfo.Click += new System.EventHandler(this.btnWorkspaceInfo_Click);
            // 
            // btnGetWorksoaceInfo
            // 
            this.btnGetWorksoaceInfo.Location = new System.Drawing.Point(12, 99);
            this.btnGetWorksoaceInfo.Name = "btnGetWorksoaceInfo";
            this.btnGetWorksoaceInfo.Size = new System.Drawing.Size(156, 23);
            this.btnGetWorksoaceInfo.TabIndex = 3;
            this.btnGetWorksoaceInfo.Text = "获取一个工作空间信息";
            this.btnGetWorksoaceInfo.UseVisualStyleBackColor = true;
            this.btnGetWorksoaceInfo.Click += new System.EventHandler(this.btnGetWorksoaceInfo_Click);
            // 
            // btnUpdateWorkspaceInfo
            // 
            this.btnUpdateWorkspaceInfo.Location = new System.Drawing.Point(12, 128);
            this.btnUpdateWorkspaceInfo.Name = "btnUpdateWorkspaceInfo";
            this.btnUpdateWorkspaceInfo.Size = new System.Drawing.Size(156, 23);
            this.btnUpdateWorkspaceInfo.TabIndex = 4;
            this.btnUpdateWorkspaceInfo.Text = "更新工作空间信息";
            this.btnUpdateWorkspaceInfo.UseVisualStyleBackColor = true;
            this.btnUpdateWorkspaceInfo.Click += new System.EventHandler(this.btnUpdateWorkspaceInfo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResult});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblResult
            // 
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(56, 17);
            this.lblResult.Text = "显示结果";
            // 
            // btnNewWorkspaceInfo
            // 
            this.btnNewWorkspaceInfo.Location = new System.Drawing.Point(12, 157);
            this.btnNewWorkspaceInfo.Name = "btnNewWorkspaceInfo";
            this.btnNewWorkspaceInfo.Size = new System.Drawing.Size(156, 23);
            this.btnNewWorkspaceInfo.TabIndex = 6;
            this.btnNewWorkspaceInfo.Text = "新增工作空间信息";
            this.btnNewWorkspaceInfo.UseVisualStyleBackColor = true;
            this.btnNewWorkspaceInfo.Click += new System.EventHandler(this.btnNewWorkspaceInfo_Click);
            // 
            // btnDeleteWorkspaceInfo
            // 
            this.btnDeleteWorkspaceInfo.Location = new System.Drawing.Point(12, 186);
            this.btnDeleteWorkspaceInfo.Name = "btnDeleteWorkspaceInfo";
            this.btnDeleteWorkspaceInfo.Size = new System.Drawing.Size(156, 23);
            this.btnDeleteWorkspaceInfo.TabIndex = 7;
            this.btnDeleteWorkspaceInfo.Text = "删除工作空间信息";
            this.btnDeleteWorkspaceInfo.UseVisualStyleBackColor = true;
            this.btnDeleteWorkspaceInfo.Click += new System.EventHandler(this.btnDeleteWorkspaceInfo_Click);
            // 
            // btnCommitWorkspace
            // 
            this.btnCommitWorkspace.Location = new System.Drawing.Point(12, 215);
            this.btnCommitWorkspace.Name = "btnCommitWorkspace";
            this.btnCommitWorkspace.Size = new System.Drawing.Size(156, 23);
            this.btnCommitWorkspace.TabIndex = 8;
            this.btnCommitWorkspace.Text = "提交工程";
            this.btnCommitWorkspace.UseVisualStyleBackColor = true;
            this.btnCommitWorkspace.Click += new System.EventHandler(this.btnCommitWorkspace_Click);
            // 
            // btnDeleteWorkspace
            // 
            this.btnDeleteWorkspace.Location = new System.Drawing.Point(12, 244);
            this.btnDeleteWorkspace.Name = "btnDeleteWorkspace";
            this.btnDeleteWorkspace.Size = new System.Drawing.Size(156, 23);
            this.btnDeleteWorkspace.TabIndex = 9;
            this.btnDeleteWorkspace.Text = "删除工程";
            this.btnDeleteWorkspace.UseVisualStyleBackColor = true;
            this.btnDeleteWorkspace.Click += new System.EventHandler(this.btnDeleteWorkspace_Click);
            // 
            // btnDownWorkspace
            // 
            this.btnDownWorkspace.Location = new System.Drawing.Point(12, 273);
            this.btnDownWorkspace.Name = "btnDownWorkspace";
            this.btnDownWorkspace.Size = new System.Drawing.Size(156, 23);
            this.btnDownWorkspace.TabIndex = 10;
            this.btnDownWorkspace.Text = "下载工程";
            this.btnDownWorkspace.UseVisualStyleBackColor = true;
            this.btnDownWorkspace.Click += new System.EventHandler(this.btnDownWorkspace_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDownWorkspace);
            this.Controls.Add(this.btnDeleteWorkspace);
            this.Controls.Add(this.btnCommitWorkspace);
            this.Controls.Add(this.btnDeleteWorkspaceInfo);
            this.Controls.Add(this.btnNewWorkspaceInfo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnUpdateWorkspaceInfo);
            this.Controls.Add(this.btnGetWorksoaceInfo);
            this.Controls.Add(this.btnAllWorkspaceInfo);
            this.Controls.Add(this.btnGetFTPData);
            this.Controls.Add(this.btn_TestDataSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_TestDataSource;
        private System.Windows.Forms.Button btnGetFTPData;
        private System.Windows.Forms.Button btnAllWorkspaceInfo;
        private System.Windows.Forms.Button btnGetWorksoaceInfo;
        private System.Windows.Forms.Button btnUpdateWorkspaceInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblResult;
        private System.Windows.Forms.Button btnNewWorkspaceInfo;
        private System.Windows.Forms.Button btnDeleteWorkspaceInfo;
        private System.Windows.Forms.Button btnCommitWorkspace;
        private System.Windows.Forms.Button btnDeleteWorkspace;
        private System.Windows.Forms.Button btnDownWorkspace;
    }
}

