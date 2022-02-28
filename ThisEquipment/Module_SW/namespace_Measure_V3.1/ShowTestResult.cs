using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorsControl;

namespace Measure
{


    public partial class ShowTestResult : UserControl
    {
        #region 1.变量
        private SysMeasureDBServices DBServices = null;
        #endregion
        #region 2.构造函数
        public ShowTestResult()
        {
            InitializeComponent();           
            Service_Refresh.TestResult_Refresh += FUNC_AddAllResult;
            Service_Refresh.Ini_Refresh += Ini_Form;
        }
        #endregion
        #region 5.公有方法
        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="prjName"></param>
        public void INIT_ShowTestResult(string prjName)
        {
            //1.读参数
            INIT_MeasureModel(prjName);//从数据库中加载数据
            //2.ModelToForm
            ModelToForm();//初始化datagridview控件
            //3.Ini_Form
            Ini_Form();
        }     
        private void INIT_MeasureModel(string prjName)
        {
            //数据库服务
            DBServices = new SysMeasureDBServices(prjName);
            ProMeasureSize.TestValue = new List<TestingData>();
            ProMeasureSize.Sizes = DBServices.GetAllByIsShow();
        }
        private void ModelToForm()
        {
            ProMeasureSize.NameList = new List<string>();
            dgv_ResultOutput.Rows.Clear();

            if (ProMeasureSize.Sizes.Count == 0)
            {
                //throw new UserException("Database load database measure sizes exception！" + "sizes = null ");
                return;
            }
            //初始化界面dgv显示
            string[] output = new string[9];
            int sizeCount = 0;
            foreach (MeasureSize size in ProMeasureSize.Sizes)
            {
                TestingData testData = new TestingData();
                testData.Name = size.SizeName;
                testData.ID = size.ID;
                ProMeasureSize.TestValue.Add(testData);
                if (size.IsShow == true)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell[] textboxcell = new DataGridViewTextBoxCell[9];

                    output[0] = 0.ToString();
                    textboxcell[0] = new DataGridViewTextBoxCell(); textboxcell[0].Value = output[0]; row.Cells.Add(textboxcell[0]);

                    output[1] = size.SizeName;
                    textboxcell[1] = new DataGridViewTextBoxCell(); textboxcell[1].Value = output[1]; row.Cells.Add(textboxcell[1]);

                    output[2] = size.SizeProperty;
                    textboxcell[2] = new DataGridViewTextBoxCell(); textboxcell[2].Value = output[2]; row.Cells.Add(textboxcell[2]);

                    output[3] = "等待测试";//0.ToString("0.0000");
                    textboxcell[3] = new DataGridViewTextBoxCell(); textboxcell[3].Value = output[3]; row.Cells.Add(textboxcell[3]);

                    output[4] = size.NormValue.ToString();
                    textboxcell[4] = new DataGridViewTextBoxCell(); textboxcell[4].Value = output[4]; row.Cells.Add(textboxcell[4]);

                    output[5] = size.UpperDeviation.ToString();
                    textboxcell[5] = new DataGridViewTextBoxCell(); textboxcell[5].Value = output[5]; row.Cells.Add(textboxcell[5]);

                    output[6] = size.LowerDeviation.ToString();
                    textboxcell[6] = new DataGridViewTextBoxCell(); textboxcell[6].Value = output[6]; row.Cells.Add(textboxcell[6]);

                    output[7] = 0.ToString("0.000");
                    textboxcell[7] = new DataGridViewTextBoxCell(); textboxcell[7].Value = output[7]; row.Cells.Add(textboxcell[7]);

                    output[8] = "+";
                    textboxcell[8] = new DataGridViewTextBoxCell(); textboxcell[8].Value = output[8]; row.Cells.Add(textboxcell[8]);

                    dgv_ResultOutput.Rows.Add(row);
                    //dgv_ResultOutput.Rows.Add(output);
                    sizeCount++;
                    //dgv显示的所有尺寸名称
                    ProMeasureSize.NameList.Add(size.SizeName);
                }
            }

        }

