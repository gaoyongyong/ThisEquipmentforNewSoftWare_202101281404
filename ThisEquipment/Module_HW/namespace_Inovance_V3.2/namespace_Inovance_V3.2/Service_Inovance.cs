using Tools;
using ScriptCaculate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Inovance
{
    public class Service_Inovance
    {
        #region 1.公有变量
        /// <summary>
        /// 定义Model
        /// </summary>
        public Model_Inovance Model_Inovance;

        /// <summary>
        ///汇川属性
        /// </summary>
        public Property_Inovance Property_Inovance;

        /// <summary>
        /// 气缸刷新暂停
        /// </summary>
        public bool Pause;

        /// <summary>
        /// 模块错误
        /// </summary>
        public bool Group_Error = false;
        #endregion
        #region 2.私有变量
        /// <summary>
        ///文件读取是否成功
        /// </summary>
        private bool Result;

        /// <summary>
        /// 汇川基础通讯类
        /// </summary>
        public Basic_Inovance Basic_Inovance = new Basic_Inovance();

        /// <summary>
        /// 停止线程
        /// </summary>
        public bool Stop_Thread;

        #endregion
        #region 3.构造函数
        public Service_Inovance()
        {
            //1.实例化Model
            Model_Inovance = new Model_Inovance();
            //2.实例化属性
            Property_Inovance = new Property_Inovance();
            //3.实例化Basic
            Basic_Inovance = new Basic_Inovance();
            //4.定义委托
            Class_Action.Lamp_Refresh += SystemStatus;
        }

        #endregion
        #region 4.私有方法
        /// <summary>
        /// 设定速度和位置
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public bool SetMoveInfo(PointPosition MoveInfo)
        {
            try
            {

                Basic_Inovance.writeMW_float(404, Convert.ToSingle(MoveInfo.Axis1Velocity));
                Basic_Inovance.writeMW_float(406, Convert.ToSingle(MoveInfo.Axis1Velocity));

                Basic_Inovance.writeMW_float(410, Convert.ToSingle(MoveInfo.Axis1Velocity));
                Basic_Inovance.writeMW_float(412, Convert.ToSingle(MoveInfo.Axis2Velocity));
                Basic_Inovance.writeMW_float(414, Convert.ToSingle(MoveInfo.Axis3Velocity));
                Basic_Inovance.writeMW_float(416, Convert.ToSingle(MoveInfo.Axis4Velocity));
                return true;
            }
            catch
            {

                return false;
            }
        }
        #endregion
        #region 5.公有方法
        /// <summary>
        /// //汇川输入输出刷新线程
        /// </summary>
        public void Read_PLC()
        {
            while (true)
            {
                if (Stop_Thread == true) //判断是否该结束线程了
                {
                    Stop_Thread = false;
                    return;
                }
                //先判断IP是否接通
                if (Class_IPConfirm.PingIPTest("192.168.1.88"))
                {
                    Group_Error = false;
                }
                else
                {
                    Group_Error = true;
                    Thread.Sleep(100);
                    Application.DoEvents();
                    continue;
                }
                //局部变量
                int thisInValue = 0;
                string strInput = "";
                string strInput1 = "";
                string strCurrent = "";

                //1.刷新Input

                if (Basic_Inovance.readMW_int32((int)PLC_Address.Input, ref thisInValue))
                {
                    strInput = Convert.ToString(thisInValue, 2);
                    strInput1 = strInput.PadLeft(32, '0');
                    for (int i = 0; i < strInput1.Length; i++)
                    {
                        try
                        {
                            strCurrent = strInput1.Substring(strInput1.Length - i - 1, 1);
                            Model_Inovance.Input[i].IO_Value = (strCurrent == "1" ? true : false);
                        }
                        catch
                        {

                        }
                    }

                }
                else
                {
                    Basic_Inovance.close();
                    Thread.Sleep(20);
                    Basic_Inovance.open();
                }

                //2.刷新Output
                int[] thisOutValue = new int[32];

                if (Basic_Inovance.readQX((int)PLC_Address.Output, 32, ref thisOutValue))
                {

                    for (int i = 0; i < 32; i++)
                    {
                        Model_Inovance.Output[i].IO_Value = (thisOutValue[i] == 1 ? true : false);
                    }
                }
                else
                {
                    Basic_Inovance.close();
                    Thread.Sleep(20);
                    Basic_Inovance.open();
                }
                //3.刷新系统变量
                //3.1 PLC正常信号
                int[] thisOutValue1 = new int[32];
                if (Basic_Inovance.readQX((int)PLC_Address.PLCStartOK, 1, ref thisOutValue1))
                {
                    Property_Inovance.HMI_PLCStartOK = thisOutValue1[0] == 1 ? true : false;
                }
                else
                {

                    Basic_Inovance.close();
                    Thread.Sleep(20);
                    Basic_Inovance.open();
                }
                #region 报错代码
                //3.2报错代码
                //if (Basic_Inovance.readQX(100, 1, ref thisOutValue1))
                //{
                //    Property_Inovance.HMI_PLCStartOK = thisOutValue1[0] == 1 ? true : false;
                //}
                //else
                //{

                //    Basic_Inovance.close();
                //    Thread.Sleep(20);
                //    Basic_Inovance.open();
                //}

                //string Error_strInput1 = Error_strInput.PadLeft(32, '0');
                //string Error_strCurrent2 = "";
                //InovanceModel.ErrorCode = "正常";
                //if (flg1)
                //{
                //    for (int i = 0; i < Error_strInput1.Length; i++)
                //    {

                //        strCurrent = Error_strInput1.Substring(Error_strInput1.Length - i - 1, 1);
                //        if (strCurrent == "1")
                //        {
                //            switch (i)
                //            {
                //                case 0:
                //                    InovanceModel.ErrorCode = "PLC EtherCat 报错";
                //                    break;
                //                case 1:
                //                    InovanceModel.ErrorCode = "伺轴报错";
                //                    break;
                //                case 2:
                //                    InovanceModel.ErrorCode = "急停中"; ;
                //                    break;
                //                //case 3:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 4:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 5:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 6:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 7:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 8:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 9:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 10:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 11:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 12:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 13:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 14:
                //                //    ErrorString = "";
                //                //    break;
                //                //case 15:
                //                //    ErrorString = "";
                //                //    break;
                //                default:
                //                    break;
                //            }


                //        }
                //    }
                //}
                #endregion

                //4.刷新轴数据
                float thisPos_float = 0;
                int thisPos_int = 0;
                bool flg1 = false;

                //4.1 轴1
                flg1 = Basic_Inovance.readMW_int32((int)PLC_Address.Axis1_Action, ref thisPos_int);
                Property_Inovance.PC_Axis1.Axis_Action = thisPos_int;

                flg1 = Basic_Inovance.readMW_int32((int)PLC_Address.Axis1_Status, ref thisPos_int);
                strInput = Convert.ToString(thisPos_int, 2);
                strInput1 = strInput.PadLeft(32, '0');
                strCurrent = strInput1.Substring(31, 1);
                Property_Inovance.PC_Axis1.Axis_Busy = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(30, 1);
                Property_Inovance.PC_Axis1.Axis_Done = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(29, 1);
                Property_Inovance.PC_Axis1.Axis_Error = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(27, 1);
                Property_Inovance.PC_Axis1.Axis_Ori = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(26, 1);
                Property_Inovance.PC_Axis1.Axis_P = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(25, 1);
                Property_Inovance.PC_Axis1.Axis_N = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(24, 1);
                Property_Inovance.PC_Axis1.Axis_HomeDone = (strCurrent == "1" ? true : false);
                flg1 = Basic_Inovance.readMW_float((int)PLC_Address.Axis1_Position, ref thisPos_float);
                Property_Inovance.PC_Axis1.Axis_Position = Convert.ToDouble(thisPos_float);

                //4.2 轴2
                flg1 = Basic_Inovance.readMW_int32((int)PLC_Address.Axis2_Action, ref thisPos_int);
                Property_Inovance.PC_Axis2.Axis_Action = thisPos_int;
                flg1 = Basic_Inovance.readMW_int32((int)PLC_Address.Axis2_Status, ref thisPos_int);
                strInput = Convert.ToString(thisPos_int, 2);
                strInput1 = strInput.PadLeft(32, '0');
                strCurrent = strInput1.Substring(31, 1);
                Property_Inovance.PC_Axis2.Axis_Busy = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(30, 1);
                Property_Inovance.PC_Axis2.Axis_Done = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(29, 1);
                Property_Inovance.PC_Axis2.Axis_Error = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(27, 1);
                Property_Inovance.PC_Axis2.Axis_Ori = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(26, 1);
                Property_Inovance.PC_Axis2.Axis_P = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(25, 1);
                Property_Inovance.PC_Axis2.Axis_N = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(24, 1);
                Property_Inovance.PC_Axis2.Axis_HomeDone = (strCurrent == "1" ? true : false);
                flg1 = Basic_Inovance.readMW_float((int)PLC_Address.Axis2_Position, ref thisPos_float);
                Property_Inovance.PC_Axis2.Axis_Position = Convert.ToDouble(thisPos_float);

                //4.3 轴3
                flg1 = Basic_Inovance.readMW_int32((int)PLC_Address.Axis3_Action, ref thisPos_int);
                Property_Inovance.PC_Axis3.Axis_Action = thisPos_int;
                flg1 = Basic_Inovance.readMW_int32((int)PLC_Address.Axis3_Status, ref thisPos_int);
                strInput = Convert.ToString(thisPos_int, 2);
                strInput1 = strInput.PadLeft(32, '0');
                strCurrent = strInput1.Substring(31, 1);
                Property_Inovance.PC_Axis3.Axis_Busy = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(30, 1);
                Property_Inovance.PC_Axis3.Axis_Done = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(29, 1);
                Property_Inovance.PC_Axis3.Axis_Error = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(27, 1);
                Property_Inovance.PC_Axis3.Axis_Ori = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(26, 1);
                Property_Inovance.PC_Axis3.Axis_P = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(25, 1);
                Property_Inovance.PC_Axis3.Axis_N = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(24, 1);
                Property_Inovance.PC_Axis3.Axis_HomeDone = (strCurrent == "1" ? true : false);
                flg1 = Basic_Inovance.readMW_float((int)PLC_Address.Axis3_Position, ref thisPos_float);
                Property_Inovance.PC_Axis3.Axis_Position = Convert.ToDouble(thisPos_float);

                //4.4 轴4
                flg1 = Basic_Inovance.readMW_int32((int)PLC_Address.Axis4_Action, ref thisPos_int);
                Property_Inovance.PC_Axis4.Axis_Action = thisPos_int;

                flg1 = Basic_Inovance.readMW_int32((int)PLC_Address.Axis4_Status, ref thisPos_int);
                strInput = Convert.ToString(thisPos_int, 2);
                strInput1 = strInput.PadLeft(32, '0');
                strCurrent = strInput1.Substring(31, 1);
                Property_Inovance.PC_Axis4.Axis_Busy = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(30, 1);
                Property_Inovance.PC_Axis4.Axis_Done = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(29, 1);
                Property_Inovance.PC_Axis4.Axis_Error = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(27, 1);
                Property_Inovance.PC_Axis4.Axis_Ori = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(26, 1);
                Property_Inovance.PC_Axis4.Axis_P = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(25, 1);
                Property_Inovance.PC_Axis4.Axis_N = (strCurrent == "1" ? true : false);
                strCurrent = strInput1.Substring(24, 1);
                Property_Inovance.PC_Axis4.Axis_HomeDone = (strCurrent == "1" ? true : false);

                flg1 = Basic_Inovance.readMW_float((int)PLC_Address.Axis4_Position, ref thisPos_float);
                Property_Inovance.PC_Axis4.Axis_Position = Convert.ToDouble(thisPos_float);

                if (!flg1)
                {
                    Basic_Inovance.close();
                    Thread.Sleep(10);
                    Basic_Inovance.open();
                }

                //刷新气缸类
                if (!Pause)
                {
                    Cylinder_Refresh();
                }
                


                Thread.Sleep(10);
                Application.DoEvents();
            }



        }
        /// <summary>
        /// 气缸刷新
        /// </summary>
        public void Cylinder_Refresh()
        {


            for (int i = 0; i < Model_Inovance.Para_Cylinders.Count; i++)
            {
                //1.IO映射
                Model_Inovance.Para_Cylinders[i].Cy_Ori_Sensor_Status = Model_Inovance.Input[Model_Inovance.Para_Cylinders[i].Cy_Ori_Sensor].IO_Value;
                Model_Inovance.Para_Cylinders[i].Cy_Work_Sensor_Status = Model_Inovance.Input[Model_Inovance.Para_Cylinders[i].Cy_Work_Sensor].IO_Value;
                //Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve_Status = Model_Inovance.Input[Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve].IO_Value;
                // Model_Inovance.Para_Cylinders[i].Cy_Work_Valve_Status = Model_Inovance.Input[Model_Inovance.Para_Cylinders[i].Cy_Work_Valve].IO_Value;
                int Adress_Work = (Model_Inovance.Para_Cylinders[i].Cy_Work_Valve / 8 + 1) * 10 + (Model_Inovance.Para_Cylinders[i].Cy_Work_Valve % 8);
                int Adress_Ori = (Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve / 8 + 1) * 10 + (Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve % 8);
                //2.气缸工作报警
                if (Model_Inovance.Para_Cylinders[i].Cy_Work_Valve_Status)
                {

                    if (Model_Inovance.Para_Cylinders[i].Cy_Work_Valve_Status != Model_Inovance.Para_Cylinders[i].Cy_Work_Valve_Status_Before)
                    {
                        Model_Inovance.Para_Cylinders[i].Action_Time = DateTime.Now;
                        //if (!Model_Inovance.Para_Cylinders[i].Cy_Work_Ignore)
                        //{
                        //    Basic_Inovance.writeQX(Adress_Work, 1);
                        //}
                        //if (!Model_Inovance.Para_Cylinders[i].Cy_Ori_Ignore)
                        //{
                        //    Basic_Inovance.writeQX(Adress_Ori, 0);
                        //}
                        Basic_Inovance.writeQX(Adress_Work, 1);
                        Basic_Inovance.writeQX(Adress_Ori, 0);

                    }
                    double Time_Distance = (DateTime.Now - Model_Inovance.Para_Cylinders[i].Action_Time).TotalSeconds;
                    if (Model_Inovance.Para_Cylinders[i].Cy_Work_Ignore)
                    {
                        if (Time_Distance > Model_Inovance.Para_Cylinders[i].Cy_Ignore_DelayTime)
                        {
                            Model_Inovance.Para_Cylinders[i].Ret_NUM = 1;
                        }
                    }
                    else
                    {
                        if (Model_Inovance.Para_Cylinders[i].Cy_Work_Sensor_Status)
                        {
                            Model_Inovance.Para_Cylinders[i].Ret_NUM = 1;
                        }
                        if (Time_Distance > Model_Inovance.Para_Cylinders[i].Cy_Alarm_Time)
                        {
                            Model_Inovance.Para_Cylinders[i].bErrorWork = true;
                            Model_Inovance.Para_Cylinders[i].Ret_NUM = -1;
                        }
                        
                    }


                }
                Model_Inovance.Para_Cylinders[i].Cy_Work_Valve_Status_Before = Model_Inovance.Para_Cylinders[i].Cy_Work_Valve_Status;
                //3.气缸原位报警
                if (Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve_Status)
                {
                    if (Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve_Status != Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve_Status_Before)
                    {
                        Model_Inovance.Para_Cylinders[i].Action_Time = DateTime.Now;

                        //if (!Model_Inovance.Para_Cylinders[i].Cy_Work_Ignore) 
                        //{
                        //    Basic_Inovance.writeQX(Adress_Work, 0);

                        //}
                        //if (!Model_Inovance.Para_Cylinders[i].Cy_Ori_Ignore)
                        //{
                        //    Basic_Inovance.writeQX(Adress_Ori, 1);
                        //}
                        Basic_Inovance.writeQX(Adress_Ori, 1);
                        Basic_Inovance.writeQX(Adress_Work, 0);
                    }
                    double Time_Distance = (DateTime.Now - Model_Inovance.Para_Cylinders[i].Action_Time).TotalSeconds;
                    if (Model_Inovance.Para_Cylinders[i].Cy_Ori_Ignore)
                    {
                        if (Time_Distance > Model_Inovance.Para_Cylinders[i].Cy_Ignore_DelayTime)
                        {
                            Model_Inovance.Para_Cylinders[i].Ret_NUM = 1;
                        }
                    }
                    else
                    {
                        if (Model_Inovance.Para_Cylinders[i].Cy_Ori_Sensor_Status)
                        {
                            Model_Inovance.Para_Cylinders[i].Ret_NUM = 1;
                        }
                        if (Time_Distance > Model_Inovance.Para_Cylinders[i].Cy_Alarm_Time)
                        {
                            Model_Inovance.Para_Cylinders[i].bErrorOrg = true;
                            Model_Inovance.Para_Cylinders[i].Ret_NUM = -1;
                        }
                    }
                }
                Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve_Status_Before = Model_Inovance.Para_Cylinders[i].Cy_Ori_Valve_Status;

                Model_Inovance.Para_Cylinders[i].bError = Model_Inovance.Para_Cylinders[i].bErrorOrg || Model_Inovance.Para_Cylinders[i].bErrorWork;
            }



        }

        /// <summary>
        /// 回原点
        /// </summary>
        /// <returns></returns>
        public bool HomeAll()
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
            try
            {

                if (!Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 400)) { return false; };
                if (!Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 400)) { return false; };
                if (!Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 400)) { return false; };
                if (!Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 400)) { return false; };
                Property_Inovance.PC_Axis1.Axis_Action = 0;
                Property_Inovance.PC_Axis2.Axis_Action = 0;
                Property_Inovance.PC_Axis3.Axis_Action = 0;
                Property_Inovance.PC_Axis4.Axis_Action = 0;
                uint t1 = CAPI.GetTickCount();
                //等待回原点完成信号
                while (true)
                {
                    Class_Delay.MyDelaySecond(100);

                    if (Property_Inovance.PC_Axis1.Axis_Action == 401 & Property_Inovance.PC_Axis2.Axis_Action == 401 &
                        Property_Inovance.PC_Axis3.Axis_Action == 401 & Property_Inovance.PC_Axis4.Axis_Action == 401)

                    {
                        return true;

                    }
                    else if ((CAPI.GetTickCount() - t1) > 40000)
                    {
                        Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 0);
                        Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 0);
                        Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 0);
                        Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 0);
                        ToolInfo.Error_String = "超时";
                        return false;
                    }

                    Class_Delay.MyDelaySecond(10);
                }

            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 回设定点
        /// </summary>
        /// <param name="movePoint"></param>
        /// <returns></returns>
        public bool MoveSettingIndex(int Index)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
            try
            {
                if ((!Property_Inovance.PC_Axis1.Axis_HomeDone) || (!Property_Inovance.PC_Axis2.Axis_HomeDone) || (!Property_Inovance.PC_Axis3.Axis_HomeDone) || (!Property_Inovance.PC_Axis4.Axis_HomeDone))
                {
                    ToolInfo.Error_String = "轴没回原点";
                    return false;
                };
                if (Model_Inovance.ListPointPosition[Index] != null)
                {
                    Class_Delay.MyDelaySecond(200);
                    //写入数据
                    Basic_Inovance.writeMW_float((int)PLC_Address.Axis1_Action_Para1, Convert.ToSingle(Model_Inovance.ListPointPosition[Index].Axis1Position));
                    Basic_Inovance.writeMW_float((int)PLC_Address.Axis1_Action_Para2, Convert.ToSingle(Model_Inovance.ListPointPosition[Index].Axis1Velocity));

                    Basic_Inovance.writeMW_float((int)PLC_Address.Axis2_Action_Para1, Convert.ToSingle(Model_Inovance.ListPointPosition[Index].Axis2Position));
                    Basic_Inovance.writeMW_float((int)PLC_Address.Axis2_Action_Para2, Convert.ToSingle(Model_Inovance.ListPointPosition[Index].Axis2Velocity));

                    Basic_Inovance.writeMW_float((int)PLC_Address.Axis3_Action_Para1, Convert.ToSingle(Model_Inovance.ListPointPosition[Index].Axis3Position));
                    Basic_Inovance.writeMW_float((int)PLC_Address.Axis3_Action_Para2, Convert.ToSingle(Model_Inovance.ListPointPosition[Index].Axis3Velocity));

                    Basic_Inovance.writeMW_float((int)PLC_Address.Axis4_Action_Para1, Convert.ToSingle(Model_Inovance.ListPointPosition[Index].Axis4Position));
                    Basic_Inovance.writeMW_float((int)PLC_Address.Axis4_Action_Para2, Convert.ToSingle(Model_Inovance.ListPointPosition[Index].Axis4Velocity));

                    //启动运行
                    Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 500);
                    Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 500);
                    Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 500);
                    Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 500);

                    Property_Inovance.PC_Axis1.Axis_Action = 0;
                    Property_Inovance.PC_Axis2.Axis_Action = 0;
                    Property_Inovance.PC_Axis3.Axis_Action = 0;
                    Property_Inovance.PC_Axis4.Axis_Action = 0;


                    //启动
                    uint t1 = CAPI.GetTickCount();

                    //等待完成
                    while (true)
                    {
                        Class_Delay.MyDelaySecond(30);
                        if (Property_Inovance.PC_Axis1.Axis_Action == 501 & Property_Inovance.PC_Axis2.Axis_Action == 501 &
                            Property_Inovance.PC_Axis3.Axis_Action == 501 & Property_Inovance.PC_Axis4.Axis_Action == 501)
                        {
                            return true;
                        }
                        else if ((CAPI.GetTickCount() - t1) > 10000)
                        {
                            Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 0);
                            Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 0);
                            Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 0);
                            Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 0);
                            ToolInfo.Error_String = "超时";
                            return false;
                        }
                        Class_Delay.MyDelaySecond(10);
                    }
                }
                else
                {
                    ToolInfo.Error_String = "轴点位参数设置失败";
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 回等待点
        /// </summary>
        /// <returns></returns>
        public bool MoveWaitPosition()
        {
            if (Group_Error)
            {

                return false;
            }
            if ((!Property_Inovance.PC_Axis1.Axis_HomeDone) || (!Property_Inovance.PC_Axis2.Axis_HomeDone) || (!Property_Inovance.PC_Axis3.Axis_HomeDone) || (!Property_Inovance.PC_Axis4.Axis_HomeDone))
            { return false; };
            //写入数据
            Basic_Inovance.writeMW_float((int)PLC_Address.Axis1_Action_Para1, Convert.ToSingle(Model_Inovance.motorpara.Axis1_testHome));
            Basic_Inovance.writeMW_float((int)PLC_Address.Axis1_Action_Para2, Convert.ToSingle(Model_Inovance.motorpara.Axis1_testHomeSpeed));

            Basic_Inovance.writeMW_float((int)PLC_Address.Axis2_Action_Para1, Convert.ToSingle(Model_Inovance.motorpara.Axis2_testHome));
            Basic_Inovance.writeMW_float((int)PLC_Address.Axis2_Action_Para2, Convert.ToSingle(Model_Inovance.motorpara.Axis2_testHomeSpeed));

            Basic_Inovance.writeMW_float((int)PLC_Address.Axis3_Action_Para1, Convert.ToSingle(Model_Inovance.motorpara.Axis3_testHome));
            Basic_Inovance.writeMW_float((int)PLC_Address.Axis3_Action_Para2, Convert.ToSingle(Model_Inovance.motorpara.Axis3_testHomeSpeed));

            Basic_Inovance.writeMW_float((int)PLC_Address.Axis4_Action_Para1, Convert.ToSingle(Model_Inovance.motorpara.Axis4_testHome));
            Basic_Inovance.writeMW_float((int)PLC_Address.Axis4_Action_Para2, Convert.ToSingle(Model_Inovance.motorpara.Axis4_testHomeSpeed));

            //启动运行
            Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 500);
            Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 500);
            Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 500);
            Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 500);

            Property_Inovance.PC_Axis1.Axis_Action = 0;
            Property_Inovance.PC_Axis2.Axis_Action = 0;
            Property_Inovance.PC_Axis3.Axis_Action = 0;
            Property_Inovance.PC_Axis4.Axis_Action = 0;
            //启动
            uint t1 = CAPI.GetTickCount();

            //等待完成
            while (true)
            {
                Class_Delay.MyDelaySecond(30);
                if (Property_Inovance.PC_Axis1.Axis_Action == 501 & Property_Inovance.PC_Axis2.Axis_Action == 501 &
                    Property_Inovance.PC_Axis3.Axis_Action == 501 & Property_Inovance.PC_Axis4.Axis_Action == 501)
                {
                    return true;
                }
                else if ((CAPI.GetTickCount() - t1) > 10000)
                {
                    Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 0);
                    Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 0);
                    Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 0);
                    Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 0);
                    return false;
                }
                Class_Delay.MyDelaySecond(10);
            }

        }
        /// <summary>
        /// 回设定点
        /// </summary>
        /// <param name="movePoint"></param>
        /// <returns></returns>
        public bool MoveSettingPosition(PointPosition MoveInfo)
        {
            if (Group_Error)
            {
                return false;
            }
            if ((!Property_Inovance.PC_Axis1.Axis_HomeDone) || (!Property_Inovance.PC_Axis2.Axis_HomeDone) || (!Property_Inovance.PC_Axis3.Axis_HomeDone) || (!Property_Inovance.PC_Axis4.Axis_HomeDone))
            { return false; };
            try
            {
                //写入数据
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis1_Action_Para1, Convert.ToSingle(MoveInfo.Axis1Position));
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis1_Action_Para2, Convert.ToSingle(MoveInfo.Axis1Velocity));

                Basic_Inovance.writeMW_float((int)PLC_Address.Axis2_Action_Para1, Convert.ToSingle(MoveInfo.Axis2Position));
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis2_Action_Para2, Convert.ToSingle(MoveInfo.Axis2Velocity));

                Basic_Inovance.writeMW_float((int)PLC_Address.Axis3_Action_Para1, Convert.ToSingle(MoveInfo.Axis3Position));
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis3_Action_Para2, Convert.ToSingle(MoveInfo.Axis3Velocity));

                Basic_Inovance.writeMW_float((int)PLC_Address.Axis4_Action_Para1, Convert.ToSingle(MoveInfo.Axis4Position));
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis4_Action_Para2, Convert.ToSingle(MoveInfo.Axis4Velocity));

                //启动运行
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 500);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 500);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 500);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 500);
                Property_Inovance.PC_Axis1.Axis_Action = 0;
                Property_Inovance.PC_Axis2.Axis_Action = 0;
                Property_Inovance.PC_Axis3.Axis_Action = 0;
                Property_Inovance.PC_Axis4.Axis_Action = 0;
                //启动
                uint t1 = CAPI.GetTickCount();

                //等待完成
                while (true)
                {
                    Class_Delay.MyDelaySecond(30);
                    if (Property_Inovance.PC_Axis1.Axis_Action == 501 & Property_Inovance.PC_Axis2.Axis_Action == 501 &
                        Property_Inovance.PC_Axis3.Axis_Action == 501 & Property_Inovance.PC_Axis4.Axis_Action == 501)
                    {
                        return true;
                    }
                    else if ((CAPI.GetTickCount() - t1) > 10000)
                    {
                        //启动运行
                        Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 0);
                        Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 0);
                        Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 0);
                        Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 0);
                        return false;
                    }
                    Class_Delay.MyDelaySecond(10);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <param name="movePoint"></param>
        /// <returns></returns>
        public bool Reset()
        {
            if (Group_Error)
            {
               
                return false;
            }
            try
            {

                //启动运行
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 700);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 700);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 700);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 700);




                Class_Delay.MyDelaySecond(200);
                //启动运行
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 0);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 0);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 0);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 0);
                return true;



            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            if (Group_Error)
            {
                return false;
            }
            try
            {
                //写入数据
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis1_Action_Para1, Convert.ToSingle(500));
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis2_Action_Para1, Convert.ToSingle(500));
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis3_Action_Para1, Convert.ToSingle(500));
                Basic_Inovance.writeMW_float((int)PLC_Address.Axis4_Action_Para1, Convert.ToSingle(500));

                //启动运行
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 700);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 700);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 700);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 700);

                Class_Delay.MyDelaySecond(200);
                //启动运行
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis1_Action, 0);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis2_Action, 0);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis3_Action, 0);
                Basic_Inovance.writeMW_int32((int)PLC_Address.Axis4_Action, 0);
                return true;



            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 强制IO
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public bool SetOutput(int Index)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
            try
            {
                if (Index > 32) 
                {
                    ToolInfo.Error_String = "IO点位超过限制";
                    return false;
                }
                int Adress = (Index / 8 + 1) * 10 + (Index % 8);
                return (Basic_Inovance.writeQX(Adress, 1));
            }
            catch
            {

                return false;
            }
        }
        /// <summary>
        /// 释放IO
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public bool ResetOutput(int Index)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
            try
            {
                if (Index > 32)
                {
                    ToolInfo.Error_String = "IO点位超过限制";
                    return false;
                }
                int Adress = (Index / 8 + 1) * 10 + (Index % 8);
                return (Basic_Inovance.writeQX(Adress, 0));
            }
            catch
            {

                return false;
            }
        }

        /// <summary>
        /// 等待IO
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public bool WaitIO(int Index)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
            try
            {
                if (Index > 32) return false;
                return (Model_Inovance.Input[Index].IO_Value);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 等待IO
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public bool WaitHandButton(int Index1, int Index2)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
            try
            {
                if (Index1 > 32 || Index2 > 32) return false;
                return (Model_Inovance.Input[Index1].IO_Value & Model_Inovance.Input[Index2].IO_Value);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 保存参数
        /// </summary>
        /// <returns></returns>
        public bool Save_Model()
        {
            if (Group_Error)
            {
                return false;
            }
            ////读取参数
            //bool result = XmlObjConvert.SerializeObject(Model_Inovance, Xml_Addr);
            return true;
        }
        #endregion


        /// <summary>
        /// 执行动位动作
        /// </summary>
        public bool Cys_Work(List<string> Set_CyNames, List<string> Reset_CyNames)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
           
            //1.判断气缸是否存在
            List<int> Find_SetCylinders = new List<int>();
            List<int> Find_ResetCylinders = new List<int>();
            for (int i = 0; i < Set_CyNames.Count; i++)
            {
                for (int j = 0; j < Model_Inovance.Para_Cylinders.Count; j++)
                {
                    if (Model_Inovance.Para_Cylinders[j].Cy_Name == Set_CyNames[i])
                    {
                        Find_SetCylinders.Add(j);
                        break;
                    }
                }

                if (Find_SetCylinders.Count == 0)
                {
                    ToolInfo.Error_String = "气缸名称不存在";
                    return false;
                }
               
            }
            for (int i = 0; i < Reset_CyNames.Count; i++)
            {
                for (int j = 0; j < Model_Inovance.Para_Cylinders.Count; j++)
                {
                    if (Model_Inovance.Para_Cylinders[j].Cy_Name == Reset_CyNames[i])
                    {
                        Find_ResetCylinders.Add(j);
                        break;
                    }
                }
                
                if (Find_ResetCylinders.Count == 0)
                {
                    ToolInfo.Error_String = "气缸名称不存在";
                    return false;
                }
                else
                {
                   
                }
            }
            //2.气缸执行
            for (int i = 0; i < Find_SetCylinders.Count; i++)
            {
                Model_Inovance.Para_Cylinders[Find_SetCylinders[i]].bErrorWork = false;
                Model_Inovance.Para_Cylinders[Find_SetCylinders[i]].bErrorOrg = false;
                Model_Inovance.Para_Cylinders[Find_SetCylinders[i]].Cy_Ori_Valve_Status = false;
                Model_Inovance.Para_Cylinders[Find_SetCylinders[i]].Cy_Work_Valve_Status = true;
                Model_Inovance.Para_Cylinders[Find_SetCylinders[i]].Ret_NUM = 0;
                Model_Inovance.Para_Cylinders[Find_SetCylinders[i]].Action_Time = DateTime.Now;
            }
            for (int i = 0; i < Find_ResetCylinders.Count; i++)
            {
                Model_Inovance.Para_Cylinders[Find_ResetCylinders[i]].bErrorWork = false;
                Model_Inovance.Para_Cylinders[Find_ResetCylinders[i]].bErrorOrg = false;
                Model_Inovance.Para_Cylinders[Find_ResetCylinders[i]].Cy_Ori_Valve_Status = true;
                Model_Inovance.Para_Cylinders[Find_ResetCylinders[i]].Cy_Work_Valve_Status = false;
                Model_Inovance.Para_Cylinders[Find_ResetCylinders[i]].Ret_NUM = 0;
                Model_Inovance.Para_Cylinders[Find_ResetCylinders[i]].Action_Time = DateTime.Now;
            }
            //3.等待结果
            while (true)
            {
                if (Group_Error)
                {
                    ToolInfo.Error_String = "PLC连接失败";
                    return false;
                }
                bool Result = true;
                for (int i = 0; i < Find_SetCylinders.Count; i++)
                {
                    if (Model_Inovance.Para_Cylinders[Find_SetCylinders[i]].Ret_NUM == 1)
                    {
                        Result = Result & true;
                    }
                    else if (Model_Inovance.Para_Cylinders[Find_SetCylinders[i]].Ret_NUM == 0)
                    {
                        Result = Result & false;
                    }
                    else
                    {
                        ToolInfo.Error_String = "超时报警";
                        return false;
                    }
                }
                for (int i = 0; i < Find_ResetCylinders.Count; i++)
                {
                    if (Model_Inovance.Para_Cylinders[Find_ResetCylinders[i]].Ret_NUM == 1)
                    {
                        Result = Result & true;
                    }
                    else if (Model_Inovance.Para_Cylinders[Find_ResetCylinders[i]].Ret_NUM == 0)
                    {
                        Result = Result & false;
                    }
                    else
                    {
                        ToolInfo.Error_String = "超时报警";
                        return false;
                    }
                }
                if (Result)
                {
                    return true;
                }

                Thread.Sleep(10);
                Application.DoEvents();
            }
        }

        ///// <summary>
        ///// 执行动位动作
        ///// </summary>
        //public bool Cys_Work(List<String> Set_CyNames, List<String> Reset_CyNames)
        //{
        //    if (Group_Error)
        //    {
        //        ToolInfo.Error_String = "PLC连接失败";
        //        return false;
        //    }
            
        //    //1.判断气缸是否存在
        //    List<Para_Cylinder> Find_SetCylinders = new List<Para_Cylinder>();
        //    List<Para_Cylinder> Find_ResetCylinders = new List<Para_Cylinder>();
        //    for (int i = 0; i < Set_CyNames.Count(); i++)
        //    {
        //        Para_Cylinder Find_SetCylinder = Model_Inovance.Para_Cylinders.Find(e1 => e1.Cy_Name == Set_CyNames[i]);
        //        if (Find_SetCylinder == null)
        //        {
        //            ToolInfo.Error_String = "气缸名称不存在";
        //            return false;
        //        }
        //        else
        //        {
        //            Find_SetCylinders.Add(Find_SetCylinder);
        //        }
        //    }
        //    for (int i = 0; i < Reset_CyNames.Count(); i++)
        //    {
        //        Para_Cylinder Find_ResetCylinder = Model_Inovance.Para_Cylinders.Find(e1 => e1.Cy_Name == Reset_CyNames[i]);
        //        if (Find_ResetCylinder == null)
        //        {
        //            ToolInfo.Error_String = "气缸名称不存在";
        //            return false;
        //        }
        //        else
        //        {
        //            Find_ResetCylinders.Add(Find_ResetCylinder);
        //        }
        //    }
        //    //2.气缸执行
        //    for (int i = 0; i < Find_SetCylinders.Count; i++)
        //    {
        //        Find_SetCylinders[i].bErrorWork = false;
        //        Find_SetCylinders[i].bErrorOrg = false;
        //        Find_SetCylinders[i].Cy_Ori_Valve_Status = false;
        //        Find_SetCylinders[i].Cy_Work_Valve_Status = true;
        //    }
        //    for (int i = 0; i < Find_ResetCylinders.Count; i++)
        //    {
        //        Find_SetCylinders[i].bErrorWork = false;
        //        Find_SetCylinders[i].bErrorOrg = false;
        //        Find_SetCylinders[i].Cy_Ori_Valve_Status = true;
        //        Find_SetCylinders[i].Cy_Work_Valve_Status = false;
        //    }
        //    //3.等待结果
        //    while (true)
        //    {
        //        bool Result = true;
        //        for (int i = 0; i < Find_SetCylinders.Count; i++)
        //        {
        //            if (Find_SetCylinders[i].Ret_NUM == 1)
        //            {
        //                Result = Result & true;
        //            }
        //            else if (Find_SetCylinders[i].Ret_NUM == 0)
        //            {
        //                Result = Result & false;
        //            }
        //            else
        //            {
        //                ToolInfo.Error_String = "超时报警";
        //                return false;
        //            }
        //        }
        //        for (int i = 0; i < Find_ResetCylinders.Count; i++)
        //        {
        //            if (Find_ResetCylinders[i].Ret_NUM == 1)
        //            {
        //                Result = Result & true;
        //            }
        //            else if (Find_ResetCylinders[i].Ret_NUM == 0)
        //            {
        //                Result = Result & false;
        //            }
        //            else
        //            {
        //                ToolInfo.Error_String = "超时报警";
        //                return false;
        //            }
        //        }
        //        if (Result)
        //        {
        //            return true;
        //        }

        //        Thread.Sleep(10);
        //        Application.DoEvents();
        //    }
        //}
        /// <summary>
        /// 执行单气缸动作
        /// </summary>
        public bool Cy_Work(string CyName)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
           
            //2.判断气缸是否存在

            Para_Cylinder Find_SetCylinder = Model_Inovance.Para_Cylinders.Find(e1 => e1.Cy_Name == CyName);
            if (Find_SetCylinder == null)
            {
                ToolInfo.Error_String = "气缸名称不存在";
                return false;
            }

            //3.气缸执行

            Find_SetCylinder.bErrorWork = false;
            Find_SetCylinder.bErrorOrg = false;
            Find_SetCylinder.Cy_Ori_Valve_Status = false;
            Find_SetCylinder.Cy_Work_Valve_Status = true;
            Find_SetCylinder.Ret_NUM = 0;
            Find_SetCylinder.Action_Time = DateTime.Now;

            //4.等待结果
            while (true)
            {

                if (Group_Error)
                {
                    ToolInfo.Error_String = "PLC连接失败";
                    return false;
                }
                if (Find_SetCylinder.Ret_NUM == 1)
                {
                    return true;
                }
                else if (Find_SetCylinder.Ret_NUM == -1)
                {
                    ToolInfo.Error_String = "超时报警";
                    return false;
                }
                Thread.Sleep(10);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 执行单气缸动作
        /// </summary>
        public bool Cy_Ori(string CyName)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
            //1.判断气缸参数是否错误
           
            //2.判断气缸是否存在

            Para_Cylinder Find_SetCylinder = Model_Inovance.Para_Cylinders.Find(e1 => e1.Cy_Name == CyName);
            if (Find_SetCylinder == null)
            {
                ToolInfo.Error_String = "气缸名称不存在";
                return false;
            }

            //3.气缸执行

            Find_SetCylinder.bErrorWork = false;
            Find_SetCylinder.bErrorOrg = false;
            Find_SetCylinder.Cy_Ori_Valve_Status = true;
            Find_SetCylinder.Cy_Work_Valve_Status = false;
            Find_SetCylinder.Ret_NUM = 0;
            Find_SetCylinder.Action_Time = DateTime.Now;

            //4.等待结果
            while (true)
            {
                if (Group_Error)
                {
                    ToolInfo.Error_String = "PLC连接失败";
                    return false;
                }
                if (Find_SetCylinder.Ret_NUM == 1)
                {
                    return true;
                }
                else if (Find_SetCylinder.Ret_NUM == -1)
                {
                    ToolInfo.Error_String = "超时报警";
                    return false;
                }
                Thread.Sleep(10);
                Application.DoEvents();
            }
        }


        /// <summary>
        /// 执行单气缸动作
        /// </summary>
        public bool Cy_OnlyWork(string CyName)
        {
            if (Group_Error)
            {
                ToolInfo.Error_String = "PLC连接失败";
                return false;
            }
            //1.判断气缸参数是否错误
         
            //2.判断气缸是否存在

            Para_Cylinder Find_SetCylinder = Model_Inovance.Para_Cylinders.Find(e1 => e1.Cy_Name == CyName);
            if (Find_SetCylinder == null)
            {
                ToolInfo.Error_String = "气缸名称不存在";
                return false;
            }

            //3.气缸执行

            Find_SetCylinder.bErrorWork = false;
            Find_SetCylinder.bErrorOrg = false;
            Find_SetCylinder.Cy_Ori_Valve_Status = false;
            Find_SetCylinder.Cy_Work_Valve_Status = true;
            Find_SetCylinder.Ret_NUM = 0;
            Find_SetCylinder.Action_Time = DateTime.Now;


            return true;
        }

        /// <summary>
        /// 执行单气缸动作
        /// </summary>
        public bool Cy_OnlyOri(string CyName)
        {
            if (Group_Error)
            {
                return false;
            }
            //1.判断气缸参数是否错误
            
            //2.判断气缸是否存在

            Para_Cylinder Find_SetCylinder = Model_Inovance.Para_Cylinders.Find(e1 => e1.Cy_Name == CyName);
            if (Find_SetCylinder == null)
            {
                ToolInfo.Error_String = "气缸名称不存在";
                return false;
            }

            //3.气缸执行

            Find_SetCylinder.bErrorWork = false;
            Find_SetCylinder.bErrorOrg = false;
            Find_SetCylinder.Cy_Ori_Valve_Status = true;
            Find_SetCylinder.Cy_Work_Valve_Status = false;
            Find_SetCylinder.Ret_NUM = 0;
            Find_SetCylinder.Action_Time = DateTime.Now;
            return true;
        }

        public void SystemStatus(string SystemStatus) 
        {
            switch (SystemStatus)
            {
                case "Normal":
                    SetOutput(1);
                    ResetOutput(0);
                    ResetOutput(2);
                    ResetOutput(3);
                    break;
                case "Alarm":
                    SetOutput(0);
                    ResetOutput(1);
                    ResetOutput(2);
                    ResetOutput(3);
                    break;
                case "Standby":
                    SetOutput(2);
                    ResetOutput(0);
                    ResetOutput(1);
                    ResetOutput(3);
                    break;

                default:
                    break;
            }
        }

       
    }



}
