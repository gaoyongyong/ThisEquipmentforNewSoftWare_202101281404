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


namespace Log
{

    public class MainLog
    {

        public const string path_log_RunState = @"D:\Log\RunState";    //运行记录
        public const string path_log_CCD_Receive = @"D:\Log\CCD_Receive";    //运行记录



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
        public bool WriteLog(string contents, Color color)   //按每天建立一个log_runstate文件,根据不同的颜色选用不同的地址
        {
            string pathStr = "";

            try
            {

                lock (lockstate)
                {
                    if (true)
                    {
                        pathStr = path_log_RunState;
                    }
                    if (color == Color.Green)
                    {
                        pathStr = path_log_CCD_Receive;
                    }
                    if (!Directory.Exists(pathStr))
                    {
                        Directory.CreateDirectory(pathStr);
                    }
                    pathStr = pathStr + @"\" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";
                    //contents = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff| ") + contents + "\r\n";
                    contents = contents + "\r\n";
                    File.AppendAllText(pathStr, contents);
                    return true;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }



    }
}
