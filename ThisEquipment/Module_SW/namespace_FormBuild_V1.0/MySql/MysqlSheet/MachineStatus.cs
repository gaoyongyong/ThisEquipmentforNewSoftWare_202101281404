using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.FormBuild.MySql.MysqlSheet
{
    public class MachineStatus
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
        /// 设备当前状态，0/1/2/3
        /// 0=未连接
        /// 1=Run
        /// 2=Standby
        /// 3=异常
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 状态开始时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 状态开始标志，1=开始 0=未开始
        /// </summary>
        public int SetStatus { get; set; }
        /// <summary>
        /// 状态结束时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 状态结束标志，1=结束，0=未结束
        /// </summary>
        public int ResetStatus { get; set; }
        /// <summary>
        /// 状态结束标志，1=结束，0=未结束
        /// </summary>
        public int ResetStatus1 { get; set; }

    }
}
