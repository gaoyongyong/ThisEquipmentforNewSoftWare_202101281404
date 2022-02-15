using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using ThisEquipment;

namespace Dialog_ProjectChoose
{
    public partial class Dialog_ProjectChoose : Form
    {

        public static bool isShow = false;

        private string defalutPrjName = string.Empty;
        public Dialog_ProjectChoose(string userAthority)
        {
            InitializeComponent();
            isShow = true;
            string strAthority = userAthority.ToUpper();

            if ((strAthority == "ROOT")|| (strAthority == "ADMINISTRATOR"))
            {
                buttonCREATE.Enabled = true;
                buttonDELETE.Enabled = true;
            }
            else
            {
                buttonCREATE.Enabled = false;
                buttonDELETE.Enabled = false;
            }

            //读取默认项目名称
            defalutPrjName = IniServices.ReadDefaultPrjName();
            //if (listView1.SelectedItems[0].Text == defalutPrjName)
            //{
            //    checkBoxDefaultPrj.Checked = true;
            //}
            //else
            //{
            //    checkBoxDefaultPrj.Checked = true;
            //}

        }




        private void InitProjectName()
        {
            //获取路径下的文件夹名称
            if (Directory.GetDirectories(ProjectChoose.strLoad).Length > 0)
            {
                string strName;                 //完整路径
                string strFinalName;            //路径下的文件夹名
                string strCreatDateTime;        //路径下的文件夹创建时间
                string strLastAccessTime;       //路径下的文件夹上次访问时间
                this.listView1.Items.Clear();
                foreach (string path in Directory.GetDirectories(ProjectChoose.strLoad))
                {
                    strName = path;
                    FileInfo file = new FileInfo(strName);
                    strFinalName = path.Replace(ProjectChoose.strLoad, "");

                    strCreatDateTime = file.CreationTime.ToString();     //文件创建时间
                    strLastAccessTime = file.LastAccessTime.ToString();   //上次访问时间
                                                                          //string c = file.LastWriteTime.ToString();         //上次修改时间

                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = strFinalName;
                    lvItem.SubItems.Add(strCreatDateTime);
                    lvItem.SubItems.Add(strLastAccessTime);
                    listView1.Items.Add(lvItem);
                    listView1.Refresh();
                }
            }
        }




        private void InitListView()
        {
            /*基本功能设置*/
            listView1.View = View.Details;      //Set to details view.细节显示
            listView1.LabelEdit = false;        //允许用户添加编辑条款
            listView1.AllowColumnReorder = true;//Allow the user rearrange columns允许用户从新排列
            listView1.CheckBoxes = false;       //DisPlay CheckBox显示打钩的框
            listView1.FullRowSelect = true;     //整行选择
            listView1.Sorting = SortOrder.None; //排序方式
            listView1.GridLines = true;         //显示网格线
            listView1.MultiSelect = false;      //禁止ListView选择多项
                                                //listView1.Dock = DockStyle.Top;    //listView在窗体的显示方式

            /*添加列标题*/
            listView1.Columns.Add("项目名称", listView1.Width / 4 * 2, HorizontalAlignment.Left);//Add a column with width 100 and left alignment.
            listView1.Columns.Add("项目创建时间", listView1.Width / 4 * 1, HorizontalAlignment.Left);
            listView1.Columns.Add("上次访问时间", listView1.Width / 4 * 1, HorizontalAlignment.Left);
        }



        //获取鼠标单击事件：给ListView在鼠标右键选中的情况下添加浮动菜单
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //右键浮动菜单事件
            if (e.Button == MouseButtons.Right)//鼠标右键，跳出浮动控件
            {
                ProjectChoose.ProjectName = listView1.SelectedItems[0].Text;
                textBoxProgram.Text = ProjectChoose.ProjectName;
                Point p = new Point(e.X, e.Y);
                contextMenuStrip1.Show(listView1, p);

                if (textBoxProgram.Text == defalutPrjName)
                {
                    checkBoxDefaultPrj.Checked = true;
                }
                else
                {
                    checkBoxDefaultPrj.Checked = false;
                }
            }

