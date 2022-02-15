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

namespace UserCoord
{
    [Serializable]
    public class mod_UserCoord
    {
        #region 定义全局变量及其所需要的类
        /// <summary>
        /// 定义数据存储文件的位置
        /// </summary>
        
        public static string PathFile_CoordExchange = Application.StartupPath + @"\Config\CoordExchange";
        public static string PathFile_BasicCoord = Application.StartupPath + @"\Config\CoordExchange\BasicCoord.csv";
        public  string PathFile = Application.StartupPath + @"\Config\CoordExchange\BasicCoord.csv"; 




        #endregion


        //类初始化
        public mod_UserCoord()
        {
           
            //读取用户坐标系数据
            // BasicCoord_List = Read_Coord_Point_List(PathFile_BasicCoord);
        }

        #region 定义类所使用的方法，可以给用户界面及自动程序调用


        /// <summary>
        /// 读用户坐标系数据
        /// </summary>
        /// <param name="PathFile"></param>
        /// <returns></returns>
        public List<Coord_Point> Read_Coord_Point_List(string a1)
        {
            string PathFile = @"D:\Program Files\ThisEquipment\Database\HwParameter\BasicCoord.csv";
            List<Coord_Point> Coord_Point_List = new List<Coord_Point>();
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
            
            for (int i = 1; i < dd.Length; i++)
            {
                string[] data = dd[i].Split(',');
                Coord_Point Coord_Point_Input = new Coord_Point();
                Coord_Point_Input.ID = Convert.ToDouble(String.Format("{0:000000}", data[0]));
                Coord_Point_Input.X_Position = Convert.ToDouble(String.Format("{0:000000}", data[1]));
                Coord_Point_Input.Y_Position = Convert.ToDouble(String.Format("{0:000000}", data[2]));
                Coord_Point_Input.Z_Position = Convert.ToDouble(String.Format("{0:000000}", data[3]));
                Coord_Point_Input.R_Position = Convert.ToDouble(String.Format("{0:000000}", data[4]));
                Coord_Point_Input.X_Position = Convert.ToDouble(String.Format("{0:000000}", data[5]));
                Coord_Point_Input.Y_Position = Convert.ToDouble(String.Format("{0:000000}", data[6]));
                Coord_Point_Input.Z_Position = Convert.ToDouble(String.Format("{0:000000}", data[7]));
                Coord_Point_Input.R_Position = Convert.ToDouble(String.Format("{0:000000}", data[8]));

                Coord_Point_List.Add(Coord_Point_Input);

            }
            return Coord_Point_List;


        }


        public  List<Coord_Point>  Coord_Exchange(List<Coord_Point> Input_Basic_List, List<Coord_Point> Input_Product_List)
        {
            //输入User坐标系位置
            HTuple Basic_PO_X = new HTuple();
            HTuple Basic_PO_Y = new HTuple();
            //输入机械坐标系位置
            HTuple Basic_P1_X = new HTuple();
            HTuple Basic_P1_Y = new HTuple();
            //输出坐标角度
            HTuple Basic_Angle = new HTuple();

            //用户坐标系输入
            Basic_PO_X[0] = Input_Basic_List[0].X_Position;
            Basic_PO_Y[0] = Input_Basic_List[0].Y_Position;
            Basic_P1_X[0] = Input_Basic_List[1].X_Position;
            Basic_P1_Y[0] = Input_Basic_List[1].Y_Position;

            //输入产品坐标系位置
            HTuple Product_X = new HTuple();
            HTuple Product_Y = new HTuple();


            //定义输出坐标系
            HTuple Machine_X = new HTuple();
            HTuple Machine_Y = new HTuple();

            //产品坐标系输入
            for (int i=0;i< Input_Product_List.Count(); i++)
            {
                Product_X[i] = Input_Product_List[i].X_Position;
                Product_Y[i] = Input_Product_List[i].Y_Position;
            }

            //定义旋转矩阵
            HTuple HomMat2d = new HTuple();
            //初始化旋转矩阵
            HOperatorSet.HomMat2dIdentity(out HomMat2d);

            //计算角度
            HOperatorSet.AngleLx(Basic_PO_X, Basic_PO_Y, Basic_P1_X, Basic_P1_Y, out Basic_Angle);
            double Angle = Basic_Angle[0];

            //构建坐标系旋转
            HOperatorSet.VectorAngleToRigid(0, 0, 0, Basic_PO_X, Basic_PO_Y, Basic_Angle, out HomMat2d);

            //计算坐标系
            HOperatorSet.AffineTransPoint2d(HomMat2d, Product_X, Product_Y, out Machine_X, out Machine_Y);

            List<Coord_Point> Result_List = new List<Coord_Point>();
            for (int i = 0; i < Input_Product_List.Count(); i++)
            {
                Coord_Point Result = new Coord_Point();
                Result.ID = i;
                Result.X_Position = Machine_X[i];
                Result.Y_Position = Machine_Y[i];
                Result_List.Add(Result);
            }
            return Result_List;

        }
     
