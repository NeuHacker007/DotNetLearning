using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkRepositoryUnitOfWorkPractice.Core.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CourseTag> CourseTags { get; set; }
    }
}
