using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
    }
}
