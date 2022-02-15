using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using ThisEquipment;
using Measure;

namespace namespace_Loading
{
    class LoadingForm
    {

        static Dialog_Loading dialogLoading = null;
        static Dialog_ErrorShow dialogErrorshow = null;

        public static bool isShowDialog_Loading=false;
        public static bool isShowDialog_ErrorShow = false;


        //private void ThreadFunc()
        //{
        //    MethodInvoker mi = new MethodInvoker(this.ShowMsgForm);
        //    this.BeginInvoke(mi);


        //    Thread.Sleep(5000);


        //    MethodInvoker mii = new MethodInvoker(this.CloseMsgForm);
        //    this.BeginInvoke(mii);
        //}
        private static void ShowMsgForm()
        {
            dialogLoading = new Dialog_Loading(textTitle, colorTitle, textText, colorText);
            dialogLoading.Show();
        }
        private static void CloseMsgForm()
        {
            dialogLoading.Close();
            dialogLoading.Dispose();
        }


        private static string textTitle;
        private static Color colorTitle;
        private static string textText;
        private static Color colorText;

        /// <summary>
        /// 线程中打开Loading窗体
        /// </summary>
        /// <param name="obj">父窗体-this</param>
        /// <param name="textTitle1">标题</param>
        /// <param name="colorTitle1">标题字体颜色</param>
        /// <param name="textText1">正文</param>
        /// <param name="colorText1">正文字体颜色</param>
        public static void MethodInvokerShowMsgForm(Form obj, string textTitle1, Color colorTitle1, string textText1, Color colorText1)
        {
            if (!isShowDialog_Loading)
            {
                isShowDialog_Loading = true;
                textTitle = textTitle1;
                colorTitle = colorTitle1;
                textText = textText1;
                colorText = colorText1;


                MethodInvoker mi = new MethodInvoker(ShowMsgForm);
                obj.BeginInvoke(mi);
            }
        }

        /// <summary>
        /// 线程中关闭Loading窗体
        /// </summary>
        /// <param name="obj">父窗体-this</param>
        public static void MethodInvokerCloseMsgForm(Form obj)
        {
            if (isShowDialog_Loading)
            {
                MethodInvoker mii = new MethodInvoker(CloseMsgForm);
                obj.BeginInvoke(mii);

                isShowDialog_Loading = false;
            }
        }

        public static System.Drawing.Image LoadImage(string fileName)

        {

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);



            int byteLength = (int)fileStream.Length;

            byte[] fileBytes = new byte[byteLength];

            fileStream.Read(fileBytes, 0, byteLength);

            fileStream.Close();



            return System.Drawing.Image.FromStream(new MemoryStream(fileBytes));

        }
























        private static void ShowErrForm()
        {
            dialogErrorshow = new Dialog_ErrorShow(textTitle, colorTitle, textText, colorText);
            dialogErrorshow.Show();
        }
        private static void CloseErrForm()
        {
            dialogErrorshow.Close();
            dialogErrorshow.Dispose();
        }


        /// <summary>
        /// 线程中打开ErrForm窗体,如果是检测到Loading窗体在运行，则将其先关闭再打开ErrorShow窗体
        /// </summary>
        /// <param name="obj">父窗体-this</param>
        /// <param name="textTitle1">标题</param>
        /// <param name="colorTitle1">标题字体颜色</param>
        /// <param name="textText1">正文</param>
        /// <param name="colorText1">正文字体颜色</param>
        public static void MethodInvokerShowErrForm(Form obj, string textTitle1, Color colorTitle1, string textText1, Color colorText1)
        {
            //如果是Loading窗体打开，则先将其关闭
            if (isShowDialog_Loading)
            {
                MethodInvokerCloseMsgForm(obj);
            }

            if (!isShowDialog_ErrorShow)
            {
                isShowDialog_ErrorShow = true;

                textTitle = textTitle1;
                colorTitle = colorTitle1;
                textText = textText1;
                colorText = colorText1;

                MethodInvoker mi = new MethodInvoker(ShowErrForm);
                obj.BeginInvoke(mi);
            }
        }

