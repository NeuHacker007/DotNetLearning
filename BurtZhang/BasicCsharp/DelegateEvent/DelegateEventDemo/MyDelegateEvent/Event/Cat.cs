using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    /// <summary>
    /// 直接调用别人实例的别的方法
    /// 不管是增减/顺序 都会让猫不稳定
    /// </summary>
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);
            {
                // 每增加或减少都需要改这个类
                new Dog().Wang();
                new Mouse().Run();
                new Baby().Cry();
                new Mother().Wispher();
                new Father().Roar();
                new Neighbor().Awake();
                new Stealer().Hide();
            }
      
        }

        // 猫叫一声， 触发一系列后续动作
        // 多了个 指定动作 正是这个不稳定 封装出去 甩锅

        public MiaoDelegate miaoDelegateHandler;
        public void MiaoNew()
        { 
            
            Console.WriteLine("{0} MiaoNew", this.GetType().Name);
            miaoDelegateHandler?.Invoke();
        }

        public event MiaoDelegate miaoDelegateEvent;

        //事件: 事件是带event关键字的委托实例, event可以限制变量被外部调用/直接赋值
        //委托和事件的区别和联系
        //委托是个类
        //事件本质上是委托类型的一个实例
        public void MiaoNewEvent()
        {
            Console.WriteLine("{0} MiaoNewEvent", this.GetType().Name);
            miaoDelegateEvent?.Invoke();
        }
    }

    public class ChildClass : Cat
    {
        public void Show()
        {
            this.miaoDelegateEvent += null;
            {
                //子类也不能调用， 只能在声明的类中调用。

                //this.miaoDelegateEvent.Invoke();
            }
            
        } 


    }

    public delegate void MiaoDelegate();
}
