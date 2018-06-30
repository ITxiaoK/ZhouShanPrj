using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SuperMap.ZS.Common
{
    /// <summary>
    /// 服务端消息接收器，用于接收弹出界面发送过来的数据
    /// </summary>
    public class MessageServer
    {
        /// <summary>
        /// 消息接收委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ReceiveMessageHandler(object sender, ReceiveMessageData e);
        /// <summary>
        /// 消息接收事件
        /// </summary>
        public event ReceiveMessageHandler OnReceived;

        private byte[] result = new byte[1024];
        private int myProt = 8885;   //端口
        static Socket serverSocket;

        /// <summary>
        /// 开始监听
        /// </summary>
        public void StartReceive()
        {
            try
            {
                //服务器IP地址
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口
                serverSocket.Listen(10);    //设定最多10个排队连接请求
                                            //Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
                                            //通过Clientsoket发送数据
                Thread myThread = new Thread(ListenClientConnect);
                myThread.Start();
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Log.OutputBox(ex);
            }
        }

        /// <summary>
        /// 监听客户端连接
        /// </summary>
        private void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                //clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="clientSocket"></param>
        private void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据
                    int receiveNumber = myClientSocket.Receive(result);
                    OnReceived?.Invoke(this, new ReceiveMessageData() { Message = Encoding.ASCII.GetString(result, 0, receiveNumber) });
                    //Console.WriteLine("接收客户端{0}消息{1}", myClientSocket.RemoteEndPoint.ToString(), Encoding.ASCII.GetString(result, 0, receiveNumber));
                }
                catch (Exception ex)
                {
                    //Log.OutputBox(ex);
                    //Console.WriteLine(ex.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 服务端接收到的消息类
    /// </summary>
    public class ReceiveMessageData
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}
