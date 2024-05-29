using AutoMapper;
using Hr_Management_System.Features.Roles.Command.CreateRole;
using Hr_Management_System.Features.Roles.Command.EditRole;
using Hr_Management_System.Models.Entities;
using Hr_Management_System.Models.Role;

namespace Hr_Management_System.MapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile() 
        {
            CreateMap<CreateRoleCommand, Role>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<CreateRoleViewModel, CreateRoleCommand>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<EditRoleCommand, Role>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<EditRoleViewModel, EditRoleCommand>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<EditRoleCommand, Role>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
        
    }
}
