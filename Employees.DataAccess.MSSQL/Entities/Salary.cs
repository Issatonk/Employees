using System;

namespace Employees.DataAccess.MSSQL.Entities
{
    public class Salary
    {
        public Employee Id { get; set; }

        public int Hours { get; set; }
        public decimal SalaryValue { get; set; }

        public DateTime DateSalary { get; set; }
    }
}
