using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class Class_Delay
{
    #region//延时
    /// <summary>
    /// 延时功能块
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="value"></param>

    [DllImport("kernel32.dll")]
    private static extern uint GetTickCount();

    private static object ob = new object();
    public static void MyDelaySecond(uint ms)
    {
        lock (ob) 
        {
            uint Start = GetTickCount();
            while (Math.Abs(GetTickCount() - Start) < ms)
            {
                Application.DoEvents();
            }
        }
        
    }
    #endregion
}