        /// <summary>
        /// 将输入的数据写入CSV中
        /// </summary>
        /// <param name="Input_Data_List"></param>
        public void Write_CoordData_To_CSV(List<Coord_Point> Input_Data_List)
        {
            string Contents = "";
            for (int i = 0; i < Input_Data_List.Count(); i++)
            {
                Contents = Contents +
                           Input_Data_List[i].ID.ToString("0") + "," +
                           Input_Data_List[i].X_Position.ToString("0.000") + "," +
                           Input_Data_List[i].Y_Position.ToString("0.000") + "," +
                           Input_Data_List[i].Z_Position.ToString("0.000") + "," +
                           Input_Data_List[i].R_Position.ToString("0.000") + "," +
                           Input_Data_List[i].X_Speed.ToString("0.000") + "," +
                           Input_Data_List[i].Y_Speed.ToString("0.000") + "," +
                           Input_Data_List[i].Z_Speed.ToString("0.000") + "," +
                           Input_Data_List[i].R_Speed.ToString("0.000") + "," +
                           "\r\n";               
            }
            WriteData(Contents);
        }

        /// <summary>
        /// 将输入的数据写入CSV中
        /// </summary>
        /// <param name="Input_Data_List"></param>
        public void Write_SingleCoordData_To_CSV(Coord_Point Input_Data_List)
        {
            
            
             string  Contents =
                           Input_Data_List.ID.ToString("0") + "," +
                           Input_Data_List.X_Position.ToString("0.000") + "," +
                           Input_Data_List.Y_Position.ToString("0.000") + "," +
                           Input_Data_List.Z_Position.ToString("0.000") + "," +
                           Input_Data_List.R_Position.ToString("0.000") + "," +
                           Input_Data_List.X_Speed.ToString("0.000") + "," +
                           Input_Data_List.Y_Speed.ToString("0.000") + "," +
                           Input_Data_List.Z_Speed.ToString("0.000") + "," +
                           Input_Data_List.R_Speed.ToString("0.000") + "," +
                            "\r\n";
            
            WriteData(Contents);
        }

        /// <summary>
        /// 输出文件记录
        /// </summary>
        /// <param name="contents">保存文件内容</param>
        /// <param name="headLine">列标题，主要用于输出数据表</param>
        /// <param name="pathStr">保存文件路径</param>
        /// <param name="suffix">后缀名</param>
        /// <returns></returns>
        public bool WriteLog(string contents)   //
        {
            string pathStr = "";
            lock (lockstate1)
            {
                try
                {
                    pathStr = PathFile_CoordExchange;
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
        private static bool WriteData(string contents)  
        {         
            lock (lockstate)
            {
                try
                {
                    CreateDir(PathFile_CoordExchange);
                    string pathStr = "";
                 
                    pathStr = PathFile_CoordExchange + @"\" +  DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".csv";
                  
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
