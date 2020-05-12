using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkRepositoryUnitOfWorkPractice.Core.Domain
{
    public class CourseTag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
