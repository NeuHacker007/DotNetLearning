using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class StudentHomeworkDecorator : BaseStudentDecorator
    {
        public StudentHomeworkDecorator(AbstractStudent student) : base(student)
        {
        }

        public override void Study()
        {
            base.Study();
            Console.WriteLine("Do Homework");
        }
    }
}
