using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTree
{
    public class C45 : ID3
    {
        /*
         1.从训练集合推导出决策树，增长决策树直到尽可能好地拟合训练数据，允许过度拟合发生。
         2.将决策树转化为等价的规则集合，方法是为从根结点到叶子结点的每一条路径创建一条规则。
         3.通过删除任何能导致估计精度提高的前件（preconditions）来修剪（泛化）每一条规则。
         4.按照修剪过的规则的估计精度对它们进行排序；并按这样的顺序应用这些规则来分类后来的实例。
         */
    }
}
