using Employees.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Employees.DataAccess.MSSQL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(16).IsRequired();

            builder.Property(x=>x.Surname).HasMaxLength(16).IsRequired();

            builder.Property(x=>x.Birthday).IsRequired().HasColumnType("date");

            builder.Property(x => x.Gender).IsRequired();

        }
    }
}
