using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.DataAccess.MSSQL.Entities
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

    public enum Gender
    {
        male,
        female
    }
