using Employees.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Employees.DataAccess.MSSQL.Configuration
{
    public class ProgLangConfiguration : IEntityTypeConfiguration<ProgLang>
    {
        public void Configure(EntityTypeBuilder<ProgLang> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(16).IsRequired();

        }
    }
}
