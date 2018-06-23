using MySql.Data.MySqlClient;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SuperMap.ZS.Data
{
    /// <summary>
    /// 工作空间信息，用于存储数据库中对应表数据。继承自BaseModel.
    /// </summary>
    public class WorkspaceInfo : BaseModel
    {
        /// <summary>
        /// 工作空间名称
        /// </summary>
        public string WorkspaceName { get; set; }

        /// <summary>
        /// 工作空间所在文件夹的服务器路径
        /// </summary>
        public string WorkspaceServerPath { get; set; }

        /// <summary>
        /// 工作空间是否被更新
        /// </summary>
        public bool IsUpdate { get; set; } = false;

        /// <summary>
        /// 获取所有工作空间信息
        /// </summary>
        /// <returns></returns>
        public override List<BaseModel> GetAllData()
        {
            List<BaseModel> lstResult = new List<BaseModel>();

            try
            {
                string sql = "select * from {0}";
                sql = string.Format(sql, Properties.Settings.Default.WorkspaceInfo);
                DataSet dt = DbHelperMySQL.GetDataSet(DbHelperMySQL.Conn, CommandType.Text, sql);
                if (dt.Tables.Count > 0)
                {
                    foreach (DataRow row in dt.Tables[0].Rows)
                    {
                        WorkspaceInfo info = new WorkspaceInfo();
                        info.ID = Convert.ToInt32(row["id"]);
                        info.WorkspaceName = Convert.ToString(row["WorkspaceName"]);
                        info.WorkspaceServerPath = Convert.ToString(row["WorkspaceServerPath"]);
                        switch (Convert.ToInt32(row["IsUpdate"]))
                        {
                            case 0:
                                info.IsUpdate = false;
                                break;
                            case 1:
                                info.IsUpdate = true;
                                break;
                        }
                        lstResult.Add(info);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return lstResult;
        }

        /// <summary>
        /// 获取某一个工作空间信息
        /// </summary>
        /// <param name="modelID">工作空间编号</param>
        /// <returns></returns>
        public override BaseModel GetData(int modelID)
        {
            WorkspaceInfo infoResult = new WorkspaceInfo();

            try
            {
                string sql = "select * from {0} where id='{1}'";
                sql = string.Format(sql, Properties.Settings.Default.WorkspaceInfo, modelID);
                DataSet dt = DbHelperMySQL.GetDataSet(DbHelperMySQL.Conn, CommandType.Text, sql);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    infoResult.ID = Convert.ToInt32(dt.Tables[0].Rows[0]["id"]);
                    infoResult.WorkspaceName = Convert.ToString(dt.Tables[0].Rows[0]["WorkspaceName"]);
                    infoResult.WorkspaceServerPath = Convert.ToString(dt.Tables[0].Rows[0]["WorkspaceServerPath"]);
                    switch (Convert.ToInt32(dt.Tables[0].Rows[0]["IsUpdate"]))
                    {
                        case 0:
                            infoResult.IsUpdate = false;
                            break;
                        case 1:
                            infoResult.IsUpdate = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return infoResult;
        }

        /// <summary>
        /// 提交工作空间修改信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Update(BaseModel model)
        {
            bool bResult = false;

            try
            {
                if (model is WorkspaceInfo info && !string.IsNullOrEmpty(info.WorkspaceName) && !string.IsNullOrEmpty(info.WorkspaceServerPath))
                {
                    List<string> values = new List<string>();

                    Type t = info.GetType();
                    foreach(PropertyInfo property in t.GetProperties())
                    {
                        values.Add(property.Name);
                    }

                    string conditions = "";
                    foreach(string name in values)
                    {
                        if (name.ToLower().Equals("id"))
                        {
                            continue;
                        }
                        if (name.ToLower().Equals("isupdate"))
                        {
                            string value = "0";

                            switch(info.GetType().GetProperty(name).GetValue(info, null))
                            {
                                case true:
                                    value = "1";
                                    break;
                                case false:
                                    value = "0";
                                    break;
                            }

                            conditions += string.Format("{0}='{1}'", name, value) + ",";
                        }
                        else
                        {
                            conditions += string.Format("{0}='{1}'", name, info.GetType().GetProperty(name).GetValue(info, null)) + ",";
                        }
                    }
                    if (conditions.Length > 0)
                    {
                        conditions = conditions.Substring(0, conditions.Length - 1);
                    }

                    string sql = "UPDATE {0} SET {1} WHERE {2}={3}";//UPDATE workspaceinfo SET WorkspaceName='舟山', IsUpdate=0 WHERE id=1
                    sql = string.Format(sql, Properties.Settings.Default.WorkspaceInfo, conditions, "id", info.ID);
                    if (DbHelperMySQL.ExecuteNonQuery(DbHelperMySQL.Conn, CommandType.Text, sql) > 0)
                    {
                        bResult = true;
                    }
                }
                else
                {
                    Log.ShowError("数据有误！");
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        /// <summary>
        /// 添加一个新的工作空间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool AddData(BaseModel model)
        {
            bool bResult = false;

            try
            {
                if(model is WorkspaceInfo info && !string.IsNullOrEmpty(info.WorkspaceName) && !string.IsNullOrEmpty(info.WorkspaceServerPath))
                {
                    List<string> names = new List<string>();

                    Type t = info.GetType();
                    foreach (PropertyInfo property in t.GetProperties())
                    {
                        names.Add(property.Name);
                    }

                    string colNames = "";
                    string values = "";
                    foreach (string name in names)
                    {
                        if (name.ToLower().Equals("id"))
                        {
                            continue;
                        }
                        colNames += name + ",";
                        if (name.ToLower().Equals("isupdate"))
                        {
                            string value = "0";

                            switch (info.GetType().GetProperty(name).GetValue(info, null))
                            {
                                case true:
                                    value = "1";
                                    break;
                                case false:
                                    value = "0";
                                    break;
                            }

                            values += "'" + value + "',";
                        }
                        else
                        {
                            values += "'" + info.GetType().GetProperty(name).GetValue(info, null) + "',";
                        }
                    }
                    if (values.Length > 0)
                    {
                        values = values.Substring(0, values.Length - 1);
                    }
                    if (colNames.Length > 0)
                    {
                        colNames = colNames.Substring(0, colNames.Length - 1);
                    }

                    string sql = "insert into {0}({1}) values({2})";
                    sql = string.Format(sql, Properties.Settings.Default.WorkspaceInfo, colNames, values);
                    if (DbHelperMySQL.ExecuteNonQuery(DbHelperMySQL.Conn, CommandType.Text, sql) > 0)
                    {
                        bResult = true;
                    }
                }
                else
                {
                    Log.ShowError("数据有误！");
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        /// <summary>
        /// 删除一个工作空间
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public override bool DeleteData(int modelID)
        {
            bool bResult = false;

            try
            {
                string sql = "delete from {0} where id={1}";
                sql = string.Format(sql, Properties.Settings.Default.WorkspaceInfo, modelID);
                if (DbHelperMySQL.ExecuteNonQuery(DbHelperMySQL.Conn, CommandType.Text, sql) > 0)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }
    }
}
