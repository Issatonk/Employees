using AutoMapper;
using Employees.Api.Contracts;
using Employees.Core;
using Employees.Core.Entity;
using Employees.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(NewDepartment newDepartment)
        {

            Department department = _mapper.Map<NewDepartment, Department>(newDepartment);

            await _departmentService.Create(department);

            return Ok();
        }
        [HttpGet]
        public  async Task<IActionResult> Read()
        {
            var result = await  _departmentService.ReadAll();

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Department updateDepartment)
        {
            var result = await _departmentService.Update(updateDepartment);

            return Ok(result);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int departmentId)
        {
            var result = await _departmentService.Delete(new Department { Id = departmentId });

            return Ok(result);
        }
    }
}
