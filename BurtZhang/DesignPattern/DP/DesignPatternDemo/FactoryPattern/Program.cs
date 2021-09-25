using System;
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

                    IRace human = ObjectFactory.CreateRace(RaceType.Undead); // 3 没有细节 细节被转移
                    player.PlayWar3(human);
                }
                {
                    Console.WriteLine("***********************Simple Factory by Configuration*****************");
                    // 利用配置文件读取种族

                    IRace human = ObjectFactory.CreateRace(config); // 3 没有细节 细节被转移
                    player.PlayWar3(human);
                }

                {
                    Console.WriteLine("***********************Simple Factory Reflection*****************");
                    IRace human = ObjectFactory.CreateRaceConfigReflection(config); 
                    player.PlayWar3(human);

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
