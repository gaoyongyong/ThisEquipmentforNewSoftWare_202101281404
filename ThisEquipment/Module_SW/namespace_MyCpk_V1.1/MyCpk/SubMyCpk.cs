using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MyCpk
{
    public partial class SubMyCpk : Form
    {
        //解决控件批量更新时带来的闪烁
        //protected override CreateParams CreateParams { get { CreateParams cp = base.CreateParams; cp.ExStyle |= 0x02000000; return cp; } }

        //禁用窗体的关闭按钮
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public SubMyCpk()
        {
            InitializeComponent();
           
            chart_cpkNorm2.MouseDoubleClick += DoubleCheck;
            chart_Rowdata.MouseDoubleClick += DoubleCheck;
            chart_cpkNorm1.MouseDoubleClick += DoubleCheck;
            listView_Rowdata.MouseDoubleClick += DoubleCheck;
            dataGridView1.MouseDoubleClick += DoubleCheck;
            dataGridView2.MouseDoubleClick += DoubleCheck;
        }

        //计算方法实例化
        //modMyCpk modmycpk = new modMyCpk();
        //=====Listview 定义=====//
        modListView listview = new modListView();
        ListViewItem LV_DataItem = new ListViewItem();
        //Panel 自适应问题
        modPanelAutoSize PanelAutoSize1 = new modPanelAutoSize();
        modPanelAutoSize PanelAutoSize2 = new modPanelAutoSize();

        bool isenable = false;
        private void SubMyCpk_Load(object sender, EventArgs e)
        {
            PanelAutoSize1.controllInitializeSize(panel_NormDist);
            PanelAutoSize2.controllInitializeSize(panel_Cpk);

            //listView_Rowdata.Clear();
            //listview.InitLV(listView_Rowdata);//初始化 表头    

            panel_NormDist.Dock = DockStyle.Fill;
            panel_NormDist.BringToFront();
            isenable = true;
        }
        
        private void SubMyCpk_SizeChanged(object sender, EventArgs e)
        {
            if (!isenable)
            {
                return;
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                panel_Cpk.Dock = DockStyle.Fill;
                panel_Cpk.BringToFront();
                PanelAutoSize2.controlAutoSize(panel_Cpk);
            }
            else
            {
                panel_NormDist.Dock = DockStyle.Fill;
                panel_NormDist.BringToFront();
                PanelAutoSize1.controlAutoSize(panel_NormDist);
            }
        }

        private void chart_cpkNorm2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
     
        }

        /// <summary>
        /// 数据加载
        /// </summary>
        /// <param name="TDS">输入数据按照List<SubMyCpk.MyRowsData>格式</param>
        public void FormShowData(List<MyRowsData> TDS,string Name)
        {
            SubMyCpk_Load(null, null);

            listView_Rowdata.Clear();
            listview.InitLV(listView_Rowdata);//初始化 表头    

            #region //=====1、Cpk计算=====//
            double T_NormaL = TDS[0].Normalvalue;
            double T_USL = TDS[0].USL;
            double T_LSL = TDS[0].LSL;
            double T_Total = TDS.Count;
            double T_Max = MyMax(TDS);
            double T_Min = MyMin(TDS);
            double T_avg = Convert.ToDouble(MyAvg(TDS).ToString("0.0000"));
            double T_stdev = Convert.ToDouble(MySTDEV(TDS).ToString("0.0000"));
            double T_cpu = 0, T_cpl = 0, T_cp = 0, T_cpk = 0, T_ca = 0;
            MyCpk(TDS, ref T_cpu, ref T_cpl, ref T_cp, ref T_cpk, ref T_ca);

            DataGridViewRefash1(dataGridView1, dataGridView2, T_NormaL, T_USL, T_LSL, T_Total, T_avg, T_Max, T_Min, T_stdev, T_cpu, T_cpl, T_cp, T_cpk, T_ca);
            #endregion

            #region //======2、画图=====//

            int Steps = 64;
            double[] Norm_X_data = new double[Steps];
            double[] Norm_Y_data = new double[Steps];

            MyNormDist(TDS, ref Norm_X_data, ref Norm_Y_data, Steps);

            int Bins = 40;
            double[] Pop_X_data = new double[Bins];
            double[] Pop_Y_data = new double[Bins];
            MyPopDensity(TDS, ref Pop_X_data, ref Pop_Y_data, Bins);

            double[] USL_X_data = { TDS[0].USL, TDS[0].USL };
            double[] USL_Y_data = { 0, 1 };

            double[] LSL_X_data = { TDS[0].LSL, TDS[0].LSL };
            double[] LSL_Y_data = { 0, 1 };

            double[] Normal_X_data = { TDS[0].Normalvalue, TDS[0].Normalvalue };
            double[] Normal_Y_data = { 0, 1 };

            Chart_Sline1(chart_cpkNorm1, Norm_X_data, Norm_Y_data, Pop_X_data, Pop_Y_data, USL_X_data, USL_Y_data, LSL_X_data, LSL_Y_data, Normal_X_data, Normal_Y_data, Name);

            Chart_Sline1(chart_cpkNorm2, Norm_X_data, Norm_Y_data, Pop_X_data, Pop_Y_data, USL_X_data, USL_Y_data, LSL_X_data, LSL_Y_data, Normal_X_data, Normal_Y_data, Name);

            double[] R_xdata = new double[TDS.Count];
            double[] Nomal_data = new double[TDS.Count];
            double[] Upper_data = new double[TDS.Count];
            double[] Down_data = new double[TDS.Count];
            double[] Real_data = new double[TDS.Count];

            for (int i = 0; i < TDS.Count; i++)
            {

                R_xdata[i] = i;
                Nomal_data[i] = TDS[i].Normalvalue;

                Upper_data[i] = TDS[i].USL;
                Down_data[i] = TDS[i].LSL;
                Real_data[i] = TDS[i].Realvalue;
            }

            Chart_line2(chart_Rowdata, R_xdata, Nomal_data, Upper_data, Down_data, Real_data, Name);

            for (int i = 0; i < TDS.Count; i++)
            {
               
                LV_DataItem = new ListViewItem();
                LV_DataItem.Text = R_xdata[i].ToString();   // "C3"; List第一个必须用Text=一个值，不能用Add功能
                LV_DataItem.SubItems.Add(Real_data[i].ToString("0.000"));
               
                listView_Rowdata.Items.Add(LV_DataItem);
                //SetlistViewText(listView_Rowdata, LV_DataItem);
            }
            #endregion
        }

        #region //================ 所有方法 ================//

        #region//=====CPK 计算公式=====//

     

        #region //====CPK计算使用公式====//
        /// <summary>
        /// 求和Sum
        /// </summary>
        /// <param name="Testdata">输入数据</param>
        /// <returns></returns>
        private double MySum(List<MyRowsData> Testdata)
        {
            double sum = 0;
            try
            {
                for (int i = 0; i < Testdata.Count; i++)
                {
                    sum += Testdata[i].Realvalue;
                }
            }
            catch
            {
                sum = -1;
            }
            return sum;
        }

        /// <summary>
        /// 最大值 Max
        /// </summary>
        /// <param name="Testdata">输入数据</param>
        /// <returns></returns>
        private double MyMax(List<MyRowsData> Testdata)
        {
            double max;
            try
            {
                double[] mymax = new double[Testdata.Count];

                for (int i = 0; i < Testdata.Count; i++)
                {
                    mymax[i] = Testdata[i].Realvalue;
                }
                max = mymax.Max();
            }
            catch
            {
                max = -1;
            }
            return max;
        }

        /// <summary>
        /// 最大值 Min
        /// </summary>
        /// <param name="Testdata">输入数据</param>
        /// <returns></returns>
        private double MyMin(List<MyRowsData> Testdata)
        {
            double min;
            try
            {
                double[] mymin = new double[Testdata.Count];

                for (int i = 0; i < Testdata.Count; i++)
                {
                    mymin[i] = Testdata[i].Realvalue;
                }
                min = mymin.Min();
            }
            catch
            {
                min = -1;
            }
            return min;
        }

        /// <summary>
        /// 平均值 Average
        /// </summary>
        /// <param name="Testdata">输入数据</param>
        /// <returns></returns>
        private double MyAvg(List<MyRowsData> Testdata)
        {
            double avg;
            try
            {
                avg = MySum(Testdata) / Testdata.Count;
            }
            catch
            {
                avg = -1;
            }
            return avg;
        }

        /// <summary>
        /// 标准偏差 STDEV
        /// </summary>
        /// <param name="Testdata">输入数据</param>
        /// <returns></returns>
        private double MySTDEV(List<MyRowsData> Testdata)
        {
            double stdev;
            try
            {
                double avg = MyAvg(Testdata);

                double delta_sum = 0;
                for (int i = 0; i < Testdata.Count; i++)
                {
                    delta_sum += ((Testdata[i].Realvalue - avg) * (Testdata[i].Realvalue - avg));
                }

                stdev = Math.Sqrt(delta_sum / (Testdata.Count - 1));
            }
            catch
            {
                stdev = -1;
            }
            return stdev;
        }

        /// <summary>
        /// CpK计算
        /// </summary>
        /// <param name="Testdata">输入数据</param>
        /// <param name="CpU">Cpu</param>
        /// <param name="CpL">Cpl</param>
        /// <param name="Cp">Cp</param>
        /// <param name="CpK">Cpk</param>
        /// <param name="Ca">Ca</param>
        private void MyCpk(List<MyRowsData> Testdata, ref double CpU, ref double CpL, ref double Cp, ref double CpK, ref double Ca)
        {
            try
            {
                double avg = MyAvg(Testdata);
                double USL = Testdata[0].USL;
                double LSL = Testdata[0].LSL;
                double sigma = MySTDEV(Testdata);

                CpU = (USL - avg) / (3 * sigma);
                CpL = (avg - LSL) / (3 * sigma);
                Cp = (USL - LSL) / (6 * sigma);

                if (CpU < CpL)
                {
                    CpK = CpU;
                }
                else
                {
                    CpK = CpL;
                }
                Ca = (avg - Testdata[0].Normalvalue) / ((USL - LSL) / 2);
            }
            catch
            {
            }
        }
        #endregion


        #region//====CPK 标准正态分布曲线图数据====//

        /// <summary>
        /// 标准正态分布曲线
        /// </summary>
        /// <param name="Testdata">输入数据</param>
        /// <param name="Steps">分多少段 默认64</param>
        /// <param name="Norm_Xdata">输出X轴数据</param>
        /// <param name="Norm_Ydata">输出Y轴数据</param>
        private void MyNormDist(List<MyRowsData> Testdata, ref double[] Norm_Xdata, ref double[] Norm_Ydata, int Steps = 64)
        {
            try
            {
                double S_Span = 0.15;  //扩大范围
                                       //int Steps = 64;        //将X轴分多少段
                double S_Max = Testdata[0].USL + (Testdata[0].USL - Testdata[0].Normalvalue) * S_Span; //扩大后的上限
                double S_Min = Testdata[0].LSL - (Testdata[0].Normalvalue - Testdata[0].LSL) * S_Span; //扩大后的下限
                double Div = (S_Max - S_Min) / Steps;      //每一段间距

                double[] Y_middle = new double[Steps];
                double avg = MyAvg(Testdata), stdev = MySTDEV(Testdata);

                for (int i = 0; i < Steps; i++)
                {
                    Norm_Xdata[i] = S_Min + Div * i;

                    Y_middle[i] = NormDistFalse1(Norm_Xdata[i], avg, stdev);
                }

                double Norm_YMax = Y_middle.Max();
                for (int i = 0; i < Steps; i++)
                {
                    Norm_Ydata[i] = Y_middle[i] / Norm_YMax;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 返回概率密度函数
        /// </summary>
        /// <param name="x">需要计算其分布的数值</param>
        /// <param name="mean">分布的算术平均值</param>
        /// <param name="standard_dev">分布的标准偏差</param>
        /// <returns></returns>
        private double NormDistFalse1(double x, double mean, double standard_dev)
        {
            double PowOfE = -(Math.Pow(x - mean, 2) / (2.0 * Math.Pow(standard_dev, 2)));
            return (1 / (Math.Sqrt(2.0 * Math.PI) * standard_dev)) * Math.Pow(Math.E, PowOfE);
        }

        #region //====正态分布NormDist函数  参考函数====//
        /// <summary>
        /// 返回指定平均值和标准偏差的正态分布函数 。。
        /// </summary>
        /// <param name="x">需要计算其分布的数值</param>
        /// <param name="mean">分布的算术平均值</param>
        /// <param name="standard_dev">分布的标准偏差</param>
        /// <param name="cumulative"> 指明函数的形式如果 cumulative 为 TRUE，函数 NORMDIST 返回累积分布函数；如果为 FALSE，返回概率密度函数</param>
        /// <returns></returns>
        private double NormDist(double x, double mean, double standard_dev, bool cumulative)
        {
            if (cumulative)
                return NormDistTrue(x, mean, standard_dev);
            else
                return NormDistFalse(x, mean, standard_dev);
        }
        /// <summary>
        /// 返回累积分布函数
        /// </summary>
        /// <param name="x">需要计算其分布的数值</param>
        /// <param name="mean">分布的算术平均值</param>
        /// <param name="standard_dev">分布的标准偏差</param>
        /// <returns></returns>
        private double NormDistTrue(double x, double mean, double standard_dev)
        {
            var x2 = (x - mean) / standard_dev;
            if (x2 == 0)
            {
                return 0.5;
            }
            else
            {
                var oor2pi = 1 / Math.Sqrt(2.0 * Math.PI);
                var t = 1 / (1.0 + 0.2316419 * Math.Abs(x2));
                t = t * oor2pi * Math.Exp(-0.5 * x2 * x2)
                    * (0.31938153 + t
                    * (-0.356563782 + t
                    * (1.781477937 + t
                    * (-1.821255978 + t
                    * 1.330274429))));

                if (x2 > 0)
                {
                    return 1.0 - t;
                }
                else
                {
                    return t;
                }
            }
        }
        /// <summary>
        /// 返回概率密度函数
        /// </summary>
        /// <param name="x">需要计算其分布的数值</param>
        /// <param name="mean">分布的算术平均值</param>
        /// <param name="standard_dev">分布的标准偏差</param>
        /// <returns></returns>
        private double NormDistFalse(double x, double mean, double standard_dev)
        {
            double PowOfE = -(Math.Pow(x - mean, 2) / (2.0 * Math.Pow(standard_dev, 2)));
            return (1 / (Math.Sqrt(2.0 * Math.PI) * standard_dev)) * Math.Pow(Math.E, PowOfE);
        }
        #endregion

        #endregion

        #region//====CPK 实际数据正态分布直方图数据====//

        /// <summary>
        /// 实际数据正态分布直方图
        /// </summary>
        /// <param name="Testdata">输入数据</param>
        /// <param name="Pop_Xdata">输出X轴数据 默认64</param>
        /// <param name="Pop_Ydata">输出Y轴数据</param>
        /// <param name="Bins">分多少段 默认40</param>
        private void MyPopDensity(List<MyRowsData> Testdata, ref double[] Pop_Xdata, ref double[] Pop_Ydata, int Bins = 40)
        {
            try
            {
                double S_Span = 0.15;  //扩大范围
                                       //int Steps = 64;        //将X轴分多少段
                double S_Max = Testdata[0].USL + (Testdata[0].USL - Testdata[0].Normalvalue) * S_Span; //扩大后的上限
                double S_Min = Testdata[0].LSL - (Testdata[0].Normalvalue - Testdata[0].LSL) * S_Span; //扩大后的下限

                double BinWidth = (S_Max - S_Min) / Bins;      //每一段间距
                double[] Bin = new double[Bins];

                for (int i = 0; i < Bins; i++)
                {
                    Bin[i] = S_Min + i * BinWidth;
                    Pop_Xdata[i] = Bin[i] - BinWidth / 2;
                }

                double[] Freq = new double[Bins + 2];
                for (int i = 0; i < Bins + 2; i++)
                {
                    if (i == 0)
                    {
                        for (int j = 0; j < Testdata.Count; j++)
                        {
                            if (Testdata[j].Realvalue < Bin[0])
                            {
                                Freq[0]++;
                            }
                        }
                    }
                    else if (i == Bins + 1)
                    {
                        for (int j = 0; j < Testdata.Count; j++)
                        {
                            if (Bin[Bins - 1] <= Testdata[j].Realvalue)
                            {
                                Freq[Bins + 1]++;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < Testdata.Count; j++)
                        {
                            if (Bin[i - 1] <= Testdata[j].Realvalue && Testdata[j].Realvalue < Bin[i])
                            {
                                Freq[i + 1]++;
                            }
                        }
                    }
                }

                double[] Pt_avg = new double[Bins];
                for (int i = 0; i < Bins; i++)
                {
                    if (i == 0)
                    {
                        Pt_avg[i] = (Freq[i] + Freq[i + 1]) / 2;
                    }
                    else
                    {
                        Pt_avg[i] = (Freq[i - 1] + Freq[i] + Freq[i + 1]) / 3;
                    }
                }

                double Pop_Max = Pt_avg.Max() * 1.1;
                for (int i = 0; i < Bins; i++)
                {
                    Pop_Ydata[i] = Pt_avg[i] / Pop_Max;
                }
            }
            catch
            {
            }
        }
        #endregion

        #endregion

        #region//=====DataGridView=====//
        /// <summary>
        /// DataGridView 赋值
        /// </summary>
        /// <param name="dgv1">DataGridView1</param>
        /// <param name="dgv2">DataGridView2</param>
        /// <param name="Target">Normal</param>
        /// <param name="Up">USL</param>
        /// <param name="UL">LSL</param>
        /// <param name="Total">样本总数</param>
        /// <param name="Avg">平均值</param>
        /// <param name="Max">最大值</param>
        /// <param name="Min">最小值</param>
        /// <param name="STDEV">标准差</param>
        /// <param name="CpU">cpu</param>
        /// <param name="CpL">cpl</param>
        /// <param name="Cp">cp</param>
        /// <param name="CpK">cpk</param>
        private void DataGridViewRefash1(DataGridView dgv1, DataGridView dgv2, double Target, double Up, double UL, double Total,
         double Avg, double Max, double Min, double STDEV, double CpU, double CpL, double Cp, double CpK, double Ca)
        {

            #region//=====dt1=====//
            DataTable dt1 = new DataTable();

            dt1.Columns.Add("样本总数"); //表头
            dt1.Columns.Add("子组大小"); //表头
            dt1.Columns.Add("平均值"); //表头
            dt1.Columns.Add("最大值"); //表头
            dt1.Columns.Add("最小值"); //表头

            dt1.Rows.Add(Total, "1", Avg.ToString("0.0000"), Max.ToString("0.0000"), Min.ToString("0.0000"));  //内容  
            dt1.Rows.Add("+3Sigma", "-3Sigma", "上规格", "目标值", "下规格");  //内容
            dt1.Rows.Add("", "", Up, Target, UL);  //内容  (STDEV*3).ToString("0.000")

            dgv1.DataSource = dt1;

            dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标头 集中
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; //自适应
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //宽度方向填充
            dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; //表头背景颜色
            dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;       //表头字体颜色
            dgv1.EnableHeadersVisualStyles = false; //如果想让标题的边框线和颜色生效还需要如下设置
            dgv1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable; //不允许排序
            dgv1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable; //不允许排序
            dgv1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable; //不允许排序
            dgv1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable; //不允许排序
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //文本剧中显示
            dgv1.RowHeadersVisible = false;  //去除左边选择框
            dgv1.AllowUserToAddRows = false;

            for (int i = 0; i < dgv1.Columns.Count; i++)
            {
                dgv1.Rows[1].Cells[i].Style.ForeColor = Color.Blue; //指定单元格 字体颜色变化

                dgv1.Rows[1].Cells[i].Style.BackColor = Color.LightGray; //指定单元格 背景颜色变化
            }

            dgv1.ClearSelection(); //取消默认选择单元格
            #endregion

            #region//=====dt2=====//
            DataTable dt2 = new DataTable();

            dt2.Columns.Add(""); //表头
            dt2.Columns.Add("STDEV"); //表头
            dt2.Columns.Add("CPK"); //表头
            dt2.Columns.Add("CP"); //表头
            dt2.Columns.Add("CPL"); //表头
            dt2.Columns.Add("CPU"); //表头
            dt2.Columns.Add("PPM<LSL"); //表头
            dt2.Columns.Add("PPM>USL"); //表头
            dt2.Columns.Add("PPM Total"); //表头
            dt2.Columns.Add("CA"); //表头

            dt2.Rows.Add("组内", 0, "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", Ca.ToString("0.0000"));  //内容
            dt2.Rows.Add("整组", STDEV.ToString("0.0000"), CpK.ToString("0.0000"), Cp.ToString("0.0000"), CpL.ToString("0.0000"), CpU.ToString("0.0000"), "", "", "", "");  //内容
            dt2.Rows.Add("实测", "", "", "", "", "", "", "", "", "");  //内容

            dgv2.DataSource = dt2;

            dgv2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标头 集中
            dgv2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; //自适应
                                                                                                        //dgv.BackgroundColor = Color.Gray; //背景颜色
            dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //宽度方向填充
            dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; //表头背景颜色
            dgv2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;       //表头字体颜色
            dgv2.EnableHeadersVisualStyles = false; //如果想让标题的边框线和颜色生效还需要如下设置
            dgv2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable; //不允许排序
            dgv2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable; //不允许排序
            dgv2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable; //不允许排序
            dgv2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable; //不允许排序
            dgv2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //文本剧中显示
            dgv2.RowHeadersVisible = false;  //去除左边选择框
            dgv2.AllowUserToAddRows = false;

            dgv2.Rows[0].Cells[0].Style.ForeColor = Color.Blue; //指定单元格 字体颜色变化              
            dgv2.Rows[0].Cells[0].Style.BackColor = Color.LightGray; //指定单元格 背景颜色变化
            dgv2.Rows[1].Cells[0].Style.ForeColor = Color.Blue; //指定单元格 字体颜色变化              
            dgv2.Rows[1].Cells[0].Style.BackColor = Color.LightGray; //指定单元格 背景颜色变化
            dgv2.Rows[2].Cells[0].Style.ForeColor = Color.Blue; //指定单元格 字体颜色变化              
            dgv2.Rows[2].Cells[0].Style.BackColor = Color.LightGray; //指定单元格 背景颜色变化

            if (CpK >= 1.33)
            {
                //dgv2.Rows[1].Cells[0].Style.ForeColor = Color.Blue; //指定单元格 字体颜色变化              
                dgv2.Rows[1].Cells[2].Style.BackColor = Color.Green; //指定单元格 背景颜色变化
            }
            else
            {
                dgv2.Rows[1].Cells[2].Style.BackColor = Color.Red; //指定单元格 背景颜色变化
            }
            dgv2.ClearSelection(); //取消默认选择单元格
            #endregion

        }
        #endregion

        #region //=====画曲线=====//

        /// <summary>
        /// CPK 画正态分布曲线图
        /// </summary>
        /// <param name="Chart1">Chart</param>
        /// <param name="Norm_X_Data">标准正态分布 X轴</param>
        /// <param name="Norm_Y_Data">标准正态分布 Y轴</param>
        /// <param name="Pop_X_Data">实际正态分布直方图 X轴</param>
        /// <param name="Pop_Y_Data">实际正态分布直方图 Y轴</param>
        /// <param name="USL_X_Data">上限 X轴</param>
        /// <param name="USL_Y_Data">上限 Y轴</param>
        /// <param name="LSL_X_Data">下限 X轴</param>
        /// <param name="LSL_Y_Data">下限 Y轴</param>
        /// <param name="Normal_X_Data">标准值 X轴</param>
        /// <param name="Normal_Y_Data">标准值 Y轴</param>
        /// <param name="title"></param>
        private void Chart_Sline1(Chart Chart1, double[] Norm_X_Data, double[] Norm_Y_Data, double[] Pop_X_Data, double[] Pop_Y_Data,
           double[] USL_X_Data, double[] USL_Y_Data, double[] LSL_X_Data, double[] LSL_Y_Data, double[] Normal_X_Data, double[] Normal_Y_Data, string title)
        {
            if (Norm_X_Data.Length > 0 && Pop_X_Data.Length > 0)
            {
                #region //=======折线图=======//
                Chart1.ChartAreas.Clear();                          //图表区
                Chart1.Titles.Clear();                              //图表标题
                Chart1.Series.Clear();                              //图表序列
                Chart1.Legends.Clear();                             //图表图例
                Chart1.BackColor = Color.Transparent;               //chart控件 背景颜色

                //图表区 new
                Chart1.ChartAreas.Add(new ChartArea("chartarea"));
                Chart1.ChartAreas["chartarea"].BackColor = Color.Transparent;                              //chart区域 背景颜色
                Chart1.ChartAreas["chartarea"].AxisX.Enabled = AxisEnabled.True;                           //chart区域 X轴 线是否显示
                Chart1.ChartAreas["chartarea"].AxisY.Enabled = AxisEnabled.True;                           //chart区域 Y轴 线是否显示
                Chart1.ChartAreas["chartarea"].AxisX.MajorGrid.LineColor = Color.Transparent;              //chart区域 X轴 线颜色
                Chart1.ChartAreas["chartarea"].AxisY.MajorGrid.LineColor = Color.Transparent;              //chart区域 Y轴 线颜色
                Chart1.ChartAreas["chartarea"].AxisX.MajorTickMark.LineColor = Color.Transparent;          //chart区域 X轴刻度 线颜色
                Chart1.ChartAreas["chartarea"].AxisY.MajorTickMark.LineColor = Color.Transparent;          //chart区域 Y轴刻度 线颜色
                Chart1.ChartAreas["chartarea"].AxisX.LineColor = Color.Black;                              //chart区域 X轴主轴 线颜色
                Chart1.ChartAreas["chartarea"].AxisY.LineColor = Color.Black;                              //chart区域 Y轴主轴 线颜色
                Chart1.ChartAreas["chartarea"].AxisX.LabelStyle.ForeColor = Color.Black;                   //chart区域 X轴刻度数值 颜色
                Chart1.ChartAreas["chartarea"].AxisY.LabelStyle.ForeColor = Color.Black;                   //chart区域 Y轴刻度数值 颜色
                Chart1.ChartAreas["chartarea"].AxisX.IsMarginVisible = false;                              //数据过原点
                Chart1.ChartAreas["chartarea"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;    //设定x轴的间隔是可变的
                Chart1.ChartAreas["chartarea"].AxisX.LabelStyle.Angle = 0;                                 //让X坐标名称 垂直显示

                ////图表标题 new
                Chart1.Titles.Add(title);
                Chart1.Titles[0].Text = title;                                                         //chart区域 Titles抬头
                Chart1.Titles[0].Font = new Font("宋体", 12);                                          //title 字体设置
                Chart1.Titles[0].ForeColor = Color.Black;                                              //title 字体颜色

                //图表序列 标准正态分布图
                Chart1.Series.Add("data1");
                Chart1.Series["data1"].ChartType = SeriesChartType.Spline;                             //图标类型  曲线图
                Chart1.Series["data1"].IsValueShownAsLabel = true;                                     //标记点上显示数据
                Chart1.Series["data1"].Color = Color.Red;                                              //线条颜色
                Chart1.Series["data1"].BorderWidth = 1;                                                //线条粗细
                Chart1.Series["data1"].IsValueShownAsLabel = false;                                    //不显示数据
                Chart1.Series["data1"].Points.DataBindXY(Norm_X_Data, Norm_Y_Data);                    //加载数据

                //图表序列 正态分布图直方图
                Chart1.Series.Add("data2");
                Chart1.Series["data2"].ChartType = SeriesChartType.Column;                             //图标类型  曲线图
                Chart1.Series["data2"].IsValueShownAsLabel = true;                                     //标记点上显示数据
                Chart1.Series["data2"].Color = Color.Green;                                            //线条颜色
                Chart1.Series["data2"].BorderWidth = 1;                                                //线条粗细
                Chart1.Series["data2"].IsValueShownAsLabel = false;                                    //不显示数据
                Chart1.Series["data2"].Points.DataBindXY(Pop_X_Data, Pop_Y_Data);                      //加载数据

                //图表序列 正态分布图直方图顶点连线
                Chart1.Series.Add("data3");
                Chart1.Series["data3"].ChartType = SeriesChartType.Spline;                             //图标类型  曲线图
                Chart1.Series["data3"].IsValueShownAsLabel = true;                                     //标记点上显示数据
                Chart1.Series["data3"].Color = Color.Blue;                                             //线条颜色
                Chart1.Series["data3"].BorderWidth = 1;                                                //线条粗细
                Chart1.Series["data3"].IsValueShownAsLabel = false;                                    //不显示数据
                Chart1.Series["data3"].Points.DataBindXY(Pop_X_Data, Pop_Y_Data);                      //加载数据

                //图表序列 上限
                Chart1.Series.Add("data4");
                Chart1.Series["data4"].ChartType = SeriesChartType.Spline;                             //图标类型  曲线图
                Chart1.Series["data4"].IsValueShownAsLabel = true;                                     //标记点上显示数据
                Chart1.Series["data4"].Color = Color.Red;                                              //线条颜色
                Chart1.Series["data4"].BorderWidth = 1;                                                //线条粗细
                Chart1.Series["data4"].IsValueShownAsLabel = false;                                    //不显示数据
                Chart1.Series["data4"].Points.DataBindXY(USL_X_Data, USL_Y_Data);                       //加载数据

                //图表序列 下限
                Chart1.Series.Add("data5");
                Chart1.Series["data5"].ChartType = SeriesChartType.Spline;                             //图标类型  曲线图
                Chart1.Series["data5"].IsValueShownAsLabel = true;                                     //标记点上显示数据
                Chart1.Series["data5"].Color = Color.Red;                                              //线条颜色
                Chart1.Series["data5"].BorderWidth = 1;                                                //线条粗细
                Chart1.Series["data5"].IsValueShownAsLabel = false;                                    //不显示数据
                Chart1.Series["data5"].Points.DataBindXY(LSL_X_Data, LSL_Y_Data);                      //加载数据

                //图表序列 下限
                Chart1.Series.Add("data6");
                Chart1.Series["data6"].ChartType = SeriesChartType.Spline;                             //图标类型  曲线图
                Chart1.Series["data6"].IsValueShownAsLabel = true;                                     //标记点上显示数据
                Chart1.Series["data6"].Color = Color.Blue;                                             //线条颜色
                Chart1.Series["data6"].BorderWidth = 2;                                                //线条粗细
                Chart1.Series["data6"].IsValueShownAsLabel = false;                                    //不显示数据
                Chart1.Series["data6"].Points.DataBindXY(Normal_X_Data, Normal_Y_Data);                //加载数据
                #endregion
            }
        }

        /// <summary>
        /// 画RowData曲线
        /// </summary>
        /// <param name="Chart1">Chart</param>
        /// <param name="X_Data">X轴</param>
        /// <param name="Nomal_Data">标准值 Y轴</param>
        /// <param name="Upper_Data">上限 Y轴</param>
        /// <param name="Down_Data">下限 Y轴</param>
        /// <param name="Real_Data">实测值 Y轴</param>
        /// <param name="title"></param>
        private void Chart_line2(Chart Chart1, double[] X_Data, double[] Nomal_Data, double[] Upper_Data, double[] Down_Data, double[] Real_Data, string title)
        {
            if (X_Data.Length > 0)
            {
                #region //=======折线图=======//
                Chart1.ChartAreas.Clear();                          //图表区
                Chart1.Titles.Clear();                              //图表标题
                Chart1.Series.Clear();                              //图表序列
                Chart1.Legends.Clear();                             //图表图例
                Chart1.BackColor = Color.Transparent;               //chart控件 背景颜色

                //图表区 new
                Chart1.ChartAreas.Add(new ChartArea("chartarea"));
                Chart1.ChartAreas["chartarea"].BackColor = Color.Transparent;                              //chart区域 背景颜色
                Chart1.ChartAreas["chartarea"].AxisX.Enabled = AxisEnabled.True;                           //chart区域 X轴 线是否显示
                Chart1.ChartAreas["chartarea"].AxisY.Enabled = AxisEnabled.True;                           //chart区域 Y轴 线是否显示
                Chart1.ChartAreas["chartarea"].AxisX.MajorGrid.LineColor = Color.Transparent;              //chart区域 X轴 线颜色
                Chart1.ChartAreas["chartarea"].AxisY.MajorGrid.LineColor = Color.Transparent;              //chart区域 Y轴 线颜色
                Chart1.ChartAreas["chartarea"].AxisX.MajorTickMark.LineColor = Color.Transparent;          //chart区域 X轴刻度 线颜色
                Chart1.ChartAreas["chartarea"].AxisY.MajorTickMark.LineColor = Color.Transparent;          //chart区域 Y轴刻度 线颜色
                Chart1.ChartAreas["chartarea"].AxisX.LineColor = Color.Black;                              //chart区域 X轴主轴 线颜色
                Chart1.ChartAreas["chartarea"].AxisY.LineColor = Color.Black;                              //chart区域 Y轴主轴 线颜色
                Chart1.ChartAreas["chartarea"].AxisX.LabelStyle.ForeColor = Color.Black;                   //chart区域 X轴刻度数值 颜色
                Chart1.ChartAreas["chartarea"].AxisY.LabelStyle.ForeColor = Color.Black;                   //chart区域 Y轴刻度数值 颜色
                Chart1.ChartAreas["chartarea"].AxisX.IsMarginVisible = false;                              //数据过原点
                Chart1.ChartAreas["chartarea"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;    //设定x轴的间隔是可变的
                Chart1.ChartAreas["chartarea"].AxisX.LabelStyle.Angle = 0;                                 //让X坐标名称 垂直显示

                //图表标题 new
                Chart1.Titles.Add(title);
                Chart1.Titles[0].Text = title;                                                         //chart区域 Titles抬头
                Chart1.Titles[0].Font = new Font("宋体", 12);                                          //title 字体设置
                Chart1.Titles[0].ForeColor = Color.Black;                                              //title 字体颜色

                //图表序列 标准值值
                Chart1.Series.Add("data1");
                Chart1.Series["data1"].ChartType = SeriesChartType.Line;                              //图标类型  曲线图
                Chart1.Series["data1"].IsValueShownAsLabel = true;                                    //标记点上显示数据
                Chart1.Series["data1"].Color = Color.Green;                                           //线条颜色
                Chart1.Series["data1"].BorderWidth = 1;                                               //线条粗细
                Chart1.Series["data1"].IsValueShownAsLabel = false;                                   //不显示数据
                Chart1.Series["data1"].Points.DataBindXY(X_Data, Nomal_Data);                          //加载数据

                //图表序列 上限值
                Chart1.Series.Add("data2");
                Chart1.Series["data2"].ChartType = SeriesChartType.Line;                              //图标类型  曲线图
                Chart1.Series["data2"].IsValueShownAsLabel = true;                                    //标记点上显示数据
                Chart1.Series["data2"].Color = Color.Red;                                             //线条颜色
                Chart1.Series["data2"].BorderWidth = 1;                                               //线条粗细
                Chart1.Series["data2"].IsValueShownAsLabel = false;                                   //不显示数据
                Chart1.Series["data2"].Points.DataBindXY(X_Data, Upper_Data);                         //加载数据

                //图表序列 下限值
                Chart1.Series.Add("data3");
                Chart1.Series["data3"].ChartType = SeriesChartType.Line;                              //图标类型  曲线图
                Chart1.Series["data3"].IsValueShownAsLabel = true;                                    //标记点上显示数据
                Chart1.Series["data3"].Color = Color.Red;                                             //线条颜色
                Chart1.Series["data3"].BorderWidth = 1;                                               //线条粗细
                Chart1.Series["data3"].IsValueShownAsLabel = false;                                   //不显示数据
                Chart1.Series["data3"].Points.DataBindXY(X_Data, Down_Data);                          //加载数据

                //图表序列 实测值
                Chart1.Series.Add("data4");
                Chart1.Series["data4"].ChartType = SeriesChartType.Line;                              //图标类型  曲线图
                Chart1.Series["data4"].IsValueShownAsLabel = true;                                    //标记点上显示数据
                Chart1.Series["data4"].Color = Color.Blue;                                            //线条颜色
                Chart1.Series["data4"].BorderWidth = 1;                                               //线条粗细
                Chart1.Series["data4"].IsValueShownAsLabel = false;                                   //不显示数据
                Chart1.Series["data4"].Points.DataBindXY(X_Data, Real_Data);                          //加载数据
                #endregion
            }
        }


        #endregion

        #endregion

        private void SubMyCpk_Resize(object sender, EventArgs e)
        {

        }

        private void SubMyCpk_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
   
        }

        private void DoubleCheck(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }
    }

    public class modListView
    {
        #region  //=====ListView=====//
        public void InitBasic(ListView MyLV)
        {
            /*基本功能设置*/
            MyLV.View = View.Details;      //Set to details view.细节显示
            MyLV.LabelEdit = false;         //允许用户添加编辑条款
            MyLV.AllowColumnReorder = false;//Allow the user rearrange columns允许用户从新排列
            MyLV.CheckBoxes = false;       //DisPlay CheckBox显示打钩的框
            MyLV.FullRowSelect = true;     //整行选择
            MyLV.Sorting = SortOrder.None; //排序方式
            MyLV.GridLines = true;         //显示网格线
            MyLV.MultiSelect = false;      //禁止ListView选择多项
            MyLV.Refresh();
        }
        public virtual void InitLV(ListView MyLV)
        {
            //在派生类中重写方法
            InitBasic(MyLV);
            MyLV.BackColor = Color.AliceBlue;

            MyLV.Columns.Add("ID", 30, HorizontalAlignment.Center);
            MyLV.Columns.Add("Data", 80, HorizontalAlignment.Center);
        }
        public virtual void InitLV1(ListView MyLV)
        {
            //在派生类中重写方法
        }
        #endregion
    }

    public class modPanelAutoSize
    {
        #region//=====Form自动适应=====//
        //(1).声明结构,只记录窗体和其控件的初始位置和大小。  
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }
        //(2).声明 1个对象  
        //注意这里不能使用控件列表记录 List<Control> nCtrl;，因为控件的关联性，记录的始终是当前的大小。  
        public List<controlRect> oldCtrl ;
        //int ctrl_first = 0;  
        //(3). 创建两个函数  
        //(3.1)记录窗体和其控件的初始位置和大小,  
        public void controllInitializeSize(Panel mForm)
        {
            // if (ctrl_first == 0)  
            {
                //  ctrl_first = 1;  
                oldCtrl = new List<controlRect>();
                controlRect cR;
                cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;
                oldCtrl.Add(cR);
                foreach (Control c in mForm.Controls)
                {
                    controlRect objCtrl;
                    objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;
                    oldCtrl.Add(objCtrl);
                }
            }
            // this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化  
            //0 - Normalize , 1 - Minimize,2- Maximize  
        }
        //(3.2)控件自适应大小,  
        public void controlAutoSize(Panel mForm)
        {
            //int wLeft0 = oldCtrl[0].Left; ;//窗体最初的位置  
            //int wTop0 = oldCtrl[0].Top;  
            ////int wLeft1 = this.Left;//窗体当前的位置  
            //int wTop1 = this.Top;  
            float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;//新旧窗体之间的比例，与最早的旧窗体  
            float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;  
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始  
            foreach (Control c in mForm.Controls)
            {
                ctrLeft0 = oldCtrl[ctrlNo].Left;
                ctrTop0 = oldCtrl[ctrlNo].Top;
                ctrWidth0 = oldCtrl[ctrlNo].Width;
                ctrHeight0 = oldCtrl[ctrlNo].Height;
                //c.Left = (int)((ctrLeft0 - wLeft0) * wScale) + wLeft1;//新旧控件之间的线性比例  
                //c.Top = (int)((ctrTop0 - wTop0) * h) + wTop1;  
                c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1  
                c.Top = (int)((ctrTop0) * hScale);//  
                c.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);  
                c.Height = (int)(ctrHeight0 * hScale);//  
                ctrlNo += 1;
            }
        }
        #endregion
    }
}
