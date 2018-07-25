using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Animation
{
    /// <summary>
    /// 行为类型。
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// 显隐。
        /// </summary>
        Visible,
        /// <summary>
        /// 闪烁。
        /// </summary>
        Twinkle,
        /// <summary>
        /// 定位。
        /// </summary>
        Location,
        /// <summary>
        /// 移动。
        /// </summary>
        Move,
        /// <summary>
        /// 屏幕文字。
        /// </summary>
        ScreenText,
        /// <summary>
        /// 粒子。
        /// </summary>
        Particle,
        /// <summary>
        /// 无行为。
        /// </summary>
        None,
    }
}
