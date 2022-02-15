using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

using System.IO;
using System.Drawing;
using System.Windows;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;

namespace CheckAxis
{
    public class CheckAxis_Model
    {
        #region 定义全局变量及其所需要的类
        /// <summary>
        /// 定义数据存储文件的位置
        /// </summary>
        public static string PathFile_AxisData = @"D:\Log\CheckAxis"; //轴数据
        [CategoryAttribute("文档设置"),DefaultValueAttribute(true)]
       

        public static string PathFile_AxisResult = @"D:\Log\AxisData"; //轴运行结果
        /// <summary>
        /// 定义数据存储的变量
        /// </summary>
        public static List<CheckAxis_DataStyle.Each_Ori_Check_Point> Check_Input_List;
        public static CheckAxis_Parameter CheckAxis_Para =  new CheckAxis_Parameter();
        #endregion

        #region 定义类所使用的方法，可以给用户界面及自动程序调用
        /// <summary>
        /// 读mapping 数据
        /// </summary>
        // public static void Read_Mapping_Origion_Data()
        //{
        //    string[] dd = null;
        //    long _size = GetFileSize(PathFile);  //65536
        //    System.IO.FileStream fs = File.OpenRead(PathFile);   // 读取文件内容  
        //    byte[] b = new byte[_size];
        //    string a = "";
        //    while (fs.Read(b, 0, b.Length) > 0)
        //    {
        //        string tmp = Encoding.Default.GetString(b);
        //        if (tmp != "")
        //        {
        //            a += tmp;
        //        }
        //    }
        //    dd = a.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);  //按照回车换行 进行分类



        //    List<CheckAxis_Model.Each_Ori_Mapping_Point> Mapping_Input_List = new List<CheckAxis_Model.Each_Ori_Mapping_Point>();
        //    for (int i = 0; i < dd.Length; i++)
        //    {
        //        string[] data = dd[i].Split(',');
        //        CheckAxis_Model.Each_Ori_Mapping_Point Mapping_Input = new CheckAxis_Model.Each_Ori_Mapping_Point();
        //        Mapping_Input.Mapping_Corrector_Data.X = Convert.ToInt32(String.Format("{0:000000}", data[0]));
        //        Mapping_Input.Mapping_Corrector_Data.Y = Convert.ToInt32(String.Format("{0:000000}", data[1]));
        //        Mapping_Input.Mapping_Axis_Data.X = Convert.ToInt32(String.Format("{0:000000}", data[2]));
        //        Mapping_Input.Mapping_Axis_Data.Y = Convert.ToInt32(String.Format("{0:000000}", data[3]));
        //        Mapping_Input_List.Add(Mapping_Input);

        //    }


        //}

        /// <summary>
        /// 读轴数据
        /// </summary>
        /// <param name="PathFile"></param>
        /// <returns></returns>
        public static List<CheckAxis_DataStyle.Each_Ori_Check_Point> Read_Check_Origion_Data(string PathFile)
        {
            List<CheckAxis_DataStyle.Each_Ori_Check_Point> CheckAxis_Input_List = new List<CheckAxis_DataStyle.Each_Ori_Check_Point>();
            string[] dd = null;          
            long _size = GetFileSize(PathFile);  //65536
            System.IO.FileStream  fs = File.OpenRead(PathFile);   // 读取文件内容
            byte[] b = new byte[_size];
            string a = "";
            while (fs.Read(b, 0, b.Length) > 0)
            {
                string tmp = Encoding.Default.GetString(b);
                if (tmp != "")
                {
                    a += tmp;
                }
            }
            dd = a.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);  //按照回车换行 进行分类
            
