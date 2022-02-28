using System;
using System.Drawing;
using System.Windows.Forms;


namespace ToolBars
{
    public partial class ToolBar_Main : UserControl
    {
        string strPath = Application.StartupPath + @"\Resources\ToolBar\";
        private static bool[] bool_userauthority = new bool[4];


        //定义变量类型
        public static bool RunFlag = false;
        public static bool PauseFlag = false;
        public static bool StopFlag = false;


        #region prjName
        private string prjName;
        public string PrjName
        {
            get { return prjName; }
            set { prjName = value; }
        }


        private bool prjEnableChoose;
        public bool PrjEnableChoose
        {
            get { return prjEnableChoose; }
            set { prjEnableChoose = value; }
        }

        #endregion


        #region btns Name
        private string btn01Name;
        public string Btn01Name
        {
            get { return btn01Name; }
            set { btn01Name = value; }
        }
        private string btn02Name;
        public string Btn02Name
        {
            get { return btn02Name; }
            set { btn02Name = value; }
        }
        private string btn03Name;
        public string Btn03Name
        {
            get { return btn03Name; }
            set { btn03Name = value; }
        }
        private string btn04Name;
        public string Btn04Name
        {
            get { return btn04Name; }
            set { btn04Name = value; }
        }
        private string btn05Name;
        public string Btn05Name
        {
            get { return btn05Name; }
            set { btn05Name = value; }
        }
        private string btn11Name;
        public string Btn11Name
        {
            get { return btn11Name; }
            set { btn11Name = value; }
        }
        private string btn12Name;
        public string Btn12Name
        {
            get { return btn12Name; }
            set { btn12Name = value; }
        }
        private string btn13Name;
        public string Btn13Name
        {
            get { return btn13Name; }
            set { btn13Name = value; }
        }
        private string btn21Name;
        public string Btn21Name
        {
            get { return btn21Name; }
            set { btn21Name = value; }
        }
        private string btn22Name;
        public string Btn22Name
        {
            get { return btn22Name; }
            set { btn22Name = value; }
        }
        //增加两个按钮
        private string btnLeftName;
        public string BtnLeftName
        {
            get { return btnLeftName; }
            set { btnLeftName = value; }
        }
        private string btnRightName;
        public string BtnRightName
        {
            get { return btnRightName; }
            set { btnRightName = value; }
        }
        #endregion
        #region btns Enable
        private bool btn01Enable;
        public bool Btn01Enable
        {
            get { return btn01Enable; }
            set { btn01Enable = value; }
        }
        private bool btn02Enable;
        public bool Btn02Enable
        {
            get { return btn02Enable; }
            set { btn02Enable = value; }
        }
        private bool btn03Enable;
        public bool Btn03Enable
        {
            get { return btn03Enable; }
            set { btn03Enable = value; }
        }
        private bool btn04Enable;
        public bool Btn04Enable
        {
            get { return btn04Enable; }
            set { btn04Enable = value; }
        }
        private bool btn05Enable;
        public bool Btn05Enable
        {
            get { return btn05Enable; }
            set { btn05Enable = value; }
        }
        private bool btn11Enable;
        public bool Btn11Enable
        {
            get { return btn11Enable; }
            set { btn11Enable = value; }
        }
        private bool btn12Enable;
        public bool Btn12Enable
        {
            get { return btn12Enable; }
            set { btn12Enable = value; }
        }
        private bool btn13Enable;
        public bool Btn13Enable
        {
            get { return btn13Enable; }
            set { btn13Enable = value; }
        }
        private bool btn21Enable;
        public bool Btn21Enable
        {
            get { return btn21Enable; }
            set { btn21Enable = value; }
        }
        private bool btn22Enable;
        public bool Btn22Enable
        {
            get { return btn22Enable; }
            set { btn22Enable = value; }
        }

        //增加两个按钮
        private bool btnLeftEnable;
        public bool BtnLeftEnable
        {
            get { return btnLeftEnable; }
            set { btnLeftEnable = value; }
        }
        private bool btnRightEnable;
        public bool BtnRightEnable
        {
            get { return btnRightEnable; }
            set { btnRightEnable = value; }
        }
        #endregion






