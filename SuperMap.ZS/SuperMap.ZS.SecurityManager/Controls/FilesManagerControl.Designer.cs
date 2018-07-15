namespace SuperMap.ZS.SecurityManager
{
    partial class FilesManagerControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesManagerControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstData = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReName = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.btnUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lstData);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.btnSelectChange);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnReName);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Location = new System.Drawing.Point(16, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 621);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在线文档";
            // 
            // lstData
            // 
            this.lstData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstData.CheckBoxes = true;
            this.lstData.FullRowSelect = true;
            this.lstData.LabelEdit = true;
            this.lstData.Location = new System.Drawing.Point(3, 51);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(265, 567);
            this.lstData.SmallImageList = this.imageList;
            this.lstData.TabIndex = 1;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.List;
            this.lstData.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstData_AfterLabelEdit);
            this.lstData.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstData_BeforeLabelEdit);
            this.lstData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstData_MouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "返回上级.png");
            this.imageList.Images.SetKeyName(1, "directory.png");
            this.imageList.Images.SetKeyName(2, "word.png");
            this.imageList.Images.SetKeyName(3, "pdf.png");
            this.imageList.Images.SetKeyName(4, "excel.png");
            this.imageList.Images.SetKeyName(5, "ppt.png");
            this.imageList.Images.SetKeyName(6, "image.png");
            this.imageList.Images.SetKeyName(7, "video.png");
            this.imageList.Images.SetKeyName(8, "rar.png");
            this.imageList.Images.SetKeyName(9, "document.png");
            this.imageList.Images.SetKeyName(10, "cad.png");
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Image = global::SuperMap.ZS.SecurityManager.Properties.Resources.全选;
            this.btnSelectAll.Location = new System.Drawing.Point(196, 15);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(30, 30);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectChange
            // 
            this.btnSelectChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectChange.Image = global::SuperMap.ZS.SecurityManager.Properties.Resources.反选;
            this.btnSelectChange.Location = new System.Drawing.Point(232, 15);
            this.btnSelectChange.Name = "btnSelectChange";
            this.btnSelectChange.Size = new System.Drawing.Size(30, 30);
            this.btnSelectChange.TabIndex = 0;
            this.btnSelectChange.UseVisualStyleBackColor = true;
            this.btnSelectChange.Click += new System.EventHandler(this.btnSelectChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::SuperMap.ZS.SecurityManager.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(78, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 30);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReName
            // 
            this.btnReName.Image = global::SuperMap.ZS.SecurityManager.Properties.Resources.ReName;
            this.btnReName.Location = new System.Drawing.Point(42, 15);
            this.btnReName.Name = "btnReName";
            this.btnReName.Size = new System.Drawing.Size(30, 30);
            this.btnReName.TabIndex = 0;
            this.btnReName.UseVisualStyleBackColor = true;
            this.btnReName.Click += new System.EventHandler(this.btnReName_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::SuperMap.ZS.SecurityManager.Properties.Resources.New;
            this.btnNew.Location = new System.Drawing.Point(6, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(30, 30);
            this.btnNew.TabIndex = 0;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUpload,
            this.btnDownload});
            this.menuStrip.Location = new System.Drawing.Point(162, 647);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(122, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // btnUpload
            // 
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(57, 24);
            this.btnUpload.Text = "上  传";
            this.btnUpload.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(57, 24);
            this.btnDownload.Text = "下  载";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // FilesManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.Name = "FilesManagerControl";
            this.Size = new System.Drawing.Size(299, 687);
            this.Load += new System.EventHandler(this.FilesManagerControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnUpload;
        private System.Windows.Forms.ToolStripMenuItem btnDownload;
    }
}
