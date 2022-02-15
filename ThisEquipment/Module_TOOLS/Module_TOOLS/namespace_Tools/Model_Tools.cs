using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    [Serializable]
    public class FlowChatInfo
    {
        /// <summary>
        /// 流程ID
        /// </summary>
        [Description("流程ID")]
        public int FlowChatID = 0;

        /// <summary>
        /// 
        /// </summary>
        [Description("流程名称")]
        public string FlowChatName;

        /// <summary>
        /// 流程中所有进程
        /// </summary>
        [Description("进程集合")]
        public List<ToolInfo> ToolInfoList = new List<ToolInfo>();

        /// <summary>
        /// 流程中的全局变量
        /// </summary>
        public List<Variable> Variables = new List<Variable>();

    }
}
