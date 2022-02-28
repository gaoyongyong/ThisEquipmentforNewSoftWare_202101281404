using Tools;
using Maths;
using Parameter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Basic_UI;
using System.ComponentModel;

/// <summary>
/// 工具信息类
/// </summary>
[XmlInclude(typeof(List<string>))]
[XmlInclude(typeof(List<double>))]
[XmlInclude(typeof(string[]))]
[XmlInclude(typeof(ToolSetting.UI.TCPClient.Model_TCPClient))]
[XmlInclude(typeof(ToolSetting.UI.Serial.Model_Serial))]
[XmlInclude(typeof(Inovance.Model_Inovance))]
[XmlInclude(typeof(Inovance.Model_Inovance))]
[XmlInclude(typeof(ScriptCaculate.Model_ScriptCaculate))]

[Serializable]
public class ToolInfo
{
    /// <summary>
    /// 工具是否启用
    /// </summary>
    public bool toolenable;
    /// <summary>
    /// 工具组名称
    /// </summary>
    public string toolGroupName;
    /// <summary>
    /// 工具名称
    /// </summary>
    public string toolName;

    /// <summary>
    /// 工具方法
    /// </summary>
    public string toolMethod;

    /// <summary>
    /// 工具屏蔽后方法
    /// </summary>
    public string toolMarkMethod;

    /// <summary>
    /// 工具对象
    /// </summary>
   // public ToolBase tool;
    /// <summary>
    /// 工具描述信息
    /// </summary>
    public string toolTipInfo = "无";
    /// 工具ID
    /// </summary>
    public int toolID = -1;

    /// 工具Address
    /// </summary>
    public string toolAddress = "";

    /// <summary>
    /// 工具输入字典集合
    /// </summary>
    public List<ToolIO> input;
    /// <summary>
    /// 工具输出字典集合
    /// </summary>
    public List<ToolIO> output;



    /// <summary>
    /// 执行结果
    /// </summary>
    public string Log_Process = "";
    /// <summary>
    /// 运行时间
    /// </summary>
    public string RunTime = "";
    /// <summary>
    /// 执行结果
    /// </summary>
    public string RunResult = "";
    /// <summary>
    /// 工具运行类型0:一次执行 1.出错后连续运行 2.禁用
    /// </summary>
    public double Now_Step = -1;

    /// <summary>
    /// 运行成功后下一步
    /// </summary>
    public double Next_Step = 0;

    /// <summary>
    /// 工具模式false:失败后继续运行 true:失败后循环该步运行
    /// </summary>
    public bool tool_Mode = false;
    /// <summary>
    /// 报错条例
    /// </summary>
    public static string  Error_String = "";

    //线程锁
    object obj = new object();
    public ToolInfo()
    {
        toolenable = true;
        toolName = string.Empty;
        // tool = new ToolBase();
        input = new List<ToolIO>();

        output = new List<ToolIO>();
    }
  

    /// <summary>
    /// 以IO名获取IO对象
    /// </summary>
    /// <param name="IOName"></param>
    /// <returns></returns>
    public ToolIO GetInput(string IOName)
    {
        for (int i = 0; i < input.Count; i++)
        {
            if (input[i].IOName == IOName)
                return input[i];
        }
        return new ToolIO();
    }
    /// <summary>
    /// 以IO名获取IO对象
    /// </summary>
    /// <param name="IOName"></param>
    /// <returns></returns>
    public ToolIO GetOutput(string IOName)
    {
        for (int i = 0; i < output.Count; i++)
        {
            if (output[i].IOName == IOName)
                return output[i];
        }

        return new ToolIO();
    }

