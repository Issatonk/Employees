using System;

namespace Employees.Core.Entity
{
    public class Salary
    {
        public Employee Id { get; set; }

        public decimal SalaryValue { get; set; }

        public int Hours { get; set; }

        public DateTime DateSalary { get; set; }
    }
}
