using Basic_UI;
using Log;
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
using System.Xml;


namespace Tools
{
    public partial class Form_Process : Form
    {

        #region 1.公有变量
        /// <summary>
        ///刷新显示界面
        /// </summary>
        public static event Action<object> Form_Refresh;
       
        //单次循环状态
        public bool On_Circle = false;

        //连续循环状态
        public bool Theard_Run_Status = false;

        //运行步骤
        public int Run_Step = 0;

        //急速模式
        public bool NoRefresh_Mode = false;

        #endregion
        #region 2.私有变量
        //运行线程
        private Thread ThreadAutoRun;

        //工具组
        private List<ToolInfo> ToolInfos;

        #endregion
        #region 3.构造函数
        public Form_Process(string FlowChartName, List<ToolInfo> ListToolInfo)
        {
            InitializeComponent();
            //1.Init_Form
            Init_Form();
            //2.用Model实例化Form
            ToolInfos = ListToolInfo;
            ModelToForm(ToolInfos);
            //3.修改工具条名称
            toolStripLabel1.Text = FlowChartName;
            //线程赋值
            ThreadAutoRun = new Thread(new ThreadStart(CircleActionAllProcess));
            ThreadAutoRun.IsBackground = true;
            ThreadAutoRun.Start();
        }


        public Form_Process()
        {
            InitializeComponent();

        }

