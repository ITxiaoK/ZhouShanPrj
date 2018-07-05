namespace SuperMap.ZS.ResourceManager
{
    partial class DeviceLocationControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeviceType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dg_Data = new System.Windows.Forms.DataGridView();
            this.colDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnScreenTip = new System.Windows.Forms.Button();
            this.btnGetCamera = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备类型：";
            // 
            // cmbDeviceType
            // 
            this.cmbDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceType.FormattingEnabled = true;
            this.cmbDeviceType.Location = new System.Drawing.Point(90, 18);
            this.cmbDeviceType.Name = "cmbDeviceType";
            this.cmbDeviceType.Size = new System.Drawing.Size(160, 20);
            this.cmbDeviceType.TabIndex = 1;
            this.cmbDeviceType.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceType_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dg_Data);
            this.groupBox1.Location = new System.Drawing.Point(14, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 457);
            this.groupBox1.TabIndex = 2;
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
            this.dg_Data.Size = new System.Drawing.Size(253, 437);
            this.dg_Data.TabIndex = 0;
            this.dg_Data.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Data_RowHeaderMouseDoubleClick);
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
            this.btnScreenTip.Location = new System.Drawing.Point(198, 589);
            this.btnScreenTip.Name = "btnScreenTip";
            this.btnScreenTip.Size = new System.Drawing.Size(75, 23);
            this.btnScreenTip.TabIndex = 3;
            this.btnScreenTip.Text = "操作导引";
            this.btnScreenTip.UseVisualStyleBackColor = true;
            this.btnScreenTip.Click += new System.EventHandler(this.btnScreenTip_Click);
            // 
            // btnGetCamera
            // 
            this.btnGetCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetCamera.Location = new System.Drawing.Point(189, 522);
            this.btnGetCamera.Name = "btnGetCamera";
            this.btnGetCamera.Size = new System.Drawing.Size(75, 23);
            this.btnGetCamera.TabIndex = 4;
            this.btnGetCamera.Text = "设置视角";
            this.btnGetCamera.UseVisualStyleBackColor = true;
            this.btnGetCamera.Click += new System.EventHandler(this.btnGetCamera_Click);
            // 
            // DeviceLocationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGetCamera);
            this.Controls.Add(this.btnScreenTip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbDeviceType);
            this.Controls.Add(this.label1);
            this.Name = "DeviceLocationControl";
            this.Size = new System.Drawing.Size(285, 634);
            this.Load += new System.EventHandler(this.DeviceLocationControl_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeviceType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnScreenTip;
        private System.Windows.Forms.Button btnGetCamera;
        private System.Windows.Forms.DataGridView dg_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSet;
    }
}
