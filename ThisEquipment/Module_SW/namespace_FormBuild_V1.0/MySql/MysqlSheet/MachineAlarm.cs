using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.FormBuild.MySql.MysqlSheet
{
    public class MachineAlarm
    {
        /// <summary>
        /// 主键-时间戳-机器号+yyyyMMddHHmmssfff
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 机器号
        /// </summary>
        public string MacineID { get; set; }
        /// <summary>
        /// 报警代码
        /// </summary>
        public string AlarmCode { get; set; }
        /// <summary>
        /// 报警开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 报警开始时间的数据是否已经上传，0未上传，1已经上传
        /// </summary>
        public int IsUploadSet { get; set; }
        /// <summary>
        /// 报警结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 报警结束时间的数据是否已经上传，0未上传，1已经上传
        /// </summary>
        public int IsUploadReset { get; set; }
        /// <summary>
        /// 报警内容
        /// </summary>
        public string AlarmContent { get; set; }
        /// <summary>
        /// 报警内容
        /// </summary>
        public string AlarmContent1 { get; set; }
    }
}
