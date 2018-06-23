using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.ZS.Data
{
    /// <summary>
    /// Model父类
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// 编号。
        /// </summary>
        public int ID { get; set; } = 1;

        /// <summary>
        /// 根据ID获取对应的所有数据
        /// </summary>
        /// <param name="modelID">ID</param>
        /// <returns></returns>
        public virtual BaseModel GetData(int modelID)
        {
            return null;
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public virtual List<BaseModel> GetAllData()
        {
            return null;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="model">表对象</param>
        /// <returns></returns>
        public virtual bool Update(BaseModel model)
        {
            return false;
        }

        /// <summary>
        /// 添加新数据
        /// </summary>
        /// <param name="model">表对象</param>
        /// <returns></returns>
        public virtual bool AddData(BaseModel model)
        {
            return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="modelID">ID</param>
        /// <returns></returns>
        public virtual bool DeleteData(int modelID)
        {
            return false;
        }
    }
}
