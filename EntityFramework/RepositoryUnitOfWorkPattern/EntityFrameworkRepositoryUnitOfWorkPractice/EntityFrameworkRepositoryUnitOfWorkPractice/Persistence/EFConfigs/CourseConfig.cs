using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkRepositoryUnitOfWorkPractice.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkRepositoryUnitOfWorkPractice.Persistence.EFConfigs
{
    class CourseConfig : IEntityTypeConfiguration<CourseTag>
    {

        public void Configure(EntityTypeBuilder<CourseTag> builder)
        {
            builder.HasKey(ct => new {ct.CourseId, ct.TagId});
            builder.HasOne(ct => ct.Course)
                .WithMany(c => c.CourseTags)
                .HasForeignKey(ct => ct.CourseId);
            builder.HasOne(ct => ct.Tag)
                .WithMany(c => c.CourseTags)
                .HasForeignKey(ct => ct.TagId);
        }
    }
}
