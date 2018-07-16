using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperMap.ZS.SecurityManager
{
    public partial class MessageTipForm : Form
    {
        private BackgroundWorker m_Worker;

        public MessageTipForm(BackgroundWorker backgroundWorker)
        {
            InitializeComponent();
            m_Worker = backgroundWorker;
            m_Worker.ProgressChanged += M_Worker_ProgressChanged;
            m_Worker.RunWorkerCompleted += M_Worker_RunWorkerCompleted;
        }

        private void M_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                pb_CurrentPrecent.Value = e.ProgressPercentage;
                lbl_CurrentPrecent.Text = e.ProgressPercentage + "%";
                lbl_Title.Text = e.UserState.ToString();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
