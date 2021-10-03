using System;
using ObserverPattern.Observer;
using ObserverPattern.Subject;

namespace ObserverPattern
{
    /// <summary>
    /// 架构师是干什么的？ 搭建框架
    ///
    /// 框架： 是把业务开发流程中， 将通用的部分实现，可变的部分需要留下扩展点
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    // 保证了猫的稳定性
                    Cat cat = new Cat();

                    cat.AddObserver(new Stealer());
                    cat.AddObserver(new Baby());
                    cat.AddObserver(new Father());
                    cat.AddObserver(new Mother());
                    cat.AddObserver(new Dog());
                    cat.AddObserver(new Neighbor());

                    cat.MiaoObserver();
                }

                {
                    Cat cat = new Cat();

                    cat.MiaoHandler +=new Stealer().Hide;
                    cat.MiaoHandler +=new Baby().Cry;
                    cat.MiaoHandler +=new Father().Roar;
                    cat.MiaoHandler +=new Mother().Wispher;
                    cat.MiaoHandler +=new Dog().Wang;
                    cat.MiaoHandler +=new Neighbor().Awake;

                    cat.MiaoEvent();
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
