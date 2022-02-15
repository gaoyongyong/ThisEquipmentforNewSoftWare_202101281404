
using Basic_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basic_UI;
using ThisEquipment.Properties;

namespace ToolSetting
{
    public partial class Form_Main : Form
    {
        #region 1.公用变量
     
        #region 1.变量
        public static List<ToolGroupModel> ToolGroupsList;
        /// <summary>
        /// Xml地址
        /// </summary>
        private string Xml_Addr = "";

        
        #endregion

        #endregion

        #region 2.私有变量
        /// <summary>
        /// 缩放类
        /// </summary>
        private new AutoSize AutoSize;
        /// <summary>
        /// 窗体的高
        /// </summary>
        private int FormHeight;
        /// <summary>
        /// 窗体的宽
        /// </summary>
        private int FormWidth;

        /// <summary>
        /// 弹出的界面
        /// </summary>
        private Form_InputMessage Display_Form;

        /// <summary>
        /// 项目选择
        /// </summary>
        public Dialog_ProjectChoose.Dialog_ProjectChoose dialog_ProjectChoose = null;
        #endregion

        public Form_Main()
        {
            InitializeComponent();
        }
        private void Form_Main_Load(object sender, EventArgs e)
        {
            //1.tablecontrol 自动缩放
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //tablecontrol_Resize();

            //2.调用子界面
            //s_io = new Sub_IO();
            //s_para = new Sub_Para();
            //s_database = new Form_Mydatabase();
            //ComData.PanelShow(panel_Para, s_para);
            //ComData.PanelShow(panel_IO, s_io);
            //ComData.PanelShow(panel_Database,s_database);

            //3.记录窗体大小
            FormWidth = Width;
            FormHeight = Height;
            AutoSize = new AutoSize(FormWidth, FormHeight);
            AutoSize.SetTag(this);

            //4.显示log


            string strPath = System.IO.Path.GetFullPath("../../") + "VersionsChangeList.txt";
            string Result = "";
            Class_OpFile.LoadingProfile(strPath, out Result);
            textBoxVersion.Text = Result;


            //5.初始化界面
            Ini_Form();
            Display_Form = new Form_InputMessage();

            //6.删除键绑定
            contextMenuStrip_tool.Items[0].Click += new System.EventHandler(删除_ToolStripMenuItem_Click);

            //7.没选择项目前禁止添加项目
            btn_addDevice.Enabled = false;

        }

        private void Ini_Form()
        {
            //初始化listview 
            Ini_dataGridView();

            //contextMenuStrip 
            Init_contextMenuStrip_mouse();

            ////显示LOG界面
            //Class_Form.PanelShow(panel_Log, Frm_Output.Instance);

        }


        private void Ini_dataGridView()
        {
            dataGridView_Tools.AllowUserToAddRows = false;
            dataGridView_Tools.AllowUserToDeleteRows = false;
            dataGridView_Tools.AllowUserToResizeColumns = false;
            //无实线
            dataGridView_Tools.BorderStyle = BorderStyle.None;
            dataGridView_Tools.AllowUserToResizeRows = false;
            dataGridView_Tools.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView_Tools.MultiSelect = false;

            dataGridView_Tools.ScrollBars = ScrollBars.Both;
            //列自动填充
            dataGridView_Tools.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //允许编辑
            dataGridView_Tools.Enabled = true;
            //编辑模式为输入后编辑
            dataGridView_Tools.EditMode = DataGridViewEditMode.EditProgrammatically;
            //去除DataGridView自带的一行
            dataGridView_Tools.AllowUserToAddRows = false;
            //行头隐藏
            dataGridView_Tools.RowHeadersVisible = false;
            //行头隐藏
            dataGridView_Tools.ColumnHeadersVisible = false;
            //行头隐藏
            dataGridView_Tools.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            ////设置
            //dataGridView_Tools.Columns.Clear();
            int ColumnWidth = dataGridView_Tools.Width;
            //DataGridViewColumn temp = new DataGridViewColumn();
            dataGridView_Tools.Columns[0].Width = ColumnWidth * 8 / 10;
            dataGridView_Tools.Columns[1].Width = ColumnWidth * 2 / 10;



        }

        private void Init_contextMenuStrip_mouse()
        {

            contextMenuStrip_Tools.Items.Add("串口通讯");
            contextMenuStrip_Tools.Items.Add("TCP服务器");
            contextMenuStrip_Tools.Items.Add("TCP客户端");
            contextMenuStrip_Tools.Items.Add("数学方法");
            contextMenuStrip_Tools.Items.Add("汇川PLC");
            contextMenuStrip_Tools.Items.Add("脚本");
            contextMenuStrip_Tools.Items.Add("刷新界面");
            contextMenuStrip_Tools.Items.Add("逻辑工具");
            contextMenuStrip_Tools.Items.Add("系统工具");


            contextMenuStrip_Tools.Items[0].Click += new System.EventHandler(this.串口通讯ToolStripMenuItem_Click);
            //contextMenuStrip_Tools.Items[1].Click += new System.EventHandler(this.TCP服务器ToolStripMenuItem_Click);
            contextMenuStrip_Tools.Items[2].Click += new System.EventHandler(this.TCP客户端ToolStripMenuItem1_Click);
            contextMenuStrip_Tools.Items[3].Click += new System.EventHandler(this.数学方法ToolStripMenuItem1_Click);
            contextMenuStrip_Tools.Items[4].Click += new System.EventHandler(this.汇川PLCToolStripMenuItem1_Click);
            contextMenuStrip_Tools.Items[5].Click += new System.EventHandler(this.脚本ToolStripMenuItem1_Click);
            contextMenuStrip_Tools.Items[6].Click += new System.EventHandler(this.刷新界面ToolStripMenuItem1_Click);
            contextMenuStrip_Tools.Items[7].Click += new System.EventHandler(this.逻辑工具ToolStripMenuItem1_Click);
            contextMenuStrip_Tools.Items[8].Click += new System.EventHandler(this.系统工具ToolStripMenuItem1_Click);


        }

