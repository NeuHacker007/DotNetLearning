using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class CrossJoinDemo
    {
        public static void Demo1()
        {
            var queryFormat = from std in CrossJoinDataSource.Student.GetAllStudnets()
                              from sub in CrossJoinDataSource.Subject.GetAllSubjects()
                              select new
                              {
                                  std,
                                  sub
                              };
            foreach (var item in queryFormat)
            {
                Console.WriteLine($"Name : {item.std.Name}, Subject: {item.sub.SubjectName}");
            }
        }

        public static void Demo2()
        {
            var methodFormat = CrossJoinDataSource.Student.GetAllStudnets()
                .SelectMany(
                sub => CrossJoinDataSource.Subject.GetAllSubjects(),
                (std, sub) => new
                {
                    Name = std.Name,
                    SubjectName = sub.SubjectName
                });


            foreach (var item in methodFormat)
            {
                Console.WriteLine($"Name : {item.Name}, Subject: {item.SubjectName}");
            }
        }

        public static void Demo3()
        {
            var methodFormat = CrossJoinDataSource.Student.GetAllStudnets()
                .Join(CrossJoinDataSource.Subject.GetAllSubjects(),
                std => true,
                sub => true,
                (std, sub) => new
                {
                    Name = std.Name,
                    SubjectName = sub.SubjectName
                });
            foreach (var item in methodFormat)
            {
                Console.WriteLine($"Name : {item.Name}, Subject: {item.SubjectName}");
            }

        }
    }
}
