using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern.Observer;

namespace ObserverPattern.Subject
{
    /// <summary>
    /// 猫叫一声之后触发 一堆的后续事件
    ///
    /// 1  需求是触发一系列的后续动作
    /// 2. 实现上太多耦合，违背单一职责
    ///
    /// 需求是     猫叫一声之后      需要触发一系列的动作
    /// 实现是     猫叫一声后       触发了一系列的动作 还指定了动作
    /// 正是因为指定了动作，才产生了耦合
    /// 怎么解耦？ 丢锅， 我不负责指定动作，别人来做，让我稳定
    /// </summary>
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine($"{typeof(Cat)} Miao ....");

            {
                // 该实现方式有什么问题
                // 1. 依赖太多
                // 2. 耦合
                // 3. 违背了单一职责
                // 4. 去掉/增加/调整顺序 都会导致对猫的修改

                //  new Baby().Cry();
                //  new Dog().Wang();
                //  new Father().Roar();
                //  new Mother().Wispher();
                //  new Mouse().Run();
                //  new Neighbor().Awake();
                //  new Stealer().Hide();
            }
        }

        private List<IObserver> _observerList = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observerList.Add(observer);
        }
        public void MiaoObserver()
        {
            Console.WriteLine($"{typeof(Cat)} Miao ....");
            // 还得触发一系列的动作， 多少个不确定 只管触发
            if (_observerList!= null && _observerList.Count > 0)
            {
                //invoke 行为

                foreach (var observer in _observerList)
                {
                    observer.Action();
                }
            }
        }


        public event Action MiaoHandler;
        /// <summary>
        /// c# 实现
        /// </summary>
        public void MiaoEvent()
        {
            Console.WriteLine($"{typeof(Cat)} Miao ....");

            if (MiaoHandler != null)
            {
                foreach (Action item in MiaoHandler.GetInvocationList())
                {
                    item.Invoke();
                }
            }
        }
    }
}
