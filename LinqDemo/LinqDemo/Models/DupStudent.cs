using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo.Models
{
    public class DupStudent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<DupStudent> GetStudents()
        {
            List<DupStudent> students = new List<DupStudent>()
            {
                new DupStudent {ID = 101, Name = "Preety" },
                new DupStudent {ID = 102, Name = "Sambit" },
                new DupStudent {ID = 103, Name = "Hina"},
                new DupStudent {ID = 104, Name = "Anurag"},
                new DupStudent {ID = 102, Name = "Sambit"},
                new DupStudent {ID = 103, Name = "Hina"},
                new DupStudent {ID = 101, Name = "Preety" },
            };
            return students;
        }

        public override bool Equals(object obj)
        {
            return this.ID == ((DupStudent) obj).ID && this.Name == ((DupStudent) obj).Name;
        }

        public override int GetHashCode()
        {
            //Get the ID hash code value
            int IDHashCode = this.ID.GetHashCode();
            //Get the string HashCode Value
            //Check for null refernece exception
            int NameHashCode = this.Name == null ? 0 : this.Name.GetHashCode();
            return IDHashCode ^ NameHashCode;
        }
    }
}
