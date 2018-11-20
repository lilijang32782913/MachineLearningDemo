using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptLearning
{
    public static class Run
    {
        /*
         实例集X：可能的日子，每个日子由下面的属性描述：
         Sky（可取值为Sunny，Cloudy和Rainy）
         AirTemp（可取值为Warm和Cold）
         Humidity（可取值为Normal和High）
         Wind（可取值为Strong和Weak）
         Water（可取值为Warm和Cool）
         Forecast（可取值为Same和Change）
         */

        /*
         假设集H：每个假设描述为6个属性Sky，AirTemp，Humidity，Wind，Water和Forecast的值约束的合取。
         约束可以为“?”（表示接受任意值），“∅”（表示拒绝所有值），或一特定值。
         */


        /*
         目标概念c: EnjoySport: X→{0, 1}
         */

        /*
         训练样例集D：目标函数的正例和反例（见表2-1）
         */

        /*
         求解：
       H中的一假设h，使对于X中任意x，h(x)=c(x)。
         */

        /*
         从特殊到一般顺序
         (总是先将结果设置为最特殊的假设，在拟合训练数据后调整得更一般)
         */


        /*
         候选消除
         (列出所有假设，逐渐消除反例)
         */

        /*
         归纳偏置
         (使用最一般和最特殊的假设作为定义，拟合正例时将特殊逐渐泛化为一般，拟合反例时将一般逐渐泛化为特殊)
         */


    }
}
