using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace VISION_CVX
{
    class CAPI_CVX
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileInt")]
        public static extern int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault, string lpFileName);


        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        public static extern int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString, string lpFileName);

        
        
    }
    class modINI_CVX<T>
        {
            public static string strFileName = Application.StartupPath + @"\Config\CVX.ini" ;
        
            //从INI文件中读出字符串格式的值
            private static int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString)
            {
                return CAPI_CVX.GetPrivateProfileString(lpSectionName, lpKeyName, lpDefault, lpReturnedString, 255, strFileName);
            }
            //从INI文件中读出整型格式的值
            private static int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault)
            {
                return CAPI_CVX.GetPrivateProfileInt(lpSectionName, lpKeyName, lpDefault, strFileName);
            }
            //从向INI文件中写入字符串格式的值
            private static int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString)
            {
                return CAPI_CVX.WritePrivateProfileString(lpSectionName, lpKeyName, lpString, strFileName);
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
    
    
    public class Class_Parameter_CVX
    {
        //参数设置只允许有三种类型，double，int，string
        //string 类型的参数需要在构造函数里初始化


       
        
        public string ProjectFuction;
        public string RecipeFuction;
        public string IP;
        public int Port;

        public double hv_HomMat2D_Para1;
        public double hv_HomMat2D_Para2;
        public double hv_HomMat2D_Para3;
        public double hv_HomMat2D_Para4;
        public double hv_HomMat2D_Para5;
        public double hv_HomMat2D_Para6;




        public Class_Parameter_CVX()
        {
            ProjectFuction = "";
            RecipeFuction = "";

            IP = "";
            Port = 8500;

            hv_HomMat2D_Para1 = 0;
            hv_HomMat2D_Para2 = 0;
            hv_HomMat2D_Para3 = 0;
            hv_HomMat2D_Para4 = 0;
            hv_HomMat2D_Para5 = 0;
            hv_HomMat2D_Para6 = 0;


        }
    }

}

