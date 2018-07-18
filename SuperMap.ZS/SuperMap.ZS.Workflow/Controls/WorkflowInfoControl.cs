using SuperMap.Desktop;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperMap.ZS.Workflow
{
    public partial class WorkflowInfoControl : UserControl
    {
        private const string m_Tip = "（描述信息在200字以内。）";
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;
        private string m_Description = "";

        public WorkflowEditType WorkflowEditType { get; set; } = WorkflowEditType.New;

        public WorkflowInfoControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
            m_Application.Workspace.Closed += Workspace_Closed;
        }

        private void Workspace_Closed(object sender, Data.WorkspaceClosedEventArgs args)
        {
            try
            {
                txt_Name.Text = "";
                rtb_Description.Text = "";
                txt_PlaySpeed.Text = "10";
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void WorkflowInfoControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void WorkflowInfoControl_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                switch (WorkflowEditType)
                {
                    case WorkflowEditType.New:
                        btn_Draw.Enabled = false;
                        break;
                    case WorkflowEditType.Edit:
                        btn_Draw.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void rtb_Description_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rtb_Description.Text.Length > 200)
                {
                    rtb_Description.Text = m_Description;
                    return;
                }
                lbl_Count.Text = "已输入" + rtb_Description.Text.Length + "个字。";
                m_Description = rtb_Description.Text;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void rtb_Description_Enter(object sender, EventArgs e)
        {
            try
            {
                if (rtb_Description.Text.Length == 0)
                {
                    rtb_Description.Text = "";
                    rtb_Description.Font = new Font("宋体", 9F, FontStyle.Italic, GraphicsUnit.Point, 134);
                }
                if (rtb_Description.Text.Equals(m_Tip))
                {
                    rtb_Description.Text = "";
                    rtb_Description.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
                }
                else
                {
                    rtb_Description.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void rtb_Description_Leave(object sender, EventArgs e)
        {
            try
            {
                if (rtb_Description.Text.Length == 0)
                {
                    rtb_Description.Text = m_Tip;
                    rtb_Description.Font = new Font("宋体", 9F, FontStyle.Italic, GraphicsUnit.Point, 134);
                }
                else
                {
                    rtb_Description.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btn_Draw_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btn_SelectColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog color = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    FullOpen = false,
                    SolidColorOnly = true,
                };
                if (color.ShowDialog() == DialogResult.OK)
                {
                    btn_SelectColor.BackColor = color.Color;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Draw.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }

    public enum WorkflowEditType
    {
        New,
        Edit
    }
}
