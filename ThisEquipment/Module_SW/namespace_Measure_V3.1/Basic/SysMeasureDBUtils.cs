using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;   //new using 
using log4net;
using System.Windows.Forms;
using System.Data;
using System.Threading;



namespace Measure
{
    public class SysMeasureDBUtils
    {
        private string prjName = null;
        public string dbName = null;
        public string dbPassword = null;
        public string thispath = null;
        public string _connectionString = null;
        public SQLiteConnection _connection = null;
        public bool db_read_lock = false;
        public bool db_write_lock = false;


        public SysMeasureDBUtils(string prjNameInput)
        {
            prjName = prjNameInput;
            dbName = "Measure.db";
            dbPassword = "123456";
            thispath = @"D:\Program Files\ThisEquipment\PrjDatabase\Project\" + prjName;
            _connectionString = "Data Source=" + thispath + "\\" + dbName + ";password=" + dbPassword;
            _connection = new SQLiteConnection(_connectionString);
        }


        /// <summary>
        /// Connection DB
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetConnection()
        {
            //SQLiteConnection conn = null;
            //string strSQLiteDB = Environment.CurrentDirectory;
            try
            {

                _connection.Open();
                return _connection;
            }
            catch (Exception ex)
            {
                CloseDB(_connection);
                throw new UserException("Database opening exception！" + ex.Message);
            }
        }


        /// <summary>
        /// Close DB
        /// </summary>
        /// <param name="conn"></param>
        public void CloseDB(SQLiteConnection conn)
        {
            if (conn.State == ConnectionState.Connecting)
            {
                try
                {
                    conn.Close();
                    SQLiteConnection.ClearAllPools();
                }
                catch (System.Exception ex)
                {
                    throw new UserException("Database closing exception！" + ex.Message);
                }
            }
        }



        #region DataGridView绑定DataSource
        /// <summary>
        /// DataGridView绑定DataSource    方法1
        /// </summary>
        /// <param name="dataGridView">指定DataGridView</param>
        /// <param name="dataAdapter"></param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">表名</param>
        public DataTable DataSourceBindToDataGridView(DataGridView dataGridView,
            out SQLiteDataAdapter dataAdapter,
            string dbName,
            string tableName,
            string condition = "")
        {

            SQLiteConnection conn = GetConnection();
            SQLiteCommand selectCommand = null;

            SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();

            selectCommand = conn.CreateCommand();
            selectCommand.CommandText = "SELECT * FROM " + tableName;

            if (condition != "" && condition != null)
            {
                selectCommand.CommandText = "SELECT * FROM " + tableName + " where " + condition;
            }

            dataAdapter = new SQLiteDataAdapter();
            dataAdapter.SelectCommand = selectCommand;
            DataTable dt = new DataTable();
            try
            {
                dataAdapter.Fill(dt);
                dataGridView.DataSource = dt.DefaultView;

                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(dataAdapter);
                dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                dataAdapter.InsertCommand = builder.GetInsertCommand();
                dataAdapter.DeleteCommand = builder.GetDeleteCommand();

                return dt;
            }
            catch (Exception e)
            {
                //m_Logger.Error("数据源绑定Datagridview失败！" + e.Message);
                return null;
            }
        }



        /// <summary>
        /// DataGridView绑定DataSource    方法2
        /// </summary>
        /// <param name="dataGridView">指定DataGridView</param>
        /// <param name="dataAdapter"></param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">筛选条件</param>
        /// <param name="fields">字段</param>
        public DataTable DataSourceBindToDataGridView(DataGridView dataGridView,
            out SQLiteDataAdapter dataAdapter,
            string dbName,
            string tableName,
            string[] fields,
            string[] strWhere)
        {
            SQLiteConnection conn = GetConnection();
            SQLiteCommand selectCommand = null;

            SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();

            selectCommand = conn.CreateCommand();
            selectCommand.CommandText = "SELECT * FROM " + tableName + " WHERE 1=1";
            for (int i = 0; i < fields.Length; i++)
            {
                selectCommand.CommandText += " and " + fields[i] + " = '" + strWhere[i] + "'";
            }
            dataAdapter = new SQLiteDataAdapter();
            dataAdapter.SelectCommand = selectCommand;
            DataTable dt = new DataTable();
            try
            {
                dataAdapter.Fill(dt);
                dataGridView.DataSource = dt;

                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(dataAdapter);
                dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                dataAdapter.InsertCommand = builder.GetInsertCommand();
                dataAdapter.DeleteCommand = builder.GetDeleteCommand();

                return dt;
            }
            catch (Exception e)
            {
                //m_Logger.Error("数据源绑定Datagridview失败！" + e.Message);
                return null;
            }
        }

        #endregion


