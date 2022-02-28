using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class UserExceptionMessage
    {

        /// <summary>
        /// 提示信息.
        /// </summary>
        public static string MSG0000 = "提示信息";

        /// <summary>
        /// 发生未知错误.
        /// </summary>
        public static string MSG0001 = "发生未知错误。";

        /// <summary>
        /// 数据库联接不正常.
        /// </summary>
        public static string MSG0002 = "数据库联接不正常。";
    }
    class UserException : ApplicationException
    {
        public UserException() { }
        public UserException(string message) : base(message) { }
        public UserException(string message, Exception inner) : base(message, inner) { }


    }
}