        /// <summary>
        /// 线程中关闭ErrForm窗体
        /// </summary>
        /// <param name="obj">父窗体-this</param>
        public static void MethodInvokerCloseErrForm(Form obj)
        {
            if (isShowDialog_ErrorShow)
            {
                MethodInvoker mii = new MethodInvoker(CloseErrForm);
                obj.BeginInvoke(mii);

                isShowDialog_ErrorShow = false;
            }
        }



       /// <summary>
       /// 超三倍报警带参数
       /// </summary>
       /// <param name="textText1"></param>
       /// <returns></returns>
        public static int Show_ErrFormWithText(string textText1)
        {
           
            //如果是Loading窗体打开，则先将其关闭
            if (isShowDialog_Loading)
            {
                MethodInvokerCloseMsgForm(Program.MainForm);
            }
            if (TestExcepation.TestThreeData)
            {
                if (!isShowDialog_ErrorShow)
                {
                    isShowDialog_ErrorShow = true;

                    textTitle = "警告";
                    colorTitle = Color.Black;
                    textText = textText1;
                    colorText = Color.Black;

                    MethodInvoker mi = new MethodInvoker(ShowErrForm);
                    Program.MainForm.BeginInvoke(mi);
                    
                }
                return 1;
            }
             
            return 0;
        }

        /// <summary>
        /// 连续3次报警
        /// </summary>
        /// <param name="textText1"></param>
        /// <returns></returns>
        public static int Show_Err1FormWithText(string textText1)
        {
            //如果是Loading窗体打开，则先将其关闭
            if (isShowDialog_Loading)
            {
                MethodInvokerCloseMsgForm(Program.MainForm);
            }
            if (TestExcepation.ThreeTimesNG)
            {
                if (!isShowDialog_ErrorShow)
                {
                    isShowDialog_ErrorShow = true;

                    textTitle = "警告";
                    colorTitle = Color.Black;
                    textText = textText1;
                    colorText = Color.Black;

                    MethodInvoker mi = new MethodInvoker(ShowErrForm);
                    Program.MainForm.BeginInvoke(mi);
                    
                }
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 超三倍报警带参数
        /// </summary>
        /// <param name="textText1"></param>
        /// <returns></returns>
        public static int Show_ErrForm()
        {

            //如果是Loading窗体打开，则先将其关闭
            if (isShowDialog_Loading)
            {
                MethodInvokerCloseMsgForm(Program.MainForm);
            }
            if (TestExcepation.TestThreeData)
            {
                if (!isShowDialog_ErrorShow)
                {
                    isShowDialog_ErrorShow = true;

                    textTitle = "警告";
                    colorTitle = Color.Black;
                    textText = "测量数据超过3倍报警，请重测产品！";
                    colorText = Color.Black;

                    MethodInvoker mi = new MethodInvoker(ShowErrForm);
                    Program.MainForm.BeginInvoke(mi);
                    
                }
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// 连续3次报警
        /// </summary>
        /// <param name="textText1"></param>
        /// <returns></returns>
        public static int Show_Err1()
        {
            //如果是Loading窗体打开，则先将其关闭
            if (isShowDialog_Loading)
            {
                MethodInvokerCloseMsgForm(Program.MainForm);
            }
            if (TestExcepation.ThreeTimesNG)
            {
                if (!isShowDialog_ErrorShow)
                {
                    isShowDialog_ErrorShow = true;

                    textTitle = "警告";
                    colorTitle = Color.Black;
                    textText = "产品连续NG超过3次，请重测产品！";
                    colorText = Color.Black;

                    MethodInvoker mi = new MethodInvoker(ShowErrForm);
                    Program.MainForm.BeginInvoke(mi);
                    
                }
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 线程中关闭ErrForm窗体
        /// </summary>
        /// <param name="obj">父窗体-this</param>
        public static void Close_ErrForm()
        {
            if (isShowDialog_ErrorShow)
            {
                MethodInvoker mii = new MethodInvoker(CloseErrForm);
                Program.MainForm.BeginInvoke(mii);

                isShowDialog_ErrorShow = false;
            }
        }


    }
}
