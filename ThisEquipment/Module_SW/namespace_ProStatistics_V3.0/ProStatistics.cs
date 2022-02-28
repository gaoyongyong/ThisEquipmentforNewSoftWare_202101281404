
using System;
using System.Collections.Generic;
using System.Diagnostics;   //Stopwatch
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using System.Threading;
using System.IO;

namespace ProStatistics
{

    public partial class UserControl_ProStatistics : UserControl
    {


        //定义参数变量


        #region 1.公有变量
        /// <summary>
        /// Model
        /// </summary>
        public static ProStatisticsModel stc = new ProStatisticsModel();
        /// <summary>
        /// 参数
        /// </summary>
        public static Parameter para = null;


        #endregion
        #region 2.私有变量
        private Thread threadTimer = null;
        private List<string> xData;
        private List<double> yData;
        #endregion
        #region 3.构造函数
        #endregion
        #region 4.私有方法
        #endregion
        #region 5.公有方法
        #endregion
        #region 6.按钮

        #endregion


        #region Chart功能

        /// <summary>
        /// 加载ProStatistics的窗体
        /// </summary>
        public void LOAD_ProStatistics()
        {

            //string[] xValues = { "0-20", "20-30", "30-40", "40-50", "50-60", "> 60", "unknow" };
            //int[] yValues = { 5, 18, 45, 17, 2, 1, 162 };
            xData = new List<string>() { "Pass", "Fail" };
            yData = new List<double>() { 100.00, 0.00 };
            //ChartAreas,Series,Legends 基本設定-------------------------------------------------
            //Chart chart1 = new Chart();

            //chart1.ChartAreas.Add("ChartArea1"); //圖表區域集合
            //chart1.Legends.Add("Legends1"); //圖例集合說明
            //chart1.Series.Add("Series1"); //數據序列集合

            //設定 Chart-------------------------------------------------------------------------
            //Chart1.Width = 770;
            //Chart1.Height = 400;
            chart1.Dock = DockStyle.Fill;
            Title title = new Title();
            title.Text = "Pro. Statistics";//   titleStr;
            title.Alignment = ContentAlignment.MiddleCenter;
            title.Font = new System.Drawing.Font("Trebuchet MS", 14F, FontStyle.Bold);
            if (chart1.Titles.Count == 0)
                chart1.Titles.Add(title);



            //設定 ChartArea1--------------------------------------------------------------------
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            //設定 Legends-------------------------------------------------------------------------         
            chart1.Legends["Legend1"].DockedToChartArea = "ChartArea1"; //顯示在圖表內
            chart1.Legends["Legend1"].Docking = Docking.Right; //自訂顯示位置
            //背景色
            chart1.Legends["Legend1"].BackColor = Color.FromArgb(235, 235, 235);
            //斜線背景
            chart1.Legends["Legend1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            chart1.Legends["Legend1"].BorderWidth = 1;
            chart1.Legends["Legend1"].BorderColor = Color.FromArgb(200, 200, 200);

            //設定 Series1-----------------------------------------------------------------------
            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
            chart1.Series["Series1"].ChartType = SeriesChartType.Doughnut;
            chart1.Series["Series1"].Points.DataBindXY(xData, yData);
            chart1.Series["Series1"].LegendText = "#VALX:    [ #PERCENT{P1} ]"; //X軸 + 百分比
            chart1.Series["Series1"].Label = "#VALX\n#PERCENT{P1}"; //X軸 + 百分比
            chart1.Series["Series1"].LabelForeColor = Color.FromArgb(0, 90, 255); //字體顏色
            //字體設定
            chart1.Series["Series1"].Font = new System.Drawing.Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold);
            chart1.Series["Series1"].Points.FindMaxByValue().LabelForeColor = Color.Red;
            chart1.Series["Series1"].Points.FindMaxByValue().Color = Color.Red;
            chart1.Series["Series1"].Points.FindMaxByValue()["Exploded"] = "true";
            chart1.Series["Series1"].BorderColor = Color.FromArgb(255, 101, 101, 101);

            //chart1.Series["Series1"]["DoughnutRadius"] = "80"; // ChartType為Doughnut時，Set Doughnut hole size
            chart1.Series["Series1"]["PieLabelStyle"] = "Inside"; //數值顯示在圓餅內
            //chart1.Series["Series1"]["PieLabelStyle"] = "Outside"; //數值顯示在圓餅外
            chart1.Series["Series1"]["PieLineColor"] = "Black";
            //chart1.Series["Series1"]["PieLabelStyle"] = "Disabled"; //不顯示數值
            //設定圓餅效果，除 Default 外其他效果3D不適用
            //chart1.Series["Series1"]["PieDrawingStyle"] = "Default";
            //chart1.Series["Series1"]["PieDrawingStyle"] = "SoftEdge";
            chart1.Series["Series1"]["PieDrawingStyle"] = "Concave";

            //Random rnd = new Random();  //亂數產生區塊顏色
            //foreach (DataPoint point in chart1.Series["Series1"].Points)
            //{
            //    //pie 顏色
            //    point.Color = Color.FromArgb(150, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            //}
            //this.Controls.Add(chart1); 
            xData = new List<string>() { "Pass", "Fail" };
            yData = new List<double>() { 100.00, 0.00 };
            chart1.Series["Series1"].Points.DataBindXY(xData, yData);
            chart1.Series["Series1"].Points[0].Color = Color.Green;
            chart1.Series["Series1"].Points[0].LabelForeColor = Color.Black;
            chart1.Series["Series1"].Points[1].Color = Color.Red;
            chart1.Series["Series1"].Points[1].LabelForeColor = Color.Black;
        }
        #endregion

