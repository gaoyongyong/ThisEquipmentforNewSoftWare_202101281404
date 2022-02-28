using Basic_UI;
using MotorsControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ThisEquipment;


namespace Tools
{
    public partial class Form_Tools : Form
    {
        #region 1.公有变量
        /// <summary>
        /// 流程集合
        /// </summary>
        public List<FlowChatInfo> flowChatList = null;

        /// <summary>
        /// 界面构造地址
        /// </summary>
        public string FormTOOLS_Address = null;

        /// <summary>
        /// 方法启动，方法暂停，方法停止
        /// </summary>
        public static Action<bool> AllRun, AllPause, AllStop;


        public static bool Form_Tools_Runing = false;

        #endregion
        #region 2.私有变量
        /// <summary>
        /// 项目Xml地址
        /// </summary>
        // private string Xml_Addr = @"D:\Program Files\ThisEquipment\Database\SwParameter\Xml\Project.xml";
        private string Xml_Addr;
        /// <summary>
        /// 全局变量
        /// </summary>
        private Form_GlobalVariable Form_Global;

        private Form_Tool Form_Tool;

        #endregion
        #region 3.构造函数
        public Form_Tools(string PathFile_FlowChat)
        {
            InitializeComponent();

            //1.初始化界面
            Init_Form(PathFile_FlowChat);
            Xml_Addr = PathFile_FlowChat+@"\Project.xml";
            //2.绑定委托（过程中的界面显示到主界面上）
            Form_Process.Form_Refresh += FormShow;

            //3.加载Xml
            bool result = true;
            flowChatList = XmlObjConvert.DeserializeObjectFromPath<List<FlowChatInfo>>(Xml_Addr, out result);

            //4.Model实例化Form
            ModelToForm();

            //5.委托刷新
            AllRun += toolStripButton_Start_Click;
            AllPause += toolStripButton_CircleStart_Pause;
            AllStop += toolStripButton_StopAll_Click;

            //定时器启动
            timer1.Enabled = true;
        }

