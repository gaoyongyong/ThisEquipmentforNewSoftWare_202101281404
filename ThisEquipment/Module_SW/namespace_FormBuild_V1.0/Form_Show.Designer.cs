using ThisEquipment.Properties;

namespace WinForm.FormBuild
{
    partial class Form_Show
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Form = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_graphForm = new System.Windows.Forms.Button();
            this.button_alarmForm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_Form);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 700);
            this.panel1.TabIndex = 0;
            // 
            // panel_Form
            // 
            this.panel_Form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Form.Location = new System.Drawing.Point(0, 58);
            this.panel_Form.Name = "panel_Form";
            this.panel_Form.Size = new System.Drawing.Size(1112, 642);
            this.panel_Form.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_alarmForm);
            this.panel2.Controls.Add(this.button_graphForm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1112, 58);
            this.panel2.TabIndex = 0;
            // 
            // button_graphForm
            // 
            this.button_graphForm.BackgroundImage = Resources._5_DataDisable;
            this.button_graphForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_graphForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_graphForm.Location = new System.Drawing.Point(12, 8);
            this.button_graphForm.Name = "button_graphForm";
            this.button_graphForm.Size = new System.Drawing.Size(49, 44);
            this.button_graphForm.TabIndex = 40;
            this.button_graphForm.UseVisualStyleBackColor = true;
            // 
            // button_alarmForm
            // 
            this.button_alarmForm.BackgroundImage = Resources._4_AlarmDisable;
            this.button_alarmForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_alarmForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_alarmForm.Location = new System.Drawing.Point(85, 8);
            this.button_alarmForm.Name = "button_alarmForm";
            this.button_alarmForm.Size = new System.Drawing.Size(49, 44);
            this.button_alarmForm.TabIndex = 41;
            this.button_alarmForm.UseVisualStyleBackColor = true;
            // 
            // Form_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 700);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Show";
            this.Text = "FormMain";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Form;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_graphForm;
        private System.Windows.Forms.Button button_alarmForm;
    }
}