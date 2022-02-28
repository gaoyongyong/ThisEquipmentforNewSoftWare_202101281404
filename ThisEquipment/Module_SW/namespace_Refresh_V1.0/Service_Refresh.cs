using Measure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Service_Refresh
{
    /// <summary>
    /// 定义事件
    /// </summary>
    public static event Action TestResult_Refresh;
    public static event Action ProStatistics_Refresh;
    public static event Action TestData_Refresh;
    public static event Action<string, Color> Log_Refresh;
    public static event Action Ini_Refresh;

    //刷新数据界面
    public bool TestResultRefresh()
    {
        TestResult_Refresh?.Invoke();
        TestData_Refresh?.Invoke();
        return true;

    }
    //刷新计数据界面
    public bool ProStatisticsRefresh()
    {
        ProStatistics_Refresh?.Invoke();
        return true;
    }

    ////刷新log
    public static void LogRefresh(string Content, string Colors)
    {
        if (Colors == "red")
        {
            Log_Refresh?.Invoke(Content, Color.Red);
        }
        else
        {
            Log_Refresh?.Invoke(Content, Color.Green);
        }


    }
    //刷新数据界面
    public bool IniRefresh()
    {
        Ini_Refresh?.Invoke();
      
        return true;

    }
}

