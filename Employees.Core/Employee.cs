using System;

namespace Employees.Core
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public Department Department { get; set; }

        public ProgLang ProgLang { get; set; }
    }

}
