using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public class LinqShow
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


        public void Show()
        {
            var students = this.getStudents();

            {
                var list = new List<Student>();
                //没有扩展方法和delegate的方式过滤数据
                foreach (var student in students)
                {
                    if (student.Age > 10)
                    {
                        list.Add(student);
                    }
                }
            }

            {
                students.IvanWhere(i => i.Age > 30);
            }

            {
                new List<int>() {1, 3, 4, 5, 612, 534, 2345, 1234, 6, 453, 45423, 4, 234, 5}.GenericWhere(g => g > 50);

            }
            {
                students.GIenumerableWhere(i => i.Age > 30);

            }
        }
    }
}
