using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
//using Tool;
using ThisEquipment.Properties;
using Tools;

namespace PropertyGridEx
{
    internal partial class Form_cCombox : Form_FormBase
    {
        internal Form_cCombox()
        {
            InitializeComponent();
        }


        #region 窗体拖动
        private static bool IsDrag = false;
        private int enterX;
        private int enterY;
        private void setForm_MouseDown(object sender, MouseEventArgs e)
        {
            IsDrag = true;
            enterX = e.Location.X;
            enterY = e.Location.Y;
        }
        private void setForm_MouseUp(object sender, MouseEventArgs e)
        {
            IsDrag = false;
            enterX = 0;
            enterY = 0;
        }
        private void setForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrag)
            {
                Left += e.Location.X - enterX;
                Top += e.Location.Y - enterY;
            }
        }
        #endregion
        /// <summary>
        /// 是否以密码的形式输入
        /// </summary>
        internal bool passwordChar = false;
        /// <summary>
        /// 信息输入窗体输入的信息
        /// </summary>
        internal static string input = string.Empty;


        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static Form_cCombox _instance;
        public static Form_cCombox Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form_cCombox();
                return _instance;
            }
        }


        private void btn_confirm_Click(object sender, EventArgs e)
        {
            input = cComboBox1.TextStr.Trim();
            this.Close();
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            input = string.Empty;
            this.Close();
        }
        internal override void btn_baseClose_Click(object sender, EventArgs e)
        {
            try
            {
                base.btn_baseClose_Click(sender, e);
                input = string.Empty;
            }
            catch (Exception ex)
            {
               // Log.SaveError(ex);
            }
        }
        
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = Resources.ButtonDown;
            Application.DoEvents();
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = Resources.ButtonUp;
            Application.DoEvents();
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = Resources.按钮__2_;
            Application.DoEvents();
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = Resources.ButtonUp;
            Application.DoEvents();
        }

      

    }
}
