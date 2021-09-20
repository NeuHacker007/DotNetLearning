using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LOD
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }

        public List<Student> Students { get; set; }

        public void Manage()
        {
            foreach (var student in Students)  
            {
                Console.WriteLine($"{nameof(student)} manage {student.Id}");
            }
        }
    }
}
