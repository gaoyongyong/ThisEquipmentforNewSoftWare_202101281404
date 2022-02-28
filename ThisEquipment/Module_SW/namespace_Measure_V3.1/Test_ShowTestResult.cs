using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Measure
{
    public partial class Form123 : Form
    {
        public Form123()
        {
            InitializeComponent();
        }

        SysMeasureDBServices dbService = new SysMeasureDBServices("LFK123");
        private void button1_Click(object sender, EventArgs e)
        {
            //通过尺寸名称，得到一个对象实体
            MeasureSize mSize=
            dbService.GetModelBySizeName(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //得到表格里测试项判定标准的集合，测试内容中的所有项的判定标准
            LmSize = dbService.GetAll();
        }

        List<MeasureSize> LmSize = null;
        private void button3_Click(object sender, EventArgs e)
        {
            LmSize = dbService.GetAllByIsShow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LmSize = dbService.GetAllByIsJudging();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dbService.CloseDB();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showTestResult1.INIT_ShowTestResult("LFK123");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //showTestResult1.INIT_DataGridView();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showTestResult1.Ini_Form();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Measure.ProMeasureSize.TestValue = new List<Measure.TestingData>();

            for (int i = 0; i < ProMeasureSize.Sizes.Count(); i++)
            {
                Measure.TestingData testdata = new Measure.TestingData();

                testdata.ID = i;
                testdata.Name = "Finger " + i.ToString();
                testdata.Value = 0.977 + i;
                Measure.ProMeasureSize.TestValue.Add(testdata);


                this.showTestResult1.FUNC_AddResults(Measure.ProMeasureSize.TestValue[0].ID, Measure.ProMeasureSize.TestValue[0]);

            }

            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.showTestResult1.FUNC_AddFinalResult(Measure.ProMeasureSize.TestValue);
        }





        //---
        private void button11_Click(object sender, EventArgs e)
        {
            this.showTestAllDataInListView1.INIT_ShowTestAllDataInListView("LFK123");
        }



        public int serial = 0;
        private void button12_Click(object sender, EventArgs e)
        {
            ProMeasureSize.Serial = (serial++).ToString();
            ProMeasureSize.Barcode = "YUIOB564564891-"+ (serial).ToString();
            ProMeasureSize.MeasureTime = DateTime.Now.ToShortTimeString();
            ProMeasureSize.MeasureResult = "PASS";


            this.showTestAllDataInListView1.FUNC_AddALineData();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ProMeasureSize.Serial = (serial++).ToString();
            ProMeasureSize.Barcode = "YUIOB564564891-" + (serial).ToString();
            ProMeasureSize.MeasureTime = DateTime.Now.ToShortTimeString();
            ProMeasureSize.MeasureResult = "PASS";


            this.showTestAllDataInListView1.FUNC_AddALineDataInColor();
        }
    }
}
