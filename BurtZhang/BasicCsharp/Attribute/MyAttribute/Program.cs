using System;
using Microsoft.Extensions.Configuration;

namespace MyAttribute
{
    /// <summary>
    /// 特性：中括号声明
    /// 错觉： 每一个特性都可以带来对应功能
    /// 实际上特性添加后，编译会在元素内部产生IL， 无法直接使用
    /// 而且在metadata里面有记录
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
                    stu.Study();
                    stu.Answer("Ivan");
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
