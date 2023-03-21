using Employees.Core;

namespace Contracts.Requests
{
    public class RegistrationRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public int DepartmentId { get; set; }
    }
}
