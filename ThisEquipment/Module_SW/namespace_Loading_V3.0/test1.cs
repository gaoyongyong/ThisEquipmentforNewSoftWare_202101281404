using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

using System.Diagnostics;

namespace namespace_Loading
{
    public partial class test1 : Form
    {
        public test1()
        {
            InitializeComponent();
        }

        private void test1_Load(object sender, EventArgs e)
        {

        }


        Thread threadStartDialog = null;
        private void button1_Click(object sender, EventArgs e)
        {

            threadStartDialog = new Thread(new ThreadStart(ThreadFunc));
            threadStartDialog.Start();




        }

        private void button2_Click(object sender, EventArgs e)
        {

        }




        private void ThreadFunc()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //线程中打开Loading窗体
            LoadingForm.MethodInvokerShowMsgForm(this, "1", Color.Red, "2222", Color.Black);
            LoadingForm.MethodInvokerShowMsgForm(this, "1", Color.Red, "2222", Color.Black);
            LoadingForm.MethodInvokerShowMsgForm(this, "1", Color.Red, "2222", Color.Black);

            Thread.Sleep(5000);

            //线程中关闭Loading窗体
            //LoadingForm.MethodInvokerCloseMsgForm(this);



            string CTEndTime = (stopwatch.ElapsedMilliseconds ).ToString("0.0");

            //MessageBox.Show("use time: " + CTEndTime + " ms");



            LoadingForm.MethodInvokerShowErrForm(this, "Error", Color.Black, "E_stop", Color.Black);

            Thread.Sleep(5000);

            //线程中关闭Loading窗体
            LoadingForm.MethodInvokerCloseErrForm(this);
            LoadingForm.MethodInvokerCloseErrForm(this);
            LoadingForm.MethodInvokerCloseErrForm(this);

        }

    }
}
