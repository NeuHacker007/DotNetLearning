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
    }

    public delegate void MiaoDelegate();
}
