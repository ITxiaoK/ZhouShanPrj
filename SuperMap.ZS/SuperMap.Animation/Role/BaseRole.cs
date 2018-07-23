using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Animation
{
    /// <summary>
    /// 动画角色父类
    /// </summary>
    public class BaseRole
    {
        /// <summary>
        /// 获取或设置角色名称
        /// </summary>
        public string Name { get; set; } = "未命名对象";

        /// <summary>
        /// 获取或设置角色动画
        /// </summary>
        public BaseAction Action { get; set; }

        /// <summary>
        /// 获取或设置是否保留结果，默认不保留
        /// </summary>
        public bool Retain { get; set; } = false;

        /// <summary>
        /// 更新动画
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// 清空动画
        /// </summary>
        public virtual void Clear()
        {

        }

        /// <summary>
        /// 记录初始信息
        /// </summary>
        public virtual void RecordData()
        {

        }
    }
}
