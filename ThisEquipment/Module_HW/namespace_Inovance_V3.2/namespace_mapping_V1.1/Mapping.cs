using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text;
using System.IO;


namespace MotorsControl
{
    #region 定义所需要的结构体变量
    public struct myPoint
    {
        public int X;
        public int Y;
    }
    public struct Each_Mapping_Point
    {
        //mapping后数据
        public int ID;
        public Each_Ori_Mapping_Point Mapping_XDownYDown;
        public Each_Ori_Mapping_Point Mapping_XDownYUp;
        public Each_Ori_Mapping_Point Mapping_XUpYDown;
        public Each_Ori_Mapping_Point Mapping_XUpYUp;
       

    }
    public struct Each_Ori_Mapping_Point
    {
        //Mapping前数据
        public int ID;
        public myPoint Mapping_Axis_Data;
        public myPoint Mapping_Corrector_Data;
    


    }

 
    public struct Mapping_Check_Point
    {
        //mapping后轴数据和相机数据
        public int ID;        
        public myPoint Check_Axis_Data;
        public myPoint Check_CCD_Data;

    }


    #endregion
    public class Mapping
    {

        #region 定义全局变量及其所需要的类
        /// <summary>
        /// 数据库连接
        /// </summary>
        public MappingDBUtil MapData = new MappingDBUtil();

        /// <summary>
        /// Mapping 前数据
        /// </summary>
        public static List<Each_Ori_Mapping_Point> Ori_Mapping_Point_List = null;

        /// <summary>
        /// Mapping 后数据
        /// </summary>
        public static List<Each_Mapping_Point> Mapping_Point_List = null;

        /// <summary>
        /// Mapping后check数据
        /// </summary>
        public static List<Mapping_Check_Point> Mapping_Check_List = null;


        /// <summary>
        /// 自动Mapping的原始数据
        /// </summary>
        public static string PathFile_Ori_MappingData = Application.StartupPath + @"\Config\Ori_MappingData.csv";

        

        /// <summary>
        /// 自动Mapping后数据
        /// </summary>
        public static string PathFile_MappingData = @"D:\Program Files\ThisEquipment\Database\HwParameter\MappingData.csv";

        /// <summary>
        /// 自动Mapping后记录数据文件夹
        /// </summary>
        public static string PathFile_Check_MappingData = @"D:\Log\AxisData\Check_MappingData";

        /// <summary>
        /// 自动Mapping参数
        /// </summary>
        public static Class_Parameter_Mapping Para;

        /// <summary>
        /// 找到的点
        /// </summary>
        public static int Find_ID = -1;



        #endregion


        #region 定义类所使用的方法，可以给用户界面及自动程序调用
        /// <summary>
        ///     获取AxisMapping数据
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns>AxisMapping数据集合</returns>
        public static List<Each_Mapping_Point> Get_MappingData_From_Database()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM PointPosition ");
            DataSet ds = MappingDBUtil.Query(strSql.ToString());
            List<Each_Mapping_Point> axisMappings = new List<Each_Mapping_Point>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Each_Mapping_Point Each_Mapping_Point_temp = new Each_Mapping_Point();

