namespace ThisEquipment
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolBar_Main1 = new ToolBars.ToolBar_Main();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 776);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 24);
            this.panel1.TabIndex = 16;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 2);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1144, 22);
            this.statusStrip1.TabIndex = 3;
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
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 111);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1144, 2);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolBar_Main1
            // 
            this.toolBar_Main1.Btn01Enable = false;
            this.toolBar_Main1.Btn01Name = "0.1";
            this.toolBar_Main1.Btn02Enable = false;
            this.toolBar_Main1.Btn02Name = "0.1";
            this.toolBar_Main1.Btn03Enable = false;
            this.toolBar_Main1.Btn03Name = "0.1";
            this.toolBar_Main1.Btn04Enable = false;
            this.toolBar_Main1.Btn04Name = "0.1";
            this.toolBar_Main1.Btn05Enable = false;
            this.toolBar_Main1.Btn05Name = "0.1";
            this.toolBar_Main1.Btn11Enable = false;
            this.toolBar_Main1.Btn11Name = "0.1";
            this.toolBar_Main1.Btn12Enable = false;
            this.toolBar_Main1.Btn12Name = "0.1";
            this.toolBar_Main1.Btn13Enable = false;
            this.toolBar_Main1.Btn13Name = "0.1";
            this.toolBar_Main1.Btn21Enable = false;
            this.toolBar_Main1.Btn21Name = "0.1";
            this.toolBar_Main1.Btn22Enable = false;
            this.toolBar_Main1.Btn22Name = "0.1";
            this.toolBar_Main1.BtnLeftEnable = true;
            this.toolBar_Main1.BtnLeftName = "Left";
            this.toolBar_Main1.BtnRightEnable = true;
            this.toolBar_Main1.BtnRightName = "Right";
            this.toolBar_Main1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar_Main1.Location = new System.Drawing.Point(0, 0);
            this.toolBar_Main1.Name = "toolBar_Main1";
            this.toolBar_Main1.PrjEnableChoose = false;
            this.toolBar_Main1.PrjName = "0.1";
            this.toolBar_Main1.Size = new System.Drawing.Size(1144, 111);
            this.toolBar_Main1.TabIndex = 17;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1144, 800);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolBar_Main1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.Text = "AMPHENOL Motion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form_Main_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private ToolBars.ToolBar_Main toolBar_Main1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
        private System.Windows.Forms.Timer timer2;
    }
}

