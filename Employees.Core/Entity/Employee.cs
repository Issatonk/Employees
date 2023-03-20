using System;
using System.Security;

namespace Employees.Core.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public Department Department { get; set; }

        public PositionInCompany Position { get; set; }

        public Contacts Contacts { get; set; }

        public Salary Salary { get; set; }
    }
}
