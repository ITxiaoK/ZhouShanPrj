namespace SuperMap.ZS.ResourceManager
{
    partial class DeviceTypeManagerControl
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
            this.btnScreenTip = new System.Windows.Forms.Button();
            this.dgv_TypeData = new System.Windows.Forms.DataGridView();
            this.colTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddType = new System.Windows.Forms.Button();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDataOK = new System.Windows.Forms.Button();
            this.btnSelectChange = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.cmbSetDeviceType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TypeData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备信息：";
            // 
            // cmbDeviceType
            // 
            this.cmbDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceType.FormattingEnabled = true;
            this.cmbDeviceType.Location = new System.Drawing.Point(84, 23);
            this.cmbDeviceType.Name = "cmbDeviceType";
            this.cmbDeviceType.Size = new System.Drawing.Size(142, 20);
            this.cmbDeviceType.TabIndex = 1;
            this.cmbDeviceType.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceType_SelectedIndexChanged);
            // 
            // btnScreenTip
            // 
            this.btnScreenTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenTip.Location = new System.Drawing.Point(166, 699);
            this.btnScreenTip.Name = "btnScreenTip";
            this.btnScreenTip.Size = new System.Drawing.Size(75, 23);
            this.btnScreenTip.TabIndex = 2;
            this.btnScreenTip.Text = "操作导引";
            this.btnScreenTip.UseVisualStyleBackColor = true;
            this.btnScreenTip.Click += new System.EventHandler(this.btnScreenTip_Click);
            // 
            // dgv_TypeData
            // 
            this.dgv_TypeData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_TypeData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TypeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TypeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTypeName});
            this.dgv_TypeData.Location = new System.Drawing.Point(14, 53);
            this.dgv_TypeData.Name = "dgv_TypeData";
            this.dgv_TypeData.RowHeadersVisible = false;
            this.dgv_TypeData.RowTemplate.Height = 23;
            this.dgv_TypeData.Size = new System.Drawing.Size(230, 290);
            this.dgv_TypeData.TabIndex = 3;
            // 
            // colTypeName
            // 
            this.colTypeName.HeaderText = "类型名称";
            this.colTypeName.Name = "colTypeName";
            // 
            // btnAddType
            // 
            this.btnAddType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddType.Location = new System.Drawing.Point(166, 349);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(75, 23);
            this.btnAddType.TabIndex = 4;
            this.btnAddType.Text = "确  定";
            this.btnAddType.UseVisualStyleBackColor = true;
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToDeleteRows = false;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colDeviceID,
            this.colDeviceName,
            this.colType});
            this.dgv_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_Data.Location = new System.Drawing.Point(3, 17);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.RowHeadersVisible = false;
            this.dgv_Data.RowTemplate.Height = 23;
            this.dgv_Data.Size = new System.Drawing.Size(223, 174);
            this.dgv_Data.TabIndex = 5;
            this.dgv_Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellContentClick);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "选择数据";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 80;
            // 
            // colDeviceID
            // 
            this.colDeviceID.HeaderText = "设备编号";
            this.colDeviceID.Name = "colDeviceID";
            this.colDeviceID.ReadOnly = true;
            this.colDeviceID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeviceID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDeviceID.Width = 120;
            // 
            // colDeviceName
            // 
            this.colDeviceName.HeaderText = "设备名称";
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.ReadOnly = true;
            this.colDeviceName.Width = 120;
            // 
            // colType
            // 
            this.colType.HeaderText = "设备类型";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDataOK);
            this.groupBox1.Controls.Add(this.btnSelectChange);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.cmbSetDeviceType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgv_Data);
            this.groupBox1.Location = new System.Drawing.Point(15, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 282);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类型设置";
            // 
            // btnDataOK
            // 
            this.btnDataOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataOK.Location = new System.Drawing.Point(148, 252);
            this.btnDataOK.Name = "btnDataOK";
            this.btnDataOK.Size = new System.Drawing.Size(75, 23);
            this.btnDataOK.TabIndex = 8;
            this.btnDataOK.Text = "保  存";
            this.btnDataOK.UseVisualStyleBackColor = true;
            this.btnDataOK.Click += new System.EventHandler(this.btnDataOK_Click);
            // 
            // btnSelectChange
            // 
            this.btnSelectChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectChange.Location = new System.Drawing.Point(148, 197);
            this.btnSelectChange.Name = "btnSelectChange";
            this.btnSelectChange.Size = new System.Drawing.Size(75, 23);
            this.btnSelectChange.TabIndex = 7;
            this.btnSelectChange.Text = "反  选";
            this.btnSelectChange.UseVisualStyleBackColor = true;
            this.btnSelectChange.Click += new System.EventHandler(this.btnSelectChange_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Location = new System.Drawing.Point(67, 197);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 7;
            this.btnSelectAll.Text = "全  选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cmbSetDeviceType
            // 
            this.cmbSetDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSetDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetDeviceType.FormattingEnabled = true;
            this.cmbSetDeviceType.Location = new System.Drawing.Point(78, 226);
            this.cmbSetDeviceType.Name = "cmbSetDeviceType";
            this.cmbSetDeviceType.Size = new System.Drawing.Size(145, 20);
            this.cmbSetDeviceType.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "设置类型：";
            // 
            // DeviceTypeManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.dgv_TypeData);
            this.Controls.Add(this.btnScreenTip);
            this.Controls.Add(this.cmbDeviceType);
            this.Controls.Add(this.label1);
            this.Name = "DeviceTypeManagerControl";
            this.Size = new System.Drawing.Size(254, 742);
            this.Load += new System.EventHandler(this.DeviceTypeManagerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TypeData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeviceType;
        private System.Windows.Forms.Button btnScreenTip;
        private System.Windows.Forms.DataGridView dgv_TypeData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeName;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSetDeviceType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectChange;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.Button btnDataOK;
    }
}
