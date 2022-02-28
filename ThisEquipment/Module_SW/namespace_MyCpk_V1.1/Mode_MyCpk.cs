using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCpk
{
   
    #region  //====数据结构体====//
    /// <summary>
    /// 数据结构体
    /// </summary>
    public struct MyRowsData
    {
        /// <summary>
        /// 标准值
        /// </summary>
        public double Normalvalue;
        /// <summary>
        /// 上限
        /// </summary>
        public double USL;
        /// <summary>
        /// 下限
        /// </summary>
        public double LSL;
        /// <summary>
        /// 实际值
        /// </summary>
        public double Realvalue;
    }
    #endregion
}
