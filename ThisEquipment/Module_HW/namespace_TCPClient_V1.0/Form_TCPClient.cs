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

namespace ToolSetting.UI.TCPClient
{
    public partial class Form_TCPClient : Form
    {
        #region 1.变量
        public Service_TCPClient Service_TCPClient;
        #endregion
        public Form_TCPClient(Model_TCPClient Model_TCPClient)
        {
            InitializeComponent();
            //1.实例化服务
            Service_TCPClient = new Service_TCPClient();
            Service_TCPClient.Model_TCPClient = Model_TCPClient;
            //2.初始化界面
            Ini_Form();
            //3.参数实例化界面
            ModelToForm();
        }

        public Form_TCPClient()
        {
            InitializeComponent();
            //1.实例化服务
            Service_TCPClient = new Service_TCPClient();          
            //2.初始化界面
            Ini_Form();
            //3.参数实例化界面
            ModelToForm();
        }



        private void Ini_Form()
        {
            
            //初始化dGV
            Ini_dataGridView();

            button_Test.Enabled = false;
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
               
                textBox_IP.Text = Service_TCPClient.Model_TCPClient.IP;
                textBox_Port.Text = Service_TCPClient.Model_TCPClient.Port.ToString();
                textBox_DelayTime.Text = Service_TCPClient.Model_TCPClient.Delay_Time.ToString();
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
            }

        }

        //输入值到DataGridView
        private void ListToDataGridView(List<double> Input)
        {
            dataGridView_Receive.Rows.Clear();
            for (int i = 0; i < Input.Count; i++)
            {
                int idx = dataGridView_Receive.Rows.Add();
                dataGridView_Receive.Rows[idx].Cells[0].Value = idx;
                dataGridView_Receive.Rows[idx].Cells[1].Value = Input[i].ToString("0.000");

            }
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            try
            {
                Service_TCPClient.Model_TCPClient.Port = Convert.ToInt32(textBox_Port.Text);
                Service_TCPClient.Model_TCPClient.IP = textBox_IP.Text;

                Service_TCPClient.Model_TCPClient.Delay_Time = Convert.ToInt32(textBox_DelayTime.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show("参数设置错误，请重新输入！");
            }
            

            if (Service_TCPClient.initial())
            {
                button_Open.Enabled = false;
                button_Close.Enabled = true;
                button_Test.Enabled = true;

            }
            else
            {
                button_Open.Enabled = true;
                button_Close.Enabled = false;
                button_Test.Enabled = false ;
                MessageBox.Show("TCP客户端打开失败");
            }
            ;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Service_TCPClient?.close();
            button_Open.Enabled = true;
            button_Close.Enabled = true;
            button_Test.Enabled = false;
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            this.button_Test.Enabled = false;
            try
            {
                Service_TCPClient.Model_TCPClient.Port = Convert.ToInt32(textBox_Port.Text);
                Service_TCPClient.Model_TCPClient.IP = textBox_IP.Text;

                Service_TCPClient.Model_TCPClient.Delay_Time = Convert.ToInt32(textBox_DelayTime.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("参数设置错误，请重新输入！");

            }
              
            try
            {
                List<double> Result_Double = new List<double>();
                if (Service_TCPClient.SendAndGetData(textBox_Send.Text, out Result_Double))
                {
                    //将结果放在Text中
                    textBox_Receive.Text += Service_TCPClient.TCPClient_Result + "\r\n";
                    //将结果写入到DataGridView中
                    ListToDataGridView(Result_Double);
                }
                else
                {
                    //MessageBox.Show("通讯失败");
                }

                
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);

            }
            this.button_Test.Enabled = true ;

        }
       

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Service_TCPClient.Model_TCPClient.Port = Convert.ToInt32(textBox_Port.Text);
                Service_TCPClient.Model_TCPClient.IP = textBox_IP.Text;

                Service_TCPClient.Model_TCPClient.Delay_Time = Convert.ToInt32(textBox_DelayTime.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("参数设置失败，请重新输入！");
            }
            
            //if (Service_TCPClient.Save_Model())
            //{
            //    MessageBox.Show("参数保存成功");
            //}
            //else
            //{
            //    MessageBox.Show("参数保存失败");
            //}
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Receive.Text = "";
            dataGridView_Receive.Rows.Clear();
        }

       

        public void Close() 
        {
           
            //1.关闭使用的资源
            Service_TCPClient?.close();
            //2.关闭当前窗口
            this.Dispose();
        }

       
    }
}
