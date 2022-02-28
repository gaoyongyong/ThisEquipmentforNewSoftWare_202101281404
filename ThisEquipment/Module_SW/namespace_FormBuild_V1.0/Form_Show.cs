using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.FormBuild.MySql;
using WinForm.FormBuild.PublicClass;
using WinForm.FormBuild.UI;

namespace WinForm.FormBuild
{
    public partial class Form_Show : Form
    {
        Form_ProductCapacity Form_ProductCapacity;


        /// <summary>
        /// 实例名称
        /// </summary>
        string typeName = "ThisEquipment";
        public Form_Show()
        {
            InitializeComponent();
            //this.typeName = TypeName;
            CheckDataBase();
        }
        #region 检查更新数据库
        /// <summary>
        /// 检查数据库
        /// </summary>
        private void CheckDataBase()
        {
            CreateTableService.CheckSchemaExist(CreateTableService.MySqlTool.DataBaseName);
            //确认数据表
            CreateTableService.CheckTableExist(GetAllEntity(), CreateTableService.MySqlTool.DataBaseName);

            Form_ProductCapacity = new Form_ProductCapacity();

            FormBuildCommon.PanelShow(panel_Form, Form_ProductCapacity);
        }
        /// <summary>
        /// 获取当前设备的工位数据实例
        /// </summary>
        /// <returns> </returns>
        private List<Type> GetAllEntity()
        {
            Type[] classes = Assembly.GetExecutingAssembly().GetTypes();
            List<Type> Entities = new List<Type>();
            foreach (Type clas in classes)
            {
                if (clas.FullName.Contains($"MySql.MysqlSheet"))
                    Entities.Add(clas);
            }
            if (Entities.Count == 0)
            {
                MessageBox.Show("未找到对应的实例，请检查实例名称,检查数据表失败!");
            }
            return Entities;
        }
        #endregion
    }
}
