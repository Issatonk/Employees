namespace Employees.DataAccess.MSSQL.Entities
{
    public class Contacts
    {
        public Employee Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
