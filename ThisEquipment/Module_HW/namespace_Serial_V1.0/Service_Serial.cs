using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Basic_UI;

namespace ToolSetting.UI.Serial
{
    public class Service_Serial
    {
        #region 变量
        /// <summary>
        /// Xml地址
        /// </summary>
        // private string Xml_Addr = @"D:\Program Files\ThisEquipment\Database\SwParameter\Xml\Form_Serial.xml";
        private string Xml_Addr;
        /// <summary>
        /// Model
        /// </summary>
        public Model_Serial Model_Serial;

        /// <summary>
        /// 定义串口名称
        /// </summary>
        public SerialPort port = new SerialPort();

         /// <summary>
         /// 类是否实例化成功
         /// </summary>
        public bool Result = true;

        /// <summary>
        /// 返回的字符串
        /// </summary>
        public string Serial_Result = "";

       

        #endregion

        #region 构造函数
        public Service_Serial()
        {
            Model_Serial = new Model_Serial();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="port"></param>
        /// <param name="Portname"></param>
        /// <returns></returns>
        public Boolean PortOpen()
        {
            try
            {
                port.ReadBufferSize = 40960;
                port.WriteBufferSize = 2048;
                port.ReceivedBytesThreshold = 1;
                port.Handshake = Handshake.None;

                port.BaudRate = Model_Serial.baudRate;//波特率
                port.DataBits = Model_Serial.dataBit;//数据位
                port.Parity = (Parity)Enum.Parse(typeof(Parity), Model_Serial.parity);//奇偶校验
                port.PortName = Model_Serial.portName;
               
                port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Model_Serial.parity);
                port.ParityReplace = 63;
                port.DiscardNull = false;
                port.DtrEnable = false;
                port.ReadTimeout = -1;
                port.RtsEnable = false;
                port.WriteTimeout = -1;
                port.Open();
            }
            catch(Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        internal void Close()
        {
            try
            {
                port.Close();
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
            }
        }

        /// <summary>
        /// 写Feeder的参数，并且返回Feeder反馈string
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool WriteFeeder_String(string cmd, out List<string> Result)
        {
            //返回变量
            List<string> Result1 = new List<string>();

            char[] SendBuffer = new char[1024];
            char[] ReadBuffer = new char[1024];
            try
            {
                //串口读取区初始化
                port.DiscardInBuffer();
                ReadBuffer.Initialize();
                //把String转化成Char
                //cmd = cmd + "\r\n";
                SendBuffer = Model_Serial.TrigCmd.ToCharArray();
                //写串口
                port.Write(SendBuffer, 0, SendBuffer.Length);

                Thread.Sleep(100);
               
                //读串口
                port.Read(ReadBuffer, 0, port.BytesToRead);
                //把Char转化成String
                string instring = new string(ReadBuffer);
                string instring1 = instring.Replace('\0'.ToString(), string.Empty);
                if (ReceiveToList(instring1,out Result1))
                {
                    Result = Result1;
                    return true;
                }
                else 
                {
                    Result = Result1;
                    return false;
                };
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
                Result = Result1;
                return false;
            }
        }
        /// <summary>
        /// 写Feeder的参数，并且返回Feeder反馈double
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool WriteFeeder_Double(string cmd, out List<double> Result)
        {
            //返回变量
            List<double> Result1 = new List<double>();

            char[] SendBuffer = new char[1024];
            char[] ReadBuffer = new char[1024];
            try
            {
                //串口读取区初始化
                port.DiscardInBuffer();
                ReadBuffer.Initialize();
                //把String转化成Char
                //cmd = cmd + "\r\n";
                SendBuffer = Model_Serial.TrigCmd.ToCharArray();
                //写串口
                port.Write(SendBuffer, 0, SendBuffer.Length);

                Thread.Sleep(100);
                //while(COMPORT.)
                //读串口
                port.Read(ReadBuffer, 0, port.BytesToRead);
                //把Char转化成String
                string instring = new string(ReadBuffer);
                string instring1 = instring.Replace('\0'.ToString(), string.Empty);
                //记录返回值
                Serial_Result = instring1;
                if (ReceiveToList(instring1, out Result1))
                {
                    Result = Result1;
                    return true;
                }
                else
                {
                    Result = Result1;
                    return false;
                };
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
                Result = Result1;
                return false;
            }
        }

        public bool Save_Model() 
        {
            //读取参数
            bool result  = XmlObjConvert.SerializeObject(Model_Serial, Xml_Addr);
            return result;
        }

        /// <summary>
        /// 接收的数据转换为字符
        /// </summary>
        /// <param name="Receive"></param>
        /// <param name="Type">0.字符串 1.double</param>
        /// <returns></returns>
        private bool ReceiveToList(string Receive,out List<string> Result) 
        {
            List<string> Result1 = new List<string>();
            try
            {
                string[] temp = Receive.Split(',');
                for (int i = 0; i < temp.Length; i++)
                {
                    Result1.Add(temp[i]);
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

