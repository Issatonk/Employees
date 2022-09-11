using AutoMapper;
using Employees.Core;

namespace Employees.Api
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Contracts.NewDepartment,Core.Department>();
            
            CreateMap<Contracts.NewEmployee, Core.Employee>()
                .ForMember(x=>x.Department, opt=>opt.MapFrom(src=>new Department { Id = src.DepartmentId }))
                .ForMember(x=>x.ProgLang, opt=>opt.MapFrom(src=>new ProgLang { Id= src.ProgLangId}));

            CreateMap<Contracts.NewProgLang, Core.ProgLang>();
        }
    }
}
