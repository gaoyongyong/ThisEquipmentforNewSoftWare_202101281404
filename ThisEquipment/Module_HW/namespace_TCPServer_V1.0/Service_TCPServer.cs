using Basic_UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolSetting.UI.TCPServer
{
    public class Service_TCPServer 
    {
        #region 1.变量
        /// <summary>
        /// Xml地址
        /// </summary>
        // private string Xml_Addr = @"D:\Program Files\ThisEquipment\Database\SwParameter\Xml\Form_TCPClient.xml";
        private string Xml_Addr;
        /// <summary>
        /// 服务端  
        /// </summary>
        private Socket ServerSocket = null;

        /// <summary>
        /// 监听客户端连接的标志
        /// </summary>
        private bool Flag_Listen = true;

        /// <summary>
        /// tcp客户端字典
        /// </summary>
        public Dictionary<string, MySession> dic_ClientSocket = new Dictionary<string, MySession>();

        /// <summary>
        /// 线程字典,每新增一个连接就添加一条线程
        /// </summary>
        private Dictionary<string, Thread> dic_ClientThread = new Dictionary<string, Thread>();

        /// <summary>
        /// TCPServer参数
        /// </summary>
        public Model_TCPServer Model_TCPServer ;
        /// <summary>
        /// 参数读取结果
        /// </summary>
        bool Result = false;

        /// <summary>
        /// TCP服务器读取的字符串
        /// </summary>
        public List<string> Receive_String;

        /// <summary>
        ///刷新界面
        /// </summary>
        public static event Action<List<string>> Form_Refresh;
        #endregion

        #region 3.构造函数
        public Service_TCPServer(string Name) 
        {
           // Xml_Addr = @"D:\Program Files\ThisEquipment\Database\HwParameter\Form_TCPServer\" + Name + ".xml";
            //读取参数
            Model_TCPServer = XmlObjConvert.DeserializeObjectFromPath<Model_TCPServer>(Xml_Addr, out Result);
            //实例化读取的字符串
            Receive_String = new List<string>();
        }
        #endregion

        #region 4.方法
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="port">端口号</param>
        public bool OpenServer()
        {
            try
            {
                Flag_Listen = true;
                // 创建负责监听的套接字，注意其中的参数；
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 创建包含ip和端口号的网络节点对象；
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Model_TCPServer.Port);
                try
                {
                    // 将负责监听的套接字绑定到唯一的ip和端口上；
                    ServerSocket.Bind(endPoint);
                   // ComData.writeStatue("创建服务器:" + endPoint + "成功!");
                }
                catch
                {
                    return false;
                }
                // 设置监听队列的长度；
                ServerSocket.Listen(1);
                // 创建负责监听的线程；
                //Client_Work cw = new Client_Work(这里给一个TCPCLIENT连接进去);
                //Thread st = new Thread(cw.Start);//这里丢到线程里去做，线程里去维护这个skt ，用完就关掉
                //st.IsBackground = true;
                //st.Start();

                //===========
                Thread Thread_ServerListen = new Thread(ListenConnecting);//估计这个地方导致崩了
                Thread_ServerListen.IsBackground = true;
                Thread_ServerListen.Start();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public void CloseServer()
        {
            lock (dic_ClientSocket)
            {
                foreach (var item in dic_ClientSocket)
                {
                    item.Value.Close();//关闭每一个连接
                }
                dic_ClientSocket.Clear();//清除字典
            }
            lock (dic_ClientThread)
            {
                foreach (var item in dic_ClientThread)
                {
                    item.Value.Abort();//停止线程
                }
                dic_ClientThread.Clear();
            }
            Flag_Listen = false;
            //ServerSocket.Shutdown(SocketShutdown.Both);//服务端不能主动关闭连接,需要把监听到的连接逐个关闭
            if (ServerSocket != null)
                ServerSocket.Close();
        }
        /// <summary>
        /// 接受数据
        /// </summary>
        /// <param name="sokConnectionparn"></param>
        public void ReceiveData(object sokConnectionparn)
        {
            MySession tcpClient = sokConnectionparn as MySession;
            Socket socketClient = tcpClient.TcpSocket;
            bool Flag_Receive = true;
            string keystr = socketClient.RemoteEndPoint.ToString();

            while (Flag_Receive)
            {
                Thread.Sleep(5);
                try
                {
                    //int len = socketClient.Available;
                    //if (len > 0)
                    //{
                    // 定义一个2M的缓存区；
                    byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                    // 将接受到的数据存入到输入  arrMsgRec中；
                    int length = -1;
                    try
                    {
                        length = socketClient.Receive(arrMsgRec); // 接收数据，并返回数据的长度；
                    }
                    catch
                    {
                        Flag_Receive = false;
                        // 从通信线程集合中删除被中断连接的通信线程对象；
                        dic_ClientSocket.Remove(keystr);//删除客户端字典中该socket
                        dic_ClientThread[keystr].Abort();//关闭线程
                        dic_ClientThread.Remove(keystr);//删除字典中该线程
                        tcpClient = null;
                        socketClient = null;
                        break;
                    }
                    byte[] buf = new byte[length];
                    Array.Copy(arrMsgRec, buf, length);
                    string dataRec = string.Empty;
                    dataRec = Encoding.Default.GetString(buf, 0, length);

                    string[] temp = dataRec.Split(',');
                    if (temp.Length > 0) 
                    {
                        Receive_String.Clear();
                        for (int i = 0; i < temp.Length; i++)
                        {
                            Receive_String.Add(temp[i]);
                        }
                        Form_Refresh?.Invoke(Receive_String);
                    }


                }
                catch(Exception ex)
                {
                    Basic_UI.Log.SaveError(ex);
                }
            }
        }
        /// <summary>
        /// 发送数据给指定的客户端
        /// </summary>
        /// <param name="_endPoint">客户端套接字</param>
        /// <param name="_buf">发送的数组</param>
        /// <returns></returns>
        public bool SendData(string _endPoint, string lon)
        {
            MySession myT = new MySession();
            byte[] _buf = { 0x00 };

            //_buf = Encoding.ASCII.GetBytes(lon);
            _buf = Encoding.Default.GetBytes(lon);
            if (dic_ClientSocket.TryGetValue(_endPoint, out myT))
            {

                myT.Send(_buf);
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 保存参数
        /// </summary>
        /// <returns></returns>
        public bool Save_Model()
        {
            //读取参数
            bool result = XmlObjConvert.SerializeObject(Model_TCPServer, Xml_Addr);
            return result;
        }

        /// <summary>
        /// 判断是否接受到数据
        /// </summary>
        /// <param name="Receive_No"></param>
        /// <param name="Check_String"></param>
        /// <returns></returns>
        public bool Fun_Check(int Receive_No, string Check_String)
        {
            if (Receive_String != null && Receive_String.Count >= Receive_No) 
            {
                if (Receive_String[Receive_No] == "Check_String")
                {
                    Receive_String.Clear();
                    return true;

                }
            }
            Receive_String.Clear();
            return false;
        }
        #endregion


        #region 5.私有方法
        /// <summary>
        /// 监听客户端请求的方法；
        /// </summary>
        private void ListenConnecting()
        {
            while (Flag_Listen)  // 持续不断的监听客户端的连接请求；
            {
                try
                {
                    Socket sokConnection = ServerSocket.Accept(); // 一旦监听到一个客户端的请求，就返回一个与该客户端通信的 套接字；
                    // 将与客户端连接的 套接字 对象添加到集合中；
                    string str_EndPoint = sokConnection.RemoteEndPoint.ToString();

                    //获取客户端的IP和端口号
                    IPAddress clientIP = (sokConnection.RemoteEndPoint as IPEndPoint).Address;
                    int clientPort = (sokConnection.RemoteEndPoint as IPEndPoint).Port;

                    //end
                    MySession myTcpClient = new MySession() { TcpSocket = sokConnection };
                    //创建线程接收数据
                    Thread th_ReceiveData = new Thread(ReceiveData);
                    th_ReceiveData.IsBackground = true;
                    th_ReceiveData.Start(myTcpClient);
                    //把线程及客户连接加入字典
                    dic_ClientThread.Add(str_EndPoint, th_ReceiveData);
                    dic_ClientSocket.Add(str_EndPoint, myTcpClient);
                }
                catch
                {
                    break;//没有这行的话，这个死循环就会出问题
                }
                Thread.Sleep(200);
            }
        }
        #endregion



    }



    /// <summary>
    /// 会话端
    /// </summary>
    public class MySession
    {
        public Socket TcpSocket;//socket对象
        public List<byte> m_Buffer = new List<byte>();//数据缓存区

        public MySession()
        {

        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="buf"></param>
        public void Send(byte[] buf)
        {
            if (buf != null)
            {
                TcpSocket.Send(buf, buf.Length, 0);
            }
        }
        /// <summary>
        /// 获取连接的ip
        /// </summary>
        /// <returns></returns>
        public string GetIp()
        {
            IPEndPoint clientipe = (IPEndPoint)TcpSocket.RemoteEndPoint;
            string _ip = clientipe.Address.ToString();
            return _ip;
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            TcpSocket.Shutdown(SocketShutdown.Both);
        }
        /// <summary>
        /// 提取正确数据包
        /// </summary>
        public byte[] GetBuffer(int startIndex, int size)
        {
            byte[] buf = new byte[size];
            m_Buffer.CopyTo(startIndex, buf, 0, size);
            m_Buffer.RemoveRange(0, startIndex + size);
            return buf;
        }

        /// <summary>
        /// 添加队列数据
        /// </summary>
        /// <param name="buffer"></param>
        public void AddQueue(byte[] buffer)
        {
            m_Buffer.AddRange(buffer);
        }
        /// <summary>
        /// 清除缓存
        /// </summary>
        public void ClearQueue()
        {
            m_Buffer.Clear();
        }
    }

}
