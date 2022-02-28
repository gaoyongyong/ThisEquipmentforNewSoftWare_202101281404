using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace ScriptCaculate
{
    public class Service_ScriptCaculate
    {
        #region 1.公有变量
        /// <summary>
        /// Model
        /// </summary>
        public Model_ScriptCaculate Model_ScriptCaculate;
        #endregion
        #region 2.私有变量
        /// <summary>
        /// 输入的MCS点位值
        /// </summary>
        public static point[] MCSPoint = new point[50];
        /// <summary>
        /// 输入sensor返回值
        /// </summary>
        public static string[][] indexBackValue = new string[50][];
        /// <summary>
        /// 中间变量double
        /// </summary>
        public static double[] IntermDbl = new double[50];
        /// <summary>
        /// 中间变量point
        /// </summary>
        public static point[] IntermPoint = new point[50];       
        /// <summary>
        /// 点位坐标
        /// </summary>
        public static point[] point_MCS = new point[50];
        /// <summary>
        /// 传感器返回值
        /// </summary>
        public static string[][] SensorbackValue = new string[10][];
        /// <summary>
        /// 输出值
        /// </summary>a
        public static double[] Out = new double[50];                  
        /// <summary>
        /// 脚本
        /// </summary>
        public static string str_ScriptText = string.Empty;
      
        /// <summary>
        /// 运行结果
        /// </summary>
        public static string RunScriptLog = string.Empty;
        /// <summary>
        /// txt地址
        /// </summary>
        //private string txt_Addr = @"D:\Program Files\ThisEquipment\Database\SwParameter\Xml\Form_ScriptCaculate.txt";
        /// <summary>
        /// 类是否实例化成功
        /// </summary>
        public bool Result = true;

        #endregion
        #region 3.构造函数
        public Service_ScriptCaculate()
        {
            //1.读取参数
            Model_ScriptCaculate = new Model_ScriptCaculate();
            Read_Model();

            //2.实例化属性变量
            Service_ScriptCaculate.MCSPoint = new point[50];
            Service_ScriptCaculate.indexBackValue = new string[50][];
            for (int i = 0; i < 50; i++)
            {
                Service_ScriptCaculate.indexBackValue[i] = new string[50];
            }
            Service_ScriptCaculate.IntermDbl = new double[50];
            Service_ScriptCaculate.IntermPoint = new point[50];            
        }

        #endregion
        #region 4.私有方法
        #region 1.脚本定义的方法
        /// <summary>
        /// 1.直接赋值ASSIGN
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static double ASSIGN(string str1)
        {
            try
            {
                double double1 = InDouble2Double(str1);

                RunScriptLog = RunScriptLog + "ASSIGN:  输入值" + str1 + "   =" + double1.ToString() + "\r\n";

                double returnDouble = double1;

                return returnDouble;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        ///  点直接赋值ASSIGN_Point
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static point ASSIGN_Point(string str1, string str2)
        {
            point p;
            try
            {
                p.X = InDouble2Double(str1);
                p.Y = InDouble2Double(str2);
                RunScriptLog = RunScriptLog + "ASSIGN_Point:  输入值" + str1 + "   =" + p.X.ToString() + "," + str2 + "   =" + p.Y.ToString() + "\r\n";
                return p;
            }
            catch
            {
                p.X = 0;
                p.Y = 0;
                return p;
            }
        }
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static double ADD(string str1, string str2)
        {
            try
            {
                double double1 = InDouble2Double(str1);
                double double2 = InDouble2Double(str2);

                RunScriptLog = RunScriptLog + "ADD: 输入值" + str1 + "   =" + double1.ToString() + ",   " + str2 + "   =" + double2.ToString() + "\r\n";

                double returnDouble = double1 + double2;

                return returnDouble;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static double SUB(string str1, string str2)
        {
            try
            {
                double double1 = InDouble2Double(str1);
                double double2 = InDouble2Double(str2);

                RunScriptLog = RunScriptLog + "SUB: 输入值" + str1 + "   =" + double1.ToString() + ",   " + str2 + "   =" + double2.ToString() + "\r\n";

                double returnDouble = double1 - double2;

                return returnDouble;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static double MUL(string str1, string str2)
        {
            try
            {
                double double1 = InDouble2Double(str1);
                double double2 = InDouble2Double(str2);

                RunScriptLog = RunScriptLog + "MUL: 输入值" + str1 + "   =" + double1.ToString() + ",   " + str2 + "   =" + double2.ToString() + "\r\n";

                double returnDouble = double1 * double2;

                return returnDouble;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 除法
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static double DIV(string str1, string str2)
        {
            try
            {
                double double1 = InDouble2Double(str1);
                double double2 = InDouble2Double(str2);

                RunScriptLog = RunScriptLog + "DIV: 输入值" + str1 + "   =" + double1.ToString() + ",   " + str2 + "   =" + double2.ToString() + "\r\n";

                double returnDouble = 0;

                if (double2 == 0)
                    return returnDouble;

                returnDouble = double1 / double2;

                return returnDouble;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// ABS  
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static double ABS(string str1)
        {
            try
            {
                double double1 = InDouble2Double(str1);


                RunScriptLog = RunScriptLog + "ABS: 输入值" + str1 + "   =" + double1.ToString() + "\r\n";

                double returnDouble = 0;



                returnDouble = Math.Abs(double1);

                return returnDouble;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 点p2到p0(起点),p1(终点)形成直线的水平距离，返回double值
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <returns></returns>
        public static double P_PPXDistance(string str1, string str2, string str3, string str4)
        {
            point p0 = InPoint2Point(str1);
            point p1 = InPoint2Point(str2);
            point p2 = InPoint2Point(str3);

            //输入角度
            double double_angle = InDouble2Double(str4);


            RunScriptLog = RunScriptLog + "P_PPXDistance:    输入值" + str1 + "   =(" + p0.X.ToString() + ",   " + p0.Y.ToString() + "),   " + str2 + "   =(" + p1.X.ToString() + ",   " + p1.Y.ToString() + "),   " + str3 + "   =(" + p2.X.ToString() + ",   " + p2.Y.ToString() + "),   " + str4 + "   =(" + double_angle.ToString() + "),   " + "\r\n";

            double k = (p0.Y - p1.Y) / (p0.X - p1.X);
            double b = (p1.Y * p0.X - p0.Y * p1.X) / (p0.X - p1.X);

            //返回值
            double dis = 0;
            if (k == 0)
            {
                dis = p2.X - p0.X;
            }
            else
            {
                //旋转角度
                double delta_k = Math.Tan(double_angle * Math.PI / 180);

                //计算新的直线线性方程
                //mid_K为旋转90 后的K值（顺时针旋转，负数时 逆时针旋转）
                //旋转90度后继续旋转角度后的计算公式
                //tan(x+α)°= tanx° +tanα°/ 1-tanx°*tanα° =k+tanα°/ 1-k*tanα°

                double mid_K = -(1 / k);
                double newk = (mid_K - delta_k) / (1 + mid_K * delta_k);
                double newb = p0.Y - newk * p0.X;

                //计算距离
                dis = Math.Abs(newk * p2.X - p2.Y + newb) / Math.Sqrt(newk * newk + 1);
            }

            return Math.Abs(dis);
        }
        /// <summary>
        /// 点p2到p0(起点),p1(终点)形成直线(并旋转角度a)的距离，返回double值
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <param name="str4"></param>
        /// <returns></returns>
        public static double P_PPYDistance(string str1, string str2, string str3, string str4)
        {
            //新的坐标系
            point p0 = InPoint2Point(str1);
            point p1 = InPoint2Point(str2);
            point p2 = InPoint2Point(str3);
            //输入角度
            double double_angle = InDouble2Double(str4);

            RunScriptLog = RunScriptLog + "P_PPYDistance:    输入值" + str1 + "   =(" + p0.X.ToString() + ",   " + p0.Y.ToString() + "),   " + str2 + "   =(" + p1.X.ToString() + ",   " + p1.Y.ToString() + "),   " + str3 + "   =(" + p2.X.ToString() + ",   " + p2.Y.ToString() + "),   " + str4 + "   =(" + double_angle.ToString() + "),   " + "\r\n";


            //double double_angle = Convert.ToDouble(str1);
            //返回值
            double returnDouble = 0;

            //新的坐标系

            try
            {
                //计算直线线性方程
                double k = (p0.Y - p1.Y) / (p0.X - p1.X);
                double b = (p1.Y * p0.X - p0.Y * p1.X) / (p0.X - p1.X);
                //旋转度数为0
                if (double_angle == 0)
                {
                    //计算点到直线的垂直距离
                    double dis = Math.Abs(k * p2.X - p2.Y + b) / Math.Sqrt(k * k + 1);
                    returnDouble = Math.Abs(dis);
                    return returnDouble;
                }
                //旋转度数不为零
                else
                {
                    //计算新的直线线性方程
                    double New_k = (k - Math.Tan(double_angle * Math.PI / 180)) / (1 + k * Math.Tan(double_angle * Math.PI / 180));
                    double New_b = p0.Y - p0.X * New_k;
                    //计算点到直线的垂直距离
                    double dis1 = Math.Abs(New_k * p2.X - p2.Y + New_b) / Math.Sqrt(New_k * New_k + 1);
                    returnDouble = Math.Abs(dis1);
                    return returnDouble;

                }
            }
            catch
            {
                return 0;
            }

        }
        /// <summary>
        /// 由机械坐标系和相机坐标系生成最终坐标系
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <param name="str4"></param>
        /// <returns></returns>
        public static point MCSCCStoCS(string str1, string str2, string str3)
        {
            //机械坐标系MCS
            point MCS_p0 = InPoint2Point(str1);


            //相机坐标系CCS
            double CCS_p0_X = InDouble2Double(str2);
            double CCS_p0_Y = InDouble2Double(str3);

            RunScriptLog = RunScriptLog + "MCSCCStoCS:    输入值" + str1 + "   =(" + MCS_p0.X.ToString() + ",   " + MCS_p0.Y.ToString() + "),   " + str2 + "   =" + CCS_p0_X.ToString() + ",   " + str3 + "   =" + CCS_p0_Y.ToString() + ",   " + "\r\n";
            //返回值
            point CS_p0;
            try
            {
                CS_p0.X = MCS_p0.X + CCS_p0_X;
                CS_p0.Y = MCS_p0.Y + CCS_p0_Y;

            }
            catch
            {
                CS_p0.X = 0;
                CS_p0.Y = 0;

            }
            return CS_p0;

        }
        /// <summary>
        /// 两点间的距离
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static double Distance_Points(string str1, string str2)
        {
            //第一个点坐标
            point p0 = InPoint2Point(str1);
            point p1 = InPoint2Point(str2);




            RunScriptLog = RunScriptLog + "Distance_Points:    输入值" + str1 + "   =(" + p0.X.ToString() + ",   " + p0.Y.ToString() + "),   " + str2 + "   =(" + p1.X.ToString() + ",   " + p1.Y.ToString() + "),   " + "\r\n";
            //返回值
            double Result_Distance;
            try
            {
                Result_Distance = Math.Sqrt((p0.X - p1.X) * (p0.X - p1.X) + (p0.Y - p1.Y) * (p0.Y - p1.Y));
            }
            catch
            {
                Result_Distance = 0;

            }
            return Result_Distance;

        }

        /// <summary>
        /// 通过枚举变量找到对应的枚举的备注
        /// </summary>
        /// <param name="fnIndex"></param>
        /// <returns></returns>
        public static string GetEnumDescription(functionsNote fnIndex)
        {
            Type t = fnIndex.GetType();
            FieldInfo info = t.GetField(Enum.GetName(t, fnIndex));
            DescriptionAttribute description = (DescriptionAttribute)Attribute.GetCustomAttribute(info, typeof(DescriptionAttribute));
            return description.Description;
        }
        /// <summary>
        /// 通过枚举值找到对应的枚举的备注
        /// </summary>
        /// <param name="fnValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(string fnValue)
        {
            functionsNote sffn = (functionsNote)Enum.Parse(typeof(functionsNote), fnValue);
            string strBack = GetEnumDescription(sffn);
            return strBack;
        }
        #endregion
        #region 2.方程式中double输入变量鉴别,返回double值
        /**************************************************/
        /// <summary>
        /// 方程式中double输入变量鉴别,返回double值
        /// </summary>
        /// <param name="strInput">输入参数</param>
        /// <returns></returns>
        private static double InDouble2Double(string strInput)
        {
            string[] strIn = strInput.Split('[', ']');
            int index1 = 0;
            int index2 = 0;

            //输入double变量鉴别（BackValue）
            if (strIn[0] == "BackValue")
            {
                index1 = Convert.ToInt16(strIn[1]);
                index2 = Convert.ToInt16(strIn[3]);

                return Convert.ToDouble(indexBackValue[index1][index2]);
            }
            //中间double变量鉴别（IntermDbl）
            else if (strIn[0] == "IntermDbl")
            {
                index1 = Convert.ToInt16(strIn[1]);

                return Convert.ToDouble(IntermDbl[index1]);
            }

            else if (strIn[0] == "Out")
            {
                index1 = Convert.ToInt16(strIn[1]);

                return Convert.ToDouble(Out[index1]);
            }
            else if (strIn[0] == "Value")
            {


                return Convert.ToDouble(strIn[1]);
            }
            else
            {
                MessageBox.Show("计算有误,请确认！");
                return 0;
            }
        }

        /// <summary>
        /// 方程式中point输入变量鉴别,返回point值
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static point InPoint2Point(string strInput)
        {
            point p;
            p.X = 0;
            p.Y = 0;

            string[] strIn = strInput.Split('[', ']');
            int index1 = 0;

            //输入point变量鉴别（MCSPoint）
            if (strIn[0] == "MCSPoint")
            {
                index1 = Convert.ToInt16(strIn[1]);

                return MCSPoint[index1];

            }
            //中间point变量鉴别（IntermPoint）
            else if (strIn[0] == "IntermPoint")
            {
                index1 = Convert.ToInt16(strIn[1]);

                return IntermPoint[index1];
            }


            return p;
        }

        /// <summary>
        /// 等号左边的变量赋值（double）
        /// </summary>
        /// <param name="strOutput"></param>
        /// <param name="dbl"></param>
        public static void OutDouble2Double(string strOutput, double dbl)
        {
            string[] strIn = strOutput.Split('[', ']');
            int index1 = Convert.ToInt16(strIn[1]);
            if (strIn[0] == "IntermDbl")
            {
                IntermDbl[index1] = dbl;

                

            }
            else if (strIn[0] == "Out")
            {
                Out[index1] = dbl;

               
            }

            RunScriptLog = RunScriptLog + strOutput + "的计算结果为:   " + dbl.ToString() + "\r\n";
        }
        /// <summary>
        /// 等号左边的变量赋值（point）
        /// </summary>
        /// <param name="strOutput"></param>
        /// <param name="p"></param>
        public static void OutPoint2Point(string strOutput, point p)
        {
            string[] strIn = strOutput.Split('[', ']');
            int index1 = Convert.ToInt16(strIn[1]);
            if (strIn[0] == "IntermPoint")
            {
                IntermPoint[index1] = p;

                //MessageBox.Show("\r\nIntermPoint[" + index1.ToString() + "].X = " + p.X.ToString() + "\r\nIntermPoint[" + index1.ToString() + "].Y = " + p.Y.ToString());

            }

            RunScriptLog = RunScriptLog + strOutput + "的计算结果为:   (" + p.X.ToString() + "," + p.Y.ToString() + ")" + "\r\n";
        }
        #endregion
        #endregion
        #region 5.公有方法
        /// <summary>
        /// 运行脚本
        /// </summary>
        /// <param name="str_ScriptText"></param>
        public bool RunScript()
        {
            //脚本赋值
            SetValue();
            try
            {
                RunScriptLog = string.Empty;
                //string[] str1 = Model_ScriptCaculate.ScriptText.Split(';');

                for (int i = 0; i < Model_ScriptCaculate.ScriptText.Count; i++)
                {

                    string str2 = Model_ScriptCaculate.ScriptText[i];
                    string[] aryReg = { "\r", "\n", " " };
                    for (int k = 0; k < aryReg.Length; k++)
                    {
                        str2 = str2.Replace(aryReg[k], string.Empty);
                    }
                    if (str2 == "" || str2.Length < 5)
                    {
                        break;
                    }
                    else
                    {
                        if (str2.Substring(0, 1) == "/")
                            continue;
                    }
                    //等号左右两边划分
                    string[] s = str2.Split('=');
                    //等号右边"("和")"和","划分，第一个是方法，后面跟的是参数
                    string[] sRight = s[1].Split('(', ')', ',');

                    if (sRight[0] == "ASSIGN")
                    {
                        double thisDouble = ASSIGN(sRight[1]);
                        OutDouble2Double(s[0], thisDouble);
                    }

                    if (sRight[0] == "ASSIGN_Point")
                    {
                        point thisDouble = ASSIGN_Point(sRight[1], sRight[2]);
                        OutPoint2Point(s[0], thisDouble);
                    }

                    if (sRight[0] == "ADD")
                    {
                        double thisDouble = ADD(sRight[1], sRight[2]);
                        OutDouble2Double(s[0], thisDouble);
                    }

                    else if (sRight[0] == "SUB")
                    {
                        double thisDouble = SUB(sRight[1], sRight[2]);
                        OutDouble2Double(s[0], thisDouble);
                    }

                    else if (sRight[0] == "MUL")
                    {
                        double thisDouble = MUL(sRight[1], sRight[2]);
                        OutDouble2Double(s[0], thisDouble);
                    }

                    else if (sRight[0] == "DIV")
                    {
                        double thisDouble = DIV(sRight[1], sRight[2]);
                        OutDouble2Double(s[0], thisDouble);
                    }

                    else if (sRight[0] == "ABS")
                    {
                        double thisDouble = ABS(sRight[1]);
                        OutDouble2Double(s[0], thisDouble);
                    }
                    else if (sRight[0] == "P_PPXDistance")
                    {
                        double thisDouble = P_PPXDistance(sRight[1], sRight[2], sRight[3], sRight[4]);
                        OutDouble2Double(s[0], thisDouble);
                    }
                    else if (sRight[0] == "P_PPYDistance")
                    {
                        double thisDouble = P_PPYDistance(sRight[1], sRight[2], sRight[3], sRight[4]);
                        OutDouble2Double(s[0], thisDouble);
                    }

                    else if (sRight[0] == "MCSCCStoCS")
                    {
                        point thisDouble = MCSCCStoCS(sRight[1], sRight[2], sRight[3]);
                        OutPoint2Point(s[0], thisDouble);
                    }
                    else if (sRight[0] == "Distance_Points")
                    {
                        double thisDouble = Distance_Points(sRight[1], sRight[2]);
                        OutDouble2Double(s[0], thisDouble);
                    }

                }

            }
            catch 
            {

                return false;
            }
            //检测数据写入到测试数据中
            Add_Measure_Data();
            return true;

        }

        public bool RunScript_Refresh()
        {
            //1.界面刷新
            Form_ScriptCaculate.Refresh();
            //2.检测数据写入到测试数据中
            Add_Measure_Data();
            return true;
        }
        private void SetValue() 
        {
            if (ThisEquipment.Form_Main.Receive == null) return;
            for (int i = 0; i < ThisEquipment.Form_Main.Receive.Count; i++)
            {
                //限制
                if ( i>= 50) return;
                for (int j = 0; j < ThisEquipment.Form_Main.Receive[i].Count; j++)
                {
                    if (j >= 50) return;
                    indexBackValue[i][j] = ThisEquipment.Form_Main.Receive[i][j].ToString("0.000");
                }
            }
        
        }
        public void Add_Measure_Data()
        {
            Measure.ProMeasureSize.TestValue = new List<Measure.TestingData>();
            if (Measure.ProMeasureSize.Sizes == null) return;
            for (int i = 0; i < Measure.ProMeasureSize.Sizes.Count(); i++)
            {
                //需要实例化后才能引用MESURE
                Measure.TestingData testdata = new Measure.TestingData();

                testdata.ID = i;

                testdata.Name = Measure.ProMeasureSize.NameList[i];

                try
                {
                    testdata.Value = Convert.ToDouble(Out[i].ToString("0.000"));


                }
                catch
                {
                    testdata.Value = 0;

                }
                Measure.ProMeasureSize.TestValue.Add(testdata);
            }
        }
        public bool Read_Model()
        {
            //读取参数
           // bool result = Class_OpFile.LoadingProfile(txt_Addr,out Model_ScriptCaculate.ScriptText);
           
            return true;
        }
        //4.写参数
        public bool Save_Model()
        {
            //读取参数
            
           // bool result = Class_OpFile.SaveProfile(Model_ScriptCaculate.ScriptText, txt_Addr);
            return true;
        }
        #endregion
    }
}
