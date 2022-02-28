using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptCaculate
{
    public partial class Form_ScriptCaculate : Form
    {
        #region 1.公有变量
        /// <summary>
        /// 刷新界面方法
        /// </summary>
        public static Action Refresh;
        /// <summary>
        /// Form的服务
        /// </summary>
        public Service_ScriptCaculate Service_ScriptCaculate;
        #endregion
        #region 2.私有变量
        #endregion
        #region 3.构造函数
        public Form_ScriptCaculate()
        {
            InitializeComponent();

            //1.实例化服务
            Service_ScriptCaculate = new Service_ScriptCaculate();
            //2.初始化界面
            Ini_Form();
            //3.参数实例化界面
            ModelToForm();
            //4.定义方法
           
            Refresh += RunScriptClick;
        }

        public Form_ScriptCaculate(Model_ScriptCaculate Model_ScriptCaculate)
        {
            InitializeComponent();

            //1.实例化服务
            Service_ScriptCaculate = new Service_ScriptCaculate();
            Service_ScriptCaculate.Model_ScriptCaculate = Model_ScriptCaculate;
            //2.初始化界面
            Ini_Form();
            //3.参数实例化界面
            ModelToForm();
            //4.定义方法

            Refresh += RunScriptClick;
        }
        #endregion
        #region 4.私有方法

        private void Ini_Form() 
        {
            //初始化comboBox_functions
            List<string> FunctionsNames = new List<string>();
            foreach (int myCode in Enum.GetValues(typeof(functionsNote)))
            {
                string strName = Enum.GetName(typeof(functionsNote), myCode);   //获取名称

                FunctionsNames.Add(strName);
            }
            comboBox_functions.Items.Clear();
            for (int i = 0; i < FunctionsNames.Count; i++)
            {
                comboBox_functions.Items.Add(FunctionsNames[i]);
            }
        }
        private void ModelToForm()
        {
            textBoxScript.Text = "";
            for (int i = 0; i < Service_ScriptCaculate.Model_ScriptCaculate.ScriptText.Count; i++)
            {
                textBoxScript.Text += Service_ScriptCaculate.Model_ScriptCaculate.ScriptText[i] + ";\r\n";
            }
            
        }
        #endregion
        #region 5.公有方法
        public void RunScriptClick()
        {
            //1.开始运行
            if(this.IsHandleCreated) 
            {
                this.Invoke(new Action(() => {
                    textBoxFunctionsNote.Text = "运行脚本...";
                }));
            }
            //2.方法运行
            string str_ScriptLog = string.Empty;
            Service_ScriptCaculate.RunScript();

            //3.结果显示
            if (this.IsHandleCreated)
            {
                this.Invoke(new Action(() =>
                {
                    textBoxScriptNote.Text = Service_ScriptCaculate.RunScriptLog;
                    textBoxFunctionsNote.Text = "运行结束！";
                }));
            }
        }
        #endregion
        #region 6.按钮
        /// <summary>
        /// 插入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_insert_Click(object sender, EventArgs e)
        {
            string str = string.Empty;

            try
            {
                if (sender == button_insertMCS)
                {//机械坐标（MCS-Point）

                    str = comboBox_MCS.Text;
                }

                else if (sender == button_insertCCS)
                {//相机返回值（CCS）

                    string[] s0 = comboBox_IndexBackValue.Text.Split('[');

                    str = s0[0] + "[" + comboBox_Index.Text + "]" + "[" + s0[1];
                }

                else if (sender == button_insertFunctions)
                {//计算公式

                    str = comboBox_functions.Text;
                }

                else if (sender == button_insertIntermDbl)
                {//中间变量（double）

                    str = comboBox_IntermDbl.Text;
                }

                else if (sender == button_insertIntermPoint)
                {//中间点变量（point）

                    str = comboBox_IntermPoint.Text;
                }

                else if (sender == buttonC1)
                {//=

                    str = "=";
                }

                else if (sender == buttonC2)
                {//(

                    str = "(";
                }

                else if (sender == buttonC3)
                {//,

                    str = ",";
                }

                else if (sender == buttonC4)
                {//)

                    str = ")";
                }

                else if (sender == buttonC5 || sender == buttonN2)
                {//;

                    str = ";";
                }
                else if (sender == buttonN1)
                {////

                    str = "//";
                }


                else if (sender == buttonN3)
                {//;

                    str = "\r\n";
                }
                else if (sender == buttonN4)
                {//;

                    str = "Value[]";
                }


                else
                {//输出变量（double）
                    str = comboBox_Out.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入脚本错误，请确认！\r\n" + ex.Message);
                return;
            }

            string s = textBoxScript.Text;
            int index = textBoxScript.SelectionStart;

            str = s.Insert(index, str);

            textBoxScript.Text = str;

            textBoxScript.SelectionStart = index + str.Length;
            textBoxScript.Focus();
        }
        /// <summary>
        /// 方法切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_functions_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBoxFunctionsNote.Text = Service_ScriptCaculate.GetEnumDescription(comboBox_functions.Text);

        }
       /// <summary>
       /// 运行脚本
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void buttonRun_Click(object sender, EventArgs e)
        {

            this.RunScriptClick();
        }
        /// <summary>
        /// 保存脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SAVE_Click(object sender, EventArgs e)
        {
            textBoxFunctionsNote.Text = "保存脚本";
            Service_ScriptCaculate.Model_ScriptCaculate.ScriptText.Clear();
            string[] Script = textBoxScript.Text.Replace("\r\n","").Split(';');
            for (int i = 0; i < Script.Count()-1; i++)
            {
                Service_ScriptCaculate.Model_ScriptCaculate.ScriptText.Add(Script[i]);
            }

            //if (Service_ScriptCaculate.Save_Model())
            //{
            //    MessageBox.Show("保存成功");
            //}
            //else 
            //{
            //    MessageBox.Show("保存失败");
            //}
            
        }
        /// <summary>
        /// 脚本重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CANCEL_Click(object sender, EventArgs e)
        {
            textBoxFunctionsNote.Text = "重新加载保存的脚本";

            textBoxScript.Text="";
                for (int i = 0; i < Service_ScriptCaculate.Model_ScriptCaculate.ScriptText.Count; i++)
                {
                    textBoxScript.Text = textBoxScript.Text + Service_ScriptCaculate.Model_ScriptCaculate.ScriptText[i] + ";\r\n";
                }
                MessageBox.Show("读取成功");
          
        }
        #endregion

        
    }
}
