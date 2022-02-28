using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Service_System
    {

        /// <summary>
        /// 延时
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Delay(double Delay_Time)
        { 
            try
            {
                Class_Delay.MyDelaySecond(Convert.ToUInt32(Delay_Time * 1000));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
