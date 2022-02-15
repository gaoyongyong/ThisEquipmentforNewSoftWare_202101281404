using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inovance
{
    [Serializable]
    public class Model_Inovance
    {
        /// <summary>
        /// 马达参数
        /// </summary>
        public Motorpara motorpara = new Motorpara();
        /// <summary>
        /// 点位字典
        /// </summary>
        public List<PointPosition> ListPointPosition = new List<PointPosition>();

        /// <summary>
        /// Input
        /// </summary>
        public List<IO> Input = new List<IO>();

        /// <summary>
        /// Output
        /// </summary>
        public List<IO> Output = new List<IO>();

        /// <summary>
        /// 气缸参数
        /// </summary>
        public List<Para_Cylinder> Para_Cylinders = new List<Para_Cylinder>();


    }
    #region 基础类
    [Serializable]
    
    public class Motorpara
    {
        public double maxspeed;
        public double acc;
        public double dec;
        public double Axis1_Upperlimit;//轴位置上限
        public double Axis1_Lowerlimit;//轴位置下限
        public double Axis2_Upperlimit;//轴位置上限
        public double Axis2_Lowerlimit;//轴位置下限
        public double Axis3_Upperlimit;//轴位置上限
        public double Axis3_Lowerlimit;//轴位置下限
        public double Axis4_Upperlimit;//轴位置上限
        public double Axis4_Lowerlimit;//轴位置下限
        public double Axis1_testHome;//轴检测初始点
        public double Axis2_testHome;//轴检测初始点
        public double Axis3_testHome;//轴检测初始点
        public double Axis4_testHome;//轴检测初始点
        public double Axis1_testHomeSpeed;//轴检测初始点速度
        public double Axis2_testHomeSpeed;//轴检测初始点速度
        public double Axis3_testHomeSpeed;//轴检测初始点速度
        public double Axis4_testHomeSpeed;//轴检测初始点速度
    }
    [Serializable]
    
    public class PointPosition
    {
        public int ID { get; set; }
        public double Axis1Position { get; set; }
        public double Axis2Position { get; set; }
        public double Axis3Position { get; set; }
        public double Axis4Position { get; set; }
        public double Axis1Velocity { get; set; }
        public double Axis2Velocity { get; set; }
        public double Axis3Velocity { get; set; }
        public double Axis4Velocity { get; set; }
    }
    /// <summary>
    /// 电机属性
    /// </summary>
    public class Property_Inovance
    {
        /// <summary>
        /// PLC正常
        /// </summary>
        public bool HMI_PLCStartOK;
        /// <summary>
        /// PLC报错代码
        /// </summary>
        public double HMI_PLCErrorCode;
        /// <summary>
        /// 轴1
        /// </summary>
        public Property_Axis PC_Axis1;
        /// <summary>
        /// 轴2
        /// </summary>
        public Property_Axis PC_Axis2;
        /// <summary>
        /// 轴3
        /// </summary>
        public Property_Axis PC_Axis3;
        /// <summary>
        /// 轴4
        /// </summary>
        public Property_Axis PC_Axis4;

        /// <summary>
        /// 气缸检测是否成功
        /// </summary>
        public bool Cy_Check = false;

       
        public Property_Inovance()
        {
            PC_Axis1 = new Property_Axis();
            PC_Axis2 = new Property_Axis();
            PC_Axis3 = new Property_Axis();
            PC_Axis4 = new Property_Axis();
        }
    }
    /// <summary>
    /// 轴属性
    /// </summary>
    public class Property_Axis
    {
        /// <summary>
        /// 轴执行命令
        /// </summary>
        public int Axis_Action = 0;
        /// <summary>
        /// 轴命令参数1
        /// </summary>
        public int Axis_Action_Para1 = 0;
        /// <summary>
        /// 轴命令参数2
        /// </summary>
        public int Axis_Action_Para2 = 0;
        /// <summary>
        /// 轴命令参数3
        /// </summary>
        public int Axis_Action_Para3 = 0;
        /// <summary>
        /// 轴命令参数4
        /// </summary>
        public int Axis_Action_Para4 = 0;
        /// <summary>
        /// 轴Busy
        /// </summary>
        public bool Axis_Busy = false;
        /// <summary>
        /// 轴Done
        /// </summary>
        public bool Axis_Done = false;
        /// <summary>
        /// 轴Error
        /// </summary>
        public bool Axis_Error = false;
        /// <summary>
        /// 轴ori
        /// </summary>
        public bool Axis_Ori = false;
        /// <summary>
        /// 轴P
        /// </summary>
        public bool Axis_P = false;
        /// <summary>
        /// 轴N
        /// </summary>
        public bool Axis_N = false;
        /// <summary>
        /// 轴HomeDone
        /// </summary>
        public bool Axis_HomeDone = false;
        /// <summary>
        /// 轴当前位置
        /// </summary>
        public double Axis_Position = 0;

        //public Property_Axis()
        //{

        //    Axis_Action = 0;
           
        //    Axis_Action_Para1 = 0;
           
        //    Axis_Action_Para2 = 0;
            
        //    Axis_Action_Para3 = 0;
            
        //    Axis_Action_Para4 = 0;
            
        //    Axis_Busy = false;
            
        //    Axis_Done = false;
            
        //    Axis_Error = false;
          
        //    Axis_Ori = false;
         
        //    Axis_P = false;
           
        //    Axis_N = false;
          
        //    Axis_Position = 0;
        //}
    }


    [Serializable]
    /// <summary>
    /// 气缸参数
    /// </summary>
    public class Para_Cylinder
    {
        /// <summary>
        ///气缸名称
        /// </summary>
        public string Cy_Name = "";
        /// <summary>
        ///到位延时时间(s)
        /// </summary>
        public double Cy_OK_DelayTime = 0.1;
        /// <summary>
        ///屏蔽延时时间(s)
        /// </summary>
        public double Cy_Ignore_DelayTime = 1;
        /// <summary>
        ///报警时间(s)
        /// </summary>
        public double Cy_Alarm_Time = 3;
        /// <summary>
        ///屏蔽原位信号
        /// </summary>
        public bool Cy_Ori_Ignore = false;
        /// <summary>
        ///屏蔽动点信号
        /// </summary>
        public bool Cy_Work_Ignore = false;
        /// <summary>
        ///原位传感器地址
        /// </summary>
        public int Cy_Ori_Sensor = 0;
        /// <summary>
        ///动位传感器地址
        /// </summary>
        public int Cy_Work_Sensor = 0;
        /// <summary>
        ///原位阀地址
        /// </summary>
        public int Cy_Ori_Valve = 0;
        /// <summary>
        ///动位阀地址
        /// </summary>
        public int Cy_Work_Valve = 0;



        ///原位传感器
        /// </summary>
        public bool Cy_Ori_Sensor_Status = false;
        /// <summary>
        ///动位传感器
        /// </summary>
        public bool Cy_Work_Sensor_Status = false;
        /// <summary>
        ///原位阀
        /// </summary>
        public bool Cy_Ori_Valve_Status = false;
        /// <summary>
        ///原位阀之前状态
        /// </summary>
        public bool Cy_Ori_Valve_Status_Before = false;
        /// <summary>
        ///动位阀
        /// </summary>
        public bool Cy_Work_Valve_Status = false;
        /// <summary>
        ///动位阀之前状态
        /// </summary>
        public bool Cy_Work_Valve_Status_Before = false;
        /// <summary>
        ///报错
        /// </summary>
        public bool bError = false;
        /// <summary>
        ///原点报错
        /// </summary>
        public bool bErrorOrg = false;
        /// <summary>
        ///动点报错
        /// </summary>
        public bool bErrorWork = false;
        /// <summary>
        ///返回值
        /// </summary>
        public int Ret_NUM = 0;
        /// <summary>
        ///动位动作允许
        /// </summary>
        public bool Allow_Work = false;
        /// <summary>
        ///原位动作允许
        /// </summary>
        public bool Allow_Org = false;
        /// <summary>
        ///工作
        /// </summary>
        public bool work_mode = false;
        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime Action_Time;

    }




    [Serializable]
    //IO参数
    public class IO
    {
        /// <summary>
        /// IO名称
        /// </summary>
        public string IO_Name;
        /// <summary>
        /// IO地址
        /// </summary>
        public int IO_Index;
        /// <summary>
        /// IO值
        /// </summary>
        public bool IO_Value;
        public IO()
        {
            IO_Name = "";
            IO_Index = 0;
            IO_Value = false;
        }
    }

    /// <summary>
    /// PLC地址
    /// </summary>
    public enum PLC_Address
    {
        //系统
        PLCStartOK = 1000,
        //IO
        Input = 1,
        Output =10,
        
        //轴1
        Axis1_Action = 10000,
        Axis1_Action_Para1 = 10002,
        Axis1_Action_Para2 = 10004,
        Axis1_Action_Para3 = 10006,
        Axis1_Action_Para4 = 10008,
        Axis1_Position = 10010,
        Axis1_Status = 10012,
        //轴2
        Axis2_Action = 10100,
        Axis2_Action_Para1 = 10102,
        Axis2_Action_Para2 = 10104,
        Axis2_Action_Para3 = 10106,
        Axis2_Action_Para4 = 10108,
        Axis2_Position = 10110,
        Axis2_Status = 10112,
        //轴3
        Axis3_Action = 10200,
        Axis3_Action_Para1 = 10202,
        Axis3_Action_Para2 = 10204,
        Axis3_Action_Para3 = 10206,
        Axis3_Action_Para4 = 10208,
        Axis3_Position = 10210,
        Axis3_Status = 10212,
        //轴4
        Axis4_Action = 10300,
        Axis4_Action_Para1 = 10302,
        Axis4_Action_Para2 = 10304,
        Axis4_Action_Para3 = 10306,
        Axis4_Action_Para4 = 10308,
        Axis4_Position = 10310,
        Axis4_Status = 10312,

    }

    #endregion


}
