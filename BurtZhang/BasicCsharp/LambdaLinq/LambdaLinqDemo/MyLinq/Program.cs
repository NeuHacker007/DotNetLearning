using System;

namespace MyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("**********************Lambda + Linq*************************");
                {
                    Console.WriteLine("**************************Lambda*********************");
                    LambdaShow lambdaShow = new LambdaShow();
                    lambdaShow.Show();
                }

                {
                    //匿名类

                    object model = new
                    {
                        id = 2,
                        Name = "",
                        Age = 25,
                        ClassId = 2
                    };

                    // Console.WriteLine(model.id); //object 编译器不允许

                    dynamic dModel = new // 4.0
                    {
                        id = 2,
                        Name = "",
                        Age = 25,
                        ClassId = 2
                    };

                    Console.WriteLine(dModel.id);


                    // var 是一个语法糖, 由编译器自动推算
                    // var 必须在声明时就确定类型
                    // var 确定类型后不能改变的
                    // 
                    var vModel =new //3.0 编译后是有一个真实的类
                    {
                        id = 2,
                        Name = "",
                        Age = 25,
                        ClassId = 2
                    };
                    //vModel.id = 3; //匿名类里面的属性只能Get不能被赋值， 只能在构造函数指定
                    Console.WriteLine(vModel.id);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
        }
    }
}
