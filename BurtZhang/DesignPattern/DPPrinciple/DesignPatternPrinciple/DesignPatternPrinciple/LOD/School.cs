using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LOD
{
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public List<Class> Classes { get; set; }


        public void Manage()
        {
            Console.WriteLine($"Manage {this.GetType().Name}");

            foreach (var c in Classes)
            {
                Console.WriteLine($"{nameof(c)} manage {c.ClassName}");
                c.Manage();
                {
                    // 基于学校 管理班级， 班级管理学生的前提 以下代码为间接朋友。视为依赖。 
                    // 因为 学生仅在 School的manage方法中出现，并且一旦student类修改
                    // 该处也要修改。所以为依赖
                    //      List<Student> students = c.Students;

                    //      foreach (var student in students)
                    //      {
                    //          Console.WriteLine(student.Id);
                    //      }
                }
               

            }
        }
    }
}
