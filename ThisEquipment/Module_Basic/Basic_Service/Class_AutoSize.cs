using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public class AutoSize
{
    private float FormHeight;
    private float FormWidth;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="Width">  </param>
    /// <param name="Height"> </param>
    public AutoSize(int Width, int Height)
    {
        FormWidth = Width;
        FormHeight = Height;
    }

    /// <summary>
    /// 将控件的宽，高，左边距，顶边距和字体大小暂存到tag属性中
    /// </summary>
    /// <param name="controls"> 控件集合 </param>
    public void SetTag(Control controls)
    {
        foreach (Control control in controls.Controls)
        {
            control.Tag = control.Width + ":" +
                          control.Height + ":" +
                          control.Left + ":" +
                          control.Top + ":" +
                          control.Font.Size;
            if (control.Controls.Count > 0)
            {
                SetTag(control);
            }
        }
    }

    /// <summary>
    /// 根据窗体大小调整控件大小
    /// </summary>
    /// <param name="newx">     </param>
    /// <param name="newy">     </param>
    /// <param name="controls"> </param>
    public void SetControls(float newx, float newy, Control controls)
    {
        //遍历窗体中的控件，重新设置控件的值
        foreach (Control control in controls.Controls)
        {
            try
            {
                string name = control.Name;
                if (name == "panel_Data")
                {
                    //return;
                }
                string[] mytag = control.Tag.ToString().Split(new char[] { ':' });//获取控件的Tag属性值，并分割后存储字符串数组
                float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                control.Width = (int)a;//宽度
                a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                control.Height = (int)(a);
                a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
                control.Left = (int)(a);
                a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                control.Top = (int)(a);
                //Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                //control.Font = new Font(control.Font.Name, currentSize, control.Font.Style, control.Font.Unit);
                if (control.Controls.Count > 0)
                {
                    SetControls(newx, newy, control);
                }
            }
            catch { }
        }
    }
}

