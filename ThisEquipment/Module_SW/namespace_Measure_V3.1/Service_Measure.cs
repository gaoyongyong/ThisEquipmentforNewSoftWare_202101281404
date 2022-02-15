using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure
{


    enum JUDGEMENT_RESULT
    {
        OK = 0,
        NG,
        NG_Upper,
        NG_Under,
        EXCEPTION,
        BIN1,
        BIN2,
        pass1,  //5
        pass2,
        pass3,
        pass4,
        pass5,
        pass6,
        pass7,
        pass8,
        ng2
    }
    class Jugement
    {
        /// <summary>
        /// 判定一个料
        /// </summary>
        /// <param name="testingDataList">一个料的测量数据</param>
        /// <param name="measureSizeList">一个料的设定参数</param>
        /// <returns></returns>
        public static bool? JugeTestingData(ref List<TestingData> testingDataList,List<MeasureSize> measureSizeList)
        {
            

            if (testingDataList == null)
                return false;
            
            bool ret = true;//OK
            foreach (TestingData testingData in testingDataList)
            {
                foreach (MeasureSize measureSize in measureSizeList)
                {
                    if (testingData.Name == measureSize.SizeName)
                    {
                       // TestExcepation.TestThreeData = false;
                        //第0步：添加补偿
                        testingData.Value = (testingData.Value - measureSize.NormValue) * 1 + measureSize.B + measureSize.NormValue;

                        #region //分PIN
                        //赋值最大最小值
                        switch (measureSize.SizeProperty)
                        {
                            case "1":
                                if (testingData.Value >= TestExcepation.SizeProperty1_Max)
                                {
                                    TestExcepation.SizeProperty1_Max = testingData.Value;
                                };
                                if ((testingData.Value <= TestExcepation.SizeProperty1_Min) || (TestExcepation.SizeProperty1_Min == 0))
                                {
                                    TestExcepation.SizeProperty1_Min = testingData.Value;
                                };
                                break;
                            case "2":
                                if (testingData.Value >= TestExcepation.SizeProperty2_Max)
                                {
                                    TestExcepation.SizeProperty2_Max = testingData.Value;
                                };
                                if ((testingData.Value <= TestExcepation.SizeProperty2_Min) || (TestExcepation.SizeProperty2_Min == 0))
                                {
                                    TestExcepation.SizeProperty2_Min = testingData.Value;
                                };
                                break;
                            case "3":
                                if (testingData.Value >= TestExcepation.SizeProperty3_Max)
                                {
                                    TestExcepation.SizeProperty3_Max = testingData.Value;
                                };
                                if ((testingData.Value <= TestExcepation.SizeProperty3_Min) || (TestExcepation.SizeProperty3_Min == 0))
                                {
                                    TestExcepation.SizeProperty3_Min = testingData.Value;
                                };
                                break;

                            default:
                                break;

                        }

                        //等级A
                        if ((testingData.Value >= (measureSize.NormValue - 0.05)) & (testingData.Value <= (measureSize.NormValue + 0.05)))
                        {
                            switch (measureSize.SizeProperty)
                            {
                                case "6":
                                    if ((TestExcepation.SizeProperty1_Max - TestExcepation.SizeProperty1_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty6 = "A1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty1_Max - TestExcepation.SizeProperty1_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty6 = "A2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty6 = "A3 level";
                                    }
                                    break;
                                case "7":
                                    if ((TestExcepation.SizeProperty2_Max - TestExcepation.SizeProperty2_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty7 = "A1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty2_Max - TestExcepation.SizeProperty2_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty7 = "A2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty7 = "A3 level";
                                    }
                                    break;
                                case "8":
                                    if ((TestExcepation.SizeProperty3_Max - TestExcepation.SizeProperty3_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty8 = "A1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty3_Max - TestExcepation.SizeProperty3_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty8 = "A2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty8 = "A3 level";
                                    }
                                    break;

                                default:
                                    break;

                            }
                        }
                        //等级B
                        else if ((testingData.Value >= (measureSize.NormValue - 0.1)) & (testingData.Value <= (measureSize.NormValue + 0.1)))
                        {
                            switch (measureSize.SizeProperty)
                            {
                                case "6":
                                    if ((TestExcepation.SizeProperty1_Max - TestExcepation.SizeProperty1_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty6 = "B1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty1_Max - TestExcepation.SizeProperty1_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty6 = "B2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty6 = "B3 level";
                                    }
                                    
                                    break;
                                case "7":
                                    if ((TestExcepation.SizeProperty2_Max - TestExcepation.SizeProperty2_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty7 = "B1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty2_Max - TestExcepation.SizeProperty2_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty7 = "B2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty7 = "B3 level";
                                    }
                                    break;
                                case "8":
                                    if ((TestExcepation.SizeProperty3_Max - TestExcepation.SizeProperty3_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty8 = "B1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty3_Max - TestExcepation.SizeProperty3_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty8 = "B2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty8 = "B3 level";
                                    }
                                    break;
                                default:
                                    break;

                            }
                        }
                        //等级C
                        else if ((testingData.Value >= (measureSize.NormValue - 0.15)) & (testingData.Value <= (measureSize.NormValue + 0.15)))
                        {
                            switch (measureSize.SizeProperty)
                            {
                                case "6":
                                    if ((TestExcepation.SizeProperty1_Max - TestExcepation.SizeProperty1_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty6 = "C1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty1_Max - TestExcepation.SizeProperty1_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty6 = "C2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty6 = "C3 level";
                                    }                                   
                                    break;
                                case "7":
                                    if ((TestExcepation.SizeProperty2_Max - TestExcepation.SizeProperty2_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty7 = "C1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty2_Max - TestExcepation.SizeProperty2_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty7 = "C2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty7 = "C3 level";
                                    }
                                    break;
                                case "8":
                                    if ((TestExcepation.SizeProperty3_Max - TestExcepation.SizeProperty3_Min) <= 0.05)
                                    {
                                        TestExcepation.SizeProperty8 = "C1 level";
                                    }
                                    else if ((TestExcepation.SizeProperty3_Max - TestExcepation.SizeProperty3_Min) <= 0.08)
                                    {
                                        TestExcepation.SizeProperty8 = "C2 level";
                                    }
                                    else
                                    {
                                        TestExcepation.SizeProperty8 = "C3 level";
                                    }
                                    break;

                                default:
                                    break;

                            }
                        }
                  
                        //等级E
                        else
                        {
                            switch (measureSize.SizeProperty)
                            {
                                case "6":
                                    TestExcepation.SizeProperty6 = "E level";
                                    break;
                                case "7":
                                    TestExcepation.SizeProperty7 = "E level";
                                    break;
                                case "8":
                                    TestExcepation.SizeProperty8 = "E level";
                                    break;
                                default:
                                    break;

                            }
                        }
                        #endregion

                        //第一步：非异常值，检查是否需要进行判定
                        if (measureSize.IsJudging == false)//如果不参与判定，直接判定为OK即可
                        {                       
                            testingData.JugeResult = JUDGEMENT_RESULT.OK.ToString();
                            if (testingData.Value > measureSize.NormValue + 1 * measureSize.UpperDeviation
                            || testingData.Value < measureSize.NormValue - 1 * measureSize.LowerDeviation)
                            {
                                switch (measureSize.SizeProperty)
                                {
                                    case "1":
                                        TestExcepation.SizeProperty1NG = true;
                                        break;
                                    case "2":
                                        TestExcepation.SizeProperty2NG = true;
                                        break;
                                    case "3":
                                        TestExcepation.SizeProperty3NG = true;
                                        break;
                                    case "4":
                                        TestExcepation.SizeProperty4NG = true;
                                        break;
                                    case "5":
                                        TestExcepation.SizeProperty5NG = true;
                                        break;
                                  
                                    default:
                                        break;

                                }
                            }
                            break;
                        }
                        //第二步：如果需要判定，检查异常值（超3倍公差）                        
                        else if (testingData.Value > measureSize.NormValue + measureSize.K * (measureSize.UpperDeviation+ measureSize.LowerDeviation)
                            || testingData.Value < measureSize.NormValue - measureSize.K * (measureSize.UpperDeviation + measureSize.LowerDeviation))
                        {
                            testingData.JugeResult = JUDGEMENT_RESULT.NG.ToString();

                            //超差结果
                            TestExcepation.TestThreeData = true;
                            switch (measureSize.SizeProperty)
                            {
                                case "1":
                                    TestExcepation.SizeProperty1NG = true;
                                    break;
                                case "2":
                                    TestExcepation.SizeProperty2NG = true;
                                    break;
                                case "3":
                                    TestExcepation.SizeProperty3NG = true;
                                    break;
                                case "4":
                                    TestExcepation.SizeProperty4NG = true;
                                    break;
                                case "5":
                                    TestExcepation.SizeProperty5NG = true;
                                    break;
                              
                                default:
                                    break;

                            }
                            ret = false;
                            break;
                        }
                        //第三步：如果需要判定，判定OK/NG
                        else if (testingData.Value > measureSize.NormValue + measureSize.UpperDeviation)
                        {
                            testingData.JugeResult = JUDGEMENT_RESULT.NG_Upper.ToString();

                            //超差结果                         
                            switch (measureSize.SizeProperty)
                            {
                                case "1":
                                    TestExcepation.SizeProperty1NG = true;
                                    break;
                                case "2":
                                    TestExcepation.SizeProperty2NG = true;
                                    break;
                                case "3":
                                    TestExcepation.SizeProperty3NG = true;
                                    break;
                                case "4":
                                    TestExcepation.SizeProperty4NG = true;
                                    break;
                                case "5":
                                    TestExcepation.SizeProperty5NG = true;
                                    break;
                                
                                default:
                                    break;

                            }
                            break;
                        }
                        else if (testingData.Value < measureSize.NormValue - measureSize.LowerDeviation)
                        {
                            testingData.JugeResult = JUDGEMENT_RESULT.NG_Under.ToString();

                            //超差结果                         
                            switch (measureSize.SizeProperty)
                            {
                                case "1":
                                    TestExcepation.SizeProperty1NG = true;
                                    break;
                                case "2":
                                    TestExcepation.SizeProperty2NG = true;
                                    break;
                                case "3":
                                    TestExcepation.SizeProperty3NG = true;
                                    break;
                                case "4":
                                    TestExcepation.SizeProperty4NG = true;
                                    break;
                                case "5":
                                    TestExcepation.SizeProperty5NG = true;
                                    break;
                              
                                default:
                                    break;

                            }
                            break;
                        }
                        else
                        {
                            testingData.JugeResult = JUDGEMENT_RESULT.OK.ToString();
                            
                            break;
                        }

                       
                    }
                }
            }
            //Common.camaraDataProcessedQueue.Enqueue(camaraDataList);
            return ret;
        }
    }



}
