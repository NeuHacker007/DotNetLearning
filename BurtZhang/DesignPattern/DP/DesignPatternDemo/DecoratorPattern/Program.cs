using System;

namespace DecoratorPattern
{
    /// <summary>
    /// 装饰器模式：
    /// 组合 + 继承
    /// 
    /// 装饰器模式可以在程序运行的过程中，为对象动态增加功能
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //{
                //    AbstractStudent student = new StudentVIPInherit()
                //    {
                //        Id = 1234,
                //        Name = "Ivan"
                //    };
                //    student.Study();
                //}
                //{
                //    AbstractStudent student = new StudentVIP()
                //    {
                //        Id = 1234,
                //        Name = "Ivan"
                //    };
                //    // 比起继承，组合跟家灵活 可以为多个类型服务，但是这个调用成本更高一点
                //    // 因为即关注了 AbstractStudent 类， 又关注了StudentCombination
                //    StudentCombination studentCombination = new StudentCombination(student);
                //    studentCombination.Study();
                //}

                {
                    AbstractStudent student = new StudentFree()
                    {
                        Id = 1234,
                        Name = "Ivan"
                    };

                    // BaseStudentDecorator baseStudentDecorator = new BaseStudentDecorator(student); // 1.

                    // AbstractStudent baseStudentDecorator = new BaseStudentDecorator(student); //2. 
                    student = new BaseStudentDecorator(student);

                    student = new StudentHomeworkDecorator(student);

                    student = new StudentCommentDecorator(student);
                    // 不修改业务类， 可以随意添加功能 装饰器
                    // 还可以随意调整顺序
                    student.Study();
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
