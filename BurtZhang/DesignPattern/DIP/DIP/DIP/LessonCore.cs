using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    /// <summary>
    /// 抽象类 父类
    /// 抽象
    /// </summary>
    public abstract class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract void Study();

        public void Movie()
        {
            Console.WriteLine("Get video back");
        }
    }

    public interface ILesson
    {
        void Movie();
    }

    public class LessonCore : Lesson, ILesson
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        public override void Study()
        {
            Console.WriteLine("Learn core");
        }

        //public void Movie()
        //{
        //    Console.WriteLine("Get video back");
        //}
    }

    public class LessonDesign : Lesson,ILesson
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        public override void Study()
        {
            Console.WriteLine("Learn design");
        }

        //public void Movie()
        //{
        //    Console.WriteLine("Get video back");
        //}
    }
}