        public Form_Tools()
        {
            InitializeComponent();

            ////1.初始化界面
            //Init_Form();

            ////2.绑定委托（过程中的界面显示到主界面上）
            //Form_Process.Form_Refresh += FormShow;

            ////3.加载Xml
            //bool result = true;
            //flowChatList = XmlObjConvert.DeserializeObjectFromPath<List<FlowChatInfo>>(Xml_Addr, out result);

            ////4.Model实例化Form
            //ModelToForm();

            ////5.委托刷新
            //AllRun += toolStripButton_Start_Click;
            //AllPause += toolStripButton_CircleStart_Pause;
            //AllStop += toolStripButton_StopAll_Click;

        }
        #endregion
        #region 4.私有方法
        #region 初始化界面
        /// <summary>
        /// 初始化界面
        /// </summary>
        private void Init_Form(string Path)
        {
            //1.初始化流程FORM
            INIT_ListView(listViewCollapseFlowChat);

            ////2.初始化工具FORM
            Form_Tool = new Form_Tool(Path);
            Class_Form.PanelShow(panel_Tool, Form_Tool);

            ////3.初始化过程Form
            //Class_Form.PanelShow(panel_Process, new Form_Process());

            //4.初始化Log_Form
            Class_Form.PanelShow(panel_Log, Frm_Output.Instance);

            //5.初始化toolStrip_main
            //Init_toolStrip_main();

            //6.初始化全局变量窗口
            Form_Global = new Form_GlobalVariable(Path);
        }
        /// <summary>
        ///将当前界面显示在Panel中
        /// </summary>
        /// <param name="temp"></param>
        private void FormShow(object temp=null)
        {
            if (temp == null)
            {
                Class_Form.PanelShow(this.ManualPanel, new Form());
            }
            else
            {
                Class_Form.PanelShow(this.ManualPanel, (Form)temp, false); 
            }

        }
        /// <summary>
        /// 增加流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAddFlowChat_Click(object sender, EventArgs e)
        {
            //在流程栏增加流程

            listViewCollapseFlowChat.BeginUpdate();
            ListViewItem MyItem = new ListViewItem();
            MyItem.ImageIndex = 1;
            ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[2];
            subItems[0] = new ListViewItem.ListViewSubItem();
            double ID = flowChatList_Refresh_Id();
            subItems[0].Text = "流程" + ID.ToString();
            subItems[0].Name = ID.ToString();

            //增加流程号
            subItems[1] = new ListViewItem.ListViewSubItem();
            List<ToolInfo> ListToolInfo = new List<ToolInfo>();


            MyItem = new ListViewItem(subItems, MyItem.ImageIndex);
            MyItem.Tag = new Form_Process(subItems[0].Text, ListToolInfo);
            listViewCollapseFlowChat.Items.Add(MyItem);
            listViewCollapseFlowChat.Refresh();
            listViewCollapseFlowChat.EndUpdate();
        }
        /// <summary>
        /// 删除流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDeleteFlowChat_Click(object sender, EventArgs e)
        {
            if (listViewCollapseFlowChat.SelectedItems.Count <= 0)
            {
                MessageBox.Show("还没有选择工具，请先选择。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (((Form_Process)listViewCollapseFlowChat.SelectedItems[0].Tag).Theard_Run_Status)
            {
            }
            else 
            {
                listViewCollapseFlowChat.Items.Remove(listViewCollapseFlowChat.SelectedItems[0]);          
                Class_Form.PanelShow(panel_Process,new Form() );
                FormShow();
            }
            

        }
        /// <summary>
        /// 增加方法流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSettingFlowchat_Click(object sender, EventArgs e)
        {
            //判断当前位置
            int index = listViewCollapseFlowChat.Items.Count;

            listViewCollapseFlowChat.BeginUpdate();
            ListViewItem MyItem = new ListViewItem();
            MyItem.ImageIndex = 2;
            ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[2];
            subItems[0] = new ListViewItem.ListViewSubItem();
            double ID = flowChatList_Refresh_Id();
            subItems[0].Text = "方法流程" + ID.ToString();
            subItems[0].Name = ID.ToString();

            //增加方法流程
            subItems[1] = new ListViewItem.ListViewSubItem();
            subItems[1].Tag = new Form_Process();

            MyItem = new ListViewItem(subItems, MyItem.ImageIndex);
            listViewCollapseFlowChat.Items.Add(MyItem);
            listViewCollapseFlowChat.Refresh();
            listViewCollapseFlowChat.EndUpdate();
        }

        /// <summary>
        /// 显示全局变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           // Form_Global = new Form_GlobalVariable();
            Form_Global.ShowDialog();
        }

        /// <summary>
        /// 流程选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewCollapseFlowChat_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (listViewCollapseFlowChat.SelectedItems.Count > 0)
            {
                if (listViewCollapseFlowChat.SelectedItems[0].Tag != null)
                {
                    Class_Form.PanelShow(panel_Process, (Form_Process)(listViewCollapseFlowChat.SelectedItems[0].Tag));
                }


            }

        }



        /// <summary>
        /// 初始化lv1
        /// </summary>
        /// <param name="lv1"></param>
        public void INIT_ListView(ListViewCollapse lv1)
        {
            //初始化控件ListView样式
            lv1.View = View.Details;      //Set to details view.细节显示
            lv1.LabelEdit = true;         //允许用户添加编辑条款
            lv1.AllowColumnReorder = true;//Allow the user rearrange columns允许用户从新排列
            lv1.CheckBoxes = false;       //DisPlay CheckBox显示打钩的框
            lv1.FullRowSelect = true;     //整行选择
            lv1.Sorting = SortOrder.None; //排序方式
            lv1.GridLines = true;         //显示网格线
            lv1.MultiSelect = false;      //禁止ListView选择多项
            lv1.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            //禁止移动
            lv1.ColumnWidthChanging += delegate (object sender, ColumnWidthChangingEventArgs e)
            {
                e.NewWidth = lv1.Columns[e.ColumnIndex].Width;
                e.Cancel = true;
            };

            //根据项目加载列
            lv1.Columns.Clear();
            lv1.Items.Clear();

            int ColumnWidth = lv1.Width - 10;

            lv1.Columns.Add("流程名称", Convert.ToInt16(ColumnWidth * 0.8), HorizontalAlignment.Left);
            lv1.Columns.Add("流程ID", Convert.ToInt16(ColumnWidth * 0.2), HorizontalAlignment.Left);


        }



