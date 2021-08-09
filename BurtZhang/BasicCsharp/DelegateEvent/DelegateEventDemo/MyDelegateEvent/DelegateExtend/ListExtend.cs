using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.DelegateExtend
{
    public class ListExtend
    {
        private List<Student> getStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name = "Ivan",
                    ClassId = 2,
                    Age = 35
                },
                new Student()
                {
                    Id = 1,
                    Name = "Alpha",
                    ClassId = 2,
                    Age = 23
                },
                new Student()
                {
                    Id = 1,
                    Name = "Hao",
                    ClassId = 2,
                    Age = 25
                },
                new Student()
                {
                    Id = 1,
                    Name = "Eric",
                    ClassId = 2,
                    Age = 27
                },
                new Student()
                {
                    Id = 1,
                    Name = "Eva",
                    ClassId = 2,
                    Age = 4
                }
            };

            return students;
        }

        public delegate bool ThanDelegate(Student student);

        private bool Than(Student st)
        {
            return st.Age > 25;
        }
        private bool LengthThan(Student st)
        {
            return st.Name.Length > 2;
        }


        private bool AllThan(Student st)
        {
            return st.Name.Length > 2 && st.Age > 25 && st.ClassId == 2;
        }

        public void Show()
        {
            List<Student> students = getStudents();
            {
                // 重复的实现, 
                {
                    //找出年龄大于25 的

                    List<Student> resuList = new List<Student>();

                    foreach (var student in students)
                    {
                        if (student.Age > 25)
                        {
                            resuList.Add(student);
                        }
                    }

                    Console.WriteLine($"total {resuList.Count}");
                }

                {

                    List<Student> resuList = new List<Student>();

                    foreach (var student in students)
                    {
                        if (student.Name.Length > 2)
                        {
                            resuList.Add(student);
                        }
                    }

                    Console.WriteLine($"total {resuList.Count}");
                }
                {
                    List<Student> resuList = new List<Student>();

                    foreach (var student in students)
                    {
                        if (student.Name.Length > 2 && student.Age > 25 && student.ClassId == 2)
                        {
                            resuList.Add(student);
                        }
                    }

                    Console.WriteLine($"total {resuList.Count}");

                }
            }
            {
                //委托
                ThanDelegate method = new ThanDelegate(this.Than);

                this.GetListDelegate(students, method);

                ThanDelegate method2 = new ThanDelegate(this.LengthThan);

                this.GetListDelegate(students, method2); 
                
                ThanDelegate method3 = new ThanDelegate(this.AllThan);

                this.GetListDelegate(students, method3);

            }

        }
        /// <summary>
        /// 1 type： 不同值， 不同判断
        /// 传个参数 -- 判断参数 -- 执行对应的行为
        /// 那我能不能直接传个行为呢？逻辑就是方法，传方法
        /// </summary>
        /// <param name="students"></param>
        /// <param name="type"></param>
        /// <returns></returns>

        private List<Student> GetList(List<Student> students, int type)
        {
            List<Student> resultList = new List<Student>();

            foreach (var student in students)
            {
                if (type == 1)
                {

                }
                else if (type == 2)
                {
                    if (student.Name.Length > 2 && student.Age > 25 && student.ClassId == 2)
                    {
                        resultList.Add(student);
                    }
                }

            }

            return resultList;
        }

        /// <summary>
        /// 把判断逻辑传递进来 + 实现共用逻辑
        ///
        /// 委托解耦, 减少重复代码
        /// </summary>
        /// <param name="students"></param>
        /// <param name="dDelegate"></param>
        /// <returns></returns>
        private List<Student> GetListDelegate(List<Student> students, ThanDelegate dDelegate)
        {
            List<Student> resultList = new List<Student>();

            foreach (var student in students)
            {
                if (dDelegate.Invoke(student))
                {
                    resultList.Add(student);
                }
            }

            return resultList;
        }


    }
}
