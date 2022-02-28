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



namespace ProStatistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            proStatistics1.LOAD_ProStatistics();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            proStatistics1.INIT_ProStatistics();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            proStatistics1.FUNC_RefreshData(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            threadStartProStatisticsCT = new Thread(new ThreadStart(StartProStatisticsCT));

            threadStartProStatisticsCT.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }


        Thread threadStartProStatisticsCT = null;


        private void StartProStatisticsCT()
        {
            proStatistics1.FUNC_CTStop();

            proStatistics1.FUNC_CTStart();

            Thread.Sleep(2000);
            proStatistics1.FUNC_CTStop();

            proStatistics1.FUNC_CTStop();

            proStatistics1.FUNC_CTStop();

            proStatistics1.FUNC_CTStart();
            proStatistics1.FUNC_CTStart();
            proStatistics1.FUNC_CTStart();
            proStatistics1.FUNC_CTStart();
            Thread.Sleep(10000);

            proStatistics1.FUNC_CTStop();

        }

    }
}