        /// <summary>
        /// 对INI文件初始化控件
        /// </summary>
        public void INIT_ProStatistics()
        {

            //初始化值
            para = new Parameter();
            modINI<Parameter>.ReadINI(ref para);
            //赋值
            stc.ProTotal = Convert.ToInt64(para.proTotal);
            stc.ProPass = Convert.ToInt64(para.proPass);
            stc.ProFail = Convert.ToInt64(para.proFail);
            timer1.Enabled = true;

            lbl_Total.Text = "Total:" + stc.ProTotal.ToString("0");
            lbl_Pass.Text = "Pass:" + stc.ProPass.ToString("0");
            lbl_Fail.Text = "Fail:" + stc.ProFail.ToString("0");
            //lbl_Total.Text = "Total:0";
            //lbl_Pass.Text = "Pass:0";
            //lbl_Fail.Text = "Fail:0";

            xData = new List<string>() { "Pass", "Fail" };
            yData = new List<double>() { 100.00, 0.00 };
            chart1.Series["Series1"].Points.DataBindXY(xData, yData);
            chart1.Series["Series1"].Points[0].Color = Color.Green;
            chart1.Series["Series1"].Points[0].LabelForeColor = Color.Black;
            chart1.Series["Series1"].Points[1].Color = Color.Red;
            chart1.Series["Series1"].Points[1].LabelForeColor = Color.Black;
            chart1.Legends["Legend1"].Docking = Docking.Right; //自訂顯示位置

        }

        /// <summary>
        ///赋值0初始化控件
        /// </summary>
        public void INIT0_ProStatistics()
        {
            //初始化值
            para = new Parameter();
            modINI<Parameter>.ReadINI(ref para);
            para.proFail = 0;
            para.proPass = 0;
            para.proTotal = 0;
            modINI<Parameter>.WriteINI(para);
            //赋值
            stc.ProTotal = 0;
            stc.ProPass = 0;
            stc.ProFail = 0;


            lbl_Total.Text = "Total:" + stc.ProTotal.ToString("0");
            lbl_Pass.Text = "Pass:" + stc.ProPass.ToString("0");
            lbl_Fail.Text = "Fail:" + stc.ProFail.ToString("0");


            xData = new List<string>() { "Pass", "Fail" };
            yData = new List<double>() { 100.00, 0.00 };
            chart1.Series["Series1"].Points.DataBindXY(xData, yData);
            chart1.Series["Series1"].Points[0].Color = Color.Green;
            chart1.Series["Series1"].Points[0].LabelForeColor = Color.Black;
            chart1.Series["Series1"].Points[1].Color = Color.Red;
            chart1.Series["Series1"].Points[1].LabelForeColor = Color.Black;
            chart1.Legends["Legend1"].Docking = Docking.Right; //自訂顯示位置


        }
        public UserControl_ProStatistics()
        {
            InitializeComponent();
            LOAD_ProStatistics();

            Service_Refresh.ProStatistics_Refresh += FUNC_AddResultWithMeasure_Refresh1;
            //Service_Refresh.Ini_Refresh += INIT_ProStatistics;

        }
        public void FUNC_AddResult_Refresh(bool Result)
        {
            if (Result)
            {
                stc.ProPass = stc.ProPass + 1;

            }
            else
            {
                stc.ProFail = stc.ProFail + 1;
            }
            stc.ProTotal = stc.ProPass + stc.ProFail;

            string Statistics_Data = stc.ProTotal.ToString() + "," + stc.ProPass.ToString() + "," + stc.ProFail.ToString();

            this.Invoke(new Action(() =>
            {
                FUNC_RefreshData(Statistics_Data);
            }));
        }

        /// <summary>
        /// 通过结果刷新计数界面
        /// </summary>
        /// <param name="Result"></param>
        public int FUNC_AddResultWithMeasure_Refresh()
        {

            if (Measure.ProMeasureSize.MeasureResult == "OK")
            {
                stc.ProPass = stc.ProPass + 1;

            }
            else
            {
                stc.ProFail = stc.ProFail + 1;
            }
            stc.ProTotal = stc.ProPass + stc.ProFail;

            string Statistics_Data = stc.ProTotal.ToString() + "," + stc.ProPass.ToString() + "," + stc.ProFail.ToString();

            this.Invoke(new Action(() =>
            {
                FUNC_RefreshData(Statistics_Data);
            }));
            return 1;
        }


