using SuperMap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// 屏幕提示
    /// </summary>
    public class ScreenTextAction : BaseAction
    {
        /// <summary>
        /// 提示内容
        /// </summary>
        [XmlElement(ElementName = "Content", Type = typeof(string))]
        public string Content { get; set; } = "";

        /// <summary>
        /// 文字风格
        /// </summary>
        [XmlElement(ElementName = "TextStyle", Type = typeof(TextStyle))]
        public TextStyle TextStyle { get; set; } = new TextStyle();

        /// <summary>
        /// 构造函数
        /// </summary>
        public ScreenTextAction()
        {
            Type = ActionType.ScreenText;
            Name = "屏幕提示";
        }
    }
}
