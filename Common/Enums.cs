using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Enums
    {
        /*
         Sky、AirTemp、Humidity、Wind、Water,Forecast
         */

        /// <summary>
        /// 天气
        /// </summary>
        public enum Sky
        {
            /// <summary>
            /// 任意都可以
            /// </summary>
            Anyone,
            /// <summary>
            /// 任何都不可以
            /// </summary>
            NoneNothing,
            Sunny,
            Cloudy,
            Rainy,
        }

        /// <summary>
        /// 天空温度
        /// </summary>
        public enum AirTemp
        {
            /// <summary>
            /// 任意都可以
            /// </summary>
            Anyone,
            /// <summary>
            /// 任何都不可以
            /// </summary>
            NoneNothing,
            /// <summary>
            /// 温暖
            /// </summary>
            Warm,
            /// <summary>
            /// 多云
            /// </summary>
            Cold
        }

        /// <summary>
        /// 天空湿度
        /// </summary>
        public enum Humidity
        {
            /// <summary>
            /// 任意都可以
            /// </summary>
            Anyone,
            /// <summary>
            /// 任何都不可以
            /// </summary>
            NoneNothing,
            Normal,
            High
        }

        /// <summary>
        /// 风量
        /// </summary>
        public enum Wind
        {
            /// <summary>
            /// 任意都可以
            /// </summary>
            Anyone,
            /// <summary>
            /// 任何都不可以
            /// </summary>
            NoneNothing,
            Strong,
            Weak
        }

        /// <summary>
        /// 水温
        /// </summary>
        public enum Water
        {
            /// <summary>
            /// 任意都可以
            /// </summary>
            Anyone,
            /// <summary>
            /// 任何都不可以
            /// </summary>
            NoneNothing,
            Warm,
            Cool
        }

        /// <summary>
        /// 天气预报
        /// </summary>
        public enum Forecast
        {
            /// <summary>
            /// 任意都可以
            /// </summary>
            Anyone,
            /// <summary>
            /// 任何都不可以
            /// </summary>
            NoneNothing,
            Same,
            Change
        }
    }
}
