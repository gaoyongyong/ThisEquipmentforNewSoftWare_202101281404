using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialog_ProjectChoose
{
    public class ProjectChoose
    {
        //选中的项目名称
        public static string ProjectName = null;
        //选中的项目名称的参数路径                                       
        public static string strMyDBLoad;

        ////是否结束选择，结束后置true
        //public static bool isFinishChoose = false;

        //public static string strLoad = Application.StartupPath + @"\项目数据库\";
        public static string strLoad = @"D:\Program Files\ThisEquipment\PrjDatabase\Project\";
        //供copy数据库文件夹的目录//数据库文件夹的目录
        // public static string strBackupLoad = Application.StartupPath + @"\备份的数据库";
        public static string strBackupLoad = @"D:\Program Files\ThisEquipment\PrjDatabase\BackupPrjDatabase";

    }
}