        #endregion
        #region 4.私有方法
        /// <summary>
        /// 初始化Form
        /// </summary>
        private void Init_Form()
        {
            Init_ListView();
            Init_ToolStrip();
        }
        /// <summary>
        /// 初始化工具条
        /// </summary>
        private void Init_ToolStrip()
        {
            toolstrip_Process.Items[0].Click += new System.EventHandler(UpSelectTool);
            toolstrip_Process.Items[1].Click += new System.EventHandler(DownSelectTool);
            toolstrip_Process.Items[2].Click += new System.EventHandler(DeleteSelectTool);
        }
        /// <summary>
        /// 删除工具
        /// </summary>
        /// <param name="listViewCollapseProcess"></param>
        /// <param name="ToolStorge"></param>
        public void DeleteSelectTool(object sender, EventArgs e)
        {
            if (lv1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("还没有选择工具，请先选择。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            lv1.Items.Remove(lv1.SelectedItems[0]);

            treeView1_Refresh_text();
        }
        /// <summary>
        /// 上移选择条
        /// </summary>
        /// <param name="listViewCollapseProcess"></param>
        public void UpSelectTool(object sender, EventArgs e)
        {

            if (lv1.SelectedItems.Count == 0)
            {
                MessageBox.Show("还没有选择工具，请先选择。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            lv1.BeginUpdate();
            if (lv1.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem lvi in lv1.SelectedItems)
                {
                    ListViewItem lviSelectedItem = lvi;
                    int indexSelectedItem = lvi.Index;
                    lv1.Items.RemoveAt(indexSelectedItem);
                    lv1.Items.Insert(indexSelectedItem - 1, lviSelectedItem);
                }
            }
            lv1.EndUpdate();
            if (lv1.Items.Count > 0 && lv1.SelectedItems.Count > 0)
            {
                lv1.Focus();
                lv1.SelectedItems[0].Focused = true;
                lv1.SelectedItems[0].EnsureVisible();
            }
            treeView1_Refresh_text();
        }
        /// <summary>
        /// 下移选择条
        /// </summary>
        /// <param name="listViewCollapseProcess"></param>
        public void DownSelectTool(object sender, EventArgs e)
        {
            if (lv1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("还没有选择工具，请先选择。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            lv1.BeginUpdate();
            int indexMaxSelectedItem = lv1.SelectedItems[lv1.SelectedItems.Count - 1].Index;
            if (indexMaxSelectedItem < lv1.Items.Count - 1)
            {
                for (int i = lv1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem lviSelectedItem = lv1.SelectedItems[i];
                    int indexSelectedItem = lviSelectedItem.Index;
                    lv1.Items.RemoveAt(indexSelectedItem);
                    lv1.Items.Insert(indexSelectedItem + 1, lviSelectedItem);
                }
            }
            lv1.EndUpdate();
            if (lv1.Items.Count > 0 && lv1.SelectedItems.Count > 0)
            {
                lv1.Focus();
                lv1.SelectedItems[lv1.SelectedItems.Count - 1].Focused = true;
                lv1.SelectedItems[lv1.SelectedItems.Count - 1].EnsureVisible();
            }
            treeView1_Refresh_text();
        }


        /// <summary>
        /// 初始化ListView
        /// </summary>
        private void Init_ListView()
        {


            //初始化控件ListView样式
            lv1.View = View.Details;      //Set to details view.细节显示
            lv1.LabelEdit = false;         //允许用户添加编辑条款
            lv1.AllowColumnReorder = true;//Allow the user rearrange columns允许用户从新排列
            lv1.CheckBoxes = false;       //DisPlay CheckBox显示打钩的框
            lv1.FullRowSelect = true;     //整行选择
            lv1.Sorting = SortOrder.None; //排序方式
            lv1.GridLines = true;         //显示网格线
            lv1.MultiSelect = false;      //禁止ListView选择多项
            lv1.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            lv1.ColumnWidthChanging += delegate (object sender, ColumnWidthChangingEventArgs e)
            {
                e.NewWidth = lv1.Columns[e.ColumnIndex].Width;
                e.Cancel = true;
            };


            //根据项目加载列
            lv1.Columns.Clear();
            lv1.Items.Clear();
            int ColumnWidth = lv1.Width;
            lv1.Columns.Add("流程里的过程名称", Convert.ToInt16(ColumnWidth * 0.6), HorizontalAlignment.Left);
            lv1.Columns.Add("耗时", Convert.ToInt16(ColumnWidth * 0.2), HorizontalAlignment.Center);
            lv1.Columns.Add("状态", Convert.ToInt16(ColumnWidth * 0.2), HorizontalAlignment.Center);


            //指定事件
            lv1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv1_MouseRightClick);
            lv1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(lv1_MouseDoubleClick);

            //流程树拖动事件
            lv1.AllowDrop = true;
            lv1.DragDrop += new DragEventHandler(lv1_DragDrop);
            lv1.DragEnter += new DragEventHandler(lv1_DragEnter);
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem item = lv1.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    lv1.Items[item.Index].Selected = true;

                }
                //赋值当前Node
                Form_Binding.ToolBindingItem = lv1.SelectedItems[0];
                Form_Binding.ProcessListView = lv1;
                Form_Binding BindingForm1 = new Form_Binding();
                BindingForm1.StartPosition = FormStartPosition.CenterScreen;
                BindingForm1.ShowDialog();
            }
            catch (Exception ex)
            {
                Frm_Output.Instance.OutputMsg(ex.ToString(), Color.Red);

            }

        }

        /// <summary>
        /// 右点击事件
        /// </summary>
        public void lv1_MouseRightClick(object sender, MouseEventArgs e)
        {
            if (lv1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("还没有选择工具，请先选择。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                ////清除右键选项框
                this.contextMenuStrip.Items.Clear();
                this.contextMenuStrip.Items.Add("屏蔽工具");
                this.contextMenuStrip.Items.Add("使用工具");
                this.contextMenuStrip.Items[0].Click += new System.EventHandler(this.屏蔽ToolStripMenuItem_Click);
                this.contextMenuStrip.Items[1].Click += new System.EventHandler(this.使用ToolStripMenuItem1_Click);



                //在鼠标点击位置显示
                contextMenuStrip.Show(MousePosition);

            }
            if (e.Button == MouseButtons.Left)
            {
                string Search_ToolGroupName = ((ToolInfo)lv1.SelectedItems[0].Tag).toolGroupName;

                object Form_Object = Form_Tool.toolGroupModel.Find(e1 => e1.GroupName == Search_ToolGroupName)?.GroupFormObject;

                Form_Refresh(Form_Object);
            }
        }

        /// <summary>
        /// 点击屏蔽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 屏蔽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lv1.BeginUpdate();

            lv1.SelectedItems[0].SubItems[0].BackColor = Color.YellowGreen;

            ((ToolInfo)lv1.SelectedItems[0].Tag).toolenable = false;
            ((ToolInfo)lv1.SelectedItems[0].Tag).Next_Step = -1;
            lv1.Refresh();
            lv1.EndUpdate();

        }

        /// <summary>
        /// 点击使用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 使用ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lv1.SelectedItems[0].SubItems[0].BackColor = Color.White;

            ((ToolInfo)lv1.SelectedItems[0].Tag).toolenable = true;
            lv1.Update();

        }

        /// <summary>
        /// 放开被拖动的节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void lv1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (Theard_Run_Status) return;
                //判断工具箱是否有选择的节点
                if (Form_Tool.DragNode != null)
                {
                    if (sender != null && sender is ListView)
                    {
                        //从工具库找到对应的工具                          
                        ToolInfo SearchTool = (ToolInfo)Form_Tool.DragNode.Tag;
                        AddProcess(SearchTool);
                        treeView1_Refresh_text();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void lv1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        /// <summary>
        /// 增加过程
        /// </summary>
        /// <param name="listViewCollapse"></param>
        private void AddProcess(ToolInfo ToolInfo)
        {
            try
            {
                //复制ToolInfo,防止多次使用
                ToolInfo AddToolInfo = ObjectCopier.Clone(ToolInfo);

                //找到添加的ID
                int i = treeView1_Refresh_Id(AddToolInfo);
                //AddToolInfo.toolID = i;
                AddToolInfo.toolAddress = AddToolInfo.toolName + i.ToString();

                //赋值输入输出值
                for (int j = 0; j < AddToolInfo.input.Count(); j++)
                {

                    //直接通过反映射生成
                    switch (AddToolInfo.input[j].IOType)
                    {
                        case "double":
                            AddToolInfo.input[j].ValueObject = new double();
                            break;
                        case "int":
                            AddToolInfo.input[j].ValueObject = new int();
                            break;
                        case "string":
                            string stringinput = "";
                            AddToolInfo.input[j].ValueObject = stringinput;
                            break;
                        case "bool":
                            bool boolinput = false;
                            AddToolInfo.input[j].ValueObject = boolinput;
                            break;
                        case "List<string>":
                            //string[] stringsinput;
                            List<string> stringsinput = new List<string>();
                            AddToolInfo.input[j].ValueObject = stringsinput;
                            break;
                        case "List<double>":
                            List<double> doubleinput = new List<double>();
                            AddToolInfo.input[j].ValueObject = doubleinput;
                            break;
                        default:
                            AddToolInfo.input[j].ValueObject = Activator.CreateInstance(Type.GetType(AddToolInfo.input[j].IOType));
                            break;
                    }
                    AddToolInfo.input[j].IOAddress = AddToolInfo.toolAddress + "." + AddToolInfo.input[j].IOName;
                }
                //赋值输出值
                for (int j = 0; j < AddToolInfo.output.Count(); j++)

                {
                    //直接通过反映射生成
                    switch (AddToolInfo.output[j].IOType)
                    {
                        case "double":
                            AddToolInfo.output[j].ValueObject = new double();
                            break;
                        case "int":
                            AddToolInfo.output[j].ValueObject = new int();
                            break;
                        case "string":
                            string stringinput = "";
                            AddToolInfo.output[j].ValueObject = stringinput;
                            break;
                        case "bool":
                            bool boolinput = false;
                            AddToolInfo.output[j].ValueObject = boolinput;
                            break;
                        case "List<string>":

                            List<string> stringsinput = new List<string>();

                            AddToolInfo.output[j].ValueObject = stringsinput;

                            break;
                        case "List<double>":

                            List<double> doubleinput = new List<double>();

                            AddToolInfo.output[j].ValueObject = doubleinput;

                            break;
                        default:
                            AddToolInfo.output[j].ValueObject = Activator.CreateInstance(Type.GetType(AddToolInfo.output[j].IOType));
                            break;
                    }

                    AddToolInfo.output[j].IOAddress = AddToolInfo.toolAddress + "." + AddToolInfo.output[j].IOName;
                }


                //复制ToolInfo
                ToolInfo AddToolInfoClone = ObjectCopier.Clone(AddToolInfo);

                //lv中添加项
                lv1.BeginUpdate();
                ListViewItem MyItem = new ListViewItem();
                MyItem.ImageIndex = AddToolInfoClone.toolID;

                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[3];



                subItems[0] = new ListViewItem.ListViewSubItem();
                subItems[0].Name = AddToolInfoClone.toolName;
                subItems[0].Text = lv1.Items.Count.ToString() + "." + AddToolInfoClone.toolName + i.ToString();



                //增加流程号
                subItems[1] = new ListViewItem.ListViewSubItem();
                subItems[1].Text = "";

                //增加listview
                subItems[2] = new ListViewItem.ListViewSubItem();
                subItems[2].Text = "";

                MyItem = new ListViewItem(subItems, MyItem.ImageIndex);

                MyItem.ToolTipText = AddToolInfoClone.toolGroupName;
                MyItem.Tag = AddToolInfoClone;


                lv1.Items.Add(MyItem);
                lv1.Refresh();
                lv1.EndUpdate();
            }
            catch (Exception ex)
            {

                Frm_Output.Instance.OutputMsg(ex.ToString(), Color.Red);
            }
        }

        //找出没有用的序列号
        private int treeView1_Refresh_Id(ToolInfo Tooltemp)
        {
            List<double> ToolIDs = new List<double>();
            foreach (ListViewItem EachItem in lv1.Items)
            {
                if ((Tooltemp.toolName == ((ToolInfo)EachItem.Tag).toolName))
                {
                    string Search_ID = Tooltemp.toolName;
                    ToolInfo a = (ToolInfo)EachItem.Tag;
                    double ID = Convert.ToDouble(((ToolInfo)EachItem.Tag).toolAddress.Replace(Search_ID, ""));

                    ToolIDs.Add(ID);
                }

            }
            //找出没有的ID号
            for (int i = 0; i < ToolIDs.Count(); i++)
            {
                if (!ToolIDs.Exists(p => p == i))
                {
                    return i;
                }

            }
            return ToolIDs.Count();
        }

        /// <summary>
        /// 刷新序列号
        /// </summary>
        private void treeView1_Refresh_text()
        {

            foreach (ListViewItem EachItem in lv1.Items)
            {
                try
                {
                    string EachNodeName = EachItem.Text;
                    EachItem.Text = EachItem.Index + "." + EachNodeName.Split('.')[1];
                    ((ToolInfo)EachItem.Tag).Now_Step = EachItem.Index;
                }
                catch (Exception ex)
                {

                }


            }
            //刷新循环序列对
            Refresh_While();
            lv1.Update();
        }

        /// <summary>
        /// 刷新循环序列对
        /// </summary>
        private void Refresh_While()
        {


            foreach (ListViewItem EachItem in lv1.Items)
            {
                if (((ToolInfo)EachItem.Tag).toolName == "循环结束")
                {
                    foreach (ListViewItem EachItem1 in lv1.Items)
                    {
                        if (((ToolInfo)EachItem1.Tag).toolName == "循环开始")
                        {
                            ((ToolInfo)EachItem.Tag).Next_Step = EachItem1.Index;
                            //MessageBox.Show("循环序列对");
                        }
                    }
                }


            }

            lv1.Update();
        }

        /// <summary>
        /// 用Model赋值Form
        /// </summary>

        private void ModelToForm(List<ToolInfo> Form_ListToolInfo)
        {
            for (int i = 0; i < Form_ListToolInfo.Count; i++)
            {
                //lv中添加项
                lv1.BeginUpdate();
                ListViewItem MyItem = new ListViewItem();
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[3];
                subItems[0] = new ListViewItem.ListViewSubItem();
                subItems[0].Name = Form_ListToolInfo[i].toolName;
                subItems[0].Text = Form_ListToolInfo[i].toolTipInfo;
                subItems[0].BackColor = Form_ListToolInfo[i].toolenable == true ? Color.White : Color.YellowGreen;
                //增加流程号
                subItems[1] = new ListViewItem.ListViewSubItem();
                subItems[1].Text = "";
                //增加listview
                subItems[2] = new ListViewItem.ListViewSubItem();
                subItems[2].Text = "";
                MyItem = new ListViewItem(subItems, MyItem.ImageIndex);
                MyItem.Tag = Form_ListToolInfo[i];
                MyItem.ImageIndex = Form_ListToolInfo[i].toolID;
                lv1.Items.Add(MyItem);
                lv1.Refresh();
                lv1.EndUpdate();
            }
        }
        #endregion
        #region 5.button方法
        private void Toolstrip_START_Click(object sender, EventArgs e)
        {
            //if (ThreadAutoRun.ThreadState == ThreadState.Background)
            //{
            //    ThreadAutoRun.Start();
            //}
            Theard_Run_Status = true;
            On_Circle = true;
            //界面按钮状态
            Toolstrip_START.Enabled = false;
            Toolstrip_STOP.Enabled = true;
            Toolstrip_SUSPEND.Enabled = true;
            Toolstrip_Single.Enabled = false;
            toolStripButton_CircleStart.Enabled = false;
        }

        private void Toolstrip_Single_Click(object sender, EventArgs e)
        {
            Toolstrip_START.Enabled = false;
            Toolstrip_STOP.Enabled = true;
            Toolstrip_SUSPEND.Enabled = true;
            Toolstrip_Single.Enabled = false;
            toolStripButton_CircleStart.Enabled = false;

            ActionProcess();

            Toolstrip_START.Enabled = true;
            Toolstrip_STOP.Enabled = false;
            Toolstrip_SUSPEND.Enabled = false;
            Toolstrip_Single.Enabled = true;
            toolStripButton_CircleStart.Enabled = true;
        }

        private void Toolstrip_STOP_Click(object sender, EventArgs e)
        {
            Run_Step = 0;
            Theard_Run_Status = false;

            //界面按钮状态
            Toolstrip_Single.Enabled = true;
            Toolstrip_START.Enabled = true;
            Toolstrip_STOP.Enabled = false;
            Toolstrip_SUSPEND.Enabled = false;
            toolStripButton_CircleStart.Enabled = true;
        }

        private void Toolstrip_SUSPEND_Click(object sender, EventArgs e)
        {
            Theard_Run_Status = false;
            //界面按钮状态
            Toolstrip_Single.Enabled = true;
            Toolstrip_START.Enabled = true;
            Toolstrip_STOP.Enabled = false;
            Toolstrip_SUSPEND.Enabled = false;

        }

        private void toolStripButton_CircleStart_Click(object sender, EventArgs e)
        {
            if (ThreadAutoRun.ThreadState == ThreadState.Unstarted) 
            {
                ThreadAutoRun.Start();
            }
            Theard_Run_Status = true;
            //界面按钮状态
            Toolstrip_Single.Enabled = false;
            Toolstrip_START.Enabled = false;
            Toolstrip_STOP.Enabled = true;
            Toolstrip_SUSPEND.Enabled = false;
            toolStripButton_CircleStart.Enabled = false;
        }
        /// <summary>
        /// 执行当前步
        /// </summary>
        public void ActionProcess()
        {
            if (lv1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("还没有选择流程，请先选择。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            try
            {
                lv1.SelectedItems[0].SubItems[1].Text = "";
                lv1.SelectedItems[0].SubItems[2].Text = "";
                bool Result =((ToolInfo)lv1.SelectedItems[0].Tag).RunTool();
                lv1.SelectedItems[0].SubItems[1].Text = ((ToolInfo)lv1.SelectedItems[0].Tag).RunTime;
                lv1.SelectedItems[0].SubItems[2].Text = ((ToolInfo)lv1.SelectedItems[0].Tag).RunResult;
                string LogContent = ((ToolInfo)lv1.SelectedItems[0].Tag).Log_Process;
               
                Frm_Output.Instance.OutputMsg(LogContent, Result==true?Color.Green: Color.Red);
                        
            }
            catch (Exception ex)
            {

                Frm_Output.Instance.OutputMsg(ex.ToString(), Color.Red);
            }
        }

        /// <summary>
        /// 所有流程执行
        /// </summary>
        public void ActionAllProcess()
        {
            //界面显示条清零
            foreach (ListViewItem EachItem in lv1.Items)
            {
                EachItem.SubItems[1].Text = "";
                EachItem.SubItems[2].Text = "";
            }
            int RunStep_Temp = 0;

            //执行程序
            for (int i = Run_Step; i < lv1.Items.Count;)
            {

                if (!Theard_Run_Status)
                {
                    break;
                }
                lv1.Items[i].SubItems[1].Text = "";
                lv1.Items[i].SubItems[2].Text = "";
                bool Result = ((ToolInfo)lv1.Items[i].Tag).RunTool();
                lv1.Items[i].SubItems[1].Text = ((ToolInfo)lv1.Items[i].Tag).RunTime;
                lv1.Items[i].SubItems[2].Text = ((ToolInfo)lv1.Items[i].Tag).RunResult;
                string LogContent = ((ToolInfo)lv1.Items[i].Tag).Log_Process;
                if (i != RunStep_Temp)
                {                  
                    Frm_Output.Instance.OutputMsg(LogContent, Result == true ? Color.Green : Color.Red);
                }
                RunStep_Temp = i;

                if ((((ToolInfo)lv1.Items[i].Tag).Next_Step != -1))
                {
                    i = Convert.ToInt32(((ToolInfo)lv1.Items[i].Tag).Next_Step);
                }
                else
                {
                    i = i + 1;
                }
                Run_Step = i;
                Class_Delay.MyDelaySecond(2);
            }
            Run_Step = 0;
            MessageBox.Show("执行完毕");
        }

        /// <summary>
        /// 所有流程循环执行
        /// </summary>
        public void CircleActionAllProcess()
        {
            int RunStep_Temp = 0;
            while (true)
            {
                if (!(Theard_Run_Status))
                {
                    Class_Delay.MyDelaySecond(100);
                    continue;
                }
                
                if ((lv1.Items.Count == 0& !NoRefresh_Mode)|| (ToolInfos.Count == 0 & NoRefresh_Mode))
                {
                    Class_Delay.MyDelaySecond(100);
                    continue;
                }              
                //急速模式
                if (NoRefresh_Mode)
                {
                    if (Run_Step >= 1000) 
                    { 
                        Run_Step = Run_Step - 1000; 
                    }
                    if (Run_Step == 0)
                    {
                        ThisEquipment.Form_Main.Receive?.Clear();
                    }
                    bool Result = ToolInfos[Run_Step].RunTool();
                    string LogContent = ToolInfos[Run_Step].Log_Process;
                    if (Run_Step != RunStep_Temp||Run_Step==0)
                    {
                        
                        if (Result)
                        {
                            Service_Refresh.LogRefresh(LogContent, "green");
                            RunStep_Temp = Run_Step;
                        }
                        else
                        {
                            Theard_Run_Status = false;
                            Run_Step = Run_Step + 1000;
                            RunStep_Temp = Run_Step;
                            Class_Action.ToolBarRefresh("Pause");
                            Service_Refresh.LogRefresh(LogContent, "red");
                            continue;
                        }                       
                    }
                    if (ToolInfos[Run_Step].Next_Step != -1)
                    {
                        Run_Step = Convert.ToInt32(ToolInfos[Run_Step].Next_Step);
                    }
                    else
                    {
                        Run_Step = Run_Step + 1;
                        if (Run_Step >= ToolInfos.Count)
                        {
                            Run_Step = 0;
                        }
                    }
                }
                //正常模式
                else 
                {
                    if (Run_Step >= 1000)
                    {
                        Run_Step = Run_Step - 1000;
                    }
                    if (Run_Step == 0)
                    {
                        ThisEquipment.Form_Main.Receive?.Clear();
                        if (this.IsHandleCreated)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lv1.Update();
                                //界面显示条清零
                                foreach (ListViewItem EachItem in this.lv1.Items)
                                {
                                    EachItem.SubItems[1].Text = "";
                                    EachItem.SubItems[2].Text = "";
                                }
                                lv1.Refresh();
                                lv1.EndUpdate();
                            }));
                        }
                       

                    }
                    if (this.IsHandleCreated || true)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.lv1.Items[Run_Step].SubItems[1].Text = "";
                            this.lv1.Items[Run_Step].SubItems[2].Text = "";
                            //执行程序
                            bool Result = ((ToolInfo)lv1.Items[Run_Step].Tag).RunTool();
                            this.lv1.Items[Run_Step].SubItems[1].Text = ((ToolInfo)lv1.Items[Run_Step].Tag).RunTime;
                            this.lv1.Items[Run_Step].SubItems[2].Text = ((ToolInfo)lv1.Items[Run_Step].Tag).RunResult;
                            string LogContent = ((ToolInfo)lv1.Items[Run_Step].Tag).Log_Process;
                            if (Run_Step != RunStep_Temp || Run_Step ==0)
                            {
                               
                                if (Result)
                                {
                                    RunStep_Temp = Run_Step;
                                    Frm_Output.Instance.OutputMsg(LogContent, Color.Green);
                                    if ((((ToolInfo)lv1.Items[Run_Step].Tag).Next_Step != -1))
                                    {
                                        Run_Step = Convert.ToInt32(((ToolInfo)lv1.Items[Run_Step].Tag).Next_Step);
                                    }
                                    else
                                    {
                                        Run_Step = Run_Step + 1;
                                        if (Run_Step >= lv1.Items.Count)
                                        {
                                            if (On_Circle)
                                            {
                                                On_Circle = false;
                                                Theard_Run_Status = false;                                               
                                                Toolstrip_Single.Enabled = true;
                                                Toolstrip_START.Enabled = true;
                                                Toolstrip_STOP.Enabled = true;
                                                Toolstrip_SUSPEND.Enabled = true;
                                                toolStripButton_CircleStart.Enabled = true;
                                                
                                            }
                                            Run_Step = 0;

                                        }
                                    }
                                }
                                else
                                {
                                    Run_Step = Run_Step + 1000;
                                    RunStep_Temp = Run_Step;
                                    Theard_Run_Status = false;
                                    Frm_Output.Instance.OutputMsg(LogContent, Color.Red);
                                    //界面按钮状态
                                    Toolstrip_Single.Enabled = true;
                                    Toolstrip_START.Enabled = true;
                                    Toolstrip_STOP.Enabled = false;
                                    Toolstrip_SUSPEND.Enabled = false;
                                  
                                }
                            }
                        }));
                    }
                }
                
                Class_Delay.MyDelaySecond(20);

            }
        }



        #endregion
        #region 公用方法
        public List<ToolInfo> Save_Infos() 
        {
            ToolInfos.Clear();
            foreach (ListViewItem EachSubItem in lv1.Items)
            {
                ToolInfo EachToolInfo = (ToolInfo)EachSubItem.Tag;
                EachToolInfo.toolTipInfo = EachSubItem.SubItems[0].Text;
                ToolInfos.Add(EachToolInfo);
            }
            return ToolInfos;

        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
