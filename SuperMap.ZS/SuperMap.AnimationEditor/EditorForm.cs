using SuperMap.UI;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperMap.AnimationEditor
{
    public partial class EditorForm : Form
    {
        private SceneControl m_SceneControl;

        public EditorForm()
        {
            InitializeComponent();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            try
            {
                m_SceneControl = new SceneControl(Realspace.SceneType.Globe)
                {
                    Dock = DockStyle.Fill
                };
                splitContainer.Panel1.Controls.Add(m_SceneControl);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
