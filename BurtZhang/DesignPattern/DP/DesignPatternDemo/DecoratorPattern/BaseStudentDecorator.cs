using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class BaseStudentDecorator: AbstractStudent
    {
        private readonly AbstractStudent _student;

        public BaseStudentDecorator(AbstractStudent student)
        {
            _student = student;
        }
        public override void Study()
        {
            _student.Study();
            Console.WriteLine("*************");
        }
    }
}
