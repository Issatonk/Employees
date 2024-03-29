﻿using Employees.Api.Contracts;
using Employees.Core;
using Employees.Core.Helpers;
using Employees.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountService _service;
        private readonly AuthenticationHelper _helper;
        public AccountController(IConfiguration configuration, IAccountService service)
        {
            _configuration = configuration;
            _service = service;
            _helper = new AuthenticationHelper(_service, _configuration);
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token(LoginModel login)
        {
            var identity = await _helper.GetIdentity(login.Login, login.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
            var response = new
            {
                access_token = _helper.GenerateJwt(identity),
                username = identity.Name,
                role = identity.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value,
                departmentId = identity.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.UserData)?.Value
            };

            return Ok(response);
        }

        [HttpPost("/registration")]
        public async Task<IActionResult> Registration(RegistrationModel registration)
        {
            User user = new User
            {
                Login = registration.Login,
                Password = registration.Password,
                Role = "Manager",
                Department = new Department { Id = registration.DepartmentId }
            };
            await _service.Create(user);
            var identity = await _helper.GetIdentity(registration.Login, registration.Password);
            var response = new
            {
                access_token = _helper.GenerateJwt(identity),
                username = identity.Name,
                role = identity.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value,
                departmentId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData)?.Value
            };
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(string login)
        {
            var result = await _service.Delete(login);

            return Ok(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangePassword(string login, string password)
        {

            await _service.Update(login, password);
            return Ok();
        }

    }
}
