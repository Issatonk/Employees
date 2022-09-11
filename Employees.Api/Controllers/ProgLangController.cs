using AutoMapper;
using Employees.Api.Contracts;
using Employees.Core;
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
        private readonly IProgLangService _service;
        private readonly IMapper _mapper;

        public ProgLangController(IProgLangService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(NewProgLang newProgLang)
        {
            var progLang = _mapper.Map<NewProgLang, ProgLang>(newProgLang);

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
        public async Task<IActionResult> Update(ProgLang progLang)
        {
            var result = await _service.Update(progLang);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int proglangId)
        {
            var result = await _service.Delete(new ProgLang { Id = proglangId });
            return Ok(result);
        }
    }
}
