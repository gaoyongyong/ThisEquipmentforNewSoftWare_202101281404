using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Class_Action
{
    /// <summary>
    /// 定义事件
    /// </summary>
    public static event Action<string> ToolBar_Refresh;

    /// <summary>
    /// 定义事件
    /// </summary>
    public static event Action<string> Lamp_Refresh;

    ////刷新log
    public static void ToolBarRefresh(string Control)
    {
        ToolBar_Refresh?.Invoke(Control);
    }
    ////刷新lamp
    public static void LampRefresh(string Control)
    {
        Lamp_Refresh?.Invoke(Control);
    }
}

