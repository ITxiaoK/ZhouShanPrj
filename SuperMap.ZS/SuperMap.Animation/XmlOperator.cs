using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// XML操作类
    /// </summary>
    public class XmlOperator
    {
        /// <summary>
        /// 反序列化Xml文件。
        /// </summary>
        /// <typeparam name="T">序列化类型。</typeparam>
        /// <param name="path">文件路径。</param>
        /// <returns>类对象。</returns>
        public static T XmlSerialize<T>(string path)
        {
            T t = default(T);

            try
            {
                if (!File.Exists(path))
                {
                    return t;
                }
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                XmlSerializer xmlSearializer = new XmlSerializer(typeof(T));
                t = (T)xmlSearializer.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return t;
        }

        /// <summary>
        /// 序列化对象为Xml文件。
        /// </summary>
        /// <typeparam name="T">序列化类型。</typeparam>
        /// <param name="obj">类对象。</param>
        /// <param name="path">保存路径。</param>
        /// <returns>是否序列化成功。</returns>
        public static bool XmlDeSerialize<T>(T obj, string path)
        {
            bool bResult = false;

            try
            {
                StreamWriter streamWriter = new StreamWriter(path);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(streamWriter, obj);
                streamWriter.Close();

                bResult = true;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }

        /// <summary>
        /// 序列化对象为Xml文件。
        /// </summary>
        /// <typeparam name="T">序列化类型。</typeparam>
        /// <param name="obj">类对象。</param>
        /// <param name="path">保存路径。</param>
        /// <param name="types">转换类型集合。</param>
        /// <returns>是否序列化成功。</returns>
        public static bool XmlDeSerialize<T>(T obj, string path, Type[] types)
        {
            bool bResult = false;

            try
            {
                StreamWriter streamWriter = new StreamWriter(path);
                XmlSerializer serializer = new XmlSerializer(typeof(T), types);
                serializer.Serialize(streamWriter, obj);
                streamWriter.Close();

                bResult = true;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }

            return bResult;
        }
    }
}
