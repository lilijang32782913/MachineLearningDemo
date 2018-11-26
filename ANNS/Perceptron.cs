﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ANNS
{
    /*
     感知器以一个实数值向量作为输入，计算这些输入的线性组合，然后如果结果大于某个阈值就输出1，否则输出-1
    */
    /// <summary>
    /// 感知器
    /// </summary>
    public class Perceptron
    {
        /// <summary>
        /// 训练结果的权值[w1,w2...wi]
        /// </summary>
        public double[] W { get; set; }

        public void Test()
        {
            /*
             物理占120分、化学占100分、生物占80分。语数外各150分
             x0 = 110,x1 = 100,x2 = 90,x3 = 150,x4 = 150;x5=150
             随机生成1000条数据，其中40条误差2%，10条误差5%；看拟合结果
             */

            //测试数据
            var demos = new List<ExampleInfo>();
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                var ei = new ExampleInfo();
                ei.X = new double[6];
                ei.X[0] = random.Next(0, 100);
                ei.X[1] = random.Next(0, 100);
                ei.X[2] = random.Next(0, 100);
                ei.X[3] = random.Next(0, 100);
                ei.X[4] = random.Next(0, 100);
                ei.X[5] = random.Next(0, 100);
                ei.T = (ei.X[0] * 120 + ei.X[1] * 100 + ei.X[2] * 80 + ei.X[3] * 150 + ei.X[4] * 150 + ei.X[5] * 150)/100;
                //if (random.Next(1, 1000) <= 40)
                //{
                //    ei.T = random.Next((int)Math.Ceiling(ei.T), (int)Math.Ceiling(ei.T * 1.2));
                //}
                //else if (random.Next(1, 1000) <= 10)
                //{
                //    ei.T = random.Next((int)Math.Ceiling(ei.T), (int)Math.Ceiling(ei.T * 1.5));
                //}

                demos.Add(ei);
            }

            //训练
            this.GradientDescent(demos);
        }

        /// <summary>
        /// 感知结果值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GetValue(double[] x)
        {
            var v = 0d;
            for (int i = 0; i < W.Length; i++)
            {
                v += W[i] * x[i];
            }
            return v;
        }

        /// <summary>
        /// 获取感知器对实例的误差
        /// </summary>
        /// <param name="example"></param>
        /// <returns></returns>
        public double GetEw(List<ExampleInfo> training_examples)
        {

            /*
             E(W) = 1/2 * Σ(td-od)^2
                         d∈D

             D=training_examples训练实例集
             td是训练实例的输出
             od是当前感知器对实例的输出
             */
            var EW = 0d;
            for (int i = 0; i < training_examples.Count; i++)
            {
                var item = training_examples[i];
                var od = this.GetValue(item.X);
                var ei = 0.5 * Math.Pow((item.T - od), 2);
                EW += ei;
            }

            return EW;
        }

        /// <summary>
        /// 梯度下降
        /// </summary>
        /// <param name="training_examples">训练示例</param>
        /// <param name="n">训练速度(过大会导致训练结果不对)</param>
        public void GradientDescent(List<ExampleInfo> training_examples, double n = 0.0001)
        {
            /*
             初始化每个wi为某个小的随机值
             遇到终止条件之前，做以下操作： 
             初始化每个Δwi为0
             对于训练样例training_examples中的每个<x,t>，做：
             把实例x输入到此单元，计算输出o
             对于线性单元的每个权wi ，做
                        Δwi ←Δwi +η(t-o)xi
               对于线性单元的每个权wi ，做
                        wi← wi +Δwi
             */

            if (training_examples == null || training_examples.Count==0)
            {
                return;
            }

            this.W = new double[training_examples.First().X.Length];
            var random = new Random();
            for (int i = 0; i < this.W.Length; i++)
            {
                this.W[i] = random.Next(1, 10);
            }

            //累计误差值小于某个阈值跳出
            var deltaW = 1d;
            while (deltaW >= 0.00000001)
            {
                for (int i = 0; i < training_examples.Count; i++)
                {
                    var item = training_examples[i];
                    for (int j = 0; j < item.X.Length; j++)
                    {
                        var o = GetValue(item.X);
                        var xi = item.X[j];
                        this.W[j] += n * (item.T - o) * xi;
                    }
                    
                }
                deltaW = GetEw(training_examples);
                //打印计算步骤
                Console.WriteLine($"{this.W[0]},{this.W[1]},{this.W[2]},{this.W[3]},{this.W[4]},{this.W[5]}");
                Console.WriteLine(deltaW);
            }
        }
    }
}
