using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using User;

namespace Layer
{
    #region  窗体动画效果相关常量
    public enum WindowsEffect
    {
        AW_SLIDE = 0x40000,//使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。    
        AW_ACTIVATE = 0x20000,//激活窗口。在使用了AW_HIDE标志后不要使用这个标志。    
        AW_BLEND = 0x80000,//使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。    
        AW_HIDE = 0x10000,//隐藏窗口，缺省则显示窗口。(关闭窗口用)    
        AW_CENTER = 0x0010,//若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。    
        AW_HOR_POSITIVE = 0x0001,//自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。    
        AW_VER_POSITIVE = 0x0004,//自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。    
        AW_HOR_NEGATIVE = 0x0002,//自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。    
        AW_VER_NEGATIVE = 0x0008//自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。    
    }
    #endregion

    class OpaqueLayerUtils
    {
       
        #region 半透层显示和隐藏方法
        /// <summary>
        /// 显示遮罩层
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="alpha">透明度</param>
        /// <param name="isShowLoadingImage">是否显示图标</param>
        public static void ShowOpaqueLayer(Control control, out OpaqueLayer op, int alpha, bool isShowLoadingImage)
        {
           
            op = new OpaqueLayer(alpha, isShowLoadingImage);
            try
            {
                control.Controls.Add(op);
                op.Dock = DockStyle.Fill;
                op.BringToFront();
                
                op.Enabled = true;
                op.Visible = true;
            }
            catch
            {
                throw new UserException("半透显示失败！");
            }
        }
        /// <summary>
        /// 隐藏遮罩层
        /// </summary>
        public static void HideOpaqueLayer(OpaqueLayer op)
        {
            try
            {
                if (op != null)
                {
                    op.Visible = false;
                    op.Enabled = false;
                    op.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new UserException("半透销毁失败！"+ex.Message);
            }
        }
        #endregion

    }
}
