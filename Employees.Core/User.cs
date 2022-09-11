using System.Collections.Generic;
using System.Linq;

namespace Employees.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public byte[] Salt { get; set; }

        public string Role { get; set; }

        public Department Department { get; set; }
    }

}