        private void 串口通讯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //显示窗口
            Display_Form = new Form_InputMessage();
            Display_Form.StartPosition = FormStartPosition.CenterParent;
            Display_Form.ShowDialog();
            if (Form_InputMessage.Input == "")
            {
                return;
            }
            //判断是否存在
            if (CheckExist("串口通讯_" + Form_InputMessage.Input))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }
            //自动添加
            int idx = dataGridView_Tools.Rows.Add(); 
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("ToolSetting.UI.Serial.Form_Serial")); ;
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "串口通讯_" + Form_InputMessage.Input;            
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[1];
            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);

        }

        private void TCP服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //显示窗口
            Display_Form = new Form_InputMessage();
            Display_Form.StartPosition = FormStartPosition.CenterParent;
            Display_Form.ShowDialog();
            if (Form_InputMessage.Input == "")
            {
                return;
            }
            //判断是否存在
            if (CheckExist("TCP服务器_" + Form_InputMessage.Input))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }
            //自动添加

            int idx = dataGridView_Tools.Rows.Add();
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("ToolSetting.UI.TCPServer.Form_TCPServer"));
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "TCP服务器_" + Form_InputMessage.Input;
            dataGridView_Tools.Rows[idx].Cells[0].Tag = "TCP服务器_" + Form_InputMessage.Input;
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[2];


            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);
        }

        private void TCP客户端ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //显示窗口
            Display_Form = new Form_InputMessage();
            Display_Form.StartPosition = FormStartPosition.CenterParent;
            Display_Form.ShowDialog();
            if (Form_InputMessage.Input == "")
            {
                return;
            }
            //判断是否存在
            if (CheckExist("TCP客户端_" + Form_InputMessage.Input))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }

            //自动添加

            int idx = dataGridView_Tools.Rows.Add();
            
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("ToolSetting.UI.TCPClient.Form_TCPClient"));
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "TCP客户端_" + Form_InputMessage.Input;
            dataGridView_Tools.Rows[idx].Cells[0].Tag = "TCP客户端_" + Form_InputMessage.Input;
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[3];



            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);



        }

        private void 数学方法ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断是否存在
            if (CheckExist("数学方法"))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }

            //自动添加
            int idx = dataGridView_Tools.Rows.Add();
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("Maths.Form_Maths"));
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "数学方法";
            dataGridView_Tools.Rows[idx].Cells[0].Tag = "";
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[4];
            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);
        }
        private void 汇川PLCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断是否存在
            if (CheckExist("汇川PLC"))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }

            //自动添加
            int idx = dataGridView_Tools.Rows.Add();
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("Inovance.Form_Inovance"));
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "汇川PLC";
            dataGridView_Tools.Rows[idx].Cells[0].Tag = "";
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[5];
            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);
        }
        private void 脚本ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断是否存在
            if (CheckExist("脚本"))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }
            //自动添加
            int idx = dataGridView_Tools.Rows.Add();
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("ScriptCaculate.Form_ScriptCaculate"));
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "脚本";
            dataGridView_Tools.Rows[idx].Cells[0].Tag = "";
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[6];
            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);
        }
        private void 刷新界面ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断是否存在
            if (CheckExist("刷新界面"))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }
            //自动添加
            int idx = dataGridView_Tools.Rows.Add();
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("Refresh.Form_Refresh"));
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "刷新界面";
            dataGridView_Tools.Rows[idx].Cells[0].Tag = "";
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[7];
            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);
        }
        private void 逻辑工具ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断是否存在
            if (CheckExist("逻辑工具"))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }

            //自动添加
            int idx = dataGridView_Tools.Rows.Add();
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("Logic.Form_Logic"));
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "逻辑工具";
            dataGridView_Tools.Rows[idx].Cells[0].Tag = "";
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[8];
            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);
        }

        private void 系统工具ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断是否存在
            if (CheckExist("系统工具"))
            {
                MessageBox.Show("工具组已经存在!");
                return;
            }

            //自动添加
            int idx = dataGridView_Tools.Rows.Add();
            dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType("System.Form_System"));
            dataGridView_Tools.Rows[idx].Height = 30;
            dataGridView_Tools.Rows[idx].Cells[0].Value = "系统工具";
            dataGridView_Tools.Rows[idx].Cells[0].Tag = "";
            dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[9];
            Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[idx].Tag);
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="Context"></param>
        /// <returns></returns>
        private bool CheckExist(string Context)
        {
            for (int i = 0; i < dataGridView_Tools.Rows.Count; i++)
            {
                if (dataGridView_Tools.Rows[i].Cells[0].Value.ToString().Contains(Context))
                {
                    return true;
                }
            }
            return false;

        }

        private void btn_addDevice_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Point p = new System.Drawing.Point();
                p.X = this.Location.X + panel10.Location.X + btn_addDevice.Location.X + 20;
                p.Y = this.Location.Y + panel10.Location.Y + btn_addDevice.Location.Y + 36;
                contextMenuStrip_Tools.Show(p);
            }
            catch { }
        }

        private void dataGridView_Tools_SelectionChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView_Tools_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView_Tools.SelectedRows.Count <= 0)
            {
                return;
            }

            if (e.Button == MouseButtons.Right)
            {

                

                contextMenuStrip_tool.Show(MousePosition);
            }
            if (e.Button == MouseButtons.Left)
            {
                int index = dataGridView_Tools.CurrentRow.Index;

                if ((Form)dataGridView_Tools.Rows[index].Tag != null)
                {
                    Class_Form.PanelShow(panel_Form, (Form)dataGridView_Tools.Rows[index].Tag);
                }
            }


        }

        private void 删除_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Tools.SelectedRows.Count <= 0)
            {
                return;
            }
            dataGridView_Tools.Rows.Remove(dataGridView_Tools.SelectedRows[0]);
            Class_Form.PanelShow(panel_Form, new Form());
        }
        /// <summary>
        /// model实例化form
        /// </summary>
        private void ModelToForm()
        {
            dataGridView_Tools.Rows.Clear();
            for (int i = 0; i < ToolGroupsList.Count; i++)
            {
                int idx = dataGridView_Tools.Rows.Add();
                object Para = new object[1];
                Para = ToolGroupsList[i].Model;

                if (Para == null)
                {
                    dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType(ToolGroupsList[i].GroupFormName));
                }
                else
                {
                    dataGridView_Tools.Rows[idx].Tag = Activator.CreateInstance(Type.GetType(ToolGroupsList[i].GroupFormName), Para);

                }

                dataGridView_Tools.Rows[idx].Height = 30;
                dataGridView_Tools.Rows[idx].Cells[0].Value = ToolGroupsList[i].GroupName;
                dataGridView_Tools.Rows[idx].Cells[1].Value = imageList_Tool.Images[ToolGroupsList[i].GroupID];
                dataGridView_Tools.Rows[idx].Cells[1].Tag = Para;

            }

        }
        /// <summary>
        /// 将Form保存到model中
        /// </summary>
        private void FormToModel()
        {
            ToolGroupsList.Clear();
            for (int i = 0; i < dataGridView_Tools.Rows.Count; i++)
            {
                ToolGroupModel ToolGroupModel_Temp = new ToolGroupModel();
                ToolGroupModel_Temp.GroupFormName = dataGridView_Tools.Rows[i].Tag.GetType().FullName;
                ToolGroupModel_Temp.GroupName = dataGridView_Tools.Rows[i].Cells[0].Value.ToString();               
                ToolGroupModel_Temp.tools = new List<ToolInfo>();

                switch (ToolGroupModel_Temp.GroupFormName)
                {
                    case "ToolSetting.UI.Serial.Form_Serial":
                        ToolGroupModel_Temp.GroupClassName = "Service_Serial";
                        ToolGroupModel_Temp.GroupModelName= "Model_Serial";
                        ToolGroupModel_Temp.GroupID = 1;
                        ToolGroupModel_Temp.Model = ((ToolSetting.UI.Serial.Form_Serial)dataGridView_Tools.Rows[i].Tag).Service_Serial.Model_Serial;

                        //工具1
                        ToolInfo ToolInfo_Serial = new ToolInfo();
                        ToolInfo_Serial.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Serial.toolenable = true;
                        ToolInfo_Serial.toolName = "读取串口数据";
                        ToolInfo_Serial.toolMethod = "WriteFeeder_Double";
                        ToolInfo_Serial.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Serial.toolID = 1;

                        ToolInfo_Serial.Now_Step = -1;
                        ToolInfo_Serial.Next_Step = -1;
                        ToolInfo_Serial.tool_Mode = false;
                        //input
                        ToolInfo_Serial.input = new List<ToolIO>();
                        ToolIO ToolIO_Serial_Input = new ToolIO();
                        ToolIO_Serial_Input.IOName = "发送的指令";
                        ToolIO_Serial_Input.IOInfo = false;
                        ToolIO_Serial_Input.IOCategory = "输入变量";
                        ToolIO_Serial_Input.Binding = false;
                        ToolIO_Serial_Input.IOType = "string";
                        ToolIO_Serial_Input.TypeConverter = "string";
                        ToolInfo_Serial.input.Add(ToolIO_Serial_Input);
                        //output
                        ToolInfo_Serial.output = new List<ToolIO>();
                        ToolIO ToolIO_Serial_Output = new ToolIO();
                        ToolIO_Serial_Output.IOName = "接受到的数据";
                        ToolIO_Serial_Output.IOInfo = false;
                        ToolIO_Serial_Output.IOCategory = "输出变量";
                        ToolIO_Serial_Output.Binding = false;
                        ToolIO_Serial_Output.IOType = "List<double>";
                        ToolInfo_Serial.output.Add(ToolIO_Serial_Output);
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Serial);
                        break;

                    case "ToolSetting.UI.TCPClient.Form_TCPClient":
                        ToolGroupModel_Temp.GroupClassName = "Service_TCPClient";
                        ToolGroupModel_Temp.GroupModelName = "Model_TCPClient";
                        ToolGroupModel_Temp.GroupID = 2;
                        ToolGroupModel_Temp.Model = ((ToolSetting.UI.TCPClient.Form_TCPClient)dataGridView_Tools.Rows[i].Tag).Service_TCPClient.Model_TCPClient;
                        //方法1
                        ToolInfo ToolInfo_TCPClient = new ToolInfo();
                        ToolInfo_TCPClient.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_TCPClient.toolenable = true;
                        ToolInfo_TCPClient.toolName = "发送和接受数据";
                        ToolInfo_TCPClient.toolMethod = "SendAndGetData";
                        ToolInfo_TCPClient.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_TCPClient.toolID = 2;

                        ToolInfo_TCPClient.Now_Step = -1;
                        ToolInfo_TCPClient.Next_Step = -1;
                        ToolInfo_TCPClient.tool_Mode = false;
                        //input
                        ToolInfo_TCPClient.input = new List<ToolIO>();
                        ToolIO ToolIO_TCPClient_Input = new ToolIO();
                        ToolIO_TCPClient_Input.IOName = "发送的TCP指令";
                        ToolIO_TCPClient_Input.IOInfo = false;
                        ToolIO_TCPClient_Input.IOCategory = "输入变量";
                        ToolIO_TCPClient_Input.Binding = false;
                        ToolIO_TCPClient_Input.IOType = "string";
                        ToolIO_TCPClient_Input.TypeConverter = "string";
                        ToolInfo_TCPClient.input.Add(ToolIO_TCPClient_Input);
                        //output
                        ToolInfo_TCPClient.output = new List<ToolIO>();
                        ToolIO ToolIO_TCPClient_Output = new ToolIO();
                        ToolIO_TCPClient_Output.IOName = "接受到的数据";
                        ToolIO_TCPClient_Output.IOInfo = false;
                        ToolIO_TCPClient_Output.IOCategory = "输出变量";
                        ToolIO_TCPClient_Output.Binding = false;
                        ToolIO_TCPClient_Output.IOType = "List<double>";
                        ToolInfo_TCPClient.output.Add(ToolIO_TCPClient_Output);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_TCPClient);

                        //方法2
                        ToolInfo ToolInfo_TCPClient1 = new ToolInfo();
                        ToolInfo_TCPClient1.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_TCPClient1.toolenable = true;
                        ToolInfo_TCPClient1.toolName = "发送数据";
                        ToolInfo_TCPClient1.toolMethod = "Send";
                        ToolInfo_TCPClient1.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_TCPClient1.toolID = 3;

                        ToolInfo_TCPClient1.Now_Step = -1;
                        ToolInfo_TCPClient1.Next_Step = -1;
                        ToolInfo_TCPClient1.tool_Mode = false;
                        //input
                        ToolInfo_TCPClient1.input = new List<ToolIO>();
                        ToolIO ToolIO_TCPClient1_Input = new ToolIO();
                        ToolIO_TCPClient1_Input.IOName = "发送的TCP指令";
                        ToolIO_TCPClient1_Input.IOInfo = false;
                        ToolIO_TCPClient1_Input.IOCategory = "输入变量";
                        ToolIO_TCPClient1_Input.Binding = false;
                        ToolIO_TCPClient1_Input.IOType = "string";
                        ToolIO_TCPClient1_Input.TypeConverter = "string";
                        ToolInfo_TCPClient1.input.Add(ToolIO_TCPClient1_Input);
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_TCPClient1);

                        //方法3
                        ToolInfo ToolInfo_TCPClient2 = new ToolInfo();
                        ToolInfo_TCPClient2.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_TCPClient2.toolenable = true;
                        ToolInfo_TCPClient2.toolName = "接受数据";
                        ToolInfo_TCPClient2.toolMethod = "GetData";
                        ToolInfo_TCPClient2.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_TCPClient2.toolID = 4;

                        ToolInfo_TCPClient2.Now_Step = -1;
                        ToolInfo_TCPClient2.Next_Step = -1;
                        ToolInfo_TCPClient2.tool_Mode = false;

                        //output
                        ToolInfo_TCPClient2.output = new List<ToolIO>();
                        ToolIO ToolIO_TCPClient2_Output = new ToolIO();
                        ToolIO_TCPClient2_Output.IOName = "接受到的数据";
                        ToolIO_TCPClient2_Output.IOInfo = false;
                        ToolIO_TCPClient2_Output.IOCategory = "输出变量";
                        ToolIO_TCPClient2_Output.Binding = false;
                        ToolIO_TCPClient2_Output.IOType = "List<double>";
                        ToolInfo_TCPClient2.output.Add(ToolIO_TCPClient2_Output);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_TCPClient2);

                        break;
                    case "ToolSetting.UI.TCPServer.Form_TCPServer":

                        break;
                    case "Maths.Form_Maths":
                        ToolGroupModel_Temp.GroupClassName = "Service_Maths";
                        ToolGroupModel_Temp.GroupID = 3;
                        //工具1
                        ToolInfo ToolInfo_Math = new ToolInfo();
                        ToolInfo_Math.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Math.toolenable = true;
                        ToolInfo_Math.toolName = "加";
                        ToolInfo_Math.toolMethod = "Add";
                        ToolInfo_Math.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Math.toolID = 6;

                        ToolInfo_Math.Now_Step = -1;
                        ToolInfo_Math.Next_Step = -1;
                        ToolInfo_Math.tool_Mode = false;
                        //input
                        ToolInfo_Math.input = new List<ToolIO>();
                        ToolIO ToolIO_Math_Input = new ToolIO();
                        ToolIO_Math_Input.IOName = "被加数";
                        ToolIO_Math_Input.IOInfo = false;
                        ToolIO_Math_Input.IOCategory = "输入变量";
                        ToolIO_Math_Input.Binding = false;
                        ToolIO_Math_Input.IOType = "double";
                        ToolIO_Math_Input.TypeConverter = "double";
                        ToolInfo_Math.input.Add(ToolIO_Math_Input);


                        ToolIO ToolIO_Math_Input1 = new ToolIO();
                        ToolIO_Math_Input1.IOName = "加数";
                        ToolIO_Math_Input1.IOInfo = false;
                        ToolIO_Math_Input1.IOCategory = "输入变量";
                        ToolIO_Math_Input1.Binding = false;
                        ToolIO_Math_Input1.IOType = "double";
                        ToolIO_Math_Input1.TypeConverter = "double";
                        ToolInfo_Math.input.Add(ToolIO_Math_Input1);

                        //output
                        ToolInfo_Math.output = new List<ToolIO>();
                        ToolIO ToolIO_Math_Output = new ToolIO();
                        ToolIO_Math_Output.IOName = "加结果";
                        ToolIO_Math_Output.IOInfo = false;
                        ToolIO_Math_Output.IOCategory = "输出变量";
                        ToolIO_Math_Output.Binding = false;
                        ToolIO_Math_Output.IOType = "double";
                        ToolInfo_Math.output.Add(ToolIO_Math_Output);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Math);

                        //工具2
                        ToolInfo ToolInfo_Math1 = new ToolInfo();
                        ToolInfo_Math1.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Math1.toolenable = true;
                        ToolInfo_Math1.toolName = "减";
                        ToolInfo_Math1.toolMethod = "Minus";
                        ToolInfo_Math1.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Math1.toolID = 7;

                        ToolInfo_Math1.Now_Step = -1;
                        ToolInfo_Math1.Next_Step = -1;
                        ToolInfo_Math1.tool_Mode = false;
                        //input
                        ToolInfo_Math1.input = new List<ToolIO>();
                        ToolIO ToolIO_Math1_Input = new ToolIO();
                        ToolIO_Math1_Input.IOName = "被减数";
                        ToolIO_Math1_Input.IOInfo = false;
                        ToolIO_Math1_Input.IOCategory = "输入变量";
                        ToolIO_Math1_Input.Binding = false;
                        ToolIO_Math1_Input.IOType = "double";
                        ToolIO_Math1_Input.TypeConverter = "double";
                        ToolInfo_Math1.input.Add(ToolIO_Math1_Input);


                        ToolIO ToolIO_Math1_Input1 = new ToolIO();
                        ToolIO_Math1_Input1.IOName = "减数";
                        ToolIO_Math1_Input1.IOInfo = false;
                        ToolIO_Math1_Input1.IOCategory = "输入变量";
                        ToolIO_Math1_Input1.Binding = false;
                        ToolIO_Math1_Input1.IOType = "double";
                        ToolIO_Math1_Input1.TypeConverter = "double";
                        ToolInfo_Math1.input.Add(ToolIO_Math1_Input1);

                        //output
                        ToolInfo_Math1.output = new List<ToolIO>();
                        ToolIO ToolIO_Math1_Output = new ToolIO();
                        ToolIO_Math1_Output.IOName = "减结果";
                        ToolIO_Math1_Output.IOInfo = false;
                        ToolIO_Math1_Output.IOCategory = "输出变量";
                        ToolIO_Math1_Output.Binding = false;
                        ToolIO_Math1_Output.IOType = "double";
                        ToolInfo_Math1.output.Add(ToolIO_Math1_Output);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Math1);


                        //工具3
                        ToolInfo ToolInfo_Math2 = new ToolInfo();
                        ToolInfo_Math2.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Math2.toolenable = true;
                        ToolInfo_Math2.toolName = "乘";
                        ToolInfo_Math2.toolMethod = "Multiply";
                        ToolInfo_Math2.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Math2.toolID = 8;

                        ToolInfo_Math2.Now_Step = -1;
                        ToolInfo_Math2.Next_Step = -1;
                        ToolInfo_Math2.tool_Mode = false;
                        //input
                        ToolInfo_Math2.input = new List<ToolIO>();
                        ToolIO ToolIO_Math2_Input = new ToolIO();
                        ToolIO_Math2_Input.IOName = "被乘数";
                        ToolIO_Math2_Input.IOInfo = false;
                        ToolIO_Math2_Input.IOCategory = "输入变量";
                        ToolIO_Math2_Input.Binding = false;
                        ToolIO_Math2_Input.IOType = "double";
                        ToolIO_Math2_Input.TypeConverter = "double";
                        ToolInfo_Math2.input.Add(ToolIO_Math2_Input);


                        ToolIO ToolIO_Math2_Input1 = new ToolIO();
                        ToolIO_Math2_Input1.IOName = "乘数";
                        ToolIO_Math2_Input1.IOInfo = false;
                        ToolIO_Math2_Input1.IOCategory = "输入变量";
                        ToolIO_Math2_Input1.Binding = false;
                        ToolIO_Math2_Input1.IOType = "double";
                        ToolIO_Math2_Input1.TypeConverter = "double";
                        ToolInfo_Math2.input.Add(ToolIO_Math2_Input1);

                        //output
                        ToolInfo_Math2.output = new List<ToolIO>();
                        ToolIO ToolIO_Math2_Output = new ToolIO();
                        ToolIO_Math2_Output.IOName = "乘结果";
                        ToolIO_Math2_Output.IOInfo = false;
                        ToolIO_Math2_Output.IOCategory = "输出变量";
                        ToolIO_Math2_Output.Binding = false;
                        ToolIO_Math2_Output.IOType = "double";
                        ToolInfo_Math2.output.Add(ToolIO_Math2_Output);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Math2);


                        //工具4
                        ToolInfo ToolInfo_Math3 = new ToolInfo();
                        ToolInfo_Math3.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Math3.toolenable = true;
                        ToolInfo_Math3.toolName = "除";
                        ToolInfo_Math3.toolMethod = "Divide";
                        ToolInfo_Math3.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Math3.toolID = 9;

                        ToolInfo_Math3.Now_Step = -1;
                        ToolInfo_Math3.Next_Step = -1;
                        ToolInfo_Math3.tool_Mode = false;
                        //input
                        ToolInfo_Math3.input = new List<ToolIO>();
                        ToolIO ToolIO_Math3_Input = new ToolIO();
                        ToolIO_Math3_Input.IOName = "被除数";
                        ToolIO_Math3_Input.IOInfo = false;
                        ToolIO_Math3_Input.IOCategory = "输入变量";
                        ToolIO_Math3_Input.Binding = false;
                        ToolIO_Math3_Input.IOType = "double";
                        ToolIO_Math3_Input.TypeConverter = "double";
                        ToolInfo_Math3.input.Add(ToolIO_Math3_Input);


                        ToolIO ToolIO_Math3_Input1 = new ToolIO();
                        ToolIO_Math3_Input1.IOName = "除数";
                        ToolIO_Math3_Input1.IOInfo = false;
                        ToolIO_Math3_Input1.IOCategory = "输入变量";
                        ToolIO_Math3_Input1.Binding = false;
                        ToolIO_Math3_Input1.IOType = "double";
                        ToolIO_Math3_Input1.TypeConverter = "double";
                        ToolInfo_Math3.input.Add(ToolIO_Math3_Input1);

                        //output
                        ToolInfo_Math3.output = new List<ToolIO>();
                        ToolIO ToolIO_Math3_Output = new ToolIO();
                        ToolIO_Math3_Output.IOName = "除结果";
                        ToolIO_Math3_Output.IOInfo = false;
                        ToolIO_Math3_Output.IOCategory = "输出变量";
                        ToolIO_Math3_Output.Binding = false;
                        ToolIO_Math3_Output.IOType = "double";
                        ToolInfo_Math3.output.Add(ToolIO_Math3_Output);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Math3);
                        break;

                    case "Inovance.Form_Inovance":
                        ToolGroupModel_Temp.GroupClassName = "Service_Inovance";
                        ToolGroupModel_Temp.GroupModelName = "Model_Inovance";
                        ToolGroupModel_Temp.Model = ((Inovance.Form_Inovance)dataGridView_Tools.Rows[i].Tag).Service_Inovance.Model_Inovance;
                        ToolGroupModel_Temp.GroupID = 4;
                        //工具1
                        ToolInfo ToolInfo_Inovance = new ToolInfo();
                        ToolInfo_Inovance.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance.toolenable = true;
                        ToolInfo_Inovance.toolName = "伺服回原点";
                        ToolInfo_Inovance.toolMethod = "HomeAll";
                        ToolInfo_Inovance.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance.toolID = 10;

                        ToolInfo_Inovance.Now_Step = -1;
                        ToolInfo_Inovance.Next_Step = -1;
                        ToolInfo_Inovance.tool_Mode = false;

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance);

                        //工具3
                        ToolInfo ToolInfo_Inovance2 = new ToolInfo();
                        ToolInfo_Inovance2.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance2.toolenable = true;
                        ToolInfo_Inovance2.toolName = "到设定点位点";
                        ToolInfo_Inovance2.toolMethod = "MoveSettingIndex";
                        ToolInfo_Inovance2.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance2.toolID = 11;

                        ToolInfo_Inovance2.Now_Step = -1;
                        ToolInfo_Inovance2.Next_Step = -1;
                        ToolInfo_Inovance2.tool_Mode = false;
                        //input
                        ToolInfo_Inovance2.input = new List<ToolIO>();
                        ToolIO ToolIO_Inovance2_Input = new ToolIO();
                        ToolIO_Inovance2_Input.IOName = "设定点位";
                        ToolIO_Inovance2_Input.IOInfo = false;
                        ToolIO_Inovance2_Input.IOCategory = "输入变量";
                        ToolIO_Inovance2_Input.Binding = false;
                        ToolIO_Inovance2_Input.IOType = "int";
                        ToolIO_Inovance2_Input.TypeConverter = "int";
                        ToolInfo_Inovance2.input.Add(ToolIO_Inovance2_Input);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance2);


                        //工具4
                        ToolInfo ToolInfo_Inovance3 = new ToolInfo();
                        ToolInfo_Inovance3.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance3.toolenable = true;
                        ToolInfo_Inovance3.toolName = "强制IO";
                        ToolInfo_Inovance3.toolMethod = "SetOutput";
                        ToolInfo_Inovance3.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance3.toolID = 12;

                        ToolInfo_Inovance3.Now_Step = -1;
                        ToolInfo_Inovance3.Next_Step = -1;
                        ToolInfo_Inovance3.tool_Mode = false;
                        //input
                        ToolInfo_Inovance3.input = new List<ToolIO>();
                        ToolIO ToolIO_Inovance3_Input = new ToolIO();
                        ToolIO_Inovance3_Input.IOName = "输出ID";
                        ToolIO_Inovance3_Input.IOInfo = false;
                        ToolIO_Inovance3_Input.IOCategory = "输入变量";
                        ToolIO_Inovance3_Input.Binding = false;
                        ToolIO_Inovance3_Input.IOType = "int";
                        ToolIO_Inovance3_Input.TypeConverter = "int";
                        ToolInfo_Inovance3.input.Add(ToolIO_Inovance3_Input);
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance3);

                        //工具5
                        ToolInfo ToolInfo_Inovance4 = new ToolInfo();
                        ToolInfo_Inovance4.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance4.toolenable = true;
                        ToolInfo_Inovance4.toolName = "复位IO";
                        ToolInfo_Inovance4.toolMethod = "ResetOutput";
                        ToolInfo_Inovance4.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance4.toolID = 13;

                        ToolInfo_Inovance4.Now_Step = -1;
                        ToolInfo_Inovance4.Next_Step = -1;
                        ToolInfo_Inovance4.tool_Mode = false;
                        //input
                        ToolInfo_Inovance4.input = new List<ToolIO>();
                        ToolIO ToolIO_Inovance4_Input = new ToolIO();
                        ToolIO_Inovance4_Input.IOName = "输出ID";
                        ToolIO_Inovance4_Input.IOInfo = false;
                        ToolIO_Inovance4_Input.IOCategory = "输入变量";
                        ToolIO_Inovance4_Input.Binding = false;
                        ToolIO_Inovance4_Input.IOType = "int";
                        ToolIO_Inovance4_Input.TypeConverter = "int";
                        ToolInfo_Inovance4.input.Add(ToolIO_Inovance4_Input);
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance4);

                        //工具6
                        ToolInfo ToolInfo_Inovance5 = new ToolInfo();
                        ToolInfo_Inovance5.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance5.toolenable = true;
                        ToolInfo_Inovance5.toolName = "等待IO";
                        ToolInfo_Inovance5.toolMethod = "WaitIO";
                        ToolInfo_Inovance5.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance5.toolID = 14;

                        ToolInfo_Inovance5.Now_Step = -1;
                        ToolInfo_Inovance5.Next_Step = -1;
                        ToolInfo_Inovance5.tool_Mode = true;
                        //input
                        ToolInfo_Inovance5.input = new List<ToolIO>();
                        ToolIO ToolIO_Inovance5_Input = new ToolIO();
                        ToolIO_Inovance5_Input.IOName = "等待IO的ID";
                        ToolIO_Inovance5_Input.IOInfo = false;
                        ToolIO_Inovance5_Input.IOCategory = "输入变量";
                        ToolIO_Inovance5_Input.Binding = false;
                        ToolIO_Inovance5_Input.IOType = "int";
                        ToolIO_Inovance5_Input.TypeConverter = "int";
                        ToolInfo_Inovance5.input.Add(ToolIO_Inovance5_Input);
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance5);

                        //工具7
                        ToolInfo ToolInfo_Inovance6 = new ToolInfo();
                        ToolInfo_Inovance6.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance6.toolenable = true;
                        ToolInfo_Inovance6.toolName = "等待双手按钮";
                        ToolInfo_Inovance6.toolMethod = "WaitHandButton";
                        ToolInfo_Inovance6.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance6.toolID = 15;
                        ToolInfo_Inovance6.Now_Step = -1;
                        ToolInfo_Inovance6.Next_Step = -1;
                        ToolInfo_Inovance6.tool_Mode = true;
                        //input
                        ToolInfo_Inovance6.input = new List<ToolIO>();
                        ToolIO ToolIO_Inovance6_Input = new ToolIO();
                        ToolIO_Inovance6_Input.IOName = "等待双手按钮1的ID";
                        ToolIO_Inovance6_Input.IOInfo = false;
                        ToolIO_Inovance6_Input.IOCategory = "输入变量";
                        ToolIO_Inovance6_Input.Binding = false;
                        ToolIO_Inovance6_Input.IOType = "int";
                        ToolIO_Inovance6_Input.TypeConverter = "int";
                        ToolInfo_Inovance6.input.Add(ToolIO_Inovance6_Input);

                        ToolIO ToolIO_Inovance6_Input1 = new ToolIO();
                        ToolIO_Inovance6_Input1.IOName = "等待双手按钮2的ID";
                        ToolIO_Inovance6_Input1.IOInfo = false;
                        ToolIO_Inovance6_Input1.IOCategory = "输入变量";
                        ToolIO_Inovance6_Input1.Binding = false;
                        ToolIO_Inovance6_Input1.IOType = "int";
                        ToolIO_Inovance6_Input1.TypeConverter = "int";
                        ToolInfo_Inovance6.input.Add(ToolIO_Inovance6_Input1);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance6);

                        //工具8
                        ToolInfo ToolInfo_Inovance7 = new ToolInfo();
                        ToolInfo_Inovance7.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance7.toolenable = true;
                        ToolInfo_Inovance7.toolName = "多气缸操作";
                        ToolInfo_Inovance7.toolMethod = "Cys_Work";
                        ToolInfo_Inovance7.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance7.toolID = 21;
                        ToolInfo_Inovance7.Now_Step = -1;
                        ToolInfo_Inovance7.Next_Step = -1;
                        ToolInfo_Inovance7.tool_Mode = false;
                        //input
                        ToolInfo_Inovance7.input = new List<ToolIO>();
                        ToolIO ToolIO_Inovance7_Input = new ToolIO();
                        ToolIO_Inovance7_Input.IOName = "动位的气缸组";
                        ToolIO_Inovance7_Input.IOInfo = false;
                        ToolIO_Inovance7_Input.IOCategory = "输入变量";
                        ToolIO_Inovance7_Input.Binding = false;
                        ToolIO_Inovance7_Input.IOType = "List<string>";
                        ToolIO_Inovance7_Input.TypeConverter = "List<string>";
                        ToolInfo_Inovance7.input.Add(ToolIO_Inovance7_Input);

                        ToolIO ToolIO_Inovance7_Input1 = new ToolIO();
                        ToolIO_Inovance7_Input1.IOName = "原位的气缸组";
                        ToolIO_Inovance7_Input1.IOInfo = false;
                        ToolIO_Inovance7_Input1.IOCategory = "输入变量";
                        ToolIO_Inovance7_Input1.Binding = false;
                        ToolIO_Inovance7_Input1.IOType = "List<string>";
                        ToolIO_Inovance7_Input1.TypeConverter = "List<string>";
                        ToolInfo_Inovance7.input.Add(ToolIO_Inovance7_Input1);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance7);

                        //工具9
                        ToolInfo ToolInfo_Inovance8 = new ToolInfo();
                        ToolInfo_Inovance8.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance8.toolenable = true;
                        ToolInfo_Inovance8.toolName = "气缸动位";
                        ToolInfo_Inovance8.toolMethod = "Cy_Work";
                        ToolInfo_Inovance8.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance8.toolID = 22;
                        ToolInfo_Inovance8.Now_Step = -1;
                        ToolInfo_Inovance8.Next_Step = -1;
                        ToolInfo_Inovance8.tool_Mode = false;
                        //input
                        ToolInfo_Inovance8.input = new List<ToolIO>();
                        ToolIO ToolIO_Inovance8_Input = new ToolIO();
                        ToolIO_Inovance8_Input.IOName = "动位的气缸";
                        ToolIO_Inovance8_Input.IOInfo = false;
                        ToolIO_Inovance8_Input.IOCategory = "输入变量";
                        ToolIO_Inovance8_Input.Binding = false;
                        ToolIO_Inovance8_Input.IOType = "string";
                        ToolIO_Inovance8_Input.TypeConverter = "string";
                        ToolInfo_Inovance8.input.Add(ToolIO_Inovance8_Input);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance8);


                        //工具10
                        ToolInfo ToolInfo_Inovance9 = new ToolInfo();
                        ToolInfo_Inovance9.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance9.toolenable = true;
                        ToolInfo_Inovance9.toolName = "气缸原位";
                        ToolInfo_Inovance9.toolMethod = "Cy_Ori";
                        ToolInfo_Inovance9.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Inovance9.toolID = 23;
                        ToolInfo_Inovance9.Now_Step = -1;
                        ToolInfo_Inovance9.Next_Step = -1;
                        ToolInfo_Inovance9.tool_Mode = false;
                        //input
                        ToolInfo_Inovance9.input = new List<ToolIO>();
                        ToolIO ToolIO_Inovance9_Input = new ToolIO();
                        ToolIO_Inovance9_Input.IOName = "原位的气缸";
                        ToolIO_Inovance9_Input.IOInfo = false;
                        ToolIO_Inovance9_Input.IOCategory = "输入变量";
                        ToolIO_Inovance9_Input.Binding = false;
                        ToolIO_Inovance9_Input.IOType = "string";
                        ToolIO_Inovance9_Input.TypeConverter = "string";
                        ToolInfo_Inovance9.input.Add(ToolIO_Inovance9_Input);

                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Inovance9);

                        break;
                    case "ScriptCaculate.Form_ScriptCaculate":
                        ToolGroupModel_Temp.GroupClassName = "Service_ScriptCaculate";
                        ToolGroupModel_Temp.GroupModelName = "Model_ScriptCaculate";
                        ToolGroupModel_Temp.Model = ((ScriptCaculate.Form_ScriptCaculate)dataGridView_Tools.Rows[i].Tag).Service_ScriptCaculate.Model_ScriptCaculate;
                        ToolGroupModel_Temp.GroupID = 5;

                        //工具1
                        ToolInfo ToolInfo_ScriptCaculate = new ToolInfo();
                        ToolInfo_ScriptCaculate.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_ScriptCaculate.toolenable = true;
                        ToolInfo_ScriptCaculate.toolName = "脚本运行";
                        ToolInfo_ScriptCaculate.toolMethod = "RunScript";
                        ToolInfo_ScriptCaculate.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_ScriptCaculate.toolID = 16;

                        ToolInfo_ScriptCaculate.Now_Step = -1;
                        ToolInfo_ScriptCaculate.Next_Step = -1;
                        ToolInfo_ScriptCaculate.tool_Mode = false;
                        //input                     
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_ScriptCaculate);

                        //工具2
                        ToolInfo ToolInfo_ScriptCaculate1 = new ToolInfo();
                        ToolInfo_ScriptCaculate1.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_ScriptCaculate1.toolenable = true;
                        ToolInfo_ScriptCaculate1.toolName = "脚本刷新界面";
                        ToolInfo_ScriptCaculate1.toolMethod = "RunScript_Refresh";
                        ToolInfo_ScriptCaculate1.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_ScriptCaculate1.toolID = 17;

                        ToolInfo_ScriptCaculate1.Now_Step = -1;
                        ToolInfo_ScriptCaculate1.Next_Step = -1;
                        ToolInfo_ScriptCaculate1.tool_Mode = false;
                        //input                     
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_ScriptCaculate1);
                        break;

                    case "Refresh.Form_Refresh":
                        ToolGroupModel_Temp.GroupClassName = "Service_Refresh";
                        ToolGroupModel_Temp.GroupID = 6;

                        ToolInfo ToolInfo_Refresh = new ToolInfo();
                        ToolInfo_Refresh.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Refresh.toolenable = true;
                        ToolInfo_Refresh.toolName = "数据界面刷新";
                        ToolInfo_Refresh.toolMethod = "TestResultRefresh";
                        ToolInfo_Refresh.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Refresh.toolID = 18;

                        ToolInfo_Refresh.Now_Step = -1;
                        ToolInfo_Refresh.Next_Step = -1;
                        ToolInfo_Refresh.tool_Mode = false;
                        //input                     
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Refresh);

                        ToolInfo ToolInfo_Refresh1 = new ToolInfo();
                        ToolInfo_Refresh1.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Refresh1.toolenable = true;
                        ToolInfo_Refresh1.toolName = "计数界面刷新";
                        ToolInfo_Refresh1.toolMethod = "ProStatisticsRefresh";
                        ToolInfo_Refresh1.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Refresh1.toolID = 19;

                        ToolInfo_Refresh1.Now_Step = -1;
                        ToolInfo_Refresh1.Next_Step = -1;
                        ToolInfo_Refresh1.tool_Mode = false;
                        //input                     
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Refresh1);

                        
                        ToolInfo ToolInfo_Refresh2 = new ToolInfo();
                        ToolInfo_Refresh2.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Refresh2.toolenable = true;
                        ToolInfo_Refresh2.toolName = "界面初始化";
                        ToolInfo_Refresh2.toolMethod = "IniRefresh";
                        ToolInfo_Refresh2.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Refresh2.toolID = 20;

                        ToolInfo_Refresh2.Now_Step = -1;
                        ToolInfo_Refresh2.Next_Step = -1;
                        ToolInfo_Refresh2.tool_Mode = false;
                        //input                     
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Refresh2);
                        break;

                    case "Logic.Form_Logic":
                        ToolGroupModel_Temp.GroupClassName = "Service_Logic";
                        ToolGroupModel_Temp.GroupID = 7;

                        ToolInfo ToolInfo_Logic = new ToolInfo();
                        ToolInfo_Logic.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Logic.toolenable = true;
                        ToolInfo_Logic.toolName = "循环开始";
                        ToolInfo_Logic.toolMethod = "While_Start";
                        ToolInfo_Logic.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Logic.toolID = 21;

                        ToolInfo_Logic.Now_Step = -1;
                        ToolInfo_Logic.Next_Step = -1;
                        ToolInfo_Logic.tool_Mode = false;
                        //input                     
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Logic);

                        ToolInfo ToolInfo_Logic1 = new ToolInfo();
                        ToolInfo_Logic1.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Logic1.toolenable = true;
                        ToolInfo_Logic1.toolName = "循环结束";
                        ToolInfo_Logic1.toolMethod = "While_Stop";
                        ToolInfo_Logic1.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_Logic1.toolID = 22;

                        ToolInfo_Logic1.Now_Step = -1;
                        ToolInfo_Logic1.Next_Step = -1;
                        ToolInfo_Logic1.tool_Mode = false;
                        //input                     
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_Logic1);
                        break;

                    case "System.Form_System":
                        ToolGroupModel_Temp.GroupClassName = "Service_System";
                        ToolGroupModel_Temp.GroupID = 7;

                        ToolInfo ToolInfo_System = new ToolInfo();
                        ToolInfo_System.toolGroupName = ToolGroupModel_Temp.GroupName;
                        ToolInfo_System.toolenable = true;
                        ToolInfo_System.toolName = "延时";
                        ToolInfo_System.toolMethod = "Delay";
                        ToolInfo_System.toolTipInfo = ToolGroupModel_Temp.GroupName;
                        ToolInfo_System.toolID = 23;

                        ToolInfo_System.Now_Step = -1;
                        ToolInfo_System.Next_Step = -1;
                        ToolInfo_System.tool_Mode = false;
                        //input 
                        ToolInfo_System.input = new List<ToolIO>();
                        ToolIO ToolIO_System_Input = new ToolIO();
                        ToolIO_System_Input.IOName = "延时时间s";
                        ToolIO_System_Input.IOInfo = false;
                        ToolIO_System_Input.IOCategory = "输入变量";
                        ToolIO_System_Input.Binding = false;
                        ToolIO_System_Input.IOType = "double";
                        ToolIO_System_Input.TypeConverter = "double";
                        ToolInfo_System.input.Add(ToolIO_System_Input);
                        //output
                        //增加到ToolInfo
                        ToolGroupModel_Temp.tools.Add(ToolInfo_System);
                        break;
                    default:
                        break;
                }
                ToolGroupsList.Add(ToolGroupModel_Temp);
            }
            bool result = XmlObjConvert.SerializeObject(ToolGroupsList, Xml_Addr);
        }



        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SC_CLOSE))
            {

                if (MessageBox.Show("确定要关闭程序吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    FormToModel();
                    for (int i = 0; i < dataGridView_Tools.Rows.Count; i++)
                    {

                        ((Form)dataGridView_Tools.Rows[i].Tag).Dispose();

                    }

                    this.Dispose();
                    //Application.Exit();
                    System.Environment.Exit(0);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
            base.WndProc(ref m);
        }
        /// <summary>
        /// 项目选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_FixtureName_Click(object sender, EventArgs e)
        {
            dialog_ProjectChoose  = new Dialog_ProjectChoose.Dialog_ProjectChoose("ROOT");
            dialog_ProjectChoose.ProjectChoosedEvent += new Dialog_ProjectChoose.Dialog_ProjectChoose.MyDelegate(Dialog_ProjectChoose_ProjectChoosedEvent);
            dialog_ProjectChoose.Show();


        }
        /// <summary>
        /// 项目选择成功后的事件
        /// </summary>
        /// <param name="str"></param>
        private void Dialog_ProjectChoose_ProjectChoosedEvent(string str)
        {
            string[] strPrjChooseClick = str.Split('_');
            if (strPrjChooseClick[0] == "ProjectChoosed")
            {
               
                //判断文件是否存在
                if (!Directory.Exists(Dialog_ProjectChoose.ProjectChoose.strMyDBLoad))
                {
                    MessageBox.Show("选定的项目不存在,请进入ROOT权限重新选择默认项目");
                    return;
                }
                label_FixtureName.Text = Dialog_ProjectChoose.ProjectChoose.ProjectName;

                //项目选择成功事件，在这里插入用户代码----------------------------------------------------------
                //这里添加项目选择后的代码
                #region 
                //1.加载Xml
                bool result = true;
                Xml_Addr = @"D:\Program Files\ThisEquipment\PrjDatabase\Project\" + Dialog_ProjectChoose.ProjectChoose.ProjectName + @"\ToolGroups.xml";
                ToolGroupsList = XmlObjConvert.DeserializeObjectFromPath<List<ToolGroupModel>>(Xml_Addr, out result);

                //2.ModelToForm
                ModelToForm();

                //3.允许添加工具
                btn_addDevice.Enabled = true;

                //4.项目切换
                label_FixtureName.Enabled = false;
                #endregion
            }

        }
    }
}
