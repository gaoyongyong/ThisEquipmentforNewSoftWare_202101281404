using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProStatistics
{
    public class ProStatisticsModel
    {

        #region Model
        private string statisticsItems;
        private string statisticsValue;
        private long proTotal;
        private long proPass;
        private long proFail;
        private string cT;
        private string cTStartTime;
        private string cTEndTime;
        #endregion
        #region
        /// <summary>
        /// 
        /// </summary>
        public string StatisticsItems
        {
            get
            {
                return statisticsItems;
            }

            set
            {
                statisticsItems = value;
            }
        }

        public string StatisticsValue
        {
            get
            {
                return statisticsValue;
            }

            set
            {
                statisticsValue = value;
            }
        }

        public long ProTotal
        {
            get
            {
                return proTotal;
            }

            set
            {
                proTotal = value;
            }
        }

        public long ProFail
        {
            get
            {
                return proFail;
            }

            set
            {
                proFail = value;
            }
        }

        public long ProPass
        {
            get
            {
                return proPass;
            }

            set
            {
                proPass = value;
            }
        }

        public string CT
        {
            get
            {
                return cT;
            }

            set
            {
                cT = value;
            }
        }

        public string CTStartTime
        {
            get
            {
                return cTStartTime;
            }

            set
            {
                cTStartTime = value;
            }
        }

        public string CTEndTime
        {
            get
            {
                return cTEndTime;
            }

            set
            {
                cTEndTime = value;
            }
        }
        #endregion
    }
}
