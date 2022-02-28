using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ToolBars;
using System.IO;
using ScriptCaculate;
using namespace_Loading;
using Measure;
using VISION_CVX;
using Parameter;
using HalconDotNet;
using CheckAxis;
using ProStatistics;

using Tools;
using MotorsControl;
using System.Runtime.InteropServices;
using WinForm.FormBuild;
using MyCpk;

namespace ThisEquipment
{
    public partial class Form_Main : Form
    {
        #region 1.变量
        #region 1.变量-窗体
        public Form_SubHome formSubHome = null;
       // public Form_SubSet formSubSet = null;
        public Form_SubData formSubData = null;
        public Form_MyCpk form_MyCpk = null;
        public Form_Tools formTools = null;
        public Form_Show form_Show = null;
        public User.Dialog_Login dialog_Login = null;
        public Dialog_ProjectChoose.Dialog_ProjectChoose dialog_ProjectChoose = null;
        #endregion
        #region 2.变量-局部变量
       
        public string Product_SN;
        public static bool HardWare_Error = false;
        /// <summary>
        /// 所有接受到的数据
        /// </summary>
        public static List<List<double>> Receive;

        #endregion
        #endregion
        #region 2.构造函数
        public Form_Main()
        {
            InitializeComponent();
 
            #region  1.初始化toolBar_Main
            toolBar_Main1.PanelWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            toolBar_Main1.PanelHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            toolBar_Main1.ToolBarMain_Btn01_Click += new ToolBar_Main.Btn01ClickHandle(ToolBarMainBtn01_Click);
            toolBar_Main1.ToolBarMain_Btn02_Click += new ToolBar_Main.Btn02ClickHandle(ToolBarMainBtn02_Click);
            toolBar_Main1.ToolBarMain_Btn03_Click += new ToolBar_Main.Btn03ClickHandle(ToolBarMainBtn03_Click);
            toolBar_Main1.ToolBarMain_Btn04_Click += new ToolBar_Main.Btn04ClickHandle(ToolBarMainBtn04_Click);
            toolBar_Main1.ToolBarMain_Btn05_Click += new ToolBar_Main.Btn05ClickHandle(ToolBarMainBtn05_Click);
            toolBar_Main1.ToolBarMain_Btn11_Click += new ToolBar_Main.Btn11ClickHandle(ToolBarMainBtn11_Click);
            toolBar_Main1.ToolBarMain_Btn12_Click += new ToolBar_Main.Btn12ClickHandle(ToolBarMainBtn12_Click);
            toolBar_Main1.ToolBarMain_Btn13_Click += new ToolBar_Main.Btn13ClickHandle(ToolBarMainBtn13_Click);
            toolBar_Main1.ToolBarMain_Btn21_Click += new ToolBar_Main.Btn21ClickHandle(ToolBarMainBtn21_Click);
            toolBar_Main1.ToolBarMain_Btn22_Click += new ToolBar_Main.Btn22ClickHandle(ToolBarMainBtn22_Click);
            toolBar_Main1.ToolBarMain_Lbl_PrjName_DoubleClick += new ToolBar_Main.Lbl_PrjNameDoubleClickHandle(ToolBarMainLblPrjName_DoubleClick);
            toolBar_Main1.ToolBarMain_button_left_Click += new ToolBar_Main.button_leftClickHandle(ToolBarMain_button_left_Click);
            toolBar_Main1.ToolBarMain_button_right_Click += new ToolBar_Main.button_rightClickHandle(ToolBarMain_button_right_Click);
            toolBar_Main1.Btn01Enable = false;
            #endregion

            #region 2.初始化Form
            formSubHome = new Form_SubHome();
            //formSubSet = new Form_SubSet();
            formSubData = new Form_SubData();
            form_MyCpk = new Form_MyCpk();
            formTools = new Form_Tools();
            form_Show = new Form_Show();

            Layer.StyleUtils.MainFormStyle(this);
            Layer.StyleUtils.SetMdiStyle(this, formSubHome, 0, 0);
            Layer.StyleUtils.SetMdiStyle(this, form_Show, 0, 0);
            Layer.StyleUtils.SetMdiStyle(this, formSubData, 0, 0);
            Layer.StyleUtils.SetMdiStyle(this, form_MyCpk, 0, 0);
            Layer.StyleUtils.SetMdiStyle(this, formTools, 0, 0);

            //3.接受到数据实例化
            Receive = new List<List<double>>();
            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //显示的第一个界面
            formSubHome.Show();
            toolBar_Main1.FANC_BtnsEnableClick(toolBar_Main1.ProcessLoad, "");
            formSubHome.uiLog1.FUNC_AppendLogMsg("Loading Sorftware.", Color.Black);
        }
        #endregion
        #region 3.按钮事件
        /*------------------------------------------------------------------------------------------*/
        /*------------------------------------ToolBars----------------------------------------------*/
        /*------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 项目选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainLblPrjName_DoubleClick(object sender, EventArgs e)
        {
            if (Dialog_ProjectChoose.Dialog_ProjectChoose.isShow)
                return;

            //------------------------------------------
            formSubHome.uiLog1.FUNC_AppendLogMsg("Starting Project choose.", Color.Black);

            string[] strAuthority = new string[5];
            strAuthority = User.SysUser.user.Authority.Split(',');
            dialog_ProjectChoose = new Dialog_ProjectChoose.Dialog_ProjectChoose(strAuthority[0]);
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
            if (strPrjChooseClick[0] == "ProjectDeleted")
            {
                formSubHome.uiLog1.FUNC_AppendLogMsg("Project Deleted. Name: " + strPrjChooseClick[1], Color.Red);
            }
            else if (strPrjChooseClick[0] == "ProjectCreated")
            {
                formSubHome.uiLog1.FUNC_AppendLogMsg("Project Created. Name: " + strPrjChooseClick[1], Color.Black);
            }
            else if (strPrjChooseClick[0] == "ProjectChoosed")
            {
                formSubHome.uiLog1.FUNC_AppendLogMsg("Project choosed sucessful.-->", Color.Black);
                formSubHome.uiLog1.FUNC_AppendLogMsg("-->Project Name is:" + Dialog_ProjectChoose.ProjectChoose.ProjectName, Color.Blue);
                //判断文件是否存在
                if (!Directory.Exists(Dialog_ProjectChoose.ProjectChoose.strMyDBLoad))
                {
                    formSubHome.uiLog1.FUNC_AppendLogMsg("选定的项目不存在,请进入ROOT权限重新选择默认项目", Color.Red);
                    return;
                }
                toolBar_Main1.UpdatePrjName(Dialog_ProjectChoose.ProjectChoose.ProjectName);
                formSubHome.uiLog1.FUNC_AppendLogMsg("Loading parameters and initialize winforms.", Color.Black);
                //项目选择成功事件，在这里插入用户代码----------------------------------------------------------
                //这里添加项目选择后的代码
                #region //1.固定的初始化操作
                //1.初始化测试结果界面
                formSubHome.showTestResult1.INIT_ShowTestResult(Dialog_ProjectChoose.ProjectChoose.ProjectName);
                //2.初始化计数界面
                formSubHome.proStatistics1.INIT_ProStatistics();
                //3.初始化数据界面             
                formSubData.showTestAllDataInListView1.INIT_ShowTestAllDataInListView(Dialog_ProjectChoose.ProjectChoose.ProjectName);
                //4.初始化Toolbar界面
                toolBar_Main1.FANC_ControlButton_Status("ini");
                //5更改MeasureData INI 文件
                //Parameter.modINI<Class_ProjectChoose_Parameter>.strFileName = Dialog_ProjectChoose.ProjectChoose.strMyDBLoad + @"\MeasureData.ini";
                //6.Tool界面刷新
                formTools = new Form_Tools(Dialog_ProjectChoose.ProjectChoose.strMyDBLoad);
                Layer.StyleUtils.SetMdiStyle(this, formTools, 0, 0);
                //7.刷新显示图片
                formSubHome.pictureBox1.BackgroundImage = Class_Image.LoadImage(Dialog_ProjectChoose.ProjectChoose.strMyDBLoad + @"\Product_Picture.png");
                formSubHome.pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                formSubHome.pictureBox1.Refresh();

                //9.启动状态栏
                timer1.Enabled = true;
                
                //11.更改measuredata 数据库
                string[] temp = Dialog_ProjectChoose.ProjectChoose.strMyDBLoad.Split('\\');
                Measurelog.path_log_Data = @"D:\Log\Data" + @"\" + temp[5];
                #endregion
            }

        }

        /// <summary>
        /// Sub_Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn01_Click(object sender, EventArgs e)
        {
            formSubHome.Show();
            form_Show.Hide();
            form_MyCpk.Hide();
            formSubData.Hide();
            formTools.Hide();
        }
        /// <summary>
        /// Parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn02_Click(object sender, EventArgs e)
        {
            formSubHome.Hide();
            form_Show.Show();
            form_MyCpk.Hide();
            formSubData.Hide();
            formTools.Hide();
        }
        /// <summary>
        /// HW
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn03_Click(object sender, EventArgs e)
        {
            formSubHome.Hide();
            form_Show.Hide();
            form_MyCpk.Show();
            formSubData.Hide();
            formTools.Hide();
        }
        /// <summary>
        /// Vision
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn04_Click(object sender, EventArgs e)
        {
            formSubHome.Hide();
            form_Show.Hide();
            form_MyCpk.Hide();
            formSubData.Hide();
            formTools.Hide();
        }
        /// <summary>
        /// Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn05_Click(object sender, EventArgs e)
        {
            formSubHome.Hide();
            form_Show.Hide();
            form_MyCpk.Hide();
            formSubData.Show();
            formTools.Hide();
        }


        /// <summary>
        /// 左界面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ToolBarMain_button_left_Click(object sender, EventArgs e)
        {
            //1.停止所有流程
            Form_Tools.AllStop(true);  
            //2.刷新界面按钮
            toolBar_Main1.FANC_ControlButton_Status("Stop");
 
            formSubHome.Hide();
            form_Show.Hide();
            form_MyCpk.Hide();
            formSubData.Hide();
            formTools.Show();
        }
        /// <summary>
        /// 右界面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMain_button_right_Click(object sender, EventArgs e)
        {
            //1.停止所有流程
            Form_Tools.AllStop(true);
            //2.保存流程
            formTools.toolStripButton_Save_Click();

            formSubHome.Show();
            form_Show.Hide();
            form_MyCpk.Hide();
            formSubData.Hide();
            formTools.Hide();
            //权限赋值
           
            toolBar_Main1.FANC_BtnsEnableClick(toolBar_Main1.ProcessPrjChoose, User.SysUser.user.Authority);
        }
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn11_Click(object sender, EventArgs e)
        {
            if (!HardWare_Error || true)
            {
                if (!ToolBar_Main.RunFlag)
                {
                    Form_Tools.AllRun(true);

                    //Controlbutton第一次启动
                    toolBar_Main1.FANC_ControlButton_Status("Start");
                    formSubHome.uiLog1.FUNC_AppendLogMsg("启动", Color.Blue);
                }
                else if (ToolBar_Main.RunFlag && ToolBar_Main.PauseFlag)
                {

                    Form_Tools.AllRun(true);

                    toolBar_Main1.FANC_ControlButton_Status("Start");
                    formSubHome.uiLog1.FUNC_AppendLogMsg("暂停取消", Color.Blue);
                }
            }
            else
            {
                MessageBox.Show("硬件连接不成功禁止启动，请重启软件!");
            }
        }


        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn12_Click(object sender, EventArgs e)
        {
            if (ToolBar_Main.RunFlag)
            {

                if (!ToolBar_Main.PauseFlag)
                {
                    Form_Tools.AllPause(true);
                    //Controlbutton暂停
                    toolBar_Main1.FANC_ControlButton_Status("Pause");
                    formSubHome.uiLog1.FUNC_AppendLogMsg("暂停", Color.Blue);

                    LoadingForm.MethodInvokerCloseMsgForm(this);
                    formSubHome.proStatistics1.FUNC_CTStop();
                }
                else
                {

                  
                }

            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn13_Click(object sender, EventArgs e)
        {
            if (ToolBar_Main.RunFlag)
            {
                Form_Tools.AllStop(true);

                //Controlbutton停止
                toolBar_Main1.FANC_ControlButton_Status("Stop");

                //关闭MSG窗口,关闭CT计数窗口
                LoadingForm.MethodInvokerCloseMsgForm(this);
                formSubHome.proStatistics1.FUNC_CTStop();

               

                formSubHome.uiLog1.FUNC_AppendLogMsg("停止", Color.Blue);

                //线程结束运行
                timer2.Stop();
            }

        }

        /// <summary>
        /// 用户登入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn21_Click(object sender, EventArgs e)
        {
            if (ToolBar_Main.RunFlag)
                return;
            if (User.Dialog_Login.isShow)
                return;

            formSubHome.uiLog1.FUNC_AppendLogMsg("Starting User Login.", Color.Black);
            dialog_Login = new User.Dialog_Login();
            dialog_Login.UserLoginEvent += new User.Dialog_Login.MyDelegate(Dialog_Login_UserLoginEvent);
            dialog_Login.Show();

        }


        /// <summary>
        /// 用户登入事件
        /// </summary>
        void Dialog_Login_UserLoginEvent(string strUserLogin)
        {


            if (strUserLogin == "UserLoginPasswordIsNotCorrect")
            {
                formSubHome.uiLog1.FUNC_AppendLogMsg("User Login Password Is Not Correct.", Color.Red);
            }
            else if (strUserLogin == "UserLoginUserIsNotExist")
            {
                formSubHome.uiLog1.FUNC_AppendLogMsg("User Login User Is Not Exist.", Color.Red);
            }
            else if (strUserLogin == "UserLoginExit")
            {
                formSubHome.uiLog1.FUNC_AppendLogMsg("User Login Exit.", Color.Red);
            }
            if (strUserLogin == "UserLoginSuccessful")
            {
                formSubHome.uiLog1.FUNC_AppendLogMsg("User Login.-->", Color.Black);
                formSubHome.uiLog1.FUNC_AppendLogMsg("-->User Name is:" + User.SysUser.user.Username, Color.Blue);
                formSubHome.uiLog1.FUNC_AppendLogMsg("-->User Authority is:" + User.SysUser.user.Authority, Color.Blue);

                if (true)
                {
                    toolBar_Main1.FANC_BtnsEnableClick(toolBar_Main1.ProcessLogin, User.SysUser.user.Authority);


                    //如果是User用户，直接登入保存的默认名称的项目
                    string[] strUserAuthority = User.SysUser.user.Authority.Split(',');
                    if (strUserAuthority[0].ToUpper() == "USER")
                    {

                        Dialog_ProjectChoose.ProjectChoose.ProjectName = User.SysUser.defaultPrjName;
                        Dialog_ProjectChoose.ProjectChoose.strMyDBLoad = Dialog_ProjectChoose.ProjectChoose.strLoad + Dialog_ProjectChoose.ProjectChoose.ProjectName;   //得到项目路径

                        Dialog_ProjectChoose_ProjectChoosedEvent("ProjectChoosed");
                    }


                }
                else
                {
                   
                }


                //用户登入成功事件，在这里插入用户代码----------------------------------------------------------
                toolBar_Main1.FANC_BtnsEnableClick(toolBar_Main1.ProcessPrjChoose, User.SysUser.user.Authority);


            }

        }
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }


        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        /// <summary>
        /// 退出程序按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarMainBtn22_Click(object sender, EventArgs e)
        {
            if (ToolBar_Main.RunFlag) 
            {
                return;
            }
            formSubHome.Dispose();
            form_Show.Dispose();
            formSubData.Dispose();
            form_MyCpk.Dispose();
            if (formTools != null)
            {
                formTools.AllClose();
                formTools.Dispose();
            }
            //状态栏关闭
            timer1.Enabled = false;
            this.Close();
            this.Dispose();
          
            System.Environment.Exit(0);
        }
        #endregion
        #region 5.窗口事件处理
        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        /// <summary>
        /// 屏幕放大或缩小事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Resize(object sender, EventArgs e)
        {
            toolBar_Main1.PanelWidth = this.Width;
            toolBar_Main1.PanelHeight = this.Height;
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            formSubHome.textBox_Result.Text = formSubHome.showTestResult1.lbl_Result.Text;
            if (Measure.ProMeasureSize.Barcode != null)
            {
                formSubHome.textBox_SN.Text = Measure.ProMeasureSize.Barcode.ToString();
            }
            else
            {
                formSubHome.textBox_SN.Text = "";
            }
        }
        #endregion
    }

}
