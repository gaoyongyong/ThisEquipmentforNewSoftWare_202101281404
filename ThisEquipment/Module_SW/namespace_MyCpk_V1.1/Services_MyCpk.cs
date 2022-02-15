//using MysqlMode.DataSheet;
using Measure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCpk
{
    public static class MysqlFunction
    {
        //方法1：插入CPK数据
        public static bool InsertCPKData(ProductionSheet ProductionSheet)
        {
            string Mysql = "INSERT INTO aphz_CPKDataBase.ProductionSheet (ID , Project , SN , Time , Data) " +
                        "values " +
                        "(" +
                        $"'{ProductionSheet.ID}' , " +
                        $"'{ProductionSheet.Project}' , " +
                        $"'{ProductionSheet.SN}' , " +
                        $"'{ProductionSheet.Time}' , " +
                        $"'{ProductionSheet.Data}'" +
                        ")";
            if (MySqlTool.Execute(Mysql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //方法2：读取CPK
        public static List<ProductionSheet> SelectCPKData(DateTime StartTime, DateTime EndTime)
        {
            string Mysql = "SELECT * FROM aphz_CPKDataBase.ProductionSheet WHERE aphz_CPKDataBase.ProductionSheet.Time " +
                           "BETWEEN " +
                           $"'{StartTime}' AND '{EndTime}' " +
                           "ORDER BY aphz_CPKDataBase.ProductionSheet.ID DESC";
            List<ProductionSheet> ProductionSheetS = new List<ProductionSheet>();
            try
            {
                DataTable dataTable = MySqlTool.GetDataSet(Mysql).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ProductionSheet ProductionSheet = new ProductionSheet()
                        {
                            ID = (!dataTable.Rows[i].IsNull("ID")) ? dataTable.Rows[i]["ID"].ToString() : "",
                            SN = (!dataTable.Rows[i].IsNull("SN")) ? dataTable.Rows[i]["SN"].ToString() : "",
                            Project = (!dataTable.Rows[i].IsNull("Project")) ? dataTable.Rows[i]["Project"].ToString() : "",
                            Time = (!dataTable.Rows[i].IsNull("Time")) ? Convert.ToDateTime(dataTable.Rows[i]["Time"]) : DateTime.Now,
                            Data = (!dataTable.Rows[i].IsNull("Data")) ? dataTable.Rows[i]["Data"].ToString() : "",
                        };
                        ProductionSheetS.Add(ProductionSheet);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:读取数据出错，{ex.Message}");
            }
            return ProductionSheetS;
        }

        //方法3：读取CPK使用数据个数和项目号
        public static int SelectCPKDataByNumer(double Number,string Project, out List<ProductionSheet> List_ProductionSheet)
        {
            
            string Mysql = $"SELECT* FROM aphz_cpkdatabase.productionsheet WHERE aphz_CPKDataBase.ProductionSheet.Project = '{Project}' order by aphz_CPKDataBase.ProductionSheet.TIME DESC limit "
                           + $"{Number}";
            List<ProductionSheet> ProductionSheetS = new List<ProductionSheet>();
            try
            {
                DataTable dataTable = MySqlTool.GetDataSet(Mysql).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ProductionSheet ProductionSheet = new ProductionSheet()
                        {
                            ID = (!dataTable.Rows[i].IsNull("ID")) ? dataTable.Rows[i]["ID"].ToString() : "",
                            SN = (!dataTable.Rows[i].IsNull("SN")) ? dataTable.Rows[i]["SN"].ToString() : "",
                            Project = (!dataTable.Rows[i].IsNull("Project")) ? dataTable.Rows[i]["Project"].ToString() : "",
                            Time = (!dataTable.Rows[i].IsNull("Time")) ? Convert.ToDateTime(dataTable.Rows[i]["Time"]) : DateTime.Now,
                            Data = (!dataTable.Rows[i].IsNull("Data")) ? dataTable.Rows[i]["Data"].ToString() : "",
                        };
                        ProductionSheetS.Add(ProductionSheet);
                    }
                }
                List_ProductionSheet = ProductionSheetS;
                return 1;
            }
            catch (Exception ex)
            {
                
                List_ProductionSheet = ProductionSheetS;
                return 0;
            }
            
        }
        /// <summary>
        /// 添加一组数据
        /// </summary>
        public static void FUNC_AddCPK()
        {
            if (!TestExcepation.TestThreeData)
            {
                string InSert_Data = "";
                for (int i = 0; i < Measure.ProMeasureSize.Sizes.Count(); i++)
                {
                    double InsertValue = Measure.ProMeasureSize.TestValue[i].Value;
                    if (InSert_Data == "")
                    {
                        InSert_Data = InsertValue.ToString("0.000") + ",";
                    }
                    else
                    {
                        InSert_Data = InSert_Data + InsertValue.ToString("0.000") + ",";
                    }
                }
                //数据库名称
                string[] Address = Dialog_ProjectChoose.ProjectChoose.strMyDBLoad.Split('\\');
                string Project = Address[5];
                //新建插入数据
                ProductionSheet InSert_Production = new ProductionSheet()
                {
                    ID = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    Project = Project,
                    SN = "",
                    Time = DateTime.Now,
                    Data = InSert_Data
                };
                MysqlFunction.InsertCPKData(InSert_Production);
            }

        }
    }

    
}
