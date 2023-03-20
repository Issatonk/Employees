using Employees.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Employees.DataAccess.MSSQL.Configuration
{
    public class PositionInCompanyConfiguration : IEntityTypeConfiguration<PositionInCompany>
    {
        public void Configure(EntityTypeBuilder<PositionInCompany> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(16).IsRequired();

        }
    }
}
