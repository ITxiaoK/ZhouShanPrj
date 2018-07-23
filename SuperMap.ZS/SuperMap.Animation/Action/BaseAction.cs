using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Animation
{
    /// <summary>
    /// 行为父类
    /// </summary>
    public class BaseAction
    {
        /// <summary>
        /// 行为开始时间
        /// </summary>
        public int StartTime { get; set; } = 0;

        /// <summary>
        /// 行为结束时间
        /// </summary>
        public int EndTime { get; set; } = 0;

        /// <summary>
        /// 行为类型
        /// </summary>
        public ActionType ActionType { get; set; } = ActionType.None;
    }
}
