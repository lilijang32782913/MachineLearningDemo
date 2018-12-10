using System;
using System.Collections.Generic;
using System.Text;

namespace ANNS
{
    /// <summary>
    /// 反向传播算法 Backpropagation
    /// </summary>
    public class Backpropagation
    {
        public void Test()
        {
            /*
              误差：
              E(W) = 1/2 * Σ Σ(tkd-okd)^2
                         d∈D k∈outputs

            其中outputs是网络输出单元的集合， tkd和okd是与训练样例d和第k个输出单元相关的输出值。
             */
        }

        /// <summary>
        /// 训练
        /// </summary>
        /// <param name="training_examples">训练数据集</param>
        /// <param name="nin">网络输入数量</param>
        /// <param name="nout">网络输出元数量</param>
        /// <param name="nhidden">隐藏层单元数量</param>
        /// <param name="η">学习速率</param>
        public void Train(List<ExampleInfo> training_examples,int nin,int nout,int nhidden, double η=0.001)
        {

        }
    }
}
