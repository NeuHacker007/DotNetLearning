using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int Age { get; set; }


        public void Study()
        {
            Console.WriteLine("Study");
        }

        public void StudyHard()
        {
            Console.WriteLine("Hard study");
        }
        public void Sing()
        {
            Console.WriteLine($"instance Sing a Song");
        }
    }
}
