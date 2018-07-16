namespace SuperMap.ZS.SecurityManager
{
    partial class MessageTipForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb_CurrentPrecent = new System.Windows.Forms.ProgressBar();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_CurrentPrecent = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pb_CurrentPrecent
            // 
            this.pb_CurrentPrecent.Location = new System.Drawing.Point(130, 27);
            this.pb_CurrentPrecent.Name = "pb_CurrentPrecent";
            this.pb_CurrentPrecent.Size = new System.Drawing.Size(267, 23);
            this.pb_CurrentPrecent.TabIndex = 0;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.Location = new System.Drawing.Point(12, 31);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(112, 14);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "任务进度(1/3)：";
            // 
            // lbl_CurrentPrecent
            // 
            this.lbl_CurrentPrecent.AutoSize = true;
            this.lbl_CurrentPrecent.Location = new System.Drawing.Point(403, 33);
            this.lbl_CurrentPrecent.Name = "lbl_CurrentPrecent";
            this.lbl_CurrentPrecent.Size = new System.Drawing.Size(17, 12);
            this.lbl_CurrentPrecent.TabIndex = 4;
            this.lbl_CurrentPrecent.Text = "0%";
            // 
            // MessageTipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 81);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_CurrentPrecent);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pb_CurrentPrecent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MessageTipForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "处理进度";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_CurrentPrecent;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_CurrentPrecent;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}