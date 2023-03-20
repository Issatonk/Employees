using System.Collections.Generic;

namespace Employees.DataAccess.MSSQL.Entities
{
    public class PositionInCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
