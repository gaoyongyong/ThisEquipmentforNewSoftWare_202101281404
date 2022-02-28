using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using PropertyGridEx;

namespace UserCoord
{
    public partial class modControl_UserCoord : UserControl
    {
        #region //定义用户界面需要的变量
        /// <summary>
        /// 定义读取基准点坐标初始值路径
        /// </summary>
        public string Manual_BasicCoord_File_Pathstr = "";

        /// <summary>
        /// 定义存储产品坐标系路径
        /// </summary>
        public string Manual_Product_File_Pathstr = "";

        /// <summary>
        /// 定义存储机械点坐标值路径
        /// </summary>
        public string Manual_MachineCoord_File_Pathstr = "";


        /// <summary>
        /// 定义用户界面基准点坐标系数据
        /// </summary>
        public List<Coord_Point> Manual_BasicCoord_List ;


        /// <summary>
        /// 定义用户界面产品坐标系数据
        /// </summary>
        public List<Coord_Point> Manual_Product_Coord_List;

        /// <summary>
        /// 定义用户基准点坐标坐标系
        /// </summary>
        public List<Coord_Point> Manual_MachineCoord_List;

        /// <summary>
        /// 实例化用户模型需要的方法类
        /// </summary>
        public mod_UserCoord UserCoord_Model = null;

        /// <summary>
        /// 实例化用户模型需要的参数类
        /// </summary>
       public  basemod_UserCoord UserCoord_Para_Model = null ;

        






        #endregion
        public modControl_UserCoord()
        {
            InitializeComponent();

            //定义UserForm需要的类
            UserCoord_Model = new mod_UserCoord();
            UserCoord_Para_Model = new basemod_UserCoord();

            


           Manual_BasicCoord_List = new List<UserCoord.Coord_Point>();
            Manual_Product_Coord_List = new List<Coord_Point>();
            Manual_MachineCoord_List = new List<Coord_Point>();
        }

        private void button_OpenFile1_Click(object sender, EventArgs e)
        {
            Manual_BasicCoord_File_Pathstr = PathAdd();
            textBox_File1.Text = Manual_BasicCoord_File_Pathstr;
        }

        private void button_OpenFile2_Click(object sender, EventArgs e)
        {
            Manual_Product_File_Pathstr = PathAdd();
            textBox_File2.Text = Manual_Product_File_Pathstr;
        }

        private string PathAdd()
        {
            string PathFile = "";

            OpenFileDialog openFile = new OpenFileDialog();   //实例化 打开文件夹
            openFile.Multiselect = false;//该值确定是否可以选择多个文件
            openFile.InitialDirectory = @"D:\Log\CoordExchange";
            openFile.Title = "请选择文件夹";
            openFile.Filter = "CSV files (*.csv)|*.csv"; //(*.xls)|*.xls  //(*.csv)|*.csv     打开的文件为csv格式
            if (openFile.ShowDialog() == DialogResult.OK)   //判断
            {
                PathFile = openFile.FileName;

            }
            return PathFile;


        }

        private void button_Mapping_Trans_Click(object sender, EventArgs e)
        {
            try
            {
                //读出基准点原始数据
                Manual_BasicCoord_List = null;// UserCoord_Model.Read_Coord_Point_List(Manual_BasicCoord_File_Pathstr);

                //读出产品坐标系原始数据
                Manual_Product_Coord_List = null;//UserCoord_Model.Read_Coord_Point_List(Manual_Product_File_Pathstr);


                //数据转换
                Manual_MachineCoord_List = UserCoord_Model.Coord_Exchange(Manual_BasicCoord_List, Manual_Product_Coord_List);

                //写入CSV
                UserCoord_Model.Write_CoordData_To_CSV(Manual_MachineCoord_List);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //获取数据
                Coord_Point Check_Point = new Coord_Point();
                Check_Point.X_Position = Convert.ToDouble(Convert.ToDouble(textBox_Input_X.Text));
                Check_Point.Y_Position = Convert.ToDouble(Convert.ToDouble(textBox_Input_Y.Text));
               


                Manual_Product_Coord_List.Add(Check_Point);
                //数据转换
                Manual_MachineCoord_List = UserCoord_Model.Coord_Exchange(Manual_BasicCoord_List, Manual_Product_Coord_List);
                //输出结果
                textBox_Result_X.Text = Manual_MachineCoord_List[0].X_Position.ToString();
                textBox_Result_Y.Text = Manual_MachineCoord_List[0].Y_Position.ToString();
                
                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "数据转换成功";
                textBox_Log.Text = msg;

            }
            catch
            {
                //结果输出并且log
                textBox_Log.Text = "";
                string msg = DateTime.Now.ToString() + ";" + "数据转换失败";
                textBox_Log.Text = msg;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
