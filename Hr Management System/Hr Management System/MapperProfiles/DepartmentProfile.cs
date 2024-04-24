using AutoMapper;
using Hr_Management_System.Models;
using Hr_Management_System.Models.Entities;

namespace Hr_Management_System.MapperProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() {
            CreateMap<CreateDepartmentViewModel, Department>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d=>d.Id, o=>o.MapFrom(s=>s.Id));
        }
    }
}
