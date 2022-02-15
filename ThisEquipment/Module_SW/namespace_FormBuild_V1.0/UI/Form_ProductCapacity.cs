using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.FormBuild.MySql;
using WinForm.FormBuild.MySql.MysqlSheet;
using WinForm.FormBuild.PublicClass;

namespace WinForm.FormBuild.UI
{
    public partial class Form_ProductCapacity : Form
    {

        /// <summary>
        /// 按钮原本的背景色
        /// </summary>
        Color butBackColor;
        /// <summary>
        /// 判断切换UPH界面和DT界面,true=UPH,flase=DT
        /// true=UPH,flase=DT
        /// </summary>
        bool bShowUPHorDTHour = true;
        /// <summary>
        /// DT列表页面
        /// </summary>
        public Form_DTHourList Form_DTHourList;
        /// <summary>
        /// DT Hours图表页面
        /// </summary>
        public Form_DTHourChart Form_DTHourChart;
        /// <summary>
        /// UPH列表页面
        /// </summary>
        public Form_UPHList Form_UPHList;
        /// <summary>
        /// UPH图表页面
        /// </summary>
        public Form_UPHChart Form_UPHChart;
        /// <summary>
        /// UPH存放数据类
        /// </summary>
        //ProductCapacity ProductCapacity;
        ///// <summary>
        ///// DT存放数据类
        ///// </summary>
        //DownTime DownTime;
        /// <summary>
        /// 数据库名称
        /// </summary>
        private string DataBaseName;

        /// <summary>
        /// 浅绿
        /// </summary>
        Color LightGreen = Color.LightGreen;

        public Form_ProductCapacity()
        {
            InitializeComponent();
            DataBaseName = CreateTableService.MySqlTool.DataBaseName;
            VisibleChanged += visibleChanged;
            Form_DTHourChart = new Form_DTHourChart();
            Form_UPHList = new Form_UPHList();
            Form_DTHourList = new Form_DTHourList();
            Form_UPHChart = new Form_UPHChart();

            FormBuildCommon.AllFormShow(panel_ShowData, new Form[]
            {
                Form_DTHourChart,
                Form_UPHList,
                Form_DTHourList,
                Form_UPHChart
            });

            radbut_listShow.Checked = true;

        }

