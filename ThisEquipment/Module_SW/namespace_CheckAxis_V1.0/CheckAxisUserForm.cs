using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckAxis
{
    public partial class CheckAxisUserForm : UserControl
    {
        #region 用户界面的变量
        /// <summary>
        /// 定义读取直线度路径
        /// </summary>
        string File_Repeatability_Pathstr = "";
        /// <summary>
        /// 定义读取直线度路径
        /// </summary>
        string File_Straightness_Pathstr = "";
        /// <summary>
        /// 定义读取垂直度X轴路径
        /// </summary>
        string File_Pathstr_Squareness_X = "";
        /// <summary>
        /// 定义读取垂直度Y轴路径
        /// </summary>
        string File_Pathstr_Squareness_Y = "";

        /// <summary>
        /// 定义用户界面手动输入的数据
        /// </summary>
        List<CheckAxis_DataStyle.Each_Ori_Check_Point> Manual_Check_Repeatability_Input_List;
        /// <summary>
        /// 定义用户界面手动输入的数据
        /// </summary>
        List<CheckAxis_DataStyle.Each_Ori_Check_Point> Manual_Check_Straightness_Input_List;
        /// <summary>
        /// 定义用户界面手动输入X轴的数据
        /// </summary>
        List<CheckAxis_DataStyle.Each_Ori_Check_Point> Manual_Check_Squareness_XInput_List;
        /// <summary>
        /// 定义用户界面手动输入Y轴的数据
        /// </summary>
        List<CheckAxis_DataStyle.Each_Ori_Check_Point> Manual_Check_Squareness_YInput_List;

        #endregion

        public CheckAxisUserForm()
        {
            InitializeComponent();

            //读INI参数
            modINI_CheckAxis<CheckAxis_Parameter>.ReadINI(ref CheckAxis_Model.CheckAxis_Para);
        }

        #region 界面使用的方法
        public string PathAdd()
        {
            string PathFile = "";

            OpenFileDialog openFile = new OpenFileDialog();   //实例化 打开文件夹
            openFile.Multiselect = false;//该值确定是否可以选择多个文件
            openFile.InitialDirectory = @"D:\Log\CheckAxis";
            openFile.Title = "请选择文件夹";
            openFile.Filter = "CSV files (*.csv)|*.csv"; //(*.xls)|*.xls  //(*.csv)|*.csv     打开的文件为csv格式
            if (openFile.ShowDialog() == DialogResult.OK)   //判断
            {
                PathFile = openFile.FileName;
                
            }
            return PathFile;


        }
        #endregion

        #region 按钮功能
        private void button_OpenFile1_Click(object sender, EventArgs e)
        {
            File_Repeatability_Pathstr = PathAdd();
            textBox_File1.Text = File_Repeatability_Pathstr;

        }
        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            File_Straightness_Pathstr = PathAdd();
            textBox_File.Text = File_Straightness_Pathstr;
        }

        private void button_OpenFile_X_Click(object sender, EventArgs e)
        {
            File_Pathstr_Squareness_X = PathAdd();
            textBox_File_X.Text = File_Pathstr_Squareness_X;
        }

        private void button_OpenFile_Y_Click(object sender, EventArgs e)
        {
            File_Pathstr_Squareness_Y = PathAdd();
            textBox_File_Y.Text = File_Pathstr_Squareness_Y;
        }
        /// <summary>
        /// 重复性计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Manual_Check_Repeatability_Input_List = new List<CheckAxis_DataStyle.Each_Ori_Check_Point>();
            int[] Repeatability_Result;
            int Choice = checkBox_AxisChoice1.Checked == true ? 1 : 0;

            try
            {
                //读取文件数据
                Manual_Check_Repeatability_Input_List = CheckAxis_Model.Read_Check_Origion_Data(File_Repeatability_Pathstr);
                //计算结果
                CheckAxis_Model.Axis_Check_Repeatability(Choice, Manual_Check_Repeatability_Input_List, out Repeatability_Result);

                //结果输出并且log
                textBox_Log.Text = "";
                string msg = "";
                msg = DateTime.Now.ToString() + ";" + "文件" + File_Repeatability_Pathstr + "重复性结果为:\r\n";

                for (int i = 0; i < Repeatability_Result.Count(); i++)
                {
                    msg = msg + "第" + i.ToString("0") + "个点的重复性为：" + Repeatability_Result[i].ToString("0") + "um,";
                }
                textBox_Log.Text = msg;
                CheckAxis_Model.WriteLog(textBox_Log.Text);
            }
            catch
            {
                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "文件读取失败!";
                textBox_Log.Text = msg;               
            }
         


        }
        /// <summary>
        /// 直线度计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Measure1_Click(object sender, EventArgs e)
        {
            
            Manual_Check_Straightness_Input_List = new List<CheckAxis_DataStyle.Each_Ori_Check_Point>();
           
            int Straightness_Result;
            int Choice = checkBox_AxisChoice1.Checked == true ? 1 : 0;
            try
            {
                //读取文件数据
                Manual_Check_Straightness_Input_List = CheckAxis_Model.Read_Check_Origion_Data(File_Straightness_Pathstr);
                //计算结果
                CheckAxis_Model.Axis_Check_Straightness(Choice, Manual_Check_Straightness_Input_List, out Straightness_Result);
                //输出结果
                tb_Straightness_Result.Text = Straightness_Result.ToString("0");

                //结果输出并且log
                textBox_Log.Text = "";
                string msg = "";
                msg = DateTime.Now.ToString() + ";" + "文件" + File_Repeatability_Pathstr + "直线度结果为:\r\n";
                msg = msg + tb_Straightness_Result.Text + "um,";
                textBox_Log.Text = msg;

                CheckAxis_Model.WriteLog(textBox_Log.Text);
            }
            catch
            {
                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "文件读取失败!";
                textBox_Log.Text = msg;
            }

        }
        /// <summary>
        /// 垂直度计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Measure2_Click(object sender, EventArgs e)
        {
            Manual_Check_Squareness_XInput_List = new List<CheckAxis_DataStyle.Each_Ori_Check_Point>();
            Manual_Check_Squareness_YInput_List = new List<CheckAxis_DataStyle.Each_Ori_Check_Point>();
            double Squareness_Result;
            try
            {
                //读取文件数据
                Manual_Check_Squareness_XInput_List = CheckAxis_Model.Read_Check_Origion_Data(File_Pathstr_Squareness_X);
                Manual_Check_Squareness_YInput_List = CheckAxis_Model.Read_Check_Origion_Data(File_Pathstr_Squareness_Y);

                //计算结果         
                CheckAxis_Model.Axis_Check_Squareness(Manual_Check_Squareness_XInput_List, Manual_Check_Squareness_YInput_List, out Squareness_Result);
                //输出结果
                tb_Squareness.Text = Squareness_Result.ToString("0.000");

                //结果输出并且log
                textBox_Log.Text = "";
                string msg = "";
                msg = DateTime.Now.ToString() + ";" + "文件" + File_Repeatability_Pathstr + "垂直度结果为:\r\n";
                msg = msg + tb_Squareness.Text + "um,";
                textBox_Log.Text = msg;

                CheckAxis_Model.WriteLog(textBox_Log.Text);
            }
            catch
            {
                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "文件读取失败!";
                textBox_Log.Text = msg;
            }
            
        }
        #endregion

        #region 调用界面功能(FUN_)
        #endregion



    }
}
