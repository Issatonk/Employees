using AutoMapper;

namespace Employees.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Core.Department, Entities.Department>().ReverseMap();

            CreateMap<Core.User, Entities.User>().ReverseMap();

            CreateMap<Core.Employee, Entities.Employee>().ReverseMap();

            CreateMap<Entities.Employee, Core.Employee>();

            CreateMap<Core.ProgLang, Entities.ProgLang>().ReverseMap();
        }
    }
}
