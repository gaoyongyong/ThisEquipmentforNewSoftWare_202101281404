using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace User
{

    public enum LoginMode
    {
        PRODUCTION_MODE = 0,
        ENGINEERING_MODE = 1,
        CPKGRR_MODE = 2
    }

    public enum UserAuthority
    {
        删除用户 = 0,
        添加用户 = 1,
        设置页查看 = 2,
        查看视觉页,
        编辑点位,
        编辑回零,
        添加项目,
        删除项目,
        编辑参数页
    }


    internal class SysUserModel
    {
        private static string m_Username;
        private static string m_Password;
        private static LoginMode m_LoginMode;
        private static string m_Authority;

        public string Username
        {
            get { return m_Username; }
            set { m_Username = value; }
        }
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        public LoginMode LoginMode
        {
            get { return m_LoginMode; }
            set { m_LoginMode = value; }
        }

        /// <summary>
        /// btn 2 - 5 的权限设置，0,0,0,0-1,1,1,1
        /// </summary>
        public string Authority
        {
            get { return m_Authority; }
            set { m_Authority = value; }
        }
    }
}
