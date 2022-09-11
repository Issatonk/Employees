using Employees.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Employees.Api.Contracts
{

    public class NewEmployee
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }

        public int DepartmentId { get; set; }

        public int ProgLangId { get; set; }
    }
}
