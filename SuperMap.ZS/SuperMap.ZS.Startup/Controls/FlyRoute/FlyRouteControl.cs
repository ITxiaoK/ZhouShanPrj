using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.ZS.Common;
using System.Xml.Linq;
using System.Diagnostics;
using SuperMap.Desktop;
using SuperMap.Realspace;
using System.IO;
using SuperMap.Data;

namespace SuperMap.ZS.Startup
{
    public partial class FlyRouteControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;
        private List<Label> lstData;

        public FlyRouteControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
            m_Application.Workspace.Closed += Workspace_Closed;
        }

        private void Workspace_Closed(object sender, WorkspaceClosedEventArgs args)
        {
            try
            {
                chkFlyRoute.DataSource = null;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnScreenTip_Click(object sender, EventArgs e)
        {
            try
            {
                XElement root = XElement.Load(CommonPars.ScreenTipConfigFilePath);
                root.SetElementValue("CurrentTip", "飞行路线入库");
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CommonPars.ScreenTipName);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void FlyRouteControl_Load(object sender, EventArgs e)
        {
            try
            {
                chkFlyRoute.Items.Clear();
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
                }
                if (lstData == null)
                {
                    lstData = new List<Label>();
                }
                foreach (Route route in m_SceneControl.Scene.FlyManager.Routes)
                {
                    lstData.Add(new Label { Text = route.Name, Tag = route });
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void LoadData()
        {
            try
            {
                chkFlyRoute.DataSource = null;
                chkFlyRoute.DataSource = lstData;
                chkFlyRoute.DisplayMember = "Text";
                chkFlyRoute.ValueMember = "Tag";
                if (chkFlyRoute.Items.Count > 0)
                {
                    chkFlyRoute.SetItemChecked(0, true);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void FlyRouteControl_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                lstData.Clear();
                foreach (Route route in m_SceneControl.Scene.FlyManager.Routes)
                {
                    lstData.Add(new Label { Text = route.Name, Tag = route });
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog
                {
                    Filter = "飞行路线文件|*.fpf",
                    InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop),
                    Multiselect = true,
                    Title = "选择飞行路线文件",
                };
                if (open.ShowDialog() == DialogResult.OK)
                {
                    foreach (string name in open.FileNames)
                    {
                        if (m_SceneControl.Scene.FlyManager.Routes.FromFile(name))
                        {
                            foreach (Route route in m_SceneControl.Scene.FlyManager.Routes)
                            {
                                lstData.Add(new Label { Text = route.Name, Tag = route });
                            }
                        }
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            Recordset objRt = null;
            try
            {
                if (chkFlyRoute.CheckedItems.Count == 0)
                {
                    m_Application.MessageBox.Show("请选择要提交的路线！");
                    return;
                }
                objRt = (m_Application.Workspace.Datasources["CommonData"].Datasets["FlyRouteTable"] as DatasetVector).GetRecordset(false, CursorType.Dynamic);
                Recordset.BatchEditor editor = objRt.Batch;
                editor.MaxRecordCount = 10;
                editor.Begin();
                int index = 1;
                foreach (object obj in chkFlyRoute.CheckedItems)
                {
                    Label label = obj as Label;
                    Route route= label.Tag as Route;
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("RouteID", index++.ToString());
                    dic.Add("RouteName", route.Name);
                    dic.Add("Content", Encoding.Default.GetBytes(route.ToXML()));
                    objRt.AddNew(null, dic);

                }
                editor.Update();
                m_Application.MessageBox.Show("路线入库成功！");
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
                m_Application.MessageBox.Show("路线入库失败！");
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

        private void tsspPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkFlyRoute.SelectedItems.Count == 0)
                {
                    m_Application.MessageBox.Show("请选择要预览的路线！");
                    return;
                }
                Route route = (chkFlyRoute.SelectedItem as Label).Tag as Route;
                Route existRoute = m_SceneControl.Scene.FlyManager.Routes[route.Name];
                if (existRoute != null)
                {
                    m_SceneControl.Scene.FlyManager.Play();
                    m_Application.MainForm.SelectedTabID = "SceneRouteManager";
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
