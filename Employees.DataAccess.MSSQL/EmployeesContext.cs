using Employees.DataAccess.MSSQL.Configuration;
using Employees.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Employees.DataAccess.MSSQL
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<PositionInCompany> PositionInCompany { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PositionInCompanyConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
