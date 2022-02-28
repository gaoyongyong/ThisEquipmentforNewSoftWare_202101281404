namespace Tools
{
    partial class Form_Process
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Process));
            this.imageListProcess = new System.Windows.Forms.ImageList(this.components);
            this.toolstrip_Process = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Toolstrip_START = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_CircleStart = new System.Windows.Forms.ToolStripButton();
            this.Toolstrip_SUSPEND = new System.Windows.Forms.ToolStripButton();
            this.Toolstrip_STOP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Toolstrip_Single = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.过程设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lv1 = new Tools.ListViewCollapse();
            this.toolstrip_Process.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // toolstrip_Process
            // 
            this.toolstrip_Process.AutoSize = false;
            this.toolstrip_Process.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolstrip_Process.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolstrip_Process.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolstrip_Process.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonUp,
            this.toolStripButtonDown,
            this.toolStripButtonDelete});
            this.toolstrip_Process.Location = new System.Drawing.Point(0, 648);
            this.toolstrip_Process.Name = "toolstrip_Process";
            this.toolstrip_Process.Size = new System.Drawing.Size(306, 41);
            this.toolstrip_Process.Stretch = true;
            this.toolstrip_Process.TabIndex = 17;
            this.toolstrip_Process.Text = "toolStrip2";
            // 
            // toolStripButtonUp
            // 
            this.toolStripButtonUp.AutoSize = false;
            this.toolStripButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUp.Image = global::ThisEquipment.Properties.Resources.up;
            this.toolStripButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUp.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonUp.Name = "toolStripButtonUp";
            this.toolStripButtonUp.Size = new System.Drawing.Size(40, 40);
            this.toolStripButtonUp.Text = "up";
            // 
            // toolStripButtonDown
            // 
            this.toolStripButtonDown.AutoSize = false;
            this.toolStripButtonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDown.Image = global::ThisEquipment.Properties.Resources.down;
            this.toolStripButtonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDown.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonDown.Name = "toolStripButtonDown";
            this.toolStripButtonDown.Size = new System.Drawing.Size(40, 40);
            this.toolStripButtonDown.Text = "down";
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.AutoSize = false;
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::ThisEquipment.Properties.Resources.cross;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(40, 40);
            this.toolStripButtonDelete.Text = "delete";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Toolstrip_START,
            this.toolStripButton_CircleStart,
            this.Toolstrip_SUSPEND,
            this.Toolstrip_STOP,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.Toolstrip_Single,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(306, 41);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // Toolstrip_START
            // 
            this.Toolstrip_START.AutoSize = false;
            this.Toolstrip_START.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Toolstrip_START.Image = ((System.Drawing.Image)(resources.GetObject("Toolstrip_START.Image")));
            this.Toolstrip_START.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Toolstrip_START.Margin = new System.Windows.Forms.Padding(1);
            this.Toolstrip_START.Name = "Toolstrip_START";
            this.Toolstrip_START.Size = new System.Drawing.Size(40, 40);
            this.Toolstrip_START.Text = "Start";
            this.Toolstrip_START.ToolTipText = "启动";
            this.Toolstrip_START.Click += new System.EventHandler(this.Toolstrip_START_Click);
            // 
            // toolStripButton_CircleStart
            // 
            this.toolStripButton_CircleStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_CircleStart.Image = global::ThisEquipment.Properties.Resources.WhileTool;
            this.toolStripButton_CircleStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CircleStart.Name = "toolStripButton_CircleStart";
            this.toolStripButton_CircleStart.Size = new System.Drawing.Size(42, 38);
            this.toolStripButton_CircleStart.Text = "toolStripButton_CircleStart";
            this.toolStripButton_CircleStart.ToolTipText = "循环启动";
            this.toolStripButton_CircleStart.Click += new System.EventHandler(this.toolStripButton_CircleStart_Click);
            // 
            // Toolstrip_SUSPEND
            // 
            this.Toolstrip_SUSPEND.AutoSize = false;
            this.Toolstrip_SUSPEND.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Toolstrip_SUSPEND.Image = ((System.Drawing.Image)(resources.GetObject("Toolstrip_SUSPEND.Image")));
            this.Toolstrip_SUSPEND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Toolstrip_SUSPEND.Margin = new System.Windows.Forms.Padding(1);
            this.Toolstrip_SUSPEND.Name = "Toolstrip_SUSPEND";
            this.Toolstrip_SUSPEND.Size = new System.Drawing.Size(40, 40);
            this.Toolstrip_SUSPEND.Text = "Suspend";
            this.Toolstrip_SUSPEND.ToolTipText = "暂停";
            this.Toolstrip_SUSPEND.Click += new System.EventHandler(this.Toolstrip_SUSPEND_Click);
            // 
            // Toolstrip_STOP
            // 
            this.Toolstrip_STOP.AutoSize = false;
            this.Toolstrip_STOP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Toolstrip_STOP.Image = ((System.Drawing.Image)(resources.GetObject("Toolstrip_STOP.Image")));
            this.Toolstrip_STOP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Toolstrip_STOP.Margin = new System.Windows.Forms.Padding(1);
            this.Toolstrip_STOP.Name = "Toolstrip_STOP";
            this.Toolstrip_STOP.Size = new System.Drawing.Size(40, 40);
            this.Toolstrip_STOP.Text = "Stop";
            this.Toolstrip_STOP.ToolTipText = "停止";
            this.Toolstrip_STOP.Click += new System.EventHandler(this.Toolstrip_STOP_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 38);
            this.toolStripLabel1.Text = "流程0";
            // 
            // Toolstrip_Single
            // 
            this.Toolstrip_Single.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Toolstrip_Single.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Toolstrip_Single.Image = ((System.Drawing.Image)(resources.GetObject("Toolstrip_Single.Image")));
            this.Toolstrip_Single.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Toolstrip_Single.Name = "Toolstrip_Single";
            this.Toolstrip_Single.Size = new System.Drawing.Size(42, 38);
            this.Toolstrip_Single.Text = "Step";
            this.Toolstrip_Single.Click += new System.EventHandler(this.Toolstrip_Single_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.过程设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(306, 25);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 过程设置ToolStripMenuItem
            // 
            this.过程设置ToolStripMenuItem.Name = "过程设置ToolStripMenuItem";
            this.过程设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.过程设置ToolStripMenuItem.Text = "过程设置";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lv1
            // 
            this.lv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv1.LargeImageList = this.imageListProcess;
            this.lv1.Location = new System.Drawing.Point(0, 66);
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(306, 582);
            this.lv1.SmallImageList = this.imageListProcess;
            this.lv1.TabIndex = 18;
            this.lv1.UseCompatibleStateImageBehavior = false;
            // 
            // Form_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 689);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolstrip_Process);
            this.Name = "Form_Process";
            this.Text = "ProcessForm";
            this.toolstrip_Process.ResumeLayout(false);
            this.toolstrip_Process.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageListProcess;
        private System.Windows.Forms.ToolStrip toolstrip_Process;
        private System.Windows.Forms.ToolStripButton toolStripButtonUp;
        private System.Windows.Forms.ToolStripButton toolStripButtonDown;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 过程设置ToolStripMenuItem;
        public ListViewCollapse lv1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ToolStripButton Toolstrip_START;
        public System.Windows.Forms.ToolStripButton Toolstrip_SUSPEND;
        public System.Windows.Forms.ToolStripButton Toolstrip_STOP;
        public System.Windows.Forms.ToolStripButton Toolstrip_Single;
        public System.Windows.Forms.ToolStripButton toolStripButton_CircleStart;
    }
}