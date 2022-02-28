using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Measure;

namespace ThisEquipment
{
    public partial class Form_SubData : Form
    {
        public Form_SubData()
        {
            InitializeComponent();
        }

        int serial = 1;
        private void button1_Click(object sender, EventArgs e)
        {


            Measure.ProMeasureSize.Serial = (serial++).ToString();
            Measure.ProMeasureSize.Barcode = "SDFGHJ123";
            Measure.ProMeasureSize.MeasureTime = DateTime.Now.ToString();
            Measure.ProMeasureSize.MeasureResult = Measure.JUDGEMENT_RESULT.OK.ToString();

            for (int i = 0; i < Measure.ProMeasureSize.TestValue.Count; i++)
            {
                Measure.ProMeasureSize.TestValue[i].Value = i*3;
            }



            //this.showTestAllData1.AddNewLineData();
            
        }

        private void showTestAllDataInListView1_Load(object sender, EventArgs e)
        {

        }
    }
}
