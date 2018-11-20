using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTree
{
    /// <summary>
    /// 决策节点
    /// </summary>
    /// <typeparam name="T">属性节点类型</typeparam>
    /// <typeparam name="R">决策返回结果类型</typeparam>
    public class TreeDecisionNode<T,R>
    {
        /// <summary>
        /// 决策属性类型
        /// </summary>
        public Type Attribute { get; set; }

        /// <summary>
        /// 决策属性可取值节点
        /// </summary>
        public TreeAttributeNode<T,R> Childrens { get; set; }
    }


    /// <summary>
    /// 属性节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeAttributeNode<T,R>
    {
        /// <summary>
        /// 决策结果
        /// </summary>
        public R Result { get; set; }

        /// <summary>
        /// 决策节点
        /// </summary>
        public TreeDecisionNode<T,R> DecisionNode { get; set; }
    }
}
