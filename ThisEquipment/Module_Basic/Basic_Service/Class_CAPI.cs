using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

