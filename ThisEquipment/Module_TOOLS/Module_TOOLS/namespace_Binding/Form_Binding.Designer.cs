using Log;

namespace Tools
{
    partial class Form_Binding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Binding));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.imageListBinding = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip_Binding = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvBinding = new Tools.TreeListViewEx(this.components);
            this.lvIO = new Tools.ListViewCollapse();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Toolstrip_START = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListBinding
            // 
            this.imageListBinding.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBinding.ImageStream")));
            this.imageListBinding.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBinding.Images.SetKeyName(0, "1.ico");
            this.imageListBinding.Images.SetKeyName(1, "2.ico");
            this.imageListBinding.Images.SetKeyName(2, "3.ico");
            this.imageListBinding.Images.SetKeyName(3, "4.ico");
            this.imageListBinding.Images.SetKeyName(4, "5.ico");
            this.imageListBinding.Images.SetKeyName(5, "6.ico");
            this.imageListBinding.Images.SetKeyName(6, "7.png");
            this.imageListBinding.Images.SetKeyName(7, "a_alarm.PNG");
            this.imageListBinding.Images.SetKeyName(8, "a_ccd.PNG");
            this.imageListBinding.Images.SetKeyName(9, "a_home.PNG");
            this.imageListBinding.Images.SetKeyName(10, "a_pause.PNG");
            this.imageListBinding.Images.SetKeyName(11, "a_R.PNG");
            this.imageListBinding.Images.SetKeyName(12, "a_setup.PNG");
            this.imageListBinding.Images.SetKeyName(13, "a_start.PNG");
            this.imageListBinding.Images.SetKeyName(14, "a_stop.PNG");
            this.imageListBinding.Images.SetKeyName(15, "a_user.PNG");
            this.imageListBinding.Images.SetKeyName(16, "a_wave.PNG");
            this.imageListBinding.Images.SetKeyName(17, "a_X.PNG");
            this.imageListBinding.Images.SetKeyName(18, "a_Y.PNG");
            this.imageListBinding.Images.SetKeyName(19, "alarm2.PNG");
            this.imageListBinding.Images.SetKeyName(20, "b_alarm.PNG");
            this.imageListBinding.Images.SetKeyName(21, "b_F.PNG");
            this.imageListBinding.Images.SetKeyName(22, "b_home.PNG");
            this.imageListBinding.Images.SetKeyName(23, "b_pause.PNG");
            this.imageListBinding.Images.SetKeyName(24, "b_start.PNG");
            this.imageListBinding.Images.SetKeyName(25, "b_stop.PNG");
            this.imageListBinding.Images.SetKeyName(26, "b_user.PNG");
            this.imageListBinding.Images.SetKeyName(27, "b_wave.PNG");
            this.imageListBinding.Images.SetKeyName(28, "b_X.PNG");
            this.imageListBinding.Images.SetKeyName(29, "b_Y.PNG");
            this.imageListBinding.Images.SetKeyName(30, "DATA.jpg");
            this.imageListBinding.Images.SetKeyName(31, "Demo.ico");
            this.imageListBinding.Images.SetKeyName(32, "Excel.PNG");
            this.imageListBinding.Images.SetKeyName(33, "Image Mode.jpg");
            this.imageListBinding.Images.SetKeyName(34, "image004.jpg");
            this.imageListBinding.Images.SetKeyName(35, "MAIN.jpg");
            this.imageListBinding.Images.SetKeyName(36, "MaxMin.jpg");
            this.imageListBinding.Images.SetKeyName(37, "PARAMETER.jpg");
            this.imageListBinding.Images.SetKeyName(38, "pause.jpg");
            this.imageListBinding.Images.SetKeyName(39, "pic.PNG");
            this.imageListBinding.Images.SetKeyName(40, "start.jpg");
            this.imageListBinding.Images.SetKeyName(41, "stop.jpg");
            this.imageListBinding.Images.SetKeyName(42, "USER.jpg");
            this.imageListBinding.Images.SetKeyName(43, "VISION.jpg");
            // 
            // contextMenuStrip_Binding
            // 
            this.contextMenuStrip_Binding.Name = "contextMenuStrip1";
            this.contextMenuStrip_Binding.Size = new System.Drawing.Size(61, 4);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid.Location = new System.Drawing.Point(0, 25);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(346, 371);
            this.propertyGrid.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvBinding);
            this.panel1.Controls.Add(this.lvIO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 514);
            this.panel1.TabIndex = 3;
            // 
            // lvBinding
            // 
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.lvBinding.Comparer = treeListViewItemCollectionComparer1;
            this.lvBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBinding.HideSelection = false;
            this.lvBinding.Location = new System.Drawing.Point(248, 0);
            this.lvBinding.Name = "lvBinding";
            this.lvBinding.Size = new System.Drawing.Size(364, 514);
            this.lvBinding.SmallImageList = this.imageListBinding;
            this.lvBinding.TabIndex = 22;
            this.lvBinding.UseCompatibleStateImageBehavior = false;
            // 
            // lvIO
            // 
            this.lvIO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvIO.Location = new System.Drawing.Point(0, 0);
            this.lvIO.Name = "lvIO";
            this.lvIO.Size = new System.Drawing.Size(248, 514);
            this.lvIO.TabIndex = 21;
            this.lvIO.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(38, 38);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Toolstrip_START,
            this.toolStripSeparator3,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 539);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(612, 41);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 18;
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
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Log);
            this.panel2.Controls.Add(this.menuStrip3);
            this.panel2.Controls.Add(this.propertyGrid);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(612, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 580);
            this.panel2.TabIndex = 4;
            // 
            // textBox_Log
            // 
            this.textBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Log.Location = new System.Drawing.Point(0, 421);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.Size = new System.Drawing.Size(346, 159);
            this.textBox_Log.TabIndex = 22;
            // 
            // menuStrip3
            // 
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.menuStrip3.Location = new System.Drawing.Point(0, 396);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip3.Size = new System.Drawing.Size(346, 25);
            this.menuStrip3.TabIndex = 21;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(92, 21);
            this.toolStripMenuItem2.Text = "方法执行结果";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(346, 25);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem1.Text = "参数显示";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.menuStrip2);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(612, 580);
            this.panel3.TabIndex = 6;
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(612, 25);
            this.menuStrip2.TabIndex = 21;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem3.Text = "参数绑定";
            // 
            // Form_Binding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 580);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "Form_Binding";
            this.Text = "参数设置";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Binding;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Toolstrip_START;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel3;
        private ListViewCollapse lvIO;
        //private Log.UILog uiLog1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        public System.Windows.Forms.ImageList imageListBinding;
        private TreeListViewEx lvBinding;
        private System.Windows.Forms.TextBox textBox_Log;
    }
}