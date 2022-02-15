using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ThisEquipment.Properties;

namespace Inovance
{
    public partial class Form_Inovance : Form
    {
        #region 1.公有变量
        public Service_Inovance Service_Inovance;
        #endregion
        #region 2.私有变量
        /// <summary>
        /// 线程刷新
        /// </summary>
        public Thread Refresh;
       
        #endregion
        #region 3.构造函数
        public Form_Inovance()
        {
            InitializeComponent();
            //1.实例化Service
            Service_Inovance = new Service_Inovance();
            //2.设置Form格式         
            Ini_Form();


            //3.ModelToForm 
            ModelToForm();
            //4.线程开启
            Refresh = new Thread(new ThreadStart(Service_Inovance.Read_PLC));
            Refresh.IsBackground = true;
            Refresh.Start();
            //4.定时器开启
            timer_Refresh.Enabled = true;

        }
        public Form_Inovance(Model_Inovance Model_Inovance)
        {
            InitializeComponent();
            //1.实例化Service
            Service_Inovance = new Service_Inovance();
            Service_Inovance.Model_Inovance = Model_Inovance;
            //2.设置Form格式         
            Ini_Form();


            //3.ModelToForm 
            ModelToForm();
            //4.线程开启
            Refresh = new Thread(new ThreadStart(Service_Inovance.Read_PLC));
            Refresh.IsBackground = true;
            Refresh.Start();
            //4.定时器开启
            timer_Refresh.Enabled = true;

        }
        #endregion
        #region 4.私有方法
        /// <summary>
        /// 实例化界面
        /// </summary>
        #region Ini_Form
        private void Ini_Form()
        {
            //1.实例化ListView
            Ini_ListView();
            //2.实例化DataGridView
            Ini_DataGridView(dgv_Input);
            //3.实例化DataGridView
            Ini_DataGridView(dgv_Output);
            //3.实例化DataGridView_Axis
            Ini_DataGridView(dgv_Axis);
            //4.实例化气缸界面
            Ini_CyDataGridView();
            //5.其他
            Ini_Other();


        }

        /// <summary>
        /// 初始化控件ListView
        /// </summary>
        private void Ini_ListView()
        {
            #region 初始化表格1样式
            //初始化控件ListView样式
            listView1.View = View.Details;      //Set to details view.细节显示
            listView1.LabelEdit = true;         //允许用户添加编辑条款
            listView1.AllowColumnReorder = true;//Allow the user rearrange columns允许用户从新排列
            listView1.CheckBoxes = false;       //DisPlay CheckBox显示打钩的框
            listView1.FullRowSelect = true;     //整行选择
            listView1.Sorting = SortOrder.None; //排序方式
            listView1.GridLines = true;         //显示网格线
            listView1.MultiSelect = false;      //禁止ListView选择多项


            //实例化表头1
            listView1.Columns.Clear();
            listView1.Items.Clear();

            int columnWidth = listView1.Width;
            listView1.Columns.Add("ID", Convert.ToInt16(0.05 * listView1.Width), HorizontalAlignment.Center);
            listView1.Columns.Add("Axis1Pos", Convert.ToInt16(0.118 * columnWidth), HorizontalAlignment.Center);
            listView1.Columns.Add("Axis2Pos", Convert.ToInt16(0.118 * columnWidth), HorizontalAlignment.Center);
            listView1.Columns.Add("Axis3Pos", Convert.ToInt16(0.118 * columnWidth), HorizontalAlignment.Center);
            listView1.Columns.Add("Axis4Pos", Convert.ToInt16(0.118 * columnWidth), HorizontalAlignment.Center);
            listView1.Columns.Add("Axis1Vel", Convert.ToInt16(0.118 * columnWidth), HorizontalAlignment.Center);
            listView1.Columns.Add("Axis2Vel", Convert.ToInt16(0.118 * columnWidth), HorizontalAlignment.Center);
            listView1.Columns.Add("Axis3Vel", Convert.ToInt16(0.118 * columnWidth), HorizontalAlignment.Center);
            listView1.Columns.Add("Axis4Vel", Convert.ToInt16(0.118 * columnWidth), HorizontalAlignment.Center);
            #endregion
        }
        /// <summary>
        /// 初始化控件DataGridView
        /// </summary>
        /// <param name="dgv"></param>
        public void Ini_DataGridView(DataGridView dgv)
        {
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            //去除DataGridView自带的一行
            dgv.AllowUserToAddRows = false;
            //列自动填充
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //允许编辑
            dgv.Enabled = true;
            //选择
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ////编辑模式为输入后编辑
            //dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            //禁止排序
            dgv.AllowUserToDeleteRows = false;



        }

