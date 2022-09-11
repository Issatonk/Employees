using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employees.Core.Services;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Employees.Core.Helpers
{
    public class AuthenticationHelper
    {
        private readonly IAccountService _service;
        private readonly IConfiguration _configuration;

        public AuthenticationHelper(IAccountService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        public async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            User person = await _service.Read(username);
            if (person != null && person.Password == CryptoHelper.GetHash(password, person.Salt))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role),
                };
                if (person.Role != "Admin") claims.Add(new Claim(ClaimTypes.UserData, person.Department.Id.ToString()));
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

        public string GenerateJwt(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: _configuration["Authentification:Issuer"],
                    audience: _configuration["Authentification:Audience"],
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(30)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(_configuration["Authentification:Key"])), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
