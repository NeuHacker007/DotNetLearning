using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Student student = new Student()
                        {
                            Id = 1,
                            Name = "Ivan"
                        };
                        student.Study();
                    }


                }

                {
                    // 为了减少对象的创建， 重用对象，提升性能，所以用了单例
                    for (int i = 0; i < 5; i++)
                    {
                        StudentSingleton student = StudentSingleton.CreateInstance(); // new StudentSingleton()

                        student.Id = 1;
                        student.Name = "Ivan";

                        student.Study();

                    }
                }

                {
                    // 单例会导致数据被覆盖，因为student 和studentNew都指向同一个对象

                    StudentSingleton student = StudentSingleton.CreateInstance(); // new StudentSingleton()

                    student.Id = 1;
                    student.Name = "Ivan";

                    student.Study();

                    StudentSingleton studentNew = StudentSingleton.CreateInstance(); // new StudentSingleton()

                    studentNew.Id = 12;
                    studentNew.Name = "Ivan123";

                    studentNew.Study();
                }

                {
                    // 1. 避免重复创建对象，重复调用构造函数问题 -- 内存拷贝
                    // 2. 避免同一个对象覆盖的问题 -- 不同对象


                    StudentPrototype student = StudentPrototype.CreateInstance(); // new StudentSingleton()

                    student.Id = 1;
                    student.Name = "Ivan";

                    student.Study();

                    StudentPrototype studentNew = StudentPrototype.CreateInstance(); // new StudentSingleton()

                    studentNew.Id = 12;
                    studentNew.Name = "Ivan123";

                    studentNew.Study();

                }

                {
                    StudentPrototype student = StudentPrototype.CreateInstance(); // new StudentSingleton()

                    student.Id = 1;
                    student.Name = "Ivan";

                    student.Study();

                    StudentPrototype studentNew = StudentPrototype.CreateInstance(); // new StudentSingleton()

                    studentNew.Id = 12;
                    studentNew.Name = "Ivan123";

                    studentNew.Study();

                    StudentPrototype studentDouble = StudentPrototype.CreateInstance(); // new StudentSingleton()

                    studentDouble.Id = 123;
                    studentDouble.Name = "Ivan12342";
                    // 会覆盖StudentPrototype中初始化的班级信息，因为浅拷贝只拷贝了引用地址
                    studentDouble.Class.ClassId = 2;
                    studentDouble.Class.Name = "Advanced";

                    studentDouble.Study();
                    // 内存拷贝时 引用属性是拷贝的引用地址, 多个student的class指向的都是同一块内存
                    // 所以一个变化，全部都会变化
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
