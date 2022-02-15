using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.FormBuild.MySql
{
    /// <summary>
    /// MySql数据库操作类
    /// </summary>
    public class MySqlTool
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DataBaseName = "APHZ_WinFormDataBase";

        /// <summary>
        /// 获取字符串连接
        /// "Database='aphz_autolinedatabase';Data Source='127.0.0.1';port=3306;User Id='hzp';Password='Newuser123';charset='utf8';pooling=true;SSLmode=none;allowPublicKeyRetrieval=true;"
        /// </summary>
        //public string connectStringForOperate = ConfigurationManager.AppSettings["MySqlConnectionStringForOperate"];


        private readonly string connectStringForOperate = "Database='APHZ_WinFormDataBase';Data Source='127.0.0.1';port=3306;User Id='root';Password='Newuser123';charset='utf8mb4';pooling=true;SSLmode=none;allowPublicKeyRetrieval=true;";
        /// <summary>
        /// 获取字符串连接
        /// "Database='sys';Data Source='127.0.0.1';port=3306;User Id='hzp';Password='Newuser123';charset='utf8';pooling=true;SSLmode=none;allowPublicKeyRetrieval=true;"
        /// </summary>
        private readonly string connectStringForCreateSchema = "Database='sys';Data Source='127.0.0.1';port=3306;User Id='root';Password='Newuser123';charset='utf8mb4';pooling=true;SSLmode=none;allowPublicKeyRetrieval=true;";
        /// <summary>
        /// 连接状态
        /// </summary>
        public bool Connected = false;
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="strSql"> 需要执行的Sql </param>
        /// <returns> true为执行成功，false为执行失败 </returns>
        public bool CreateSchema(string strSql)
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
                Connected = true;
            }
            catch (Exception ex)
            {
                if (mySqlTransaction != null)
                {
                    mySqlTransaction.Rollback();
                }
                Connected = false;
                //MessageBox.Show("CreateSchema Error:\r\n" + ex.ToString());
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
        public DataSet CheckSchema(string strSql)
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
                Connected = true;
            }
            catch (Exception ex)
            {
                Connected = false;
                //MessageBox.Show("CheckSchema Error:\r\n" + ex.ToString());
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

        object lockExecutelist = new object();

        /// <summary>
        /// 执行对应的Sql
        /// </summary>
        /// <param name="strSqls"> 需要执行的Sqls </param>
        /// <returns> true为执行成功，false为执行失败 </returns>
        public bool Execute(List<string> strSqls)
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
                    Connected = true;
                }
                catch (Exception ex)
                {
                    if (mySqlTransaction != null)
                    {
                        mySqlTransaction.Rollback();
                    }
                    Connected = false;
                    //MessageBox.Show("Execute list Error:\r\n" + ex.ToString());
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
        object lockExecute = new object();

        public bool Execute(string strSql)
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
                    Connected = true;
                }
                catch (Exception ex)
                {
                    if (mySqlTransaction != null)
                    {
                        mySqlTransaction.Rollback();
                    }
                    Connected = false;
                    // MessageBox.Show("Execute string Error:\r\n" + ex.ToString());
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

        object lockGetDataSet1 = new object();
        /// <summary>
        /// 获取dataset
        /// </summary>
        /// <param name="strSql"> 需要执行的Sql </param>
        /// <param name="start">  开始数 </param>
        /// <param name="count">  数据个数 </param>
        /// <returns> 返回dataset </returns>
        public DataSet GetDataSet(string strSql, int start, int count)
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
                    Connected = true;
                }
                catch (Exception ex)
                {
                    Connected = false;
                    // MessageBox.Show("GetDataSetcount Error:\r\n" + ex.ToString());
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

        object lockGetDataSet = new object();
        /// <summary>
        /// 获取dataset
        /// </summary>
        /// <param name="strSql"> 需要执行的Sql </param>
        /// <returns> 返回dataset </returns>
        public DataSet GetDataSet(string strSql)
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
                    Connected = true;
                }


                catch (Exception ex)
                {
                    Connected = false;
                    // MessageBox.Show("GetDataSet Error:\r\n" + ex.Message.ToString());
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
        public byte Search(string strSql)
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
                Connected = true;
            }
            catch (Exception ex)
            {
                Connected = false;
                // MessageBox.Show("Search Error:\r\n" + ex.ToString());
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
    }

}
