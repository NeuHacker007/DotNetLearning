using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkRepositoryUnitOfWorkPractice.Core.Domain
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Course> Courses { get; set; }
    }



}
