using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ToolBars
{
    class IniUtils
    {
        private string fileName;
        private string appName;
        private string keyName;
        private string keyValue;

        /// <remarks>区域</remarks>
        public string AppName
        {
            get
            {
                return appName;
            }
            set
            {
                appName = value;
            }
        }

        /// <remarks>文件路径</remarks>
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        /// <remarks>Key名称</remarks>
        public string KeyName
        {
            get
            {
                return keyName;
            }
            set
            {
                keyName = value;
            }
        }

        /// <remarks>Key值</remarks>
        public string KeyValue
        {
            get
            {
                return keyValue;
            }
            set
            {
                keyValue = value;
            }
        }



        /********************************写INI**************************************/
        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileStringA(string lpApplicationName, string lpKeyName, string lpDefault_
            , StringBuilder retVal, uint nSize, string lpFileName);
        public void CreateInI(string FileName, string AppName, string Keyname, string Value)
        {
            string strFileName;
            strFileName = Application.StartupPath + @"\Config\" + FileName; 
            uint returnv = WritePrivateProfileStringA(AppName, Keyname, Value, strFileName);
        }
        /********************************读INI**************************************/
        [DllImport("kernel32.dll")]
        public static extern uint WritePrivateProfileStringA(string lpApplicationName, string lpKeyName, string lpString
            , string lpFileName);
        public string ReadInI(string FileName, string AppName, string Keyname)
        {
            string strFileName;
            strFileName = Application.StartupPath + @"\Config\" + FileName;
            StringBuilder temp = new StringBuilder(255);
            uint returnv = GetPrivateProfileStringA(AppName, Keyname, "0.1", temp, 255, strFileName);
            return temp.ToString();
        }
    }
}
