namespace Measure
{
    partial class ShowTestResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dgv_ResultOutput = new System.Windows.Forms.DataGridView();
            this.MeasureID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeasureValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpperDeviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowerDeviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviationDiagram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yield = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResultOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Result
            // 
            this.lbl_Result.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Result.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Result.Font = new System.Drawing.Font("宋体", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Result.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_Result.Location = new System.Drawing.Point(0, 0);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(988, 92);
            this.lbl_Result.TabIndex = 61;
            this.lbl_Result.Text = "---";
            this.lbl_Result.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 92);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(988, 5);
            this.splitter1.TabIndex = 62;
            this.splitter1.TabStop = false;
            // 
            // dgv_ResultOutput
            // 
            this.dgv_ResultOutput.AllowUserToAddRows = false;
            this.dgv_ResultOutput.AllowUserToDeleteRows = false;
            this.dgv_ResultOutput.AllowUserToResizeColumns = false;
            this.dgv_ResultOutput.AllowUserToResizeRows = false;
            this.dgv_ResultOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ResultOutput.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ResultOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ResultOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ResultOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ResultOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeasureID,
            this.SizeName,
            this.SizeProperty,
            this.MeasureValue,
            this.NormValue,
            this.UpperDeviation,
            this.LowerDeviation,
            this.Deviation,
            this.DeviationDiagram,
            this.Yield});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ResultOutput.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ResultOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ResultOutput.EnableHeadersVisualStyles = false;
            this.dgv_ResultOutput.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_ResultOutput.Location = new System.Drawing.Point(0, 97);
            this.dgv_ResultOutput.Name = "dgv_ResultOutput";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ResultOutput.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ResultOutput.RowHeadersVisible = false;
            this.dgv_ResultOutput.RowTemplate.Height = 23;
            this.dgv_ResultOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ResultOutput.Size = new System.Drawing.Size(988, 530);
            this.dgv_ResultOutput.TabIndex = 63;
            // 
            // MeasureID
            // 
            this.MeasureID.HeaderText = "尺寸号";
            this.MeasureID.Name = "MeasureID";
            this.MeasureID.ReadOnly = true;
            this.MeasureID.Visible = false;
            // 
            // SizeName
            // 
            this.SizeName.HeaderText = "元素名称";
            this.SizeName.Name = "SizeName";
            this.SizeName.ReadOnly = true;
            // 
            // SizeProperty
            // 
            this.SizeProperty.HeaderText = "属性";
            this.SizeProperty.Name = "SizeProperty";
            this.SizeProperty.ReadOnly = true;
            this.SizeProperty.Visible = false;
            // 
            // MeasureValue
            // 
            this.MeasureValue.HeaderText = "测量值";
            this.MeasureValue.Name = "MeasureValue";
            this.MeasureValue.ReadOnly = true;
            // 
            // NormValue
            // 
            this.NormValue.HeaderText = "理论值";
            this.NormValue.Name = "NormValue";
            this.NormValue.ReadOnly = true;
            // 
            // UpperDeviation
            // 
            this.UpperDeviation.HeaderText = "上偏差";
            this.UpperDeviation.Name = "UpperDeviation";
            this.UpperDeviation.ReadOnly = true;
            // 
            // LowerDeviation
            // 
            this.LowerDeviation.HeaderText = "下偏差";
            this.LowerDeviation.Name = "LowerDeviation";
            this.LowerDeviation.ReadOnly = true;
            // 
            // Deviation
            // 
            this.Deviation.HeaderText = "偏差";
            this.Deviation.Name = "Deviation";
            this.Deviation.ReadOnly = true;
            // 
            // DeviationDiagram
            // 
            this.DeviationDiagram.HeaderText = "偏差图";
            this.DeviationDiagram.Name = "DeviationDiagram";
            this.DeviationDiagram.ReadOnly = true;
            // 
            // Yield
            // 
            this.Yield.HeaderText = "良率";
            this.Yield.Name = "Yield";
            // 
            // ShowTestResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_ResultOutput);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lbl_Result);
            this.Name = "ShowTestResult";
            this.Size = new System.Drawing.Size(988, 627);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResultOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dgv_ResultOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeasureID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeasureValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpperDeviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowerDeviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviationDiagram;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yield;
    }
}
