/*====================================功能==========================================
TCP刻画端

=====================================更新记录==========================================
修改日期：2016-03-10
更新内容：

=====================================使用方法=========================================


=======================================================================================*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


using System.Collections;

using System.Runtime.InteropServices;
using Basic_UI;
using System.Threading;

namespace ToolSetting.UI.TCPClient

{
    public class Service_TCPClient
    {
        #region 1.变量    
        /// <summary>
        /// Xml地址
        /// </summary>
        // private string Xml_Addr = @"D:\Program Files\ThisEquipment\Database\SwParameter\Xml\Form_TCPClient"+ Name +".xml";
        private string Xml_Addr = "";
        /// <summary>
        /// Socket 实例化类
        /// </summary>
        private Socket sckKey = null;

        /// <summary>
        /// 实例化端口
        /// </summary>
        private IPEndPoint IpEnd;

        /// <summary>
        /// 类构造函数运行结果
        /// </summary>
        private bool Result;

        /// <summary>
        /// Model
        /// </summary>
        public Model_TCPClient Model_TCPClient;

        /// <summary>
        /// 返回的字符串
        /// </summary>
        public string TCPClient_Result = "";



        #endregion
        #region 2.构造函数
        public Service_TCPClient()
        {
            //读取参数
            Model_TCPClient = new Model_TCPClient();

        }

        #endregion


        #region 3.公用方法
        public bool initial()
        {
            try
            {
                int Port = Convert.ToInt16(Model_TCPClient.Port);
                IpEnd = new IPEndPoint(IPAddress.Parse(Model_TCPClient.IP), Port);
                sckKey = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sckKey.Connect(IpEnd);
                return true;
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
            }

            return false;
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        /// <returns></returns>
        public bool Save_Model()
        {
           
            //读取参数
            bool result = XmlObjConvert.SerializeObject(Model_TCPClient, Xml_Addr);
            return result;
        }

        private object ob = new object();
        /// <summary>
        /// 发送和接受数据
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public bool SendAndGetData(string cmd, out List<double> Result)
        {
            lock (ob) 
            {
                //初始化输入变量
                List<double> result = new List<double>();
                try
                {
                    if ((sckKey == null))
                    {
                        initial();
                        Result = result;
                        ToolInfo.Error_String = "TCP客户端不存在";
                        return false;
                    }
                    //建立与远程主机的连接
                    if (!sckKey.Connected)
                    {
                        sckKey.Dispose();
                        sckKey = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        sckKey.Connect(IpEnd);
                        Result = result;
                        ToolInfo.Error_String = "TCP客户端未连接";
                        return false;
                    }
                    else
                    {
                        sckKey.ReceiveTimeout = Model_TCPClient.Delay_Time;
                        string strSendData = cmd;
                        byte[] bytSendData = Encoding.ASCII.GetBytes(strSendData); //将指定的 String 中的所有字符编码为一个字节序列
                        sckKey.Send(bytSendData, bytSendData.Length, 0);  //使用指定的 SocketFlags，将指定字节数的数据发送到已连接的 Socket

                        SocketError ERRORCODE = 0;
                        SocketFlags socketFlags = 0;

                        //通过延时同步接收服务器段发回的信息

                        Class_Delay.MyDelaySecond(20);     //根据相机的处理时间，适当的修改延时时间
                        string strReceive = "";
                        byte[] bytReceiveData = new byte[10240];
                        //int RecieveBytes = sckKey.Receive(bytReceiveData, bytReceiveData.Length,0);
                        int RecieveBytes = sckKey.Receive(bytReceiveData, 0, bytReceiveData.Length, socketFlags, out ERRORCODE);
                        strReceive += Encoding.ASCII.GetString(bytReceiveData, 0, RecieveBytes); //将字节数组中某个范围的字节解码为一个字符串     
                                                                                                 //保存读取字符串
                        TCPClient_Result = strReceive;
                        if (ERRORCODE != 0)
                        {

                            strReceive = "";
                            ToolInfo.Error_String = "TCP客户端超时";
                            Result = result;
                            return false;
                        }
                        //接受数据
                        else
                        {
                            if (ReceiveToList(strReceive, out result))
                            {
                                ThisEquipment.Form_Main.Receive.Add(result);
                                Result = result;
                                return true;
                            }
                            else
                            {
                                Result = result;
                                ToolInfo.Error_String = "TCP客户端接受数据无法转换未double类型";
                                return false;
                            }

                        }
                    }
                }

                catch (Exception ex)
                {
                    Basic_UI.Log.SaveError(ex);
                    sckKey.Close();

                    Result = result;
                    ToolInfo.Error_String = "TCP客户端超时";
                    return false;
                }
            }
            


        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool Send(string cmd)
        {          
            try
            {
                if ((sckKey == null))
                {
                    initial();
                    ToolInfo.Error_String = "TCP客户端不存在";
                    return false;
                }
                //建立与远程主机的连接
                if (!sckKey.Connected)
                {
                    sckKey.Dispose();
                    sckKey = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sckKey.Connect(IpEnd);
                    ToolInfo.Error_String = "TCP客户端未连接";
                    return false;
                }
                else
                {
                    sckKey.ReceiveTimeout = Model_TCPClient.Delay_Time;
                    string strSendData = cmd;
                    byte[] bytSendData = Encoding.ASCII.GetBytes(strSendData); //将指定的 String 中的所有字符编码为一个字节序列
                    sckKey.Send(bytSendData, bytSendData.Length, 0);  //使用指定的 SocketFlags，将指定字节数的数据发送到已连接的 Socket 
                    return true;
                }
            }

            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
                sckKey.Close();
                return false;
            }


        }

        /// <summary>
        /// 发送和接受数据
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public bool GetData(out List<double> Result)
        {

            //初始化输入变量
            List<double> result = new List<double>();
            try
            {
                if ((sckKey == null))
                {
                    initial();
                    Result = result;
                    ToolInfo.Error_String = "TCP客户端不存在";
                    return false;
                }
                //建立与远程主机的连接
                if (!sckKey.Connected)
                {
                    sckKey.Dispose();
                    sckKey = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sckKey.Connect(IpEnd);
                    Result = result;
                    ToolInfo.Error_String = "TCP客户端未连接";
                    return false;
                }
                else
                {
                    sckKey.ReceiveTimeout = Model_TCPClient.Delay_Time;
                    SocketError ERRORCODE = 0;
                    SocketFlags socketFlags = 0;
                    string strReceive = "";
                    byte[] bytReceiveData = new byte[10240];
                    int RecieveBytes = sckKey.Receive(bytReceiveData, 0, bytReceiveData.Length, socketFlags, out ERRORCODE);
                    strReceive += Encoding.ASCII.GetString(bytReceiveData, 0, RecieveBytes); //将字节数组中某个范围的字节解码为一个字符串     
                    //保存读取字符串
                    TCPClient_Result = strReceive;
                    if (ERRORCODE != 0)
                    {
                        ToolInfo.Error_String = "TCP客户端超时";
                        strReceive = "";
                        Result = result;
                        
                        return false;
                    }
                    //接受数据
                    else
                    {
                        if (ReceiveToList(strReceive, out result))
                        {
                            ThisEquipment.Form_Main.Receive.Add(result);
                            Result = result;
                            return true;
                        }
                        else
                        {
                            Result = result;
                            ToolInfo.Error_String = "TCP客户端接受数据无法转换未double类型";
                            return false;
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
                sckKey.Close();

                Result = result;
                ToolInfo.Error_String = "TCP客户端超时";
                return false;
            }


        }
        public void close()
        {
            try
            {
                if (sckKey != null)
                {
                    sckKey.Close();
                    sckKey.Dispose();
                }
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);

            }


        }

        #endregion

        #region 3.私有方法

        /// <summary>
        /// 接收的数据转换为double
        /// </summary>
        /// <param name="Receive"></param>
        /// <param name="Type">0.字符串 1.double</param>
        /// <returns></returns>
        private bool ReceiveToList(string Receive, out List<double> Result)
        {
            List<double> Result1 = new List<double>();
            try
            {
                string[] temp = Receive.Split(',');
                for (int i = 0; i < temp.Length; i++)
                {
                    double temp_double = Convert.ToDouble(temp[i]);
                    Result1.Add(temp_double);
                }
                Result = Result1;
                return true;
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
                Result = Result1;
                return false;
            }
        }

     

        #endregion

    }
}
