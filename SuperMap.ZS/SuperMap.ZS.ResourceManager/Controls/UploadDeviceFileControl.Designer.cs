namespace SuperMap.ZS.ResourceManager
{
    partial class UploadDeviceFileControl
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
            this.rad_Type = new System.Windows.Forms.RadioButton();
            this.rad_Device = new System.Windows.Forms.RadioButton();
            this.gb_Type = new System.Windows.Forms.GroupBox();
            this.cmb_DeviceType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Device = new System.Windows.Forms.GroupBox();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_DeviceType2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_Type.SuspendLayout();
            this.gb_Device.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // rad_Type
            // 
            this.rad_Type.AutoSize = true;
            this.rad_Type.Checked = true;
            this.rad_Type.Location = new System.Drawing.Point(16, 28);
            this.rad_Type.Name = "rad_Type";
            this.rad_Type.Size = new System.Drawing.Size(107, 16);
            this.rad_Type.TabIndex = 0;
            this.rad_Type.TabStop = true;
            this.rad_Type.Text = "按设备类型上传";
            this.rad_Type.UseVisualStyleBackColor = true;
            this.rad_Type.CheckedChanged += new System.EventHandler(this.rad_Type_CheckedChanged);
            // 
            // rad_Device
            // 
            this.rad_Device.AutoSize = true;
            this.rad_Device.Location = new System.Drawing.Point(129, 28);
            this.rad_Device.Name = "rad_Device";
            this.rad_Device.Size = new System.Drawing.Size(107, 16);
            this.rad_Device.TabIndex = 0;
            this.rad_Device.Text = "按单个设备上传";
            this.rad_Device.UseVisualStyleBackColor = true;
            this.rad_Device.CheckedChanged += new System.EventHandler(this.rad_Type_CheckedChanged);
            // 
            // gb_Type
            // 
            this.gb_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Type.Controls.Add(this.cmb_DeviceType);
            this.gb_Type.Controls.Add(this.label2);
            this.gb_Type.Location = new System.Drawing.Point(16, 62);
            this.gb_Type.Name = "gb_Type";
            this.gb_Type.Size = new System.Drawing.Size(220, 82);
            this.gb_Type.TabIndex = 1;
            this.gb_Type.TabStop = false;
            this.gb_Type.Text = "接设备类型上传";
            // 
            // cmb_DeviceType
            // 
            this.cmb_DeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_DeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DeviceType.FormattingEnabled = true;
            this.cmb_DeviceType.Location = new System.Drawing.Point(77, 36);
            this.cmb_DeviceType.Name = "cmb_DeviceType";
            this.cmb_DeviceType.Size = new System.Drawing.Size(137, 20);
            this.cmb_DeviceType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择类型：";
            // 
            // gb_Device
            // 
            this.gb_Device.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Device.Controls.Add(this.dgv_Data);
            this.gb_Device.Controls.Add(this.label3);
            this.gb_Device.Controls.Add(this.cmb_DeviceType2);
            this.gb_Device.Enabled = false;
            this.gb_Device.Location = new System.Drawing.Point(16, 150);
            this.gb_Device.Name = "gb_Device";
            this.gb_Device.Size = new System.Drawing.Size(220, 256);
            this.gb_Device.TabIndex = 1;
            this.gb_Device.TabStop = false;
            this.gb_Device.Text = "接单个设备上传";
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToDeleteRows = false;
            this.dgv_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colDeviceID,
            this.colDeviceName});
            this.dgv_Data.Location = new System.Drawing.Point(0, 46);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.RowHeadersVisible = false;
            this.dgv_Data.RowTemplate.Height = 23;
            this.dgv_Data.Size = new System.Drawing.Size(220, 210);
            this.dgv_Data.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "选择类型：";
            // 
            // cmb_DeviceType2
            // 
            this.cmb_DeviceType2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_DeviceType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DeviceType2.FormattingEnabled = true;
            this.cmb_DeviceType2.Location = new System.Drawing.Point(77, 20);
            this.cmb_DeviceType2.Name = "cmb_DeviceType2";
            this.cmb_DeviceType2.Size = new System.Drawing.Size(137, 20);
            this.cmb_DeviceType2.TabIndex = 1;
            this.cmb_DeviceType2.SelectedIndexChanged += new System.EventHandler(this.cmb_DeviceType2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文件：";
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FilePath.Location = new System.Drawing.Point(85, 418);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.ReadOnly = true;
            this.txt_FilePath.Size = new System.Drawing.Size(100, 21);
            this.txt_FilePath.TabIndex = 2;
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Select.Location = new System.Drawing.Point(191, 418);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(45, 23);
            this.btn_Select.TabIndex = 3;
            this.btn_Select.Text = "...";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Upload
            // 
            this.btn_Upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Upload.Location = new System.Drawing.Point(155, 460);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(75, 23);
            this.btn_Upload.TabIndex = 4;
            this.btn_Upload.Text = "提  交";
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "选择设备";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colDeviceID
            // 
            this.colDeviceID.HeaderText = "设备编码";
            this.colDeviceID.Name = "colDeviceID";
            this.colDeviceID.ReadOnly = true;
            // 
            // colDeviceName
            // 
            this.colDeviceName.HeaderText = "设备名称";
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.ReadOnly = true;
            // 
            // UploadDeviceFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Upload);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.txt_FilePath);
            this.Controls.Add(this.gb_Device);
            this.Controls.Add(this.gb_Type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rad_Device);
            this.Controls.Add(this.rad_Type);
            this.Name = "UploadDeviceFileControl";
            this.Size = new System.Drawing.Size(247, 625);
            this.Load += new System.EventHandler(this.UploadDeviceFileControl_Load);
            this.gb_Type.ResumeLayout(false);
            this.gb_Type.PerformLayout();
            this.gb_Device.ResumeLayout(false);
            this.gb_Device.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rad_Type;
        private System.Windows.Forms.RadioButton rad_Device;
        private System.Windows.Forms.GroupBox gb_Type;
        private System.Windows.Forms.GroupBox gb_Device;
        private System.Windows.Forms.ComboBox cmb_DeviceType2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.ComboBox cmb_DeviceType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceName;
    }
}
