using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using DataBase;
using User;
using Dialog_ProjectChoose;

namespace User
{
    public partial class Dialog_Login : Form
    {

        public static bool isShow = false;

        //变量定义
        SysUserServices sysUserService = new SysUserServices(); //用户名中用到的相关类
        List<string> userNames = new List<string>();            //用户名的集合

        User.SysUserModel userModel = new SysUserModel();   //实例化一个用户模型

        /// <summary>
        /// 构造函数
        /// </summary>
        public Dialog_Login()
        {

            InitializeComponent();

            isShow = true;


        }

        private void Dlg_Login_Load(object sender, EventArgs e)
        {
            //连接数据库，加载用户名
            SysUserDBUtil.GetConnection();
            userNames = sysUserService.GetAllUsername();

            for (int i = 0; i < userNames.Count; i++)
            {
                comboBox1.Items.Add(userNames[i]);
            }

            comboBox1.SelectedItem = comboBox1.Items[1];
            userModel = sysUserService.GetModel("Operater");
            textBox2.Text = userModel.Password;
            SysUserDBUtil.CloseDB();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            
            string userName = comboBox1.Text;
            if (userName == string.Empty)
                return;
            if (sysUserService.Exists(userName))
            {
                userModel = sysUserService.GetModel(userName);
                if (userModel.Password == textBox2.Text)
                {
                    //密码正确
                    SysUser.user = userModel;

                    if (UserLoginEvent != null)
                    {
                        //string[] str = SysUser.user.Authority.Split(',');


                        //if (str[0].ToUpper() == "USER")
                        SysUser.defaultPrjName = IniServices.ReadDefaultPrjName();


                        UserLoginEvent("UserLoginSuccessful");//引发事件
                    }
                    isShow = false;
                    this.Hide();
                    //MessageBox.Show("good!");
                }
                else
                {
                    //密码错误
                    MessageBox.Show("The password is not correct, Pls check again!");
                    UserLoginEvent("UserLoginPasswordIsNotCorrect");//引发事件
                    return;
                }
            }
            else
            {
                MessageBox.Show("The user is not exist, Pls check again!");
                UserLoginEvent("UserLoginUserIsNotExist");//引发事件
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserLoginEvent("UserLoginExit");//引发事件
            //Application.Exit();
            this.Hide();
            isShow = false;

        }



        //---
        //定义委托
        public delegate void MyDelegate(string userLoginStr);
        //定义事件
        public event MyDelegate UserLoginEvent;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
