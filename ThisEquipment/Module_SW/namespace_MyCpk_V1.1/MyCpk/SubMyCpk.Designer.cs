namespace MyCpk
{
    partial class SubMyCpk
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_NormDist = new System.Windows.Forms.Panel();
            this.chart_cpkNorm2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_Cpk = new System.Windows.Forms.Panel();
            this.chart_Rowdata = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.chart_cpkNorm1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listView_Rowdata = new System.Windows.Forms.ListView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_NormDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cpkNorm2)).BeginInit();
            this.panel_Cpk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Rowdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cpkNorm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_NormDist
            // 
            this.panel_NormDist.Controls.Add(this.chart_cpkNorm2);
            this.panel_NormDist.Location = new System.Drawing.Point(3, 1);
            this.panel_NormDist.Name = "panel_NormDist";
            this.panel_NormDist.Size = new System.Drawing.Size(386, 345);
            this.panel_NormDist.TabIndex = 0;
            // 
            // chart_cpkNorm2
            // 
            this.chart_cpkNorm2.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chart_cpkNorm2.ChartAreas.Add(chartArea1);
            this.chart_cpkNorm2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_cpkNorm2.Location = new System.Drawing.Point(0, 0);
            this.chart_cpkNorm2.Name = "chart_cpkNorm2";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart_cpkNorm2.Series.Add(series1);
            this.chart_cpkNorm2.Size = new System.Drawing.Size(386, 345);
            this.chart_cpkNorm2.TabIndex = 89;
            this.chart_cpkNorm2.Text = "chart1";
            this.chart_cpkNorm2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart_cpkNorm2_MouseDoubleClick);
            // 
            // panel_Cpk
            // 
            this.panel_Cpk.Controls.Add(this.chart_Rowdata);
            this.panel_Cpk.Controls.Add(this.dataGridView2);
            this.panel_Cpk.Controls.Add(this.chart_cpkNorm1);
            this.panel_Cpk.Controls.Add(this.listView_Rowdata);
            this.panel_Cpk.Controls.Add(this.dataGridView1);
            this.panel_Cpk.Location = new System.Drawing.Point(395, 12);
            this.panel_Cpk.Name = "panel_Cpk";
            this.panel_Cpk.Size = new System.Drawing.Size(772, 682);
            this.panel_Cpk.TabIndex = 1;
            // 
            // chart_Rowdata
            // 
            this.chart_Rowdata.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            this.chart_Rowdata.ChartAreas.Add(chartArea2);
            this.chart_Rowdata.Location = new System.Drawing.Point(0, -2);
            this.chart_Rowdata.Name = "chart_Rowdata";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            this.chart_Rowdata.Series.Add(series2);
            this.chart_Rowdata.Size = new System.Drawing.Size(772, 158);
            this.chart_Rowdata.TabIndex = 94;
            this.chart_Rowdata.Text = "chart1";
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.GridColor = System.Drawing.Color.Black;
            this.dataGridView2.Location = new System.Drawing.Point(0, 590);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(772, 92);
            this.dataGridView2.TabIndex = 98;
            // 
            // chart_cpkNorm1
            // 
            this.chart_cpkNorm1.BackColor = System.Drawing.SystemColors.Control;
            chartArea3.Name = "ChartArea1";
            this.chart_cpkNorm1.ChartAreas.Add(chartArea3);
            this.chart_cpkNorm1.Location = new System.Drawing.Point(0, 160);
            this.chart_cpkNorm1.Name = "chart_cpkNorm1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            this.chart_cpkNorm1.Series.Add(series3);
            this.chart_cpkNorm1.Size = new System.Drawing.Size(630, 330);
            this.chart_cpkNorm1.TabIndex = 95;
            this.chart_cpkNorm1.Text = "chart1";
            // 
            // listView_Rowdata
            // 
            this.listView_Rowdata.BackColor = System.Drawing.SystemColors.Control;
            this.listView_Rowdata.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_Rowdata.HideSelection = false;
            this.listView_Rowdata.Location = new System.Drawing.Point(639, 160);
            this.listView_Rowdata.Name = "listView_Rowdata";
            this.listView_Rowdata.Size = new System.Drawing.Size(133, 429);
            this.listView_Rowdata.TabIndex = 96;
            this.listView_Rowdata.UseCompatibleStateImageBehavior = false;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 497);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(630, 92);
            this.dataGridView1.TabIndex = 97;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 732);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // SubMyCpk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 732);
            this.Controls.Add(this.panel_Cpk);
            this.Controls.Add(this.panel_NormDist);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "SubMyCpk";
            this.Text = "SubMyCpk";
            this.Load += new System.EventHandler(this.SubMyCpk_Load);
            this.SizeChanged += new System.EventHandler(this.SubMyCpk_SizeChanged);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SubMyCpk_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.SubMyCpk_Resize);
            this.panel_NormDist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_cpkNorm2)).EndInit();
            this.panel_Cpk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Rowdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cpkNorm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_NormDist;
        private System.Windows.Forms.Panel panel_Cpk;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_cpkNorm2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Rowdata;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_cpkNorm1;
        public System.Windows.Forms.ListView listView_Rowdata;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
    }
}