    /// <summary>
    /// 执行工具
    /// </summary>
    /// <returns></returns>
    public bool RunTool()
    {
        lock (obj) 
        { 
       
        //清理运行LOG
        Log_Process = "";
        //清理报错代码
        Error_String = "";
        //计时开始
        uint t1 = CAPI.GetTickCount();
        //如果工具屏蔽则不执行
        if (!toolenable)
        {
            uint Alltime1 = CAPI.GetTickCount() - t1;
            RunTime = Alltime1 + "ms";
            Log_Process = Log_Process + "[" + toolAddress.ToString()  + "]" + "屏蔽中" + ";";
            RunResult = "OK";
            if (tool_Mode == true)
            {
                Next_Step = -1;
            }
            return true;
        }
        
        try
        {
            //第一步：读出输入输出的值
            object[] Para_obj = new object[input.Count() + output.Count()];
            for (int i = 0; i < input.Count(); i++)
            {
                //如果已经绑定信息
                if (input[i].Binding)
                {
                    string a = input[i].BindingObject.GetType().Name;
                    if (input[i].BindingObject.GetType().Name == "ToolIO")
                    {
                        Para_obj[i] = ((ToolIO)input[i].BindingObject).ValueObject;
                    }
                    else if (input[i].BindingObject.GetType().Name == "Variable")
                    {
                        Para_obj[i] = ((Variable)input[i].BindingObject).value;
                    }
                    else 
                    { 
                    }
                    
                    // Para_obj[i] = input[i].BindingObject;
                }
                else
                {
                    Para_obj[i] = input[i].ValueObject;
                }
            }
            for (int j = 0; j < output.Count(); j++)
            {

                Para_obj[input.Count() + j] = output[j].ValueObject;

            }


            //第二步：根据工具名和方法名取出方法

            object ClassObject = Form_Tool.toolGroupModel.Find(e1 => e1.GroupName == toolGroupName)?.GroupClassObject;

            if (ClassObject==null)
            {

                //记录lo错误信息

                Log_Process = Log_Process + "工具组不存在";
                return false;
            }
               
            MethodInfo Method = ClassObject.GetType().GetMethod(toolMethod);

            if (Method == null)
            {
                //记录lo错误信息
                Log_Process = Log_Process + "工具组中没有此方法";
                return false;
            }

            //第三步：执行动作
            object Result = Method.Invoke(ClassObject, Para_obj);

            //赋值输出
            for (int j = 0; j < output.Count(); j++)
            {

                output[j].ValueObject = Para_obj[input.Count() + j];

            }

           // Class_Delay.MyDelaySecond(2);

            //第四步记录LOG
            //第五步：决定运行下一步（判断结果=》1.如果工具模式是失败后一直运行，则下一部为本身步骤，否则下一步执行）
            if ((bool)Result==true)
            {
                uint Alltime1 = CAPI.GetTickCount() - t1;
                RunTime = Alltime1 + "ms";

                Log_Process = Log_Process + "[" + toolAddress.ToString()  + "]" + "执行成功,运行时间:" + Alltime1 + "ms;";

                for (int i = 0; i < input.Count(); i++)
                {
                    if (!input[i].Binding)
                    {
                        Log_Process = Log_Process + "输入变量" + i.ToString() + "<-" +
                                 input[i].IOName + "值为:" + Para_obj[i].ToString() + ";";
                    }
                    else
                    {
                        if (input[i].BindingObject.GetType().Name == "ToolIO")
                        {
                            Log_Process = Log_Process + "输入变量" + i.ToString() + "<-" +
                                input[i].IOName + "值为:" + ((ToolIO)input[i].BindingObject).ValueObject.ToString() + "（绑定信息:" + ((ToolIO)input[i].BindingObject).IOAddress + ")" + ";";
                        }
                        else if (input[i].BindingObject.GetType().Name == "Variable")
                        {
                            Log_Process = Log_Process + "输入变量" + i.ToString() + "<-" +
                                input[i].IOName + "值为:" + ((Variable)input[i].BindingObject).value.ToString() + "（绑定信息:" + ((Variable)input[i].BindingObject).name + ")" + ";";
                        }
                        else 
                        { 

                        }
                        
                    }


                }
                for (int i = 0; i < output.Count(); i++)
                {
                    switch (output[i].IOType)
                    {
                        case "List<string>":
                            Log_Process = Log_Process + "输出变量" + "->" +
                                output[i].IOName + "值为:";
                            List<string> stringsOutput = (List<string>)output[i].ValueObject;
                            for (int j = 0; j < stringsOutput.Count(); j++)
                            {
                                Log_Process = Log_Process + stringsOutput[j].ToString() + ",";
                            }
                            Log_Process = Log_Process + ";";
                            break;
                        case "List<double>":
                            Log_Process = Log_Process + "输出变量" + "->" +
                                output[i].IOName + "值为:";
                            List<double> doubleOutput = (List<double>)output[i].ValueObject;
                            for (int j = 0; j < doubleOutput.Count(); j++)
                            {
                                Log_Process = Log_Process + doubleOutput[j].ToString() + ",";
                            }
                            Log_Process = Log_Process + ";";
                            break;

                        default:
                            Log_Process = Log_Process + "输出变量" + "->" +
                                output[i].IOName + "值为:" + output[i].ValueObject.ToString()+";";
                            break;
                    }

                }


                RunResult = "OK";
                if (tool_Mode == true)
                {
                    Next_Step = -1;
                }
                return true;
            }
            else
            {
                //记录运行时间
                uint Alltime1 = CAPI.GetTickCount() - t1;
                RunTime = Alltime1 + "ms";
                Log_Process = Log_Process + "[" + toolAddress.ToString() + "]" + "执行失败,运行时间:" + Alltime1 + "ms," + "失败原因:" + Error_String + ";";
                RunResult = "NG";
                if (tool_Mode == true)
                {
                    Next_Step = Now_Step;
                }
                return false;
            }

        }

        catch (Exception ex)
        {
            //记录运行时间
            uint Alltime1 = CAPI.GetTickCount() - t1;
            RunTime = Alltime1 + "ms";
            Log_Process = Log_Process + "[" + toolAddress.ToString() + "]" + "执行失败,运行时间:" + Alltime1 + "ms," + "失败原因:";
            Log_Process = Log_Process + ex.ToString() + ";";
            RunResult = "NG";


            return false;
        }
    }
    }
}

[Serializable]
public class ToolGroupModel
{
    /// <summary>
    /// 工具组ID
    /// </summary>
    [Description("工具组ID")]
    public int GroupID;
    /// <summary>
    /// 工具组名称
    /// </summary>
    [Description("工具组名称")]
    public string GroupName;

    /// <summary>
    /// 工具组方法实例化类名
    /// </summary>
    [Description("工具组方法实例化类名")]
    public string GroupClassName;

    /// <summary>
    /// 工具组界面类名称
    /// </summary>
    [Description("工具组方法实例化类名")]
    public string GroupFormName;

    /// <summary>
    /// 工具组Model名称
    /// </summary>
    [Description("工具组Model类名")]
    public string GroupModelName;

    /// <summary>
    /// 工具组方法实例化类
    /// </summary>
    [Description("工具组方法实例化类object")]
    [XmlIgnore]
    public object GroupClassObject;

    /// <summary>
    /// 工具组方法实例化界面OBJECT
    /// </summary>
    [Description("工具组方法实例化界面OBJECT")]
    [XmlIgnore]
    public object GroupFormObject;

    /// <summary>
    /// 工具名称
    /// </summary>
    [Description("工具组名称")]
    public List<ToolInfo> tools;

    /// <summary>
    /// 工具组Model
    /// </summary>
    [Description("工具组Model")]
    public object Model;


   
}


