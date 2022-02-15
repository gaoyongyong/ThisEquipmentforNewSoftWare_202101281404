using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.FormBuild.MySql.MysqlSheet
{
    public class ProductionInfo
    {
        /// <summary>
        /// 主键-时间戳-机器号+yyyyMMddHHmmssfff
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 机器号
        /// </summary>
        public string MacineID { get; set; }
        /// <summary>
        /// 工位号
        /// </summary>
        public string StationID { get; set; }
        /// <summary>
        /// 产品SN
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 生产时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 生产此产品耗时
        /// </summary>
        public string CT { get; set; }
        /// <summary>
        /// 此产品OK/NG,1/0
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 产品数据
        /// </summary>
        public string Data { get; set; }

    }

}
