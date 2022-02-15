namespace UserCoord
{
    partial class Sub_UserCoord
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
            this.modControl_UserCoord1 = new UserCoord.modControl_UserCoord();
            this.SuspendLayout();
            // 
            // modControl_UserCoord1
            // 
            this.modControl_UserCoord1.Dock = System.Windows.Forms.DockStyle.Top;
            this.modControl_UserCoord1.Location = new System.Drawing.Point(0, 0);
            this.modControl_UserCoord1.Name = "modControl_UserCoord1";
            this.modControl_UserCoord1.Size = new System.Drawing.Size(764, 838);
            this.modControl_UserCoord1.TabIndex = 0;
            this.modControl_UserCoord1.Load += new System.EventHandler(this.modControl_UserCoord1_Load);
            // 
            // Sub_UserCoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 841);
            this.Controls.Add(this.modControl_UserCoord1);
            this.Name = "Sub_UserCoord";
            this.Text = "Sub_UserCoord";
            this.ResumeLayout(false);

        }

        #endregion

        private UserCoord.modControl_UserCoord modControl_UserCoord1;
    }
}