        public void UpdatePrjName(string prjName)
        {
            lbl_PrjName.Text = prjName;
        }

        #region  按钮长宽属性
        private int panelWidth;
        public int PanelWidth
        {
            set
            {
                double buttonW = 13.1744;
                panel01.Width = Convert.ToInt16(value / buttonW);
                panel02.Width = Convert.ToInt16(value / buttonW);
                panel03.Width = Convert.ToInt16(value / buttonW);
                panel04.Width = Convert.ToInt16(value / buttonW);
                panel05.Width = Convert.ToInt16(value / buttonW);
                panel11.Width = Convert.ToInt16(value / buttonW);
                panel12.Width = Convert.ToInt16(value / buttonW);
                panel13.Width = Convert.ToInt16(value / buttonW);
                panel21.Width = Convert.ToInt16(value / buttonW);
                panel22.Width = Convert.ToInt16(value / buttonW);

                panel6.Width = Convert.ToInt16(value / 5.22);
            }

        }
        private int panelHeight;
        public int PanelHeight
        {
            set
            {
                double buttonH = 10.813;
                this.Height = Convert.ToInt16(value / buttonH);
            }
        }
        #endregion



        public ToolBar_Main()
        {
            InitializeComponent();


            IniUtils ini = new IniUtils();
            ini.FileName = "ToolBar_Main.ini";

            btn01Name = ini.ReadInI(ini.FileName, "BtnNames", "btn01Name");
            btn02Name = ini.ReadInI(ini.FileName, "BtnNames", "btn02Name");
            btn03Name = ini.ReadInI(ini.FileName, "BtnNames", "btn03Name");
            btn04Name = ini.ReadInI(ini.FileName, "BtnNames", "btn04Name");
            btn05Name = ini.ReadInI(ini.FileName, "BtnNames", "btn05Name");
            btn11Name = ini.ReadInI(ini.FileName, "BtnNames", "btn11Name");
            btn12Name = ini.ReadInI(ini.FileName, "BtnNames", "btn12Name");
            btn13Name = ini.ReadInI(ini.FileName, "BtnNames", "btn13Name");
            btn21Name = ini.ReadInI(ini.FileName, "BtnNames", "btn21Name");
            btn22Name = ini.ReadInI(ini.FileName, "BtnNames", "btn22Name");

            prjName = ini.ReadInI(ini.FileName, "ProjectName", "PrjName");

            //增加按钮
            btnLeftName = ini.ReadInI(ini.FileName, "BtnNames", "btnLeftName");
            btnRightName = ini.ReadInI(ini.FileName, "BtnNames", "btnRightName");


            btn01Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn01Enable") == "true" ? true : false;
            btn02Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn02Enable") == "true" ? true : false;
            btn03Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn03Enable") == "true" ? true : false;
            btn04Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn04Enable") == "true" ? true : false;
            btn05Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn05Enable") == "true" ? true : false;
            btn11Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn11Enable") == "true" ? true : false;
            btn12Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn12Enable") == "true" ? true : false;
            btn13Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn13Enable") == "true" ? true : false;
            btn21Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn21Enable") == "true" ? true : false;
            btn22Enable = ini.ReadInI(ini.FileName, "BtnEnable", "btn22Enable") == "true" ? true : false;

            //增加按钮
            BtnLeftEnable = ini.ReadInI(ini.FileName, "BtnEnable", "BtnLeftEnable") == "true" ? true : false;
            BtnRightEnable = ini.ReadInI(ini.FileName, "BtnEnable", "BtnRightEnable") == "true" ? true : false;

            bool_userauthority[0] = btn02Enable;
            bool_userauthority[1] = btn03Enable;
            bool_userauthority[2] = btn04Enable;
            bool_userauthority[3] = btn05Enable;


           


            #region    buttons Name Text and background pictures
            btn_01.Name = Btn01Name;
            lbl_01.Text = Btn01Name;
            btn_01.Enabled = Btn01Enable;
            if (Btn01Enable)
                try
                {
                    btn_01.BackgroundImage = Class_Image.LoadImage(strPath + btn_01.Name + ".jpg");
                    
                    btn_01.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_02.Name = Btn02Name;
            lbl_02.Text = Btn02Name;
            btn_02.Enabled = Btn02Enable;
            if (Btn02Enable)
                try
                {
                    btn_02.BackgroundImage = Class_Image.LoadImage(strPath + btn_02.Name + ".jpg");
                    btn_02.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_02.Name = Btn02Name;
            lbl_02.Text = Btn02Name;
            btn_02.Enabled = Btn02Enable;
            if (Btn02Enable)
                try
                {
                    btn_02.BackgroundImage = Class_Image.LoadImage(strPath + btn_02.Name + ".jpg");
                    btn_02.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_03.Name = Btn03Name;
            lbl_03.Text = Btn03Name;
            btn_03.Enabled = Btn03Enable;
            if (Btn03Enable)
                try
                {
                    btn_03.BackgroundImage = Class_Image.LoadImage(strPath + btn_03.Name + ".jpg");
                    btn_03.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_04.Name = Btn04Name;
            lbl_04.Text = Btn04Name;
            btn_04.Enabled = Btn04Enable;
            if (Btn04Enable)
                try
                {
                    btn_04.BackgroundImage = Class_Image.LoadImage(strPath + btn_04.Name + ".jpg");
                    btn_04.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_05.Name = Btn05Name;
            lbl_05.Text = Btn05Name;
            btn_05.Enabled = Btn05Enable;
            if (Btn05Enable)
                try
                {
                    btn_05.BackgroundImage = Class_Image.LoadImage(strPath + btn_05.Name + ".jpg");
                    btn_05.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_11.Name = Btn11Name;
            lbl_11.Text = Btn11Name;
            btn_11.Enabled = Btn11Enable;
            if (Btn11Enable)
                try
                {
                    btn_11.BackgroundImage = Class_Image.LoadImage(strPath + btn_11.Name + ".jpg");
                    btn_11.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_12.Name = Btn12Name;
            lbl_12.Text = Btn12Name;
            btn_12.Enabled = Btn12Enable;
            if (Btn12Enable)
                try
                {
                    btn_12.BackgroundImage = Class_Image.LoadImage(strPath + btn_12.Name + ".jpg");
                    btn_12.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_13.Name = Btn13Name;
            lbl_13.Text = Btn13Name;
            btn_13.Enabled = Btn13Enable;
            if (Btn13Enable)
                try
                {
                    btn_13.BackgroundImage = Class_Image.LoadImage(strPath + btn_13.Name + ".jpg");
                    btn_13.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_21.Name = Btn21Name;
            lbl_21.Text = Btn21Name;
            btn_21.Enabled = Btn21Enable;
            if (Btn21Enable)
                try
                {
                    btn_21.BackgroundImage = Class_Image.LoadImage(strPath + btn_21.Name + ".jpg");
                    btn_21.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            btn_22.Name = Btn22Name;
            lbl_22.Text = Btn22Name;
            btn_22.Enabled = Btn22Enable;
            if (Btn22Enable)
                try
                {
                    btn_22.BackgroundImage = Class_Image.LoadImage(strPath + btn_22.Name + ".jpg");
                    btn_22.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            //增加两个按钮
            button_left.Name = btnLeftName;
            if (BtnLeftEnable)
                try
                {
                    //button_left.BackgroundImage = Image.FromFile(strPath + button_left.Name + ".jpg");
                    //button_left.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            button_right.Name = btnRightName;
            if (BtnRightEnable)
                try
                {
                    //button_right.BackgroundImage = Image.FromFile(strPath + button_right.Name + ".jpg");
                    //button_right.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                }

            #endregion


            #region   button_MouseLeave & MouseEnter     EventHandler
            this.btn_01.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_01.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_02.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_02.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_03.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_03.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_04.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_04.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_05.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_05.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            //this.button6.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            //this.button6.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_11.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_11.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_12.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_12.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_13.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_13.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            //this.button10.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            //this.button10.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_22.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_22.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.btn_21.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_21.MouseLeave += new System.EventHandler(this.button_MouseLeave);


            //增加两个按钮
            this.button_left.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_left.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_right.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_right.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            #endregion

            panel_Right.Width = 0;
            panel_left.Width = 20;

            Class_Action.ToolBar_Refresh += FANC_ControlButton_Status;
        }

        #region   button_MouseLeave & MouseEnter     EventHandler
        private void button_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Green;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            if((((Button)sender).Name == "Right")|| (((Button)sender).Name == "Left"))
                ((Button)sender).BackColor = Color.DeepSkyBlue;
            else
                ((Button)sender).BackColor = Color.Gainsboro;
        }
        #endregion



        //定义委托
        public delegate void Btn01ClickHandle(object sender, EventArgs e);
        public delegate void Btn02ClickHandle(object sender, EventArgs e);
        public delegate void Btn03ClickHandle(object sender, EventArgs e);
        public delegate void Btn04ClickHandle(object sender, EventArgs e);
        public delegate void Btn05ClickHandle(object sender, EventArgs e);
        public delegate void Btn11ClickHandle(object sender, EventArgs e);
        public delegate void Btn12ClickHandle(object sender, EventArgs e);
        public delegate void Btn13ClickHandle(object sender, EventArgs e);
        public delegate void Btn21ClickHandle(object sender, EventArgs e);
        public delegate void Btn22ClickHandle(object sender, EventArgs e);
        public delegate void Lbl_PrjNameDoubleClickHandle(object sender, EventArgs e);

        //增加两个按钮
        public delegate void button_leftClickHandle(object sender, EventArgs e);
        public delegate void button_rightClickHandle(object sender, EventArgs e);

        //定义事件
        public event Btn01ClickHandle ToolBarMain_Btn01_Click;
        public event Btn02ClickHandle ToolBarMain_Btn02_Click;
        public event Btn03ClickHandle ToolBarMain_Btn03_Click;
        public event Btn04ClickHandle ToolBarMain_Btn04_Click;
        public event Btn05ClickHandle ToolBarMain_Btn05_Click;
        public event Btn11ClickHandle ToolBarMain_Btn11_Click;
        public event Btn12ClickHandle ToolBarMain_Btn12_Click;
        public event Btn13ClickHandle ToolBarMain_Btn13_Click;
        public event Btn21ClickHandle ToolBarMain_Btn21_Click;
        public event Btn22ClickHandle ToolBarMain_Btn22_Click;
        public event Lbl_PrjNameDoubleClickHandle ToolBarMain_Lbl_PrjName_DoubleClick;

        //增加两个按钮
        public event button_leftClickHandle ToolBarMain_button_left_Click;
        public event button_rightClickHandle ToolBarMain_button_right_Click;




        ////定义委托
        //public delegate void BtnClickHandle(object sender, EventArgs e);
        ////定义事件
        //public event BtnClickHandle ToolBarMainBtnClicked;
        //private void btn_Click(object sender, EventArgs e)
        //{
        //    if (ToolBarMainBtnClicked != null)
        //    {
        //        ToolBarMainBtnClicked(sender, new EventArgs());
        //    }
        //}

        private void btn_01_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn01_Click != null)
            {
                ToolBarMain_Btn01_Click(sender, new EventArgs());
            }
        }

        private void btn_02_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn02_Click != null)
            {
                ToolBarMain_Btn02_Click(sender, new EventArgs());
            }
        }

        private void btn_03_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn03_Click != null)
            {
                ToolBarMain_Btn03_Click(sender, new EventArgs());
            }
        }

        private void btn_04_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn04_Click != null)
            {
                ToolBarMain_Btn04_Click(sender, new EventArgs());
            }
        }

        private void btn_05_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn05_Click != null)
            {
                ToolBarMain_Btn05_Click(sender, new EventArgs());
            }
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn11_Click != null)
            {
                ToolBarMain_Btn11_Click(sender, new EventArgs());
            }
        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn12_Click != null)
            {
                ToolBarMain_Btn12_Click(sender, new EventArgs());
            }
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn13_Click != null)
            {
                ToolBarMain_Btn13_Click(sender, new EventArgs());
            }
        }