        /// <summary>
        /// 找出没用的序列号
        /// </summary>
        /// <param name="ToolName"></param>
        /// <returns></returns>
        private double flowChatList_Refresh_Id()
        {
            List<double> ToolIDs = new List<double>();
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                //if (ToolName == EachItem.SubItems[0].Text.Replace(EachItem.SubItems[0].Name, ""))
                if (true)
                {

                    double ID = Convert.ToDouble(EachItem.SubItems[0].Text.Replace("流程", ""));

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
        /// 保存流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTOOLS_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Dispose();
                foreach (Control EachControl in this.panelProcess.Controls)
                {
                    EachControl.Dispose();
                }
                Application.Exit();

            }
            catch (Exception ex)
            {

                
            }    
           
        }
        #endregion

        #region Model实例化Form
        /// <summary>
        /// Model实例化Form
        /// </summary>
        private void ModelToForm()
        {
            for (int i = 0; i < flowChatList.Count; i++)
            {
                listViewCollapseFlowChat.BeginUpdate();
                ListViewItem MyItem = new ListViewItem();

                MyItem.ImageIndex = flowChatList[i].FlowChatID;
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[2];
                subItems[0] = new ListViewItem.ListViewSubItem();
                subItems[0].Text = flowChatList[i].FlowChatName;
                
                //增加流程号
                subItems[1] = new ListViewItem.ListViewSubItem();
               
                MyItem = new ListViewItem(subItems, MyItem.ImageIndex);
                MyItem.Tag = new Form_Process(flowChatList[i].FlowChatName, flowChatList[i].ToolInfoList);
                Class_Form.PanelShow(panel_Process, (Form)MyItem.Tag);

                listViewCollapseFlowChat.Items.Add(MyItem);
                listViewCollapseFlowChat.Refresh();
                listViewCollapseFlowChat.EndUpdate();

            }
        }



        #endregion

        #endregion

        #region 5.公有方法
        public bool Check_Status()
        {
            bool status = false;
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                status = Form_Tools_Runing || ((Form_Process)EachItem.Tag).Theard_Run_Status;
            }
            if (status)
            {
                return true;
            }
            else 
            {
                return false;
            }

        }
        public void AllClose()
        {
            try
            {                
                for (int i = Form_Tool.toolGroupModel.Count-1; i >= 0; i--)
                {
                    object[] Para_obj = new object[0];
                    MethodInfo Method = Form_Tool.toolGroupModel[i].GroupFormObject.GetType().GetMethod("Close");

                    if (Method != null)
                    {
                        //第三步：执行动作
                        object Result = Method.Invoke(Form_Tool.toolGroupModel[i].GroupFormObject, Para_obj);

                    }
                    else
                    {
                        ((Form)Form_Tool.toolGroupModel[i].GroupFormObject).Close();
                    }
                }
               
                foreach (Control EachControl in this.panelProcess.Controls)
                {
                    EachControl.Dispose();
                }
                
                this.Dispose();
            }
            catch (Exception ex)
            {


            }
        }


