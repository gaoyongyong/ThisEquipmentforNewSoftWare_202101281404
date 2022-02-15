using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCaculate
{
    public class Model_ScriptCaculate
    {
        /// <summary>
        /// 脚本
        /// </summary>
        public List<string> ScriptText;

        public Model_ScriptCaculate() 
        {
            ScriptText = new List<string>();
        }
    }
    /// <summary>
    /// 点位坐标
    /// </summary>
    public struct point
    {
        public double X;
        public double Y;
    }

    /// <summary>
    /// 方法枚举
    /// </summary>
    public enum functionsNote
    {
        [Description("直接赋值:\r\n---void ASSIGN(string str1)")]
        ASSIGN = 1,
        [Description("两数相加:\r\n---double ADD(string str1, string str2)")]
        ADD = 2,
        [Description("两数相减:\r\n---double SUB(string str1, string str2))")]
        SUB = 3,
        [Description("两数相乘:\r\n---double MUL(string str1, string str2")]
        MUL = 4,
        [Description("两数相除:\r\n---double DIV(string str1, string str2)")]
        DIV = 5,
        [Description("点p2到p0(起点),p1(终点)形成直线(并旋转角度str4)的水平距离,返回double值:\r\n---P_PPXDistance(string str1, string str2, string str3, string str4)")]
        P_PPXDistance = 6,
        [Description("点p2到p0(起点),p1(终点)形成直线(并旋转角度str4)的垂直距离,返回double值:\r\n---P_PPYDistance(string str1, string str2, string str3, string str4)")]
        P_PPYDistance = 7,
        [Description("由机械坐标系(str1点变量)和相机坐标系(str2,str3数据变量)生成最终坐标系:\r\n---point P_PPYDistance(string str1, string str2, string str3)")]
        MCSCCStoCS = 8,
        [Description("求绝对值:\r\n---double ABS(string str1)")]
        ABS = 9,
        [Description("点直接赋值:\r\n---void ASSIGN_Point(string str1,string str2)")]
        ASSIGN_Point = 10,
        [Description("两点间的距离:\r\n---double Distance_Points(string str1,string str2)")]
        Distance_Points = 11,
    }
}
