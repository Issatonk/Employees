namespace Employees.DataAccess.MSSQL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public byte[] Salt { get; set; }

        public string Role { get; set; }
    }
}
