namespace SuperMap.ZS.Startup
{
    partial class ThemeControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScreenTip = new System.Windows.Forms.Button();
            this.btnDrawData = new System.Windows.Forms.Button();
            this.chkTheme = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Commit = new System.Windows.Forms.Button();
            this.dg_Data = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScreenTip
            // 
            this.btnScreenTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenTip.Location = new System.Drawing.Point(151, 597);
            this.btnScreenTip.Name = "btnScreenTip";
            this.btnScreenTip.Size = new System.Drawing.Size(75, 23);
            this.btnScreenTip.TabIndex = 0;
            this.btnScreenTip.Text = "操作导引";
            this.btnScreenTip.UseVisualStyleBackColor = true;
            this.btnScreenTip.Click += new System.EventHandler(this.btnScreenTip_Click);
            // 
            // btnDrawData
            // 
            this.btnDrawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawData.Location = new System.Drawing.Point(128, 204);
            this.btnDrawData.Name = "btnDrawData";
            this.btnDrawData.Size = new System.Drawing.Size(75, 23);
            this.btnDrawData.TabIndex = 1;
            this.btnDrawData.Text = "绘制数据";
            this.btnDrawData.UseVisualStyleBackColor = true;
            this.btnDrawData.Click += new System.EventHandler(this.btnDrawData_Click);
            // 
            // chkTheme
            // 
            this.chkTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTheme.CheckOnClick = true;
            this.chkTheme.FormattingEnabled = true;
            this.chkTheme.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.chkTheme.Location = new System.Drawing.Point(5, 18);
            this.chkTheme.Name = "chkTheme";
            this.chkTheme.Size = new System.Drawing.Size(201, 180);
            this.chkTheme.TabIndex = 2;
            this.chkTheme.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkTheme_ItemCheck);
            this.chkTheme.SelectedIndexChanged += new System.EventHandler(this.chkTheme_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkTheme);
            this.groupBox1.Controls.Add(this.btnDrawData);
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 235);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择要编辑的专题";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btn_Commit);
            this.groupBox2.Controls.Add(this.dg_Data);
            this.groupBox2.Location = new System.Drawing.Point(17, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 325);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "属性数据";
            // 
            // btn_Commit
            // 
            this.btn_Commit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Commit.Location = new System.Drawing.Point(128, 296);
            this.btn_Commit.Name = "btn_Commit";
            this.btn_Commit.Size = new System.Drawing.Size(75, 23);
            this.btn_Commit.TabIndex = 1;
            this.btn_Commit.Text = "保  存";
            this.btn_Commit.UseVisualStyleBackColor = true;
            this.btn_Commit.Click += new System.EventHandler(this.btn_Commit_Click);
            // 
            // dg_Data
            // 
            this.dg_Data.AllowUserToAddRows = false;
            this.dg_Data.AllowUserToResizeColumns = false;
            this.dg_Data.BackgroundColor = System.Drawing.Color.White;
            this.dg_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.dg_Data.Location = new System.Drawing.Point(3, 17);
            this.dg_Data.Name = "dg_Data";
            this.dg_Data.RowTemplate.Height = 23;
            this.dg_Data.Size = new System.Drawing.Size(203, 273);
            this.dg_Data.TabIndex = 0;
            this.dg_Data.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Data_RowHeaderMouseClick);
            this.dg_Data.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_Data_UserDeletingRow);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(47, 296);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷  新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ThemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnScreenTip);
            this.Name = "ThemeControl";
            this.Size = new System.Drawing.Size(247, 635);
            this.Load += new System.EventHandler(this.ThemeControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScreenTip;
        private System.Windows.Forms.Button btnDrawData;
        private System.Windows.Forms.CheckedListBox chkTheme;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_Data;
        private System.Windows.Forms.Button btn_Commit;
        private System.Windows.Forms.Button btnRefresh;
    }
}
