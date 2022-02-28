using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dialog_ProjectChoose
{
    class IniServices
    {

        /// <summary>
        /// INI文件路径
        /// </summary>
        public static string strFileName = Application.StartupPath + @"\Config\UserDefaultProject.ini";
        /// <summary>
        /// </summary>
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// </summary>
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileInt")]
        public static extern int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        public static extern int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString, string lpFileName);

        /// <summary>
        /// </summary>
        public static int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString)
        {
            return GetPrivateProfileString(lpSectionName, lpKeyName, lpDefault, lpReturnedString, 255, strFileName);
        }

        /// <summary>
        /// </summary>
        public static int GetPrivateProfileInt(string lpSectionName, string lpKeyName, int lpDefault)
        {
            return GetPrivateProfileInt(lpSectionName, lpKeyName, lpDefault, strFileName);
        }

        public static int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString)
        {
            return WritePrivateProfileString(lpSectionName, lpKeyName, lpString, strFileName);
        }

        /// <summary>
        /// 读取默认项目名称
        /// </summary>
        /// <returns></returns>
        public static string ReadDefaultPrjName()
        {

            try
            {
                File.Exists(strFileName);

                StringBuilder strDefualtPrjName = new StringBuilder();
                GetPrivateProfileString("UserDefaultProject", "DefaultProject", "200", strDefualtPrjName, 255, strFileName);
                string PrjName = strDefualtPrjName.ToString();
                return PrjName;
                
            }
            catch (Exception ex)
            {
                //Motorpara Mpara=new Motorpara();
                MessageBox.Show(ex.Message);
                return "";

            }


        }



        /// <summary>
        /// 写入默认项目名称
        /// </summary>
        /// <returns></returns>
        public static int WriteDefaultPrjName(string strName)
        {
            if (File.Exists(strFileName))
            {

                WritePrivateProfileString("UserDefaultProject", "DefaultProject", strName, strFileName);


                return 0;
            }
            else
            {
                return -1;
            }

        }
       

    }
}
