using SuperMap.UI;
using SuperMap.ZS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace SuperMap.Animation
{
    /// <summary>
    /// 动画信息类型，通过该类
    /// </summary>
    public class Animation
    {
        private DispatcherTimer m_Timer;
        private int m_Index;
        internal string m_BasePath;
        internal Animation m_Animation;

        /// <summary>
        /// 获取动画总时长
        /// </summary>
        public int TimeCount { get; private set; } = 0;

        /// <summary>
        /// 获取或设置对象集合。
        /// </summary>
        [XmlElement(ElementName = "Role")]
        public List<BaseRole> Roles { get; set; }

        /// <summary>
        /// 场景控件
        /// </summary>
        public SceneControl SceneControl { get; set; }

        /// <summary>
        /// 动画结束事件。
        /// </summary>
        public event EventHandler Stopped;

        /// <summary>
        /// 动画播放委托。
        /// </summary>
        /// <param name="e"></param>
        public delegate void TimerTickHandler(AnimationTickArgs e);
        /// <summary>
        /// 动画帧事件。
        /// </summary>
        public event TimerTickHandler Tick;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public Animation()
        {
            try
            {
                Roles = new List<BaseRole>();
                m_Timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(1000)
                };
                m_Timer.Tick += M_Timer_Tick;
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void M_Timer_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
        
        /// <summary>
        /// 播放动画
        /// </summary>
        public void Play()
        {
            try
            {
                int count = 0;
                foreach (BaseRole role in Roles)
                {
                    if (role.Action.EndTime > count)
                    {
                        count = role.Action.EndTime;
                    }
                }
                TimeCount = count;
                m_Timer.Start();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
        
        /// <summary>
        /// 暂停。
        /// </summary>
        public void Pause()
        {
            try
            {
                m_Timer.Stop();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        /// <summary>
        /// 停止。
        /// </summary>
        public void Stop()
        {
            try
            {
                m_Index = 0;
                TimeCount = 0;
                m_Timer.Stop();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        /// <summary>
        /// 重播。
        /// </summary>
        public void RePlay()
        {
            try
            {
                m_Index = 0;
                m_Timer.Start();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool FromXml(string path)
        {
            bool bResult = false;
            try
            {
                if (!File.Exists(path))
                {
                    return bResult;
                }
                m_Animation = XmlOperator.XmlSerialize<Animation>(path);
                m_Animation.m_BasePath = path.Substring(0, path.LastIndexOf("\\") + 1);
                m_Animation.SceneControl = SceneControl;

                for (int i = 0; i < m_Animation.Roles.Count; i++)
                {
                    for (int j = 0; j < m_Animation.Roles.Count - 1 - i; j++)
                    {
                        if (m_Animation.Roles[j].Action.StartTime > m_Animation.Roles[j + 1].Action.StartTime)
                        {
                            BaseRole temprole = m_Animation.Roles[j + 1];
                            m_Animation.Roles[j + 1] = m_Animation.Roles[j];
                            m_Animation.Roles[j] = temprole;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            return bResult;
        }

        /// <summary>
        /// 生成配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ToXml(string path)
        {
            bool bResult = false;
            try
            {
                bResult = XmlOperator.XmlDeSerialize(m_Animation, path);
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
            return bResult;
        }
    }

    /// <summary>
    /// 动画播放参数。
    /// </summary>
    public class AnimationTickArgs : EventArgs
    {
        /// <summary>
        /// 当前播放秒数。
        /// </summary>
        public int Second { get; set; } = 0;
    }
}
