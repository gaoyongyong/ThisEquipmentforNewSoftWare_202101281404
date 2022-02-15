namespace Tools
{
    partial class Form_Tool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Tool));
            this.listViewCollapseTool = new Tools.ListViewCollapse();
            this.imageListTools = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listViewCollapseTool
            // 
            this.listViewCollapseTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCollapseTool.LargeImageList = this.imageListTools;
            this.listViewCollapseTool.Location = new System.Drawing.Point(0, 0);
            this.listViewCollapseTool.Name = "listViewCollapseTool";
            this.listViewCollapseTool.Size = new System.Drawing.Size(269, 366);
            this.listViewCollapseTool.TabIndex = 0;
            this.listViewCollapseTool.UseCompatibleStateImageBehavior = false;
            // 
            // imageListTools
            // 
            this.imageListTools.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTools.ImageStream")));
            this.imageListTools.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTools.Images.SetKeyName(0, "1.ico");
            this.imageListTools.Images.SetKeyName(1, "2.ico");
            this.imageListTools.Images.SetKeyName(2, "3.ico");
            this.imageListTools.Images.SetKeyName(3, "4.ico");
            this.imageListTools.Images.SetKeyName(4, "5.ico");
            this.imageListTools.Images.SetKeyName(5, "6.ico");
            this.imageListTools.Images.SetKeyName(6, "7.png");
            this.imageListTools.Images.SetKeyName(7, "a_alarm.PNG");
            this.imageListTools.Images.SetKeyName(8, "a_ccd.PNG");
            this.imageListTools.Images.SetKeyName(9, "a_home.PNG");
            this.imageListTools.Images.SetKeyName(10, "a_pause.PNG");
            this.imageListTools.Images.SetKeyName(11, "a_R.PNG");
            this.imageListTools.Images.SetKeyName(12, "a_setup.PNG");
            this.imageListTools.Images.SetKeyName(13, "a_start.PNG");
            this.imageListTools.Images.SetKeyName(14, "a_stop.PNG");
            this.imageListTools.Images.SetKeyName(15, "a_user.PNG");
            this.imageListTools.Images.SetKeyName(16, "a_wave.PNG");
            this.imageListTools.Images.SetKeyName(17, "a_X.PNG");
            this.imageListTools.Images.SetKeyName(18, "a_Y.PNG");
            this.imageListTools.Images.SetKeyName(19, "alarm2.PNG");
            this.imageListTools.Images.SetKeyName(20, "b_alarm.PNG");
            this.imageListTools.Images.SetKeyName(21, "b_F.PNG");
            this.imageListTools.Images.SetKeyName(22, "b_home.PNG");
            this.imageListTools.Images.SetKeyName(23, "b_pause.PNG");
            this.imageListTools.Images.SetKeyName(24, "b_start.PNG");
            this.imageListTools.Images.SetKeyName(25, "b_stop.PNG");
            this.imageListTools.Images.SetKeyName(26, "b_user.PNG");
            this.imageListTools.Images.SetKeyName(27, "b_wave.PNG");
            this.imageListTools.Images.SetKeyName(28, "b_X.PNG");
            this.imageListTools.Images.SetKeyName(29, "b_Y.PNG");
            this.imageListTools.Images.SetKeyName(30, "DATA.jpg");
            this.imageListTools.Images.SetKeyName(31, "Demo.ico");
            this.imageListTools.Images.SetKeyName(32, "Excel.PNG");
            this.imageListTools.Images.SetKeyName(33, "Image Mode.jpg");
            this.imageListTools.Images.SetKeyName(34, "image004.jpg");
            this.imageListTools.Images.SetKeyName(35, "MAIN.jpg");
            this.imageListTools.Images.SetKeyName(36, "MaxMin.jpg");
            this.imageListTools.Images.SetKeyName(37, "PARAMETER.jpg");
            this.imageListTools.Images.SetKeyName(38, "pause.jpg");
            this.imageListTools.Images.SetKeyName(39, "pic.PNG");
            this.imageListTools.Images.SetKeyName(40, "start.jpg");
            this.imageListTools.Images.SetKeyName(41, "stop.jpg");
            this.imageListTools.Images.SetKeyName(42, "USER.jpg");
            this.imageListTools.Images.SetKeyName(43, "VISION.jpg");
            // 
            // Form_Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 366);
            this.Controls.Add(this.listViewCollapseTool);
            this.Name = "Form_Tool";
            this.Text = "ToolForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Tools.ListViewCollapse listViewCollapseTool;
        private System.Windows.Forms.ImageList imageListTools;
    }
}