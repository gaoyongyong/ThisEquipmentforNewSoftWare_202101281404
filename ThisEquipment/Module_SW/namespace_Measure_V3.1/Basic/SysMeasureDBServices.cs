using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure
{
    /// <summary>
    /// 数据库服务
    /// </summary>
    class SysMeasureDBServices
    {
        private string prjName = null;
        SysMeasureDBUtils sqlite = null;
        public SysMeasureDBServices(string prjNameInput)
        {
            prjName = prjNameInput;
            sqlite = new SysMeasureDBUtils(prjName);
            GetConnection();
        }

        public void GetConnection()
        {
            sqlite.GetConnection();
        }
        public void CloseDB()
        {
            sqlite.CloseDB(sqlite._connection);
        }


     



        /// <summary>
        /// 通过表格里一个测试项的名称，得到该测试项判定标准
        /// </summary>
        public MeasureSize GetModelBySizeName(string SizeName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * From MeasureSize");
            strSql.Append(" where SizeName=@SizeName ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@SizeName", DbType.String,50)};
            parameters[0].Value = SizeName;

            MeasureSize model = new MeasureSize();
            DataSet ds = sqlite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.SizeName = ds.Tables[0].Rows[0]["SizeName"].ToString();
                model.SizeProperty = ds.Tables[0].Rows[0]["SizeProperty"].ToString();
                if (ds.Tables[0].Rows[0]["NormValue"].ToString() != "")
                {
                    model.NormValue = double.Parse(ds.Tables[0].Rows[0]["NormValue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpperDeviation"].ToString() != "")
                {
                    model.UpperDeviation = double.Parse(ds.Tables[0].Rows[0]["UpperDeviation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LowerDeviation"].ToString() != "")
                {
                    model.LowerDeviation = double.Parse(ds.Tables[0].Rows[0]["LowerDeviation"].ToString());
                } 
                if (ds.Tables[0].Rows[0]["K"].ToString() != "")
                {
                    model.K = double.Parse(ds.Tables[0].Rows[0]["K"].ToString());
                } 
                if (ds.Tables[0].Rows[0]["B"].ToString() != "")
                {
                    model.B = double.Parse(ds.Tables[0].Rows[0]["B"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                {
                    model.IsShow = bool.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
                }
                if(ds.Tables[0].Rows[0]["IsJudging"].ToString() != "")
                {
                    model.IsJudging = bool.Parse(ds.Tables[0].Rows[0]["IsJudging"].ToString());
                }
              
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到表格里测试项判定标准的集合，测试内容中的所有项的判定标准
        /// </summary>
        ///// <param name="prject"></param>
        /// <returns></returns>
        public List<MeasureSize> GetAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * From MeasureSize");
            SQLiteParameter[] parameters = {
					new SQLiteParameter()};
            List<MeasureSize> measureSizeList = new List<MeasureSize>();
            DataSet ds = sqlite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MeasureSize model = new MeasureSize();
                    if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                    }
                    model.SizeName = ds.Tables[0].Rows[i]["SizeName"].ToString();
                    model.SizeProperty = ds.Tables[0].Rows[i]["SizeProperty"].ToString();
                    if (ds.Tables[0].Rows[i]["NormValue"].ToString() != "")
                    {
                        model.NormValue = double.Parse(ds.Tables[0].Rows[i]["NormValue"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["UpperDeviation"].ToString() != "")
                    {
                        model.UpperDeviation = double.Parse(ds.Tables[0].Rows[i]["UpperDeviation"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LowerDeviation"].ToString() != "")
                    {
                        model.LowerDeviation = double.Parse(ds.Tables[0].Rows[i]["LowerDeviation"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["K"].ToString() != "")
                    {
                        model.K = double.Parse(ds.Tables[0].Rows[i]["K"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["B"].ToString() != "")
                    {
                        model.B = double.Parse(ds.Tables[0].Rows[i]["B"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                    {
                        model.IsShow = bool.Parse(ds.Tables[0].Rows[i]["IsShow"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["IsJudging"].ToString() != "")
                    {
                        model.IsJudging = bool.Parse(ds.Tables[0].Rows[i]["IsJudging"].ToString());
                    }
                    measureSizeList.Add(model);

                }
                return measureSizeList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到表格里(显示的)测试项判定标准的集合，测试内容中的所有(显示的)项的判定标准
        /// </summary>
        /// <returns></returns>
        public List<MeasureSize> GetAllByIsShow()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * From MeasureSize");
            SQLiteParameter[] parameters = {
					new SQLiteParameter()};
            List<MeasureSize> measureSizeList = new List<MeasureSize>();
            DataSet ds = sqlite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MeasureSize model = new MeasureSize();
                    if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                    }
                    model.SizeName = ds.Tables[0].Rows[i]["SizeName"].ToString();
                    model.SizeProperty = ds.Tables[0].Rows[i]["SizeProperty"].ToString();
                    if (ds.Tables[0].Rows[i]["NormValue"].ToString() != "")
                    {
                        model.NormValue = double.Parse(ds.Tables[0].Rows[i]["NormValue"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["UpperDeviation"].ToString() != "")
                    {
                        model.UpperDeviation = double.Parse(ds.Tables[0].Rows[i]["UpperDeviation"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LowerDeviation"].ToString() != "")
                    {
                        model.LowerDeviation = double.Parse(ds.Tables[0].Rows[i]["LowerDeviation"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["K"].ToString() != "")
                    {
                        model.K = double.Parse(ds.Tables[0].Rows[i]["K"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["B"].ToString() != "")
                    {
                        model.B = double.Parse(ds.Tables[0].Rows[i]["B"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                    {
                        string a = ds.Tables[0].Rows[i]["IsShow"].ToString();
                        model.IsShow = bool.Parse(ds.Tables[0].Rows[i]["IsShow"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["IsJudging"].ToString() != "")
                    {
                        model.IsJudging = bool.Parse(ds.Tables[0].Rows[i]["IsJudging"].ToString());
                    }

                    if (model.IsShow == true)
                    {
                        measureSizeList.Add(model);
                    }
                }
                return measureSizeList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到表格里(判定的)测试项判定标准的集合，测试内容中的所有(判定的)项的判定标准
        /// </summary>
        /// <returns></returns>
        public List<MeasureSize> GetAllByIsJudging()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * From MeasureSize");

            List<MeasureSize> measureSizeList = new List<MeasureSize>();
            DataSet ds = sqlite.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MeasureSize model = new MeasureSize();
                    if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                    }
                    model.SizeName = ds.Tables[0].Rows[i]["SizeName"].ToString();
                    model.SizeProperty = ds.Tables[0].Rows[i]["SizeProperty"].ToString();
                    if (ds.Tables[0].Rows[i]["NormValue"].ToString() != "")
                    {
                        model.NormValue = double.Parse(ds.Tables[0].Rows[i]["NormValue"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["UpperDeviation"].ToString() != "")
                    {
                        model.UpperDeviation = double.Parse(ds.Tables[0].Rows[i]["UpperDeviation"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LowerDeviation"].ToString() != "")
                    {
                        model.LowerDeviation = double.Parse(ds.Tables[0].Rows[i]["LowerDeviation"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["K"].ToString() != "")
                    {
                        model.K = double.Parse(ds.Tables[0].Rows[i]["K"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["B"].ToString() != "")
                    {
                        model.B = double.Parse(ds.Tables[0].Rows[i]["B"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                    {
                        model.IsShow = bool.Parse(ds.Tables[0].Rows[i]["IsShow"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["IsJudging"].ToString() != "")
                    {
                        model.IsJudging = bool.Parse(ds.Tables[0].Rows[i]["IsJudging"].ToString());
                    }

                    if (model.IsJudging == true)
                    {
                        measureSizeList.Add(model);
                    }

                }
                return measureSizeList;
            }
            else
            {
                return null;
            }
        }


        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return sqlite.GetMaxID("ID", "MeasureSize");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MeasureSize");
            strSql.Append(" where ID=@ID ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)};
            parameters[0].Value = ID;

            return sqlite.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(MeasureSize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MeasureSize(");
            strSql.Append("ID,SizeName,SizeProperty,NormValue,UpperDeviation,LowerDeviation,K,B,IsShow,IsJudging,project)");
            strSql.Append(" values (");
            strSql.Append("@ID,@SizeName,@SizeProperty,@NormValue,@UpperDeviation,@LowerDeviation,@K,@B,@IsShow,@IsJudging,@Project)");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4),
					new SQLiteParameter("@SizeName", DbType.String,50),
					new SQLiteParameter("@SizeProperty", DbType.String,50),
					new SQLiteParameter("@NormValue", DbType.Decimal,8),
					new SQLiteParameter("@UpperDeviation", DbType.Decimal,8),
					new SQLiteParameter("@LowerDeviation", DbType.Decimal,8),
                    new SQLiteParameter("@K", DbType.Decimal,8),
                    new SQLiteParameter("@B", DbType.Decimal,8),
                    new SQLiteParameter("@IsShow", DbType.Boolean),
                    new SQLiteParameter("@IsJudging", DbType.Boolean),
                    new SQLiteParameter("@Project", DbType.String,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SizeName;
            parameters[2].Value = model.SizeProperty;
            parameters[3].Value = model.NormValue;
            parameters[4].Value = model.UpperDeviation;
            parameters[5].Value = model.LowerDeviation;
            parameters[6].Value = model.K;
            parameters[7].Value = model.B;
            parameters[8].Value = model.IsShow;
            parameters[9].Value = model.IsJudging;
            //parameters[10].Value = model.Project;
            sqlite.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MeasureSize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MeasureSize set ");
            strSql.Append("SizeName=@SizeName,");
            strSql.Append("SizeProperty=@SizeProperty,");
            strSql.Append("NormValue=@NormValue,");
            strSql.Append("UpperDeviation=@UpperDeviation,");
            strSql.Append("LowerDeviation=@LowerDeviation,");
            strSql.Append("K=@K,");
            strSql.Append("B=@B");
            strSql.Append("IsShow=@IsShow,");
            strSql.Append("IsJudging=@IsJudging");
            strSql.Append("project=@Project");
            strSql.Append(" where ID=@ID ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@SizeName", DbType.String,50),
					new SQLiteParameter("@SizeProperty", DbType.String,50),
					new SQLiteParameter("@NormValue", DbType.Decimal,8),
					new SQLiteParameter("@UpperDeviation", DbType.Decimal,8),
					new SQLiteParameter("@LowerDeviation", DbType.Decimal,8),
                    new SQLiteParameter("@K", DbType.Decimal,8),
					new SQLiteParameter("@B", DbType.Decimal,8),
                    new SQLiteParameter("@IsShow", DbType.Boolean),
					new SQLiteParameter("@IsJudging", DbType.Boolean),
                    new SQLiteParameter("@Project", DbType.String,50),
					new SQLiteParameter("@ID", DbType.Int32,4)
                    };
            parameters[0].Value = model.SizeName;
            parameters[1].Value = model.SizeProperty;
            parameters[2].Value = model.NormValue;
            parameters[3].Value = model.UpperDeviation;
            parameters[4].Value = model.LowerDeviation;
            parameters[5].Value = model.K;
            parameters[6].Value = model.B;
            parameters[7].Value = model.IsShow;
            parameters[8].Value = model.IsJudging;
            //parameters[9].Value = model.Project;
            parameters[9].Value = model.ID;

            int rows = sqlite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MeasureSize ");
            strSql.Append(" where ID=@ID ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)};
            parameters[0].Value = ID;

            int rows = sqlite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MeasureSize ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = sqlite.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MeasureSize GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from MeasureSize");
            strSql.Append(" where ID=@ID ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)};
            parameters[0].Value = ID;

            MeasureSize model = new MeasureSize();
            DataSet ds = sqlite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.SizeName = ds.Tables[0].Rows[0]["SizeName"].ToString();
                model.SizeProperty = ds.Tables[0].Rows[0]["SizeProperty"].ToString();
                if (ds.Tables[0].Rows[0]["NormValue"].ToString() != "")
                {
                    model.NormValue = double.Parse(ds.Tables[0].Rows[0]["NormValue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpperDeviation"].ToString() != "")
                {
                    model.UpperDeviation = double.Parse(ds.Tables[0].Rows[0]["UpperDeviation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LowerDeviation"].ToString() != "")
                {
                    model.LowerDeviation = double.Parse(ds.Tables[0].Rows[0]["LowerDeviation"].ToString());
                } if (ds.Tables[0].Rows[0]["K"].ToString() != "")
                {
                    model.K = double.Parse(ds.Tables[0].Rows[0]["K"].ToString());
                } if (ds.Tables[0].Rows[0]["B"].ToString() != "")
                {
                    model.B = double.Parse(ds.Tables[0].Rows[0]["B"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                {
                    model.IsShow = bool.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsJudging"].ToString() != "")
                {
                    model.IsJudging = bool.Parse(ds.Tables[0].Rows[0]["IsJudging"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["project"].ToString() != "")
                //{
                //    model.Project = ds.Tables[0].Rows[0]["project"].ToString();
                //}
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据尺寸名称，得到一个对象实体
        /// </summary>
        public MeasureSize GetModel(string Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from MeasureSize");
            strSql.Append(" where SizeName=@Name ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@Name", DbType.String,50)};
            parameters[0].Value = Name;

            MeasureSize model = new MeasureSize();
            DataSet ds = sqlite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.SizeName = ds.Tables[0].Rows[0]["SizeName"].ToString();
                model.SizeProperty = ds.Tables[0].Rows[0]["SizeProperty"].ToString();
                if (ds.Tables[0].Rows[0]["NormValue"].ToString() != "")
                {
                    model.NormValue = double.Parse(ds.Tables[0].Rows[0]["NormValue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpperDeviation"].ToString() != "")
                {
                    model.UpperDeviation = double.Parse(ds.Tables[0].Rows[0]["UpperDeviation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LowerDeviation"].ToString() != "")
                {
                    model.LowerDeviation = double.Parse(ds.Tables[0].Rows[0]["LowerDeviation"].ToString());
                } if (ds.Tables[0].Rows[0]["K"].ToString() != "")
                {
                    model.K = double.Parse(ds.Tables[0].Rows[0]["K"].ToString());
                } if (ds.Tables[0].Rows[0]["B"].ToString() != "")
                {
                    model.B = double.Parse(ds.Tables[0].Rows[0]["B"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                {
                    model.IsShow = bool.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsJudging"].ToString() != "")
                {
                    model.IsJudging = bool.Parse(ds.Tables[0].Rows[0]["IsJudging"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["project"].ToString() != "")
                //{
                //    model.Project = ds.Tables[0].Rows[0]["project"].ToString();
                //}
                return model;
            }
            else
            {
                return null;
            }
        }
      
        /// 根据工程名称和尺寸名称，得到一个对象实体
        /// </summary>
        /// <param name="Project">工程名称</param>
        /// <param name="SizeName">尺寸名称</param>
        /// <returns></returns>
        public MeasureSize GetModelByProjectNameAndSizeName(string Project,string SizeName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from MeasureSize");
            strSql.Append(" where project=@Project ");
            strSql.Append(" AND SizeName=@SizeName ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@Project", DbType.String,50),
                    new SQLiteParameter("@SizeName", DbType.String,50)};
            parameters[0].Value = Project;
            parameters[1].Value = SizeName;

            MeasureSize model = new MeasureSize();
            DataSet ds = sqlite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.SizeName = ds.Tables[0].Rows[0]["SizeName"].ToString();
                model.SizeProperty = ds.Tables[0].Rows[0]["SizeProperty"].ToString();
                if (ds.Tables[0].Rows[0]["NormValue"].ToString() != "")
                {
                    model.NormValue = double.Parse(ds.Tables[0].Rows[0]["NormValue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpperDeviation"].ToString() != "")
                {
                    model.UpperDeviation = double.Parse(ds.Tables[0].Rows[0]["UpperDeviation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LowerDeviation"].ToString() != "")
                {
                    model.LowerDeviation = double.Parse(ds.Tables[0].Rows[0]["LowerDeviation"].ToString());
                } if (ds.Tables[0].Rows[0]["K"].ToString() != "")
                {
                    model.K = double.Parse(ds.Tables[0].Rows[0]["K"].ToString());
                } if (ds.Tables[0].Rows[0]["B"].ToString() != "")
                {
                    model.B = double.Parse(ds.Tables[0].Rows[0]["B"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                {
                    model.IsShow = bool.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsJudging"].ToString() != "")
                {
                    model.IsJudging = bool.Parse(ds.Tables[0].Rows[0]["IsJudging"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["project"].ToString() != "")
                //{
                //    model.Project = ds.Tables[0].Rows[0]["project"].ToString();
                //}
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM MeasureSize ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return sqlite.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
