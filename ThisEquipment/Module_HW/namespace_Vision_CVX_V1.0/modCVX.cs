/*====================================功能==========================================
通过以太网触发CCD,并读取CCD返回数据

=====================================更新记录==========================================
修改日期：2016-03-10
更新内容：

=====================================使用方法=========================================

1.创建modCCD对象      modCCD  ccd =new modCCD();
2.初始化CCD           ccd.initial("10.0.0.11", 24691);
3.触发并读取数据      ccd.getCCDData(ref outData,0);

触发CCD字符串在readCCD函数的参数列表中修改
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


namespace VISION_CVX
{
    
   
    public class modCVXVision
    {


        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();


        /// <summary>
        /// 延时功能块
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="value"></param>


        public static void MyDelaySecond(uint ms)
        {
            uint Start = GetTickCount();
            while (Math.Abs(GetTickCount() - Start) < ms)
            {
                Application.DoEvents();
            }
        }



        static IPAddress KeyIP;
        static IPEndPoint IpEnd;
        static Socket sckKey = null;// new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        string IP_Address;
        int CCD_Port;
        public bool initial(string IP, string Port)//必须设置与CCD设置相同
        {
            IP_Address = IP;
            CCD_Port = Convert.ToInt16(Port);
            KeyIP = IPAddress.Parse(IP_Address);
            IpEnd = new IPEndPoint(KeyIP, CCD_Port);

            try
            {                
                sckKey = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);                
                sckKey.Connect(IpEnd);
                return true;
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + ae.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + exc.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            return false;
        }


        /// <summary>
        /// 根据指令读取返回值
        /// </summary>
        /// <param name="mode">触发指令</param>
        /// <param name="trigCode">触发CCD代码,可更改</param>
        /// <returns></returns>
        public string readCVXVision(string mode = "")//
        {
            try
            {
                //建立与远程主机的连接

                if (!sckKey.Connected)                   
               {
                    sckKey.Dispose();
                    sckKey = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sckKey.Connect(IpEnd);
                }
                    
                if (sckKey.Connected)
                {
                    sckKey.ReceiveTimeout = 10000;
                    string strSendData = mode ;
                    byte[] bytSendData = Encoding.ASCII.GetBytes(strSendData); //将指定的 String 中的所有字符编码为一个字节序列
                    sckKey.Send(bytSendData, bytSendData.Length, 0);  //使用指定的 SocketFlags，将指定字节数的数据发送到已连接的 Socket

                    //通过延时同步接收服务器段发回的信息
                    MyDelaySecond(300);     //根据相机的处理时间，适当的修改延时时间
                    string strReceive = "";
                    byte[] bytReceiveData = new byte[10240];
                    int RecieveBytes = sckKey.Receive(bytReceiveData, bytReceiveData.Length, 0);
                    strReceive += Encoding.ASCII.GetString(bytReceiveData, 0, RecieveBytes); //将字节数组中某个范围的字节解码为一个字符串
                    return strReceive;
                }
                else
                    MessageBox.Show("Connect Camera Fail!", "Warn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + ae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
         
            sckKey.Close();

            return "error";
        }

        
        /// <summary>
        /// 读数据
        /// </summary>
        /// <param name="outData">返回值</param>
        /// <param name="mode">发送指令</param>
        /// <returns></returns>
        public string Read_Data(string SendData)
        {

          
            string readData = "";
            try
            {
                readData = readCVXVision(SendData);
                //readData = readData.Replace("\r", "");

                return readData;
            }
            catch
            {

                return null;
            }
        }


        /// <summary>
        /// 读指定数据
        /// </summary>
        /// <param name="outData">返回值</param>
        /// <param name="mode">发送指令</param>
        /// <returns></returns>
        public string Read_CCD()
        {

            string SendData = "T1\r\n";
            string readData = "";
            try
            {
                readData = Read_Data(SendData);
                if (readData.Split(',')[0] == "ER")
                {
                    return "ER";
                }
                readData = readData.Replace("\r", ";");

                return readData.Split(';')[1];
            }
            catch
            {

                return "ER";
            }
        }
        /// <summary>
        /// 切产品配方号
        /// </summary>
        /// <param name="outData">返回值</param>
        /// <param name="mode">发送指令</param>
        /// <returns></returns>
        public bool ChangeCCD_Recipe(string mode = "")
        {

            string SendData = "EXW," + mode + "\r\n";
            string readData = "";
            try
            {
                readData = Read_Data(SendData);
                readData = readData.Replace("\r\n", "");
                if (readData == "EXW")
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {

                return false;
            }
        }


        /// <summary>
        /// 切换项目号
        /// </summary>
        /// <param name="outData">返回值</param>
        /// <param name="mode">发送指令</param>
        /// <returns></returns>
        public bool ChangeCCD_Poject(string mode = "")
        {

            string SendData = "PW,1," + mode + "\r\n";
            string readData = "";
            try
            {
                readData = Read_Data(SendData);
                readData = readData.Replace("\r", "");
                //
                if (readData.Split(',')[0] == "PW")
                {
                    return true;
                }
                else
                {
                    return false;
                }



                
            }
            catch
            {

                return false;
            }
        }
        public void closeCCD()
        {
            try
            {
                sckKey.Close();
                sckKey.Dispose();

            }
            catch (ArgumentException ae)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + ae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Connect Camera Fail!\r\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

        }
    




    }
}
