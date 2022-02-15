using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


using System.Threading;

namespace namespace_Loading
{
    public partial class Dialog_ErrorShow : Form
    {


        #region 解决闪烁问题
        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion



        public Dialog_ErrorShow(string textTitle,Color colorTitle,string textText,Color colorText)
        {
            InitializeComponent();
            //SetShadow();
            SetWindowRegion();

            labelTitle.Text = textTitle;
            labelTitle.ForeColor = colorTitle;


            labelText.Text = "      " + textText;
            labelText.ForeColor = colorText;

        }


        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        private void SetShadow()
        {
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
        }




        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 20);
            this.Region = new Region(FormPath);
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();    // 左上角    
            path.AddArc(arcRect, 180, 90);    // 右上角    
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);    // 右下角    
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);    // 左下角    
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线    
            return path;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            LoadingForm.MethodInvokerCloseErrForm(this);
        }
    }
}
