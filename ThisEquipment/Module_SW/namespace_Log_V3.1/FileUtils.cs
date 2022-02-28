using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Log
{
    class FileUtils
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("FileWRUtils");


        #region 打印日志到txt文件
        /// <summary>
        /// 打印日志到txt文件
        /// </summary>
        /// <param name="strLog">日志描述</param>
        public static void WriteLogToTxt(string strLog)
        {

            String System_Now_Time = null;
            String File_Create_Time = null;

            System_Now_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File_Create_Time = DateTime.Now.ToString("yyyyMMdd");
            string logDocument = File_Create_Time + ".txt";

            string str = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string logFilePath = str.Substring(0, str.LastIndexOf("\\")) + "\\Log";
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }
            logFilePath = logFilePath + "//" + logDocument;
            FileStream fs = new FileStream(logFilePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine(System_Now_Time + ":   " + strLog);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        #endregion

    }
}