        /// <summary>
        /// 通过结果刷新计数界面
        /// </summary>
        /// <param name="Result"></param>
        public void FUNC_AddResultWithMeasure_Refresh1()
        {

            if (Measure.ProMeasureSize.MeasureResult == "OK")
            {
                stc.ProPass = stc.ProPass + 1;

            }
            else
            {
                stc.ProFail = stc.ProFail + 1;
            }
            stc.ProTotal = stc.ProPass + stc.ProFail;

            string Statistics_Data = stc.ProTotal.ToString() + "," + stc.ProPass.ToString() + "," + stc.ProFail.ToString();

            this.Invoke(new Action(() =>
            {
                FUNC_RefreshData(Statistics_Data);
            }));

        }





        /// <summary>
        /// 刷新数据，集合含义分别是Total，Pass，Fail
        /// </summary>
        /// <param name="TotalPassFail"></param>
        public void FUNC_RefreshData(string TotalPassFail)
        {
            string[] Values = TotalPassFail.Split(',');
            lbl_Total.Text = "Total:" + Values[0];
            lbl_Pass.Text = "Pass:" + Values[1];
            lbl_Fail.Text = "Fail:" + Values[2];


            xData = new List<string>() { "Pass", "Fail" };
            yData[0] = Convert.ToDouble(Values[1]) / Convert.ToDouble(Values[0]);
            yData[1] = Convert.ToDouble(Values[2]) / Convert.ToDouble(Values[0]);
            chart1.Series["Series1"].Points.DataBindXY(xData, yData);
            chart1.Series["Series1"].Points[0].Color = Color.Green;
            chart1.Series["Series1"].Points[0].LabelForeColor = Color.Black;
            chart1.Series["Series1"].Points[1].Color = Color.Red;
            chart1.Series["Series1"].Points[1].LabelForeColor = Color.Black;

            stc.ProTotal = Convert.ToInt32(Values[0]);
            stc.ProPass = Convert.ToInt32(Values[1]);
            stc.ProFail = Convert.ToInt32(Values[2]);

            //写文件
            para = new Parameter();
            modINI<Parameter>.ReadINI(ref para);
            para.proTotal = stc.ProTotal;
            para.proPass = stc.ProPass;
            para.proFail = stc.ProFail;
            modINI<Parameter>.WriteINI(para);
        }

        private bool isCTStart = false;
        public void FUNC_CTStart()
        {
            if (!isCTStart)
            {
                isCTStart = true;


                stopwatch = new Stopwatch();
                stopwatch.Start();

                threadTimer = new Thread(new ThreadStart(this.timer_CT_Tick));
                threadTimer.Start();

                stc.CTStartTime = (stopwatch.ElapsedMilliseconds / 1000.0).ToString("0.0");
                timer_CT.Enabled = true;
            }

        }

        public void FUNC_CTStop()
        {
            if (isCTStart)
            {
                stopwatch.Stop();
                stc.CTEndTime = (stopwatch.ElapsedMilliseconds / 1000.0).ToString("0.0");

                threadTimer.Abort();


                stc.CT = (Convert.ToDouble(stc.CTEndTime) - Convert.ToDouble(stc.CTStartTime)).ToString();


                timer_CT.Enabled = false;


                isCTStart = false;
            }
        }

        public Stopwatch stopwatch = null;
        private void timer_CT_Tick()
        {
            while (true)
            {
                this.Invoke(new Action(() =>
                {
                    lbl_CT.Text = "CT:" + (stopwatch.ElapsedMilliseconds / 1000.0).ToString("0.0");
                }));

                Thread.Sleep(50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Whether recount the measurement data?", "Tip:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                INIT0_ProStatistics();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region //======每天早上8点清除数据====//
            //string parpath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Parameter.ini"; //获取当前parameter路径
            string parpath = modINI<Parameter>.strFileName;
            FileInfo file = new FileInfo(parpath);
            // DateTime par_dt = file.LastAccessTime;   //上次访问时间
            DateTime par_dt = file.LastWriteTime;   //上次访问时间
            DateTime Now_dt = DateTime.Now.Date;

            if (Now_dt.ToString().Contains("0:00:00"))
            {
                Now_dt = Convert.ToDateTime(Now_dt.Date.ToString().Replace("0:00:00", "08:00:00"));
            }
            else if (Now_dt.ToString().Contains("00:00:00"))
            {
                Now_dt = Convert.ToDateTime(Now_dt.Date.ToString().Replace("00:00:00", "08:00:00"));
            }
            if (Now_dt > par_dt)
            {
                para = new Parameter();
                modINI<Parameter>.ReadINI(ref para);
                para.proTotal = 0;
                para.proPass = 0;
                para.proFail = 0;
                modINI<Parameter>.WriteINI(para);

                //初始化界面程序
                INIT_ProStatistics();
            }
            #endregion
        }
    }
}