        public void Ini_CyDataGridView()
        {

            dataGridView_Cy.ScrollBars = ScrollBars.Both;
            //列自动填充
            dataGridView_Cy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //不允许编辑
            dataGridView_Cy.Enabled = true;
            //选择
            dataGridView_Cy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ////定义弹出框
            //dataGridView_Cy.contextMenuStrip_mouse = new ContextMenuStrip();
            //去除DataGridView自带的一行
            dataGridView_Cy.AllowUserToAddRows = false;
            //// 行头隐藏
            //RowHeadersVisible = false;
            ////拷贝时不拷贝头
            //ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }
        private void Ini_Other()
        {
            this.contextMenuStrip_Output.Items[0].Click += new System.EventHandler(ON_ToolStripMenuItem_Click);
            this.contextMenuStrip_Output.Items[1].Click += new System.EventHandler(OFF_ToolStripMenuItem_Click);
            this.contextMenuStrip_Cy.Items[0].Click += new System.EventHandler(CyON_ToolStripMenuItem_Click);
            this.contextMenuStrip_Cy.Items[1].Click += new System.EventHandler(CyOFF_ToolStripMenuItem_Click);
        }
        #endregion
        #region ModelToForm
        private void ModelToForm()
        {
            Model_ListView();
            Model_Dgv();
            Model_DgvAxis();
            Model_Others();
            Model_DgvCy();
        }
        /// <summary>
        /// 实例化ListView
        /// </summary>

        private void Model_ListView()
        {
            listView1.Items.Clear();
            if (Service_Inovance.Model_Inovance.ListPointPosition == null) return;
            for (int i = 0; i < Service_Inovance.Model_Inovance.ListPointPosition.Count(); i++)
            {
                ListViewItem lItem = new ListViewItem();
                lItem.Text = Service_Inovance.Model_Inovance.ListPointPosition[i].ID.ToString();
                lItem.SubItems.Add(Service_Inovance.Model_Inovance.ListPointPosition[i].Axis1Position.ToString());
                lItem.SubItems.Add(Service_Inovance.Model_Inovance.ListPointPosition[i].Axis2Position.ToString());
                lItem.SubItems.Add(Service_Inovance.Model_Inovance.ListPointPosition[i].Axis3Position.ToString());
                lItem.SubItems.Add(Service_Inovance.Model_Inovance.ListPointPosition[i].Axis4Position.ToString());
                lItem.SubItems.Add(Service_Inovance.Model_Inovance.ListPointPosition[i].Axis1Velocity.ToString());
                lItem.SubItems.Add(Service_Inovance.Model_Inovance.ListPointPosition[i].Axis2Velocity.ToString());
                lItem.SubItems.Add(Service_Inovance.Model_Inovance.ListPointPosition[i].Axis3Velocity.ToString());
                lItem.SubItems.Add(Service_Inovance.Model_Inovance.ListPointPosition[i].Axis4Velocity.ToString());
                listView1.Items.Add(lItem);
            }
            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
            }
        }
        private void Model_Dgv()
        {
            //1.判断参数是否正确
            if ((Service_Inovance.Model_Inovance.Input.Count != 32) || (Service_Inovance.Model_Inovance.Output.Count != 32))
            {
                Service_Inovance.Model_Inovance.Input.Clear();
                Service_Inovance.Model_Inovance.Output.Clear();
                for (int i = 0; i < 32; i++)
                {

                    IO temp = new IO();
                    temp.IO_Index = i;
                    switch (i)
                    {
                        case 0:
                            temp.IO_Name = "急停";
                            break;
                        case 1:
                            temp.IO_Name = "复位";
                            break;
                        case 2:
                            temp.IO_Name = "门开关";
                            break;
                        case 3:
                            temp.IO_Name = "安全光栅";
                            break;


                        default:
                            temp.IO_Name = "";
                            break;
                    }


                    Service_Inovance.Model_Inovance.Input.Add(temp);

                    IO temp1 = new IO();
                    temp1.IO_Index = 0;
                    switch (i)
                    {
                        case 0:
                            temp1.IO_Name = "三色灯红";
                            break;
                        case 1:
                            temp1.IO_Name = "三色灯绿";
                            break;
                        case 2:
                            temp1.IO_Name = "三色灯黄";
                            break;
                        case 3:
                            temp1.IO_Name = "三色灯蜂鸣器";
                            break;
                        default:
                            temp1.IO_Name = "";
                            break;
                    }
                    Service_Inovance.Model_Inovance.Output.Add(temp1);
                }
                //MessageBox.Show("IO参数设置错误，请重新输入");
            }
            //2.初始化控件1
            dgv_Input.Rows.Clear();
            for (int i = 0; i < 32; i++)
            {
                DataGridViewRow dr = new DataGridViewRow();

                foreach (DataGridViewColumn c in dgv_Input.Columns)
                {
                    dr.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                }

                dr.Cells[0].Value = i;
                int a = i / 8;
                int b = i % 8;
                dr.Cells[1].Value = "IX:" + (a + 2).ToString() + "." + b.ToString();
                dr.Cells[2].Value = Service_Inovance.Model_Inovance.Input[i].IO_Name;

                this.dgv_Input.Rows.Add(dr);
            }


            // 3.初始化控件2
            dgv_Output.Rows.Clear();
            for (int i = 0; i < 32; i++)
            {
                DataGridViewRow dr = new DataGridViewRow();

                foreach (DataGridViewColumn c in dgv_Input.Columns)
                {
                    dr.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                }
                dr.Cells[0].Value = i;
                int a = i / 8;
                int b = i % 8;
                dr.Cells[1].Value = "QX:" + (a + 1).ToString() + "." + b.ToString();
                dr.Cells[2].Value = Service_Inovance.Model_Inovance.Output[i].IO_Name;
                this.dgv_Output.Rows.Add(dr);
            }

        }
        private void Model_DgvAxis()
        {
            dgv_Axis.Rows.Clear();
            for (int i = 0; i < 4; i++)
            {
                DataGridViewRow dr = new DataGridViewRow();

                foreach (DataGridViewColumn c in dgv_Axis.Columns)
                {
                    dr.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                }
                switch (i)
                {
                    case 0:
                        dr.Cells[0].Value = "轴1";
                        dr.Cells[1].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_Position;
                        dr.Cells[2].Value = Service_Inovance.Model_Inovance.motorpara.Axis1_Upperlimit;
                        dr.Cells[3].Value = Service_Inovance.Model_Inovance.motorpara.Axis1_Lowerlimit;
                        dr.Cells[4].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_Ori ? Resources.On : Resources.Off;
                        dr.Cells[5].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_N ? Resources.On : Resources.Off;
                        dr.Cells[6].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_P ? Resources.On : Resources.Off;
                        dr.Cells[7].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_Error ? Resources.Red : Resources.Off;
                        break;
                    case 1:
                        dr.Cells[0].Value = "轴2";
                        dr.Cells[1].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_Position;
                        dr.Cells[2].Value = Service_Inovance.Model_Inovance.motorpara.Axis2_Upperlimit;
                        dr.Cells[3].Value = Service_Inovance.Model_Inovance.motorpara.Axis2_Lowerlimit;
                        dr.Cells[4].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_Ori ? Resources.On : Resources.Off;
                        dr.Cells[5].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_N ? Resources.On : Resources.Off;
                        dr.Cells[6].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_P ? Resources.On : Resources.Off;
                        dr.Cells[7].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_Error ? Resources.Red : Resources.Off;
                        break;
                    case 2:
                        dr.Cells[0].Value = "轴3";
                        dr.Cells[1].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_Position;
                        dr.Cells[2].Value = Service_Inovance.Model_Inovance.motorpara.Axis3_Upperlimit;
                        dr.Cells[3].Value = Service_Inovance.Model_Inovance.motorpara.Axis3_Lowerlimit;
                        dr.Cells[4].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_Ori ? Resources.On : Resources.Off;
                        dr.Cells[5].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_N ? Resources.On : Resources.Off;
                        dr.Cells[6].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_P ? Resources.On : Resources.Off;
                        dr.Cells[7].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_Error ? Resources.Red : Resources.Off;
                        break;
                    case 3:
                        dr.Cells[0].Value = "轴4";
                        dr.Cells[1].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_Position;
                        dr.Cells[2].Value = Service_Inovance.Model_Inovance.motorpara.Axis4_Upperlimit;
                        dr.Cells[3].Value = Service_Inovance.Model_Inovance.motorpara.Axis4_Lowerlimit;
                        dr.Cells[4].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_Ori ? Resources.On : Resources.Off;
                        dr.Cells[5].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_N ? Resources.On : Resources.Off;
                        dr.Cells[6].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_P ? Resources.On : Resources.Off;
                        dr.Cells[7].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_Error ? Resources.Red : Resources.Off;
                        break;
                    default:
                        break;


                }
                dgv_Axis.Rows.Add(dr);
            }

        }
        private void Model_Others()
        {
            numericUpDown_Axis1_Pos.Value = 0;
            numericUpDown_Axis2_Pos.Value = 0;
            numericUpDown_Axis3_Pos.Value = 0;
            numericUpDown_Axis4_Pos.Value = 0;
        }
        private void Model_DgvCy()
        {
            //测试段
            dataGridView_Cy.Rows.Clear();

            try
            {
                for (int i = 0; i < Service_Inovance.Model_Inovance.Para_Cylinders.Count; i++)
                {

                    DataGridViewRow Add_Row = new DataGridViewRow();
                    Add_Row.CreateCells(dataGridView_Cy);
                    Add_Row.Cells[0].Value = Service_Inovance.Model_Inovance.Para_Cylinders[i].Cy_Name.ToString();
                    Add_Row.Cells[1].Value = Service_Inovance.Model_Inovance.Para_Cylinders[i].Cy_Ori_Sensor_Status ? Resources.On : Resources.Off;
                    Add_Row.Cells[2].Value = Service_Inovance.Model_Inovance.Para_Cylinders[i].Cy_Work_Sensor_Status ? Resources.On : Resources.Off;
                    Add_Row.Cells[3].Value = Service_Inovance.Model_Inovance.Para_Cylinders[i].bError ? Resources.Red : Resources.Off;


                    dataGridView_Cy.Rows.Add(Add_Row);
                }
            }
            catch
            {

            }
        }
        #endregion
        #endregion
        #region 5.公有方法
        #endregion
        #region 6.按钮操作
        #region 6.1轴控界面
        private void button_LvUp_Click(object sender, EventArgs e)
        {
            Class_ListView.ListViewUpMove(this.listView1);

        }

