using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DevComponents;

namespace Log
{
    public partial class UILog : UserControl
    {
        private static int _maxLogmsgTextLength = 10000;//日志框最大输入
        public MainLog Main_Log = new MainLog();
        object obj = new object();

        public UILog()
        {
            InitializeComponent();

            txtLogMsg.SelectionStart = txtLogMsg.Text.Length;
            txtLogMsg.SelectionLength = 0;
            txtLogMsg.ScrollToCaret();

            Service_Refresh.Log_Refresh += FUNC_AppendLogMsg;
        }

        private void UILog_Load(object sender, EventArgs e)
        {
            this.txtLogMsg.Multiline = true;
            this.txtLogMsg.ReadOnly = true; 
        }

        /// <summary>
        /// 初始化Log界面
        /// </summary>
        public void INIT_LogMsg()
        {
            this.txtLogMsg.Clear();
        }

        /// <summary>
        /// 添加Log
        /// </summary>
        /// <param name="msg">添加内容</param>
        /// <param name="color">呈现颜色</param>
        public void FUNC_AppendLogMsg(string msg, Color color)
        {
            lock (obj)
            {
                try
                {
                    msg = DateTime.Now.ToString("HH:mm:ss fff") + "：" + msg;
                    //在UI线程中执行
                    this.BeginInvoke(new Action(() =>
                    {
                        if (txtLogMsg.Text.Length > _maxLogmsgTextLength)
                        {
                            txtLogMsg.Clear();
                        };
                        txtLogMsg.AppendText(msg);
                        int selectedText = txtLogMsg.Text.IndexOf(msg);
                        txtLogMsg.AppendText(Environment.NewLine);
                        if (selectedText != -1)
                        {
                            txtLogMsg.SelectionStart = selectedText;
                            txtLogMsg.SelectionLength = msg.Length;
                            txtLogMsg.SelectionColor = color;
                            //txtLogMsg.Select(selectedText, (msg).Length);
                        }
                        
                        // txtLogMsg.Text.Length;
                        
                        //txtLogMsg.Focus();


                    }));
                    Main_Log.WriteLog(msg, color);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("报错");
                }
            }
            
        }

        private void UILog_ClientSizeChanged(object sender, EventArgs e)
        {
            txtLogMsg.Width = this.Width;
            txtLogMsg.Height = this.Height;
        }

        private void txtLogMsg_TextChanged(object sender, EventArgs e)
        {
            //文本框选中的起始点在最后
            txtLogMsg.SelectionStart = txtLogMsg.TextLength;
            //将控件内容滚动到当前插入符号位置
            txtLogMsg.ScrollToCaret();
        }
    }
}
