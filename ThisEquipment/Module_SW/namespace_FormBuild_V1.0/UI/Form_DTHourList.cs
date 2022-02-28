using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.FormBuild.PublicClass;

namespace WinForm.FormBuild.UI
{
    public partial class Form_DTHourList : Form
    {
        private delegate void dgShowData(DownTime DownTime);
        private dgShowData _wtShowData;
        private void ONShowData(DownTime DownTime)
        {
            Invoke(_wtShowData, DownTime);
        }


        public Form_DTHourList()
        {
            InitializeComponent();
            this.dataGridView_DTDataDay.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
            this.dataGridView_DTDataDay.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            //this.dataGridView_DTDataDay.Columns[0].Width = 110;
            //this.dataGridView_DTDataDay.Columns[5].Width = 110;
            dataGridView_DTDataDay.Columns[4].DefaultCellStyle.BackColor = Color.White;

            dataGridView_DTDataDay.ReadOnly = true;
            dataGridView_DTDataDay.AllowUserToAddRows = false;
            dataGridView_DTDataDay.AllowUserToDeleteRows = false;
            dataGridView_DTDataDay.AllowUserToResizeColumns = false;
            dataGridView_DTDataDay.AllowUserToResizeRows = false;

            _wtShowData = new dgShowData(ShowData);
            FormBuildCommon.NotifyDShow += ONShowData;

        }


        private void ShowData(DownTime DownTime)
        {
            List<string> DayDTTimeSolt = new List<string>();
            List<int> DayDTRuning = new List<int>();
            List<int> DayDTAlarm = new List<int>();
            List<int> DayDTWait = new List<int>();

            List<string> NightDTTimeSolt = new List<string>();
            List<int> NightDTRuning = new List<int>();
            List<int> NightDTAlarm = new List<int>();
            List<int> NightDTWait = new List<int>();

            int DayRunTimeADD = 0;
            int DayAlarmTimeADD = 0;
            int DayWaitTimeADD = 0;
            double DayEfficency = 0;
            int NightRunTimeADD = 0;
            int NightAlarmTimeADD = 0;
            int NightWaitTimeADD = 0;
            double NightEfficency = 0;

            for (int i = 0; i < DownTime.TimeSlot.Count; i++)
            {
                if (i < 12)
                {
                    DayDTTimeSolt.Add(DownTime.TimeSlot[i]);
                    DayDTRuning.Add(DownTime.RunTime[i]);
                    DayDTAlarm.Add(DownTime.AlarmTime[i]);
                    DayDTWait.Add(DownTime.WaitTime[i]);
                }
                else
                {
                    NightDTTimeSolt.Add(DownTime.TimeSlot[i]);
                    NightDTRuning.Add(DownTime.RunTime[i]);
                    NightDTAlarm.Add(DownTime.AlarmTime[i]);
                    NightDTWait.Add(DownTime.WaitTime[i]);
                }
            }
            DayRunTimeADD = DayDTRuning.Sum();
            DayAlarmTimeADD = DayDTAlarm.Sum();
            DayWaitTimeADD = DayDTWait.Sum();
            NightRunTimeADD = NightDTRuning.Sum();
            NightAlarmTimeADD = NightDTAlarm.Sum();
            NightWaitTimeADD = NightDTWait.Sum();

            DayEfficency = Math.Round((double)DayRunTimeADD / (double)60 * 12, 2);
            NightEfficency = Math.Round((double)NightRunTimeADD / (double)60 * 12, 2);

            DayDTTimeSolt.Add("白班合计");
            DayDTRuning.Add(DayRunTimeADD);
            DayDTAlarm.Add(DayAlarmTimeADD);
            DayDTWait.Add(DayWaitTimeADD);

            NightDTTimeSolt.Add("夜班合计");
            NightDTRuning.Add(NightRunTimeADD);
            NightDTAlarm.Add(NightAlarmTimeADD);
            NightDTWait.Add(NightWaitTimeADD);
            dataGridView_DTDataDay.Rows.Clear();

            for (int i = 0; i < DayDTTimeSolt.Count; i++)
            {
                string[] rows = {
                                    DayDTTimeSolt[i],
                                    DayDTRuning[i].ToString(),
                                    DayDTAlarm[i].ToString(),
                                    DayDTWait[i].ToString(),
                                    "",
                                    NightDTTimeSolt[i].ToString(),
                                    NightDTRuning[i].ToString(),
                                    NightDTAlarm[i].ToString(),
                                    NightDTWait[i].ToString()
                                    };
                this.dataGridView_DTDataDay.Rows.Add(rows);
            }
            string[] row = {
                                    "稼动率",
                                    DayEfficency.ToString(),
                                    "",
                                    "",
                                    "",
                                    "稼动率",
                                    NightEfficency.ToString(),
                                    "",
                                    "",
                                    };
            this.dataGridView_DTDataDay.Rows.Add(row);
        }
    }
}
