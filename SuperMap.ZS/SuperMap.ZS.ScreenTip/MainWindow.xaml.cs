using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SuperMap.ZS.Common;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Media.Animation;
using System.Linq;

namespace SuperMap.ZS.ScreenTip
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte[] result = new byte[1024];
        private Socket clientSocket;
        private int m_ImageIndex = 1;
        private int m_PlayCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DirectoryInfo topDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
                XElement root = XElement.Load(topDir.Parent.FullName + "\\Configuration\\SuperMap.ZS.Config.xml");
                string type = root.Element("ScreenTipType").Value;
                switch (type)
                {
                    case "Window":
                        WindowState = WindowState.Maximized;
                        img_left.Visibility = Visibility.Hidden;
                        img_right.Visibility = Visibility.Hidden;
                        gd_Images.Visibility = Visibility.Hidden;

                        break;
                    case "Next":
                        WindowState = WindowState.Normal;
                        img_left.Visibility = Visibility.Visible;
                        img_right.Visibility = Visibility.Visible;
                        gd_Images.Visibility = Visibility.Visible;
                        break;
                }

                gd_Images.Children.Clear();
                gd_Points.Children.Clear();
                string value = root.Element("CurrentTip").Value;
                foreach (var item in root.Elements("ScreenTip"))
                {
                    if (item.Attribute("Name").Value.Equals(value))
                    {
                        var list = item.Elements("Image");
                        for (int i = 0; i < Enumerable.Count(list); i++)
                        {
                            gd_Points.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                        }

                        int index = 0;
                        foreach (var img in list)
                        {
                            Ellipse ellipse = new Ellipse()
                            {
                                Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)),
                                Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
                                HorizontalAlignment = HorizontalAlignment.Left,
                                Margin = new Thickness(10, 5, 0, 5),
                                Width = 10,
                                Height = 10,
                                Cursor = Cursors.Hand,
                                Tag = index,
                            };
                            ellipse.MouseLeftButtonDown += Ellipse_MouseLeftButtonDown;
                            Grid.SetColumn(ellipse, index);
                            if (index == 0)
                            {
                                ellipse.Margin = new Thickness(0, 5, 0, 5);
                                ellipse.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                            }
                            gd_Points.Children.Add(ellipse);


                            Image image = new Image()
                            {
                                Source = new BitmapImage(new Uri(topDir.Parent.FullName + @"\Resources\ZhouShan\ScreenTip\" + item.Attribute("dirName").Value + "\\" + img.Value)),
                            };
                            TransformGroup transformGroup = new TransformGroup();
                            TranslateTransform transform = new TranslateTransform()
                            {
                                X = index++ * gd_Images.ActualWidth
                            };
                            transformGroup.Children.Add(transform);
                            image.RenderTransform = transformGroup;
                            gd_Images.Children.Add(image);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32((e.Source as Ellipse).Tag);
                m_PlayCount = m_ImageIndex - index -1;
                if (index > m_ImageIndex - 1)
                {
                    img_left_MouseLeftButtonDown(null, null);
                }
                else if(index<m_ImageIndex - 1)
                {
                    img_right_MouseLeftButtonDown(null, null);
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void btn_Next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sendMessage = "Home";
                //设定服务器IP地址
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    clientSocket.Connect(new IPEndPoint(ip, 8885)); //配置服务器IP与端口
                    //Console.WriteLine("连接服务器成功");
                }
                catch
                {
                    //Console.WriteLine("连接服务器失败，请按回车键退出！");
                    return;
                }
                //通过clientSocket接收数据
                //int receiveLength = clientSocket.Receive(result);
                //Console.WriteLine("接收服务器消息：{0}", Encoding.ASCII.GetString(result, 0, receiveLength));
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
                //Console.WriteLine("向服务器发送消息：{0}" + sendMessage);
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                //Log.OutputBox(ex);
            }
        }

        private void img_left_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (m_ImageIndex < gd_Images.Children.Count)
                {
                    R2L();
                    m_ImageIndex++;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void img_right_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (m_ImageIndex > 1)
                {
                    L2R();
                    m_ImageIndex--;
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void R2L()
        {
            try
            {
                Storyboard storyboard = new Storyboard();
                storyboard.Completed += Storyboard_Completed;
                
                foreach (Image img in gd_Images.Children)
                {
                    TranslateTransform transform = ((img.RenderTransform as TransformGroup).Children[0] as TranslateTransform);

                    DoubleAnimationUsingKeyFrames keyFrames = new DoubleAnimationUsingKeyFrames();
                    Storyboard.SetTarget(keyFrames, img);
                    Storyboard.SetTargetProperty(keyFrames, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));

                    BackEase backEase = new BackEase
                    {
                        EasingMode = EasingMode.EaseOut
                    };

                    EasingDoubleKeyFrame keyFrame1 = new EasingDoubleKeyFrame()
                    {
                        KeyTime = TimeSpan.FromSeconds(0),
                        Value = transform.X,
                        EasingFunction = backEase
                    };
                    keyFrames.KeyFrames.Add(keyFrame1);

                    EasingDoubleKeyFrame keyFrame2 = new EasingDoubleKeyFrame()
                    {
                        KeyTime = TimeSpan.FromSeconds(0.5),
                        Value = transform.X - gd_Images.ActualWidth,
                        EasingFunction = backEase
                    };
                    keyFrames.KeyFrames.Add(keyFrame2);
                    storyboard.Children.Add(keyFrames);
                }

                storyboard.Begin();

                foreach (Ellipse e in gd_Points.Children)
                {
                    e.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                }
                (gd_Points.Children[m_ImageIndex] as Ellipse).Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void L2R()
        {
            try
            {
                Storyboard storyboard = new Storyboard();
                storyboard.Completed += Storyboard_Completed;

                foreach (Image img in gd_Images.Children)
                {
                    TranslateTransform transform = ((img.RenderTransform as TransformGroup).Children[0] as TranslateTransform);

                    DoubleAnimationUsingKeyFrames keyFrames = new DoubleAnimationUsingKeyFrames();
                    Storyboard.SetTarget(keyFrames, img);
                    Storyboard.SetTargetProperty(keyFrames, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));

                    BackEase backEase = new BackEase
                    {
                        EasingMode = EasingMode.EaseOut
                    };

                    EasingDoubleKeyFrame keyFrame1 = new EasingDoubleKeyFrame()
                    {
                        KeyTime = TimeSpan.FromSeconds(0),
                        Value = transform.X,
                        EasingFunction = backEase
                    };
                    keyFrames.KeyFrames.Add(keyFrame1);

                    EasingDoubleKeyFrame keyFrame2 = new EasingDoubleKeyFrame()
                    {
                        KeyTime = TimeSpan.FromSeconds(0.5),
                        Value = transform.X + gd_Images.ActualWidth,
                        EasingFunction = backEase
                    };
                    keyFrames.KeyFrames.Add(keyFrame2);
                    storyboard.Children.Add(keyFrames);
                }

                storyboard.Begin();

                foreach (Ellipse e in gd_Points.Children)
                {
                    e.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                }
                (gd_Points.Children[m_ImageIndex - 2] as Ellipse).Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            try
            {
                bool R2L = true;
                if (m_PlayCount > 0)
                {
                    R2L = false;
                }
                else if (m_PlayCount < 0)
                {
                    R2L = true;
                }
                for (int i = 0; i < Math.Abs(m_PlayCount) - 1; i++)
                {
                    if (R2L)
                    {
                        img_left_MouseLeftButtonDown(null, null);
                    }
                    else
                    {
                        img_right_MouseLeftButtonDown(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        private void img_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }
    }
}
