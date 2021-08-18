using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    public class ActionFunc
    {
        public void Show()
        {
            // Action 0到16个参数 没有返回值 泛型委托
            Action action1 = () => { };

            Action<int> action2 = i => Console.WriteLine(i);

            Action<int, string, DateTime, ActionFunc> action16 = null;

            // Action 0到16个参数 带返回值 泛型委托
            Func<int> func1 = () => 1;

            Func<int, string> func2 = (i) => i.ToString();

            NoReturnNoPara noReturnNoPara = () => { };


            this.DoNothing(action1);
            //this.DoNothing(noReturnNoPara); //error
            // 因为 NoReturnNoPara 和Action 不是同一个类型
            // Student Teacher 大家属性都差不多但是实例之间不能替换，因为没有什么关系
            // 很多委托长的一样， 参数列表和返回值都相同，但是不能通用
            // 在不同框架组件定义各种各样的相同委托就是浪费. 比如 Thread 的 ThreadStart 委托和Action 委托是一样的
            // 所以为了统一，就全部使用标准的Action/Func

        }

        private void DoNothing(Action act){

        }
    }

    public delegate void NoReturnNoPara();

   
}
