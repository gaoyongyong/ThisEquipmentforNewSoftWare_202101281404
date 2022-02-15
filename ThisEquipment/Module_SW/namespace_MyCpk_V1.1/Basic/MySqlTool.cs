using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCpk
{
    /// <summary>
    /// MySql数据库操作类
    /// </summary>
    public static class MySqlTool
    {
        /// <summary>
        /// 获取字符串连接
        /// "Database='aphz_autolinedatabase';Data Source='127.0.0.1';port=3306;User Id='hzp';Password='Newuser123';charset='utf8';pooling=true;SSLmode=none;allowPublicKeyRetrieval=true;"
        /// </summary>
        //public string connectStringForOperate = ConfigurationManager.AppSettings["MySqlConnectionStringForOperate"];
        private static string connectStringForOperate = "Database='aphz_CPKDataBase';Data Source='127.0.0.1';port=3306;User Id='root';Password='Newuser123';charset='utf8';pooling=true;SSLmode=none;allowPublicKeyRetrieval=true;";
        /// <summary>
        /// 获取字符串连接
        /// "Database='sys';Data Source='127.0.0.1';port=3306;User Id='hzp';Password='Newuser123';charset='utf8';pooling=true;SSLmode=none;allowPublicKeyRetrieval=true;"
        /// </summary>
        //public string connectStringForCreateSchema = ConfigurationManager.AppSettings["MySqlConnectionStringForCreateSchema"];
        private static string connectStringForCreateSchema = "Database='sys';Data Source='127.0.0.1';port=3306;User Id='root';Password='Newuser123';charset='utf8';pooling=true;SSLmode=none;allowPublicKeyRetrieval=true;";

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="strSql"> 需要执行的Sql </param>
        /// <returns> true为执行成功，false为执行失败 </returns>
        public static bool CreateSchema(string strSql)
        {
            bool status = true;
            MySqlTransaction mySqlTransaction = null;
            MySqlConnection mySqlConnection = new MySqlConnection();
            MySqlCommand mySqlCommand;
            try
            {
                mySqlConnection = new MySqlConnection(connectStringForCreateSchema);
                if (mySqlConnection.State == ConnectionState.Closed)
                {
                    mySqlConnection.Open();
                }

                mySqlCommand = mySqlConnection.CreateCommand();
                mySqlTransaction = mySqlConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                mySqlCommand.Transaction = mySqlTransaction;

                string temp = strSql;
                mySqlCommand.CommandText = strSql.Trim();
                mySqlCommand.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                if (mySqlTransaction != null)
                {
                    mySqlTransaction.Rollback();
                }
                MessageBox.Show("CreateSchema Error:\r\n" + ex.ToString());
                status = false;
            }
            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// 判断数据库是否存在
        /// </summary>
        /// <param name="strSql"> 需要执行的Sql </param>
        /// <returns> 返回dataset </returns>
        public static DataSet CheckSchema(string strSql)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter SqlAdapter;
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon.ConnectionString = connectStringForCreateSchema;
                if (SqlCon.State == ConnectionState.Closed)
                {
                    SqlCon.Open();
                }
                SqlAdapter = new MySqlDataAdapter(strSql, SqlCon);
                SqlAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CheckSchema Error:\r\n" + ex.ToString());
                ds = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return ds;
        }

        private static object  lockExecutelist = new object();

        /// <summary>
        /// 执行对应的Sql
        /// </summary>
        /// <param name="strSqls"> 需要执行的Sqls </param>
        /// <returns> true为执行成功，false为执行失败 </returns>
        public static bool Execute(List<string> strSqls)
        {
            lock (lockExecutelist)
            {
                bool status = true;
                MySqlTransaction mySqlTransaction = null;
                MySqlConnection mySqlConnection = new MySqlConnection();
                MySqlCommand mySqlCommand;
                try
                {
                    mySqlConnection = new MySqlConnection(connectStringForOperate);
                    if (mySqlConnection.State == ConnectionState.Closed)
                    {
                        mySqlConnection.Open();
                    }

                    mySqlCommand = mySqlConnection.CreateCommand();
                    mySqlTransaction = mySqlConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    mySqlCommand.Transaction = mySqlTransaction;

                    foreach (string strsql in strSqls)
                    {
                        string sql = strsql;
                        mySqlCommand.CommandText = strsql.Trim();
                        mySqlCommand.ExecuteNonQuery();
                    }
                    mySqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (mySqlTransaction != null)
                    {
                        mySqlTransaction.Rollback();
                    }
                    MessageBox.Show("Execute list Error:\r\n" + ex.ToString());
                    status = false;
                }
                finally
                {
                    if (mySqlConnection.State == ConnectionState.Open)
                    {
                        mySqlConnection.Close();
                    }
                }
                return status;
            }
        }
        private static object lockExecute = new object();

        public static bool Execute(string strSql)
        {
            lock (lockExecute)
            {
                bool status = true;
                MySqlTransaction mySqlTransaction = null;
                MySqlConnection mySqlConnection = new MySqlConnection();
                MySqlCommand mySqlCommand;
                try
                {
                    mySqlConnection = new MySqlConnection(connectStringForOperate);
                    if (mySqlConnection.State == ConnectionState.Closed)
                    {
                        mySqlConnection.Open();
                    }

                    mySqlCommand = mySqlConnection.CreateCommand();
                    mySqlTransaction = mySqlConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    mySqlCommand.Transaction = mySqlTransaction;

                    string temp = strSql;
                    mySqlCommand.CommandText = strSql.Trim();
                    mySqlCommand.ExecuteNonQuery();
                    mySqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (mySqlTransaction != null)
                    {
                        mySqlTransaction.Rollback();
                    }
                    MessageBox.Show("Execute string Error:\r\n" + ex.ToString());

                    status = false;
                }
                finally
                {
                    if (mySqlConnection.State == ConnectionState.Open)
                    {
                        mySqlConnection.Close();
                    }
                }
                return status;
            }
        }

        private static object lockGetDataSet1 = new object();
        /// <summary>
        /// 获取dataset
        /// </summary>
        /// <param name="strSql"> 需要执行的Sql </param>
        /// <param name="start">  开始数 </param>
        /// <param name="count">  数据个数 </param>
        /// <returns> 返回dataset </returns>
        public static DataSet GetDataSet(string strSql, int start, int count)
        {
            lock (lockGetDataSet1)
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter SqlAdapter;
                MySqlConnection SqlCon = new MySqlConnection();
                try
                {
                    SqlCon.ConnectionString = connectStringForOperate;
                    if (SqlCon.State == ConnectionState.Closed)
                    {
                        SqlCon.Open();
                    }
                    SqlAdapter = new MySqlDataAdapter(strSql, SqlCon);
                    SqlAdapter.Fill(ds, start, count, "table");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GetDataSetcount Error:\r\n" + ex.ToString());
                    ds = null;
                }
                finally
                {
                    if (SqlCon.State == ConnectionState.Open)
                    {
                        SqlCon.Close();
                    }
                }
                return ds;
            }
        }

       private static object lockGetDataSet = new object();
        /// <summary>
        /// 获取dataset
        /// </summary>
        /// <param name="strSql"> 需要执行的Sql </param>
        /// <returns> 返回dataset </returns>
        public static DataSet GetDataSet(string strSql)
        {
            lock (lockGetDataSet)
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter SqlAdapter;
                MySqlConnection SqlCon = new MySqlConnection();
                try
                {
                    SqlCon.ConnectionString = connectStringForOperate;
                    if (SqlCon.State == ConnectionState.Closed)
                    {
                        SqlCon.Open();
                    }
                    SqlAdapter = new MySqlDataAdapter(strSql, SqlCon);
                    SqlAdapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GetDataSet Error:\r\n" + ex.Message.ToString());
                    ds = null;
                }
                finally
                {
                    if (SqlCon.State == ConnectionState.Open)
                    {
                        SqlCon.Close();
                    }
                }
                return ds;
            }
        }

        /// <summary>
        /// 判断是否有返回数据
        /// </summary>
        /// <param name="strSql"> 需要执行的Sql </param>
        /// <returns> 0为无数据，1为有数据 </returns>
        public static byte Search(string strSql)
        {
            byte status = 0;
            MySqlCommand SqlCmd;
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon.ConnectionString = connectStringForOperate;
                if (SqlCon.State == ConnectionState.Closed)
                {
                    SqlCon.Open();
                }
                SqlCmd = new MySqlCommand(strSql.Trim(), SqlCon);
                if (SqlCmd.ExecuteScalar() == null)
                {
                    status = 0;
                }
                else
                {
                    status = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error:\r\n" + ex.ToString());
                status = 2;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// 调用存储过程，带参数
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static DataSet execution(string procedureName, IDictionary<string, string> Parameters)
        {
            MySqlConnection SqlCon = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            try
            {

                SqlCon.ConnectionString = connectStringForOperate;

                MySqlCommand mysqlcom = new MySqlCommand(procedureName, SqlCon);
                mysqlcom.CommandType = CommandType.StoredProcedure;//设置调用的类型为存储过程 

                if (Parameters == null)
                {
                    return null;
                }
                foreach (string k in Parameters.Keys)
                {
                    mysqlcom.Parameters.Add(k, MySqlDbType.VarChar, 20).Value = Parameters[k];//参数名，参数类型，长度和参数值

                }

                if (SqlCon.State == ConnectionState.Closed)
                {
                    SqlCon.Open();
                }
                mysqlcom.ExecuteNonQuery();
                adapter.SelectCommand = mysqlcom;
                adapter.Fill(ds, procedureName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Getprocedure Error:\r\n" + ex.Message.ToString());
                ds = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return ds;
        }
    }
}
