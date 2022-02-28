using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Choice
{
    public partial class Form_Choice : Form
    {
        public static int Choice = 0;
        public Form_Choice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "自动运行软件")
            {
                Choice = 0;
            }
            else
            {
                Choice = 1;
            }
            this.Dispose();
        }
    }
}
