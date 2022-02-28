using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Tools
{
    internal partial class Form_GlobalVariable : Form_FormBase
    {
        #region 1.公有变量
        /// <summary>
        /// 定义全局变量
        /// </summary>
        public  GlobalVariableServices GlobalVariableServices;
        #endregion
        #region 2.私有变量
        bool enable = false;
        ///// <summary>
        ///// 窗体对象实例
        ///// </summary>
        //private static Form_GlobalVariable _instance;
        //internal static Form_GlobalVariable Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new Form_GlobalVariable();
        //        return _instance;
        //    }

        //}
        #endregion
        #region 3.构造函数
        internal Form_GlobalVariable(string FilePath)
        {
            InitializeComponent();
            //1.实例化Service
            
            GlobalVariableServices = new GlobalVariableServices(FilePath);
          
            //2.IniForm
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            //3.ModelToForm
            ModelToForm();
            
        }
        #endregion
        #region 4.私有方法
        internal void ModelToForm(int variableType = 1)
        {
            try
            {
                enable = false;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < GlobalVariableServices.GlobelVariables.L_variable.Count; i++)
                {
                    if (GlobalVariableServices.GlobelVariables.L_variable[i].variableType == variableType)
                    {
                        int idx = dataGridView1.Rows.Add();
                        dataGridView1.Rows[idx].Cells[0].Value = GlobalVariableServices.GlobelVariables.L_variable[i].index;
                        dataGridView1.Rows[idx].Cells[1].Value = GlobalVariableServices.GlobelVariables.L_variable[i].type;
                        dataGridView1.Rows[idx].Cells[2].Value = GlobalVariableServices.GlobelVariables.L_variable[i].name;
                        dataGridView1.Rows[idx].Cells[3].Value = GlobalVariableServices.GlobelVariables.L_variable[i].value;
                        dataGridView1.Rows[idx].Cells[4].Value = GlobalVariableServices.GlobelVariables.L_variable[i].info;
                    }
                }
                enable = true;
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 单元选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (enable == false)
                return;

            string name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (!GlobalVariableServices.GlobelVariables.SetGlobalVariableValue(name, value)) 
            {
                MessageBox.Show("参数设置错误!");
            };
        }
        private void Form_GlobalVariable_Shown(object sender, EventArgs e)
        {
            cbx_variableType.SelectedIndex = 1;
        }

        private void cbx_variableType_SelectedIndexChanged()
        {
            ModelToForm(cbx_variableType.SelectedIndex);
            if (cbx_variableType.SelectedIndex == 0)
            {
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                dataGridView1.ReadOnly = true;
            }
            else
            {
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                dataGridView1.ReadOnly = false;
            }
        }
        #endregion
        #region 5.公有方法
        #endregion
        #region 6.按钮
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            //button.BackgroundImage = Resources.ButtonDown;
            Application.DoEvents();
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;

            Application.DoEvents();
        }

        /// <summary>
        /// 添加Int
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Variable variable = new Variable(dataGridView1.Rows.Count + 1, "int", GlobalVariableServices.GlobelVariables.GetNewName("Int"));
            GlobalVariableServices.GlobelVariables.L_variable.Add(variable);
            ModelToForm();
        }
        /// <summary>
        /// 添加double
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click_1(object sender, EventArgs e)
        {
            Variable variable = new Variable(dataGridView1.Rows.Count + 1, "double", GlobalVariableServices.GlobelVariables.GetNewName("Double"));
            GlobalVariableServices.GlobelVariables.L_variable.Add(variable);
            ModelToForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Variable variable = new Variable(dataGridView1.Rows.Count + 1, "string", GlobalVariableServices.GlobelVariables.GetNewName("String"));
            GlobalVariableServices.GlobelVariables.L_variable.Add(variable);
            ModelToForm();
        }
        /// <summary>
        /// 添加bool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            Variable variable = new Variable(dataGridView1.Rows.Count + 1, "bool", GlobalVariableServices.GlobelVariables.GetNewName("Bool"));
            GlobalVariableServices.GlobelVariables.L_variable.Add(variable);
            ModelToForm();
        }
        /// <summary>
        /// 删除当前变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                GlobalVariableServices.GlobelVariables.L_variable.RemoveAt(index);
                ModelToForm();
            }

        }
        /// <summary>
        /// 退出并保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariableServices.Save();
                //this.Dispose();
            }
            catch (Exception ex)
            {
                Basic_UI.Log.SaveError(ex);
            }
        }


        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Application.DoEvents();
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Application.DoEvents();
        }


        #endregion
    }
}
