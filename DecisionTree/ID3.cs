using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using static Common.PlyballEnums;

namespace DecisionTree
{
    /// <summary>
    /// 贪婪搜索决策树
    /// </summary>
    public class ID3
    {
        public void Test()
        {
            /* 
            Sunny 	Hot 	High 	Weak 	No 
            Sunny 	Hot 	High 	Strong 	No 
            Overcast 	Hot 	High 	Weak 	Yes 
            Rain 	Mild 	High 	Weak 	Yes 
            Rain 	Cool 	Normal 	Weak 	Yes 
            Rain 	Cool 	Normal 	Strong 	No 
            Overcast 	Cool 	Normal 	Strong 	Yes 
            Sunny 	Mild 	High 	Weak 	No 
            Sunny 	Cool 	Normal 	Weak 	Yes 
            Rain 	Mild 	Normal 	Weak 	Yes 
            Sunny 	Mild 	Normal 	Strong 	Yes 
            Overcast 	Mild 	High 	Strong 	Yes 
            Overcast 	Hot 	Normal 	Weak 	Yes 
            Rain 	Mild 	High 	Strong 	No
             */
            var sourcesStr = @"Sunny 	Hot 	High 	Weak 	No 
            Sunny 	Hot 	High 	Strong 	No 
            Overcast 	Hot 	High 	Weak 	Yes 
            Rain 	Mild 	High 	Weak 	Yes 
            Rain 	Cool 	Normal 	Weak 	Yes 
            Rain 	Cool 	Normal 	Strong 	No 
            Overcast 	Cool 	Normal 	Strong 	Yes 
            Sunny 	Mild 	High 	Weak 	No 
            Sunny 	Cool 	Normal 	Weak 	Yes 
            Rain 	Mild 	Normal 	Weak 	Yes 
            Sunny 	Mild 	Normal 	Strong 	Yes 
            Overcast 	Mild 	High 	Strong 	Yes 
            Overcast 	Hot 	Normal 	Weak 	Yes 
            Rain 	Mild 	High 	Strong 	No";
            var sourceList = sourcesStr.Split("\r\n");
            var examples = sourceList.Select(i =>
            {
                i = i.Replace('\t', ' ');
                var dataStr = i.Split(' ').ToList();
                dataStr.RemoveAll(d => d == string.Empty);
                return new Playball(EnumUtil.GetByName<Outlook>(dataStr[0]),
                    EnumUtil.GetByName<Temperature>(dataStr[1]),
                    EnumUtil.GetByName<Humidity>(dataStr[2]),
                    EnumUtil.GetByName<Wind>(dataStr[3]),
                    dataStr[4] == "Yes");
            }).ToList();

            Console.WriteLine("Entropy:" + Entropy(examples));

            Console.WriteLine("InformationGain:[Outlook]" + InformationGain(examples, typeof(Outlook)));
            Console.WriteLine("InformationGain:[Humidity]" + InformationGain(examples, typeof(Humidity)));
            Console.WriteLine("InformationGain:[Wind]" + InformationGain(examples, typeof(Wind)));
            Console.WriteLine("InformationGain:[Temperature]" + InformationGain(examples, typeof(Temperature)));
        }

        /// <summary>
        /// 返回能正确分类给定Examples的决策树。
        /// </summary>
        /// <param name="Examples">Examples即训练样例集。T</param>
        /// <param name="Target_attribute">arget_attribute是这棵树要预测的目标属性。</param>
        /// <param name="Attributes">Attributes是除目标属性外供学习到的决策树测试的属性列表。</param>
        public void Train(List<Playball> Examples,object Target_attribute,object Attributes)
        {
            /*
             创建树的Root结点
             如果Examples都为正，那么返回label =+ 的单结点树Root
             如果Examples都为反，那么返回label =- 的单结点树Root
             如果Attributes为空，那么返回单结点树Root，label=Examples中最普遍的Target_attribute值
             否则
                 A←Attributes中分类Examples能力最好*的属性
                 Root的决策属性←A
                 对于A的每个可能值v
                     在Root下加一个新的分支对应测试A= vi
                     令iivExamples为Examples中满足A属性值为vi
                     如果的子集ivExamples为空
                         在这个新分支下加一个叶子结点，结点的label=Examples中最普遍的Target_attribute值
                         否则在这个新分支下加一个子树ID3（ivExamples, Target_attribute, Attributes-{A}）
                     结束
                     返回Root
             */
        }

        /// <summary>
        /// Entropy熵,表示样例的纯度
        /// </summary>
        /// <returns></returns>
        public double Entropy(List<Playball> S)
        {
            /*
                Σpi*log2Pi
                其中pi是S中属于类别i的比例。请注意对数的底数仍然为2
             */
            var result = 0d;
            foreach (var item in S.GroupBy(i=>i.Play))
            {
                var pi = ((double)item.Count()) / S.Count;
                var v = -pi * Math.Log(pi, 2);
                result += v;
            }
            return result;
        }

        /// <summary>
        /// 信息增益计算
        /// </summary>
        /// <param name="S">样例集合</param>
        /// <param name="A">属性A</param>
        /// <returns>属性A在样例中的信息增益</returns>
        public double InformationGain(List<Playball> S,Type A)
        {
            /*                                    
             Gain(S,A) = Entropy(S) - Σ           |Sv|/|S| *  Entropy(Sv)
                                      v∈Values(A)

            其中 Values(A)是属性A所有可能值的集合，
            Sv是S中属性A的值为v的子集（也就是，vS={s∈S|A(s)=v}）。
            请注意，等式（3.4）的第一项就是原来集合S的熵，第二项是用A分类S后熵的期望值。
            |Sv|/|S|为属性值为v在原集合中的比例
             */

            var result = 0d;
            var typeP = typeof(Playball);
            var valuesA = Enum.GetValues(A);
            foreach (var v in valuesA)
            {
                var Sv = S.Where(i =>
                {
                    var prop = typeP.GetProperties().First(p => p.PropertyType == A);
                    return v.Equals(prop.GetValue(i));
                }).ToList();
                var p1 = Math.Abs(Sv.Count / (double)S.Count);
                var EntropySv = Entropy(Sv);
                result += p1 * EntropySv;
            }

            result = Entropy(S) - result;

            return result;
        }
    }
}
