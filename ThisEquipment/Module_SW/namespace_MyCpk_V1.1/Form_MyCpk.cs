using Measure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCpk
{
    public partial class Form_MyCpk : Form
    {
        public Form_MyCpk()
        {
            InitializeComponent();
            //测试数据库
            CheckDataBase();

            panel1.AutoScroll = true;//设置panel控件的自动滑动条
            
            Service_Refresh.TestResult_Refresh += MysqlFunction.FUNC_AddCPK;
        }

        #region 变量   
        /// <summary>
        /// 子窗体尺寸
        /// </summary>
        private Size formSize;
        /// <summary>
        /// 间隔
        /// </summary>
        private int Gap = 5;
        /// <summary>
        /// 第一个窗体X
        /// </summary>
        private int firstX = 0;
        /// <summary>
        /// 第一个窗体Y
        /// </summary>
        private int firstY = 0;
        /// <summary>
        /// 一行固定5个
        /// </summary>
        private int Rows;
        /// <summary>
        /// 存放窗体的集合
        /// </summary>
        List<SubMyCpk> ListForm = new List<SubMyCpk>();

        private void AutoSize(object sender, EventArgs e)
        {
            Reflsh();
        }

        #endregion
        /// <summary>
        /// 刷新界面
        /// </summary>
        private void Reflsh()
        {
            if (ListForm.Count <= 0)
            {
                return;
            }
            Size PanelSize = this.panel1.Size;
            int count = ListForm.Count;
            //计算列
            Rows = CalculateRowCount(count);
            //计算窗体尺寸
            if (count <= Rows)
            {
                formSize = Calculate(count, Rows, PanelSize, Gap);
            }
            else
            {
                formSize = Calculate(Rows, Rows, PanelSize, Gap);
            }
            //循环设置窗体属性
            int i = 0;

            foreach (SubMyCpk form in ListForm)
            {
                form.TopLevel = false;
                panel1.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Size = formSize;
                form.Location = matrix(i, form.Width, form.Height, Gap, Rows);
                form.Text = $"Form{i + 1}";
                form.Show();


                i++;
            }
        }
        /// <summary>
        /// 计算列
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private int CalculateRowCount(int count)
        {
            int re = 5;
            if (count <= 2)
            {
                re = 2;
            }
            else if (count <= 4)
            {
                re = 2;
            }
            else if (count <= 9)
            {
                re = 3;
            }
            else if (count <= 16)
            {
                re = 4;
            }
            else if (count <= 25)
            {
                re = 5;
            }
            else
                re = 5;
            return re;
        }
        /// <summary>
        /// 计算窗体尺寸
        /// </summary>
        /// <param name="formcount">窗体数量</param>
        /// <param name="Rows">一行固定几个窗体</param>
        /// <param name="panlesize">容器尺寸</param>
        /// <param name="gzp">间隔</param>
        /// <returns></returns>
        private Size Calculate(int formcount, int Rows, Size panlesize, int gzp)
        {
            Size formsize = new Size();
            double x = panlesize.Height;
            double y = panlesize.Width;
            double ratio = x / y;
            if (formcount == 0) formcount = 1;
            formsize.Width = (int)((panlesize.Width - gzp * Rows) / formcount);
            formsize.Height = (int)(formsize.Width * ratio);
            return formsize;
        }

        /// <summary>
        /// 计算窗体位置
        /// </summary>
        /// <param name="Count">第几个窗体，从0开始</param>
        /// <param name="Xsize">窗体的宽</param>
        /// <param name="Ysize">窗体高</param>
        /// <param name="gzp">间隔</param>
        /// <param name="Row">一行几个窗体</param>
        /// <returns></returns>
        private Point matrix(int Count, int Xsize, int Ysize, int gzp, int Row)
        {
            Point _Point = new Point();
            if (Count < Row)
            {
                int _col = Count / Row;
                _Point.X = (Count * Xsize) + gzp * Count;
                _Point.Y = (_col * Ysize) + gzp * _col;
            }
            else
            {
                int _row = Count / Row;
                int _count = Count - _row * Row;
                _Point.X = (_count * Xsize) + gzp * _count;
                _Point.Y = (_row * Ysize) + gzp * _row;
            }

            return _Point;
        }
        /// <summary>
        /// 窗台清除
        /// </summary>
        private void Clear()
        {
            foreach (SubMyCpk form in ListForm)
            {
                form.Close();
            }
            ListForm.Clear();
        }


        #region 公用方法
        //窗体初始化
        public void Fun1_IniForm(int Number)
        {
            Clear();
            //第一步：查询

            List<ProductionSheet> ProductionSheetS = null;
            string[] temp = Dialog_ProjectChoose.ProjectChoose.strMyDBLoad.Split('\\');
            string Address = temp[5];
            int Result = MysqlFunction.SelectCPKDataByNumer(Number, Address, out ProductionSheetS);

            //查询失败则退出
            if (Result == 0 || ProductionSheetS.Count<=0) { return; };

            //根据测量项生成list
            List<MyRowsData>[] TDS = new List<MyRowsData>[ProMeasureSize.Sizes.Count];


            foreach (MeasureSize size in ProMeasureSize.Sizes)
            {

                SubMyCpk submycpk = new SubMyCpk();
                ListForm.Add(submycpk);

                //当前序列号
                int index = ProMeasureSize.Sizes.IndexOf(size);
                TDS[index] = new List<MyRowsData>();

                for (int i = 0; i < ProductionSheetS.Count; i++)
                {
                    Application.DoEvents();

                    MyRowsData rowdatas = new MyRowsData();
                    rowdatas.Normalvalue = size.NormValue;
                    rowdatas.USL = size.NormValue+size.UpperDeviation;
                    rowdatas.LSL = size.NormValue-size.LowerDeviation;
                    try
                    {
                        rowdatas.Realvalue = Convert.ToDouble(ProductionSheetS[i].Data.Split(',')[index]);
                    }
                    catch
                    {
                        rowdatas.Realvalue = rowdatas.Normalvalue;
                    }
                    TDS[index].Add(rowdatas);
                }
                submycpk.FormShowData(TDS[index], size.SizeName);

                //submycpk.Show();


            }
            Reflsh();


        }
        //更新窗体数据
        public void Fun2_RefreshForm(int Number)
        {
            //Clear();
            //第一步：查询
            Stopwatch watch = new Stopwatch();

            watch.Start();
            List<ProductionSheet> ProductionSheetS = null;

            //更改measuredata 数据库
            string[] temp = Dialog_ProjectChoose.ProjectChoose.strMyDBLoad.Split('\\');
            string Project  = temp[5];
            int Result = MysqlFunction.SelectCPKDataByNumer(Number, Project,out ProductionSheetS);

            //MessageBox.Show($"1{watch.ElapsedMilliseconds}");
            watch.Restart();
            //查询失败则退出
            if (Result == 0) { return; };

            //根据测量项生成list
            List<MyRowsData>[] TDS = new List<MyRowsData>[ProMeasureSize.Sizes.Count];


            foreach (MeasureSize size in ProMeasureSize.Sizes)
            {
                Application.DoEvents();


                //当前序列号
                int index = ProMeasureSize.Sizes.IndexOf(size);
                TDS[index] = new List<MyRowsData>();
                watch.Restart();
                for (int i = 0; i < ProductionSheetS.Count; i++)
                {

                    MyRowsData rowdatas = new MyRowsData()
                    {
                        Normalvalue = size.NormValue,
                        USL = size.UpperDeviation,
                        LSL = size.LowerDeviation,
                    };

                    try
                    {
                        rowdatas.Realvalue = Convert.ToDouble(ProductionSheetS[i].Data.Split(',')[index]);
                    }
                    catch
                    {
                        rowdatas.Realvalue = rowdatas.Normalvalue;
                    }
                    TDS[index].Add(rowdatas);
                }


                watch.Restart();
                ListForm[index].FormShowData(TDS[index], size.SizeName);


            }


        }

        /// <summary>
        /// 自动确认数据库和数据表，如果没有就新建
        /// </summary>
        public void CheckDataBase()
        {
            string DataBaseName = "aphz_CPKDataBase";
            CreateTableService.CheckSchemaExist(DataBaseName);

            Type[] classes = Assembly.GetExecutingAssembly().GetTypes();
            List<Type> Entities = new List<Type>();
            string name = "";
            foreach (Type clas in classes)
            {
                if (clas.FullName.Contains("MyCpk.ProductionSheet"))
                    Entities.Add(clas);
            }
            CreateTableService.CheckTableExist(Entities, DataBaseName);
        }

        #endregion

        private void button_Ini_Click(object sender, EventArgs e)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            int index = 100;
            try
            {
                index = Convert.ToInt16(textBox1.Text);
            }
            catch
            {
                index = 100;
                textBox1.Text = "100";
            }
            Fun1_IniForm(index);
            //MessageBox.Show($"{watch.ElapsedMilliseconds}");
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            int index = 100;
            try
            {
                index = Convert.ToInt16(textBox1.Text);
            }
            catch
            {
                index = 100;
            }
            Stopwatch watch = new Stopwatch();

            watch.Start();

            Fun2_RefreshForm(index);
            MessageBox.Show($"{watch.ElapsedMilliseconds}");
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button_Insert_Click(object sender, EventArgs e)
        {
            string InSert_Data = "";
            
            Random random = new Random();
            foreach (MeasureSize size in ProMeasureSize.Sizes)
            {             
                //插入公差内的一个数据
                int Down = Convert.ToInt32((size.NormValue - size.LowerDeviation) * 1000);
                int Up = Convert.ToInt32((size.NormValue + size.UpperDeviation) * 1000);
                
                double InsertValue =random.Next(0, 300)*0.001;

                if (InSert_Data == "")
                {
                     
                    InSert_Data = InsertValue.ToString("0.000") + ",";
                }
                else 
                {
                    InSert_Data= InSert_Data + InsertValue.ToString("0.000") + ",";
                }
                
            }
            //更改measuredata 数据库
            string[] temp = Dialog_ProjectChoose.ProjectChoose.strMyDBLoad.Split('\\');
            string Project = temp[5];

            ProductionSheet InSert_Production = new ProductionSheet()
            {
                ID = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Project = Project,
                SN ="123456",
                Time = DateTime.Now,
                Data = InSert_Data
            };


            MysqlFunction.InsertCPKData(InSert_Production);
           
            
        }
    }
}
