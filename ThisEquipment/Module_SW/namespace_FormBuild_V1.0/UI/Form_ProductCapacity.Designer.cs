namespace WinForm.FormBuild.UI
{
    partial class Form_ProductCapacity
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
            this.panel_ShowData = new System.Windows.Forms.Panel();
            this.button_UPHStatistics = new System.Windows.Forms.Button();
            this.button_DTHoursStatistics = new System.Windows.Forms.Button();
            this.button_ShowRefresh = new System.Windows.Forms.Button();
            this.radbut_MapShow = new System.Windows.Forms.RadioButton();
            this.radbut_listShow = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_Starttime = new System.Windows.Forms.DateTimePicker();
            this.panel_Select = new System.Windows.Forms.Panel();
            this.label_TimeSolt = new System.Windows.Forms.Label();
            this.panel_Button = new System.Windows.Forms.Panel();
            this.panel_Select.SuspendLayout();
            this.panel_Button.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_ShowData
            // 
            this.panel_ShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ShowData.Location = new System.Drawing.Point(128, 69);
            this.panel_ShowData.Name = "panel_ShowData";
            this.panel_ShowData.Size = new System.Drawing.Size(984, 573);
            this.panel_ShowData.TabIndex = 19;
            // 
            // button_UPHStatistics
            // 
            this.button_UPHStatistics.Location = new System.Drawing.Point(12, 3);
            this.button_UPHStatistics.Name = "button_UPHStatistics";
            this.button_UPHStatistics.Size = new System.Drawing.Size(107, 43);
            this.button_UPHStatistics.TabIndex = 12;
            this.button_UPHStatistics.Text = "产能统计";
            this.button_UPHStatistics.UseVisualStyleBackColor = true;
            this.button_UPHStatistics.Click += new System.EventHandler(this.button_UPHStatistics_Click);
            // 
            // button_DTHoursStatistics
            // 
            this.button_DTHoursStatistics.Location = new System.Drawing.Point(12, 69);
            this.button_DTHoursStatistics.Name = "button_DTHoursStatistics";
            this.button_DTHoursStatistics.Size = new System.Drawing.Size(107, 43);
            this.button_DTHoursStatistics.TabIndex = 13;
            this.button_DTHoursStatistics.Text = "时间统计";
            this.button_DTHoursStatistics.UseVisualStyleBackColor = true;
            this.button_DTHoursStatistics.Click += new System.EventHandler(this.button_DTHoursStatistics_Click);
            // 
            // button_ShowRefresh
            // 
            this.button_ShowRefresh.Location = new System.Drawing.Point(301, 42);
            this.button_ShowRefresh.Name = "button_ShowRefresh";
            this.button_ShowRefresh.Size = new System.Drawing.Size(53, 26);
            this.button_ShowRefresh.TabIndex = 14;
            this.button_ShowRefresh.Text = "刷新";
            this.button_ShowRefresh.UseVisualStyleBackColor = true;
            this.button_ShowRefresh.Click += new System.EventHandler(this.button_ShowRefresh_Click);
            // 
            // radbut_MapShow
            // 
            this.radbut_MapShow.AutoSize = true;
            this.radbut_MapShow.Location = new System.Drawing.Point(124, 16);
            this.radbut_MapShow.Name = "radbut_MapShow";
            this.radbut_MapShow.Size = new System.Drawing.Size(73, 17);
            this.radbut_MapShow.TabIndex = 8;
            this.radbut_MapShow.TabStop = true;
            this.radbut_MapShow.Text = "图形显示";
            this.radbut_MapShow.UseVisualStyleBackColor = true;
            this.radbut_MapShow.CheckedChanged += new System.EventHandler(this.radbut_MapShow_CheckedChanged);
            // 
            // radbut_listShow
            // 
            this.radbut_listShow.AutoSize = true;
            this.radbut_listShow.Location = new System.Drawing.Point(11, 16);
            this.radbut_listShow.Name = "radbut_listShow";
            this.radbut_listShow.Size = new System.Drawing.Size(73, 17);
            this.radbut_listShow.TabIndex = 7;
            this.radbut_listShow.TabStop = true;
            this.radbut_listShow.Text = "列表显示";
            this.radbut_listShow.UseVisualStyleBackColor = true;
            this.radbut_listShow.CheckedChanged += new System.EventHandler(this.radbut_listShow_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "选择查看日期:";
            // 
            // dateTimePicker_Starttime
            // 
            this.dateTimePicker_Starttime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_Starttime.Location = new System.Drawing.Point(99, 43);
            this.dateTimePicker_Starttime.Name = "dateTimePicker_Starttime";
            this.dateTimePicker_Starttime.Size = new System.Drawing.Size(196, 20);
            this.dateTimePicker_Starttime.TabIndex = 10;
            this.dateTimePicker_Starttime.ValueChanged += new System.EventHandler(this.dateTimePicker_Starttime_ValueChanged);
            // 
            // panel_Select
            // 
            this.panel_Select.Controls.Add(this.label_TimeSolt);
            this.panel_Select.Controls.Add(this.button_ShowRefresh);
            this.panel_Select.Controls.Add(this.radbut_MapShow);
            this.panel_Select.Controls.Add(this.radbut_listShow);
            this.panel_Select.Controls.Add(this.label1);
            this.panel_Select.Controls.Add(this.dateTimePicker_Starttime);
            this.panel_Select.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Select.Location = new System.Drawing.Point(128, 0);
            this.panel_Select.Name = "panel_Select";
            this.panel_Select.Size = new System.Drawing.Size(984, 69);
            this.panel_Select.TabIndex = 20;
            // 
            // label_TimeSolt
            // 
            this.label_TimeSolt.AutoSize = true;
            this.label_TimeSolt.Location = new System.Drawing.Point(406, 50);
            this.label_TimeSolt.Name = "label_TimeSolt";
            this.label_TimeSolt.Size = new System.Drawing.Size(42, 13);
            this.label_TimeSolt.TabIndex = 15;
            this.label_TimeSolt.Text = "Time：";
            // 
            // panel_Button
            // 
            this.panel_Button.Controls.Add(this.button_UPHStatistics);
            this.panel_Button.Controls.Add(this.button_DTHoursStatistics);
            this.panel_Button.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Button.Location = new System.Drawing.Point(0, 0);
            this.panel_Button.Name = "panel_Button";
            this.panel_Button.Size = new System.Drawing.Size(128, 642);
            this.panel_Button.TabIndex = 18;
            // 
            // Form_ProductCapacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 642);
            this.Controls.Add(this.panel_ShowData);
            this.Controls.Add(this.panel_Select);
            this.Controls.Add(this.panel_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ProductCapacity";
            this.Text = "Form_ProductCapacity";
            this.panel_Select.ResumeLayout(false);
            this.panel_Select.PerformLayout();
            this.panel_Button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_ShowData;
        private System.Windows.Forms.Button button_UPHStatistics;
        private System.Windows.Forms.Button button_DTHoursStatistics;
        private System.Windows.Forms.Button button_ShowRefresh;
        private System.Windows.Forms.RadioButton radbut_MapShow;
        private System.Windows.Forms.RadioButton radbut_listShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Starttime;
        private System.Windows.Forms.Panel panel_Select;
        private System.Windows.Forms.Label label_TimeSolt;
        private System.Windows.Forms.Panel panel_Button;
    }
}