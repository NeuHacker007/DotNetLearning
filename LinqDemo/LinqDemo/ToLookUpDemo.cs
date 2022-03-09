using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class ToLookUpDemo
    {

        public static void Demo1()
        {
            var methodFormat = GroupByStudent.GetStudents().ToLookup(s => s.Barnch);

            var queryFormat = (from std in GroupByStudent.GetStudents()
                              select std).ToLookup(s => s.Barnch);
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
            
        }
    }
}
