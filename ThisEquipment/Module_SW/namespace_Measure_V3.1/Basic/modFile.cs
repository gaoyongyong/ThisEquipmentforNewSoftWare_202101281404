/*====================================功能==========================================
创建/读写常用的txt、csv文件
创建/删除文件和文件夹

=====================================更新记录==========================================
修改日期：2016-03-10
更新内容：

=====================================使用说明=========================================
1.先创建对象
2.常用writeLog函数,记录机台运行记录（根据日期每天创建一个文件）

     
=======================================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;


namespace Measure
{

    public class Measurelog
    {

        public static string path_log_Data = @"D:\Log\Data";         //Data



        private static object lockstate = new object(); //定义一个空对象用来加锁





        public bool WriteData(string contents, string headLine ,string pathStr)   //按每天建立一个log.csv文件
        {
            lock (lockstate)
            {
                try
                {
                    if (!Directory.Exists(pathStr))
                    {
                        Directory.CreateDirectory(pathStr);
                    }
                    pathStr = pathStr + @"\" + DateTime.Now.Date.ToString("yyyyMMdd") + ".csv";
                    if (!File.Exists(pathStr))
                    {
                        File.AppendAllText(pathStr, headLine + "\r\n");  //数据列标题
                    }
                    //else
                    //{
                        contents = contents + "\r\n";
                        File.AppendAllText(pathStr, contents);
                    //}
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
}
