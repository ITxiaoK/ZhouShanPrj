using SuperMap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// 粒子
    /// </summary>
    public class ParticleAction : BaseAction
    {
        /// <summary>
        /// 粒子类型
        /// </summary>
        [XmlElement(ElementName = "ParticleType", Type = typeof(ParticleType))]
        public ParticleType ParticleType { get; set; } = ParticleType.Fire;

        /// <summary>
        /// 粒子X轴比例
        /// </summary>
        [XmlElement(ElementName = "ScaleX", Type = typeof(double))]
        public double ScaleX { get; set; } = 1;

        /// <summary>
        /// 粒子Y轴比例
        /// </summary>
        [XmlElement(ElementName = "ScaleY", Type = typeof(double))]
        public double ScaleY { get; set; } = 1;

        /// <summary>
        /// 粒子Z轴比例
        /// </summary>
        [XmlElement(ElementName = "ScaleZ", Type = typeof(double))]
        public double ScaleZ { get; set; } = 1;

        /// <summary>
        /// 粒子绕X轴旋转
        /// </summary>
        [XmlElement(ElementName = "RotateX", Type = typeof(double))]
        public double RotateX { get; set; } = 0;

        /// <summary>
        /// 粒子绕Y轴旋转
        /// </summary>
        [XmlElement(ElementName = "RotateY", Type = typeof(double))]
        public double RotateY { get; set; } = 0;

        /// <summary>
        /// 粒子绕Z轴旋转
        /// </summary>
        [XmlElement(ElementName = "RotateZ", Type = typeof(double))]
        public double RotateZ { get; set; } = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ParticleAction()
        {
            Type = ActionType.Particle;
            Name = "粒子";
        }
    }
}