        #region 删除选中DataGridView列的数据???
        /// <summary>
        /// 删除选中DataGridView列的数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="dgvSelectedRowList"></param>
        public void DeleteToInputSettingTable(SQLiteConnection conn, List<string> dgvSelectedRowList)
        {
            string sql = "DELETE FROM InputSetting WHERE " + "Input名称 = " + "'" + dgvSelectedRowList[1] + "'";
            Log.FileUtils.WriteLogToTxt(sql);
            SQLiteCommand cmdInsert = new SQLiteCommand(sql, conn);
            try
            {
                cmdInsert.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                CloseDB(conn);
                throw new UserException("删除InputSetting表中数据时发生异常！" + ex.Message);
            }
        }
        #endregion



        #region 公用方法
        /// <summary>
        /// FieldName
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ") from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }


        /// <summary>
        /// Exists-strSql           //指定一个子查询，检测行的存在。
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Exists-strSql-cmdParms      ??
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public bool Exists(string strSql, params SQLiteParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// ClearTable-tableName    
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool ClearTable(string tableName)
        {
            string sql = "delete from " + tableName;
            try
            {
                ExecuteSql(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion



        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数        ??
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString)
        {
            //using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(SQLString, _connection))
                {
                    try
                    {
                        if (_connection.State != ConnectionState.Open)
                            _connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        _connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。  ??
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                SQLiteTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, string content)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLString, connection);
                SQLiteParameter myParameter = new SQLiteParameter("@content", DbType.String);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }



        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(strSQL, connection);
                SQLiteParameter myParameter = new SQLiteParameter("@fs", DbType.Binary);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }



        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SQLite.SQLiteException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回SQLiteDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SQLiteDataReader</returns>
        public SQLiteDataReader ExecuteReader(string strSQL)
        {
            SQLiteConnection connection = new SQLiteConnection(_connectionString);
            SQLiteCommand cmd = new SQLiteCommand(strSQL, connection);
            try
            {
                connection.Open();
                SQLiteDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString)
        {
            //connection =
            //connectionString = "Data Source=" + Environment.CurrentDirectory + "\\test1.db;password=123456";
            //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    if (_connection.State != ConnectionState.Open)
                        _connection.Open();
                    //WaitForRead();
                    SQLiteDataAdapter command = new SQLiteDataAdapter(SQLString, _connection);
                    command.Fill(ds, "ds");
                    //ReleaseReadLock();
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    //ReleaseReadLock();
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }


        #endregion



        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, params SQLiteParameter[] cmdParms)
        {
            //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, _connection, null, SQLString, cmdParms);
                        //WaitForWrite();
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        //ReleaseWriteLock();
                        return rows;
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        //ReleaseWriteLock();
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SQLiteParameter[]）</param>
        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (SQLiteTransaction trans = conn.BeginTransaction())
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SQLiteParameter[] cmdParms = (SQLiteParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, params SQLiteParameter[] cmdParms)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SQLite.SQLiteException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SQLiteDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SQLiteDataReader</returns>
        public SQLiteDataReader ExecuteReader(string SQLString, params SQLiteParameter[] cmdParms)
        {
            SQLiteConnection connection = new SQLiteConnection(_connectionString);
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SQLiteDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString, params SQLiteParameter[] cmdParms)
        {
            //connectionString = "Data Source=" + Environment.CurrentDirectory + "\\test1.db;password=123456";
            //using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                //WaitForRead();
                SQLiteCommand cmd = new SQLiteCommand();
                PrepareCommand(cmd, _connection, null, SQLString, cmdParms);
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                        //ReleaseReadLock();
                    }
                    catch (System.Data.SQLite.SQLiteException ex)
                    {
                        //ReleaseReadLock();
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

        #region --------------------------------------------------------------------
        public bool WaitForWrite()
        {
            Console.WriteLine("-------------WaitForWrite---------------------");
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            while (db_read_lock != false || db_write_lock != false)
            {
                end = DateTime.Now;
                if (end - start > TimeSpan.FromSeconds(3))
                {
                    Console.WriteLine("等待数据库写超时！");
                    //m_Logger.Error("等待数据库写超时！");
                    break;
                }
                Thread.Sleep(1);
            }
            Console.WriteLine("-------------WaitForWrite " + (end - start).TotalSeconds + "---------------------");
            db_write_lock = true;
            return true;
        }

        public bool WaitForRead()
        {
            Console.WriteLine("-------------WaitForRead---------------------");
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            while (db_write_lock != false)
            {
                end = DateTime.Now;
                if (end - start > TimeSpan.FromSeconds(3))
                {
                    Console.WriteLine("等待数据库读超时！");
                    //m_Logger.Error("等待数据库读超时！");
                    break;
                }
                Thread.Sleep(1);
            }
            Console.WriteLine("-------------WaitForRead " + (end - start).TotalSeconds + "---------------------");
            db_read_lock = true;
            return true;
        }


        public void ReleaseReadLock()
        {
            Console.WriteLine("-------------Read Done---------------------");
            db_read_lock = false;
        }
        public void ReleaseWriteLock()
        {
            Console.WriteLine("-------------Write Done---------------------");
            db_write_lock = false;
        }
        #endregion
    }

}
