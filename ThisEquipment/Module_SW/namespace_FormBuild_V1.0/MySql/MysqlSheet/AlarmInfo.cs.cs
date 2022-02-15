using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.FormBuild.MySql.MysqlSheet
{
    /// <summary>
    /// 报警信息
    /// </summary>
    public class AlarmInfo
    {
        /// <summary>
        /// 主键-时间戳-yyyyMMddHHmmssfff
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Machine { get; set; }

        /// <summary>
        /// 报警代码
        /// </summary>
        public string AlarmCode { get; set; }

        /// <summary>
        /// 报警发生的位置
        /// </summary>
        public string AlarmPosition { get; set; }

        /// <summary>
        /// 报警发生的位置对应的FCM的位置
        /// </summary>
        public int FCMPosition { get; set; }

        /// <summary>
        /// 中文报警代码
        /// </summary>
        public string AlarmChineseContents { get; set; }
        /// <summary>
        /// 英文报警代码
        /// </summary>
        public string AlarmEnglishContents { get; set; }
    }
}
