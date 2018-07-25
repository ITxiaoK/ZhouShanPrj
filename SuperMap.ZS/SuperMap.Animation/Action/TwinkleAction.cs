using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// 闪烁行为。
    /// </summary>
    public class TwinkleAction : BaseAction
    {
        private int m_RepeatCount = 9;
        private int m_TimeLength = 5;

        /// <summary>
        /// 闪烁次数。
        /// </summary>
        [XmlElement(ElementName = "TwinkleCount", Type = typeof(int))]
        public int TwinkleCount { get; set; } = 5;

        /// <summary>
        /// 闪烁时长。
        /// </summary>
        [XmlElement(ElementName = "TimeLength", Type = typeof(int))]
        public int TimeLength { get; set; } = 9;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public TwinkleAction()
        {
            Type = ActionType.Twinkle;
            Name = "闪烁";
        }
    }
}
