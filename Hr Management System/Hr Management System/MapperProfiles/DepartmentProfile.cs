using AutoMapper;
using Hr_Management_System.Models.Department;
using Hr_Management_System.Models.Entities;
using Hr_Management_System.Features.Departments.Command.EditDepartment;
using Hr_Management_System.Features.Departments.Command.CreateDepartment;
using Hr_Management_System.Features.Departments.Command;

namespace Hr_Management_System.MapperProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() {
            CreateMap<CreateDepartmentViewModel, Department>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d=>d.Id, o=>o.MapFrom(s=>s.Id));
            CreateMap<CreateDepartmentViewModel, CreateDepartmentCommand>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<CreateDepartmentCommand, Department>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<EditDepartmentViewModel, EditDepartmentCommand>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<EditDepartmentCommand, Department>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));

        }
    }
}
