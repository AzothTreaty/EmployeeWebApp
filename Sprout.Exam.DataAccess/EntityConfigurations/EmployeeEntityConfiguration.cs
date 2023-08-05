using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sprout.Exam.DataAccess.DomainModels;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Sprout.Exam.DataAccess.EntityConfigurations
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever();
        }
    }
}
