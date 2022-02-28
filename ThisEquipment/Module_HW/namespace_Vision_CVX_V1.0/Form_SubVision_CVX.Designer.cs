namespace VISION_CVX
{
    partial class Form_SubVision_CVX
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
            this.button_CloseSocket = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonINIT_Socket = new System.Windows.Forms.Button();
            this.button_Read_Data = new System.Windows.Forms.Button();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_Result_X = new System.Windows.Forms.TextBox();
            this.tb_Result_Y = new System.Windows.Forms.TextBox();
            this.button_Result_Check = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_Check_X = new System.Windows.Forms.TextBox();
            this.tb_Check_Y = new System.Windows.Forms.TextBox();
            this.button_Check = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_value = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_P4_X = new System.Windows.Forms.TextBox();
            this.tb_P4_Y = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_P3_X = new System.Windows.Forms.TextBox();
            this.tb_P3_Y = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_P2_X = new System.Windows.Forms.TextBox();
            this.tb_P2_Y = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_P1_X = new System.Windows.Forms.TextBox();
            this.tb_P1_Y = new System.Windows.Forms.TextBox();
            this.button_Calibration = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_CloseSocket
            // 
            this.button_CloseSocket.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_CloseSocket.Location = new System.Drawing.Point(3, 710);
            this.button_CloseSocket.Name = "button_CloseSocket";
            this.button_CloseSocket.Size = new System.Drawing.Size(501, 58);
            this.button_CloseSocket.TabIndex = 23;
            this.button_CloseSocket.Text = "Clear";
            this.button_CloseSocket.UseVisualStyleBackColor = true;
            this.button_CloseSocket.Click += new System.EventHandler(this.buttonFUNC_CloseSocket_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPort.Enabled = false;
            this.textBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPort.Location = new System.Drawing.Point(3, 77);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(501, 29);
            this.textBoxPort.TabIndex = 21;
            this.textBoxPort.Text = "8500";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.Location = new System.Drawing.Point(3, 48);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(501, 29);
            this.textBoxIP.TabIndex = 20;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // buttonINIT_Socket
            // 
            this.buttonINIT_Socket.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonINIT_Socket.Location = new System.Drawing.Point(3, 17);
            this.buttonINIT_Socket.Name = "buttonINIT_Socket";
            this.buttonINIT_Socket.Size = new System.Drawing.Size(501, 31);
            this.buttonINIT_Socket.TabIndex = 19;
            this.buttonINIT_Socket.Text = "INIT_CVX";
            this.buttonINIT_Socket.UseVisualStyleBackColor = true;
            this.buttonINIT_Socket.Click += new System.EventHandler(this.buttonINIT_Socket_Click);
            // 
            // button_Read_Data
            // 
            this.button_Read_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Read_Data.Location = new System.Drawing.Point(3, 106);
            this.button_Read_Data.Name = "button_Read_Data";
            this.button_Read_Data.Size = new System.Drawing.Size(501, 58);
            this.button_Read_Data.TabIndex = 53;
            this.button_Read_Data.Text = "Read_CXV_Data";
            this.button_Read_Data.UseVisualStyleBackColor = true;
            this.button_Read_Data.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_Log
            // 
            this.textBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Log.Enabled = false;
            this.textBox_Log.Location = new System.Drawing.Point(3, 164);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.Size = new System.Drawing.Size(501, 543);
            this.textBox_Log.TabIndex = 54;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Log);
            this.groupBox1.Controls.Add(this.splitter1);
            this.groupBox1.Controls.Add(this.button_CloseSocket);
            this.groupBox1.Controls.Add(this.button_Read_Data);
            this.groupBox1.Controls.Add(this.textBoxPort);
            this.groupBox1.Controls.Add(this.textBoxIP);
            this.groupBox1.Controls.Add(this.buttonINIT_Socket);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 771);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Laser_Manual_Test";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 707);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(501, 3);
            this.splitter1.TabIndex = 55;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.button_Result_Check);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_value);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.button_Calibration);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(507, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 771);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "相机校正";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(3, 606);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(444, 162);
            this.textBox1.TabIndex = 65;
            this.textBox1.Text = "说明：\r\n   校正完成后，需要轴走到对应位置，相机反馈的数值与轴的位置需要一致。";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.tb_Result_X);
            this.panel4.Controls.Add(this.tb_Result_Y);
            this.panel4.Location = new System.Drawing.Point(3, 550);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(444, 56);
            this.panel4.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(53, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 16);
            this.label12.TabIndex = 19;
            this.label12.Text = "转换后坐标位置";
            // 
            // tb_Result_X
            // 
            this.tb_Result_X.Enabled = false;
            this.tb_Result_X.Location = new System.Drawing.Point(216, 14);
            this.tb_Result_X.Name = "tb_Result_X";
            this.tb_Result_X.Size = new System.Drawing.Size(64, 21);
            this.tb_Result_X.TabIndex = 17;
            // 
            // tb_Result_Y
            // 
            this.tb_Result_Y.Enabled = false;
            this.tb_Result_Y.Location = new System.Drawing.Point(313, 14);
            this.tb_Result_Y.Name = "tb_Result_Y";
            this.tb_Result_Y.Size = new System.Drawing.Size(64, 21);
            this.tb_Result_Y.TabIndex = 18;
            // 
            // button_Result_Check
            // 
            this.button_Result_Check.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Result_Check.Location = new System.Drawing.Point(3, 497);
            this.button_Result_Check.Name = "button_Result_Check";
            this.button_Result_Check.Size = new System.Drawing.Size(444, 53);
            this.button_Result_Check.TabIndex = 64;
            this.button_Result_Check.Text = "结果验证";
            this.button_Result_Check.UseVisualStyleBackColor = true;
            this.button_Result_Check.Click += new System.EventHandler(this.button_Result_Check_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tb_Check_X);
            this.panel3.Controls.Add(this.tb_Check_Y);
            this.panel3.Location = new System.Drawing.Point(3, 458);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(444, 39);
            this.panel3.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(53, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "相机坐标点";
            // 
            // tb_Check_X
            // 
            this.tb_Check_X.Location = new System.Drawing.Point(216, 5);
            this.tb_Check_X.Name = "tb_Check_X";
            this.tb_Check_X.Size = new System.Drawing.Size(64, 21);
            this.tb_Check_X.TabIndex = 17;
            // 
            // tb_Check_Y
            // 
            this.tb_Check_Y.Location = new System.Drawing.Point(313, 5);
            this.tb_Check_Y.Name = "tb_Check_Y";
            this.tb_Check_Y.Size = new System.Drawing.Size(64, 21);
            this.tb_Check_Y.TabIndex = 18;
            // 
            // button_Check
            // 
            this.button_Check.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_Check.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Check.Location = new System.Drawing.Point(0, 0);
            this.button_Check.Name = "button_Check";
            this.button_Check.Size = new System.Drawing.Size(216, 57);
            this.button_Check.TabIndex = 55;
            this.button_Check.Text = "读校验点数据1";
            this.button_Check.UseVisualStyleBackColor = true;
            this.button_Check.Click += new System.EventHandler(this.button_Check_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(3, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(444, 38);
            this.label8.TabIndex = 61;
            this.label8.Text = "第四步：结果验证";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_value
            // 
            this.btn_value.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_value.Enabled = false;
            this.btn_value.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_value.Location = new System.Drawing.Point(3, 323);
            this.btn_value.Name = "btn_value";
            this.btn_value.Size = new System.Drawing.Size(444, 39);
            this.btn_value.TabIndex = 60;
            this.btn_value.Text = "点赋值";
            this.btn_value.UseVisualStyleBackColor = true;
            this.btn_value.Click += new System.EventHandler(this.btn_value_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(3, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(444, 38);
            this.label7.TabIndex = 59;
            this.label7.Text = "第三步：校正";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tb_P4_X);
            this.panel2.Controls.Add(this.tb_P4_Y);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tb_P3_X);
            this.panel2.Controls.Add(this.tb_P3_Y);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 218);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(444, 67);
            this.panel2.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "相机拍到第二个点坐标值";
            // 
            // tb_P4_X
            // 
            this.tb_P4_X.Location = new System.Drawing.Point(216, 41);
            this.tb_P4_X.Name = "tb_P4_X";
            this.tb_P4_X.Size = new System.Drawing.Size(64, 21);
            this.tb_P4_X.TabIndex = 20;
            this.tb_P4_X.Text = "1";
            // 
            // tb_P4_Y
            // 
            this.tb_P4_Y.Location = new System.Drawing.Point(313, 41);
            this.tb_P4_Y.Name = "tb_P4_Y";
            this.tb_P4_Y.Size = new System.Drawing.Size(64, 21);
            this.tb_P4_Y.TabIndex = 21;
            this.tb_P4_Y.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(20, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "相机拍到第一个点坐标值";
            // 
            // tb_P3_X
            // 
            this.tb_P3_X.Location = new System.Drawing.Point(216, 5);
            this.tb_P3_X.Name = "tb_P3_X";
            this.tb_P3_X.Size = new System.Drawing.Size(64, 21);
            this.tb_P3_X.TabIndex = 17;
            this.tb_P3_X.Text = "0";
            // 
            // tb_P3_Y
            // 
            this.tb_P3_Y.Location = new System.Drawing.Point(313, 5);
            this.tb_P3_Y.Name = "tb_P3_Y";
            this.tb_P3_Y.Size = new System.Drawing.Size(64, 21);
            this.tb_P3_Y.TabIndex = 18;
            this.tb_P3_Y.Text = "0";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 38);
            this.label1.TabIndex = 57;
            this.label1.Text = "第二步：输入校正板坐标值";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tb_P2_X);
            this.panel1.Controls.Add(this.tb_P2_Y);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tb_P1_X);
            this.panel1.Controls.Add(this.tb_P1_Y);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 67);
            this.panel1.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(68, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "相机第二个点坐标";
            // 
            // tb_P2_X
            // 
            this.tb_P2_X.Enabled = false;
            this.tb_P2_X.Location = new System.Drawing.Point(216, 41);
            this.tb_P2_X.Name = "tb_P2_X";
            this.tb_P2_X.Size = new System.Drawing.Size(64, 21);
            this.tb_P2_X.TabIndex = 20;
            // 
            // tb_P2_Y
            // 
            this.tb_P2_Y.Enabled = false;
            this.tb_P2_Y.Location = new System.Drawing.Point(313, 41);
            this.tb_P2_Y.Name = "tb_P2_Y";
            this.tb_P2_Y.Size = new System.Drawing.Size(64, 21);
            this.tb_P2_Y.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(68, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "相机第一个点坐标";
            // 
            // tb_P1_X
            // 
            this.tb_P1_X.Enabled = false;
            this.tb_P1_X.Location = new System.Drawing.Point(216, 5);
            this.tb_P1_X.Name = "tb_P1_X";
            this.tb_P1_X.Size = new System.Drawing.Size(64, 21);
            this.tb_P1_X.TabIndex = 17;
            // 
            // tb_P1_Y
            // 
            this.tb_P1_Y.Enabled = false;
            this.tb_P1_Y.Location = new System.Drawing.Point(313, 5);
            this.tb_P1_Y.Name = "tb_P1_Y";
            this.tb_P1_Y.Size = new System.Drawing.Size(64, 21);
            this.tb_P1_Y.TabIndex = 18;
            // 
            // button_Calibration
            // 
            this.button_Calibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Calibration.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Calibration.Location = new System.Drawing.Point(3, 55);
            this.button_Calibration.Name = "button_Calibration";
            this.button_Calibration.Size = new System.Drawing.Size(444, 58);
            this.button_Calibration.TabIndex = 54;
            this.button_Calibration.Text = "读标定数据";
            this.button_Calibration.UseVisualStyleBackColor = true;
            this.button_Calibration.Click += new System.EventHandler(this.button_Calibration_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(444, 38);
            this.label3.TabIndex = 55;
            this.label3.Text = "第一步：在相机视野里找两个点";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.button_Check);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 400);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(444, 57);
            this.panel5.TabIndex = 66;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(216, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 57);
            this.button1.TabIndex = 56;
            this.button1.Text = "读校验点数据2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_SubVision_CVX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 771);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_SubVision_CVX";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_SubVision_LJ8080_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_CloseSocket;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonINIT_Socket;
        private System.Windows.Forms.Button button_Read_Data;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_Result_X;
        private System.Windows.Forms.TextBox tb_Result_Y;
        private System.Windows.Forms.Button button_Result_Check;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_Check_X;
        private System.Windows.Forms.TextBox tb_Check_Y;
        private System.Windows.Forms.Button button_Check;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_value;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_P4_X;
        private System.Windows.Forms.TextBox tb_P4_Y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_P3_X;
        private System.Windows.Forms.TextBox tb_P3_Y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_P2_X;
        private System.Windows.Forms.TextBox tb_P2_Y;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_P1_X;
        private System.Windows.Forms.TextBox tb_P1_Y;
        private System.Windows.Forms.Button button_Calibration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1;
    }
}