using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Class_Image
{
    public static System.Drawing.Image LoadImage(string fileName)

    {

        FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);



        int byteLength = (int)fileStream.Length;

        byte[] fileBytes = new byte[byteLength];

        fileStream.Read(fileBytes, 0, byteLength);

        fileStream.Close();

        return System.Drawing.Image.FromStream(new MemoryStream(fileBytes));

    }
}


