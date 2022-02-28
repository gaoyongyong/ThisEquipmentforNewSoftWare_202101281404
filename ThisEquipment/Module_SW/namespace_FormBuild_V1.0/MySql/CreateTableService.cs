using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.FormBuild.PublicClass;

namespace WinForm.FormBuild.MySql
{
    /// <summary>
    /// 创建表
    /// </summary>
    public static class CreateTableService
    {
        /// <summary>
        /// Mysql数据库类
        /// </summary>
        public static MySqlTool MySqlTool = new MySqlTool();
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string CreateTable(Type type, string DataBaseName)
        {
            string createSql = $"CREATE TABLE `{DataBaseName}`.`" + type.Name + "` (";
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                switch (propertyInfo.PropertyType.Name)
                {
                    case "String":
                        if (propertyInfo.Name == "ID")
                        {
                            createSql += "`" + propertyInfo.Name + "` VARCHAR(80) NOT NULL,";
                        }
                        else
                        {
                            if (propertyInfo.Name.Contains("txt"))
                            {
                                createSql += "`" + propertyInfo.Name + "` TEXT(20000) NULL,";
                            }
                            else if (propertyInfo.Name.Contains("Result"))
                            {
                                createSql += "`" + propertyInfo.Name + "` VARCHAR(10) NULL,";
                            }
                            else
                            {
                                createSql += "`" + propertyInfo.Name + "` VARCHAR(500) NULL,";
                            }
                        }
                        break;
                    case "Int32":
                        createSql += "`" + propertyInfo.Name + "` INT NULL,";
                        break;
                    case "Double":
                        createSql += "`" + propertyInfo.Name + "` DOUBLE NULL,";
                        break;
                    case "DateTime":
                        createSql += "`" + propertyInfo.Name + "` DATETIME NULL,";
                        break;
                }
            }
            if (createSql.Contains("`ID`"))
            {
                createSql += "PRIMARY KEY(`ID`));";
            }
            else
            {
                createSql = createSql.TrimEnd(',');
                createSql += ");";
            }
            return createSql;
        }
        /// <summary>
        /// 更新表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="columnProperties"></param>
        /// <returns></returns>
        private static string UpdateTable(Type type, List<ColumnProperty> columnProperties, string DataBaseName)
        {
            string updateSql = $"ALTER TABLE `{DataBaseName}`.`" + type.Name + "` ";
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (ColumnProperty columnProperty in columnProperties)
            {
                List<PropertyInfo> propertyInfos1 = propertyInfos.Where(o => o.Name == columnProperty.ColumnName).ToList();
                //删除不存在的字段
                if (propertyInfos1.Count == 0)
                {
                    updateSql += "DROP COLUMN `" + columnProperty.ColumnName + "`,";
                }
            }
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                List<ColumnProperty> columnProperties1 = columnProperties.Where(o => o.ColumnName == propertyInfo.Name).ToList();
                //是否需要更新
                if (columnProperties1.Count == 1)
                {
                    //保持主键不变
                    if (propertyInfo.Name == "ID")
                    {
                        continue;
                    }
                    string propertyType = "";
                    string columnType = "";
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "String":
                            if (propertyInfo.Name.Contains("txt"))
                            {
                                propertyType = "text";
                            }
                            else
                            {
                                propertyType = "varchar";
                            }
                            break;
                        case "Int":
                            propertyType = "int";
                            break;
                        case "Double":
                            propertyType = "double";
                            break;
                        case "DateTime":
                            propertyType = "datetime";
                            break;
                    }
                    //类型是否相同
                    if (columnProperties1[0].ColumnType.ToLower().Contains(propertyType))
                    {
                        continue;
                    }
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "String":
                            if (propertyInfo.Name.Contains("ID"))
                            {
                                columnType = "VARCHAR(80)";
                            }
                            else
                            {
                                if (propertyInfo.Name.Contains("txt"))
                                {
                                    columnType = "TEXT(20000)";
                                }
                                else if (propertyInfo.Name.Contains("Result"))
                                {
                                    columnType = "VARCHAR(10)";
                                }
                                else
                                {
                                    columnType = "VARCHAR(500)";
                                }
                            }
                            break;
                        case "Int":
                            columnType = "INT";
                            break;
                        case "Double":
                            columnType = "DOUBLE";
                            break;
                        case "DateTime":
                            columnType = "DATETIME";
                            break;
                    }
                    updateSql += "CHANGE COLUMN `" + propertyInfo.Name + "` `" + propertyInfo.Name + "` " + columnType + " NULL ,";
                }
                //插入新增字段
                else if (columnProperties1.Count == 0)
                {
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "String":
                            if (propertyInfo.Name == "ID")
                            {
                                updateSql += "ADD COLUMN `" + propertyInfo.Name + "` VARCHAR(80) NOT NULL,";
                            }
                            else
                            {
                                if (propertyInfo.Name.Contains("txt"))
                                {
                                    updateSql += "ADD COLUMN `" + propertyInfo.Name + "` TEXT(20000) NULL,";
                                }
                                else if (propertyInfo.Name.Contains("Result"))
                                {
                                    updateSql += "ADD COLUMN `" + propertyInfo.Name + "` VARCHAR(10) NULL,";
                                }
                                else
                                {
                                    updateSql += "ADD COLUMN `" + propertyInfo.Name + "` VARCHAR(500) NULL,";
                                }
                            }
                            break;
                        case "Int32":
                            updateSql += "ADD COLUMN `" + propertyInfo.Name + "` INT NULL,";
                            break;
                        case "Double":
                            updateSql += "ADD COLUMN `" + propertyInfo.Name + "` DOUBLE NULL,";
                            break;
                        case "DateTime":
                            updateSql += "ADD COLUMN `" + propertyInfo.Name + "` DATETIME NULL,";
                            break;
                    }
                }
            }
            if (updateSql.Last() == ',')
            {
                updateSql = updateSql.Remove(updateSql.Length - 1);
            }
            return updateSql;
        }


        /// <summary>
        /// 获取表的列属性
        /// </summary>
        /// <param name="checkColunmsSql">查询语句</param>
        /// <returns></returns>
        private static List<ColumnProperty> GetColumnProperties(string checkColunmsSql)
        {
            List<ColumnProperty> columnProperties = new List<ColumnProperty>();
            try
            {
                DataTable dataTable = MySqlTool.GetDataSet(checkColunmsSql).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ColumnProperty columnProperty = new ColumnProperty()
                        {
                            ColumnName = (!dataTable.Rows[i].IsNull("column_name")) ? dataTable.Rows[i]["column_name"].ToString() : "",
                            IsNullable = (!dataTable.Rows[i].IsNull("is_nullable")) ? dataTable.Rows[i]["is_nullable"].ToString() : "",
                            ColumnType = (!dataTable.Rows[i].IsNull("column_type")) ? dataTable.Rows[i]["column_type"].ToString() : "",
                            ColumnKey = (!dataTable.Rows[i].IsNull("column_key")) ? dataTable.Rows[i]["column_key"].ToString() : "",
                        };
                        columnProperties.Add(columnProperty);
                    }
                }
            }
            catch { }
            return columnProperties;
        }

        /// <summary>
        /// 判断数据库是否存在
        /// </summary>
        public static void CheckSchemaExist(string DataBaseName)
        {
            string selectSql = $"SELECT * FROM information_schema.SCHEMATA WHERE SCHEMA_NAME = '{DataBaseName}'";
            DataSet dataSet = MySqlTool.CheckSchema(selectSql);
            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0)
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        return;
                    }
                    else
                    {
                        string creatSql = $"CREATE SCHEMA `{DataBaseName}`";
                        bool result = MySqlTool.CreateSchema(creatSql);
                        if (!result)
                            MessageBox.Show("Create Schema Fail!");
                    }
                }
                else
                {
                    string creatSql = $"CREATE SCHEMA `{DataBaseName}`";
                    bool result = MySqlTool.CreateSchema(creatSql);
                    if (!result)
                        MessageBox.Show("Create Schema Fail!");
                }
            }
            else
            {
                string creatSql = $"CREATE SCHEMA `{DataBaseName}`";
                bool result = MySqlTool.CreateSchema(creatSql);
                if (!result)
                    MessageBox.Show("Create Schema Fail!");
            }
        }
        /// <summary>
        /// 判断数据表是否存在
        /// </summary>
        /// <param name="Entities"> 表名集合 </param>
        public static void CheckTableExist(List<Type> Entities, string DataBaseName)
        {
            //名称    对应  表名
            //属性名称  对应  列名
            //属性类型  对应  列类型
            //属性名称ID    对应  主键
            //属性名称ID    对应  非空
            foreach (Type entity in Entities)
            {
                string checkSql = $"SELECT * FROM information_schema.Tables WHERE table_schema = '{DataBaseName}' AND TABLE_NAME = '" + entity.Name + "'";
                try
                {
                    DataTable dataTable = MySqlTool.GetDataSet(checkSql).Tables[0];
                    //数据表不存在，需要新建数据表
                    if (dataTable.Rows.Count == 0)
                    {
                        if (entity.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length > 0)
                        {
                            string createSql = CreateTable(entity, DataBaseName);
                            if (!MySqlTool.Execute(createSql))
                                MessageBox.Show($"创建数据表'{entity.Name}'失败!");
                        }
                    }
                    else
                    {
                        string checkColunmsSql = $"SELECT * FROM information_schema.columns WHERE table_schema = '{DataBaseName}' AND table_name = '" + entity.Name + "'";
                        List<ColumnProperty> columnProperties = GetColumnProperties(checkColunmsSql);
                        string updateSql = UpdateTable(entity, columnProperties, DataBaseName);
                        if (!MySqlTool.Execute(updateSql))
                            MessageBox.Show($"更新数据表'{entity.Name}'失败!");
                    }
                }
                catch
                {
                    MessageBox.Show($"检查数据表'{entity.Name}'失败!");
                }
            }
        }
    }

}
