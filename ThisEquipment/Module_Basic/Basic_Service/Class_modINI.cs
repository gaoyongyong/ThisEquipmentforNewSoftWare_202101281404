using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Parameter
{
    class CAPI
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileInt")]
        public static extern int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault, string lpFileName);


        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        public static extern int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll")]
        public static extern uint GetTickCount();
    }
    class modINI<T>
        {
        public static string strFileName = Dialog_ProjectChoose.ProjectChoose.strMyDBLoad + @"\MeasureData.ini";
        
            //从INI文件中读出字符串格式的值
            private static int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString)
            {
                return CAPI.GetPrivateProfileString(lpSectionName, lpKeyName, lpDefault, lpReturnedString, 255, strFileName);
            }
            //从INI文件中读出整型格式的值
            private static int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault)
            {
                return CAPI.GetPrivateProfileInt(lpSectionName, lpKeyName, lpDefault, strFileName);
            }
            //从向INI文件中写入字符串格式的值
            private static int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString)
            {
                return CAPI.WritePrivateProfileString(lpSectionName, lpKeyName, lpString, strFileName);
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
    class modbasicINI<T>
    {
        public static string strFileName = Application.StartupPath + @"\Config\Basic_Para.ini";

        //从INI文件中读出字符串格式的值
        private static int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString)
        {
            return CAPI.GetPrivateProfileString(lpSectionName, lpKeyName, lpDefault, lpReturnedString, 255, strFileName);
        }
        //从INI文件中读出整型格式的值
        private static int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault)
        {
            return CAPI.GetPrivateProfileInt(lpSectionName, lpKeyName, lpDefault, strFileName);
        }
        //从向INI文件中写入字符串格式的值
        private static int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString)
        {
            return CAPI.WritePrivateProfileString(lpSectionName, lpKeyName, lpString, strFileName);
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
    public class Class_ProjectChoose_Parameter
    {
        //参数设置只允许有三种类型，double，int，string
        //string 类型的参数需要在构造函数里初始化
        /// <summary>
        /// 设备运行模式：0=自动运行,1=打表，2=自动Mapping,3=自动运行后确认
        /// </summary>
        public int Machine_Mode;
        public string Project_Name;
        public string Project_Name_Number;
        public string SN;

        public int CCD_Project_Num;
        public int CCD_Waitting_Time;

        public string Result1Name;
        public string Result2Name;
        public string Result3Name;
        public string Result4Name;
        public string Result5Name;
        public string Result6Name;
        public string Result7Name;
        public string Result8Name;


        public int Result1Show;
        public int Result2Show;
        public int Result3Show;
        public int Result4Show;
        public int Result5Show;
        public int Result6Show;
        public int Result7Show;
        public int Result8Show;




        public Class_ProjectChoose_Parameter()
        {
            Machine_Mode = 0;
            Project_Name = "";
            Project_Name_Number = "";
            SN = "";
            Result1Name = "";
            Result2Name = "";
            Result3Name = "";
            Result4Name = "";
            Result5Name = "";
            Result6Name = "";
            Result7Name = "";
            Result8Name = "";


            Result1Show = 0;
            Result2Show = 0;
            Result3Show = 0;
            Result4Show = 0;
            Result5Show = 0;
            Result6Show = 0;
            Result7Show = 0;
            Result8Show = 0;

            CCD_Project_Num = 1;
            CCD_Waitting_Time = 500;
        }
    }
    public class Class_Basic_Parameter
    {
        //参数设置只允许有三种类型，double，int，string
        //string 类型的参数需要在构造函数里初始化


        public int Scanner_choice;
        public int Database_choice;
        
        public string Database_IP;
        public int Database_IP_Port;

        public int Sensor_choice;
        public int Double_Button_choice;

        public Class_Basic_Parameter()
        {
            Scanner_choice = 0;
            Database_choice = 0;
           
            Database_IP = "";
            Database_IP_Port = 0;

            Sensor_choice = 0;
            Double_Button_choice = 0;

            
            
        }
    }

}

