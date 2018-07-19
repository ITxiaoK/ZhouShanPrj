namespace SuperMap.ZS.Workflow
{
    partial class WorkflowInfoControl
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
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtb_Description = new System.Windows.Forms.RichTextBox();
            this.lbl_Count = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_PlaySpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnScreenTip = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Draw = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_SelectColor = new System.Windows.Forms.Button();
            this.lst_Items = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetCamera = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_Workflow = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工艺名称：";
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Name.Location = new System.Drawing.Point(88, 25);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(149, 21);
            this.txt_Name.TabIndex = 1;
            this.txt_Name.Leave += new System.EventHandler(this.txt_Name_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "工艺描述：";
            // 
            // rtb_Description
            // 
            this.rtb_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Description.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_Description.Location = new System.Drawing.Point(16, 79);
            this.rtb_Description.Name = "rtb_Description";
            this.rtb_Description.Size = new System.Drawing.Size(221, 130);
            this.rtb_Description.TabIndex = 3;
            this.rtb_Description.Text = "（描述信息在200字以内。）";
            this.rtb_Description.TextChanged += new System.EventHandler(this.rtb_Description_TextChanged);
            this.rtb_Description.Enter += new System.EventHandler(this.rtb_Description_Enter);
            this.rtb_Description.Leave += new System.EventHandler(this.rtb_Description_Leave);
            // 
            // lbl_Count
            // 
            this.lbl_Count.AutoSize = true;
            this.lbl_Count.Location = new System.Drawing.Point(14, 212);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(83, 12);
            this.lbl_Count.TabIndex = 0;
            this.lbl_Count.Text = "已输入0个字。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "播放速度：";
            // 
            // txt_PlaySpeed
            // 
            this.txt_PlaySpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PlaySpeed.Location = new System.Drawing.Point(88, 234);
            this.txt_PlaySpeed.Name = "txt_PlaySpeed";
            this.txt_PlaySpeed.Size = new System.Drawing.Size(106, 21);
            this.txt_PlaySpeed.TabIndex = 1;
            this.txt_PlaySpeed.Text = "10";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "m/s：";
            // 
            // btnScreenTip
            // 
            this.btnScreenTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenTip.Location = new System.Drawing.Point(183, 648);
            this.btnScreenTip.Name = "btnScreenTip";
            this.btnScreenTip.Size = new System.Drawing.Size(75, 23);
            this.btnScreenTip.TabIndex = 4;
            this.btnScreenTip.Text = "操作导引";
            this.btnScreenTip.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Location = new System.Drawing.Point(162, 300);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "保  存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Draw
            // 
            this.btn_Draw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Draw.Enabled = false;
            this.btn_Draw.Location = new System.Drawing.Point(81, 300);
            this.btn_Draw.Name = "btn_Draw";
            this.btn_Draw.Size = new System.Drawing.Size(75, 23);
            this.btn_Draw.TabIndex = 4;
            this.btn_Draw.Text = "绘制流程";
            this.btn_Draw.UseVisualStyleBackColor = true;
            this.btn_Draw.Click += new System.EventHandler(this.btn_Draw_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "工艺颜色：";
            // 
            // btn_SelectColor
            // 
            this.btn_SelectColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectColor.Location = new System.Drawing.Point(88, 261);
            this.btn_SelectColor.Name = "btn_SelectColor";
            this.btn_SelectColor.Size = new System.Drawing.Size(106, 33);
            this.btn_SelectColor.TabIndex = 5;
            this.btn_SelectColor.UseVisualStyleBackColor = true;
            this.btn_SelectColor.Click += new System.EventHandler(this.btn_SelectColor_Click);
            // 
            // lst_Items
            // 
            this.lst_Items.Dock = System.Windows.Forms.DockStyle.Top;
            this.lst_Items.FormattingEnabled = true;
            this.lst_Items.ItemHeight = 12;
            this.lst_Items.Location = new System.Drawing.Point(3, 17);
            this.lst_Items.Name = "lst_Items";
            this.lst_Items.Size = new System.Drawing.Size(237, 196);
            this.lst_Items.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSetCamera);
            this.groupBox1.Controls.Add(this.lst_Items);
            this.groupBox1.Location = new System.Drawing.Point(15, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 244);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分段数据";
            // 
            // btnSetCamera
            // 
            this.btnSetCamera.Location = new System.Drawing.Point(158, 215);
            this.btnSetCamera.Name = "btnSetCamera";
            this.btnSetCamera.Size = new System.Drawing.Size(75, 23);
            this.btnSetCamera.TabIndex = 7;
            this.btnSetCamera.Text = "设置视角";
            this.btnSetCamera.UseVisualStyleBackColor = true;
            this.btnSetCamera.Click += new System.EventHandler(this.btnSetCamera_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbl_Count);
            this.groupBox2.Controls.Add(this.btn_SelectColor);
            this.groupBox2.Controls.Add(this.txt_Name);
            this.groupBox2.Controls.Add(this.btn_Draw);
            this.groupBox2.Controls.Add(this.txt_PlaySpeed);
            this.groupBox2.Controls.Add(this.btn_Save);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rtb_Description);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(15, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 329);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "流程信息";
            // 
            // cmb_Workflow
            // 
            this.cmb_Workflow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Workflow.FormattingEnabled = true;
            this.cmb_Workflow.Location = new System.Drawing.Point(103, 17);
            this.cmb_Workflow.Name = "cmb_Workflow";
            this.cmb_Workflow.Size = new System.Drawing.Size(145, 20);
            this.cmb_Workflow.TabIndex = 9;
            this.cmb_Workflow.SelectedIndexChanged += new System.EventHandler(this.cmb_Workflow_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "现有流程：";
            // 
            // WorkflowInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_Workflow);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnScreenTip);
            this.Name = "WorkflowInfoControl";
            this.Size = new System.Drawing.Size(273, 686);
            this.Load += new System.EventHandler(this.WorkflowInfoControl_Load);
            this.VisibleChanged += new System.EventHandler(this.WorkflowInfoControl_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtb_Description;
        private System.Windows.Forms.Label lbl_Count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_PlaySpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnScreenTip;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Draw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_SelectColor;
        private System.Windows.Forms.ListBox lst_Items;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetCamera;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_Workflow;
        private System.Windows.Forms.Label label6;
    }
}
