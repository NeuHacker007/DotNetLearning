using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class StudentVIP : AbstractStudent
    {
        public override void Study()
        {
            Console.WriteLine("Learn VIP");
        }
    }


    public class StudentVIPInherit : StudentVIP
    {
        public override void Study()
        {
            
            base.Study();
            Console.WriteLine("get video after class");
        }
    }

    public class StudentCombination : AbstractStudent
    {
        private readonly AbstractStudent _student;

        public StudentCombination(AbstractStudent student)
        {
            _student = student;
        }

        public override void Study()
        {
            _student.Study();
            Console.WriteLine("get video after class");
        }
    }
}
