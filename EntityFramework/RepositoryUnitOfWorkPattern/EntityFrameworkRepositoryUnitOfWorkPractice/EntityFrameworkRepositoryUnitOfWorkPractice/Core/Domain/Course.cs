using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkRepositoryUnitOfWorkPractice.Core.Domain
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public CourseLevel Level { get; set; }
        public string Description { get; set; }

        public float FullPrice { get; set; }

        public virtual Author Author { get; set; }

        public virtual IList<CourseTag> CourseTags { get; set; }
    }



}