            for (int i = 0; i < dd.Length; i++)
            {
                string[] data = dd[i].Split(',');
                CheckAxis_DataStyle.Each_Ori_Check_Point CheckAxis_Input = new CheckAxis_DataStyle.Each_Ori_Check_Point();
                CheckAxis_Input.ID = Convert.ToInt32(String.Format("{0:000000}", data[0]));
                CheckAxis_Input.Check_Axis_Data.X = Convert.ToInt32(String.Format("{0:000000}", data[1]));
                CheckAxis_Input.Check_Axis_Data.Y = Convert.ToInt32(String.Format("{0:000000}", data[2]));
                CheckAxis_Input.Check_CCD_Data.X = Convert.ToInt32(String.Format("{0:000000}", data[3]));
                CheckAxis_Input.Check_CCD_Data.Y = Convert.ToInt32(String.Format("{0:000000}", data[4]));
                CheckAxis_Input_List.Add(CheckAxis_Input);

            }
            return CheckAxis_Input_List;


        }

        /// <summary>
        /// 计算直线度
        /// </summary>
        /// <param name="Para">参数</param>
        /// <param name="Axis_Choice">轴选择=false：计算X轴直线度 =true:计算Y轴直线度</param>
        public static void Axis_Check_Straightness(int Axis_Choice,List<CheckAxis_DataStyle.Each_Ori_Check_Point> Input_Data_List,out int Result)
        {

            HTuple Input_Straightness_X = new HTuple();
            HTuple Input_Straightness_Y = new HTuple();

            HObject Result_Straightness_X = new HObject();
            HObject Result_Straightness_Y = new HObject();

            HTuple RowBegin = new HTuple();
            HTuple ColBegin = new HTuple();
            HTuple RowEnd = new HTuple();
            HTuple ColEnd = new HTuple();
            HTuple Nr = new HTuple();
            HTuple Nc = new HTuple();
            HTuple Dist = new HTuple();

            HTuple Distance = new HTuple();
            HTuple Straightness = new HTuple();
           

            //X的直线度需要取Y坐标

            for (int i = 0; i < Input_Data_List.Count(); i++)
            {
                if (Axis_Choice==0)
                {
                    Input_Straightness_X[i] = Input_Data_List[i].Check_CCD_Data.X;
                    Input_Straightness_Y[i] = Input_Data_List[i].Check_CCD_Data.Y;
                }
                else
                {
                    Input_Straightness_X[i] = Input_Data_List[i].Check_CCD_Data.Y;
                    Input_Straightness_Y[i] = Input_Data_List[i].Check_CCD_Data.X;
                }
            }



            //将点集合画图
            HOperatorSet.GenContourPolygonXld(out Result_Straightness_X, Input_Straightness_X, Input_Straightness_Y);
            //将点拟合成线
            HOperatorSet.FitLineContourXld(Result_Straightness_X, "regression", -1, 0, 1, 1, out RowBegin, out ColBegin, out RowEnd, out ColEnd, out Nr, out Nc, out Dist);

            //求所有点到直线的距离
            HOperatorSet.DistancePl(Input_Straightness_X, Input_Straightness_Y, RowBegin, ColBegin, RowEnd, ColEnd, out Distance);

            //直线度最大值
            HOperatorSet.TupleMax(Distance, out Straightness);
          

            double Straightness_Result = Straightness;
            Result = Convert.ToInt32(Straightness_Result);
            ///
        
      
        }
        /// <summary>
        /// 计算垂直度
        /// </summary>
        /// <param name="Para">参数</param>
        /// <param name="Axis_Choice">轴选择=false：计算X轴直线度 =true:计算Y轴直线度</param>
        public static void Axis_Check_Squareness(List<CheckAxis_DataStyle.Each_Ori_Check_Point> Input_XData_List, List<CheckAxis_DataStyle.Each_Ori_Check_Point> Input_YData_List, out double Result)
        {
            //定义X,Y轴输入变量
            HTuple Input_XSquareness_X = new HTuple();
            HTuple Input_XSquareness_Y = new HTuple();

            HTuple Input_YSquareness_X = new HTuple();
            HTuple Input_YSquareness_Y = new HTuple();

            //定义X,Y轴所有点图形
            HObject Result_XStraightness = new HObject();
            HObject Result_YStraightness = new HObject();

            //X轴结果
            HTuple XRowBegin = new HTuple();
            HTuple XColBegin = new HTuple();
            HTuple XRowEnd = new HTuple();
            HTuple XColEnd = new HTuple();
            HTuple XNr = new HTuple();
            HTuple XNc = new HTuple();
            HTuple XDist = new HTuple();

           

            //Y轴结果
            HTuple YRowBegin = new HTuple();
            HTuple YColBegin = new HTuple();
            HTuple YRowEnd = new HTuple();
            HTuple YColEnd = new HTuple();
            HTuple YNr = new HTuple();
            HTuple YNc = new HTuple();
            HTuple YDist = new HTuple();
        
            HTuple XYSquareness = new HTuple();

            //取X轴所有坐标
            for (int i = 0; i < Input_XData_List.Count(); i++)
            {
                Input_XSquareness_X[i] = Input_XData_List[i].Check_CCD_Data.X;
                Input_XSquareness_Y[i] = Input_XData_List[i].Check_CCD_Data.Y;           
            }

            //取Y轴所有坐标
            for (int i = 0; i < Input_YData_List.Count(); i++)
            {
                Input_YSquareness_X[i] = Input_YData_List[i].Check_CCD_Data.X;
                Input_YSquareness_Y[i] = Input_YData_List[i].Check_CCD_Data.Y;
            }



            //将X轴点集合画图
            HOperatorSet.GenContourPolygonXld(out Result_XStraightness, Input_XSquareness_X, Input_XSquareness_Y);
            //将X轴点拟合成线
            HOperatorSet.FitLineContourXld(Result_XStraightness, "regression", -1, 0, 1, 1, out XRowBegin, out XColBegin, out XRowEnd, out XColEnd, out XNr, out XNc, out XDist);

            //将Y轴点集合画图
            HOperatorSet.GenContourPolygonXld(out Result_YStraightness, Input_YSquareness_X, Input_YSquareness_Y);
            //将Y轴点拟合成线
            HOperatorSet.FitLineContourXld(Result_YStraightness, "regression", -1, 0, 1, 1, out YRowBegin, out YColBegin, out YRowEnd, out YColEnd, out YNr, out YNc, out YDist);

            //计算直线度
            HOperatorSet.AngleLl(XRowBegin, XColBegin,  XRowEnd, XColEnd, YRowBegin, YColBegin, YRowEnd, YColEnd, out XYSquareness);


            //输出结果
            double XYSquareness_Double = XYSquareness;
            Result = XYSquareness_Double;            

        }
        /// <summary>
        /// 计算重复性
        /// </summary>
        /// <param name="Axis_Choice"></param>
        /// <param name="Input_Data_List"></param>
        /// <param name="Result"></param>
        public static void Axis_Check_Repeatability(int Axis_Choice, List<CheckAxis_DataStyle.Each_Ori_Check_Point>Input_Data_List, out int[] Result)
        {
            int ID_Max = 0;

            HTuple Input_Repeatability ;
            HTuple Repeatability_Max ;
            HTuple Repeatability_Min ;

            //分离数据集合
            List<int> Find_Data_List = new List<int>();
            //分离数据集合去重复
            List<int> Find_Data_List1 = new List<int>();

            int Find_Data = 0;
            int m = 0;
            //添加第一个值


            //计算list里所有X或Y值
            for (int i = 0; i < Input_Data_List.Count(); i++)
            {
                if (Axis_Choice == 0)
                {
                    Find_Data = Input_Data_List[i].Check_Axis_Data.X;
                }
                else
                {
                    Find_Data = Input_Data_List[i].Check_Axis_Data.Y;
                    
                }
                Find_Data_List1.Add(Find_Data);

            }

            Find_Data_List = Find_Data_List1.Distinct().ToList(); 

            //返回值
            int[] Repeatability = new int[Find_Data_List.Count()];

            //计算每个list的最大值

            for (int i = 0; i < Find_Data_List.Count(); i++)
            {
                Input_Repeatability = new HTuple();
                Repeatability_Max = new HTuple();
                Repeatability_Min = new HTuple();
                for (int j = 0; j < Input_Data_List.Count(); j++)
                {
                  
                        
                        if (Axis_Choice==0)
                        {
                        if (Input_Data_List[j].Check_Axis_Data.X == Find_Data_List[i])
                        {
                            Input_Repeatability.Append(Input_Data_List[j].Check_CCD_Data.Y);
                        }

                        }
                        else
                        {
                        if (Input_Data_List[j].Check_Axis_Data.Y == Find_Data_List[i])
                        {
                            Input_Repeatability.Append(Input_Data_List[j].Check_CCD_Data.X);
                        }
                        }
                    
                    
                }
                HOperatorSet.TupleMax(Input_Repeatability, out Repeatability_Max);
                HOperatorSet.TupleMin(Input_Repeatability, out Repeatability_Min);
                double Repeatability_Max_Double = Repeatability_Max;
                double Repeatability_Min_Double = Repeatability_Min;
                Repeatability[i] = Convert.ToInt32((Repeatability_Max_Double - Repeatability_Min_Double));
            }
            Result = Repeatability;



        }
        /// <summary>
        /// 将输入的数据写入CSV中
        /// </summary>
        /// <param name="Input_Data_List"></param>
        public static void Write_AxisData_To_CSV(List<CheckAxis_DataStyle.Each_Ori_Check_Point> Input_Data_List,int Choice)
        {
            string Contents = "";
            for (int i = 0; i < Input_Data_List.Count(); i++)
            {
                Contents = Contents+
                           Input_Data_List[i].ID.ToString("0") + "," +
                           Input_Data_List[i].Check_Axis_Data.X.ToString("0") + "," +
                           Input_Data_List[i].Check_Axis_Data.Y.ToString("0") + "," +
                           Input_Data_List[i].Check_CCD_Data.X.ToString("0") + "," +
                           Input_Data_List[i].Check_CCD_Data.Y.ToString("0")
                           + "\r\n";               
            }
            WriteData(Contents, Choice);
        }