        #endregion

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            toolStripButton_Save_Click();
        }
        public void toolStripButton_Save_Click() 
        {
            try
            {
                if (!Form_Tool.SaveGroupModel())
                {
                    MessageBox.Show("工具组保存失败!");
                    return;
                    
                }
             
                flowChatList = new List<FlowChatInfo>();
                foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
                {
                    FlowChatInfo FlowChatInfo = new FlowChatInfo();
                    FlowChatInfo.FlowChatID = 1;
                    FlowChatInfo.FlowChatName = EachItem.SubItems[0].Text;                 
                    FlowChatInfo.ToolInfoList = ((Form_Process)EachItem.Tag).Save_Infos();                  
                    flowChatList.Add(FlowChatInfo);
                }
                
                if (!XmlObjConvert.SerializeObject(flowChatList, Xml_Addr))
                {

                    MessageBox.Show("保存失败!");
                    return;
                }
                MessageBox.Show("保存成功!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败!");
            }

        }

        private void toolStripButton_StopAll_Click(object sender, EventArgs e)
        {
            toolStripButton_StopAll_Click();
        }
        private void toolStripButton_StopAll_Click(bool NoFreshMode = false)
        {
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                if (NoFreshMode)
                {
                    ((Form_Process)EachItem.Tag).NoRefresh_Mode = false;
                }
                ((Form_Process)EachItem.Tag).Theard_Run_Status = false;
                ((Form_Process)EachItem.Tag).On_Circle = false;
                ((Form_Process)EachItem.Tag).Run_Step = 0;

                ((Form_Process)EachItem.Tag).Toolstrip_START.Enabled = true;
                ((Form_Process)EachItem.Tag).Toolstrip_STOP.Enabled = false;
                ((Form_Process)EachItem.Tag).Toolstrip_SUSPEND.Enabled = false;
                ((Form_Process)EachItem.Tag).Toolstrip_Single.Enabled = true;
                ((Form_Process)EachItem.Tag).toolStripButton_CircleStart.Enabled = true;
            }
            toolStripButton_CircleStart.Enabled = true;
            toolStripButton_CirclePause.Enabled = false;
            toolStripButton_StopAll.Enabled = false;
           // timer1.Enabled = false;
            listViewCollapseFlowChat.BeginUpdate();
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                EachItem.SubItems[1].Text = "";
                
            }
            listViewCollapseFlowChat.Refresh();
            listViewCollapseFlowChat.EndUpdate();
        }



        private void toolStripButton_CircleStart_Pause(object sender, EventArgs e)
        {
            toolStripButton_CircleStart_Pause();
        }

        private void toolStripButton_CircleStart_Pause(bool NoFreshMode = false)
        {
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                if (NoFreshMode)
                {
                    ((Form_Process)EachItem.Tag).NoRefresh_Mode = false;
                }
                ((Form_Process)EachItem.Tag).Theard_Run_Status = false;

                ((Form_Process)EachItem.Tag).Toolstrip_START.Enabled = true;
                ((Form_Process)EachItem.Tag).Toolstrip_STOP.Enabled = false;
                ((Form_Process)EachItem.Tag).Toolstrip_SUSPEND.Enabled = false;
                ((Form_Process)EachItem.Tag).Toolstrip_Single.Enabled = true;
                ((Form_Process)EachItem.Tag).toolStripButton_CircleStart.Enabled = true;
            }
            toolStripButton_CircleStart.Enabled = true;
            toolStripButton_CirclePause.Enabled = false;
            toolStripButton_StopAll.Enabled = false;
           // timer1.Enabled = false;
            listViewCollapseFlowChat.BeginUpdate();
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                EachItem.SubItems[1].Text = "";
            }
            listViewCollapseFlowChat.Refresh();
            listViewCollapseFlowChat.EndUpdate();
        }



        private void toolStripButton_Start_Click(object sender, EventArgs e)
        {
            toolStripButton_Start_Click();
        }

        private void Form_Tools_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                
               
                foreach (Control EachControl in this.panelProcess.Controls)
                {
                    EachControl.Dispose();
                }
                Application.Exit();

            }
            catch (Exception ex)
            {


            }
        }

        private void toolStripButton_Start_Click(bool NoFreshMode = false)
        {
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                if (NoFreshMode) 
                {
                    ((Form_Process)EachItem.Tag).NoRefresh_Mode = true;
                }
                ((Form_Process)EachItem.Tag).Theard_Run_Status = true;

                ((Form_Process)EachItem.Tag).Toolstrip_START.Enabled = false;
                ((Form_Process)EachItem.Tag).Toolstrip_STOP.Enabled = true;
                ((Form_Process)EachItem.Tag).Toolstrip_SUSPEND.Enabled = true;
                ((Form_Process)EachItem.Tag).Toolstrip_Single.Enabled = false;
                ((Form_Process)EachItem.Tag).toolStripButton_CircleStart.Enabled = false;
            }
            toolStripButton_CircleStart.Enabled = false;
            toolStripButton_CirclePause.Enabled = true;
            toolStripButton_StopAll.Enabled = true;

            //timer1.Enabled = true;
        }


        /// <summary>
        /// 定时刷数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            listViewCollapseFlowChat.BeginUpdate();
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                EachItem.SubItems[1].Text = ((Form_Process)EachItem.Tag).Run_Step.ToString();
            }
            listViewCollapseFlowChat.Refresh();
            listViewCollapseFlowChat.EndUpdate();

            bool Running = false;
            foreach (ListViewItem EachItem in listViewCollapseFlowChat.Items)
            {
                if (((Form_Process)EachItem.Tag).Theard_Run_Status == true)
                {
                    Running = true;
                  
                }
            }
            if (Running)
            {
                ManualPanel.Enabled = false;
            }
            else 
            {
                ManualPanel.Enabled = true ;
            }
        }
    }
}
