using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;


public class Class_OpFile
{
    /// <summary>
    /// Output string to a file.
    /// </summary>
    /// <param name="profileDatas">save String</param>
    /// <param name="savePath">Full path to the file to save</param>
    /// <remarks></remarks>
    public static bool SaveProfile(string profileDatas, string savePath)
    {
        try
        {

            using (StreamWriter sw = new StreamWriter(savePath, false, Encoding.GetEncoding("utf-16")))
            {
                sw.Write(profileDatas);

                sw.Close();
                sw.Dispose();
            }
            return true;
        }
        catch
        {
            return false;

        }
    }



    public static bool LoadingProfile(string savePath, out string Result)
    {
        string str_read = string.Empty;
        try
        {

            StreamReader sr = new StreamReader(savePath, Encoding.Default);


            str_read = sr.ReadToEnd(); //从开始du到末尾读取文件的所有内容，zhistr_read 存放的就是读取到的文本
            sr.Close(); //读完文件记dao得关闭流
            sr.Dispose();

            Result = str_read;
            return true;

        }
        catch
        {
            Result = str_read;
            return true;
        }
    }


}

