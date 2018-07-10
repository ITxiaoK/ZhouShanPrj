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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TypeData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
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
            this.cmbDeviceType.Location = new System.Drawing.Point(84, 23);
            this.cmbDeviceType.Name = "cmbDeviceType";
            this.cmbDeviceType.Size = new System.Drawing.Size(142, 20);
            this.cmbDeviceType.TabIndex = 1;
            this.cmbDeviceType.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceType_SelectedIndexChanged);
            // 
            // btnScreenTip
            // 
            this.btnScreenTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenTip.Location = new System.Drawing.Point(166, 547);
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
            this.dgv_TypeData.Size = new System.Drawing.Size(230, 138);
            this.dgv_TypeData.TabIndex = 3;
            // 
            // colTypeName
            // 
            this.colTypeName.HeaderText = "类型名称";
            this.colTypeName.Name = "colTypeName";
            // 
            // DeviceTypeManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_TypeData);
            this.Controls.Add(this.btnScreenTip);
            this.Controls.Add(this.cmbDeviceType);
            this.Controls.Add(this.label1);
            this.Name = "DeviceTypeManagerControl";
            this.Size = new System.Drawing.Size(254, 590);
            this.Load += new System.EventHandler(this.DeviceTypeManagerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TypeData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeviceType;
        private System.Windows.Forms.Button btnScreenTip;
        private System.Windows.Forms.DataGridView dgv_TypeData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeName;
    }
}
