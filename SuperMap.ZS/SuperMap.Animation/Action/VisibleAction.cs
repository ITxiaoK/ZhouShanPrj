using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// 显示或隐藏
    /// </summary>
    public class VisibleAction : BaseAction
    {
        /// <summary>
        /// 是否显示。
        /// </summary>
        [XmlElement(ElementName = "Visible", Type = typeof(bool))]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public VisibleAction()
        {
            Type = ActionType.Visible;
            Name = "显隐";
        }
    }
}
