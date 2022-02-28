using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSetting.UI.Serial
{
    public class Model_Serial
    {
        /// <summary>
        /// 串口号
        /// </summary>
        public string portName = "COM1";
        /// <summary>
        /// 波特率
        /// </summary>
        public int baudRate = 9600;
        /// <summary>
        /// 数据位
        /// </summary>
        public int dataBit = 8;
        /// <summary>
        /// 停止位
        /// </summary>
        public string stopBit = "1";
        /// <summary>
        /// 奇偶效验位
        /// </summary>
        public string parity = "无";
        /// <summary>
        /// 触发命令
        /// </summary>
        public string TrigCmd = "T";
        /// <summary>
        /// 以十六进制形式通讯
        /// </summary>
        public bool CommHex = false;
        /// <summary>
        /// 失败重扫次数
        /// </summary>
        public int failNum = 3;
        /// <summary>
        /// 扫描到的条码
        /// </summary>
        public string ResultStr = string.Empty;
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string Name = string.Empty;
        /// <summary>
        /// 结束符
        /// </summary>
        public string endChar = string.Empty;
    }
}
