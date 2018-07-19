using SuperMap.Data;
using SuperMap.Desktop;
using SuperMap.Realspace;
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

        private List<Label> m_lstWorkflow;
        private List<Label> m_lstItems;

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
                m_lstWorkflow = new List<Label>();
                m_lstItems = new List<Label>();
                Recordset objRt = null;

                try
                {
                    objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ArtCraftTable"] as DatasetVector).GetRecordset(false, CursorType.Static);
                    objRt.MoveFirst();
                    while (!objRt.IsEOF)
                    {
                        Label lbl = new Label
                        {
                            Text = Convert.ToString(objRt.GetFieldValue("CraftName")),
                            Tag = objRt.GetFieldValue("CraftID")
                        };
                        m_lstWorkflow.Add(lbl);

                        objRt.MoveNext();
                    }
                    cmb_Workflow.DataSource = m_lstWorkflow;
                    cmb_Workflow.DisplayMember = "Text";
                    if (cmb_Workflow.Items.Count > 0)
                    {
                        cmb_Workflow.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    Log.OutputBox(ex);
                }
                finally
                {
                    if (objRt != null)
                    {
                        objRt.Close();
                        objRt.Dispose();
                    }
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
                        cmb_Workflow.Enabled = false;
                        break;
                    case WorkflowEditType.Edit:
                        btn_Draw.Enabled = true;
                        cmb_Workflow.Enabled = true;
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
                m_SceneControl.Scene.Layers[txt_Name.Text + "@SpaceData"].IsEditable = true;
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
            Recordset objRt = null;
            try
            {
                btn_Draw.Enabled = true;
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ArtCraftTable"] as DatasetVector).GetRecordset(false, CursorType.Dynamic);
                switch (WorkflowEditType)
                {
                    case WorkflowEditType.New:
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add("CraftName", txt_Name.Text);
                        dic.Add("Note", rtb_Description.Text.Equals(m_Tip) ? "" : rtb_Description.Text);
                        dic.Add("CraftID", objRt.RecordCount + 1);
                        dic.Add("PlaySpeed", txt_PlaySpeed.Text);
                        dic.Add("Color", btn_SelectColor.BackColor.ToArgb().ToString());
                        objRt.AddNew(null, dic);
                        objRt.Update();
                        DatasetVectorInfo info = new DatasetVectorInfo
                        {
                            Name = txt_Name.Text,
                            Type = DatasetType.Line3D,
                        };
                        DatasetVector objDtV = m_Application.Workspace.Datasources["SpaceData"].Datasets.Create(info);
                        m_SceneControl.Scene.Layers.Add(objDtV, new Layer3DSettingVector(), true);

                        m_lstWorkflow.Add(new Label { Text = txt_Name.Text, Tag = objRt.RecordCount + 1 });
                        cmb_Workflow.DataSource = null;
                        cmb_Workflow.DataSource = m_lstWorkflow;
                        cmb_Workflow.DisplayMember = "Text";
                        if (cmb_Workflow.Items.Count > 0)
                        {
                            cmb_Workflow.SelectedIndex = cmb_Workflow.Items.Count - 1;
                        }
                        break;
                    case WorkflowEditType.Edit:
                        objRt.Edit();
                        objRt.SetFieldValue("CraftName", txt_Name.Text);
                        objRt.SetFieldValue("Note", rtb_Description.Text.Equals(m_Tip) ? "" : rtb_Description.Text);
                        objRt.SetFieldValue("CraftID", objRt.RecordCount + 1);
                        objRt.SetFieldValue("PlaySpeed", txt_PlaySpeed.Text);
                        objRt.SetFieldValue("Color", btn_SelectColor.BackColor.ToArgb().ToString());
                        objRt.Update();
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                if (objRt != null)
                {
                    objRt.Close();
                    objRt.Dispose();
                }
            }
        }

        private void cmb_Workflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recordset objRt = null;
            try
            {
                string id = (cmb_Workflow.SelectedItem as Label).Tag.ToString();
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ArtCraftTable"] as DatasetVector).Query("CraftID='" + id + "'", CursorType.Static);
                if (objRt.RecordCount > 0)
                {
                    txt_Name.Text = Convert.ToString(objRt.GetFieldValue("CraftName"));
                    rtb_Description.Text = Convert.ToString(objRt.GetFieldValue("Note"));
                    txt_PlaySpeed.Text = Convert.ToString(objRt.GetFieldValue("PlaySpeed"));
                    string color = Convert.ToString(objRt.GetFieldValue("Color"));
                    if (!string.IsNullOrEmpty(color))
                    {
                        btn_SelectColor.BackColor = Color.FromArgb(Convert.ToInt32(color.Split(',')[0]),
                            Convert.ToInt32(color.Split(',')[1]), Convert.ToInt32(color.Split(',')[2]),
                            Convert.ToInt32(color.Split(',')[3]));
                    }

                    objRt.Close();
                    objRt.Dispose();

                    objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ArtCraftTable"] as DatasetVector).GetRecordset(false, CursorType.Static);
                    objRt.MoveFirst();
                    while (!objRt.IsEOF)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>
                        {
                            { "lon", objRt.GetFieldValue("Longitude") },
                            { "lat", objRt.GetFieldValue("Latitude") },
                            { "alt", objRt.GetFieldValue("Altitude") },
                            { "tilt", objRt.GetFieldValue("Tilt") },
                            { "heading", objRt.GetFieldValue("Heading") },
                            { "geo", objRt.GetGeometry() }
                        };
                        bool flag = false;
                        if (objRt.GetFieldValue("Longitude") == null)
                        {
                            flag = true;
                        }
                        Label lbl = new Label
                        {
                            Text = flag ? "第【" + objRt.GetID() + "】分段(无视角)" : "第【" + objRt.GetID() + "】分段",
                            Tag = dic
                        };
                        m_lstItems.Add(lbl);

                        objRt.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                if (objRt != null)
                {
                    objRt.Close();
                    objRt.Dispose();
                }
            }
        }

        private void txt_Name_Leave(object sender, EventArgs e)
        {
            try
            {
                if (m_Application.Workspace.Datasources["SpaceData"].Datasets.IsAvailableDatasetName(txt_Name.Text, DatasetType.Line3D))
                {
                    m_Application.MessageBox.Show("该流程已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Save.Enabled = false;
                }
                else
                {
                    btn_Save.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnSetCamera_Click(object sender, EventArgs e)
        {
            Recordset objRt = null;
            try
            {
                if (lst_Items.SelectedItem == null)
                {
                    m_Application.MessageBox.Show("请选择分段数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                objRt = (m_Application.Workspace.Datasources["SpaceData"].Datasets[txt_Name.Text] as DatasetVector).GetRecordset(false, CursorType.Dynamic);
                objRt.Edit();
                objRt.SetFieldValue("Longitude", m_SceneControl.Scene.Camera.Longitude);
                objRt.SetFieldValue("Latitude", m_SceneControl.Scene.Camera.Latitude);
                objRt.SetFieldValue("Altitude", m_SceneControl.Scene.Camera.Altitude);
                objRt.SetFieldValue("Tilt", m_SceneControl.Scene.Camera.Tilt);
                objRt.SetFieldValue("Heading", m_SceneControl.Scene.Camera.Heading);
                objRt.Update();

                if ((lst_Items.SelectedItem as Label).Text.Contains("("))
                {
                    (lst_Items.SelectedItem as Label).Text = (lst_Items.SelectedItem as Label).Text.Split('(')[0];
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                if (objRt != null)
                {
                    objRt.Close();
                    objRt.Dispose();
                }
            }
        }
    }

    public enum WorkflowEditType
    {
        New,
        Edit
    }
}
