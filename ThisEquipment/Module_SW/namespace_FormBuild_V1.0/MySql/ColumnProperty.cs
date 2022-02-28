using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.FormBuild.MySql
{
    /// <summary>
    /// 列属性
    /// </summary>
    public class ColumnProperty
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName;

        /// <summary>
        /// 是否为空
        /// </summary>
        public string IsNullable;

        /// <summary>
        /// 类型
        /// </summary>
        public string ColumnType;

        /// <summary>
        /// 主键
        /// </summary>
        public string ColumnKey;
    }
}
