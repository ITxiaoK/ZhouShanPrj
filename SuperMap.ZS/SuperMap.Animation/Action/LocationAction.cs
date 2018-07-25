using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// 定位行为。
    /// </summary>
    public class LocationAction : BaseAction
    {
        /// <summary>
        /// 经度。
        /// </summary>
        [XmlElement(ElementName = "Longitude", Type = typeof(double))]
        public double Longitude { get; set; } = 0;

        /// <summary>
        /// 纬度。
        /// </summary>
        [XmlElement(ElementName = "Latitude", Type = typeof(double))]
        public double Latitude { get; set; } = 0;

        /// <summary>
        /// 高度。
        /// </summary>
        [XmlElement(ElementName = "Altitude", Type = typeof(double))]
        public double Altitude { get; set; } = 0;

        /// <summary>
        /// 朝向。
        /// </summary>
        [XmlElement(ElementName = "Heading", Type = typeof(double))]
        public double Heading { get; set; } = 0;

        /// <summary>
        /// 俯仰。
        /// </summary>
        [XmlElement(ElementName = "Tilt", Type = typeof(double))]
        public double Tilt { get; set; } = 0;

        /// <summary>
        /// 高度模式。
        /// </summary>
        [XmlElement(ElementName = "AltitudeMode", Type = typeof(AltitudeMode))]
        public AltitudeMode AltitudeMode { get; set; } = AltitudeMode.Absolute;

        /// <summary>
        /// 定位速度，默认100 000米每秒。
        /// </summary>
        [XmlElement(ElementName = "Speed", Type = typeof(double))]
        public double Speed { get; set; } = 50000;

        /// <summary>
        /// 相机定位类型。默认为Fly。
        /// </summary>
        [XmlElement(ElementName = "LocationType", Type = typeof(LocationType))]
        public LocationType LocationType { get; set; } = LocationType.Fly;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public LocationAction()
        {
            Type = ActionType.Location;
            Name = "定位";
        }


        internal Camera Parse()
        {
            Camera camera = new Camera();

            try
            {
                camera.Longitude = Longitude;
                camera.Latitude = Latitude;
                camera.Altitude = Altitude;
                camera.Heading = Heading;
                camera.Tilt = Tilt;
                camera.AltitudeMode = (AltitudeMode)Enum.Parse(typeof(AltitudeMode), AltitudeMode.ToString());
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return camera;
        }
    }

    /// <summary>
    /// 相机定位类型。
    /// </summary>
    public enum LocationType
    {
        /// <summary>
        /// 飞行。
        /// </summary>
        Fly,
        /// <summary>
        /// 跳转。
        /// </summary>
        Jump
    }
}
