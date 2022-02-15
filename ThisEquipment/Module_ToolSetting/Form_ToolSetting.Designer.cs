namespace ToolSetting
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_FixtureName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_SW = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_Logo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel_Toolsetting = new System.Windows.Forms.Panel();
            this.panel_Form = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btn_addDevice = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView_Tools = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_PlcStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip_Tools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageList_Tool = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip_tool = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel_Toolsetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tools)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip_tool.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1456, 94);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label_FixtureName);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(200, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1256, 94);
            this.panel5.TabIndex = 29;
            // 
            // label_FixtureName
            // 
            this.label_FixtureName.AutoSize = true;
            this.label_FixtureName.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_FixtureName.Location = new System.Drawing.Point(425, 29);
            this.label_FixtureName.Name = "label_FixtureName";
            this.label_FixtureName.Size = new System.Drawing.Size(231, 36);
            this.label_FixtureName.TabIndex = 30;
            this.label_FixtureName.Text = "软件系统设置界面";
            this.label_FixtureName.Click += new System.EventHandler(this.label_FixtureName_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label_SW);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1056, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 94);
            this.panel3.TabIndex = 29;
            // 
            // label_SW
            // 
            this.label_SW.AutoSize = true;
            this.label_SW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SW.Location = new System.Drawing.Point(82, 61);
            this.label_SW.Name = "label_SW";
            this.label_SW.Size = new System.Drawing.Size(106, 20);
            this.label_SW.TabIndex = 10;
            this.label_SW.Text = "版本号：V1.0";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label_Logo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 94);
            this.panel4.TabIndex = 28;
            // 
            // label_Logo
            // 
            this.label_Logo.AutoSize = true;
            this.label_Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label_Logo.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Logo.ForeColor = System.Drawing.Color.Blue;
            this.label_Logo.Location = new System.Drawing.Point(21, 29);
            this.label_Logo.Name = "label_Logo";
            this.label_Logo.Size = new System.Drawing.Size(157, 36);
            this.label_Logo.TabIndex = 26;
            this.label_Logo.Text = "Amphenol";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1456, 885);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1456, 863);
            this.panel6.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1456, 863);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel_Toolsetting);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1429, 855);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "软件设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel_Toolsetting
            // 
            this.panel_Toolsetting.Controls.Add(this.panel_Form);
            this.panel_Toolsetting.Controls.Add(this.groupBox1);
            this.panel_Toolsetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Toolsetting.Location = new System.Drawing.Point(3, 3);
            this.panel_Toolsetting.Name = "panel_Toolsetting";
            this.panel_Toolsetting.Size = new System.Drawing.Size(1423, 849);
            this.panel_Toolsetting.TabIndex = 0;
            // 
            // panel_Form
            // 
            this.panel_Form.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Form.Location = new System.Drawing.Point(193, 0);
            this.panel_Form.Name = "panel_Form";
            this.panel_Form.Size = new System.Drawing.Size(1230, 849);
            this.panel_Form.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel10);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 849);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通讯及设备列表";
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.btn_addDevice);
            this.panel10.Location = new System.Drawing.Point(3, 802);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(187, 47);
            this.panel10.TabIndex = 16;
            // 
            // btn_addDevice
            // 
            this.btn_addDevice.BackColor = System.Drawing.Color.White;
            this.btn_addDevice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_addDevice.BackgroundImage")));
            this.btn_addDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addDevice.FlatAppearance.BorderSize = 0;
            this.btn_addDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_addDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_addDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addDevice.ForeColor = System.Drawing.Color.White;
            this.btn_addDevice.Location = new System.Drawing.Point(149, 3);
            this.btn_addDevice.Name = "btn_addDevice";
            this.btn_addDevice.Size = new System.Drawing.Size(35, 38);
            this.btn_addDevice.TabIndex = 14;
            this.btn_addDevice.TabStop = false;
            this.btn_addDevice.UseVisualStyleBackColor = false;
            this.btn_addDevice.Click += new System.EventHandler(this.btn_addDevice_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dataGridView_Tools);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 16);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(187, 780);
            this.panel7.TabIndex = 15;
            // 
            // dataGridView_Tools
            // 
            this.dataGridView_Tools.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Tools.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Tools.CausesValidation = false;
            this.dataGridView_Tools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Tools.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView_Tools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Tools.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Tools.MultiSelect = false;
            this.dataGridView_Tools.Name = "dataGridView_Tools";
            this.dataGridView_Tools.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_Tools.RowHeadersWidth = 10;
            this.dataGridView_Tools.Size = new System.Drawing.Size(187, 780);
            this.dataGridView_Tools.TabIndex = 0;
            this.dataGridView_Tools.SelectionChanged += new System.EventHandler(this.dataGridView_Tools_SelectionChanged);
            this.dataGridView_Tools.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Tools_MouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "图标";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 20;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxVersion);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1429, 855);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "帮助界面";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxVersion.Location = new System.Drawing.Point(3, 3);
            this.textBoxVersion.Multiline = true;
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.Size = new System.Drawing.Size(1423, 849);
            this.textBoxVersion.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_Status,
            this.toolStripStatusLabel_PlcStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 863);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1456, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel1.Text = "RunStatus：";
            // 
            // toolStripStatusLabel_Status
            // 
            this.toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            this.toolStripStatusLabel_Status.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel_Status.Text = "Waitting";
            // 
            // toolStripStatusLabel_PlcStatus
            // 
            this.toolStripStatusLabel_PlcStatus.Name = "toolStripStatusLabel_PlcStatus";
            this.toolStripStatusLabel_PlcStatus.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel_PlcStatus.Text = "等待刷新";
            // 
            // contextMenuStrip_Tools
            // 
            this.contextMenuStrip_Tools.Name = "contextMenuStrip_Tools";
            this.contextMenuStrip_Tools.Size = new System.Drawing.Size(61, 4);
            // 
            // imageList_Tool
            // 
            this.imageList_Tool.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Tool.ImageStream")));
            this.imageList_Tool.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Tool.Images.SetKeyName(0, "1.PNG");
            this.imageList_Tool.Images.SetKeyName(1, "2.PNG");
            this.imageList_Tool.Images.SetKeyName(2, "3.PNG");
            this.imageList_Tool.Images.SetKeyName(3, "4.PNG");
            this.imageList_Tool.Images.SetKeyName(4, "5.PNG");
            this.imageList_Tool.Images.SetKeyName(5, "6.PNG");
            this.imageList_Tool.Images.SetKeyName(6, "7.PNG");
            this.imageList_Tool.Images.SetKeyName(7, "8.PNG");
            this.imageList_Tool.Images.SetKeyName(8, "9.PNG");
            this.imageList_Tool.Images.SetKeyName(9, "10.PNG");
            this.imageList_Tool.Images.SetKeyName(10, "a_X.PNG");
            this.imageList_Tool.Images.SetKeyName(11, "a_Y.PNG");
            this.imageList_Tool.Images.SetKeyName(12, "alarm2.PNG");
            this.imageList_Tool.Images.SetKeyName(13, "b_alarm.PNG");
            this.imageList_Tool.Images.SetKeyName(14, "b_F.PNG");
            this.imageList_Tool.Images.SetKeyName(15, "b_home.PNG");
            this.imageList_Tool.Images.SetKeyName(16, "b_pause.PNG");
            this.imageList_Tool.Images.SetKeyName(17, "b_start.PNG");
            this.imageList_Tool.Images.SetKeyName(18, "b_stop.PNG");
            this.imageList_Tool.Images.SetKeyName(19, "b_user.PNG");
            this.imageList_Tool.Images.SetKeyName(20, "b_wave.PNG");
            this.imageList_Tool.Images.SetKeyName(21, "b_X.PNG");
            this.imageList_Tool.Images.SetKeyName(22, "b_Y.PNG");
            this.imageList_Tool.Images.SetKeyName(23, "DATA.jpg");
            this.imageList_Tool.Images.SetKeyName(24, "Excel.PNG");
            this.imageList_Tool.Images.SetKeyName(25, "Image Mode.jpg");
            this.imageList_Tool.Images.SetKeyName(26, "image004.jpg");
            this.imageList_Tool.Images.SetKeyName(27, "MAIN.jpg");
            this.imageList_Tool.Images.SetKeyName(28, "MaxMin.jpg");
            this.imageList_Tool.Images.SetKeyName(29, "PARAMETER.jpg");
            this.imageList_Tool.Images.SetKeyName(30, "pause.jpg");
            this.imageList_Tool.Images.SetKeyName(31, "pic.PNG");
            this.imageList_Tool.Images.SetKeyName(32, "start.jpg");
            this.imageList_Tool.Images.SetKeyName(33, "stop.jpg");
            this.imageList_Tool.Images.SetKeyName(34, "USER.jpg");
            this.imageList_Tool.Images.SetKeyName(35, "VISION.jpg");
            // 
            // contextMenuStrip_tool
            // 
            this.contextMenuStrip_tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip_tool.Name = "contextMenuStrip1";
            this.contextMenuStrip_tool.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 979);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Main";
            this.Text = "SetUp V1.0";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel_Toolsetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tools)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip_tool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Logo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label_SW;
        private System.Windows.Forms.Label label_FixtureName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_PlcStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel_Toolsetting;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dataGridView_Tools;
        internal System.Windows.Forms.Button btn_addDevice;
        private System.Windows.Forms.Panel panel_Form;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Tools;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.ImageList imageList_Tool;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_tool;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
    }
}

