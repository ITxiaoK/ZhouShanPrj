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
            this.SuspendLayout();
            // 
            // btn_TestDataSource
            // 
            this.btn_TestDataSource.Location = new System.Drawing.Point(40, 25);
            this.btn_TestDataSource.Name = "btn_TestDataSource";
            this.btn_TestDataSource.Size = new System.Drawing.Size(75, 23);
            this.btn_TestDataSource.TabIndex = 0;
            this.btn_TestDataSource.Text = "测试数据库";
            this.btn_TestDataSource.UseVisualStyleBackColor = true;
            this.btn_TestDataSource.Click += new System.EventHandler(this.btn_TestDataSource_Click);
            // 
            // btnGetFTPData
            // 
            this.btnGetFTPData.Location = new System.Drawing.Point(40, 68);
            this.btnGetFTPData.Name = "btnGetFTPData";
            this.btnGetFTPData.Size = new System.Drawing.Size(75, 23);
            this.btnGetFTPData.TabIndex = 1;
            this.btnGetFTPData.Text = "获取FTP数据";
            this.btnGetFTPData.UseVisualStyleBackColor = true;
            this.btnGetFTPData.Click += new System.EventHandler(this.btnGetFTPData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetFTPData);
            this.Controls.Add(this.btn_TestDataSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_TestDataSource;
        private System.Windows.Forms.Button btnGetFTPData;
    }
}

