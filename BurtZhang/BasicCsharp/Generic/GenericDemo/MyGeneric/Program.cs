using System;


namespace MyGeneric
{
    /// <summary>
    /// 1. 引入泛： 延迟声明
    /// 2. 如何声明和使用泛型
    /// 3. 泛型的好处和原理
    /// 4. 泛型类, 泛型方法, 泛型接口，泛型委托
    /// 5. 泛型约束
    /// 6. 协变 逆变
    /// 7. 泛型缓存
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                {
                    Console.WriteLine("*****************Old Way***********");
                    int i = 123;
                    string s = "456";
                    DateTime dt = DateTime.Now;
                    object o = "sorry";
                    {
                        Console.WriteLine("************************");
                        CommonMethod.ShowInt(i);
                        CommonMethod.ShowString(s);
                        CommonMethod.ShowDateTime(dt);
                        CommonMethod.ShowObject(o);
                        CommonMethod.ShowObject(i);
                        CommonMethod.ShowObject(s);
                    }
               

                    {
                        Console.WriteLine("*************Generic**************");
                       GenericMethod.Show(i); // <> 能省略，自动推算
                       GenericMethod.Show<string>(s); //需要指定参数类型
                    }

                    {
                        Console.WriteLine("*************Monitor**************");
                        // 性能 common ~ Generic > object
                        Monitor.Show();
                    }
                }

             

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            Console.Read();
        }
    }
}
