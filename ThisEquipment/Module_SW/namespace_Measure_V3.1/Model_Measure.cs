using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure
{
    public class TestExcepation
    {
        /// <summary>
        /// 测量数据大于3倍spec
        /// </summary>
        public static bool TestThreeData = false;

        /// <summary>
        /// 测量数据3次NG
        /// </summary>
        public static bool ThreeTimesNG = false;

        /// <summary>
        /// 测量数据次数
        /// </summary>
        public static int NG_Count = 0;

        /// <summary>
        /// SizeProperty = 1 NG
        /// </summary>
        public static bool SizeProperty1NG = false;
        /// <summary>
        /// 第二个检测结果
        /// </summary>
        public static bool SizeProperty2NG = false;
        /// <summary>
        /// 第三个检测结果
        /// </summary>
        public static bool SizeProperty3NG = false;
        /// <summary>
        /// 第四个检测结果
        /// </summary>
        public static bool SizeProperty4NG = false;
        /// <summary>
        /// 第五个检测结果
        /// </summary>
        public static bool SizeProperty5NG = false;
       
        /// <summary>
        /// 第六个检测结果
        /// </summary>
        public static string SizeProperty6 = "";
        /// <summary>
        /// 第七个检测结果
        /// </summary>
        public static string SizeProperty7 = "";
        /// 第八个检测结果
        /// </summary>
        public static string SizeProperty8 = "";

        /// <summary>
        /// 第一个检测结果最大值
        /// </summary>
        public static double SizeProperty1_Max = 0;
        /// <summary>
        /// 第一个检测结果最小值
        /// </summary>
        public static double SizeProperty1_Min = 0;
        /// <summary>
        /// 第二个检测结果最大值
        /// </summary>
        public static double SizeProperty2_Max = 0;
        /// <summary>
        /// 第二个检测结果最小值
        /// </summary>
        public static double SizeProperty2_Min = 0;
        /// <summary>
        /// 第三个检测结果最大值
        /// </summary>
        public static double SizeProperty3_Max = 0;
        /// <summary>
        /// 第三个检测结果最小值
        /// </summary>
        public static double SizeProperty3_Min = 0;
    }
  
    /// <summary>
    /// 测试项判定标准，测试内容中的一项的判定标准
    /// </summary>
    public class MeasureSize
    {
        public int ID { get; set; }
        public string SizeName { get; set; }
        public string SizeProperty { get; set; }
        public double NormValue { get; set; }
        public double UpperDeviation { get; set; }
        public double LowerDeviation { get; set; }
        public double K { get; set; }
        public double B { get; set; }
        public bool IsShow { get; set; }
        public bool IsJudging { get; set; }
        //public string Project { get; set; }
    }
    /// <summary>
    /// 测试项结果，测试内容中的一项的测试结果
    /// </summary>
    public class TestingData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int Remark { get; set; }
        public string JugeResult { get; set; }
    }
    /// <summary>
    /// 测试结果(静态)，一个产品的完整的测试结果
    /// </summary>
    public static class ProMeasureSize
    {
        /// <summary>
        /// 测试结果(静态)-序号
        /// </summary>
        public static string Serial { get; set; }
        /// <summary>
        /// 测试结果(静态)-二维码
        /// </summary>
        public static string Barcode { get; set; }
        /// <summary>
        /// 测试结果(静态)-测试时间
        /// </summary>
        public static string MeasureTime { get; set; }
        /// <summary>
        /// 测试结果(静态)-测试结果
        /// </summary>
        public static string MeasureResult { get; set; }

        ///// <summary>
        ///// 测试结果(静态)-一条测试项
        ///// </summary>
        //public static TestingData TestValue_Now = new TestingData();

        /// <summary>
        /// 测试结果(静态)-测试数据集合
        /// </summary>
        public static List<TestingData> TestValue { get; set; }


        /// <summary>
        ///  一个产品测试项判定标准的集合
        /// </summary>
        /// <typeparam name="MeasureSize"></typeparam>
        /// <param name=""></param>
        /// <returns></returns>
        public static List<MeasureSize> Sizes { get; set; }



        /// <summary>
        /// 显示的测试项名字？待确认
        /// </summary>
        public static List<string> NameList { get; set; } /*= new List<string>();*/
    }

}
