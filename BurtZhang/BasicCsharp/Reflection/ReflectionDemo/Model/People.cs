using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class People
    {
        public People()
        {
            Console.WriteLine("{0} is constructed", this.GetType().FullName);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description;
    }

    public class PeopleDTO
    {
        public PeopleDTO()
        {
            Console.WriteLine("{0} is constructed", this.GetType().FullName);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description;
    }
}
