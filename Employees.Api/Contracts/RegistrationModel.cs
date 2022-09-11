using Employees.Core;

namespace Employees.Api.Contracts
{
    public class RegistrationModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public int DepartmentId { get; set; }
    }
}
