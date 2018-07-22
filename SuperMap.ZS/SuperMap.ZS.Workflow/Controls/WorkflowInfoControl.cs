using SuperMap.Data;
using SuperMap.Desktop;
using SuperMap.Realspace;
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

        private WorkflowEditType m_Type;
        public WorkflowEditType WorkflowEditType
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
                if (value == WorkflowEditType.Edit)
                {
                    LoadData();
                    cmb_Workflow.Enabled = true;
                    gb_Draw.Enabled = true;
                }
                else
                {
                    cmb_Workflow.Enabled = false;
                    gb_Draw.Enabled = false;
                }
            }
        }

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

                    switch (m_Type)
                    {
                        case WorkflowEditType.New:
                            cmb_Workflow.Enabled = false;
                            gb_Draw.Enabled = false;
                            break;
                        case WorkflowEditType.Edit:
                            cmb_Workflow.Enabled = true;
                            gb_Draw.Enabled = true;
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
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void WorkflowInfoControl_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Visible)
                {
                    m_lstItems.Clear();
                    m_lstWorkflow.Clear();
                    txt_Name.Text = "";
                    rtb_Description.Text = m_Tip;
                    txt_PlaySpeed.Text = "10";
                    btn_SelectColor.Text = "Workflow";
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
                m_SceneControl.Scene.Layers[txt_Name.Text.Trim() + "@SpaceData"].IsEditable = true;
                gb_Draw.Enabled = true;
                m_SceneControl.ObjectAdded += M_SceneControl_ObjectAdded;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_SceneControl_ObjectAdded(object sender, UI.ObjectAddedEventArgs e)
        {
            try
            {
                m_lstItems.Add(new Label { Text = "第【" + e.ID + "】分段(无视角)", Tag = e.ID });

                lst_Items.DataSource = null;
                lst_Items.DataSource = m_lstItems;
                lst_Items.DisplayMember = "Text";
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
                Symbol symbol = m_Application.Workspace.Resources.LineLibrary.FindSymbol(btn_SelectColor.Text);
                Symbol newSymbol = SymbolEditDialog.ShowDialog(symbol, m_Application.Workspace.Resources);
                btn_SelectColor.Text = newSymbol.Name;
                btn_SelectColor.Tag = newSymbol.ID;
                m_SceneControl.Scene.Layers[txt_Name.Text.Trim() + "@SpaceData"].UpdateData();
                m_SceneControl.Scene.Refresh();
                m_SceneControl.Focus();
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
                switch (m_Type)
                {
                    case WorkflowEditType.New:
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add("CraftName", txt_Name.Text.Trim());
                        dic.Add("Note", rtb_Description.Text.Equals(m_Tip) ? "" : rtb_Description.Text);
                        dic.Add("CraftID", (objRt.RecordCount + 1).ToString());
                        dic.Add("PlaySpeed", txt_PlaySpeed.Text);
                        dic.Add("Symbol", btn_SelectColor.Text + ',' + btn_SelectColor.Tag);
                        objRt.AddNew(null, dic);
                        objRt.Update();
                        break;
                    case WorkflowEditType.Edit:
                        objRt.Edit();
                        objRt.SetFieldValue("CraftName", txt_Name.Text.Trim());
                        objRt.SetFieldValue("Note", rtb_Description.Text.Equals(m_Tip) ? "" : rtb_Description.Text);
                        objRt.SetFieldValue("CraftID", objRt.RecordCount + 1);
                        objRt.SetFieldValue("PlaySpeed", txt_PlaySpeed.Text);
                        objRt.SetFieldValue("Symbol", btn_SelectColor.Text + ',' + btn_SelectColor.Tag);
                        objRt.Update();
                        break;
                }

                Layer3DDataset layer = m_SceneControl.Scene.Layers[txt_Name.Text + "@SpaceData"] as Layer3DDataset;
                for (int i = 0; i < (layer.Theme as Theme3DUnique).Count; i++)
                {
                    Theme3DUniqueItem item = (layer.Theme as Theme3DUnique)[i];
                    item.IsVisible = false;
                }
                m_Application.MessageBox.Show("保存成功！");
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
            LoadData();
        }

        private void LoadData()
        {
            Recordset objRt = null;
            try
            {
                if (m_Type == WorkflowEditType.New)
                {
                    return;
                }
                if (cmb_Workflow.SelectedItem == null)
                {
                    return;
                }
                string id = (cmb_Workflow.SelectedItem as Label).Tag.ToString();
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ArtCraftTable"] as DatasetVector).Query("CraftID='" + id + "'", CursorType.Static);
                if (objRt.RecordCount > 0)
                {
                    txt_Name.Text = Convert.ToString(objRt.GetFieldValue("CraftName"));
                    rtb_Description.Text = Convert.ToString(objRt.GetFieldValue("Note"));
                    txt_PlaySpeed.Text = Convert.ToString(objRt.GetFieldValue("PlaySpeed"));
                    btn_SelectColor.Text = Convert.ToString(objRt.GetFieldValue("Symbol")).Split(',')[0];
                    btn_SelectColor.Tag = Convert.ToString(objRt.GetFieldValue("Symbol")).Split(',')[1];

                    objRt.Close();
                    objRt.Dispose();

                    m_lstItems.Clear();
                    objRt = (m_Application.Workspace.Datasources["SpaceData"].Datasets[txt_Name.Text.Trim()] as DatasetVector).GetRecordset(false, CursorType.Static);
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
                            Tag = objRt.GetID()
                        };
                        m_lstItems.Add(lbl);

                        objRt.MoveNext();
                    }

                    lst_Items.DataSource = null;
                    lst_Items.DataSource = m_lstItems;
                    lst_Items.DisplayMember = "Text";
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
                if (!m_Application.Workspace.Datasources["SpaceData"].Datasets.IsAvailableDatasetName(txt_Name.Text.Trim(), DatasetType.Line3D))
                {
                    m_Application.MessageBox.Show("该流程已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Name.Text = "";
                    btn_Save.Enabled = false;
                }
                else
                {
                    switch (m_Type)
                    {
                        case WorkflowEditType.New:
                            SymbolRibbonTrail trail = new SymbolRibbonTrail((m_Application.Workspace.Resources.LineLibrary.FindSymbol("Workflow")) as SymbolRibbonTrail)
                            {
                                Name = string.IsNullOrEmpty(txt_Name.Text.Trim()) ? "Workflow_default" : "Workflow_" + txt_Name.Text.Trim()
                            };
                            m_Application.Workspace.Resources.LineLibrary.Add(trail);
                            m_Application.Workspace.Save();
                            btn_SelectColor.Text = trail.Name;
                            btn_SelectColor.Tag = trail.ID;


                            DatasetVectorInfo info = new DatasetVectorInfo
                            {
                                Name = txt_Name.Text.Trim(),
                                Type = DatasetType.Line3D,
                            };
                            DatasetVector objDtV = m_Application.Workspace.Datasources["SpaceData"].Datasets.Create(info);
                            objDtV.PrjCoordSys = m_Application.Workspace.Datasources["SpaceData"].PrjCoordSys;
                            for (int i = 0; i < 6; i++)
                            {
                                FieldInfo fieldInfo = new FieldInfo();
                                fieldInfo.Type = FieldType.Text;
                                switch (i)
                                {
                                    case 0:
                                        fieldInfo.Name = "Longitude";
                                        fieldInfo.Caption = "经度";
                                        break;
                                    case 1:
                                        fieldInfo.Name = "Latitude";
                                        fieldInfo.Caption = "纬度";
                                        break;
                                    case 2:
                                        fieldInfo.Name = "Altitude";
                                        fieldInfo.Caption = "高度";
                                        break;
                                    case 3:
                                        fieldInfo.Name = "Tilt";
                                        fieldInfo.Caption = "俯仰角";
                                        break;
                                    case 4:
                                        fieldInfo.Name = "Heading";
                                        fieldInfo.Caption = "视角";
                                        break;
                                    case 5:
                                        fieldInfo.Name = "Time";
                                        fieldInfo.Caption = "时长";
                                        break;
                                }
                                objDtV.FieldInfos.Add(fieldInfo);
                            }
                            GeoStyle3D style = new GeoStyle3D
                            {
                                LineSymbolID = Convert.ToInt32(btn_SelectColor.Tag)
                            };

                            Theme3DUnique theme = new Theme3DUnique
                            {
                                DefaultStyle = style,
                                UniqueExpression = "SmID"
                            };
                            for (int i = 0; i < theme.Count; i++)
                            {
                                Theme3DUniqueItem item = theme[i];
                                item.Style = style;
                            }
                            Layer3DDataset layer = m_SceneControl.Scene.Layers.Add(objDtV, theme, true);

                            m_lstWorkflow.Add(new Label { Text = txt_Name.Text.Trim(), Tag = cmb_Workflow.Items.Count + 1 });
                            cmb_Workflow.DataSource = null;
                            cmb_Workflow.DataSource = m_lstWorkflow;
                            cmb_Workflow.DisplayMember = "Text";
                            if (cmb_Workflow.Items.Count > 0)
                            {
                                cmb_Workflow.SelectedIndex = cmb_Workflow.Items.Count - 1;
                            }
                            break;
                    }
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
                int id = Convert.ToInt32((lst_Items.SelectedItem as Label).Tag);
                objRt = (m_Application.Workspace.Datasources["SpaceData"].Datasets[txt_Name.Text.Trim()] as DatasetVector).GetRecordset(false, CursorType.Dynamic);
                objRt.MoveTo(id);
                objRt.Edit();
                objRt.SetFieldValue("Longitude", m_SceneControl.Scene.Camera.Longitude.ToString());
                objRt.SetFieldValue("Latitude", m_SceneControl.Scene.Camera.Latitude.ToString());
                objRt.SetFieldValue("Altitude", m_SceneControl.Scene.Camera.Altitude.ToString());
                objRt.SetFieldValue("Tilt", m_SceneControl.Scene.Camera.Tilt.ToString());
                objRt.SetFieldValue("Heading", m_SceneControl.Scene.Camera.Heading.ToString());
                objRt.SetFieldValue("Time", txt_PlaySpeed.Text);
                objRt.Update();

                (m_lstItems[lst_Items.SelectedIndex] as Label).Text = (lst_Items.SelectedItem as Label).Text.Split('(')[0];

                lst_Items.DataSource = null;
                lst_Items.DataSource = m_lstItems;
                lst_Items.DisplayMember = "Text";
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

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Recordset objRt = null;

            try
            {
                Layer3DDataset layer = m_SceneControl.Scene.Layers[txt_Name.Text.Trim() + "@SpaceData"] as Layer3DDataset;
                GeoStyle3D style = new GeoStyle3D
                {
                    LineSymbolID = Convert.ToInt32(btn_SelectColor.Tag)
                };

                Theme3DUnique theme = layer.Theme as Theme3DUnique;
                theme.UniqueExpression = "SmID";
                theme.DefaultStyle = style;
                theme.Clear();

                m_lstItems.Clear();
                objRt = (m_Application.Workspace.Datasources["SpaceData"].Datasets[txt_Name.Text.Trim()] as DatasetVector).GetRecordset(false, CursorType.Static);
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
                        Tag = objRt.GetID()
                    };
                    m_lstItems.Add(lbl);

                    Theme3DUniqueItem item = new Theme3DUniqueItem
                    {
                        Caption = objRt.GetID().ToString(),
                        Style = style,
                        IsVisible = true,
                        Unique = objRt.GetID().ToString()
                    };
                    theme.Add(item);

                    objRt.MoveNext();
                }

                lst_Items.DataSource = null;
                lst_Items.DataSource = m_lstItems;
                lst_Items.DisplayMember = "Text";
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

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Recordset objRt = null;
            try
            {
                if (m_Application.MessageBox.Show("确定要删除【" + cmb_Workflow.Text + "】吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                txt_Name.Text = "";
                rtb_Description.Text = m_Tip;
                txt_PlaySpeed.Text = "10";
                btn_SelectColor.Text = "Workflow";
                rtb_Description.Font = new Font("宋体", 9F, FontStyle.Italic, GraphicsUnit.Point, 134);
                m_lstItems.Clear();
                lst_Items.DataSource = null;

                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ArtCraftTable"] as DatasetVector).Query("CraftName='" + cmb_Workflow.Text.Trim() + "'", CursorType.Dynamic);
                if (objRt.RecordCount > 0)
                {
                    objRt.Delete();
                }
                m_Application.Workspace.Resources.LineLibrary.Remove((m_Application.Workspace.Resources.LineLibrary.FindSymbol("Workflow_" + cmb_Workflow.Text.Trim())).ID);
                m_Application.Workspace.Datasources["SpaceData"].Datasets.Delete(cmb_Workflow.Text.Trim());
                m_Application.Workspace.Save();
                foreach (Label lbl in m_lstWorkflow)
                {
                    if (lbl.Text.Equals(cmb_Workflow.Text))
                    {
                        m_lstWorkflow.Remove(lbl);
                        break;
                    }
                }
                cmb_Workflow.DataSource = null;
                cmb_Workflow.DataSource = m_lstWorkflow;
                cmb_Workflow.DisplayMember = "Text";
                if (cmb_Workflow.Items.Count > 0)
                {
                    cmb_Workflow.SelectedIndex = 0;
                }
                m_Application.MessageBox.Show("删除成功！");
                
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            finally
            {
                if(objRt != null)
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
