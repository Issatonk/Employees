using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DataAccess.MSSQL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
