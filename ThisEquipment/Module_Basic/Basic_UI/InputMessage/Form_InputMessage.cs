using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_UI
{
    public partial class Form_InputMessage : Form
    {
        //输入的名称
        public static string Input;

        public Form_InputMessage()
        {
            InitializeComponent();
            label1.Text = "";
            Input = "";
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            Input = textBox1.Text;
            this.Close();

        }
    }
}