        private void button_LvDown_Click(object sender, EventArgs e)
        {
            Class_ListView.ListViewDownMove(this.listView1);
        }

        private void button_LvDelete_Click(object sender, EventArgs e)
        {

            Class_ListView.ListViewRemove(this.listView1);

        }

        private void button_LvClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void btn_LvSave_Click(object sender, EventArgs e)
        {
            Service_Inovance.Model_Inovance.motorpara.Axis1_Upperlimit = Convert.ToDouble(dgv_Axis.Rows[0].Cells[2].Value);
            Service_Inovance.Model_Inovance.motorpara.Axis1_Lowerlimit = Convert.ToDouble(dgv_Axis.Rows[0].Cells[3].Value);
            Service_Inovance.Model_Inovance.motorpara.Axis2_Upperlimit = Convert.ToDouble(dgv_Axis.Rows[1].Cells[2].Value);
            Service_Inovance.Model_Inovance.motorpara.Axis2_Lowerlimit = Convert.ToDouble(dgv_Axis.Rows[1].Cells[3].Value);
            Service_Inovance.Model_Inovance.motorpara.Axis3_Upperlimit = Convert.ToDouble(dgv_Axis.Rows[2].Cells[2].Value);
            Service_Inovance.Model_Inovance.motorpara.Axis3_Lowerlimit = Convert.ToDouble(dgv_Axis.Rows[2].Cells[3].Value);
            Service_Inovance.Model_Inovance.motorpara.Axis4_Upperlimit = Convert.ToDouble(dgv_Axis.Rows[3].Cells[2].Value);
            Service_Inovance.Model_Inovance.motorpara.Axis4_Lowerlimit = Convert.ToDouble(dgv_Axis.Rows[3].Cells[3].Value);
            Service_Inovance.Model_Inovance.ListPointPosition.Clear();
            if (listView1.Items.Count <= 0) return;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                PointPosition thisPointPosition = new PointPosition();
                thisPointPosition.ID = i;//这里调整ID顺序
                thisPointPosition.Axis1Position = Convert.ToDouble(listView1.Items[i].SubItems[1]?.Text);
                thisPointPosition.Axis2Position = Convert.ToDouble(listView1.Items[i].SubItems[2]?.Text);
                thisPointPosition.Axis3Position = Convert.ToDouble(listView1.Items[i].SubItems[3]?.Text);
                thisPointPosition.Axis4Position = Convert.ToDouble(listView1.Items[i].SubItems[4]?.Text);

                thisPointPosition.Axis1Velocity = Convert.ToDouble(listView1.Items[i].SubItems[5]?.Text);
                thisPointPosition.Axis2Velocity = Convert.ToDouble(listView1.Items[i].SubItems[6]?.Text);
                thisPointPosition.Axis3Velocity = Convert.ToDouble(listView1.Items[i].SubItems[7]?.Text);
                thisPointPosition.Axis4Velocity = Convert.ToDouble(listView1.Items[i].SubItems[8]?.Text);

                Service_Inovance.Model_Inovance.ListPointPosition.Add(thisPointPosition);
            }


