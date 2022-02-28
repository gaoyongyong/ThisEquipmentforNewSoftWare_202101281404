namespace Measure
{
    partial class ShowTestAllDataInListView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Statistics = new System.Windows.Forms.Panel();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.lbl_NG1 = new System.Windows.Forms.Label();
            this.lv1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonNoClean = new System.Windows.Forms.Button();
            this.buttonYesClean = new System.Windows.Forms.Button();
            this.panel_Statistics.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Statistics
            // 
            this.panel_Statistics.Controls.Add(this.btn_Clear);
            this.panel_Statistics.Controls.Add(this.lbl_NG1);
            this.panel_Statistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Statistics.Location = new System.Drawing.Point(0, 0);
            this.panel_Statistics.Name = "panel_Statistics";
            this.panel_Statistics.Size = new System.Drawing.Size(804, 49);
            this.panel_Statistics.TabIndex = 68;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Clear.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btn_Clear.Location = new System.Drawing.Point(719, 0);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(85, 49);
            this.btn_Clear.TabIndex = 42;
            this.btn_Clear.Text = "Clear ListView";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // lbl_NG1
            // 
            this.lbl_NG1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_NG1.Location = new System.Drawing.Point(552, 48);
            this.lbl_NG1.Name = "lbl_NG1";
            this.lbl_NG1.Size = new System.Drawing.Size(37, 16);
            this.lbl_NG1.TabIndex = 37;
            this.lbl_NG1.Text = "FAIL:";
            // 
            // lv1
            // 
            this.lv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv1.Location = new System.Drawing.Point(0, 49);
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(804, 458);
            this.lv1.TabIndex = 69;
            this.lv1.UseCompatibleStateImageBehavior = false;
           
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.buttonNoClean);
            this.groupBox2.Controls.Add(this.buttonYesClean);
            this.groupBox2.Location = new System.Drawing.Point(259, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 98);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "Clear the data in Listview ?";
            // 
            // buttonNoClean
            // 
            this.buttonNoClean.BackColor = System.Drawing.Color.White;
            this.buttonNoClean.Location = new System.Drawing.Point(169, 58);
            this.buttonNoClean.Name = "buttonNoClean";
            this.buttonNoClean.Size = new System.Drawing.Size(85, 24);
            this.buttonNoClean.TabIndex = 1;
            this.buttonNoClean.Text = "No";
            this.buttonNoClean.UseVisualStyleBackColor = false;
            this.buttonNoClean.Click += new System.EventHandler(this.buttonNoClean_Click);
            // 
            // buttonYesClean
            // 
            this.buttonYesClean.BackColor = System.Drawing.Color.White;
            this.buttonYesClean.Location = new System.Drawing.Point(32, 58);
            this.buttonYesClean.Name = "buttonYesClean";
            this.buttonYesClean.Size = new System.Drawing.Size(85, 24);
            this.buttonYesClean.TabIndex = 0;
            this.buttonYesClean.Text = "Yes";
            this.buttonYesClean.UseVisualStyleBackColor = false;
            this.buttonYesClean.Click += new System.EventHandler(this.buttonYesClean_Click);
            // 
            // ShowTestAllDataInListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.panel_Statistics);
            this.Name = "ShowTestAllDataInListView";
            this.Size = new System.Drawing.Size(804, 507);
            this.panel_Statistics.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Statistics;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Label lbl_NG1;
        private System.Windows.Forms.ListView lv1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonNoClean;
        private System.Windows.Forms.Button buttonYesClean;
    }
}
