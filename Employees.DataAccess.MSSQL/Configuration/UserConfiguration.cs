using Employees.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.DataAccess.MSSQL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login).HasMaxLength(16).IsRequired();
           
            builder.Property(x=>x.Password).IsRequired();

            builder.Property(x=>x.Salt).IsRequired();

            builder.Property(x=>x.Role).IsRequired();

        }
    }
}