            //左键
            if (e.Button == MouseButtons.Left)
            {
                ProjectChoose.ProjectName = listView1.SelectedItems[0].Text;
                textBoxProgram.Text = ProjectChoose.ProjectName;

                if (textBoxProgram.Text == defalutPrjName)
                {
                    checkBoxDefaultPrj.Checked = true;
                }
                else
                {
                    checkBoxDefaultPrj.Checked = false;
                }
            }

        }
        /********************选择浮动按钮********************/
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectChoose.ProjectName = listView1.SelectedItems[0].Text;
                ProjectChoose.strMyDBLoad = ProjectChoose.strLoad + ProjectChoose.ProjectName;
                //这里写打开文件夹下的数据库，数据初始化
                //。。。。。。
                MessageBox.Show("你选中的项目名称是：" + ProjectChoose.ProjectName);
            }
            catch
            {
                MessageBox.Show("请选择选择的项目名称!");
            }

        }
        /********************新建项目********************/
        private void buttonCREATE_Click(object sender, EventArgs e)
        {
            //C#复制一个文件夹，过程：新建一个文件夹，将文件夹下的东西全部copy到新建的文件夹下面
            try
            {
                string newProgramLoad = ProjectChoose.strLoad + textBoxProgram.Text;
                if (!Directory.Exists(newProgramLoad))                                      //文件不存在
                {
                    Directory.CreateDirectory(newProgramLoad);                              //新建文件夹
                                                                                            //string[] filenames = Directory.GetFileSystemEntries(strBackupLoad);     //读取备份的文件夹中所有的子文件和子文件夹
                    string[] filenames = Directory.GetFiles(ProjectChoose.strBackupLoad);                 //读取备份文件夹中所有的子文件
                    foreach (string file in filenames)
                    {
                        string filenameInnewFolder = file.Substring(file.LastIndexOf("\\") + 1);
                        filenameInnewFolder = newProgramLoad + "\\" + filenameInnewFolder;

                        File.Copy(file, filenameInnewFolder, true);
                    }


                    ProjectChoosedEvent("ProjectCreated_" + textBoxProgram.Text);//引发事件
                }
                else
                {
                    MessageBox.Show("项目已经存在,请重新命名项目名称或者删除原有项目!");
                }
                this.InitProjectName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        /********************删除项目********************/
        private void buttonDELETE_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("是否删除项目文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    string strDeleteFile = listView1.SelectedItems[0].Text;
                    Directory.Delete(ProjectChoose.strLoad + strDeleteFile, true);

                    listView1.Items.Clear();

                    MyDelaySecond(100);
                    this.InitProjectName();
                    textBoxProgram.Text = "";


                    ProjectChoosedEvent("ProjectDeleted_" + strDeleteFile);//引发事件

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /********************选择项目********************/



        //---
        //定义委托
        public delegate void MyDelegate(string strProjectChoose);
        //定义事件
        public event MyDelegate ProjectChoosedEvent;
        private void buttonSELECT_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectChoose.ProjectName = listView1.SelectedItems[0].Text;
                ProjectChoose.strMyDBLoad = ProjectChoose.strLoad + ProjectChoose.ProjectName;   //得到项目路径

                isShow = false;

                //这里写打开文件夹下的数据库，数据初始化   
                //ThisEquipment.Form_Main.ProjectChooseSuccess();
                //modINI<Class_ProjectChoose_Parameter>.ReadINI(ref ProjectChoose.ProjectChoose_Parameter);


                //如果选择成默认的User启动项目，则将项目名称写入INI
                if(checkBoxDefaultPrj.Checked)
                    IniServices.WriteDefaultPrjName(listView1.SelectedItems[0].Text);

            }
            catch
            {
                MessageBox.Show("请选择的项目名称!");
                isShow = true;
                return;
            }
            
            this.Close();


            if (ProjectChoosedEvent != null)
            {
                ProjectChoosedEvent("ProjectChoosed");//引发事件

            }


        }

        private void buttonEXIT_Click(object sender, EventArgs e)
        {
            isShow = false;
            this.Close();
        }





        /******************************************************************************************/
        /*                                  自定义延时毫秒数                                      */
        /*                                  using System.Runtime.InteropServices;                 */
        /******************************************************************************************/
        [DllImport("kernel32.dll")]
        public static extern uint GetTickCount();

        public static void MyDelaySecond(uint ms)
        {
            uint Start = GetTickCount();
            while (Math.Abs(GetTickCount() - Start) < ms)
            {
                Application.DoEvents();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            buttonSELECT_Click(null, null);
        }

        private void Dialog_ProjectChoose_Load(object sender, EventArgs e)
        {
           
            this.InitListView();                //初始化ListView
            this.InitProjectName();             //初始化项目名称（读取文件夹数）
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
