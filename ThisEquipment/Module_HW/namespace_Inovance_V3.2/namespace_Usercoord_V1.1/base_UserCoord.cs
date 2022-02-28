using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace UserCoord
{
   
    #region 静态方法
    //静态方法只能改名称

    /// <summary>
    /// 系统获取数据
    /// </summary>
    public class CAPI
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileInt")]
        public static extern int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault, string lpFileName);


        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        public static extern int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString, string lpFileName);

        
        
    }
  
    #endregion


    #region 非静态方法，需要实例化
    #endregion

}

