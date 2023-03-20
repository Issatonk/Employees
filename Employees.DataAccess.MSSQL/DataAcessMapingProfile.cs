using AutoMapper;
using Employees.Core.Entity;

namespace Employees.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Department, Entities.Department>().ReverseMap();

            CreateMap<User, Entities.User>().ReverseMap();

            CreateMap<Employee, Entities.Employee>().ReverseMap();

            CreateMap<Entities.Employee, Employee>();

            CreateMap<PositionInCompany, Entities.PositionInCompany>().ReverseMap();
        }
    }
}
