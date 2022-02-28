using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSetting.UI.TCPClient
{
    public class Model_TCPClient
    {
        
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP = "127.0.0.1";
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port = 502;

        /// <summary>
        /// 通讯延时时间 1ms
        /// </summary>
        public int Delay_Time = 200;

    }
}
