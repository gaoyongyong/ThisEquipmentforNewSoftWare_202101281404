namespace Tools
{
    partial class Form_Tools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Tools));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Value = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_StopAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_CirclePause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_CircleStart = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelParamater = new System.Windows.Forms.Panel();
            this.ManualPanel = new System.Windows.Forms.Panel();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.属性设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel_Log = new System.Windows.Forms.Panel();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.设备状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panelProcess = new System.Windows.Forms.Panel();
            this.panel_Process = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelTools = new System.Windows.Forms.Panel();
            this.panel_Tool = new System.Windows.Forms.Panel();
            this.listViewCollapseTools = new Tools.ListViewCollapse();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listViewCollapseFlowChat = new Tools.ListViewCollapse();
            this.imageListFlowChat = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddFlowChat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDeleteFlowChat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCreateFunction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSettingFlowchat = new System.Windows.Forms.ToolStripButton();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.工具栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListProcess = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.toolStrip_main.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelParamater.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.panelProcess.SuspendLayout();
            this.panelTools.SuspendLayout();
            this.panel_Tool.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.toolStrip_main);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1314, 47);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.AutoSize = false;
            this.toolStrip_main.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip_main.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripSeparator1,
            this.toolStripButton_Value,
            this.toolStripButton_StopAll,
            this.toolStripButton_CirclePause,
            this.toolStripButton_CircleStart});
            this.toolStrip_main.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.Size = new System.Drawing.Size(1314, 49);
            this.toolStrip_main.Stretch = true;
            this.toolStrip_main.TabIndex = 17;
            this.toolStrip_main.Text = "toolStrip1";
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.AutoSize = false;
            this.toolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Save.Image")));
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton_Save.Text = "创建流程";
            this.toolStripButton_Save.ToolTipText = "保存流程";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 49);
            // 
            // toolStripButton_Value
            // 
            this.toolStripButton_Value.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Value.Image = global::ThisEquipment.Properties.Resources.字符;
            this.toolStripButton_Value.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Value.Name = "toolStripButton_Value";
            this.toolStripButton_Value.Size = new System.Drawing.Size(42, 46);
            this.toolStripButton_Value.Text = "全局变量";
            this.toolStripButton_Value.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton_StopAll
            // 
            this.toolStripButton_StopAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_StopAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_StopAll.Image = global::ThisEquipment.Properties.Resources.b_stop;
            this.toolStripButton_StopAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_StopAll.Name = "toolStripButton_StopAll";
            this.toolStripButton_StopAll.Size = new System.Drawing.Size(42, 46);
            this.toolStripButton_StopAll.Text = "toolStripButton_StopAll";
            this.toolStripButton_StopAll.Click += new System.EventHandler(this.toolStripButton_StopAll_Click);
            // 
            // toolStripButton_CirclePause
            // 
            this.toolStripButton_CirclePause.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_CirclePause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_CirclePause.Image = global::ThisEquipment.Properties.Resources.b_pause;
            this.toolStripButton_CirclePause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CirclePause.Name = "toolStripButton_CirclePause";
            this.toolStripButton_CirclePause.Size = new System.Drawing.Size(42, 46);
            this.toolStripButton_CirclePause.Text = "toolStripButton_CirclePause";
            this.toolStripButton_CirclePause.Click += new System.EventHandler(this.toolStripButton_CircleStart_Pause);
            // 
            // toolStripButton_CircleStart
            // 
            this.toolStripButton_CircleStart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_CircleStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_CircleStart.Image = global::ThisEquipment.Properties.Resources.循环;
            this.toolStripButton_CircleStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CircleStart.Name = "toolStripButton_CircleStart";
            this.toolStripButton_CircleStart.Size = new System.Drawing.Size(42, 46);
            this.toolStripButton_CircleStart.Text = "toolStripButton_CircleStart";
            this.toolStripButton_CircleStart.Click += new System.EventHandler(this.toolStripButton_Start_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelParamater);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.panelProcess);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panelTools);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1314, 669);
            this.panel2.TabIndex = 1;
            // 
            // panelParamater
            // 
            this.panelParamater.Controls.Add(this.ManualPanel);
            this.panelParamater.Controls.Add(this.menuStrip3);
            this.panelParamater.Controls.Add(this.splitter5);
            this.panelParamater.Controls.Add(this.splitter4);
            this.panelParamater.Controls.Add(this.panel5);
            this.panelParamater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParamater.Location = new System.Drawing.Point(550, 0);
            this.panelParamater.Margin = new System.Windows.Forms.Padding(2);
            this.panelParamater.Name = "panelParamater";
            this.panelParamater.Size = new System.Drawing.Size(764, 669);
            this.panelParamater.TabIndex = 4;
            // 
            // ManualPanel
            // 
            this.ManualPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManualPanel.Location = new System.Drawing.Point(1, 25);
            this.ManualPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ManualPanel.Name = "ManualPanel";
            this.ManualPanel.Size = new System.Drawing.Size(763, 498);
            this.ManualPanel.TabIndex = 4;
            // 
            // menuStrip3
            // 
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性设置ToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(1, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip3.Size = new System.Drawing.Size(763, 25);
            this.menuStrip3.TabIndex = 7;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // 属性设置ToolStripMenuItem
            // 
            this.属性设置ToolStripMenuItem.Name = "属性设置ToolStripMenuItem";
            this.属性设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.属性设置ToolStripMenuItem.Text = "手动界面";
            // 
            // splitter5
            // 
            this.splitter5.Location = new System.Drawing.Point(0, 0);
            this.splitter5.Margin = new System.Windows.Forms.Padding(2);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(1, 523);
            this.splitter5.TabIndex = 5;
            this.splitter5.TabStop = false;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 523);
            this.splitter4.Margin = new System.Windows.Forms.Padding(2);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(764, 1);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel_Log);
            this.panel5.Controls.Add(this.menuStrip5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 524);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(764, 145);
            this.panel5.TabIndex = 0;
            // 
            // panel_Log
            // 
            this.panel_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Log.Location = new System.Drawing.Point(0, 25);
            this.panel_Log.Name = "panel_Log";
            this.panel_Log.Size = new System.Drawing.Size(764, 120);
            this.panel_Log.TabIndex = 4;
            // 
            // menuStrip5
            // 
            this.menuStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备状态ToolStripMenuItem});
            this.menuStrip5.Location = new System.Drawing.Point(0, 0);
            this.menuStrip5.Name = "menuStrip5";
            this.menuStrip5.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip5.Size = new System.Drawing.Size(764, 25);
            this.menuStrip5.TabIndex = 3;
            this.menuStrip5.Text = "menuStrip5";
            // 
            // 设备状态ToolStripMenuItem
            // 
            this.设备状态ToolStripMenuItem.Name = "设备状态ToolStripMenuItem";
            this.设备状态ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.设备状态ToolStripMenuItem.Text = "设备状态";
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(549, 0);
            this.splitter2.Margin = new System.Windows.Forms.Padding(2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1, 669);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panelProcess
            // 
            this.panelProcess.Controls.Add(this.panel_Process);
            this.panelProcess.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelProcess.Location = new System.Drawing.Point(257, 0);
            this.panelProcess.Margin = new System.Windows.Forms.Padding(2);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(292, 669);
            this.panelProcess.TabIndex = 2;
            // 
            // panel_Process
            // 
            this.panel_Process.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Process.Location = new System.Drawing.Point(0, 0);
            this.panel_Process.Name = "panel_Process";
            this.panel_Process.Size = new System.Drawing.Size(292, 669);
            this.panel_Process.TabIndex = 20;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(256, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 669);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panelTools
            // 
            this.panelTools.Controls.Add(this.panel_Tool);
            this.panelTools.Controls.Add(this.splitter3);
            this.panelTools.Controls.Add(this.panel3);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Margin = new System.Windows.Forms.Padding(2);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(256, 669);
            this.panelTools.TabIndex = 0;
            // 
            // panel_Tool
            // 
            this.panel_Tool.Controls.Add(this.listViewCollapseTools);
            this.panel_Tool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Tool.Location = new System.Drawing.Point(0, 350);
            this.panel_Tool.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Tool.Name = "panel_Tool";
            this.panel_Tool.Size = new System.Drawing.Size(256, 319);
            this.panel_Tool.TabIndex = 5;
            // 
            // listViewCollapseTools
            // 
            this.listViewCollapseTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCollapseTools.Location = new System.Drawing.Point(0, 0);
            this.listViewCollapseTools.Name = "listViewCollapseTools";
            this.listViewCollapseTools.Size = new System.Drawing.Size(256, 319);
            this.listViewCollapseTools.TabIndex = 0;
            this.listViewCollapseTools.UseCompatibleStateImageBehavior = false;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 349);
            this.splitter3.Margin = new System.Windows.Forms.Padding(2);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(256, 1);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listViewCollapseFlowChat);
            this.panel3.Controls.Add(this.toolStrip2);
            this.panel3.Controls.Add(this.menuStrip2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 349);
            this.panel3.TabIndex = 3;
            // 
            // listViewCollapseFlowChat
            // 
            this.listViewCollapseFlowChat.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewCollapseFlowChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCollapseFlowChat.GridLines = true;
            this.listViewCollapseFlowChat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewCollapseFlowChat.Location = new System.Drawing.Point(0, 66);
            this.listViewCollapseFlowChat.Margin = new System.Windows.Forms.Padding(2);
            this.listViewCollapseFlowChat.MultiSelect = false;
            this.listViewCollapseFlowChat.Name = "listViewCollapseFlowChat";
            this.listViewCollapseFlowChat.Size = new System.Drawing.Size(256, 283);
            this.listViewCollapseFlowChat.SmallImageList = this.imageListFlowChat;
            this.listViewCollapseFlowChat.TabIndex = 17;
            this.listViewCollapseFlowChat.UseCompatibleStateImageBehavior = false;
            this.listViewCollapseFlowChat.SelectedIndexChanged += new System.EventHandler(this.listViewCollapseFlowChat_SelectedIndexChanged);
            // 
            // imageListFlowChat
            // 
            this.imageListFlowChat.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFlowChat.ImageStream")));
            this.imageListFlowChat.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFlowChat.Images.SetKeyName(0, "6.PNG");
            this.imageListFlowChat.Images.SetKeyName(1, "a_X.PNG");
            this.imageListFlowChat.Images.SetKeyName(2, "a_Y.PNG");
            this.imageListFlowChat.Images.SetKeyName(3, "5.PNG");
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddFlowChat,
            this.toolStripSeparator5,
            this.toolStripButtonDeleteFlowChat,
            this.toolStripSeparator2,
            this.toolStripButtonCreateFunction,
            this.toolStripSeparator4,
            this.toolStripButtonSettingFlowchat});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(256, 41);
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 16;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonAddFlowChat
            // 
            this.toolStripButtonAddFlowChat.AutoSize = false;
            this.toolStripButtonAddFlowChat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddFlowChat.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddFlowChat.Image")));
            this.toolStripButtonAddFlowChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddFlowChat.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonAddFlowChat.Name = "toolStripButtonAddFlowChat";
            this.toolStripButtonAddFlowChat.Size = new System.Drawing.Size(40, 40);
            this.toolStripButtonAddFlowChat.Text = "创建流程";
            this.toolStripButtonAddFlowChat.Click += new System.EventHandler(this.toolStripButtonAddFlowChat_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButtonDeleteFlowChat
            // 
            this.toolStripButtonDeleteFlowChat.AutoSize = false;
            this.toolStripButtonDeleteFlowChat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteFlowChat.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteFlowChat.Image")));
            this.toolStripButtonDeleteFlowChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteFlowChat.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonDeleteFlowChat.Name = "toolStripButtonDeleteFlowChat";
            this.toolStripButtonDeleteFlowChat.Size = new System.Drawing.Size(40, 40);
            this.toolStripButtonDeleteFlowChat.Text = "删除流程";
            this.toolStripButtonDeleteFlowChat.Click += new System.EventHandler(this.toolStripButtonDeleteFlowChat_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButtonCreateFunction
            // 
            this.toolStripButtonCreateFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCreateFunction.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCreateFunction.Image")));
            this.toolStripButtonCreateFunction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreateFunction.Name = "toolStripButtonCreateFunction";
            this.toolStripButtonCreateFunction.Size = new System.Drawing.Size(42, 38);
            this.toolStripButtonCreateFunction.Text = "创建方法流程";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButtonSettingFlowchat
            // 
            this.toolStripButtonSettingFlowchat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSettingFlowchat.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSettingFlowchat.Image")));
            this.toolStripButtonSettingFlowchat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettingFlowchat.Name = "toolStripButtonSettingFlowchat";
            this.toolStripButtonSettingFlowchat.Size = new System.Drawing.Size(42, 38);
            this.toolStripButtonSettingFlowchat.Text = "设置流程";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具栏ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(256, 25);
            this.menuStrip2.TabIndex = 18;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 工具栏ToolStripMenuItem
            // 
            this.工具栏ToolStripMenuItem.Name = "工具栏ToolStripMenuItem";
            this.工具栏ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.工具栏ToolStripMenuItem.Text = "工具栏";
            // 
            // imageListProcess
            // 
            this.imageListProcess.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListProcess.ImageStream")));
            this.imageListProcess.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListProcess.Images.SetKeyName(0, "1.ico");
            this.imageListProcess.Images.SetKeyName(1, "2.ico");
            this.imageListProcess.Images.SetKeyName(2, "3.ico");
            this.imageListProcess.Images.SetKeyName(3, "4.ico");
            this.imageListProcess.Images.SetKeyName(4, "5.ico");
            this.imageListProcess.Images.SetKeyName(5, "6.ico");
            this.imageListProcess.Images.SetKeyName(6, "7.png");
            this.imageListProcess.Images.SetKeyName(7, "a_alarm.PNG");
            this.imageListProcess.Images.SetKeyName(8, "a_ccd.PNG");
            this.imageListProcess.Images.SetKeyName(9, "a_home.PNG");
            this.imageListProcess.Images.SetKeyName(10, "a_pause.PNG");
            this.imageListProcess.Images.SetKeyName(11, "a_R.PNG");
            this.imageListProcess.Images.SetKeyName(12, "a_setup.PNG");
            this.imageListProcess.Images.SetKeyName(13, "a_start.PNG");
            this.imageListProcess.Images.SetKeyName(14, "a_stop.PNG");
            this.imageListProcess.Images.SetKeyName(15, "a_user.PNG");
            this.imageListProcess.Images.SetKeyName(16, "a_wave.PNG");
            this.imageListProcess.Images.SetKeyName(17, "a_X.PNG");
            this.imageListProcess.Images.SetKeyName(18, "a_Y.PNG");
            this.imageListProcess.Images.SetKeyName(19, "alarm2.PNG");
            this.imageListProcess.Images.SetKeyName(20, "b_alarm.PNG");
            this.imageListProcess.Images.SetKeyName(21, "b_F.PNG");
            this.imageListProcess.Images.SetKeyName(22, "b_home.PNG");
            this.imageListProcess.Images.SetKeyName(23, "b_pause.PNG");
            this.imageListProcess.Images.SetKeyName(24, "b_start.PNG");
            this.imageListProcess.Images.SetKeyName(25, "b_stop.PNG");
            this.imageListProcess.Images.SetKeyName(26, "b_user.PNG");
            this.imageListProcess.Images.SetKeyName(27, "b_wave.PNG");
            this.imageListProcess.Images.SetKeyName(28, "b_X.PNG");
            this.imageListProcess.Images.SetKeyName(29, "b_Y.PNG");
            this.imageListProcess.Images.SetKeyName(30, "DATA.jpg");
            this.imageListProcess.Images.SetKeyName(31, "Demo.ico");
            this.imageListProcess.Images.SetKeyName(32, "Excel.PNG");
            this.imageListProcess.Images.SetKeyName(33, "Image Mode.jpg");
            this.imageListProcess.Images.SetKeyName(34, "image004.jpg");
            this.imageListProcess.Images.SetKeyName(35, "MAIN.jpg");
            this.imageListProcess.Images.SetKeyName(36, "MaxMin.jpg");
            this.imageListProcess.Images.SetKeyName(37, "PARAMETER.jpg");
            this.imageListProcess.Images.SetKeyName(38, "pause.jpg");
            this.imageListProcess.Images.SetKeyName(39, "pic.PNG");
            this.imageListProcess.Images.SetKeyName(40, "start.jpg");
            this.imageListProcess.Images.SetKeyName(41, "stop.jpg");
            this.imageListProcess.Images.SetKeyName(42, "USER.jpg");
            this.imageListProcess.Images.SetKeyName(43, "VISION.jpg");
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 716);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Tools";
            this.Text = "FormTOOLS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Tools_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTOOLS_FormClosed);
            this.panel1.ResumeLayout(false);
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelParamater.ResumeLayout(false);
            this.panelParamater.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.menuStrip5.ResumeLayout(false);
            this.menuStrip5.PerformLayout();
            this.panelProcess.ResumeLayout(false);
            this.panelTools.ResumeLayout(false);
            this.panel_Tool.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelParamater;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panelProcess;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Panel panel_Tool;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageListFlowChat;
        private System.Windows.Forms.ImageList imageListProcess;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.Panel ManualPanel;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFlowChat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteFlowChat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreateFunction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettingFlowchat;
        private System.Windows.Forms.MenuStrip menuStrip5;
        private System.Windows.Forms.ToolStripMenuItem 设备状态ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 工具栏ToolStripMenuItem;
        private ListViewCollapse listViewCollapseTools;
        private System.Windows.Forms.Panel panel_Process;
        private System.Windows.Forms.ToolStrip toolStrip_main;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripButton toolStripButton_Value;
        private System.Windows.Forms.Panel panel_Log;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem 属性设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_StopAll;
        private System.Windows.Forms.ToolStripButton toolStripButton_CirclePause;
        private System.Windows.Forms.ToolStripButton toolStripButton_CircleStart;
        private System.Windows.Forms.Timer timer1;
        public ListViewCollapse listViewCollapseFlowChat;
    }
}