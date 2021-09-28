using System;
using FactoryPattern.FactoryMethod;
using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using Microsoft.Extensions.Configuration;

namespace FactoryPattern
{
    /// <summary>
    ///
    /// 三大工厂
    /// 简单工厂： (不属于GOF23种设计模式)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                var builder = new ConfigurationBuilder();
                var config = builder.AddJsonFile("appsettings.json", false, true).Build();


                Player player = new Player(); //1. 到处都是细节
                {
                    Console.WriteLine("***********************Normal*****************");
                    Human human = new Human();
                    player.PlayWar3(human);
                }

                {
                    Console.WriteLine("***********************Using Interface*****************");
                    IRace human = new Human(); // 2. 左边是抽象， 右边是细节
                    player.PlayWar3(human);
                }

                { 
                    Console.WriteLine("***********************Simple Factory*****************");
                    // 我们希望去掉右边的细节，咱们就封装一下 转移一下

                    IRace human = SimpleFactory.CreateRace(RaceType.Undead); // 3 没有细节 细节被转移
                    player.PlayWar3(human);
                }
                {
                    Console.WriteLine("***********************Simple Factory by Configuration*****************");
                    // 利用配置文件读取种族

                    IRace human = SimpleFactory.CreateRace(config); // 3 没有细节 细节被转移
                    player.PlayWar3(human);
                }

                {
                    Console.WriteLine("***********************Simple Factory Reflection*****************");
                    IRace human = SimpleFactory.CreateRaceConfigReflection(config); 
                    player.PlayWar3(human);

                }

                {
                    // 工厂方法就是把每个new 对象的操作单独作为一个工厂
                    IFactory factory = new HumanFactory();
                    IRace race = factory.CreateRace();
                    // 何苦 搞了这么多工厂 还不是创建对象
                    // 以前依赖的是Human 现在换成了 HumanFactory

                    // 1. 工厂可以增加一些创建逻辑 屏蔽对象实例化的复杂度 比如增加多种参数
                    // 2. 对象创建的过程中 可能扩展(IOC)
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
