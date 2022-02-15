namespace ThisEquipment
{
    partial class Form_SubData
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
            this.button1 = new System.Windows.Forms.Button();
            this.showTestAllDataInListView1 = new Measure.ShowTestAllDataInListView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // showTestAllDataInListView1
            // 
            this.showTestAllDataInListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showTestAllDataInListView1.Location = new System.Drawing.Point(0, 0);
            this.showTestAllDataInListView1.Name = "showTestAllDataInListView1";
            this.showTestAllDataInListView1.Size = new System.Drawing.Size(1268, 610);
            this.showTestAllDataInListView1.TabIndex = 2;
            this.showTestAllDataInListView1.Load += new System.EventHandler(this.showTestAllDataInListView1_Load);
            // 
            // Form_SubData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 610);
            this.Controls.Add(this.showTestAllDataInListView1);
            this.Controls.Add(this.button1);
            this.Name = "Form_SubData";
            this.Text = "Form_SubData";
            this.ResumeLayout(false);

        }

        #endregion

        //private Measure.ShowTestAllData showTestAllData1;
        private System.Windows.Forms.Button button1;
        public Measure.ShowTestAllDataInListView showTestAllDataInListView1;
        //private Measure.ShowTestAllData showTestAllData1;
    }
}