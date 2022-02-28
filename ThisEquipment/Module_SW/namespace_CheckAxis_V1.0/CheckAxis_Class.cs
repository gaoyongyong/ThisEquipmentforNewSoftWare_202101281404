using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace CheckAxis
{



    #region 数据类型
    /// <summary>
    /// CheckAxis资源包用到的数据类型
    /// </summary>
    public class CheckAxis_DataStyle
    {
        #region 定义功能块需要的类型
        public struct myPoint
        {
            private int x;
            [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
            public int X
            {
                get { return x; }
                set { x = value; }
            }

            public int Y;
        }

        /// <summary>
        /// Mapping 数据包括Mapping后每个小矩阵轴,校正板坐标点
        /// </summary>
        public struct Each_Mapping_Point
        {
            //每个小矩阵轴,校正板坐标点
            public Each_Ori_Mapping_Point Mapping_XDownYDown;
            public Each_Ori_Mapping_Point Mapping_XDownYUp;
            public Each_Ori_Mapping_Point Mapping_XUpYDown;
            public Each_Ori_Mapping_Point Mapping_XUpYUp;


        }
        /// <summary>
        /// //每个小矩阵轴坐标点
        /// </summary>
        public struct Each_Ori_Mapping_Point
        {

            public myPoint Mapping_Axis_Data;
            public myPoint Mapping_Corrector_Data;



        }
        /// <summary>
        /// 打表坐标点
        /// </summary>
        public struct Each_Ori_Check_Point
        {
            public int ID;
            public int Max_ID;
            public myPoint Check_Axis_Data;
            public myPoint Check_CCD_Data;



        }

        /// <summary>
        /// 轴和校正后坐标点
        /// </summary>
        public struct Mapping_Point
        {
            //每个小矩阵轴坐标点
            public Each_Mapping_Point Mapping_Axis;
            //每个小矩阵校正板坐标点
            public Each_Mapping_Point Mapping_Calibration;

            public bool Result;

        }
        #endregion

    }

    /// <summary>
    /// CheckAxis资源包用到的参数类型
    /// </summary>
    public class CheckAxis_Parameter
    {
        //参数设置只允许有三种类型，double，int，string
        //string 类型的参数需要在构造函数里初始化

        /// <summary>
        /// 轴选择 0:X轴 1:Y轴
        /// </summary>
        public int AxisChoice;
        public double Check_Count;

        public CheckAxis_Parameter()
        {
            AxisChoice = 0;
            Check_Count = 0;
        }
    }
    #endregion


    #region 静态方法
    //静态方法只能改名称

    /// <summary>
    /// 系统获取数据
    /// </summary>
    public class CAPI_CheckAxis
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileInt")]
        public static extern int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault, string lpFileName);


        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        public static extern int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString, string lpFileName);

        
        
    }
    /// <summary>
    /// 读INI文件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class modINI_CheckAxis<T>
        {
            public static string strFileName = @"D:\Program Files\ThisEquipment\Database\HwParameter\CheckAxis.ini";
        
            //从INI文件中读出字符串格式的值
            private static int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString)
            {
                return CAPI_CheckAxis.GetPrivateProfileString(lpSectionName, lpKeyName, lpDefault, lpReturnedString, 255, strFileName);
            }
            //从INI文件中读出整型格式的值
            private static int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault)
            {
                return CAPI_CheckAxis.GetPrivateProfileInt(lpSectionName, lpKeyName, lpDefault, strFileName);
            }
            //从向INI文件中写入字符串格式的值
            private static int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString)
            {
                return CAPI_CheckAxis.WritePrivateProfileString(lpSectionName, lpKeyName, lpString, strFileName);
            }

            public static string ReadINI(string keyName, string sectionName = "System")
            {
                if (!File.Exists(strFileName))
                {
                    MessageBox.Show("INI File lost!");
                    return "";
                }
                try
                {
                    StringBuilder strValue1 = new StringBuilder(50);
                    string strValue;
                    GetPrivateProfileString(sectionName, keyName, "0", strValue1);
                    strValue = strValue1.ToString();
                    return strValue;
                }
                catch
                {
                    return "";
                }
            }
            public static bool WriteINI(string keyName, string value, string sectionName = "System")
            {
                if (!File.Exists(strFileName))
                {
                    MessageBox.Show("INI File lost!");
                    return false;
                }
                try
                {
                    WritePrivateProfileString(sectionName, keyName, value);
                }
                catch
                {
                    return false;
                }
                return true;
            }

            //读INI文件
            public static bool ReadINI(ref T para1, string sectionName = "System")
            {
                if (!File.Exists(strFileName))
                {
                    MessageBox.Show("INI File lost!");
                    return false;
                }
                try
                {
                    foreach (FieldInfo fieldInfo in para1.GetType().GetFields())
                    {
                        StringBuilder strValue1 = new StringBuilder(50);
                        string strValue;
                        GetPrivateProfileString(sectionName, fieldInfo.Name, "0", strValue1);
                        strValue = strValue1.ToString();
                        object objN = fieldInfo.GetValue(para1);
                        if (fieldInfo.GetValue(para1) is int)
                            fieldInfo.SetValue(para1, Convert.ToInt32(strValue));
                        else if (fieldInfo.GetValue(para1) is double)
                            fieldInfo.SetValue(para1, Convert.ToDouble(strValue));
                        else if (fieldInfo.GetValue(para1) is string)
                            fieldInfo.SetValue(para1, strValue);
                    }
                }
                catch
                {
                    return false;
                }
                return true;
            }
            //向INI文件中写入参数
            public static bool WriteINI(T para1, string sectionName = "System")
            {
                if (!File.Exists(strFileName))
                {
                    MessageBox.Show("INI File lost!");
                    return false;
                }
                try
                {
                    foreach (FieldInfo fieldInfo in para1.GetType().GetFields())
                        WritePrivateProfileString(sectionName, fieldInfo.Name, fieldInfo.GetValue(para1).ToString());
                }
                catch
                {
                    return false;
                }
                return true;
            }


        }
    #endregion


    #region 非静态方法，需要实例化
    #endregion

}

