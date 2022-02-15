using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace MotorsControl
{
    public partial class Mapping_UserControl : UserControl
    {

        #region 用户界面的变量
        /// <summary>
        /// 定义读取Mapping初始值路径
        /// </summary>
        string Manual_OriMapping_File_Pathstr = "";
        /// <summary>
        /// 定义存储Mapping后值路径
        /// </summary>
        string Manual_Mapping_File_Pathstr = "";


        /// <summary>
        /// 定义用户界面Mapping初始值数据
        /// </summary>
        public List<Each_Ori_Mapping_Point> Manual_Mapping_Input_List;

        /// <summary>
        /// 定义用户界面Mapping后数据
        /// </summary>
        public List<Each_Mapping_Point> Manual_Axis_To_Calibration;
        /// <summary>

       

        #endregion

        public Mapping_UserControl()
        {
            InitializeComponent();
            //读取基本参数
            Mapping.Para = new Class_Parameter_Mapping();
            modINI_Mapping<Class_Parameter_Mapping>.ReadINI(ref Mapping.Para);

            //读取Mapping数据
            Mapping.Mapping_Point_List = new List<Each_Mapping_Point>();
            Mapping.Mapping_Point_List = Mapping.Get_MappingData_From_CSV(Mapping.PathFile_MappingData);

        }

        private void button_OpenFile1_Click(object sender, EventArgs e)
        {
            Manual_OriMapping_File_Pathstr = PathAdd();
            textBox_File1.Text = Manual_OriMapping_File_Pathstr;

        }
        private void button_OpenFile2_Click(object sender, EventArgs e)
        {
            Manual_Mapping_File_Pathstr = PathAdd();
            textBox_File2.Text = Manual_Mapping_File_Pathstr;

        }
        private void button_Mapping_Trans_Click(object sender, EventArgs e)
        {
            
            Manual_Mapping_Input_List = new List<Each_Ori_Mapping_Point>();
            List<Each_Mapping_Point> Manual_Axis_To_Calibration = new List<Each_Mapping_Point>();
            try
            {
                //读出原始数据
                Manual_Mapping_Input_List = Mapping.Read_Origion_Mapping_Data(Manual_OriMapping_File_Pathstr);
                //数据转换
                Mapping.Write_Mapping_OutputData(Mapping.Para, Manual_Mapping_Input_List, Manual_Mapping_File_Pathstr);

                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "数据转换成功";
                textBox_Log.Text = msg;
            }
            catch
            {
                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "文件读取失败!";
                textBox_Log.Text = msg;
            }
          
        }


        public string PathAdd()
        {
            string PathFile = "";

            OpenFileDialog openFile = new OpenFileDialog();   //实例化 打开文件夹
            openFile.Multiselect = false;//该值确定是否可以选择多个文件
            openFile.InitialDirectory = @"D:\Log\Mapping";
            openFile.Title = "请选择文件夹";
            openFile.Filter = "CSV files (*.csv)|*.csv"; //(*.xls)|*.xls  //(*.csv)|*.csv     打开的文件为csv格式
            if (openFile.ShowDialog() == DialogResult.OK)   //判断
            {
                PathFile = openFile.FileName;

            }
            return PathFile;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //获取数据
                myPoint Check_Point = new myPoint();
                Check_Point.X = Convert.ToInt32(Convert.ToDouble(textBox_Input_X.Text));
                Check_Point.Y = Convert.ToInt32(Convert.ToDouble(textBox_Input_Y.Text));
                //转换
                myPoint Result_Point = new myPoint();
                Result_Point = Mapping.CorrectAxisData(true, Mapping.Para, Check_Point, Mapping.Mapping_Point_List);
                //输出结果
                textBox_Result_X.Text = Result_Point.X.ToString();
                textBox_Result_Y.Text = Result_Point.Y.ToString();
                textBox_MappingID.Text = Mapping.Find_ID.ToString();

                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "点位Mapping成功";
                textBox_Log.Text = msg;

            }
            catch
            {
                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "点位Mapping失败";
                textBox_Log.Text = msg;
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
