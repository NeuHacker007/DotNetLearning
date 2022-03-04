using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class SelectManyDemo
    {
        public static IEnumerable<char> Demo1()
        {
            List<string> nameList = new List<string>() { "Pranaya", "Kumar" };
            var methodFormat = nameList.SelectMany(x => x);
            var queryFormat = from name in nameList
                              from ch in name
                              select ch;
            foreach (char c in queryFormat)
            {
                Console.Write(c + " ");
            }
            return methodFormat;
        }

        public static void Demo2()
        {
            var methodFormat = Student.GetStudents().SelectMany(st => st.Programming).ToList();
            var queryFormat = from st in Student.GetStudents()
                              from program in st.Programming
                              select program;
            foreach (var program in methodFormat)
            {
                Console.WriteLine(program);
            }
        }

        public static void Demo3()
        {
            var methodFormat = Student.GetStudents()
                                      .SelectMany(st => st.Programming)
                                      .Distinct()
                                      .ToList();

            var queryFormat = (from st in Student.GetStudents()
                              from program in st.Programming
                              select program).Distinct().ToList();

            foreach (var program in methodFormat)
            {
                Console.WriteLine(program);
            }
        }

        public static void Demo4()
        {
            var methodFormat = Student.GetStudents()
                .SelectMany(st => st.Programming,(st, p) => new
                {
                    StudentName = st.Name,
                    Programming = p
                });

            var queryFormat = (from st in Student.GetStudents()
                              from program in st.Programming
                              select new
                              {
                                  StudentName = st.Name,
                                  Programming = program
                              }).ToList();

            foreach (var item in methodFormat)
            {
                Console.WriteLine(item.StudentName + " => " + item.Programming);
            }

        }

        public static void Demo5()
        {
            var methodFormat = Student.GetStudents()
                                      .SelectMany(st => new string[]{st.Name, st.Email})
                                      .Distinct()
                                      .OrderByDescending(x => x)
                                      .ToList();
            var queryFormat = (from st in Student.GetStudents()
                               from p in new string[] {st.Name, st.Email }
                               select p
                               )
                               .Distinct()
                               .ToList();
            foreach(var st in queryFormat)
            {
                Console.WriteLine(st);
            }
        }
    }
}
