using System;
using System.Collections.Generic;
using System.Text;

namespace ANNS
{
    /// <summary>
    /// S形状单元
    /// </summary>
    public class SigmoidUnit
    {
        public void Test()
        {
            /*
             σ(sigma)
             输出o=σ(w*x)
             
            其中 σ(y)=1/(1 + e^-y)

             */
        }

        /// <summary>
        /// σ(sigma)，逻辑函数,返回0~1，随输出单调递增
        /// </summary>
        /// <returns></returns>
        public double Sigma()
        {
            return 0;
        }
    }
}
