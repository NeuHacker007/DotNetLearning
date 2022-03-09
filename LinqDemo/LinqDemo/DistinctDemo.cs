using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LinqDemo
{
    public class DistinctDemo
    {
        public static void Demo1()
        {
            DupStudentComparer dupStudentComparer = new DupStudentComparer();

            var methodFormat = DupStudent.GetStudents().Distinct(dupStudentComparer).ToList();
            foreach (var item in methodFormat)
            {
                Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
            }
        }

        public static void Demo2()
        {
            var methodFormat = DupStudent.GetStudents().Distinct().ToList();
            foreach (var item in methodFormat)
            {
                Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
            }
        }

        public static void Demo3()
        {
            var methodFormat = DupStudent.GetStudents().Select(std => new { std.ID, std.Name }).Distinct().ToList();
            var methodFormat2 = DupStudent.GetStudents().SelectMany(std => new string[] { std.ID.ToString(), std.Name }).Distinct().ToList();
            var methodFormat3 = DupStudent.GetStudents().SelectMany(std => new List<Tuple<int, string>>() { Tuple.Create(std.ID, std.Name) }).Distinct().ToList();

            foreach (var item in methodFormat)
            {
                Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
            }

            foreach (var item in methodFormat3)
            {
                Console.WriteLine(item.Item1 + "\t" + item.Item2);
            }

        }
    }

    public class DupStudentComparer : IEqualityComparer<DupStudent>
    {
        public bool Equals(DupStudent x, DupStudent y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (object.ReferenceEquals(x, null)
                || object.ReferenceEquals(y, null))
            {
                return false;
            }

            return x.ID == y.ID && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] DupStudent obj)
        {
            if (obj == null)
            {
                return 0;
            }

            int IDHash = obj.ID.GetHashCode();
            int NameHash = obj.Name == null ? 0 : obj.Name.GetHashCode();

            return IDHash ^ NameHash;
        }
    }
}
