using AutoMapper;
using Contracts.Requests;
using Employees.Core;
using Employees.Core.Entity;

namespace Employees.Api
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateDepartmentRequest, Department>();
            
            CreateMap<CreateEmployeeRequest, Employee>()
                .ForMember(x=>x.Department, opt=>opt.MapFrom(src=>new Department { Id = src.DepartmentId }))
                .ForMember(x=>x.Position, opt=>opt.MapFrom(src=>new PositionInCompany { Id= src.PositionInCompanyId}));

            CreateMap<CreateEmployeeRequest, PositionInCompany>();

            CreateMap<UpdateEmployeeRequest, Employee>()
                .ForMember(x => x.Department, opt => opt.MapFrom(src => new Department { Id = src.DepartmentId }))
                .ForMember(x => x.Position, opt => opt.MapFrom(src => new PositionInCompany { Id = src.PositionInCompanyId }));
        }
    }
}
