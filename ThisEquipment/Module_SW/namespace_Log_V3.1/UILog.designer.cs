namespace Log
{
    partial class UILog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLogMsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtLogMsg
            // 
            this.txtLogMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogMsg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLogMsg.Location = new System.Drawing.Point(0, 0);
            this.txtLogMsg.Name = "txtLogMsg";
            this.txtLogMsg.Size = new System.Drawing.Size(199, 163);
            this.txtLogMsg.TabIndex = 0;
            this.txtLogMsg.Text = "";
            this.txtLogMsg.TextChanged += new System.EventHandler(this.txtLogMsg_TextChanged);
            // 
            // UILog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLogMsg);
            this.Name = "UILog";
            this.Size = new System.Drawing.Size(199, 163);
            this.Load += new System.EventHandler(this.UILog_Load);
            this.ClientSizeChanged += new System.EventHandler(this.UILog_ClientSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.RichTextBox txtLogMsg;
        //private System.Windows.Forms.RichTextBox richTextBox1;

    }
}
