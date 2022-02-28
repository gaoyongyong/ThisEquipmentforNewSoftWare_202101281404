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

namespace ToolSetting.UI.TCPServer
{


    public partial class Form_TCPServer : Form
    {

        #region 1.变量
        //Service
        public Service_TCPServer Service_TCPServer;



        #endregion
        public Form_TCPServer(string Name)
        {
            InitializeComponent();
            //1.实例化服务
            Service_TCPServer = new Service_TCPServer(Name);
            //2.初始化界面
            Ini_Form();
            //3.参数实例化界面
            ModelToForm();
            //4.方法和Action之间绑定
            Service_TCPServer.Form_Refresh += FUNC_Receive_Refresh;
        }

        private void Form_TCPServer_Load(object sender, EventArgs e)
        {
           
        }

        private void Ini_Form()
        {
            //禁止窗体缩放
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //初始化dGV
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

        //3.参数实例化界面
        private void ModelToForm()
        {
            try
            {
                textBox_Port.Text = Service_TCPServer.Model_TCPServer.Port.ToString();
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
            }

        }
        /// <summary>
        /// 启动监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Open_Click(object sender, EventArgs e)
        {
            try
            {
                Service_TCPServer.Model_TCPServer.Port = Convert.ToInt32(textBox_Port.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show("参数设置错误，请重新输入！");
            }
            try
            {
                if (Service_TCPServer.OpenServer())
                {
                    button_Open.Enabled = false;
                    button_Close.Enabled = true;
                    MessageBox.Show("TCP服务器连接成功！");
                }
                else
                {
                    button_Open.Enabled = true;
                    button_Close.Enabled = false;
                    MessageBox.Show("TCP服务器连接失败！");
                };


            }
            catch (Exception ex)
            {

                Basic_UI.Log.SaveError(ex);
            }

        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Service_TCPServer.CloseServer();
            button_Open.Enabled = true;
            button_Close.Enabled = false;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Service_TCPServer.Model_TCPServer.Port = Convert.ToInt32(textBox_Port.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("参数设置失败，请重新输入！");
            }

            if (Service_TCPServer.Save_Model())
            {
                MessageBox.Show("参数保存成功");
            }
            else
            {
                MessageBox.Show("参数保存失败");
            }
        }

        /// <summary>
        /// 将接受到的数据显示在界面上
        /// </summary>
        /// <param name="input"></param>
        private void FUNC_Receive_Refresh(List<string> input)
        {
            this.Invoke(new Action(() =>
            {

                for (int i = 0; i < input.Count; i++)
                {
                    //将结果放在Text中
                    textBox_Receive.Text += input[i] + ",";

                }
                //将结果放在Text中
                textBox_Receive.Text += "\r\n";

                //将结果写入到DataGridView中
                ListToDataGridView(input);
            }));

        }

        //输入值到DataGridView
        private void ListToDataGridView(List<string> Input)
        {
            dataGridView_Receive.Rows.Clear();
            for (int i = 0; i < Input.Count; i++)
            {
                int idx = dataGridView_Receive.Rows.Add();
                dataGridView_Receive.Rows[idx].Cells[0].Value = idx;
                dataGridView_Receive.Rows[idx].Cells[1].Value = Input[i];

            }
        }

        private void Form_TCPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            Service_TCPServer?.CloseServer();
        }
    }
}
