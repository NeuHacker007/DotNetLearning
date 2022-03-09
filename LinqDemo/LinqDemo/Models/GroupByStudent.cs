using System.Collections.Generic;

namespace LinqDemo.Models
{
    public class GroupByStudent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Barnch { get; set; }
        public int Age { get; set; }
        public static List<GroupByStudent> GetStudents()
        {
            return new List<GroupByStudent>()
        {
            new GroupByStudent { ID = 1001, Name = "Preety", Gender = "Female",
                                         Barnch = "CSE", Age = 20 },
            new GroupByStudent { ID = 1002, Name = "Snurag", Gender = "Male",
                                         Barnch = "ETC", Age = 21  },
            new GroupByStudent { ID = 1003, Name = "Pranaya", Gender = "Male",
                                  Barnch = "CSE", Age = 21  },
            new GroupByStudent { ID = 1004, Name = "Anurag", Gender = "Male",
                                 Barnch = "CSE", Age = 20  },
            new GroupByStudent { ID = 1005, Name = "Hina", Gender = "Female",
                                  Barnch = "ETC", Age = 20 },
            new GroupByStudent { ID = 1006, Name = "Priyanka", Gender = "Female",
                                Barnch = "CSE", Age = 21 },
            new GroupByStudent { ID = 1007, Name = "santosh", Gender = "Male",
                                  Barnch = "CSE", Age = 22  },
            new GroupByStudent { ID = 1008, Name = "Tina", Gender = "Female",
                                  Barnch = "CSE", Age = 20  },
            new GroupByStudent { ID = 1009, Name = "Celina", Gender = "Female",
               Barnch = "ETC", Age = 22 },
            new GroupByStudent { ID = 1010, Name = "Sambit", Gender = "Male",
                                         Barnch = "ETC", Age = 21 }
        };
        }

    }
}