            //Service_Inovance.Save_Model();
        }

        /// <summary>
        /// 切换步进值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            decimal decIncrement = 0;
            if (sender == radioButton1)
            {
                decIncrement = Convert.ToDecimal(0.01);
            }
            else if (sender == radioButton2)
            {
                decIncrement = Convert.ToDecimal(0.1);
            }
            else if (sender == radioButton3)
            {
                decIncrement = Convert.ToDecimal(1);
            }
            else if (sender == radioButton4)
            {
                decIncrement = Convert.ToDecimal(10);
            }
            else if (sender == radioButton5)
            {
                decIncrement = Convert.ToDecimal(0.001);
            }
            else
            {
                decIncrement = 0;
            }

            numericUpDown_Axis1_Pos.Increment = decIncrement;
            numericUpDown_Axis2_Pos.Increment = decIncrement;
            numericUpDown_Axis3_Pos.Increment = decIncrement;
            numericUpDown_Axis4_Pos.Increment = decIncrement;
        }

        /// <summary>
        /// 将表选择位置赋值给当前需要运行的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem lvItem = new ListViewItem();
            if (listView1.SelectedItems.Count > 0)
                lvItem = listView1.SelectedItems[0];
            else
                return;

            numericUpDown_Axis1_Pos.Value = Convert.ToDecimal(lvItem.SubItems[1].Text);
            numericUpDown_Axis2_Pos.Value = Convert.ToDecimal(lvItem.SubItems[2].Text);
            numericUpDown_Axis3_Pos.Value = Convert.ToDecimal(lvItem.SubItems[3].Text);
            numericUpDown_Axis4_Pos.Value = Convert.ToDecimal(lvItem.SubItems[4].Text);

            numericUpDownAxis1speed.Value = Convert.ToDecimal(lvItem.SubItems[5].Text);
            numericUpDownAxis2speed.Value = Convert.ToDecimal(lvItem.SubItems[6].Text);
            numericUpDownAxis3speed.Value = Convert.ToDecimal(lvItem.SubItems[7].Text);
            numericUpDownAxis4speed.Value = Convert.ToDecimal(lvItem.SubItems[8].Text);



        }


        /// <summary>
        /// 加当前检测点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AddCurrentPos_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Decimal.ToDouble(numericUpDown_Axis1_Pos.Value) < Service_Inovance.Model_Inovance.motorpara.Axis1_Lowerlimit) | (Decimal.ToDouble(numericUpDown_Axis1_Pos.Value) > Service_Inovance.Model_Inovance.motorpara.Axis1_Upperlimit))
                {
                    MessageBox.Show("轴1超出极限", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if ((Decimal.ToDouble(numericUpDown_Axis2_Pos.Value) < Service_Inovance.Model_Inovance.motorpara.Axis2_Lowerlimit) | (Decimal.ToDouble(numericUpDown_Axis2_Pos.Value) > Service_Inovance.Model_Inovance.motorpara.Axis2_Upperlimit))
                {
                    MessageBox.Show("轴2超出极限", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if ((Decimal.ToDouble(numericUpDown_Axis3_Pos.Value) < Service_Inovance.Model_Inovance.motorpara.Axis3_Lowerlimit) | (Decimal.ToDouble(numericUpDown_Axis3_Pos.Value) > Service_Inovance.Model_Inovance.motorpara.Axis3_Upperlimit))
                {
                    MessageBox.Show("轴3超出极限", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if ((Decimal.ToDouble(numericUpDown_Axis4_Pos.Value) < Service_Inovance.Model_Inovance.motorpara.Axis4_Lowerlimit) | (Decimal.ToDouble(numericUpDown_Axis4_Pos.Value) > Service_Inovance.Model_Inovance.motorpara.Axis4_Upperlimit))
                {
                    MessageBox.Show("轴4超出极限", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }


                ListViewItem item = new ListViewItem();
                item.Text = (listView1.Items.Count).ToString();
                item.SubItems.Add(string.Format("{0:0.000}", numericUpDown_Axis1_Pos.Value));
                item.SubItems.Add(string.Format("{0:0.000}", numericUpDown_Axis2_Pos.Value));
                item.SubItems.Add(string.Format("{0:0.000}", numericUpDown_Axis3_Pos.Value));
                item.SubItems.Add(string.Format("{0:0.000}", numericUpDown_Axis4_Pos.Value));
                item.SubItems.Add(string.Format("{0:0.000}", numericUpDownAxis1speed.Value));
                item.SubItems.Add(string.Format("{0:0.000}", numericUpDownAxis2speed.Value));
                item.SubItems.Add(string.Format("{0:0.000}", numericUpDownAxis3speed.Value));
                item.SubItems.Add(string.Format("{0:0.000}", numericUpDownAxis4speed.Value));

                listView1.Items.Add(item);

                Class_ListView.Listview_Refresh_ID(this.listView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        /// <summary>
        /// 设置当前位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SetTestHome_Click(object sender, EventArgs e)
        {
            numericUpDown_Axis1_Pos.Value = Convert.ToDecimal(Service_Inovance.Property_Inovance.PC_Axis1.Axis_Position.ToString("0.000"));
            numericUpDown_Axis2_Pos.Value = Convert.ToDecimal(Service_Inovance.Property_Inovance.PC_Axis2.Axis_Position.ToString("0.000"));
            numericUpDown_Axis3_Pos.Value = Convert.ToDecimal(Service_Inovance.Property_Inovance.PC_Axis3.Axis_Position.ToString("0.000"));
            numericUpDown_Axis4_Pos.Value = Convert.ToDecimal(Service_Inovance.Property_Inovance.PC_Axis4.Axis_Position.ToString("0.000"));
        }

        /// <summary>
        /// 轴移动到指定位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Axis1Move_Click(object sender, EventArgs e)
        {
            numericUpDown_Axis1_Pos.Enabled = false;
            numericUpDown_Axis2_Pos.Enabled = false;
            numericUpDown_Axis3_Pos.Enabled = false;
            numericUpDown_Axis4_Pos.Enabled = false;
            button_Axis1Move.Enabled = false;
            button_Axis1Minus.Enabled = false;
            groupBox3.Enabled = false;


            PointPosition movePoint = new PointPosition();
            movePoint.Axis1Position = Decimal.ToDouble(numericUpDown_Axis1_Pos.Value);
            movePoint.Axis2Position = Decimal.ToDouble(numericUpDown_Axis2_Pos.Value);
            movePoint.Axis3Position = Decimal.ToDouble(numericUpDown_Axis3_Pos.Value);
            movePoint.Axis4Position = Decimal.ToDouble(numericUpDown_Axis4_Pos.Value);
            movePoint.Axis1Velocity = Decimal.ToDouble(numericUpDownAxis1speed.Value);
            movePoint.Axis2Velocity = Decimal.ToDouble(numericUpDownAxis2speed.Value);
            movePoint.Axis3Velocity = Decimal.ToDouble(numericUpDownAxis3speed.Value);
            movePoint.Axis4Velocity = Decimal.ToDouble(numericUpDownAxis4speed.Value);

            if (Service_Inovance.MoveSettingPosition(movePoint))
            {

                //numericUpDown_Axis1_Pos.Value = Convert.ToDecimal(labelNowPosition_Axis1.Text);
                //numericUpDown_Axis2_Pos.Value = Convert.ToDecimal(labelNowPosition_Axis2.Text);
                //numericUpDown_Axis3_Pos.Value = Convert.ToDecimal(labelNowPosition_Axis3.Text);
                //numericUpDown_Axis4_Pos.Value = Convert.ToDecimal(labelNowPosition_Axis4.Text);

            }
            else
            {
                MessageBox.Show("执行失败！");
            }
            numericUpDown_Axis1_Pos.Enabled = true;
            numericUpDown_Axis2_Pos.Enabled = true;
            numericUpDown_Axis3_Pos.Enabled = true;
            numericUpDown_Axis4_Pos.Enabled = true;
            button_Axis1Move.Enabled = true;
            button_Axis1Minus.Enabled = true;
            groupBox3.Enabled = true;
        }
        /// <summary>
        /// 回待机点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestHome_Click(object sender, EventArgs e)
        {

            groupBox3.Enabled = false;
            if (!Service_Inovance.MoveWaitPosition())
            {
                MessageBox.Show("执行失败!");
            };
            groupBox3.Enabled = true;
        }
        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            if (!Service_Inovance.HomeAll())
            {
                MessageBox.Show("执行失败!");
            };
            groupBox3.Enabled = true;
        }
        /// <summary>
        /// 错误复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Reset_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            if (!Service_Inovance.Reset())
            {
                MessageBox.Show("执行失败!");
            };
            groupBox3.Enabled = true;
        }

        private void button_SavePara_Click(object sender, EventArgs e)
        {
            try
            {
                Service_Inovance.Model_Inovance.motorpara.Axis1_Upperlimit = Convert.ToDouble(dgv_Axis.Rows[0].Cells[1].Value);
                Service_Inovance.Model_Inovance.motorpara.Axis1_Lowerlimit = Convert.ToDouble(dgv_Axis.Rows[0].Cells[2].Value);

                Service_Inovance.Model_Inovance.motorpara.Axis2_Upperlimit = Convert.ToDouble(dgv_Axis.Rows[1].Cells[1].Value);
                Service_Inovance.Model_Inovance.motorpara.Axis2_Lowerlimit = Convert.ToDouble(dgv_Axis.Rows[1].Cells[2].Value);

                Service_Inovance.Model_Inovance.motorpara.Axis3_Upperlimit = Convert.ToDouble(dgv_Axis.Rows[2].Cells[1].Value);
                Service_Inovance.Model_Inovance.motorpara.Axis3_Lowerlimit = Convert.ToDouble(dgv_Axis.Rows[2].Cells[2].Value);

                Service_Inovance.Model_Inovance.motorpara.Axis4_Upperlimit = Convert.ToDouble(dgv_Axis.Rows[3].Cells[1].Value);
                Service_Inovance.Model_Inovance.motorpara.Axis4_Lowerlimit = Convert.ToDouble(dgv_Axis.Rows[3].Cells[2].Value);
            }
            catch
            {

                MessageBox.Show("参数错误！");
            }


        }

        private void button_AxisStop_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            if (!Service_Inovance.Stop())
            {
                MessageBox.Show("执行失败!");
            };
            groupBox3.Enabled = true;
        }
        #endregion
        #region 6.2 IO界面
        /// <summary>
        /// 强制IO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Output_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv_Output.SelectedRows.Count <= 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {


                this.contextMenuStrip_Output.Show(MousePosition);
            }

        }
        private void ON_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Adress = dgv_Output.SelectedRows[0].Index;
            Service_Inovance.SetOutput(Adress);
        }
        private void OFF_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Adress = dgv_Output.SelectedRows[0].Index;
            Service_Inovance.ResetOutput(Adress);

        }
        #endregion
        #region 6.3气缸界面
        private void dataGridView_Cy_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView_Cy.SelectedRows.Count <= 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {

                contextMenuStrip_Cy.Show(MousePosition);
            }
        }
        private void CyON_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cy.SelectedRows.Count > 0 & (dataGridView_Cy.CurrentRow.Cells[0].Value != null))
            {
                if (Service_Inovance.Cy_OnlyWork(dataGridView_Cy.CurrentRow.Cells[0].Value.ToString()))
                {
                    //MessageBox.Show("执行成功");
                }
                else
                {
                    // MessageBox.Show("执行失败");
                }
            }
        }
        private void CyOFF_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cy.SelectedRows.Count > 0 & (dataGridView_Cy.CurrentRow.Cells[0].Value != null))
            {

                if (Service_Inovance.Cy_OnlyOri(dataGridView_Cy.CurrentRow.Cells[0].Value.ToString()))
                {
                    //MessageBox.Show("执行成功");
                }
                else
                {
                    //MessageBox.Show("执行失败");
                }
            }
        }
        #endregion
        #region 6.4 设置界面
        private void button_CySave_Click(object sender, EventArgs e)
        {
            timer_Refresh.Enabled = false;
            timer_IO.Enabled = false;
            Service_Inovance.Pause = true;

            //克隆汇川Model
            Setting_Inovance.Model_Inovance = ObjectCopier.Clone(Service_Inovance.Model_Inovance);
            Setting_Inovance temp = new Setting_Inovance();
            temp.StartPosition = FormStartPosition.CenterScreen;
            temp.ShowDialog();
            if (Setting_Inovance.Result)
            {
                Service_Inovance.Model_Inovance = ObjectCopier.Clone(Setting_Inovance.Model_Inovance);
                Model_Dgv();
                Model_DgvCy();

            }

            Service_Inovance.Pause = false;
            timer_Refresh.Enabled = true;
            timer_IO.Enabled = true;


        }

        #endregion
        #endregion
        #region 7.界面刷新

        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Start_Click(object sender, EventArgs e)
        {

            timer_IO.Enabled = true;
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            timer_IO.Enabled = false;
            for (int i = 0; i < 32; i++)
            {
                dgv_Input.Rows[i].Cells[3].Value = "";
                dgv_Input.Rows[i].Cells[3].Style.BackColor = Color.White;
                dgv_Output.Rows[i].Cells[3].Value = "";
                dgv_Output.Rows[i].Cells[3].Style.BackColor = Color.White;
            }
        }
        /// <summary>
        /// 定时刷新当前位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {


            dgv_Axis.Rows[0].Cells[0].Value = "轴1";
            dgv_Axis.Rows[0].Cells[1].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_Position.ToString("0.000");
            //dgv_Axis.Rows[0].Cells[2].Value = Service_Inovance.Model_Inovance.motorpara.Axis1_Upperlimit;
            //dgv_Axis.Rows[0].Cells[3].Value = Service_Inovance.Model_Inovance.motorpara.Axis1_Lowerlimit;
            dgv_Axis.Rows[0].Cells[4].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_Ori ? Resources.On : Resources.Off;
            dgv_Axis.Rows[0].Cells[5].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_P ? Resources.On : Resources.Off;
            dgv_Axis.Rows[0].Cells[6].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_N ? Resources.On : Resources.Off;
            dgv_Axis.Rows[0].Cells[7].Value = Service_Inovance.Property_Inovance.PC_Axis1.Axis_Error ? Resources.Red : Resources.Off;

            dgv_Axis.Rows[1].Cells[0].Value = "轴2";
            dgv_Axis.Rows[1].Cells[1].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_Position.ToString("0.000");
            //dgv_Axis.Rows[1].Cells[2].Value = Service_Inovance.Model_Inovance.motorpara.Axis2_Upperlimit;
            //dgv_Axis.Rows[1].Cells[3].Value = Service_Inovance.Model_Inovance.motorpara.Axis2_Lowerlimit;
            dgv_Axis.Rows[1].Cells[4].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_Ori ? Resources.On : Resources.Off;
            dgv_Axis.Rows[1].Cells[5].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_P ? Resources.On : Resources.Off;
            dgv_Axis.Rows[1].Cells[6].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_N ? Resources.On : Resources.Off;
            dgv_Axis.Rows[1].Cells[7].Value = Service_Inovance.Property_Inovance.PC_Axis2.Axis_Error ? Resources.Red : Resources.Off;

            dgv_Axis.Rows[2].Cells[0].Value = "轴3";
            dgv_Axis.Rows[2].Cells[1].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_Position.ToString("0.000");
            //dgv_Axis.Rows[2].Cells[2].Value = Service_Inovance.Model_Inovance.motorpara.Axis3_Upperlimit;
            //dgv_Axis.Rows[2].Cells[3].Value = Service_Inovance.Model_Inovance.motorpara.Axis3_Lowerlimit;
            dgv_Axis.Rows[2].Cells[4].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_Ori ? Resources.On : Resources.Off;
            dgv_Axis.Rows[2].Cells[5].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_P ? Resources.On : Resources.Off;
            dgv_Axis.Rows[2].Cells[6].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_N ? Resources.On : Resources.Off;
            dgv_Axis.Rows[2].Cells[7].Value = Service_Inovance.Property_Inovance.PC_Axis3.Axis_Error ? Resources.Red : Resources.Off;

            dgv_Axis.Rows[3].Cells[0].Value = "轴4";
            dgv_Axis.Rows[3].Cells[1].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_Position.ToString("0.000");
            //dgv_Axis.Rows[3].Cells[2].Value = Service_Inovance.Model_Inovance.motorpara.Axis4_Upperlimit;
            //dgv_Axis.Rows[3].Cells[3].Value = Service_Inovance.Model_Inovance.motorpara.Axis4_Lowerlimit;
            dgv_Axis.Rows[3].Cells[4].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_Ori ? Resources.On : Resources.Off;
            dgv_Axis.Rows[3].Cells[5].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_P ? Resources.On : Resources.Off;
            dgv_Axis.Rows[3].Cells[6].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_N ? Resources.On : Resources.Off;
            dgv_Axis.Rows[3].Cells[7].Value = Service_Inovance.Property_Inovance.PC_Axis4.Axis_Error ? Resources.Red : Resources.Off;






            if (Service_Inovance.Property_Inovance.HMI_PLCStartOK)
            {
                button_Axis1Move.Enabled = true;
                //btnTestHome.Enabled = true;
                btnHome.Enabled = true;
            }
            if (!Service_Inovance.Property_Inovance.HMI_PLCStartOK)
            {
                button_Axis1Move.Enabled = false;
                //btnTestHome.Enabled = false;
                btnHome.Enabled = false;
            }
            try
            {
                //气缸状态刷新
                for (int i = 0; i < Service_Inovance.Model_Inovance.Para_Cylinders.Count; i++)
                {

                    dataGridView_Cy.Rows[i].Cells[0].Style.BackColor = Service_Inovance.Model_Inovance.Para_Cylinders[i].Cy_Work_Valve_Status ? Color.GreenYellow : Color.White;
                    dataGridView_Cy.Rows[i].Cells[0].Value = Service_Inovance.Model_Inovance.Para_Cylinders[i].Cy_Name.ToString();
                    dataGridView_Cy.Rows[i].Cells[1].Value = Service_Inovance.Model_Inovance.Para_Cylinders[i].Cy_Ori_Sensor_Status ? Resources.On : Resources.Off;
                    dataGridView_Cy.Rows[i].Cells[2].Value = Service_Inovance.Model_Inovance.Para_Cylinders[i].Cy_Work_Sensor_Status ? Resources.On : Resources.Off;
                    dataGridView_Cy.Rows[i].Cells[3].Value = Service_Inovance.Model_Inovance.Para_Cylinders[i].bError ? Resources.Red : Resources.Off;
                }

            }
            catch
            {


            }


        }

        /// <summary>
        /// 显示IO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_IO_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 32; i++)
            {
                dgv_Input.Rows[i].Cells[3].Value = Service_Inovance.Model_Inovance.Input[i].IO_Value ? 1 : 0;
                dgv_Input.Rows[i].Cells[3].Style.BackColor = Service_Inovance.Model_Inovance.Input[i].IO_Value ? Color.GreenYellow : Color.White;
                dgv_Output.Rows[i].Cells[3].Value = Service_Inovance.Model_Inovance.Output[i].IO_Value ? 1 : 0;
                dgv_Output.Rows[i].Cells[3].Style.BackColor = Service_Inovance.Model_Inovance.Output[i].IO_Value ? Color.GreenYellow : Color.White;
            }
        }
        #endregion
        #region 8.界面退出

        public void Close()
        {
            
            //1.关闭使用的资源
            Service_Inovance.Stop_Thread = true;
            while ((Refresh.ThreadState != System.Threading.ThreadState.Stopped) && (Refresh.ThreadState != System.Threading.ThreadState.Aborted))
            {
                Thread.Sleep(10);
            }
            //2.关闭当前窗口
            this.Dispose();
        }
        #endregion
    }
}