        /// <summary>
        /// 输出文件记录
        /// </summary>
        /// <param name="contents">保存文件内容</param>
        /// <param name="headLine">列标题，主要用于输出数据表</param>
        /// <param name="pathStr">保存文件路径</param>
        /// <param name="suffix">后缀名</param>
        /// <returns></returns>
        public static bool WriteLog(string contents)   //
        {
            string pathStr = "";
            lock (lockstate1)
            {
                try
                {
                    pathStr = PathFile_AxisResult;
                    if (!Directory.Exists(pathStr))
                    {
                        Directory.CreateDirectory(pathStr);
                    }
                    pathStr = pathStr + @"\" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";
                    contents = contents + "\r\n";
                    File.AppendAllText(pathStr, contents);
                    return true;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
        #endregion

        #region 定义此类所使用的辅助方法,使用private
        private static object lockstate = new object(); //定义一个空对象用来加锁
        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        private static long GetFileSize(string _path)
        {
            long lSize = 0;
            if (File.Exists(_path))
                lSize = new FileInfo(_path).Length;
            return lSize;
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        private static void CreateDir(string dirPath)   //创建文件夹
        {

            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建" + dirPath + "目录失败\n" + ex.Message);
                

            }

        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        private static bool WriteData(string contents,int Address_Choice)  
        {         
            lock (lockstate)
            {
                try
                {
                    CreateDir(PathFile_AxisData);
                    string pathStr = "";
                    if (Address_Choice==0)
                    {
                        pathStr = PathFile_AxisData + @"\" + "X轴" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
                    }
                    else
                    {
                        pathStr = PathFile_AxisData + @"\" + "Y轴" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
                    }

                    // contents = contents + "\r\n";
                    File.AppendAllText(pathStr, contents);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        private static object lockstate1 = new object(); //定义一个空对象用来加锁
        private void CreateDir(object pdcaPath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }


}
