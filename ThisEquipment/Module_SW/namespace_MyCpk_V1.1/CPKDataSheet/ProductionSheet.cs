using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCpk
{
   
        public class ProductionSheet
        {
            /// <summary>
            /// 主键-时间戳-yyyyMMddHHmmssfff
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 项目
            /// </summary>
            public string Project { get; set; }
            /// <summary>
            /// SN
            /// </summary>
            public string SN { get; set; }

            /// <summary>
            /// 时间
            /// </summary>
            public DateTime Time { get; set; }

            /// <summary>
            /// 数据
            /// </summary>
            public string Data { get; set; }
 
    }

    
}
