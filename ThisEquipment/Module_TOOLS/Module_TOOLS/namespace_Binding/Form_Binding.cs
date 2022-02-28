using Basic_UI;
using PropertyGridEx;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Tools
{
    public partial class Form_Binding : Form
    {
        #region 1.公有变量

        /// 过程中ListViewCollapse
        /// </summary>
        public static ListViewCollapse ProcessListView = new ListViewCollapse();

        /// <summary>
        /// 弹出绑定节点
        /// </summary>
        public static ListViewItem ToolBindingItem = new ListViewItem();

        #endregion
        #region 2.私有变量
        #endregion
        #region 3.构造函数
        public Form_Binding()
        {
            InitializeComponent();

            //1.实例化Form服务
            //ToolService = new ToolServices();

            //2.初始化Form
            Init_Form();

            //3.读出参数（此处由赋值给入）

            //4.Model实例化Form
            ModelToForm();

            //5.属性显示
            PropertyShow();
        }
        #endregion
        #region 4.私有方法
        #region 初始化界面
        private void Init_Form()
        {
            //设定当前窗台名称
            this.Text = ((ToolInfo)ToolBindingItem.Tag).toolGroupName;
            Init_lvIO();
            Init_lvBinding();
            Init_ToolStrip1();
        }
        /// <summary>
        /// 初始化listview 
        /// </summary>
        /// <param name="lv1"></param>
        public void Init_lvIO()
        {
            //初始化控件ListView样式
            lvIO.View = View.Details;      //Set to details view.细节显示
            lvIO.LabelEdit = false;         //允许用户添加编辑条款
            lvIO.AllowColumnReorder = true;//Allow the user rearrange columns允许用户从新排列
            lvIO.CheckBoxes = false;       //DisPlay CheckBox显示打钩的框
            lvIO.FullRowSelect = true;     //整行选择
            lvIO.Sorting = SortOrder.None; //排序方式
            lvIO.GridLines = true;         //显示网格线
            lvIO.MultiSelect = false;      //禁止ListView选择多项
            lvIO.HeaderStyle = ColumnHeaderStyle.Nonclickable;


            ImageList imageList = new ImageList();   //设置行高20

            imageList.ImageSize = new System.Drawing.Size(1, 20);   //分别是宽和高

            lvIO.SmallImageList = imageList;   //这里设置listView的SmallImageList ,用imgList将其撑大。

            //根据项目加载列
            lvIO.Columns.Clear();
            lvIO.Items.Clear();

            int ColumnWidth = lvIO.Width;
            lvIO.Columns.Add("参数名称", Convert.ToInt16(ColumnWidth * 0.4), HorizontalAlignment.Left);
            lvIO.Columns.Add("绑定信息", Convert.ToInt16(ColumnWidth * 0.6), HorizontalAlignment.Center);


            lvIO.ColumnWidthChanging += delegate (object sender, ColumnWidthChangingEventArgs e)
            {
                e.NewWidth = lvIO.Columns[e.ColumnIndex].Width;
                e.Cancel = true;
            };
            //绑定事件
            
            lvIO.DoubleClick += new System.EventHandler(lvIO_MouseDoubleClick);
            lvIO.MouseClick += new System.Windows.Forms.MouseEventHandler(lvIO_MouseClick);
            // this.ListViewCollapse.Click += new System.EventHandler(this.lv1_MouseClick);
        }
        /// <summary>
        /// 参数界面鼠标单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvIO_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvIO.SelectedItems.Count == 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    //清除所有项
                    lvBinding.Items.Clear();
                    //之前所有点变量
                    string Result_Str = GetAllOutPut();

                    //结果为空则跳过
                    if (!(Result_Str == ""))
                    {
                        string[] Result_Str_Single = Result_Str.Split(';');

                        //分离所有结果字符串并添加到鼠标右键
                        for (int i = 0; i < Result_Str_Single.Length - 1; i++)
                        {
                            string[] Result_Str_Info = Result_Str_Single[i].Split(',');
                            TreeListViewItem BindingItem = new TreeListViewItem();
                            if (Result_Str_Info[0] == "Globel")
                            {
                                string Name = Result_Str_Info[1];
                                //查找当前匹配的序列号
                                if (lvBinding.Items.Count == 0)
                                {
                                    //增加组
                                    BindingItem.Text = "";
                                    BindingItem.SubItems.Add("全局变量");
                                    BindingItem.ImageIndex = 10;


                                    TreeListViewItem Subitem = new TreeListViewItem();
                                    string SearchIOText = Name;
                                    Subitem.SubItems.Add(SearchIOText);
                                    string SearchIOType = ((ToolIO)lvIO.SelectedItems[0].Tag).IOType;
                                    Subitem.SubItems.Add(SearchIOType);
                                    string SearchIOValue = GlobalVariableServices.GlobelVariables.GetGlobalVariableValue(Name).ToString();
                                    Subitem.SubItems.Add(SearchIOValue);
                                    Subitem.Tag = GlobalVariableServices.GlobelVariables.GetGlobalVariable(Name);
                                    BindingItem.Items.Add(Subitem);
                                    lvBinding.Items.Add(BindingItem);

                                }
                                else
                                {
                                    if (lvBinding.Items[lvBinding.Items.Count - 1].SubItems[1].Text == "全局变量")
                                    {
                                        TreeListViewItem Subitem = new TreeListViewItem();
                                        string SearchIOText = Name;
                                        Subitem.SubItems.Add(SearchIOText);
                                        string SearchIOType = ((ToolIO)lvIO.SelectedItems[0].Tag).IOType;
                                        Subitem.SubItems.Add(SearchIOType);
                                        string SearchIOValue = GlobalVariableServices.GlobelVariables.GetGlobalVariableValue(Name).ToString();
                                        Subitem.SubItems.Add(SearchIOValue);
                                        Subitem.Tag = GlobalVariableServices.GlobelVariables.GetGlobalVariable(Name);
                                        lvBinding.Items[lvBinding.Items.Count - 1].Items.Add(Subitem);


                                    }
                                    else 
                                    {
                                        //增加组
                                        BindingItem.Text = "";
                                        BindingItem.SubItems.Add("全局变量");
                                        BindingItem.ImageIndex = 10;


                                        TreeListViewItem Subitem = new TreeListViewItem();
                                        string SearchIOText = Name;
                                        Subitem.SubItems.Add(SearchIOText);
                                        string SearchIOType = ((ToolIO)lvIO.SelectedItems[0].Tag).IOType;
                                        Subitem.SubItems.Add(SearchIOType);
                                        string SearchIOValue = GlobalVariableServices.GlobelVariables.GetGlobalVariableValue(Name).ToString();
                                        Subitem.SubItems.Add(SearchIOValue);
                                        Subitem.Tag = GlobalVariableServices.GlobelVariables.GetGlobalVariable(Name);
                                        BindingItem.Items.Add(Subitem);
                                        lvBinding.Items.Add(BindingItem);
                                    }
                                }
                            }
                            else
                            {
                                //查找当前匹配的序列号
                                int Index = Convert.ToInt32(Result_Str_Info[0]);
                                //IO
                                bool IOType = (Result_Str_Info[1] == "0") ? false : true;
                                //IO序号
                                int IOIndex = Convert.ToInt32(Result_Str_Info[2]);
                                //如果lvBinding组=0
                                if (lvBinding.Items.Count == 0)
                                {
                                    //增加组
                                    BindingItem.Text = "";
                                    BindingItem.SubItems.Add(ProcessListView.Items[Index].SubItems[0].Text);                                 
                                    BindingItem.ImageIndex = ProcessListView.Items[Index].ImageIndex;
                                    TreeListViewItem Subitem = new TreeListViewItem();

                                    //增加组成员
                                    if (!IOType)//输入
                                    {
                                        string SearchIOText = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].IOName;
                                        Subitem.SubItems.Add(SearchIOText);
                                        string SearchIOType = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].IOType;
                                        Subitem.SubItems.Add(SearchIOType);
                                        string SearchIOValue = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].ValueObject.ToString();
                                        Subitem.SubItems.Add(SearchIOValue);
                                        Subitem.Tag = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex];
                                    }
                                    else
                                    {
                                        string SearchIOText = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].IOName;
                                        Subitem.SubItems.Add(SearchIOText);
                                        string SearchIOType = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].IOType;
                                        Subitem.SubItems.Add(SearchIOType);
                                        string SearchIOValue = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].ValueObject.ToString();
                                        Subitem.SubItems.Add(SearchIOValue);

                                        Subitem.Tag = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex];
                                    }
                                    BindingItem.Items.Add(Subitem);
                                    lvBinding.Items.Add(BindingItem);
                                }
                                //如果lvBinding组不存在
                                else
                                {
                                    if ((lvBinding.Items[lvBinding.Items.Count - 1].SubItems[1].Text != ProcessListView.Items[Index].SubItems[0].Text))
                                    {
                                        //增加组
                                        BindingItem.Text = "";
                                        BindingItem.SubItems.Add(ProcessListView.Items[Index].SubItems[0].Text);
                                        //BindingItem.BackColor = Color.Pink;
                                        //BindingItem.SubItems[0].BackColor = Color.Pink;
                                        //BindingItem.SubItems[1].BackColor = Color.Pink;
                                        //BindingItem.SubItems[2].BackColor = Color.Pink;
                                        BindingItem.ImageIndex = ProcessListView.Items[Index].ImageIndex;
                                        TreeListViewItem Subitem = new TreeListViewItem();

                                        //增加组成员
                                        if (!IOType)//输入
                                        {
                                            string SearchIOText = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].IOName;
                                            Subitem.SubItems.Add(SearchIOText);
                                            string SearchIOType = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].IOType;
                                            Subitem.SubItems.Add(SearchIOType);
                                            string SearchIOValue = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].ValueObject.ToString();
                                            Subitem.SubItems.Add(SearchIOValue);

                                            Subitem.Tag = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex];

                                        }
                                        else
                                        {
                                            string SearchIOText = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].IOName;
                                            Subitem.SubItems.Add(SearchIOText);
                                            string SearchIOType = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].IOType;
                                            Subitem.SubItems.Add(SearchIOType);
                                            string SearchIOValue = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].ValueObject.ToString();
                                            Subitem.SubItems.Add(SearchIOValue);

                                            Subitem.Tag = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex];
                                        }
                                        BindingItem.Items.Add(Subitem);
                                        lvBinding.Items.Add(BindingItem);
                                    }

                                    else
                                    {

                                        if (!IOType)//输入
                                        {
                                            string SearchIOText = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].IOName;
                                            BindingItem.SubItems.Add(SearchIOText);
                                            string SearchIOType = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].IOType;
                                            BindingItem.SubItems.Add(SearchIOType);
                                            string SearchIOValue = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex].ValueObject.ToString();
                                            BindingItem.SubItems.Add(SearchIOValue);

                                            BindingItem.Tag = ((ToolInfo)ProcessListView.Items[Index].Tag).input[IOIndex];
                                        }
                                        else
                                        {
                                            string SearchIOText = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].IOName;
                                            BindingItem.SubItems.Add(SearchIOText);
                                            string SearchIOType = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].IOType;
                                            BindingItem.SubItems.Add(SearchIOType);
                                            string SearchIOValue = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex].ValueObject.ToString();
                                            BindingItem.SubItems.Add(SearchIOValue);

                                            BindingItem.Tag = ((ToolInfo)ProcessListView.Items[Index].Tag).output[IOIndex];
                                        }
                                        lvBinding.Items[lvBinding.Items.Count - 1].Items.Add(BindingItem);
                                    }
                                }
                            }

                        }
                    }
                    lvBinding.ExpandAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
        }

        /// <summary>
        /// 获取当前流程所对应的流程树对象
        /// </summary>
        /// <param name="jobName">流程名</param>
        /// <returns>流程树控件对象</returns>
        internal string GetAllOutPut()
        {
            int Index = ProcessListView.SelectedItems[0].Index;
            
            string Search_Type = ((ToolIO)lvIO.SelectedItems[0].Tag).IOType;

            string Result = "";

            try
            {
                //从之前流程查询
                for (int i = 0; i < Index; i++)
                {
                    int InputCount = ((ToolInfo)(ProcessListView.Items[i].Tag)).input.Count;
                    for (int j = 0; j < InputCount; j++)
                    {
                        if (((ToolInfo)(ProcessListView.Items[i].Tag)).input[j].IOType == Search_Type)
                        {
                            Result = Result + i.ToString() + ",0," + j.ToString() + ";";
                        }


                    }
                    int OutputCount = ((ToolInfo)(ProcessListView.Items[i].Tag)).output.Count;
                    for (int j = 0; j < OutputCount; j++)
                    {
                        if (((ToolInfo)(ProcessListView.Items[i].Tag)).output[j].IOType == Search_Type)
                        {
                            Result = Result + i.ToString() + ",1," + j.ToString() + ";";
                        }
                    }
                }
                ////从全局变量中查询
                for (int i = 0; i < GlobalVariableServices.GlobelVariables.L_variable.Count; i++)
                {
                    if (GlobalVariableServices.GlobelVariables.L_variable[i].type == Search_Type)
                    {
                        Result = Result + "Globel" + "," + GlobalVariableServices.GlobelVariables.L_variable[i].name + ";";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return Result;
        }
        /// <summary>
        /// 参数界面鼠标双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvIO_MouseDoubleClick(object sender, EventArgs e)
        {
            if (lvIO.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择正确的参数项");
            }
            else
            {

                //绑定IO进行赋值
                ToolIO SelectToolIO = (ToolIO)lvIO.SelectedItems[0].Tag;
                SelectToolIO.Binding = false;
                lvIO.SelectedItems[0].SubItems[1].Text = "未绑定";

            }

        }

        public void Init_lvBinding()
        {
            //初始化控件ListView样式
            lvBinding.View = View.Details;      //Set to details view.细节显示
            lvBinding.LabelEdit = false;         //允许用户添加编辑条款
            lvBinding.AllowColumnReorder = false;//Allow the user rearrange columns允许用户从新排列

            lvBinding.FullRowSelect = true;     //整行选择
            lvBinding.Sorting = SortOrder.None; //排序方式
            lvBinding.GridLines = true;         //显示网格线
            lvBinding.MultiSelect = false;      //禁止ListView选择多项
            lvBinding.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvBinding.ShowPlusMinus = false;//禁止左上角加减选项

            //禁止列拖动
            lvBinding.ColumnWidthChanging += delegate (object sender, ColumnWidthChangingEventArgs e)
            {
                e.NewWidth = lvIO.Columns[e.ColumnIndex].Width;
                e.Cancel = true;
            };
            //根据项目加载列
            lvBinding.Columns.Clear();
            lvBinding.Items.Clear();

            int ColumnWidth = lvBinding.Width;
            lvBinding.Columns.Add("模块列表", Convert.ToInt16(ColumnWidth * 0.25), HorizontalAlignment.Left);
            lvBinding.Columns.Add("名称", Convert.ToInt16(ColumnWidth * 0.25), HorizontalAlignment.Center);
            lvBinding.Columns.Add("类型", Convert.ToInt16(ColumnWidth * 0.25), HorizontalAlignment.Center);
            lvBinding.Columns.Add("值", Convert.ToInt16(ColumnWidth * 0.25), HorizontalAlignment.Center);

            //绑定事件
            lvBinding.DoubleClick += new System.EventHandler(lvBinding_MouseDoubleClick);
        }
        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvBinding_MouseDoubleClick(object sender, EventArgs e)
        {
            if (lvBinding.SelectedItems.Count == 0)
            {
            }
            else
            {
                if (lvBinding.SelectedItems[0].Parent == null)
                {
                    //MessageBox.Show("请选择正确的绑定项");
                }
                else
                {
                    //绑定IO进行赋值
                    ((ToolIO)lvIO.SelectedItems[0].Tag).Binding = true;
                    ((ToolIO)lvIO.SelectedItems[0].Tag).BindingObject = lvBinding.SelectedItems[0].Tag;
                    Type a = (lvBinding.SelectedItems[0].Tag).GetType();
                    if (lvBinding.SelectedItems[0].Tag.GetType().Name == "ToolIO")
                    {
                        lvIO.SelectedItems[0].SubItems[1].Text = ((ToolIO)(lvBinding.SelectedItems[0].Tag)).IOAddress;
                        lvIO.SelectedItems[0].SubItems[1].BackColor = Color.GreenYellow;
                    }
                    else if (lvBinding.SelectedItems[0].Tag.GetType().Name == "Variable")
                    {
                        lvIO.SelectedItems[0].SubItems[1].Text = "全局变量" + ((Variable)(lvBinding.SelectedItems[0].Tag)).name;
                        lvIO.SelectedItems[0].SubItems[1].BackColor = Color.GreenYellow;
                    }
                    else
                    {  
                        MessageBox.Show("无此绑定类型");
                    }
                   
                }
            }



        }

        private void Init_ToolStrip1() 
        {
            this.toolStrip1.Items[0].Click += new System.EventHandler(toolStrip1_Item1Clicked);
        }

        /// <summary>
        /// 工具单次执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip1_Item1Clicked(object sender, EventArgs e)
        {
            toolStrip1.Enabled = false;
            try
            {
                ((ToolInfo)ToolBindingItem.Tag).RunTool();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            toolStrip1.Enabled = true;
            textBox_Log.Clear();
            textBox_Log.Text= ((ToolInfo)ToolBindingItem.Tag).Log_Process;

            propertyGrid.Update();
            propertyGrid.Refresh();
            PropertyShow();
        }

        /// <summary>
        /// 显示属性
        /// </summary>
        private void PropertyShow()
        {
            try
            {
                ToolInfo SelectToolInfo = (ToolInfo)ToolBindingItem.Tag;
                CustomPropertyCollection collection = new CustomPropertyCollection();

                //Input属性
                for (int i = 0; i < SelectToolInfo.input.Count; i++)
                {

                    switch (SelectToolInfo.input[i].TypeConverter)
                    {
                        case "Combox":

                            collection.Add(new CustomProperty(SelectToolInfo.input[i].IOName, "ValueObject", SelectToolInfo.input[i].IOCategory, SelectToolInfo.input[i].IOTipInfo, SelectToolInfo.input[i], typeof(CategoryModalEditor)));
                            Form_cCombox.Instance.cComboBox1.Clear();
                            switch (SelectToolInfo.toolGroupName)
                            {
                                //case "伺服操作":
                                //    Form_cCombox.Instance.cComboBox1.Clear();
                                //    for (int j = 0; j < Para_MotorsControl.Basic_Para.ListPointPositionGroupList.Count; j++)
                                //    {

                                //        Form_cCombox.Instance.cComboBox1.Add(Para_MotorsControl.Basic_Para.ListPointPositionGroupList[j].Group_Name);
                                //        Form_cCombox.Instance.cComboBox1.SelectedIndex = 0;
                                //    }
                                //    break;
                                //case "等待信号":
                                //    Form_cCombox.Instance.cComboBox1.Clear();
                                //    for (int j = 0; j < InovanceModel.ioModel.PLC_IO.Count(); j++)
                                //    {
                                //        if (InovanceModel.ioModel.PLC_IO[j].IO_Name != "")
                                //        {
                                //            Form_cCombox.Instance.cComboBox1.Add(InovanceModel.ioModel.PLC_IO[j].IO_Name);
                                //            Form_cCombox.Instance.cComboBox1.SelectedIndex = 0;
                                //        }

                                //    }
                                //    break;

                            }

                            break;

                        
                        default:
                           collection.Add(new CustomProperty(SelectToolInfo.input[i].IOName, "ValueObject", SelectToolInfo.input[i].IOCategory, SelectToolInfo.input[i].IOTipInfo, SelectToolInfo.input[i],typeof(MyStringCollectionEditor)));
                           break;
                    }

                }
                //Output属性
                for (int i = 0; i < SelectToolInfo.output.Count; i++)

                {
                    collection.Add(new CustomProperty(SelectToolInfo.output[i].IOName, "ValueObject", SelectToolInfo.output[i].IOCategory, SelectToolInfo.output[i].IOTipInfo, SelectToolInfo.output[i]));


                }

                propertyGrid.SelectedObject = collection;

            }
            catch (Exception ex)
            {

                Frm_Output.Instance.OutputMsg(ex.ToString(), Color.Red);
            }

        }


        /// <summary>
        /// 刷新ListView
        /// </summary>
        public void ModelToForm()
        {
            ToolInfo SelectToolInfo = ((ToolInfo)ToolBindingItem.Tag);
            //增加参数栏
            for (int i = 0; i < SelectToolInfo.input.Count; i++)
            {
                lvIO.BeginUpdate();
                ListViewItem MyItem = new ListViewItem();
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[2];
                subItems[0] = new ListViewItem.ListViewSubItem();
                subItems[0].Text = SelectToolInfo.input[i].IOName;
                //增加值
                subItems[1] = new ListViewItem.ListViewSubItem();
                if (!SelectToolInfo.input[i].Binding)
                {
                    subItems[1].Text = "未绑定";
                }
                else
                {
                    subItems[1].Text = ((ToolIO)SelectToolInfo.input[i].BindingObject).IOAddress;
                }
                MyItem = new ListViewItem(subItems, SelectToolInfo.toolID);
                MyItem.Tag = SelectToolInfo.input[i];

                lvIO.Items.Add(MyItem);
                lvIO.Refresh();
                lvIO.EndUpdate();

            }
            //设定选定项
            if (SelectToolInfo.input.Count > 0)
            {
                lvIO.Items[0].Selected = true;
            }


        }
        #endregion

        #endregion
        #region 5.公有方法
        #endregion
    }
}
