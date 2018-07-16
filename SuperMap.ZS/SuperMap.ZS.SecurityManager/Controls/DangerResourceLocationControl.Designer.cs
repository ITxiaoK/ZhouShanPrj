namespace SuperMap.ZS.SecurityManager
{
    partial class DangerResourceLocationControl
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
            this.btnGetCamera = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dg_Data = new System.Windows.Forms.DataGridView();
            this.colDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnScreenTip = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetCamera
            // 
            this.btnGetCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetCamera.Location = new System.Drawing.Point(186, 477);
            this.btnGetCamera.Name = "btnGetCamera";
            this.btnGetCamera.Size = new System.Drawing.Size(75, 23);
            this.btnGetCamera.TabIndex = 6;
            this.btnGetCamera.Text = "设置视角";
            this.btnGetCamera.UseVisualStyleBackColor = true;
            this.btnGetCamera.Click += new System.EventHandler(this.btnGetCamera_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dg_Data);
            this.groupBox1.Location = new System.Drawing.Point(6, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 457);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备列表";
            // 
            // dg_Data
            // 
            this.dg_Data.AllowUserToAddRows = false;
            this.dg_Data.AllowUserToDeleteRows = false;
            this.dg_Data.AllowUserToResizeColumns = false;
            this.dg_Data.AllowUserToResizeRows = false;
            this.dg_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeviceID,
            this.colSet});
            this.dg_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Data.Location = new System.Drawing.Point(3, 17);
            this.dg_Data.Name = "dg_Data";
            this.dg_Data.RowHeadersVisible = false;
            this.dg_Data.RowTemplate.Height = 23;
            this.dg_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Data.Size = new System.Drawing.Size(262, 437);
            this.dg_Data.TabIndex = 0;
            // 
            // colDeviceID
            // 
            this.colDeviceID.FillWeight = 111.6751F;
            this.colDeviceID.HeaderText = "设备编号";
            this.colDeviceID.Name = "colDeviceID";
            this.colDeviceID.ReadOnly = true;
            // 
            // colSet
            // 
            this.colSet.FillWeight = 88.32487F;
            this.colSet.HeaderText = "是否设置视角";
            this.colSet.Name = "colSet";
            this.colSet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnScreenTip
            // 
            this.btnScreenTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenTip.Location = new System.Drawing.Point(196, 611);
            this.btnScreenTip.Name = "btnScreenTip";
            this.btnScreenTip.Size = new System.Drawing.Size(75, 23);
            this.btnScreenTip.TabIndex = 7;
            this.btnScreenTip.Text = "操作导引";
            this.btnScreenTip.UseVisualStyleBackColor = true;
            this.btnScreenTip.Click += new System.EventHandler(this.btnScreenTip_Click);
            // 
            // DangerResourceLocationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnScreenTip);
            this.Controls.Add(this.btnGetCamera);
            this.Controls.Add(this.groupBox1);
            this.Name = "DangerResourceLocationControl";
            this.Size = new System.Drawing.Size(283, 651);
            this.Load += new System.EventHandler(this.DangerResourceLocationControl_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetCamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dg_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSet;
        private System.Windows.Forms.Button btnScreenTip;
    }
}
