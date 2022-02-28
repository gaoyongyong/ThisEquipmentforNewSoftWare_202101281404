
using Basic_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolSetting.UI.Serial
{
    public partial class Form_Serial : Form
    {
        #region 变量
        /// <summary>
        /// Sevice
        /// </summary>
        public Service_Serial Service_Serial;
        #endregion


        public Form_Serial()
        {
            InitializeComponent();
            //1.实例化服务
            Service_Serial = new Service_Serial();
            //2.初始化界面
            Ini_Form();
            //3.参数实例化界面
            ModelToForm();
        }

        public Form_Serial(Model_Serial Model_Serial)
        {
            InitializeComponent();
            //1.实例化服务
            Service_Serial = new Service_Serial();
            Service_Serial.Model_Serial = Model_Serial;
            //2.初始化界面
            Ini_Form();
            //3.参数实例化界面
            ModelToForm();
        }





        private void Ini_Form() 
        {
            //禁止窗体缩放
            this.FormBorderStyle= FormBorderStyle.FixedSingle;

            //comboBox_Port
            string[] comValue = new string[] 
            { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8" ,"COM9","COM10"};
            comboBox_Port.DataSource = comValue;
            comboBox_Port.Text = "COM1";
            //comboBox_baudRate
            string[] comValue1 = new string[]
            { "1200", "2400", "4800", "9600", "14400", "19200"};
            comboBox_baudRate.DataSource = comValue1;
            comboBox_baudRate.Text = "9600";
            //comboBox_dataBit
            string[] comValue2 = new string[]
            { "5", "6", "7", "8"};
            comboBox_dataBit.DataSource = comValue2;
            comboBox_dataBit.Text = "8";
            //comboBox_StopBits
            string[] comValue5 = new string[]
            { "1", "1.5", "2"};
            comboBox_StopBits.DataSource = comValue5;
            comboBox_StopBits.Text = "1";
            //comboBox_parity
            string[] comValue3 = new string[]
            { "无", "奇校验", "偶校验"};
            comboBox_parity.DataSource = comValue3;
            comboBox_parity.Text = "无";
            //comboBox_End
            string[] comValue4 = new string[]
            { "无", "/r/n"};
            comboBox_End.DataSource = comValue4;
            comboBox_End.Text = "无";
            //comboBox_Result
            string[] comValue6 = new string[]
            { "double","string"};
            comboBox_Result.DataSource = comValue6;
            comboBox_Result.Text = "double";

            Ini_dataGridView();
        }

        private void Ini_dataGridView()
        {
            dataGridView_Receive.ScrollBars = ScrollBars.Both;
            //列自动填充
            dataGridView_Receive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //不允许编辑
            dataGridView_Receive.Enabled = false;
            //编辑模式为输入后编辑
            dataGridView_Receive.EditMode = DataGridViewEditMode.EditOnEnter;
            //去除DataGridView自带的一行
            //AllowUserToAddRows = false;
            //行头隐藏
            //RowHeadersVisible = false;
        }

        private void ModelToForm() 
        {
            try
            {
                
                comboBox_Port.Text = Service_Serial.Model_Serial.portName;
                comboBox_baudRate.Text = Service_Serial.Model_Serial.baudRate.ToString();
                comboBox_dataBit.Text = Service_Serial.Model_Serial.dataBit.ToString();
                comboBox_StopBits.Text = Service_Serial.Model_Serial.stopBit;
                comboBox_parity.Text = Service_Serial.Model_Serial.parity;
                comboBox_End.Text = Service_Serial.Model_Serial.endChar;
                textBox_Send.Text = Service_Serial.Model_Serial.TrigCmd;
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
            }

        }

        private void ListToDataGridView(List<String>Input)
        {
            dataGridView_Receive.Rows.Clear();
            for (int i = 0; i < Input.Count; i++)
            {
                int idx = dataGridView_Receive.Rows.Add();
                dataGridView_Receive.Rows[idx].Cells[0].Value =  idx;
                dataGridView_Receive.Rows[idx].Cells[1].Value = Input[i];

            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            
            Service_Serial.Model_Serial.portName = comboBox_Port.Text;
            Service_Serial.Model_Serial.baudRate = Convert.ToInt32(comboBox_baudRate.Text);
            Service_Serial.Model_Serial.dataBit = Convert.ToInt32(comboBox_dataBit.Text);
            Service_Serial.Model_Serial.stopBit = comboBox_StopBits.Text;
            Service_Serial.Model_Serial.parity = comboBox_parity.Text;
            Service_Serial.Model_Serial.endChar = comboBox_End.Text;
            Service_Serial.Model_Serial.TrigCmd = textBox_Send.Text;
            

            //if (Service_Serial.Save_Model())
            //{
            //    MessageBox.Show("文件保存成功");
            //}
            //else 
            //{
            //    MessageBox.Show("文件保存失败");
            //}
            //;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Service_Serial.PortOpen())
            {
                button_Open.Enabled = false;
                button_Close.Enabled = true;
                button_Test.Enabled = true;

            }
            else 
            {
                button_Open.Enabled = true;
                button_Close.Enabled = false;
                button_Test.Enabled = false;
                MessageBox.Show("串口打开失败");
            }
            ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Service_Serial.Model_Serial.portName = comboBox_Port.Text;
            Service_Serial.Model_Serial.baudRate = Convert.ToInt32(comboBox_baudRate.Text);
            Service_Serial.Model_Serial.dataBit = Convert.ToInt32(comboBox_dataBit.Text);
            Service_Serial.Model_Serial.stopBit = comboBox_StopBits.Text;
            Service_Serial.Model_Serial.parity = comboBox_parity.Text;
            Service_Serial.Model_Serial.endChar = comboBox_End.Text;
            Service_Serial.Model_Serial.TrigCmd = textBox_Send.Text;
           

            try
            {
                List<String> Result_String =  new List<string>();
                switch (comboBox_Result.Text)
                {
                    case "double":
                        List<double> Result_Double =  new List<double>();
                        Service_Serial.WriteFeeder_Double(Service_Serial.Model_Serial.TrigCmd,out Result_Double);
                        for (int i = 0; i < Result_Double.Count; i++)
                        {
                            String temp = Result_Double[i].ToString("0.000");
                            Result_String.Add(temp);
                        }
                        break;
                    case "string":
                        Service_Serial.WriteFeeder_String(Service_Serial.Model_Serial.TrigCmd, out Result_String);
                        break;
                    default:
                        break;
                }
                //将结果放在Text中
                textBox_Result.Text = Service_Serial.Serial_Result;
                //将结果写入到DataGridView中
                ListToDataGridView(Result_String);
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
                
            }

        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Service_Serial?.Close();
            button_Open.Enabled = true;
            button_Close.Enabled = true;
            button_Test.Enabled = false;
        }

       
        public void Close()
        {
          
            //1.关闭使用的资源
            Service_Serial?.Close();
            //2.关闭当前窗口
            this.Dispose();
        }

    }
}
