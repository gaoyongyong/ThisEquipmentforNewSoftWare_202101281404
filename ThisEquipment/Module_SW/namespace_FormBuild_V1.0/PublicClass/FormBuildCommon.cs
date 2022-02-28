using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.FormBuild.MySql;

namespace WinForm.FormBuild.PublicClass
{
    public static class FormBuildCommon
    {
        #region 定义委托
        /// <summary>
        /// 委托显示
        /// </summary>
        /// <param name="txt"> 内容 </param>
        public delegate void EventNotifyUPHShow(ProductCapacity ProductCapacity);
        public static EventNotifyUPHShow NotifyUPHShow;

        public delegate void EventNotifyDTShow(DownTime DownTime);
        public static EventNotifyDTShow NotifyDShow;
        #endregion


        /// <summary>
        /// 在Panel内加载窗体,每次调用
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="Winform"></param>
        public static void PanelShow(Panel panel, Form Winform)
        {
            Winform.Visible = false;
            panel.Controls.Clear();
            Winform.TopLevel = false;
            Winform.FormBorderStyle = FormBorderStyle.None;
            Winform.Dock = System.Windows.Forms.DockStyle.Fill;//填充
            panel.Controls.Add(Winform);
            Winform.Visible = true;
            Winform.Show();
        }

        /// <summary>
        /// 在Panel内加载窗体
        /// </summary>
        /// <param name="panel"> Panel名称 </param>
        /// <param name="forms"> 窗体类型数组 </param>
        public static void AllFormShow(Panel panel, Form[] forms)
        {
            foreach (Form form in forms)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                panel.Controls.Add(form);
                form.Location = new System.Drawing.Point(0, 0);
                form.Dock = DockStyle.Fill;
                form.Show();
                form.Visible = false;
            }
        }
        /// <summary>
        /// 计算时间段合成字符串,分白夜班时间段08~20
        /// </summary>
        /// <param name="SelectWorkShiftMode">一天/白夜班</param>
        /// <param name="day">白班还是夜班</param>
        /// <param name="StartTimes">返回开始时间集合</param>
        /// <param name="EndTime">结束时间集合</param>
        /// <returns></returns>
        public static List<string> CalculateTimeSlot(int SelectWorkShiftMode, string day, ref List<string> StartTimes, ref List<string> EndTimes)
        {
            List<string> TemporaryTimeSlot = new List<string>();
            List<string> starttime = new List<string>();
            List<string> endtime = new List<string>();

            DateTime Time1;
            //string startdate = "";//日期
            //string enddate = "";//日期
            if (SelectWorkShiftMode == 0)//一天
            {
                //08~08
                Time1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 08:00:00"));
                for (int i = 0; i < 24; i++)
                {
                    int addDay1 = 0;
                    int addDay2 = 0;
                    int hour = Time1.Hour + i;
                    if (hour >= 24)
                    {
                        hour -= 24;
                        addDay1++;
                    }
                    string shour = hour.ToString("00");
                    int hour2 = Time1.Hour + i + 1;
                    if (hour2 >= 24)
                    {
                        hour2 -= 24;
                        addDay2++;
                    }
                    string shour2 = hour2.ToString("00");
                    TemporaryTimeSlot.Add($"{shour}-{shour2}");

                    string startdate = "";
                    string enddate = "";
                    string stimeslot = $"{shour}:00:00";
                    string stimeslot2 = $"{shour2}:00:00";
                    startdate = DateTime.Now.AddDays(addDay1).ToString("yyyy-MM-dd");
                    startdate = startdate + " " + stimeslot;
                    enddate = DateTime.Now.AddDays(addDay2).ToString("yyyy-MM-dd");
                    enddate = enddate + " " + stimeslot2;
                    starttime.Add(startdate);
                    endtime.Add(enddate);
                }
            }
            else//分白夜班
            {
                if (day == "白班")
                {
                    Time1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 08:00:00"));
                    for (int i = 0; i < 12; i++)
                    {
                        int addDay1 = 0;
                        int addDay2 = 0;
                        int hour = Time1.Hour + i;
                        if (hour >= 24)
                        {
                            hour -= 24;
                            addDay1++;
                        }
                        string shour = hour.ToString("00");
                        int hour2 = Time1.Hour + i + 1;
                        if (hour2 > 24)
                        {
                            hour2 -= 24;
                            addDay2++;
                        }
                        string shour2 = hour2.ToString("00");
                        TemporaryTimeSlot.Add($"{shour}-{shour2}");

                        string startdate = "";
                        string enddate = "";
                        string stimeslot = $"{shour}:00:00";
                        string stimeslot2 = $"{shour2}:00:00";
                        startdate = DateTime.Now.AddDays(addDay1).ToString("yyyy-MM-dd");
                        startdate = startdate + " " + stimeslot;
                        enddate = DateTime.Now.AddDays(addDay2).ToString("yyyy-MM-dd");
                        enddate = enddate + " " + stimeslot2;
                        starttime.Add(startdate);
                        endtime.Add(enddate);
                    }
                }
                else
                {
                    Time1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 20:00:00"));
                    for (int i = 0; i < 12; i++)
                    {
                        int addDay1 = 0;
                        int addDay2 = 0;
                        int hour = Time1.Hour + i;
                        if (hour >= 24)
                        {
                            hour -= 24;
                            addDay1++;
                        }
                        string shour = hour.ToString("00");
                        int hour2 = Time1.Hour + i + 1;
                        if (hour2 >= 24)
                        {
                            hour2 -= 24;
                            addDay2++;
                        }
                        string shour2 = hour2.ToString("00");
                        TemporaryTimeSlot.Add($"{shour}-{shour2}");

                        string startdate = "";
                        string enddate = "";
                        string stimeslot = $"{shour}:00:00";
                        string stimeslot2 = $"{shour2}:00:00";
                        startdate = DateTime.Now.AddDays(addDay1).ToString("yyyy-MM-dd");
                        startdate = startdate + " " + stimeslot;
                        enddate = DateTime.Now.AddDays(addDay2).ToString("yyyy-MM-dd");
                        enddate = enddate + " " + stimeslot2;
                        starttime.Add(startdate);
                        endtime.Add(enddate);
                    }
                }
            }
            StartTimes = starttime;
            EndTimes = endtime;
            return TemporaryTimeSlot;
        }


        /// <summary>
        /// 计算时间差，返回分钟数
        /// </summary>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <returns></returns>
        public static int TimeDifferenceCalculation(DateTime StartTime, DateTime EndTime, ref int Second)
        {
            TimeSpan time = EndTime - StartTime;
            int result = 0;
            int hour = time.Hours;
            int min = time.Minutes;
            int second = time.Seconds;
            if (hour < 0 || min < 0 || second < 0) return result;//开始时间不能小于结束时间
            result = hour * 60 + min + second / 60;
            Second = second;
            return result;
        }
        /// <summary>
        /// 计算时间差，返回分钟数+秒数
        /// </summary>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <returns></returns>
        public static string TimeDifference(DateTime StartTime, DateTime EndTime)
        {
            TimeSpan time = EndTime - StartTime;
            string result = "0:00";
            int hour = time.Hours;
            int min = time.Minutes;
            int second = time.Seconds;
            if (hour < 0 || min < 0 || second < 0) return result;//开始时间不能小于结束时间
            result = (hour * 60 + min).ToString();
            result += ":";
            result += second.ToString();
            return result;
        }


    }
}
