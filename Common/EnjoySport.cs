using System;
using static Common.Enums;

namespace Common
{
    /// <summary>
    /// 水上运动
    /// （Aldo进行水上运动的日子）
    /// </summary>
    public class EnjoySport
    {
        /// <summary>
        /// 是否参与水上运动
        /// </summary>
        public bool IsSport { get; set; }

        public Sky Sky { get; set; }

        public AirTemp AirTemp { get; set; }

        public Humidity Humidity { get; set; }

        public Wind Wind { get; set; }

        public Water Water { get; set; }

        public Forecast Forecast { get; set; }


        public EnjoySport()
        {

        }
    }
}
