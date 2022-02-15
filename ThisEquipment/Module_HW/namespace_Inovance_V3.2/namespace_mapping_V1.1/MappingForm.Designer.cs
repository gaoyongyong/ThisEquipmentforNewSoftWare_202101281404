namespace MotorsControl
{
    partial class MappingForm
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
            this.mapping_UserControl2 = new MotorsControl.Mapping_UserControl();
            this.SuspendLayout();
            // 
            // mapping_UserControl2
            // 
            this.mapping_UserControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapping_UserControl2.Location = new System.Drawing.Point(0, 0);
            this.mapping_UserControl2.Name = "mapping_UserControl2";
            this.mapping_UserControl2.Size = new System.Drawing.Size(763, 616);
            this.mapping_UserControl2.TabIndex = 0;
            // 
            // MappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 616);
            this.Controls.Add(this.mapping_UserControl2);
            this.Name = "MappingForm";
            this.Text = "MappingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Mapping_UserControl mapping_UserControl1;
        private Mapping_UserControl mapping_UserControl2;
    }
}