using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovance
{
    public partial class Setting_Inovance : Form
    {
        #region 1.公用静态变量，需要静态变量来带入带出数据
        public static Model_Inovance Model_Inovance;

        public static  bool Result = false;
        #endregion

        #region 2.构造函数
        public Setting_Inovance()
        {
            InitializeComponent();
            //1.设置Form格式         
            Ini_Form();
            //2.ModelToForm           
            ModelToForm();
        }

        private void Ini_Form()
        {
            //1.实例化DataGridView
            Ini_DataGridView(dgv_Input);
            //2.实例化DataGridView
            Ini_DataGridView(dgv_Output);
            //3.实例化气缸参数设置界面
            //无
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
            //编辑模式为输入后编辑
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            //禁止排序
            dgv.AllowUserToDeleteRows = false;
        }

        private void ModelToForm()
        { 
            Model_Dgv();
            Model_DgvCy();
        }
        /// <summary>
        /// Model到IO表
        /// </summary>
        private void Model_Dgv()
        {
            //1.判断参数是否正确
            if ((Model_Inovance.Input.Count != 32) || (Model_Inovance.Output.Count != 32))
            {
                Model_Inovance.Input.Clear();
                Model_Inovance.Output.Clear();
                for (int i = 0; i < 32; i++)
                {
                    IO temp = new IO();
                    temp.IO_Index = i;
                    temp.IO_Name = "";
                    Model_Inovance.Input.Add(temp);

                    IO temp1 = new IO();
                    temp1.IO_Index = 0;
                    temp1.IO_Name = "";
                    Model_Inovance.Output.Add(temp1);
                }
                MessageBox.Show("IO参数设置错误，请重新输入");
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
                dr.Cells[2].Value = Model_Inovance.Input[i].IO_Name;
                if (i < 4) 
                {
                    dr.Cells[2].ReadOnly = true;
                }
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
                dr.Cells[2].Value = Model_Inovance.Output[i].IO_Name;

                if (i < 4)
                {
                    dr.Cells[2].ReadOnly = true;
                }
                this.dgv_Output.Rows.Add(dr);
            }

        }
        /// <summary>
        /// Mode到气缸表
        /// </summary>
        private void Model_DgvCy()
        {
            //测试段
            dataGridView_Ex_Cy.Rows.Clear();

            try
            {
                for (int i = 0; i < Model_Inovance.Para_Cylinders.Count; i++)
                {

                    DataGridViewRow Add_Row = new DataGridViewRow();
                    Add_Row.CreateCells(dataGridView_Ex_Cy);
                    Add_Row.Cells[0].Value = Model_Inovance.Para_Cylinders[i].Cy_Name.ToString();
                    Add_Row.Cells[1].Value = Model_Inovance.Para_Cylinders[i].Cy_OK_DelayTime.ToString();
                    Add_Row.Cells[2].Value = Model_Inovance.Para_Cylinders[i].Cy_Ignore_DelayTime.ToString();
                    Add_Row.Cells[3].Value = Model_Inovance.Para_Cylinders[i].Cy_Alarm_Time.ToString();

                    ((DataGridViewCheckBoxCell)Add_Row.Cells[4]).Value = Model_Inovance.Para_Cylinders[i].Cy_Ori_Ignore == true ? "true" : "false";
                    ((DataGridViewCheckBoxCell)Add_Row.Cells[5]).Value = Model_Inovance.Para_Cylinders[i].Cy_Work_Ignore == true ? "true" : "false";

                    dataGridView_Ex_Cy.Rows.Add(Add_Row);
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 3.按钮操作
        private void button_Setting_Save_Click(object sender, EventArgs e)
        {
            //1.保存输入
            Model_Inovance.Input.Clear();

            for (int i = 0; i < dgv_Input.Rows.Count; i++)
            {
                IO tempIO = new IO();
                tempIO.IO_Index = i;
                tempIO.IO_Name = dgv_Input.Rows[i].Cells[2].Value?.ToString().Replace("\r", "");
                Model_Inovance.Input.Add(tempIO);
            }

            //2.保存输出
            Model_Inovance.Output.Clear();

            for (int i = 0; i < dgv_Output.Rows.Count; i++)
            {
                IO tempIO1 = new IO();
                tempIO1.IO_Index = i;
                tempIO1.IO_Name = dgv_Output.Rows[i].Cells[2].Value?.ToString().Replace("\r", "");
                Model_Inovance.Output.Add(tempIO1);
            }

            if (CyDgvToCyModel())
            {
                Result = true;
                MessageBox.Show("保存成功!");
            }
            else 
            {
                MessageBox.Show("保存失败!");
            }
        }
        private bool CyDgvToCyModel()
        {

            bool Alarm = false;
            Model_Inovance.Para_Cylinders.Clear();
            try
            {
                for (int i = 0; i < dataGridView_Ex_Cy.Rows.Count - 1; i++)
                {
                    //判断是否有重复的气缸名称
                    if (i >= 1)
                    {
                        for (int j =0; j < i; j++)
                        {
                            if (dataGridView_Ex_Cy.Rows[i].Cells[0].Value.ToString() == dataGridView_Ex_Cy.Rows[j].Cells[0].Value.ToString()) 
                            {
                                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                Alarm = true;
                               
                            }
                        }
                    }
                   

                    Para_Cylinder Cylinder = new Para_Cylinder();

                    if (dataGridView_Ex_Cy.Rows[i].Cells[0].Value?.ToString() == "")
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
                        Alarm = true;
                    }
                    else
                    {
                        Cylinder.Cy_Name = dataGridView_Ex_Cy.Rows[i].Cells[0].Value?.ToString();
                    }
                    
                    if (!Double.TryParse(dataGridView_Ex_Cy.Rows[i].Cells[1].Value?.ToString(), out Cylinder.Cy_OK_DelayTime))
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[1].Style.BackColor = Color.Red;
                        Alarm = true;
                    }
                    else
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[1].Style.BackColor = Color.White;
                    }

                    if (!Double.TryParse(dataGridView_Ex_Cy.Rows[i].Cells[2].Value?.ToString(), out Cylinder.Cy_Ignore_DelayTime))
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[2].Style.BackColor = Color.Red;
                        Alarm = true;
                    }
                    else
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[2].Style.BackColor = Color.White;
                    }
                    if (!Double.TryParse(dataGridView_Ex_Cy.Rows[i].Cells[3].Value?.ToString(), out Cylinder.Cy_Alarm_Time))
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[3].Style.BackColor = Color.Red;
                        Alarm = true;
                    }
                    else
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[3].Style.BackColor = Color.White;
                    }
                 
                    if (dataGridView_Ex_Cy.Rows[i].Cells[4].EditedFormattedValue.ToString() == "True")
                    {
                        Cylinder.Cy_Ori_Ignore = true;
                    }

                    dataGridView_Ex_Cy.Rows[i].Cells[4].Style.BackColor = Color.White;

                    if (dataGridView_Ex_Cy.Rows[i].Cells[5].EditedFormattedValue.ToString() == "True")
                    {
                        Cylinder.Cy_Work_Ignore = true;
                    }
                    dataGridView_Ex_Cy.Rows[i].Cells[5].Style.BackColor = Color.White;

                    //if (!Cylinder.Cy_Ori_Ignore)
                    //{
                        object Index1 = (Model_Inovance.Input.Find(e1 => e1.IO_Name == Cylinder.Cy_Name + "原位传感器"))?.IO_Index;
                        if (Index1 == null)
                        {

                            dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
                            Alarm = true;
                        }
                        else
                        {
                            Cylinder.Cy_Ori_Sensor = (int)Index1;
                            dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.White;
                        }
                    //}
                    //else
                    //{
                    //    Cylinder.Cy_Ori_Sensor = 0;
                    //}

                    //if (!Cylinder.Cy_Work_Ignore)
                    //{
                        object Index2 = (Model_Inovance.Input.Find(e1 => e1.IO_Name == Cylinder.Cy_Name + "动位传感器"))?.IO_Index;
                        if (Index2 == null)
                        {

                            dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
                            Alarm = true;
                        }
                        else
                        {
                            Cylinder.Cy_Work_Sensor = (int)Index2;
                            dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.White;
                        }
                    //}
                    //else 
                    //{
                    //    Cylinder.Cy_Work_Sensor = 0;
                    //}
                        

                    object Index3 = (Model_Inovance.Output.Find(e1 => e1.IO_Name == Cylinder.Cy_Name + "原位阀"))?.IO_Index;
                    if (Index3 == null)
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
                        Alarm = true;
                    }
                    else
                    {
                        Cylinder.Cy_Ori_Valve = (int)Index3;
                        dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.White;
                    }

                    object Index4 = (Model_Inovance.Output.Find(e1 => e1.IO_Name == Cylinder.Cy_Name + "动位阀"))?.IO_Index;
                    if (Index4 == null)
                    {
                        dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
                        Alarm = true;
                    }
                    else
                    {
                        Cylinder.Cy_Work_Valve = (int)Index4;
                        dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.White;
                    }
                    if (!Alarm)
                    {
                        Model_Inovance.Para_Cylinders.Add(Cylinder);
                      
                    }

                }

            }
            catch
            {
                return false;
            }

            if (Alarm)
            {
                
                return false;
            }
            else
            {
                return true;
            }
        }
        ///// <summary>
        ///// 检查气缸配置
        ///// </summary>
        ///// <returns></returns>

        //private bool CheckCy()
        //{

        //    bool Alarm = false;

        //    try
        //    {

        //        for (int i = 0; i < Model_Inovance.Para_Cylinders.Count - 1; i++)
        //        {


        //            object Index1 = (Model_Inovance.Input.Find(e1 => e1.IO_Name == Model_Inovance.Para_Cylinders[i].Cy_Name + "原位传感器"))?.IO_Index;
        //            if (Index1 == null)
        //            {

        //                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
        //                Alarm = true;
        //            }
        //            else
        //            {

        //                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.White;
        //            }

        //            object Index2 = (Model_Inovance.Input.Find(e1 => e1.IO_Name == Model_Inovance.Para_Cylinders[i].Cy_Name + "原位传感器"))?.IO_Index;
        //            if (Index2 == null)
        //            {

        //                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
        //                Alarm = true;
        //            }
        //            else
        //            {

        //                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.White;
        //            }

        //            object Index3 = (Model_Inovance.Output.Find(e1 => e1.IO_Name == Model_Inovance.Para_Cylinders[i].Cy_Name + "原位"))?.IO_Index;
        //            if (Index3 == null)
        //            {
        //                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
        //                Alarm = true;
        //            }
        //            else
        //            {

        //                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.White;
        //            }

        //            object Index4 = (Model_Inovance.Output.Find(e1 => e1.IO_Name == Model_Inovance.Para_Cylinders[i].Cy_Name + "动位"))?.IO_Index;
        //            if (Index4 == null)
        //            {
        //                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.Red;
        //                Alarm = true;
        //            }
        //            else
        //            {

        //                dataGridView_Ex_Cy.Rows[i].Cells[0].Style.BackColor = Color.White;
        //            }


        //        }
        //        if (!Alarm)
        //        {
        //            return true;
        //        }
        //        else
        //        {

        //            return false;

        //        }

        //    }
        //    catch
        //    {

        //        return false;

        //    }

        //}

        private void dgv_Input_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv_Input.SelectedRows.Count <= 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip_Input.Items[0].Click += new System.EventHandler(Input粘贴_ToolStripMenuItem_Click);
              

                contextMenuStrip_Input.Show(MousePosition);
            }
        }
        private void Input粘贴_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                int index = dgv_Input.CurrentRow.Index;
                if(index<4)
                {
                    MessageBox.Show("固定分配的IO,禁止修改名称");
                    return;
                }
                string clipboardText = Clipboard.GetText(); //获取剪贴板中的内容
                if (string.IsNullOrEmpty(clipboardText))
                {
                    return;
                }
                if (clipboardText.Substring(clipboardText.Length - 1, 1) == "\n")
                {
                    string[] TextRow = clipboardText.Split('\n');
                    if (TextRow.Length + index - 1 >= 32)
                    {
                        for (int i = index; i < 32; i++)
                        {

                            dgv_Input.Rows[i].Cells[2].Value = TextRow[i - index];
                        }
                    }
                    else
                    {
                        for (int i = index; i < index + TextRow.Length - 1; i++)
                        {

                            dgv_Input.Rows[i].Cells[2].Value = TextRow[i - index];
                        }
                    }

                }
                else
                {
                    string[] TextRow = clipboardText.Split('\n');
                    if (TextRow.Length + index >= 32)
                    {
                        for (int i = index; i < 32; i++)
                        {

                            dgv_Input.Rows[i].Cells[2].Value = TextRow[i - index];
                        }
                    }
                    else
                    {
                        for (int i = index; i < index + TextRow.Length; i++)
                        {

                            dgv_Input.Rows[i].Cells[2].Value = TextRow[i - index];
                        }
                    }
                }


            }

            catch
            {


            }
            //重构气缸界面
            Model_DgvCy();
        }
        private void dgv_Output_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv_Output.SelectedRows.Count <= 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip_Output.Items[0].Click += new System.EventHandler(Output粘贴_ToolStripMenuItem_Click);


                contextMenuStrip_Output.Show(MousePosition);
            }

        }
        private void Output粘贴_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                int index = dgv_Output.CurrentRow.Index;
                if (index < 4)
                {
                    MessageBox.Show("固定分配的IO,禁止修改名称");
                    return;
                }
                string clipboardText = Clipboard.GetText(); //获取剪贴板中的内容
                if (string.IsNullOrEmpty(clipboardText))
                {
                    return;
                }
                string[] TextRow = clipboardText.Split('\n');
                if (clipboardText.Substring(clipboardText.Length - 1, 1) == "\n")
                {
                    if (TextRow.Length + index - 1 >= 32)
                    {
                        for (int i = index; i < 32; i++)
                        {

                            dgv_Output.Rows[i].Cells[2].Value = TextRow[i - index];
                        }
                    }
                    else
                    {
                        for (int i = index; i < index+ TextRow.Length; i++)
                        {

                            dgv_Output.Rows[i].Cells[2].Value = TextRow[i - index];
                        }
                    }
                }
                else
                {

                    if (TextRow.Length + index  >= 32)
                    {
                        for (int i = index; i < 32; i++)
                        {

                            dgv_Output.Rows[i].Cells[2].Value = TextRow[i - index];
                        }
                    }
                    else
                    {
                        for (int i = index; i < index + TextRow.Length ; i++)
                        {

                            dgv_Output.Rows[i].Cells[2].Value = TextRow[i - index];
                        }
                    }

                }

            }
            catch
            {
                MessageBox.Show("粘贴区域大小不一致");
                return;
            }

        }

        #endregion
    }
}
