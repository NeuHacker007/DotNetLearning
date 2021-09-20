using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
    /// <summary>
    /// 里氏替换原则： 任何使用基类的地方，都可以透明的使用其子类； 继承 + 不改变行为
    ///
    /// 继承，多态
    ///
    /// 继承： 通过继承，子类拥有父类的一切属性和行为， 任何父类出现的地方，都可以用子类来替代
    /// 1. 子类必须完全实现父类有的方法
    ///    如果子类没有父类的某项东西，
    ///    就要断掉继承
    /// 2. 子类可以有父类没有的东西, 所以子类出现的地方，不一定能用父类来代替
    ///     a. 父类已经实现的东西，子类不要去new
    ///     b. 父类已经实现的东西，想改的话，就必须用virtual 加 override
    ///
    /// 声明变量,参数，属性，字段，最好都是基于基类的。
    /// </summary>
    public class LSPShow
    {
        public static void Show()
        {
            {
                Poly.Test();
            }

          
        }
    }
}
