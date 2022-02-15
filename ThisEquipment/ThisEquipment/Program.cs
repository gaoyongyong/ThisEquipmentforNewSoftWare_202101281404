using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using MotorsControl;
using Tools;
using Choice;

namespace ThisEquipment
{
    static class Program
    {

        public static Form_Main MainForm;
        public static Form_Main GetMain() 
        {
            if (MainForm == null || MainForm.IsDisposed)
            {
                MainForm = new Form_Main();

            }
            return MainForm;
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
       
            string moduleName = Process.GetCurrentProcess().MainModule.ModuleName;
            string processName = System.IO.Path.GetFileNameWithoutExtension(moduleName);
            Process[] processes = Process.GetProcessesByName(processName);

            bool isRuned = false;
         
           
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "OnlyRunOneInstance", out isRuned);
            if (isRuned)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form_Choice Choice = new Form_Choice();
                Choice.StartPosition = FormStartPosition.CenterScreen;
                Choice.ShowDialog();
                if (Form_Choice.Choice == 0)
                {              
                    Application.Run(GetMain());
                }
                else 
                {
                    ToolSetting.Form_Main ToolSetting = new ToolSetting.Form_Main();
                    ToolSetting.StartPosition = FormStartPosition.CenterScreen;

                    Application.Run(ToolSetting);
                }
             
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("程序已启动!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
