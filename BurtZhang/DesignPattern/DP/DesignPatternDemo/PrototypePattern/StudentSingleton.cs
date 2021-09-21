using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrototypePattern
{
    public class StudentSingleton
    {
        
        private static StudentSingleton _studentSingleton = null;
        public int Id { get; set; }

        public string Name { get; set; }
        
        private StudentSingleton()
        {
            long lResult = 0;

            for (int i = 0; i < 10000000; i++)
            {
                lResult +=i;
            }

            Thread.Sleep(1000);

        }

        static StudentSingleton()
        {
            _studentSingleton = new StudentSingleton();
        }

        public static StudentSingleton CreateInstance()
        {
            return _studentSingleton;
        }


        public void Study()
        {

        }
    }
}
