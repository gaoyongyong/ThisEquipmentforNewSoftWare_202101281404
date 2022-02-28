using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.FormBuild.PublicClass
{
   public class ProductCapacity
    {
        /// <summary>
        /// 时间段，分白夜班和全天体现.用于X轴显示
        /// </summary>
        public List<string> TimeSlot = new List<string>();
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public List<string> SelectStartTimes = new List<string>();
        /// <summary>
        /// 查询结束时间
        /// </summary>
        public List<string> SelectEndTimes = new List<string>();
        /// <summary>
        /// oK数量
        /// </summary>
        public List<int> MachineOK = new List<int>();
        /// <summary>
        /// NG数量
        /// </summary>
        public List<int> MachineNG = new List<int>();
        /// <summary>
        /// 时间段产能
        /// </summary>
        public List<int> MachineCapacity = new List<int>();
        /// <summary>
        /// 良率
        /// </summary>
        public List<double> MachineYield = new List<double>();
    }
    public class DownTime
    {
        /// <summary>
        /// 时间段，分白夜班和全天体现.用于X轴显示
        /// </summary>
        public List<string> TimeSlot = new List<string>();
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public List<string> SelectStartTimes = new List<string>();
        /// <summary>
        /// 查询结束时间
        /// </summary>
        public List<string> SelectEndTimes = new List<string>();
        /// <summary>
        /// DT运行时间集合
        /// </summary>
        public  List<int> RunTime = new List<int>();
        /// <summary>
        /// DT报警时间集合
        /// </summary>
        public  List<int> AlarmTime = new List<int>();
        /// <summary>
        /// DT待机时间集合
        /// </summary>
        public  List<int> WaitTime = new List<int>();
    }

}