        private void btn_21_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn21_Click != null)
            {
                ToolBarMain_Btn21_Click(sender, new EventArgs());
            }
        }

        private void btn_22_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_Btn22_Click != null)
            {
                ToolBarMain_Btn22_Click(sender, new EventArgs());
            }
        }

        private void lbl_PrjName_DoubleClick(object sender, EventArgs e)
        {
            if (ToolBarMain_Lbl_PrjName_DoubleClick != null)
            {
                ToolBarMain_Lbl_PrjName_DoubleClick(sender, new EventArgs());
            }
        }


        private void btn_left_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_button_left_Click != null)
            {
                ToolBarMain_button_left_Click(sender, new EventArgs());

                btn_01.Enabled = false;
                btn_02.Enabled = false;
                btn_03.Enabled = false;
                btn_04.Enabled = false;
                btn_05.Enabled = false;
                lbl_PrjName.Enabled = false;
                btn_11.Enabled = false;
                btn_12.Enabled = false;
                btn_13.Enabled = false;
                btn_21.Enabled = false;
                btn_22.Enabled = false;
                button_left.Enabled = false;
                button_right.Enabled = true;

                panel_left.Width = 0;
                panel_Right.Width = 20;
            }
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            if (ToolBarMain_button_right_Click != null)
            {
                ToolBarMain_button_right_Click(sender, new EventArgs());
                panel_Right.Width = 0;
                panel_left.Width = 20;
            }
        }

        public string ProcessLoad = "Loaded";
        public string ProcessLogin = "Logined";
        public string ProcessPrjChoose = "PrjChoosed";


        public void FANC_BtnsEnableClick(string process,string userAuthority)
        {
            if (process == "Loaded")
            {
                btn_01.Enabled = false;
                btn_02.Enabled = false;
                btn_03.Enabled = false;
                btn_04.Enabled = false;
                btn_05.Enabled = false;
                lbl_PrjName.Enabled = false;
                btn_11.Enabled = false;
                btn_12.Enabled = false;
                btn_13.Enabled = false;
                btn_21.Enabled = true;
                btn_22.Enabled = true;
                button_left.Enabled = false;
                button_right.Enabled = false;
            }

            if (process == "Logined")
            {
                btn_01.Enabled = false;
                btn_02.Enabled = false;
                btn_03.Enabled = false;
                btn_04.Enabled = false;
                btn_05.Enabled = false;
                lbl_PrjName.Enabled = true;
                btn_11.Enabled = false;
                btn_12.Enabled = false;
                btn_13.Enabled = false;
                btn_21.Enabled = true;
                btn_22.Enabled = true;
                button_left.Enabled = false;
                button_right.Enabled = false;
            }

            if (process == "PrjChoosed")
            {
                btn_01.Enabled = true;
                
                string[] str_authority = userAuthority.Split(',');
                bool[] bool_authority = new bool[4];
                try
                {
                    bool_authority[0] = str_authority[1] == "1" ? true : false;
                    bool_authority[1] = str_authority[2] == "1" ? true : false;
                    bool_authority[2] = str_authority[3] == "1" ? true : false;
                    bool_authority[3] = str_authority[4] == "1" ? true : false;
                }
                catch
                {

                }

                btn_02.Enabled = bool_userauthority[0] && bool_authority[0];
                btn_03.Enabled = bool_userauthority[1] && bool_authority[1];
                btn_04.Enabled = bool_userauthority[2] && bool_authority[2];
                btn_05.Enabled = bool_userauthority[3] && bool_authority[3];

                if ((str_authority[0].ToUpper() == "ROOT") || (str_authority[0].ToUpper() == "ADMIN"))
                    lbl_PrjName.Enabled = true;
                else
                    lbl_PrjName.Enabled = false;

                btn_11.Enabled = true;
                btn_12.Enabled = true;
                btn_13.Enabled = true;
                btn_21.Enabled = true;
                btn_22.Enabled = true;
                button_left.Enabled = true;
                button_right.Enabled = true;

            }

        }


        /// <summary>
        /// 控制按钮状态改变
        /// </summary>
        /// <param name="Status">Start,Pause,Stop,Ini</param>
        /// 
        public void FANC_ControlButton_Status(string Status)
        {
            switch (Status)
            {
                case "Start":
                    this.Invoke(new Action(() =>
                    {
                       
                        //按钮背景控制
                        btn_11.BackgroundImage = Class_Image.LoadImage(strPath  + "b_start.jpg");
                        btn_12.BackgroundImage = Class_Image.LoadImage(strPath  + "pause.jpg"); 
                        btn_13.BackgroundImage = Class_Image.LoadImage(strPath  + "stop.jpg"); 
                        //按钮控制
                        btn_11.Enabled = false;
                        btn_12.Enabled = true;
                        btn_13.Enabled = true;

                    }));

                    RunFlag = true;
                    PauseFlag = false;
                    StopFlag = false;

                    Class_Action.LampRefresh("Normal");

                  
                    break;

                case "Pause":
                    this.Invoke(new Action(() =>
                    {
                        //按钮背景控制
                        btn_11.BackgroundImage = Class_Image.LoadImage(strPath  + "start.jpg"); 
                        btn_12.BackgroundImage = Class_Image.LoadImage(strPath  + "b_pause.jpg"); 
                        btn_13.BackgroundImage = Class_Image.LoadImage(strPath  + "stop.jpg");
                        //按钮控制
                        btn_11.Enabled = true;
                        btn_12.Enabled = false;
                        btn_13.Enabled = true;

                    }));
                    RunFlag = true;
                    PauseFlag = true;
                    StopFlag = false;
                    Class_Action.LampRefresh("Alarm");

                    break;

                case "Stop":
                    this.Invoke(new Action(() =>
                    {
                        //按钮背景控制
                        btn_11.BackgroundImage = Class_Image.LoadImage(strPath + "start.jpg"); 
                        btn_12.BackgroundImage = Class_Image.LoadImage(strPath  + "pause.jpg"); 
                        btn_13.BackgroundImage = Class_Image.LoadImage(strPath  + "b_stop.jpg"); 
                        //按钮控制
                        btn_11.Enabled = true;
                        btn_12.Enabled = false;
                        btn_13.Enabled = false;

                    }));
                    Class_Action.LampRefresh("Standby");


                    RunFlag = false;
                    PauseFlag = false;
                    StopFlag = true;

                 
                    break;

                case "Ini":
                    this.Invoke(new Action(() =>
                    {
                        //按钮背景控制
                        btn_11.BackgroundImage = Class_Image.LoadImage(strPath  + "start.jpg"); 
                        btn_12.BackgroundImage = Class_Image.LoadImage(strPath  + "pause.jpg"); 
                        btn_13.BackgroundImage = Class_Image.LoadImage(strPath  + "stop.jpg"); 
                        btn_11.Enabled = true;
                        btn_12.Enabled = false;
                        btn_13.Enabled = false;

                    }));
                    RunFlag = false;
                    PauseFlag = false;
                    StopFlag = false;

                  
                    break;

                default:
                    this.Invoke(new Action(() =>
                    {
                        //按钮背景控制
                        btn_11.BackgroundImage = Class_Image.LoadImage(strPath  + "start.jpg"); 
                        btn_12.BackgroundImage = Class_Image.LoadImage(strPath + "pause.jpg");
                        btn_13.BackgroundImage = Class_Image.LoadImage(strPath  + "stop.jpg"); 
                        //按钮控制
                        btn_11.Enabled = true;
                        btn_12.Enabled = false;
                        btn_13.Enabled = false;

                    }));
                    RunFlag = false;
                    PauseFlag = false;
                    StopFlag = false;


                    break;

            }
        }

    }
}
