using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.FormBuild.PublicClass;

namespace WinForm.FormBuild.UI
{
    public partial class Form_UPHList : Form
    {
        private delegate void dgShowData(ProductCapacity ProductCapacity);
        private dgShowData _wtShowData;
        private void ONShowData(ProductCapacity ProductCapacity)
        {
            Invoke(_wtShowData, ProductCapacity);
        }   
        public Form_UPHList()
        {
            InitializeComponent();

            this.dataGridView_ProductDataDay.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
            this.dataGridView_ProductDataDay.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView_ProductDataDay.Columns[4].DefaultCellStyle.BackColor = Color.White;
            dataGridView_ProductDataDay.ReadOnly = true;
            dataGridView_ProductDataDay.AllowUserToAddRows = false;
            dataGridView_ProductDataDay.AllowUserToDeleteRows = false;
            dataGridView_ProductDataDay.AllowUserToResizeColumns = false;
            dataGridView_ProductDataDay.AllowUserToResizeRows = false;

            _wtShowData = new dgShowData(ShowData);
            FormBuildCommon.NotifyUPHShow += ONShowData;
        }
        private void ShowData(ProductCapacity ProductCapacity)
        {
            List<string> DayTimeSolt = new List<string>();
            List<int> DayUPHCount = new List<int>();
            List<int> DayUPHOK = new List<int>();
            List<int> DayUPHNG = new List<int>();
            List<double> DayUPHYelid = new List<double>();

            List<string> NightTimeSolt = new List<string>();
            List<int> NightUPHCount = new List<int>();
            List<int> NightUPHOK = new List<int>();
            List<int> NightUPHNG = new List<int>();
            List<double> NightUPHYelid = new List<double>();

            for (int i = 0; i < ProductCapacity.TimeSlot.Count; i++)
            {
                if (i < 12)
                {
                    DayTimeSolt.Add(ProductCapacity.TimeSlot[i]);
                    DayUPHOK.Add(ProductCapacity.MachineOK[i]);
                    DayUPHNG.Add(ProductCapacity.MachineNG[i]);
                    DayUPHYelid.Add(ProductCapacity.MachineYield[i]);
                    DayUPHCount.Add(ProductCapacity.MachineCapacity[i]);
                }
                else
                {
                    NightTimeSolt.Add(ProductCapacity.TimeSlot[i]);
                    NightUPHCount.Add(ProductCapacity.MachineCapacity[i]);
                    NightUPHOK.Add(ProductCapacity.MachineOK[i]);
                    NightUPHNG.Add(ProductCapacity.MachineNG[i]);
                    NightUPHYelid.Add(ProductCapacity.MachineYield[i]);
                }
            }

            int DayAllCount = DayUPHCount.Sum(t => t);
            int DayAllOK = DayUPHOK.Sum(t => t);
            int DayAllNG = DayUPHNG.Sum(t => t);
            double DayAllYeild = Math.Round(Convert.ToDouble(((double)DayAllOK * 100 / (double)DayAllCount)), 2);

            int NightAllCount = NightUPHCount.Sum(t => t);
            int NightAllOK = NightUPHOK.Sum(t => t);
            int NightAllNG = NightUPHNG.Sum(t => t);
            double NightAllYeild = Math.Round(Convert.ToDouble(((double)NightAllOK * 100 / (double)NightAllCount)), 2);

            DayTimeSolt.Add("白班合计");
            DayUPHCount.Add(DayAllCount);
            DayUPHOK.Add(DayAllOK);
            DayUPHNG.Add(DayAllNG);
            DayUPHYelid.Add(DayAllYeild);
            NightTimeSolt.Add("夜班合计");
            NightUPHCount.Add(NightAllCount);
            NightUPHOK.Add(NightAllOK);
            NightUPHNG.Add(NightAllNG);
            NightUPHYelid.Add(NightAllYeild);
            dataGridView_ProductDataDay.Rows.Clear();

            for (int i = 0; i < DayTimeSolt.Count; i++)
            {
                string[] rows = {
                                    DayTimeSolt[i],
                                    DayUPHCount[i].ToString(),
                                    DayUPHNG[i].ToString(),
                                    DayUPHYelid[i].ToString(),
                                    "",
                                    NightTimeSolt[i].ToString(),
                                    NightUPHCount[i].ToString(),
                                    NightUPHNG[i].ToString(),
                                    NightUPHYelid[i].ToString()
                                    };
                this.dataGridView_ProductDataDay.Rows.Add(rows);
            }
        }

    }
}
