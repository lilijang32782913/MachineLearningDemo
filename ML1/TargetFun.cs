using System;
using System.Collections.Generic;
using System.Text;

namespace ML1
{
    /// <summary>
    /// 目标函数
    /// </summary>
    class TargetFun
    {
        public decimal m1 { get; set; }
        public decimal m2 { get; set; }

        /// <summary>
        /// 训练样例 <b,Vtrain(b)>
        /// </summary>
        public IDictionary<string,object> DemoList { get; set; }

        /// <summary>
        /// 权值调整(用于训练m1~mn的权值)
        /// </summary>
        public void WeightAdjust()
        {
            /*
             目标：使得 Σ(Vtrain(b)-Vnear(b))^2 最小
             */

            /*
             对于每一个训练样例<b，Vtrain(b)>
            • 使用当前的权计算 Vˆ(b)
            • 对每一个权值wi
            w进行如下更新
            i←wi+η(VtrainVˆ(b)-(b))x
             */
        }

        /// <summary>
        /// 逼近函数:
        /// V函数的逼近函数(表示能大体评估份值)
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public decimal Vnear(object b)
        {
            /*
             x1：棋盘上黑子的数量
             x2：棋盘上红子的数量
             x3：棋盘上黑王的数量
             x4：棋盘上红王的数量
             x5：被红子威胁的黑子数量（即会在下一次被红吃掉的子）

                于是，学习程序把：被黑子威胁的红子数量
                Vˆ(b)表示为一个线性函数
                Vˆ(b)=w0+w1x1+w2x2+w3x3+w4x4+w5x5+w6x
             */

            /*
             Vtrain(训练中间的权值结果，即单次训练结果)
             Vnear(successor(b))(表示b走后对手回一步的棋盘状态)

            Vtrain(b)<-Vnear(successor(b))
             */

            return 0;
        }

        /// <summary>
        /// 理想函数:
        /// 评估函数,返回只一个份值，用来评估该步走法的好坏，越大代表约好
        /// </summary>
        public decimal V(object b)
        {
            /*
                1. 如果b是一最终的胜局，那么V(b)=100
                2. 如果b是一最终的负局，那么V(b)=-100
                3. 如果b是一最终的和局，那么V(b)=0
                4. 如果b不是最终棋局，那么V(b)=V(b′)，其中b′是从b开始双方都采取最优对弈后可达到的终局。
             */
            return 0;
        }

        /// <summary>
        /// 选择一个最好的走法
        /// </summary>
        public void ChooseMove()
        {

        }
    }
}
