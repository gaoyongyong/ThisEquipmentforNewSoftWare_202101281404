using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;   //new using 
using System.Windows.Forms;
using System.Data;


namespace User
{
    class SysUserDBUtil
    {
        public static string dbName = "UserParameters.db";
        public static string dbPassword = "123456";
        // static string thispath = Application.StartupPath;
       // static string thispath = @"D:\Program Files\ThisEquipment\Database\SwParameter";
        static string thispath = Environment.CurrentDirectory;
        public static string _connectionString = "Data Source=" + thispath + "\\" + dbName + ";password=" + dbPassword;
        public static SQLiteConnection _connection = new SQLiteConnection(_connectionString);

        /// <summary>
        /// Connection DB
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetConnection()
        {
            
            try
            {
                _connection.Open();
                return _connection;
            }
            catch (Exception ex)
            {
                CloseDB();
                return _connection;
                //throw new UserException("Database opening exception！" + ex.Message);
            }
        }

        /// <summary>
        /// Close DB
        /// </summary>
        /// <param name="conn"></param>
        public static void CloseDB()
        {
            if (_connection.State == ConnectionState.Connecting)
            {
                try
                {
                    _connection.Close();
                    SQLiteConnection.ClearAllPools();
                }
                catch (System.Exception ex)
                {
                    throw new UserException("Database closing exception！" + ex.Message);
                }
            }
        }



        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
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

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SQLiteParameter[] cmdParms)
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
        /// Exists-strSql-cmdParms      ??
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool Exists(string strSql, params SQLiteParameter[] cmdParms)
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
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SQLiteParameter[] cmdParms)
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
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms)
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
    }
}
