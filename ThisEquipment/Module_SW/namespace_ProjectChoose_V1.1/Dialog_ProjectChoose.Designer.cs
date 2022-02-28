namespace Dialog_ProjectChoose
{
    partial class Dialog_ProjectChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_ProjectChoose));
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCREATE = new System.Windows.Forms.Button();
            this.textBoxProgram = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDELETE = new System.Windows.Forms.Button();
            this.buttonEXIT = new System.Windows.Forms.Button();
            this.buttonSELECT = new System.Windows.Forms.Button();
            this.checkBoxDefaultPrj = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(20, 75);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(510, 261);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "XG-8000_7000.ico");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem1.Text = "选择项目";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // buttonCREATE
            // 
            this.buttonCREATE.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCREATE.Location = new System.Drawing.Point(20, 381);
            this.buttonCREATE.Name = "buttonCREATE";
            this.buttonCREATE.Size = new System.Drawing.Size(95, 53);
            this.buttonCREATE.TabIndex = 13;
            this.buttonCREATE.Text = "新建[CREATE]";
            this.buttonCREATE.UseVisualStyleBackColor = false;
            this.buttonCREATE.Click += new System.EventHandler(this.buttonCREATE_Click);
            // 
            // textBoxProgram
            // 
            this.textBoxProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProgram.Location = new System.Drawing.Point(178, 23);
            this.textBoxProgram.Name = "textBoxProgram";
            this.textBoxProgram.Size = new System.Drawing.Size(351, 40);
            this.textBoxProgram.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "项目名称：";
            // 
            // buttonDELETE
            // 
            this.buttonDELETE.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDELETE.Location = new System.Drawing.Point(145, 381);
            this.buttonDELETE.Name = "buttonDELETE";
            this.buttonDELETE.Size = new System.Drawing.Size(95, 53);
            this.buttonDELETE.TabIndex = 9;
            this.buttonDELETE.Text = "删除[DELETE]";
            this.buttonDELETE.UseVisualStyleBackColor = false;
            this.buttonDELETE.Click += new System.EventHandler(this.buttonDELETE_Click);
            // 
            // buttonEXIT
            // 
            this.buttonEXIT.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonEXIT.Location = new System.Drawing.Point(430, 381);
            this.buttonEXIT.Name = "buttonEXIT";
            this.buttonEXIT.Size = new System.Drawing.Size(98, 53);
            this.buttonEXIT.TabIndex = 10;
            this.buttonEXIT.Text = "退出[EXIT]";
            this.buttonEXIT.UseVisualStyleBackColor = false;
            this.buttonEXIT.Click += new System.EventHandler(this.buttonEXIT_Click);
            // 
            // buttonSELECT
            // 
            this.buttonSELECT.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSELECT.Location = new System.Drawing.Point(270, 381);
            this.buttonSELECT.Name = "buttonSELECT";
            this.buttonSELECT.Size = new System.Drawing.Size(130, 53);
            this.buttonSELECT.TabIndex = 8;
            this.buttonSELECT.Text = "选择[SELECT]";
            this.buttonSELECT.UseVisualStyleBackColor = false;
            this.buttonSELECT.Click += new System.EventHandler(this.buttonSELECT_Click);
            // 
            // checkBoxDefaultPrj
            // 
            this.checkBoxDefaultPrj.AutoSize = true;
            this.checkBoxDefaultPrj.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDefaultPrj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDefaultPrj.Location = new System.Drawing.Point(74, 345);
            this.checkBoxDefaultPrj.Name = "checkBoxDefaultPrj";
            this.checkBoxDefaultPrj.Size = new System.Drawing.Size(340, 24);
            this.checkBoxDefaultPrj.TabIndex = 17;
            this.checkBoxDefaultPrj.Text = "Setting as user default opening project";
            this.checkBoxDefaultPrj.UseVisualStyleBackColor = true;
            // 
            // Dialog_ProjectChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 449);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxDefaultPrj);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonCREATE);
            this.Controls.Add(this.textBoxProgram);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDELETE);
            this.Controls.Add(this.buttonEXIT);
            this.Controls.Add(this.buttonSELECT);
            this.Name = "Dialog_ProjectChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog_ProjectChoose";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Dialog_ProjectChoose_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button buttonCREATE;
        private System.Windows.Forms.TextBox textBoxProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDELETE;
        private System.Windows.Forms.Button buttonEXIT;
        private System.Windows.Forms.Button buttonSELECT;
        private System.Windows.Forms.CheckBox checkBoxDefaultPrj;
    }
}