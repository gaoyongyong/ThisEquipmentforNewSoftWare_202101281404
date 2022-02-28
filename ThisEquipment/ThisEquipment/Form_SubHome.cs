using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Layer;
using ProStatistics;
using System.Diagnostics;   //Stopwatch
using System.IO;

using System.Threading;

namespace ThisEquipment
{
    public partial class Form_SubHome : Form
    {  
        public Form_SubHome()
        {
            InitializeComponent();
        }
 
        private void Form_SubHome_Load(object sender, EventArgs e)
        {      
            string strPath = System.IO.Path.GetFullPath("../../") + "VersionsChangeList.txt";
            string Result = "";
            Class_OpFile.LoadingProfile(strPath, out Result);
            textBoxVersion.Text = Result;
        }
    }
}
