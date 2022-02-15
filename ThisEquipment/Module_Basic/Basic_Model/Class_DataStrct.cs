using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


[Serializable]
public class Variable
{
    public int index = 0;
    public string type = "Int";
    public string name = "Value";
    public object value = 0;
    public string info = string.Empty;
    public int variableType = 1;        //0表示系统变量     1表示自定义变量
    public Variable()
    {
        index = 0;
        type = "int";
        name = "Value";
        value = 0;
        info = string.Empty;
        variableType = 1;

    }
    internal Variable(int index, string type, string name)
    {
        this.index = index;
        this.type = type;
        this.name = name;
        if(type == "int")    { value = (int)0; }
        if(type == "double") { value = (double)0; }
        if(type == "bool")   { value = (bool)false; }
        if(type == "string") { value = ""; }
    }

}


/// <summary>
/// 工具的输入输出类
/// </summary>
[Serializable]
public class ToolIO
{
    /// <summary>
    /// IO名称
    /// </summary>
    public string IOName;
    /// <summary>
    /// IO名称
    /// </summary>
    public string IOText;
    /// <summary>
    /// IOTipInfo
    /// </summary>
    public string IOTipInfo;

    /// <summary>
    /// IO类型：0;输入,1.输出
    /// </summary>
    public bool IOInfo = false;

    /// <summary>
    /// IO类型：Int,double
    /// </summary>
    public string IOType;

    /// <summary>
    /// IO转换类型
    /// </summary>
    public string TypeConverter;

    /// <summary>
    /// 自己的值
    /// </summary>
    public object ValueObject { get; set; } = null;

    /// <summary>
    /// 自己的地址
    /// </summary>
    public string IOAddress = "";

    /// <summary>
    /// IO分类
    /// </summary>
    public string IOCategory = "";


    /// <summary>
    /// 是否绑定
    /// </summary>
    public bool Binding = false;

    /// <summary>
    /// 绑定的流程
    /// </summary>
    public string BindingProcess;

    /// <summary>
    /// 绑定的参数名称
    /// </summary>
    public string BindingParaName;

    /// <summary>
    /// 绑定的值
    /// </summary>
    public object BindingValueObject = null;

    /// <summary>
    /// 绑定的对象
    /// </summary>
    public object BindingObject = null;
}

/// <summary>
/// 提示类型
/// </summary>
public enum TipType
{
    Tip,
    Warn,
    Error,
}






