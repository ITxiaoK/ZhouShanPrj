﻿using System;
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
using SuperMap.Data;
using SuperMap.Desktop;
using SuperMap.Realspace;

namespace SuperMap.ZS.ResourceManager
{
    public partial class DeviceLocationControl : UserControl
    {
        private Desktop.Application m_Application;
        private DesktopSceneControl m_SceneControl;
        private List<DeviceTypeData> m_lstData;

        public DeviceLocationControl()
        {
            InitializeComponent();
            m_Application = Desktop.Application.ActiveApplication;
        }

        private void btnScreenTip_Click(object sender, EventArgs e)
        {
            try
            {
                XElement root = XElement.Load(CommonPars.ScreenTipConfigFilePath);
                root.SetElementValue("CurrentTip", "设备定位");
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CommonPars.ScreenTipName);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void DeviceLocationControl_Load(object sender, EventArgs e)
        {
            Recordset objRt = null;

            try
            {
                if (m_lstData == null)
                {
                    m_lstData = new List<DeviceTypeData>();
                }
                if (m_Application.MainForm.FormManager.ActiveForm is IFormScene formScene)
                {
                    m_SceneControl = formScene.SceneControl;
                }
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets["ResourceTable"] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    DeviceTypeData data = new DeviceTypeData
                    {
                        ResourceName = Convert.ToString(objRt.GetFieldValue("SourceName")),
                        ResourceTableName = Convert.ToString(objRt.GetFieldValue("TableName")),
                        FieldID = string.IsNullOrEmpty(Convert.ToString(objRt.GetFieldValue("TableField"))) ? null : Convert.ToString(objRt.GetFieldValue("TableField")).Split(',')[0],
                        FieldName = string.IsNullOrEmpty(Convert.ToString(objRt.GetFieldValue("TableField"))) ? null : Convert.ToString(objRt.GetFieldValue("TableField")).Split(',')[1],
                    };

                    m_lstData.Add(data);

                    objRt.MoveNext();
                }
                GetData();
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

        private void GetData()
        {
            try
            {
                cmbDeviceType.DataSource = null;
                cmbDeviceType.DataSource = m_lstData;
                cmbDeviceType.DisplayMember = "ResourceName";
                if (cmbDeviceType.Items.Count > 0)
                {
                    cmbDeviceType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void cmbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recordset objRt = null;
            try
            {
                dg_Data.Rows.Clear();
                DeviceTypeData data = cmbDeviceType.SelectedItem as DeviceTypeData;
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets[data.ResourceTableName] as DatasetVector).GetRecordset(false, CursorType.Static);
                objRt.MoveFirst();
                while (!objRt.IsEOF)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell
                    {
                        Value = Convert.ToString(objRt.GetFieldValue(data.FieldID))
                    };
                    row.Cells.Add(cell1);

                    int isSet = 0;
                    if (objRt.GetFieldValue("Heading") == null && objRt.GetFieldValue("Altitude") == null)
                    {
                        isSet = 0;
                    }
                    else
                    {
                        isSet = 1;
                    }
                    DataGridViewCheckBoxCell cell2 = new DataGridViewCheckBoxCell
                    {
                        Value = isSet
                    };
                    row.Cells.Add(cell2);
                    row.Tag = objRt.GetID();
                    dg_Data.Rows.Add(row);

                    objRt.MoveNext();
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

        private void dg_Data_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Recordset objRt = null;

            try
            {
                DataGridViewRow row = dg_Data.Rows[e.RowIndex];
                DeviceTypeData data = cmbDeviceType.SelectedItem as DeviceTypeData;
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets[data.ResourceTableName] as DatasetVector).GetRecordset(false, CursorType.Static);
                if (objRt.SeekID(Convert.ToInt32(row.Tag)))
                {
                    double lon = Convert.ToDouble(objRt.GetFieldValue("Longitude"));
                    double lat = Convert.ToDouble(objRt.GetFieldValue("Latitude"));
                    double alt = Convert.ToDouble(objRt.GetFieldValue("Altitude"));
                    double heading = Convert.ToDouble(objRt.GetFieldValue("Heading"));
                    double tilt = Convert.ToDouble(objRt.GetFieldValue("Tilt"));
                    Camera camera = new Camera
                    {
                        Longitude = lon,
                        Latitude = lat,
                        Altitude = alt,
                        Heading = heading,
                        Tilt = tilt,
                        AltitudeMode = AltitudeMode.Absolute
                    };
                    m_SceneControl.Scene.Fly(camera);
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

        private void btnGetCamera_Click(object sender, EventArgs e)
        {

            Recordset objRt = null;

            try
            {
                if (dg_Data.SelectedRows.Count == 0)
                {
                    m_Application.MessageBox.Show("未选中数据！");
                    return;
                }
                DataGridViewRow row = dg_Data.SelectedRows[0];
                DeviceTypeData data = cmbDeviceType.SelectedItem as DeviceTypeData;
                objRt = (m_Application.Workspace.Datasources["Resource"].Datasets[data.ResourceTableName] as DatasetVector).GetRecordset(false, CursorType.Dynamic);
                if (objRt.SeekID(Convert.ToInt32(row.Tag)) && objRt.Edit())
                {
                    objRt.SetFieldValue("Longitude", m_SceneControl.Scene.Camera.Longitude);
                    objRt.SetFieldValue("Latitude", m_SceneControl.Scene.Camera.Latitude);
                    objRt.SetFieldValue("Altitude", m_SceneControl.Scene.Camera.Altitude);
                    objRt.SetFieldValue("Heading", m_SceneControl.Scene.Camera.Heading);
                    objRt.SetFieldValue("Tilt", m_SceneControl.Scene.Camera.Tilt);

                    if (objRt.Update())
                    {
                        m_Application.MessageBox.Show("视角保存成功！");
                    }
                    else
                    {
                        m_Application.MessageBox.Show("视角保存失败！");
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
    }

    internal class DeviceTypeData
    {
        internal string ResourceName { get; set; }

        internal string ResourceTableName { get; set; }

        internal string FieldID { get; set; }

        internal string FieldName { get; set; }
    }
}
