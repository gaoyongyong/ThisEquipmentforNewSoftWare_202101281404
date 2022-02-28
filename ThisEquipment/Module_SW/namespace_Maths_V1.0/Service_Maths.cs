using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maths
{
    [Serializable]
    public class Service_Maths
    {
        
        /// <summary>
        /// 加
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Add(double x, double y,out double z)
        {

            //  MessageBox.Show("输入参数: \r\ndouble:" + x.ToString() + "; int:" + y.ToString());
            //  MessageBox.Show("运行：ADD =" + (x + y).ToString());
            try
            {
                double z1 = x + y;
                z = z1;
                return true;
            }
            catch (Exception ex)
            {
                z = 0;
                return false;
            }
            
        }

        /// <summary>
        /// 减
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Minus(double x, double y, out double z) 
        {
            // MessageBox.Show("输入参数: \r\nint:" + x.ToString() + "; double:" + y.ToString());
            // MessageBox.Show("运行：MINUS =" + (x - y).ToString());

            try
            {
                double z1 = x + y;
                z = z1;
                return true;
            }
            catch (Exception ex)
            {
                z = 0;
                return false;
            }
        }

       

        /// <summary>
        /// 乘
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Multiply(double x, double y, out double z)
        {
            try
            {
                double z1 = x * y;
                z = z1;
                return true;
            }
            catch (Exception ex)
            {
                z = 0;
                return false;
            }


        }

        /// <summary>
        /// 除
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Divide(double x, double y, out double z)
        {

            try
            {
                double z1 = x / y;
                z = z1;
                return true;
            }
            catch (Exception ex)
            {
                z = 0;
                return false;
            }

        }

        /// <summary>
        /// 取反
        /// </summary>
        /// <param name="isTrue"></param>
        /// <returns></returns>
        public bool Negation(bool isTrue)
        {

            MessageBox.Show("输入参数: \r\nbool:" + isTrue.ToString());
            MessageBox.Show("运行：NEGATION =" + (!isTrue).ToString());
            return !isTrue;
        }

     
        
    }
}
