using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//using DataBase;


//namespace Lian201901.Module.DAL
namespace User
{
    class SysUserServices
    {
        #region 创建系统用户表
        /// <summary>
        /// 创建系统用户表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="conn">数据库连接</param>
        public void CreateUserTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(username varchar(50) PRIMARY KEY UNIQUE NOT NULL, password varchar(50) NOT NULL, loginMode integer NOT NULL)";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }
        #endregion

        #region 根据用户名查询用户密码和登陆模式
        /// <summary>
        /// 根据用户名查询用户密码和登陆模式
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public  List<string> SelectUserByUsername(SQLiteConnection conn, string username)
        {
            List<string> list = new List<string>();
            string password;
            LoginMode loginMode;
            string sql = "SELECT password,loginMode FROM User WHERE username = " + "'" + username + "' ";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    password = reader.GetString(0);
                    list.Add(password);
                    loginMode = (LoginMode)reader.GetInt16(1);
                    list.Add(loginMode.ToString().Trim());
                }
            }
            return list;
        }
        #endregion

        #region  获取所有用户名
        /// <summary>
        /// 获取所有用户名
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllUsername()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select username ");
            strSql.Append(" FROM User ");
            DataSet ds = SysUserDBUtil.Query(strSql.ToString());
            
            List<string> ls = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string s = ds.Tables[0].Rows[i][0].ToString();
                if(string.Empty != s)ls.Add(s);

            }
            return ls;
        }
        #endregion

        #region  自动生成

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User");
            strSql.Append(" where username=@username ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@username", DbType.String,50)};
            parameters[0].Value = username;

            return SysUserDBUtil.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(User.SysUserModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into User(");
            strSql.Append("username,password,loginMode,Authority)");
            strSql.Append(" values (");
            strSql.Append("@username,@password,@loginMode,@Authority)");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@username", DbType.String,50),
					new SQLiteParameter("@password", DbType.String,50),
					new SQLiteParameter("@loginMode", DbType.Int32,4),
					new SQLiteParameter("@Authority", DbType.String,50)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.LoginMode;
            parameters[3].Value = model.Authority;

            //SysUserDBUtil.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(User.SysUserModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update User set ");
            strSql.Append("password=@password,");
            strSql.Append("loginMode=@loginMode,");
            strSql.Append("Authority=@Authority");
            strSql.Append(" where username=@username ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@password", DbType.String,50),
					new SQLiteParameter("@loginMode", DbType.Int32,4),
					new SQLiteParameter("@Authority", DbType.String,50),
					new SQLiteParameter("@username", DbType.String,50)};
            parameters[0].Value = model.Password;
            parameters[1].Value = model.LoginMode;
            parameters[2].Value = model.Authority;
            parameters[3].Value = model.Username;

            //int rows = SQLiteUtils.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
                return false;
            //}
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string username)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User ");
            strSql.Append(" where username=@username ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@username", DbType.String,50)};
            parameters[0].Value = username;

            //int rows = SQLiteUtils.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            return false;
            //}
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string usernamelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User ");
            strSql.Append(" where username in (" + usernamelist + ")  ");
            //int rows =  SQLiteUtils.ExecuteSql(strSql.ToString());
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
                return false;
            //}
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public User.SysUserModel GetModel(string username)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select username,password,loginMode,Authority from User ");
            strSql.Append(" where username=@username ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@username", DbType.String,50)};
            parameters[0].Value = username;

            User.SysUserModel model = new User.SysUserModel();
            DataSet ds = SysUserDBUtil.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Username = ds.Tables[0].Rows[0]["username"].ToString();
                model.Password = ds.Tables[0].Rows[0]["password"].ToString();
                if (ds.Tables[0].Rows[0]["loginMode"].ToString() != "")
                {
                    model.LoginMode = (LoginMode)int.Parse(ds.Tables[0].Rows[0]["loginMode"].ToString());
                }
                model.Authority = ds.Tables[0].Rows[0]["Authority"].ToString();
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
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select username,password,loginMode,Authority ");
        //    strSql.Append(" FROM User ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    return SQLiteUtils.Query(strSql.ToString());
        //}

        #endregion  自动生成




    }
}
