using System;
using Microsoft.Extensions.Configuration;
using MyAttribute.Extension;

namespace MyAttribute
{
    /// <summary>
    /// 特性：中括号声明
    /// 错觉： 每一个特性都可以带来对应功能
    /// 实际上特性添加后，编译会在元素内部产生IL， 无法直接使用
    /// 而且在metadata里面有记录
    ///
    /// 特性本身是没有用的，在程序运行过程中，我们能找到特性，也能应用一下
    /// 任何一个可以生效的特性，都是因为有地方主动使用了的
    ///
    /// 没有破坏类型封装的前提下， 可以加点额外的信息及行为。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", true, true)
                 .Build();
            try
            {
                Console.WriteLine("****************Attribute + AOP");
                {
                    Student stu = new Student();
                    stu.Id = 123;
                    stu.Name = "Ivan";
                    //stu.Study();
                    //stu.Answer("Ivan");
                    Manager.Show(stu);
                }

                {
                    UserState userState = UserState.Normal;

                    // if (userState == UserState.Normal) Console.WriteLine("正常");
                    Console.WriteLine(userState.GetRemark());
                }
                {
                    UserState userState = UserState.Frozen;

                    // if (userState == UserState.Normal) Console.WriteLine("正常");
                    Console.WriteLine(userState.GetRemark());
                }

                {
                    UserState userState = UserState.Deleted;

                    // if (userState == UserState.Normal) Console.WriteLine("正常");
                    Console.WriteLine(userState.GetRemark());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
        }
    }
}
