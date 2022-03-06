using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class GroupByDemo
    {
        public static void Demo1()
        {
            var methodFormat = GroupByStudent.GetStudents()
                .GroupBy(std => std.Barnch);

            var queryFormat = from std in GroupByStudent.GetStudents()
                              group std by std.Barnch;

            foreach (var group in methodFormat)
            {
                Console.WriteLine(group.Key + " : " + group.Count());
                //Iterate through each student of a group
                foreach (var student in group)
                {
                    Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
                }
            }
        }

        public static void Demo2()
        {
            var methodFormat = GroupByStudent.GetStudents()
                .GroupBy(std => std.Gender)
                .OrderByDescending(g => g.Key)
                .Select(std => new
                {
                    Key = std.Key,
                    Students = std.OrderBy(s => s.Name)
                });
            var queryFormat = from std in GroupByStudent.GetStudents()
                              group std by std.Gender into genderGroup
                              orderby genderGroup.Key descending
                              select new
                              {
                                  Key = genderGroup.Key,
                                  Students = genderGroup.OrderBy(s => s.Name)
                              };
            foreach (var group in methodFormat)
            {
                Console.WriteLine(group.Key +" : " + group.Students.Count());
                //Iterate through each student of a group
                foreach(var student in group.Students)
                {
                    Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Branch :" + student.Barnch);
                }
            }

           
        }
    }
}