        private void showform(Form Form)
        {
            Form_DTHourChart.Visible = false;
            Form_UPHList.Visible = false;
            Form_DTHourList.Visible = false;
            Form_UPHChart.Visible = false;
            Form.Visible = true;
        }
        private void visibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                SelectUPHData();
                SelectDtData();
                if (button_UPHStatistics.BackColor == LightGreen) button_UPHStatistics_Click(null, null);
                else if (button_DTHoursStatistics.BackColor == LightGreen) button_DTHoursStatistics_Click(null, null);

            }
        }
        private void button_UPHStatistics_Click(object sender, EventArgs e)
        {
            SetBackColor(button_UPHStatistics);
            bShowUPHorDTHour = true;
            if (radbut_MapShow.Checked)
            {
                showform(Form_UPHChart);
            }
            else
            {
                showform(Form_UPHList);
            }

        }

        private void button_DTHoursStatistics_Click(object sender, EventArgs e)
        {
            SetBackColor(button_DTHoursStatistics);
            bShowUPHorDTHour = false;
            if (radbut_MapShow.Checked)
            {
                showform(Form_DTHourChart);
            }
            else
            {
                showform(Form_DTHourList);
            }
        }

        private void radbut_listShow_CheckedChanged(object sender, EventArgs e)
        {
            if (bShowUPHorDTHour)
            {
                showform(Form_UPHList);
                SetBackColor(button_UPHStatistics);
            }
            else
            {
                showform(Form_DTHourList);
                SetBackColor(button_DTHoursStatistics);
            }
        }
        private void radbut_MapShow_CheckedChanged(object sender, EventArgs e)
        {
            if (bShowUPHorDTHour)
            {
                showform(Form_UPHChart);
                SetBackColor(button_UPHStatistics);
            }
            else
            {
                showform(Form_DTHourChart);
                SetBackColor(button_DTHoursStatistics);
            }
        }

        private void button_ShowRefresh_Click(object sender, EventArgs e)
        {
            SelectUPHData();
            SelectDtData();
        }
        /// <summary>
        /// 设置按钮背景色
        /// </summary>
        /// <param name="button"></param>
        private void SetBackColor(Button button)
        {
            button_DTHoursStatistics.BackColor = butBackColor;
            button_UPHStatistics.BackColor = butBackColor;
            button.BackColor = Color.LightGreen;
            button.Focus();
            panel_Select.Visible = true;
        }

        private void dateTimePicker_Starttime_ValueChanged(object sender, EventArgs e)
        {
            SelectUPHData();
            SelectDtData();
        }
        /// <summary>
        /// 查询UPH产能
        /// </summary>
        private void SelectUPHData()
        {
            DateTime ShowStartTime = this.dateTimePicker_Starttime.Value.Date.AddHours(8);
            DateTime ShowEndTime = ShowStartTime.AddDays(1).AddSeconds(0);
            string DayStart = ShowStartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string DayEnd = ShowEndTime.ToString("yyyy-MM-dd HH:mm:ss");
            label_TimeSolt.Text = $"Time:{DayStart} ~ {ShowStartTime.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")}";
            ProductCapacity ProductCapacity = new ProductCapacity();
            ProductCapacity.TimeSlot = FormBuildCommon.CalculateTimeSlot(0, "", ref ProductCapacity.SelectStartTimes, ref ProductCapacity.SelectEndTimes);

            string mysql = SelectMachine(DayStart, DayEnd);
            List<ProductionInfo> ProductionInfoS = SelectMachine(mysql);

            for (int i = 0; i < ProductCapacity.TimeSlot.Count; i++)
            {
                DateTime sTime = DateTime.Parse(ProductCapacity.SelectStartTimes[i]);
                DateTime eTime = DateTime.Parse(ProductCapacity.SelectEndTimes[i]);
                //查询数量
                int OK = ProductionInfoS.Where(B => B.Time >= sTime && B.Time < eTime && B.Result == 1).Count();
                int NG = ProductionInfoS.Where(B => B.Time >= sTime && B.Time < eTime && B.Result != 1).Count();
                ProductCapacity.MachineOK.Add(OK);
                ProductCapacity.MachineNG.Add(NG);
                ProductCapacity.MachineCapacity.Add(OK + NG);
                ProductCapacity.MachineYield.Add((OK + NG) == 0 ? 0 : Math.Round(((double)OK * 100 / (double)(OK + NG)), 2));
            }
            ///委托刷新界面显示
            FormBuildCommon.NotifyUPHShow(ProductCapacity);
        }
        /// <summary>
        /// 查询DT时间
        /// </summary>
        private void SelectDtData()
        {
            DateTime ShowStartTime = this.dateTimePicker_Starttime.Value.Date.AddHours(8);
            DateTime ShowEndTime = ShowStartTime.AddDays(1).AddSeconds(0);
            string DayStart = ShowStartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string DayEnd = ShowEndTime.ToString("yyyy-MM-dd HH:mm:ss");
            DownTime _DownTime = new DownTime();
            _DownTime.TimeSlot = FormBuildCommon.CalculateTimeSlot(0, "", ref _DownTime.SelectStartTimes, ref _DownTime.SelectEndTimes);
            string mysql = SelectDTsql(DayStart, DayEnd);
            List<MachineStatus> MachineStatusS = SelectDTData(mysql);
            for (int i = 0; i < _DownTime.TimeSlot.Count; i++)
            {
                DateTime sTime = DateTime.Parse(_DownTime.SelectStartTimes[i]);
                DateTime eTime = DateTime.Parse(_DownTime.SelectEndTimes[i]);
                int runTime = 0, standbyTime = 0, abnormalTime = 0, runTimeSecond = 0, standbyTimeSecond = 0, abnormalTimeSecond = 0;

                List<MachineStatus> _MachineStatuss = MachineStatusS.Where(B => B.EndTime >= sTime && B.EndTime < eTime).ToList();
                foreach (MachineStatus item in _MachineStatuss)
                {
                    int _second = 0;
                    DateTime StartTime;
                    DateTime EndTime = eTime;
                    if (sTime < item.StartTime)
                    {
                        StartTime = item.StartTime;
                    }
                    else
                    {
                        StartTime = sTime;
                    }
                    if (item.Status == 1)//运行时间
                    {
                        int minutes = FormBuildCommon.TimeDifferenceCalculation(StartTime, item.EndTime, ref _second);
                        runTime += minutes;
                        runTimeSecond += _second;
                    }
                    else if (item.Status == 2)//待机
                    {
                        int minutes = FormBuildCommon.TimeDifferenceCalculation(StartTime, item.EndTime, ref _second);
                        standbyTime += minutes;
                        standbyTimeSecond += _second;
                    }
                    else if (item.Status == 3)//异常
                    {
                        int minutes = FormBuildCommon.TimeDifferenceCalculation(StartTime, item.EndTime, ref _second);
                        abnormalTime += minutes;
                        abnormalTimeSecond += _second;
                    }
                }
                runTime += runTimeSecond / 60;
                standbyTime += standbyTimeSecond / 60;
                abnormalTime += abnormalTimeSecond / 60;
                _DownTime.RunTime.Add(runTime);
                _DownTime.WaitTime.Add(standbyTime);
                _DownTime.AlarmTime.Add(abnormalTime);


            }
            FormBuildCommon.NotifyDShow(_DownTime);

        }
        private string SelectMachine(string StartTime, string Endtime)
        {
            string mysql = "SELECT " +
                           $"{DataBaseName}.ProductionInfo.Time, " +
                           $"{DataBaseName}.ProductionInfo.Result " +
                           "FROM " +
                           $"{DataBaseName}.ProductionInfo WHERE " +
                           $"{DataBaseName}.ProductionInfo.Time BETWEEN '" + StartTime + "' AND '" + Endtime + "' " +
                           $"ORDER BY {DataBaseName}.ProductionInfo.ID DESC";
            return mysql;
        }

        private string SelectDTsql(string StartTime, string Endtime)
        {
            string mysql = "SELECT " +
                            $"{DataBaseName}.MachineStatus.StartTime, " +
                            $"{DataBaseName}.MachineStatus.Status, " +
                            $"{DataBaseName}.MachineStatus.EndTime " +
                            "FROM " +
                           $"{DataBaseName}.MachineStatus WHERE " +
                           $"{DataBaseName}.MachineStatus.ResetStatus = '1' " +
                           $"AND {DataBaseName}.MachineStatus.SetStatus = '1' " +
                           $"AND {DataBaseName}.MachineStatus.EndTime BETWEEN '" + StartTime + "' AND '" + Endtime + "' " +
                           $"ORDER BY {DataBaseName}.MachineStatus.ID DESC";
            return mysql;
        }
        /// <summary>
        /// 从数据库中查询时间段内的数量
        /// </summary>
        /// <param name="mysql"></param>
        /// <returns></returns>
        private List<ProductionInfo> SelectMachine(string mysql)
        {
            List<ProductionInfo> ProductionInfoS = new List<ProductionInfo>();
            try
            {
                DataTable dataTable = CreateTableService.MySqlTool.GetDataSet(mysql).Tables[0];

                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ProductionInfo productionInfo = new ProductionInfo()
                        {
                            Time = (!dataTable.Rows[i].IsNull("Time")) ? Convert.ToDateTime(dataTable.Rows[i]["Time"]) : DateTime.Now,
                            Result = (!dataTable.Rows[i].IsNull("Result")) ? Convert.ToInt16(dataTable.Rows[i]["Result"].ToString()) : 0,
                        };
                        ProductionInfoS.Add(productionInfo);
                    }
                }
                return ProductionInfoS;


            }
            catch
            {
                return ProductionInfoS;
            }
        }

        private List<MachineStatus> SelectDTData(string mysql)
        {
            List<MachineStatus> DownTimeS = new List<MachineStatus>();
            try
            {
                DataTable dataTable = CreateTableService.MySqlTool.GetDataSet(mysql).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        MachineStatus MachineStatus = new MachineStatus()
                        {
                            StartTime = (!dataTable.Rows[i].IsNull("StartTime")) ? Convert.ToDateTime(dataTable.Rows[i]["StartTime"]) : DateTime.Now,
                            EndTime = (!dataTable.Rows[i].IsNull("EndTime")) ? Convert.ToDateTime(dataTable.Rows[i]["EndTime"]) : DateTime.Now,
                            Status = (!dataTable.Rows[i].IsNull("Result")) ? Convert.ToInt16(dataTable.Rows[i]["Result"].ToString()) : 0,
                        };
                        DownTimeS.Add(MachineStatus);
                    }
                }
                return DownTimeS;
            }
            catch
            {
                return DownTimeS;
            }
        }

    }
}
