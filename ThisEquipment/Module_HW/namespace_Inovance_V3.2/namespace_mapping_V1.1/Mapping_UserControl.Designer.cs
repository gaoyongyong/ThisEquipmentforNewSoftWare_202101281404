namespace MotorsControl
{
    partial class Mapping_UserControl
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_Mapping_Trans = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_OpenFile2 = new System.Windows.Forms.Button();
            this.textBox_File2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button_OpenFile1 = new System.Windows.Forms.Button();
            this.textBox_File1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_MappingID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Result_Y = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Result_X = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_Input_Y = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Input_X = new System.Windows.Forms.TextBox();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_Mapping_Trans);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.groupBox1);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.panel8);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(3, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(360, 526);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "mapping数据转换";
            // 
            // button_Mapping_Trans
            // 
            this.button_Mapping_Trans.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Mapping_Trans.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Mapping_Trans.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Mapping_Trans.Location = new System.Drawing.Point(3, 331);
            this.button_Mapping_Trans.Name = "button_Mapping_Trans";
            this.button_Mapping_Trans.Size = new System.Drawing.Size(354, 58);
            this.button_Mapping_Trans.TabIndex = 62;
            this.button_Mapping_Trans.Text = "Mapping 数据转换";
            this.button_Mapping_Trans.UseVisualStyleBackColor = true;
            this.button_Mapping_Trans.Click += new System.EventHandler(this.button_Mapping_Trans_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(3, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(354, 38);
            this.label9.TabIndex = 60;
            this.label9.Text = "第三步：开始转换";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.button_OpenFile2);
            this.groupBox1.Controls.Add(this.textBox_File2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 100);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "存储位置";
            // 
            // button_OpenFile2
            // 
            this.button_OpenFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_OpenFile2.Location = new System.Drawing.Point(3, 55);
            this.button_OpenFile2.Name = "button_OpenFile2";
            this.button_OpenFile2.Size = new System.Drawing.Size(348, 42);
            this.button_OpenFile2.TabIndex = 4;
            this.button_OpenFile2.Text = "浏览";
            this.button_OpenFile2.UseVisualStyleBackColor = true;
            this.button_OpenFile2.Click += new System.EventHandler(this.button_OpenFile2_Click);
            // 
            // textBox_File2
            // 
            this.textBox_File2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_File2.Location = new System.Drawing.Point(3, 17);
            this.textBox_File2.Multiline = true;
            this.textBox_File2.Name = "textBox_File2";
            this.textBox_File2.ReadOnly = true;
            this.textBox_File2.Size = new System.Drawing.Size(348, 38);
            this.textBox_File2.TabIndex = 5;
            this.textBox_File2.Text = "D:\\Log\\AxisData\\MappingData.csv";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(3, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(354, 38);
            this.label11.TabIndex = 66;
            this.label11.Text = "第二步：输入mapping结果位置";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.groupBox7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 55);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(354, 100);
            this.panel8.TabIndex = 61;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox7.Controls.Add(this.button_OpenFile1);
            this.groupBox7.Controls.Add(this.textBox_File1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(354, 100);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "存储位置";
            // 
            // button_OpenFile1
            // 
            this.button_OpenFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_OpenFile1.Location = new System.Drawing.Point(3, 55);
            this.button_OpenFile1.Name = "button_OpenFile1";
            this.button_OpenFile1.Size = new System.Drawing.Size(348, 42);
            this.button_OpenFile1.TabIndex = 4;
            this.button_OpenFile1.Text = "浏览";
            this.button_OpenFile1.UseVisualStyleBackColor = true;
            this.button_OpenFile1.Click += new System.EventHandler(this.button_OpenFile1_Click);
            // 
            // textBox_File1
            // 
            this.textBox_File1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_File1.Location = new System.Drawing.Point(3, 17);
            this.textBox_File1.Multiline = true;
            this.textBox_File1.Name = "textBox_File1";
            this.textBox_File1.ReadOnly = true;
            this.textBox_File1.Size = new System.Drawing.Size(348, 38);
            this.textBox_File1.TabIndex = 5;
            this.textBox_File1.Text = "D:\\Log\\AxisData\\Ori_MappingData.csv";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(3, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(354, 38);
            this.label12.TabIndex = 59;
            this.label12.Text = "第一步：打开mapping原始文件";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_MappingID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_Result_Y);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_Result_X);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox_Input_Y);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_Input_X);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(363, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 526);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "校验点";
            // 
            // textBox_MappingID
            // 
            this.textBox_MappingID.Enabled = false;
            this.textBox_MappingID.Location = new System.Drawing.Point(187, 335);
            this.textBox_MappingID.Name = "textBox_MappingID";
            this.textBox_MappingID.Size = new System.Drawing.Size(100, 21);
            this.textBox_MappingID.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(40, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mapping ID";
            // 
            // textBox_Result_Y
            // 
            this.textBox_Result_Y.Enabled = false;
            this.textBox_Result_Y.Location = new System.Drawing.Point(187, 285);
            this.textBox_Result_Y.Name = "textBox_Result_Y";
            this.textBox_Result_Y.Size = new System.Drawing.Size(100, 21);
            this.textBox_Result_Y.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y轴坐标：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(40, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "X轴坐标：";
            // 
            // textBox_Result_X
            // 
            this.textBox_Result_X.Enabled = false;
            this.textBox_Result_X.Location = new System.Drawing.Point(188, 233);
            this.textBox_Result_X.Name = "textBox_Result_X";
            this.textBox_Result_X.Size = new System.Drawing.Size(100, 21);
            this.textBox_Result_X.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "计算轴坐标";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_Input_Y
            // 
            this.textBox_Input_Y.Location = new System.Drawing.Point(187, 122);
            this.textBox_Input_Y.Name = "textBox_Input_Y";
            this.textBox_Input_Y.Size = new System.Drawing.Size(100, 21);
            this.textBox_Input_Y.TabIndex = 3;
            this.textBox_Input_Y.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "校正板X轴坐标：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "校正板X轴坐标：";
            // 
            // textBox_Input_X
            // 
            this.textBox_Input_X.Location = new System.Drawing.Point(188, 70);
            this.textBox_Input_X.Name = "textBox_Input_X";
            this.textBox_Input_X.Size = new System.Drawing.Size(100, 21);
            this.textBox_Input_X.TabIndex = 0;
            this.textBox_Input_X.Text = "0";
            // 
            // textBox_Log
            // 
            this.textBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Log.Location = new System.Drawing.Point(0, 546);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Log.Size = new System.Drawing.Size(762, 283);
            this.textBox_Log.TabIndex = 69;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(762, 546);
            this.groupBox3.TabIndex = 70;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "手动界面";
            // 
            // Mapping_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.groupBox3);
            this.Name = "Mapping_UserControl";
            this.Size = new System.Drawing.Size(762, 829);
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_Mapping_Trans;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_OpenFile2;
        private System.Windows.Forms.TextBox textBox_File2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button_OpenFile1;
        private System.Windows.Forms.TextBox textBox_File1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_MappingID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Result_Y;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Result_X;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_Input_Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Input_X;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
