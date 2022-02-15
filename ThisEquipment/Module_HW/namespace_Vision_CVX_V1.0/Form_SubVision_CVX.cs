using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.Threading;

namespace VISION_CVX
{
    public partial class Form_SubVision_CVX : Form
    {
        public static modCVXVision CCD1 = null;
        public static Class_Parameter_CVX Parameter_Model;
        public static bool CCD_Clibraiton_finish = false;

        public static HTuple hv_HomMat2D = new HTuple();
        public HTuple Cam_X1 = new HTuple();
        public HTuple Cam_Y1 = new HTuple();
        public HTuple Cam_X2 = new HTuple();
        public HTuple Cam_Y2 = new HTuple();

        public HTuple test_x = new HTuple();
        public HTuple test_y = new HTuple();
        public HTuple Result_x = new HTuple();
        public HTuple Result_y = new HTuple();
        public static HTuple Save_File = new HTuple();
        
        public Form_SubVision_CVX()
        {
            InitializeComponent();
            //定义存储位置
            Save_File = Application.StartupPath + @"\Config\HomMat2D.mtx";
            
            

            Parameter_Model = new Class_Parameter_CVX();
            //读取INI
            modINI_CVX<Class_Parameter_CVX>.ReadINI(ref Parameter_Model);

            //读校正文件
            try
            {
                HOperatorSet.ReadTuple(Save_File, out hv_HomMat2D);
            }
            catch
            {
                MessageBox.Show("CVX校正文件读取失败");
            }


            //ip&port赋值
            textBoxIP.Text = Parameter_Model.IP;
            textBoxPort.Text = Parameter_Model.Port.ToString();

          

            //实例化
         //   CCD1 = new modCVXVision();
           // Laser1.initial(textBoxIP.Text, textBoxPort.Text);

        }

        private void Form_SubVision_LJ8080_Load(object sender, EventArgs e)
        {

        }

        private void buttonINIT_Socket_Click(object sender, EventArgs e)
        {
            CCD1.initial(textBoxIP.Text,textBoxPort.Text);
            

        }

  

        private void button2_Click(object sender, EventArgs e)
        {
            string re = CCD1.Read_Data("T1\r\n");
            textBox_Log.Text += re + "\r\n";
        }

        private void comboBox_Recipe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonFUNC_CloseSocket_Click(object sender, EventArgs e)
        {
            //Laser1.closeCCD();
            textBox_Log.Text = "";
        }

        private void button_Calibration_Click(object sender, EventArgs e)
        {
            string re = CCD1.Read_Data("T1\r\n");
            try
            {
                tb_P1_X.Text = Convert.ToDouble(re.Split(',')[1].Trim()).ToString("0.000");
                tb_P1_Y.Text = Convert.ToDouble(re.Split(',')[2].Trim()).ToString("0.000");
                tb_P2_X.Text = Convert.ToDouble(re.Split(',')[3].Trim()).ToString("0.000");
                tb_P2_Y.Text = Convert.ToDouble(re.Split(',')[4].Trim()).ToString("0.000");
            }
            catch
            {
                tb_P1_X.Text = "0";
                tb_P1_Y.Text = "0";
                tb_P2_X.Text = "0";
                tb_P2_Y.Text = "0";

            }
           


            Cam_X1[0] = Convert.ToDouble(tb_P1_X.Text.Trim());
            Cam_Y1[0] = Convert.ToDouble(tb_P1_Y.Text.Trim());

            Cam_X1[1] = Convert.ToDouble(tb_P2_X.Text.Trim());
            Cam_Y1[1] = Convert.ToDouble(tb_P2_Y.Text.Trim());


        }

        private void btn_value_Click(object sender, EventArgs e)
        {

            Cam_X2[0] = Convert.ToDouble(tb_P3_X.Text.Trim());
            Cam_Y2[0] = Convert.ToDouble(tb_P3_Y.Text.Trim());

            Cam_X2[1] = Convert.ToDouble(tb_P4_X.Text.Trim());
            Cam_Y2[1] = Convert.ToDouble(tb_P4_Y.Text.Trim());

            //保存校正文件
            try
            {
                HOperatorSet.VectorToSimilarity(Cam_X1, Cam_Y1, Cam_X2, Cam_Y2, out hv_HomMat2D);
                HOperatorSet.WriteTuple(hv_HomMat2D, Save_File);
                MessageBox.Show("保存成功");
            }
            catch
            {
                MessageBox.Show("校正出错");
            }
            
            
        }

        private void button_Check_Click(object sender, EventArgs e)
        {
            Form_SubVision_CVX.CCD1.ChangeCCD_Recipe("1");
            Thread.Sleep(20);

            string re = CCD1.Read_CCD();
            try
            {
                tb_Check_X.Text = Convert.ToDouble(re.Split(',')[0].Trim()).ToString("0.000");
                tb_Check_Y.Text = Convert.ToDouble(re.Split(',')[1].Trim()).ToString("0.000");
            }
            catch
            {
                tb_Check_X.Text = "0";
                tb_Check_Y.Text = "0";
            }
            
            
        }

        private void button_Result_Check_Click(object sender, EventArgs e)
        {
            test_x[0] = Convert.ToDouble(tb_Check_X.Text.Trim());
            test_y[0] = Convert.ToDouble(tb_Check_Y.Text.Trim());
            try
            {
                HOperatorSet.AffineTransPoint2d(hv_HomMat2D, test_x, test_y, out Result_x, out Result_y);
                tb_Result_X.Text = Convert.ToDouble(Result_x.ToString()).ToString("0.000");
                tb_Result_Y.Text = Convert.ToDouble(Result_y.ToString()).ToString("0.000");
            }
            catch
            {
                MessageBox.Show("结果输出出错！");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_SubVision_CVX.CCD1.ChangeCCD_Recipe("2");
            Thread.Sleep(20);
            string re = CCD1.Read_CCD();
            try
            {
                tb_Check_X.Text = Convert.ToDouble(re.Split(',')[0].Trim()).ToString("0.000");
                tb_Check_Y.Text = Convert.ToDouble(re.Split(',')[1].Trim()).ToString("0.000");
            }
            catch
            {
                tb_Check_X.Text = "0";
                tb_Check_Y.Text = "0";
            }
        }
    }
}
