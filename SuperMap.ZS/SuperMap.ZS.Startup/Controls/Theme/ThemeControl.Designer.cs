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
            this.SuspendLayout();
            // 
            // btnScreenTip
            // 
            this.btnScreenTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenTip.Location = new System.Drawing.Point(173, 597);
            this.btnScreenTip.Name = "btnScreenTip";
            this.btnScreenTip.Size = new System.Drawing.Size(75, 23);
            this.btnScreenTip.TabIndex = 0;
            this.btnScreenTip.Text = "操作导引";
            this.btnScreenTip.UseVisualStyleBackColor = true;
            this.btnScreenTip.Click += new System.EventHandler(this.btnScreenTip_Click);
            // 
            // btnDrawData
            // 
            this.btnDrawData.Location = new System.Drawing.Point(61, 50);
            this.btnDrawData.Name = "btnDrawData";
            this.btnDrawData.Size = new System.Drawing.Size(75, 23);
            this.btnDrawData.TabIndex = 1;
            this.btnDrawData.Text = "绘制数据";
            this.btnDrawData.UseVisualStyleBackColor = true;
            this.btnDrawData.Click += new System.EventHandler(this.btnDrawData_Click);
            // 
            // ThemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDrawData);
            this.Controls.Add(this.btnScreenTip);
            this.Name = "ThemeControl";
            this.Size = new System.Drawing.Size(269, 635);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScreenTip;
        private System.Windows.Forms.Button btnDrawData;
    }
}
