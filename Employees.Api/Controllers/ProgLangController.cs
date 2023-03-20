using AutoMapper;
using Employees.Api.Contracts;
using Employees.Core;
using Employees.Core.Entity;
using Employees.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgLangController : ControllerBase
    {
        private readonly IPositionInCompanyService _service;
        private readonly IMapper _mapper;

        public ProgLangController(IPositionInCompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(NewProgLang newProgLang)
        {
            var progLang = _mapper.Map<NewProgLang, PositionInCompany>(newProgLang);

            var result = await _service.Create(progLang);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var result = await _service.ReadAll();

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(PositionInCompany progLang)
        {
            var result = await _service.Update(progLang);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int proglangId)
        {
            var result = await _service.Delete(new PositionInCompany { Id = proglangId });
            return Ok(result);
        }
    }
}
