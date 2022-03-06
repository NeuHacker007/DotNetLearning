using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class GroupByMultipleKey
    {
        public static void Demo1()
        {
            var methodFormat = GroupByStudent.GetStudents()
                .GroupBy(std => new { std.Barnch, std.Gender })
                .OrderByDescending(g => g.Key.Barnch)
                .ThenBy(g => g.Key.Gender)
                .Select(stdGroup => new
                {
                    Branch = stdGroup.Key.Barnch,
                    Gender = stdGroup.Key.Gender,
                    Students = stdGroup.OrderBy(x => x.Name)
                });
            var queryFormat = from std in GroupByStudent.GetStudents()
                              group std by new { std.Barnch, std.Gender } into stdGroup
                              select new
                              {
                                  Branch = stdGroup.Key.Barnch,
                                  Gender = stdGroup.Key.Gender,
                                  Students = stdGroup.OrderBy(x => x.Name)
                              };

            foreach (var group in methodFormat)
            {
                Console.WriteLine($"Barnch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
                //It will iterate through each item of a group
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
                }
                Console.WriteLine();
            }
        }
    }
}
