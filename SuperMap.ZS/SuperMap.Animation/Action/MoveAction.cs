using SuperMap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// 移动行为
    /// </summary>
    public class MoveAction : BaseAction
    {
        /// <summary>
        /// 移动点集合
        /// </summary>
        [XmlElement(ElementName = "TracePoint3Ds", Type = typeof(Point3Ds))]
        public Point3Ds TracePoint3Ds { get; set; } = new Point3Ds();

        /// <summary>
        /// 构造函数
        /// </summary>
        public MoveAction()
        {
            Type = ActionType.Move;
            Name = "运动";
        }
    }
}
