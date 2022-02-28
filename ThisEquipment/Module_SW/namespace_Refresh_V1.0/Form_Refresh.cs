using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refresh
{
    public partial class Form_Refresh : Form
    {
        //定义服务
        public Service_Refresh Service_Refresh;
        public Form_Refresh()
        {
            InitializeComponent();
            Service_Refresh = new Service_Refresh();
        }
    }
}
