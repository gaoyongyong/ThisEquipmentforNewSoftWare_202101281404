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
using WinForm.FormBuild.PublicClass;

namespace WinForm.FormBuild.UI
{
    public partial class Form_UPHChart : Form
    {
        private delegate void dgShowData(ProductCapacity ProductCapacity);
        private dgShowData _wtShowData;
        private void ONShowData(ProductCapacity ProductCapacity)
        {
            Invoke(_wtShowData, ProductCapacity);
        }
        public Form_UPHChart()
        {
            InitializeComponent();

            _wtShowData = new dgShowData(ShowData);
            FormBuildCommon.NotifyUPHShow += ONShowData;
        }
        private void ShowData(ProductCapacity ProductCapacity)
        {
            int[] ydata1 = ProductCapacity.MachineOK.ToArray();
            int[] ydata2 = ProductCapacity.MachineNG.ToArray();
            string[] XData = ProductCapacity.TimeSlot.ToArray();
            ProductDataShowChart(this.chart1, ydata1, ydata2, XData, "UPH统计");
        }

        /// <summary>
        /// 产能柱状图
        /// </summary>
        /// <param name="Chart1"></param>
        /// <param name="YData"></param>
        /// <param name="XData"></param>
        /// <param name="title"></param>
        public void ProductDataShowChart(Chart Chart1, int[] YData1, int[] YData2, string[] XData, string title)
        {
            #region //=======树状图1=======//
            Chart1.ChartAreas.Clear();     //图表区
            Chart1.Titles.Clear();         //图表标题
            Chart1.Series.Clear();         //图表序列
            Chart1.Legends.Clear();        //图表图例

            Chart1.BackColor = Color.LightBlue;               //chart控件 背景颜色
            string chartarea = "chartarea";
            //图表区 new
            Chart1.ChartAreas.Add(new ChartArea(chartarea));
            Chart1.ChartAreas[chartarea].BackColor = Color.LightBlue;  //chart区域 背景颜色
            Chart1.ChartAreas[chartarea].AxisX.Enabled = AxisEnabled.True;                           //chart区域 X轴 线是否显示
            Chart1.ChartAreas[chartarea].AxisY.Enabled = AxisEnabled.True;                           //chart区域 Y轴 线是否显示
            Chart1.ChartAreas[chartarea].AxisX.MajorGrid.LineColor = Color.LightBlue;                //chart区域 X轴 线颜色
            Chart1.ChartAreas[chartarea].AxisY.MajorGrid.LineColor = this.BackColor;                //chart区域 Y轴 线颜色

            Chart1.ChartAreas[chartarea].AxisX.IsMarginVisible = true;
            Chart1.ChartAreas[chartarea].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            Chart1.ChartAreas[chartarea].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;     //设定x轴的间隔是可变的
            Chart1.ChartAreas[chartarea].AxisX.LabelStyle.Angle = -78;     //让X坐标名称 垂直显示

            ////开启三维模式的原因是为了避免标签重叠
            //Chart1.ChartAreas["chartarea"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            //Chart1.ChartAreas["chartarea"].Area3DStyle.Rotation = 15;//起始角度
            //Chart1.ChartAreas["chartarea"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            //Chart1.ChartAreas["chartarea"].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
            //图表标题 new
            Chart1.Titles.Add(title);
            Chart1.Titles[0].Text = title;                          //chart区域 Titles抬头
            Chart1.Titles[0].Font = new Font("宋体", 13);            //title 字体设置
            Chart1.Titles[0].ForeColor = Color.RoyalBlue;           //title 字体颜色
            //Chart1.Titles[0].TextOrientation = TextOrientation.Horizontal; //字体方向

            //图表序列 new 1
            Series series1 = new Series("OK数量");
            series1.ChartArea = chartarea;
            Chart1.Series.Add(series1);
            Chart1.Series[0].IsValueShownAsLabel = true;
            Chart1.Series[0]["PointWidth"] = "0.5";  //柱状宽度
            Chart1.Series[0].ChartType = SeriesChartType.Column;  //图标类型  柱状图
            Chart1.Series[0].Color = Color.Green;
            Chart1.Series[0].Points.DataBindXY(XData, YData1);

            //图表序列 new 2
            Series series2 = new Series("NG数量");
            series2.ChartArea = chartarea;
            Chart1.Series.Add(series2);
            Chart1.Series[1].IsValueShownAsLabel = true;
            Chart1.Series[1]["PointWidth"] = "0.5";  //柱状宽度
            Chart1.Series[1].ChartType = SeriesChartType.Column;  //图标类型  柱状图
            Chart1.Series[1].Color = Color.Red;
            Chart1.Series[1].Points.DataBindXY(XData, YData2);

            //Legend
            Chart1.Legends.Add("Total SpLine");
            Chart1.Legends[0].Docking = Docking.Top;

            // Enable range selection and zooming end user interface
            Chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            Chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            Chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            Chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            Chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            Chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            //将滚动内嵌到坐标轴中
            Chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            Chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            // 设置滚动条的大小
            Chart1.ChartAreas[0].AxisX.ScrollBar.Size = 15;
            Chart1.ChartAreas[0].AxisY.ScrollBar.Size = 15;

            // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
            Chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            Chart1.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.ResetZoom;

            // 设置自动放大与缩小的最小量
            Chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            Chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 2;

            Chart1.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = double.NaN;
            Chart1.ChartAreas[0].AxisY.ScaleView.SmallScrollMinSize = 2;

            Chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            #endregion
        }
    }
}
