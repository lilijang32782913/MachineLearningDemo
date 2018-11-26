using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ANNS
{
    /*
        training_examples中每一个训练样例形式为序偶<x,t>，其中x是输入值向量，t是目标输出值。 
    */
    /// <summary>
    /// 样例(x1...xn的输入和输出t)
    /// </summary>
    public class ExampleInfo
    {
        /// <summary>
        /// 向量[x1,x2...xn]
        /// </summary>
        public double[] X { get; set; }

        /// <summary>
        /// 输出值
        /// </summary>
        public double T { get; set; }
    }
}
