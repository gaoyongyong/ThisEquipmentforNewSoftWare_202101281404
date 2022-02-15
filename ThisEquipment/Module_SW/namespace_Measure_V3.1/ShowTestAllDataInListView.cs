using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Measure
{
    public partial class ShowTestAllDataInListView : UserControl
    {
        #region 1.公有变量
        #endregion
        #region 2.私有变量
        //写log内容，写log头
        string RecordData_Contents = "";
        string RecordData_Head = "";
        private static int MaxListLenth = 200;//最大数据输入
        Measurelog Measure_log = new Measurelog();
        #endregion
        #region 3.构造函数
        public ShowTestAllDataInListView()
        {
            InitializeComponent();
            Service_Refresh.TestData_Refresh += Add_Measure_Data_Record;
            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            Ini_Form();
        }
        #endregion
        #region 4.私有方法
        /// <summary>
        /// 初始化控件ListView样式
        /// </summary>
        private void Ini_Form()
        {
            //初始化控件ListView样式
            lv1.View = View.Details;      //Set to details view.细节显示
            lv1.LabelEdit = true;         //允许用户添加编辑条款
            lv1.AllowColumnReorder = true;//Allow the user rearrange columns允许用户从新排列
            lv1.CheckBoxes = false;       //DisPlay CheckBox显示打钩的框
            lv1.FullRowSelect = true;     //整行选择
            lv1.Sorting = SortOrder.None; //排序方式
            lv1.GridLines = true;         //显示网格线
            lv1.MultiSelect = false;      //禁止ListView选择多项

            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

        }
        #endregion
        #region 5.公有方法
        /// <summary>
        /// 初始化控件-根据项目加载列
        /// </summary>
        public void INIT_ShowTestAllDataInListView(string prjName)
        {
            //根据项目加载列
            lv1.Columns.Clear();
            lv1.Items.Clear();

            lv1.Columns.Add("Serial", 50, HorizontalAlignment.Center);
            lv1.Columns.Add("Barcode", 150, HorizontalAlignment.Right);
            lv1.Columns.Add("M-Time", 100, HorizontalAlignment.Right);
            lv1.Columns.Add("M-Result", 80, HorizontalAlignment.Center);


            int intWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - 50 - 150 - 100 - 80 - 20;
            if (intWidth < 1)
                intWidth = 1;

            int intCountShow = 0;
            for (int i = 0; i < ProMeasureSize.Sizes.Count(); i++)
            {
                if (ProMeasureSize.Sizes[i].IsShow)
                    intCountShow++;
            }
            int widthShow=0;
            if (intCountShow != 0) 
            {
                widthShow = intWidth / intCountShow;
            }
            
            if (widthShow < 80)
                widthShow = 80;

            for (int i = 0; i < ProMeasureSize.Sizes.Count(); i++)
            {
                if (ProMeasureSize.Sizes[i].IsShow)

                    lv1.Columns.Add(ProMeasureSize.Sizes[i].SizeName, widthShow, HorizontalAlignment.Left);
                else
                    lv1.Columns.Add(ProMeasureSize.Sizes[i].SizeName, 0, HorizontalAlignment.Left);
            }
        }

        /// <summary>
        /// 向总表插入一行数据
        /// </summary>
        public void FUNC_AddALineData()
        {
            ListViewItem MyItem = new ListViewItem();
            MyItem.Text = ProMeasureSize.Serial.ToString();
            MyItem.SubItems.Add(ProMeasureSize.Barcode);
            MyItem.SubItems.Add(ProMeasureSize.MeasureTime);
            MyItem.SubItems.Add(ProMeasureSize.MeasureResult);
            for (int i = 0; i < ProMeasureSize.Sizes.Count(); i++)
            {
                try
                {
                    MyItem.SubItems.Add(ProMeasureSize.TestValue[i].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    continue;
                }

            }
            lv1.Items.Insert(0, MyItem);
            lv1.Refresh();
        }

        /// <summary>
        /// 向总表插入一行数据,超下限和上限用不同的颜色区分
        /// </summary>
        public void FUNC_AddALineDataInColor()
        {

            lv1.View = View.Details;
            ListViewItem MyItem = new ListViewItem();
            MyItem.UseItemStyleForSubItems = false;
            MyItem.Text = ProMeasureSize.Serial.ToString();
            MyItem.SubItems.Add(ProMeasureSize.Barcode);
            MyItem.SubItems.Add(ProMeasureSize.MeasureTime);
            MyItem.SubItems.Add(ProMeasureSize.MeasureResult);
            //文件格式
            RecordData_Contents = MyItem.Text + "," + ProMeasureSize.Barcode + "," + ProMeasureSize.MeasureTime + "," + ProMeasureSize.MeasureResult + "," + TestExcepation.SizeProperty6.ToString() + "," + TestExcepation.SizeProperty7.ToString() + "," + TestExcepation.SizeProperty8.ToString() + ",";
            RecordData_Head = "Serial,Barcode,M-Time,M-Reusult,L_BIN1,R_BIN2,M_BIN3,";
            for (int i = 0; i < ProMeasureSize.Sizes.Count(); i++)
            {
                RecordData_Contents = RecordData_Contents + ProMeasureSize.TestValue[i].Value.ToString() + ",";
                RecordData_Head = RecordData_Head + ProMeasureSize.NameList[i].ToString() + ",";
                try
                {
                    MyItem.SubItems.Add(ProMeasureSize.TestValue[i].Value.ToString("0.000"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            for (int i = 0; i < ProMeasureSize.Sizes.Count(); i++)
            {
                if (ProMeasureSize.TestValue[i].Value < ProMeasureSize.Sizes[i].NormValue - ProMeasureSize.Sizes[i].LowerDeviation)
                    MyItem.SubItems[i + 4].BackColor = Color.Red;

                else if (ProMeasureSize.TestValue[i].Value > ProMeasureSize.Sizes[i].NormValue + ProMeasureSize.Sizes[i].UpperDeviation)
                    MyItem.SubItems[i + 4].BackColor = Color.Red;

                else
                {
                    MyItem.SubItems[i + 4].BackColor = Color.White;
                }
            }

            Measure_log.WriteData(RecordData_Contents, RecordData_Head, Measurelog.path_log_Data);
            //如果items数据大于设置值，items数据清零
            
            this.Invoke(new Action(() =>
            {
                if (lv1.Items.Count > MaxListLenth)
                {
                    lv1.Items.Clear();
                }

                lv1.Items.Insert(0, MyItem);
                lv1.Refresh();
            }));
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        public void Add_Measure_Data_Record()
        {

            Measure.ProMeasureSize.Serial = ProStatistics.UserControl_ProStatistics.stc.ProTotal.ToString();

            Measure.ProMeasureSize.MeasureTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff| ");

            FUNC_AddALineDataInColor();

        }
        #endregion
        #region 6.按钮
        /// <summary>
        /// 清空数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.groupBox2.Visible = true;

            Point p = new Point();
            p.X = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2 - this.groupBox2.Width / 2;
            p.Y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 2 - this.groupBox2.Height - 100;
            this.groupBox2.Location = p;

        }

        /// <summary>
        /// Yes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonYesClean_Click(object sender, EventArgs e)
        {
            lv1.Items.Clear();
            this.groupBox2.Visible = false;
        }
        /// <summary>
        /// No
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNoClean_Click(object sender, EventArgs e)
        {
            this.groupBox2.Visible = false;
        }
        #endregion

    }
}