        /// <summary>
        /// 界面清零
        /// </summary>
        public void Ini_Form()
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(new Action(() =>
            {
                for (int rowIndex = 0; rowIndex < dgv_ResultOutput.Rows.Count; rowIndex++)
                {
                    dgv_ResultOutput.Rows[rowIndex].Cells[3].Style.BackColor = Color.White;
                    dgv_ResultOutput.Rows[rowIndex].Cells[3].Value = "等待测试";
                    dgv_ResultOutput.Rows[rowIndex].Cells[7].Value = "0.000";
                }
                lbl_Result.BackColor = Color.White;
                lbl_Result.Text = "---";

            }));
            }
        }

        /// <summary>
        /// 添加结果到datagridview
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="MeasureID"></param>
        /// <param name="SizeName"></param>
        /// <param name="MeasureValue"></param>
        /// <returns></returns>
        public bool FUNC_AddResults(int MeasureID, TestingData testingData)
        {

            string SizeName = testingData.Name;
            double MeasureValue = testingData.Value;
            if (!ProMeasureSize.NameList.Contains(testingData.Name))
                return false;//如果尺寸不需要显示，返回false

            List<TestingData> testdata = new List<TestingData>();
            testdata.Add(testingData);
            Jugement.JugeTestingData(ref testdata, ProMeasureSize.Sizes);
            if (this.IsHandleCreated)
            {
                this.Invoke(new Action(() =>
                {
                    for (int rowIndex = 0; rowIndex < dgv_ResultOutput.Rows.Count; rowIndex++)
                    {
                        if (dgv_ResultOutput.Rows[rowIndex].Cells[1].Value.ToString() != testingData.Name)
                            continue;

                        if (testingData.JugeResult == JUDGEMENT_RESULT.NG_Upper.ToString())//NG
                        {
                            dgv_ResultOutput.Rows[rowIndex].Cells[3].Style.BackColor = Color.Red;
                        }
                        else if (testingData.JugeResult == JUDGEMENT_RESULT.NG_Under.ToString())//NG
                        {
                            dgv_ResultOutput.Rows[rowIndex].Cells[3].Style.BackColor = Color.Red;
                        }
                        else if (testingData.JugeResult == JUDGEMENT_RESULT.NG.ToString())//NG
                        {
                            dgv_ResultOutput.Rows[rowIndex].Cells[3].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dgv_ResultOutput.Rows[rowIndex].Cells[3].Style.BackColor = Color.White;
                        }

                        dgv_ResultOutput.Rows[rowIndex].Cells[3].Value = testingData.Value.ToString("0.000");
                        dgv_ResultOutput.Rows[rowIndex].Cells[0].Value = MeasureID;
                        dgv_ResultOutput.Rows[rowIndex].Cells[7].Value = (testingData.Value - double.Parse(dgv_ResultOutput.Rows[rowIndex].Cells[4].Value.ToString())).ToString("f6");

                    }
                }));
            }
            return true;

        }
        /// <summary>
        /// 添加结果到总结果
        /// </summary>
        /// <param name="tests"></param>
        /// <returns></returns>
        public bool FUNC_AddFinalResult(List<TestingData> tests)
        {
            foreach (TestingData test in tests)
            {
                if (test.JugeResult != JUDGEMENT_RESULT.OK.ToString())
                {
                    if (this.IsHandleCreated)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lbl_Result.Text = "FAIL";
                            lbl_Result.BackColor = Color.Red;
                        }));
                    }


                    return false;

                }
            }
            if (this.IsHandleCreated)
            {
                this.Invoke(new Action(() =>
                {
                    lbl_Result.Text = "PASS";
                    lbl_Result.BackColor = Color.White;
                }));
            }
            return true;

        }

        /// <summary>
        /// 新程序报警
        /// </summary>
        public void FUNC_AddAllResult()
        {
            for (int i = 0; i < Measure.ProMeasureSize.Sizes.Count(); i++)
            {
                bool Result = FUNC_AddResults(Measure.ProMeasureSize.TestValue[i].ID, Measure.ProMeasureSize.TestValue[i]);

            }
            Measure.ProMeasureSize.MeasureResult = FUNC_AddFinalResult(ProMeasureSize.TestValue) == true ? "OK" : "NG";
            if (Measure.ProMeasureSize.MeasureResult == "OK")
            {
                TestExcepation.ThreeTimesNG = false;
                TestExcepation.NG_Count = 0;

            }
            else
            {
                TestExcepation.NG_Count = TestExcepation.NG_Count + 1;
                if (TestExcepation.NG_Count >= 3)
                {
                    TestExcepation.ThreeTimesNG = true;
                }

            }
        }
        
        
        #endregion
    }
}
