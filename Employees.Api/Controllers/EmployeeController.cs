using AutoMapper;
using Contracts.Requests;
using Employees.Core;
using Employees.Core.Entity;
using Employees.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody]CreateEmployeeRequest newEmployee)
        {
            var employee = _mapper.Map<Employee>(newEmployee);
            var result = await  _service.Create(employee);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAll();

            return Ok(employees);
        }

        [HttpGet("GetPage")]
        public async Task<IActionResult> GetPage(int page = 1, int size = 100, int? departmentId = null)
        {
            var result = await _service.GetPage(page, size, departmentId);

            return Ok(new {employees = result.Item1, pages = result.numberOfPages});
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequest employeeRequest)
        {

            var employee = _mapper.Map<Employee>(employeeRequest);

            var result = await _service.Update(employee);

            return Ok(result);
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int employeeId)
        {
            var result = await _service.Delete(new Employee { Id = employeeId });
            return Ok(result);
        }
        [HttpGet("GetByDepartment")]
        [Authorize]
        public async Task<IActionResult> GetByDepartment(int departmentId)
        {
            var result = await _service.GetByDepartment(new Department { Id = departmentId });

            return Ok(result);
        }
    }
}