                    Each_Mapping_Point_temp.ID = (!ds.Tables[0].Rows[i].IsNull("Point")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Point"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XDownYDown.Mapping_Corrector_Data.X = (!ds.Tables[0].Rows[i].IsNull("Correct_XDownYDown_X")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Correct_XDownYDown_X"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XDownYDown.Mapping_Corrector_Data.Y = (!ds.Tables[0].Rows[i].IsNull("Correct_XDownYDown_Y")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Correct_XDownYDown_Y"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XUpYDown.Mapping_Corrector_Data.X = (!ds.Tables[0].Rows[i].IsNull("Correct_XUpYDown_X")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Correct_XUpYDown_X"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XUpYDown.Mapping_Corrector_Data.Y = (!ds.Tables[0].Rows[i].IsNull("Correct_XUpYDown_Y")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Correct_XUpYDown_Y"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XDownYUp.Mapping_Corrector_Data.X = (!ds.Tables[0].Rows[i].IsNull("Correct_XDownYUp_X")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Correct_XDownYUp_X"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XDownYUp.Mapping_Corrector_Data.Y = (!ds.Tables[0].Rows[i].IsNull("Correct_XDownYUp_Y")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Correct_XDownYUp_Y"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XUpYUp.Mapping_Corrector_Data.X = (!ds.Tables[0].Rows[i].IsNull("Correct_XUpYUp_X")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Correct_XUpYUp_X"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XUpYUp.Mapping_Corrector_Data.Y = (!ds.Tables[0].Rows[i].IsNull("Correct_XUpYUp_Y")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Correct_XUpYUp_Y"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XDownYDown.Mapping_Axis_Data.X = (!ds.Tables[0].Rows[i].IsNull("Axis_XDownYDown_X")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Axis_XDownYDown_X"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XDownYDown.Mapping_Axis_Data.Y = (!ds.Tables[0].Rows[i].IsNull("Axis_XDownYDown_Y")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Axis_XDownYDown_Y"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XUpYDown.Mapping_Axis_Data.X = (!ds.Tables[0].Rows[i].IsNull("Axis_XUpYDown_X")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Axis_XUpYDown_X"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XUpYDown.Mapping_Axis_Data.Y = (!ds.Tables[0].Rows[i].IsNull("Axis_XUpYDown_Y")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Axis_XUpYDown_Y"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XDownYUp.Mapping_Axis_Data.X = (!ds.Tables[0].Rows[i].IsNull("Axis_XDownYUp_X")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Axis_XDownYUp_X"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XDownYUp.Mapping_Axis_Data.Y = (!ds.Tables[0].Rows[i].IsNull("Axis_XDownYUp_Y")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Axis_XDownYUp_Y"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XUpYUp.Mapping_Axis_Data.X = (!ds.Tables[0].Rows[i].IsNull("Axis_XUpYUp_X")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Axis_XUpYUp_X"]) : 0;
                    Each_Mapping_Point_temp.Mapping_XUpYUp.Mapping_Axis_Data.Y = (!ds.Tables[0].Rows[i].IsNull("Axis_XUpYUp_Y")) ? Convert.ToInt32(ds.Tables[0].Rows[i]["Axis_XUpYUp_Y"]) : 0;
                    axisMappings.Add(Each_Mapping_Point_temp);
                     
                }
            }
            return axisMappings;

        }
        /// <summary>
        /// 通过文件读取mapping原始数据
        /// </summary>
        /// <param name="PathFile"></param>
        /// <returns></returns>
        public static List<Each_Mapping_Point> Get_MappingData_From_CSV(string PathFile)
        {
            string[] dd = null;
            long _size = GetFileSize(PathFile);  //65536
            System.IO.FileStream fs = File.OpenRead(PathFile);   // 读取文件内容  
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
            List<Each_Mapping_Point> Mapping_Input_List = new List<Each_Mapping_Point>();
            for (int i = 0; i < dd.Length; i++)
            {
                string[] data = dd[i].Split(',');
                Each_Mapping_Point Each_Mapping_Input = new Each_Mapping_Point();
                Each_Mapping_Input.ID = Convert.ToInt32(Convert.ToDouble(data[0]));
                Each_Mapping_Input.Mapping_XDownYDown.Mapping_Corrector_Data.X = Convert.ToInt32(Convert.ToDouble(data[1]));
                Each_Mapping_Input.Mapping_XDownYDown.Mapping_Corrector_Data.Y = Convert.ToInt32(Convert.ToDouble(data[2]));
                Each_Mapping_Input.Mapping_XUpYDown.Mapping_Corrector_Data.X = Convert.ToInt32(Convert.ToDouble(data[3]));
                Each_Mapping_Input.Mapping_XUpYDown.Mapping_Corrector_Data.Y = Convert.ToInt32(Convert.ToDouble(data[4]));

                Each_Mapping_Input.Mapping_XDownYUp.Mapping_Corrector_Data.X = Convert.ToInt32(Convert.ToDouble(data[5]));
                Each_Mapping_Input.Mapping_XDownYUp.Mapping_Corrector_Data.Y = Convert.ToInt32(Convert.ToDouble(data[6]));
                Each_Mapping_Input.Mapping_XUpYUp.Mapping_Corrector_Data.X = Convert.ToInt32(Convert.ToDouble(data[7]));
                Each_Mapping_Input.Mapping_XUpYUp.Mapping_Corrector_Data.Y = Convert.ToInt32(Convert.ToDouble(data[8]));

                Each_Mapping_Input.Mapping_XDownYDown.Mapping_Axis_Data.X = Convert.ToInt32(Convert.ToDouble(data[9]));
                Each_Mapping_Input.Mapping_XDownYDown.Mapping_Axis_Data.Y = Convert.ToInt32(Convert.ToDouble(data[10]));
                Each_Mapping_Input.Mapping_XUpYDown.Mapping_Axis_Data.X = Convert.ToInt32(Convert.ToDouble(data[11]));
                Each_Mapping_Input.Mapping_XUpYDown.Mapping_Axis_Data.Y = Convert.ToInt32(Convert.ToDouble(data[12]));

                Each_Mapping_Input.Mapping_XDownYUp.Mapping_Axis_Data.X = Convert.ToInt32(Convert.ToDouble(data[13]));
                Each_Mapping_Input.Mapping_XDownYUp.Mapping_Axis_Data.Y = Convert.ToInt32(Convert.ToDouble(data[14]));
                Each_Mapping_Input.Mapping_XUpYUp.Mapping_Axis_Data.X = Convert.ToInt32(Convert.ToDouble(data[15]));
                Each_Mapping_Input.Mapping_XUpYUp.Mapping_Axis_Data.Y = Convert.ToInt32(Convert.ToDouble(data[16]));


                
                Mapping_Input_List.Add(Each_Mapping_Input);
            }
            return Mapping_Input_List;

        }


        /// <summary>
        /// //通过校正板的坐标，找到机械坐标的位置
        /// </summary>
        /// <param name="Used"></param>
        /// <param name="Para"></param>
        /// <param name="Search_Correct_Point"></param>
        /// <returns></returns>
        public static myPoint CorrectAxisData(bool Used, Class_Parameter_Mapping Para,myPoint Search_Correct_Point, List<Each_Mapping_Point> Searched_Point_List)
        {

            Find_ID = -1;
            if (Used)
            {
                //在上下限范围内
                if ((Search_Correct_Point.X >= Para.strXDown & Search_Correct_Point.X < Para.strXUp & Search_Correct_Point.Y >= Para.strYDown & Search_Correct_Point.Y < Para.strYUp))
                {
                    //计算mapping位置
                    int X_Position = Search_Correct_Point.X / Para.XUnit;
                    int Y_Position = Search_Correct_Point.Y / Para.YUnit;
                    int Mapping_Position = Y_Position * (Para.strXUp / Para.XUnit) + X_Position;
                    Find_ID = Mapping_Position;
                    //找到点位
                    Each_Mapping_Point Searched_Point = Searched_Point_List[Mapping_Position];



                    //求输入点在X，Y轴的比例
                    int X_scale = (Search_Correct_Point.X - Searched_Point.Mapping_XDownYDown.Mapping_Corrector_Data.X) * 1000 / (Searched_Point.Mapping_XUpYDown.Mapping_Corrector_Data.X - Searched_Point.Mapping_XDownYDown.Mapping_Corrector_Data.X);
                    int Y_scale = (Search_Correct_Point.Y - Searched_Point.Mapping_XDownYDown.Mapping_Corrector_Data.Y) * 1000 / (Searched_Point.Mapping_XDownYUp.Mapping_Corrector_Data.Y - Searched_Point.Mapping_XDownYDown.Mapping_Corrector_Data.Y);

                    //求输入点在轴位置中的点
                    myPoint P1 = new myPoint();
                    myPoint P2 = new myPoint();
                    myPoint P3 = new myPoint();
                    myPoint P4 = new myPoint();
                    myPoint Result_Point = new myPoint();
                    //下点
                    P1.X = (Searched_Point.Mapping_XUpYDown.Mapping_Axis_Data.X - Searched_Point.Mapping_XDownYDown.Mapping_Axis_Data.X) * X_scale / 1000 + Searched_Point.Mapping_XDownYDown.Mapping_Axis_Data.X;
                    P1.Y = (Searched_Point.Mapping_XUpYDown.Mapping_Axis_Data.Y - Searched_Point.Mapping_XDownYDown.Mapping_Axis_Data.Y) * X_scale / 1000 + Searched_Point.Mapping_XDownYDown.Mapping_Axis_Data.Y;
                    //上点
                    P4.X = (Searched_Point.Mapping_XUpYUp.Mapping_Axis_Data.X - Searched_Point.Mapping_XDownYUp.Mapping_Axis_Data.X) * X_scale / 1000 + Searched_Point.Mapping_XDownYUp.Mapping_Axis_Data.X;
                    P4.Y = (Searched_Point.Mapping_XUpYUp.Mapping_Axis_Data.Y - Searched_Point.Mapping_XDownYUp.Mapping_Axis_Data.Y) * X_scale / 1000 + Searched_Point.Mapping_XDownYUp.Mapping_Axis_Data.Y;
                    //左点
                    P2.X = (Searched_Point.Mapping_XDownYUp.Mapping_Axis_Data.X - Searched_Point.Mapping_XDownYDown.Mapping_Axis_Data.X) * Y_scale / 1000 + Searched_Point.Mapping_XDownYDown.Mapping_Axis_Data.X;
                    P2.Y = (Searched_Point.Mapping_XDownYUp.Mapping_Axis_Data.Y - Searched_Point.Mapping_XDownYDown.Mapping_Axis_Data.Y) * Y_scale / 1000 + Searched_Point.Mapping_XDownYDown.Mapping_Axis_Data.Y;
                    //右点
                    P3.X = (Searched_Point.Mapping_XUpYUp.Mapping_Axis_Data.X - Searched_Point.Mapping_XUpYDown.Mapping_Axis_Data.X) * Y_scale / 1000 + Searched_Point.Mapping_XUpYDown.Mapping_Axis_Data.X;
                    P3.Y = (Searched_Point.Mapping_XUpYUp.Mapping_Axis_Data.Y - Searched_Point.Mapping_XUpYDown.Mapping_Axis_Data.Y) * Y_scale / 1000 + Searched_Point.Mapping_XUpYDown.Mapping_Axis_Data.Y;

                    Result_Point = getCrossPoint(P1, P2, P3, P4);

                    return Result_Point;
                }
                else if (Search_Correct_Point.X == Para.strXUp & (Search_Correct_Point.Y % Para.YUnit == 0) & (Search_Correct_Point.Y != Para.strYUp))
                {
                    int X_Position = Search_Correct_Point.X / Para.XUnit -1;
                    int Y_Position = Search_Correct_Point.Y / Para.YUnit;
                    int Mapping_Position = Y_Position * (Para.strXUp / Para.XUnit) + X_Position;
                    Find_ID = Mapping_Position;
                    Each_Mapping_Point Searched_Point = Searched_Point_List[Mapping_Position];
                    myPoint Result_Point = new myPoint();

                    Result_Point = Searched_Point.Mapping_XUpYDown.Mapping_Axis_Data;
                    return Result_Point;
                }
                else if (Search_Correct_Point.Y == Para.strYUp & (Search_Correct_Point.X % Para.XUnit == 0) & (Search_Correct_Point.X != Para.strXUp))
                {
                    int X_Position = Search_Correct_Point.X / Para.XUnit;
                    int Y_Position = Search_Correct_Point.Y / Para.YUnit - 1;
                    int Mapping_Position = Y_Position * (Para.strXUp / Para.XUnit) + X_Position;
                    Find_ID = Mapping_Position;
                    Each_Mapping_Point Searched_Point = Searched_Point_List[Mapping_Position];
                    myPoint Result_Point = new myPoint();

                    Result_Point = Searched_Point.Mapping_XDownYUp.Mapping_Axis_Data;
                    return Result_Point;
                }
                else if (Search_Correct_Point.Y == Para.strYUp  & (Search_Correct_Point.X == Para.strXUp))
                {
                    int X_Position = Search_Correct_Point.X / Para.XUnit - 1;
                    int Y_Position = Search_Correct_Point.Y / Para.YUnit - 1;
                    int Mapping_Position = Y_Position * (Para.strXUp / Para.XUnit) + X_Position;
                    Find_ID = Mapping_Position;
                    Each_Mapping_Point Searched_Point = Searched_Point_List[Mapping_Position];
                    myPoint Result_Point = new myPoint();

                    Result_Point = Searched_Point.Mapping_XUpYUp.Mapping_Axis_Data;
                    return Result_Point;
                }

                else
                {
                    return Search_Correct_Point;
                }
            }
            else
            {
                return Search_Correct_Point;
            }


            






        }

        /// <summary>
        /// //通过机械坐标，找到校正板的位置
        /// </summary>
        /// <param name="Used"></param>
        /// <param name="Para"></param>
        /// <param name="Search_Correct_Point"></param>
        /// <returns></returns>
        //public static myPoint AxisCorrectData(bool Used, Class_Parameter_Mapping Para, myPoint Search_Correct_Point, List<AxisMapping> Searched_Point_List)
        //{
           

        //    if (Used)
        //    {
        //        //在上下限范围内
        //        if ((Search_Correct_Point.X >= Para.strXDown & Search_Correct_Point.X <= Para.strXUp & Search_Correct_Point.Y >= Para.strYDown & Search_Correct_Point.Y <= Para.strYUp))
        //        {
        //            //计算mapping位置
        //            int X_Position = Search_Correct_Point.X / Para.XUnit;
        //            int Y_Position = Search_Correct_Point.Y / Para.YUnit;
        //            int Mapping_Position = X_Position * (Para.strXUp / Para.XUnit) + Y_Position;
        //            //List<AxisMapping> Searched_Point_List = GetMappingDataToAxisMapping();
        //            AxisMapping Searched_Point = Searched_Point_List[Mapping_Position];

        //            //求输入点在X，Y轴的比例
        //            int X_scale = (Search_Correct_Point.X - Searched_Point.Axis_XDownYDown_X) / (Searched_Point.Axis_XUpYDown_X - Searched_Point.Axis_XDownYDown_X);
        //            int Y_scale = (Search_Correct_Point.Y - Searched_Point.Axis_XDownYDown_Y) / (Searched_Point.Axis_XDownYUp_Y - Searched_Point.Axis_XDownYDown_Y);

        //            //求输入点在轴位置中的点
        //            myPoint P1 = new myPoint();
        //            myPoint P2 = new myPoint();
        //            myPoint P3 = new myPoint();
        //            myPoint P4 = new myPoint();
        //            myPoint Result_Point = new myPoint();
        //            //下点
        //            P1.X = (Searched_Point.Axis_XUpYDown_X - Searched_Point.Axis_XDownYDown_X) * X_scale + Searched_Point.Axis_XDownYDown_X;
        //            P1.Y = (Searched_Point.Axis_XUpYDown_Y - Searched_Point.Axis_XDownYDown_Y) * X_scale + Searched_Point.Axis_XDownYDown_Y;
        //            //上点
        //            P4.X = (Searched_Point.Axis_XUpYUp_X - Searched_Point.Axis_XDownYUp_X) * X_scale + Searched_Point.Axis_XDownYUp_X;
        //            P4.Y = (Searched_Point.Axis_XUpYUp_Y - Searched_Point.Axis_XDownYUp_Y) * X_scale + Searched_Point.Axis_XDownYUp_Y;
        //            //左点
        //            P2.X = (Searched_Point.Axis_XDownYUp_X - Searched_Point.Axis_XDownYDown_X) * Y_scale + Searched_Point.Axis_XDownYDown_X;
        //            P2.Y = (Searched_Point.Axis_XDownYUp_Y - Searched_Point.Axis_XDownYDown_Y) * Y_scale + Searched_Point.Axis_XDownYDown_Y;
        //            //右点
        //            P3.X = (Searched_Point.Axis_XUpYUp_X - Searched_Point.Axis_XUpYDown_X) * Y_scale + Searched_Point.Axis_XUpYDown_X;
        //            P3.Y = (Searched_Point.Axis_XUpYUp_Y - Searched_Point.Axis_XUpYDown_Y) * Y_scale + Searched_Point.Axis_XUpYDown_Y;

        //            Result_Point = getCrossPoint(P1, P2, P3, P4);

        //            return Result_Point;
        //        }
        //        else
        //        {
        //            return Search_Correct_Point;
        //        }
        //    }
        //    else
        //    {
        //        return Search_Correct_Point;
        //    }








           
        //}


        /// <summary>
        /// 通过文件读取mapping原始数据
        /// </summary>
        /// <param name="PathFile"></param>
        /// <returns></returns>
        public static List<Each_Ori_Mapping_Point> Read_Origion_Mapping_Data(string PathFile)
        {
            string[] dd = null;
            long _size = GetFileSize(PathFile);  //65536
            System.IO.FileStream fs = File.OpenRead(PathFile);   // 读取文件内容  
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
            List<Each_Ori_Mapping_Point> Mapping_Input_List = new List<Each_Ori_Mapping_Point>();
            for (int i = 0; i < dd.Length; i++)
            {
                string[] data = dd[i].Split(',');
                Each_Ori_Mapping_Point Mapping_Input = new Each_Ori_Mapping_Point();
                Mapping_Input.ID = Convert.ToInt32(Convert.ToDouble(data[0]));
                Mapping_Input.Mapping_Corrector_Data.X = Convert.ToInt32(Convert.ToDouble(data[1]));
                Mapping_Input.Mapping_Corrector_Data.Y = Convert.ToInt32(Convert.ToDouble(data[2]));
                Mapping_Input.Mapping_Axis_Data.X = Convert.ToInt32(Convert.ToDouble(data[3]));
                Mapping_Input.Mapping_Axis_Data.Y = Convert.ToInt32(Convert.ToDouble(data[4]));
                Mapping_Input_List.Add(Mapping_Input);
            }
            return Mapping_Input_List;

        }
        
       
        /// <summary>
        /// 将找到的点写入文件
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="PathFile"></param>
        public static void Write_Mapping_OutputData(Class_Parameter_Mapping Para,List<Each_Ori_Mapping_Point> Mapping_Input_List, string PathFile)
        {

            myPoint Search_Point;
            Each_Mapping_Point Finded_Rectangle;
            List<Each_Mapping_Point> Finded_Rectangle_List = new List<Each_Mapping_Point>();
            for (int j = 0; Para.YUnit * j < Para.strYUp; j++)
            {
                for (int i = 0; Para.XUnit * i < Para.strXUp; i++)
               {
             
                    Search_Point = new myPoint();
                    Finded_Rectangle = new Each_Mapping_Point();
                    Search_Point.X = Para.XUnit * i;
                    Search_Point.Y = Para.XUnit * j;
                    Finded_Rectangle = Find_Mapping_Data(Search_Point, Para, Mapping_Input_List);

                    Finded_Rectangle_List.Add(Finded_Rectangle);


                }

            }
            string CSV_msg = "";
            for (int i = 0; i < Finded_Rectangle_List.Count(); i++)
            {
                CSV_msg = CSV_msg +
                     i.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XDownYDown.Mapping_Corrector_Data.X.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XDownYDown.Mapping_Corrector_Data.Y.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XDownYUp.Mapping_Corrector_Data.X.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XDownYUp.Mapping_Corrector_Data.Y.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XUpYDown.Mapping_Corrector_Data.X.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XUpYDown.Mapping_Corrector_Data.Y.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XUpYUp.Mapping_Corrector_Data.X.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XUpYUp.Mapping_Corrector_Data.Y.ToString("0") + "," +

                     Finded_Rectangle_List[i].Mapping_XDownYDown.Mapping_Axis_Data.X.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XDownYDown.Mapping_Axis_Data.Y.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XDownYUp.Mapping_Axis_Data.X.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XDownYUp.Mapping_Axis_Data.Y.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XUpYDown.Mapping_Axis_Data.X.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XUpYDown.Mapping_Axis_Data.Y.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XUpYUp.Mapping_Axis_Data.X.ToString("0") + "," +
                     Finded_Rectangle_List[i].Mapping_XUpYUp.Mapping_Axis_Data.Y.ToString("0")
                     + "\r\n";
            }
            //写入CSV
            WriteCSV(CSV_msg, PathFile);
        }


        /// <summary>
        /// 通过输入点和参数找出四个矩阵点
        /// </summary>
        /// <param name="Input_Point"></param>
        /// <param name="Para"></param>
        /// <param name="Mapping_Input_List"></param>
        /// <returns></returns>
        public static Each_Mapping_Point Find_Mapping_Data(myPoint Input_Point, Class_Parameter_Mapping Para, List<Each_Ori_Mapping_Point> Mapping_Input_List)
        {
            Each_Mapping_Point Search_Point = new Each_Mapping_Point();// 
            bool Search1_Ok = false, Search2_Ok = false, Search3_Ok = false, Search4_Ok = false;
            for (int i = 0; i < Mapping_Input_List.Count; i++)
            {

                //找到左下点
                if ((Input_Point.X == Mapping_Input_List[i].Mapping_Corrector_Data.X) & (Input_Point.Y == Mapping_Input_List[i].Mapping_Corrector_Data.Y))
                {
                    Search_Point.Mapping_XDownYDown = Mapping_Input_List[i];
                    Search1_Ok = true;

                }
                //找到右下点
                if (((Input_Point.X + Para.XUnit) == Mapping_Input_List[i].Mapping_Corrector_Data.X) & (Input_Point.Y == (Mapping_Input_List[i].Mapping_Corrector_Data.Y)))
                {
                    Search_Point.Mapping_XDownYUp = Mapping_Input_List[i];
                    Search2_Ok = true;
                }
                //找到左上点
                if ((Input_Point.X == Mapping_Input_List[i].Mapping_Corrector_Data.X) & ((Input_Point.Y + Para.YUnit) == Mapping_Input_List[i].Mapping_Corrector_Data.Y))
                {
                    Search_Point.Mapping_XUpYDown = Mapping_Input_List[i];
                    Search3_Ok = true;

                }
                //找到右上点
                if (((Input_Point.X + Para.XUnit) == Mapping_Input_List[i].Mapping_Corrector_Data.X) & ((Input_Point.Y + Para.YUnit) == (Mapping_Input_List[i].Mapping_Corrector_Data.Y)))
                {
                    Search_Point.Mapping_XUpYUp = Mapping_Input_List[i];
                    Search4_Ok = true;
                }



            }
            //结果正确
            if (Search1_Ok & Search2_Ok & Search3_Ok & Search4_Ok)
            {


            }
            else
            {
                MessageBox.Show("没找到点");

            }
            return Search_Point;
        }

        /// <summary>
        /// 将自动Mapping的原始数据写入文件
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="PathFile"></param>
        public static void Write_Ori_MappingData(List<Each_Ori_Mapping_Point> Ori_Mapping_Input_List, string PathFile)
        {     
            string CSV_msg = "";
            for (int i = 0; i < Ori_Mapping_Input_List.Count(); i++)
            {
                CSV_msg = CSV_msg +
                     Ori_Mapping_Input_List[i].ID.ToString("0") + "," +
                     Ori_Mapping_Input_List[i].Mapping_Corrector_Data.X.ToString("0") + "," +
                     Ori_Mapping_Input_List[i].Mapping_Corrector_Data.Y.ToString("0") + "," +
                     Ori_Mapping_Input_List[i].Mapping_Axis_Data.X.ToString("0") + "," +
                     Ori_Mapping_Input_List[i].Mapping_Axis_Data.Y.ToString("0") + "," +                 
                     "\r\n";
            }
            //写入CSV
            WriteCSV(CSV_msg, PathFile);
        }

        /// <summary>
        /// 将Mapping Check数据写入文件
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="PathFile"></param>
        public static void Write_Mapping_Check_Point(List<Mapping_Check_Point> Mapping_Check_Point_List, string PathFile)
        {
            string CSV_msg = "";
            for (int i = 0; i < Mapping_Check_Point_List.Count(); i++)
            {
                CSV_msg = CSV_msg +
                     Mapping_Check_Point_List[i].ID.ToString("0") + "," +
                     Mapping_Check_Point_List[i].Check_Axis_Data.X.ToString("0") + "," +
                     Mapping_Check_Point_List[i].Check_Axis_Data.Y.ToString("0") + "," +
                     Mapping_Check_Point_List[i].Check_CCD_Data.X.ToString("0") + "," +
                     Mapping_Check_Point_List[i].Check_CCD_Data.Y.ToString("0") + "," +
                     "\r\n";
            }
            //写入CSV
            WriteData(CSV_msg, PathFile);
        }

        /// <summary>
        /// 判断文件大小
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

        private static object lockstate1 = new object(); //定义一个空对象用来加锁

        /// <summary>
        /// 写runlog方法
        /// </summary>
        /// <param name="contents">写入内容</param>
        /// <param name="pathStr">文件路径</param>
        /// <param name="headLine">文件头</param>
        /// <returns></returns>
        public static bool WriteCSV(string contents,string PathFile)
        {
            
            lock (lockstate1)
            {
                try
                {
                    if (File.Exists(PathFile))
                    {
                        File.Delete(PathFile);
                    }
                   //写CSV                 
                    contents = contents + "\r\n";
                    File.AppendAllText(PathFile, contents);

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
        /// <summary>
        /// 写数据方法
        /// </summary>
        private static object lockstate2 = new object(); //定义一个空对象用来加锁
        public static bool WriteData(string contents, string pathStr)  
        {
            lock (lockstate2)
            {
                try
                {
                    if (!Directory.Exists(pathStr))
                    {
                        Directory.CreateDirectory(pathStr);
                    }
                    pathStr = pathStr + @"\" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".csv";
                                      
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

        /// <summary>
        /// 判断第一个点 与 第四个点所连直线 与 第2个点和第3个点 所连直线的交点
        /// </summary>
        /// <param name="point1">左下角点</param>
        /// <param name="point2">右下角点</param>
        /// <param name="point3">左上角点</param>
        /// <param name="point4">右上角</param>
        /// <returns></returns>
        public static myPoint getCrossPoint(myPoint  point1, myPoint  point2, myPoint  point3, myPoint  point4)
        {
            myPoint a = new myPoint();
            Double pD_x = Convert.ToDouble(point1.X);
            Double pD_y = Convert.ToDouble(point1.Y);
            Double pA_x = Convert.ToDouble(point2.X);
            Double pA_y = Convert.ToDouble(point2.Y);

            Double pC_x = Convert.ToDouble(point3.X);
            Double pC_y = Convert.ToDouble(point3.Y);
            Double pB_x = Convert.ToDouble(point4.X);
            Double pB_y = Convert.ToDouble(point4.Y);

            Double k_y = (pB_x * pC_y * pD_y - pD_x * pB_y * pC_y - pA_y * pB_x * pD_y + pD_x * pB_y * pA_y + pC_x * pA_y * pD_y - pA_x * pC_y * pD_y - pC_x * pB_y * pA_y + pA_x * pB_y * pC_y) /
                (pD_y * pC_x - pA_x * pD_y - pB_y * pC_x + pA_x * pB_y + pB_x * pC_y - pD_x * pC_y - pA_y * pB_x + pA_y * pD_x);

            Double k_x = (pD_y * (pC_x - pA_x) * (pB_x - pD_x) - pA_y * (pC_x - pA_x) * (pB_x - pD_x) + pA_x * (pC_y - pA_y) * (pB_x - pD_x) + pD_x * (pD_y - pB_y) * (pC_x - pA_x)) /
                ((pC_y - pA_y) * (pB_x - pD_x) + (pD_y - pB_y) * (pC_x - pA_x));
            a.X = Convert.ToInt32(k_x);
            a.Y = Convert.ToInt32(k_y);
            return a;
        }

        /// <summary> 
        /// 判断当前位置是否在不规则形状里面 
        /// </summary> 
        /// <param name="nvert">不规则形状的定点数</param> 
        /// <param name="vertx">当前x坐标</param> 
        /// <param name="verty">当前y坐标</param> 
        /// <param name="testx">不规则形状x坐标集合</param> 
        /// <param name="testy">不规则形状y坐标集合</param> 
        /// <returns></returns> 
        public static bool PositionPnpoly(List<double> vertx, List<double> verty, myPoint P)
        {
            int i, j, c = 0;
            for (i = 0, j = 4 - 1; i < 4; j = i++)
            {
                if (((verty[i] > P.Y) != (verty[j] > P.Y)) && (P.X < (vertx[j] - vertx[i]) * (P.Y - verty[i]) / (verty[j] - verty[i]) + vertx[i]))
                {
                    c = 1 + c; ;
                }
            }
            if (c % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
    #region 定义此类所使用的辅助方法 
    public class MappingDBUtil
    {
        public static string dbName = "MappingData.db";
        public static string dbPassword = "123456";
        static string thispath = @"D:\Program Files\ThisEquipment\Database\HwParameter";
        public static string _connectionString = "Data Source=" + thispath + "\\" + dbName + ";password=" + dbPassword;
        public static SQLiteConnection _connection = new SQLiteConnection(_connectionString);


        public MappingDBUtil()
        {
           
        }


        /// <summary>
        /// Connection DB
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection conn = null;
            string strSQLiteDB = Environment.CurrentDirectory;
            try
            {
                string dbPath = "Data Source=" + strSQLiteDB + "\\" + dbName;
                conn = new SQLiteConnection(dbPath);
                conn.SetPassword(dbPassword);
                conn.Open();
                
            }
            catch (Exception ex)
            {
                CloseDB(conn);
                
            }
            return conn;
        }

        /// <summary>
        /// Close DB
        /// </summary>
        /// <param name="conn"></param>
        public static void CloseDB(SQLiteConnection conn)
        {
            if (conn.State == ConnectionState.Connecting)
            {
                try
                {
                    conn.Close();
                    SQLiteConnection.ClearAllPools();
                }
                catch (System.Exception ex)
                {
                   
                }
            }
        }



        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
      
            {
                DataSet ds = new DataSet();
                try
                {
                    if (_connection.State != ConnectionState.Open)
                        _connection.Open();
                    
                    SQLiteDataAdapter command = new SQLiteDataAdapter(SQLString, _connection);
                    command.Fill(ds, "ds");
                   
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                 
                }
                return ds;
            }
        }


    }
    public class Mapping_Log
    {

        public const string path_log_RunState = @"D:\Log\MappingOutput";    //运行记录
        private static object lockstate = new object(); //定义一个空对象用来加锁



        internal void CreateDir(object pdcaPath)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 输出文件记录
        /// </summary>
        /// <param name="contents">保存文件内容</param>
        /// <param name="headLine">列标题，主要用于输出数据表</param>
        /// <param name="pathStr">保存文件路径</param>
        /// <param name="suffix">后缀名</param>
        /// <returns></returns>
        public bool WriteLog(string contents)   
        {
            string pathStr = "";
            lock (lockstate)
            {
                try
                {

                    if (true)
                    {
                        pathStr = path_log_RunState;
                    }

                    if (!Directory.Exists(pathStr))
                    {
                        Directory.CreateDirectory(pathStr);
                    }
                    pathStr = pathStr + @"\" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";
                    contents = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff| ") + contents + "\r\n";
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



    }

    #endregion

}
