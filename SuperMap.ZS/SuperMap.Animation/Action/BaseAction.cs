using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// 行为父类
    /// </summary>
    [XmlInclude(typeof(VisibleAction))]
    [XmlInclude(typeof(TwinkleAction))]
    [XmlInclude(typeof(LocationAction))]
    [XmlInclude(typeof(MoveAction))]
    [XmlInclude(typeof(ScreenTextAction))]
    [XmlInclude(typeof(ParticleAction))]
    public class BaseAction
    {
        /// <summary>
        /// 行为名称。
        /// </summary>
        [XmlElement(ElementName = "Name", Type = typeof(string))]
        public string Name { get; set; } = "未命名行为";

        /// <summary>
        /// 开始时间。
        /// </summary>
        [XmlElement(ElementName = "StartTime", Type = typeof(int))]
        public int StartTime { get; set; } = 0;

        /// <summary>
        /// 结束时间。
        /// </summary>
        [XmlElement(ElementName = "EndTime", Type = typeof(int))]
        public int EndTime { get; set; } = 0;

        /// <summary>
        /// 行为类型。
        /// </summary>
        [XmlElement(ElementName = "Type", Type = typeof(ActionType))]
        public ActionType Type { get; set; } = ActionType.None;
    }
}
