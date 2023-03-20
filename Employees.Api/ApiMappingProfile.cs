using AutoMapper;
using Employees.Core;
using Employees.Core.Entity;

namespace Employees.Api
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Contracts.NewDepartment, Core.Entity.Department>();
            
            CreateMap<Contracts.NewEmployee, Core.Entity.Employee>()
                .ForMember(x=>x.Department, opt=>opt.MapFrom(src=>new Department { Id = src.DepartmentId }))
                .ForMember(x=>x.Position, opt=>opt.MapFrom(src=>new PositionInCompany { Id= src.ProgLangId}));

            CreateMap<Contracts.NewProgLang, Core.Entity.PositionInCompany>();
        }
    }
}
