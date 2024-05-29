using AutoMapper;
using Hr_Management_System.Features.Departments.Command.CreateDepartment;
using Hr_Management_System.Features.Departments.Command;
using Hr_Management_System.Features.Roles.Command.CreateRole;
using Hr_Management_System.Features.Roles.Command.EditRole;
using Hr_Management_System.Features.Skills.Command.CreateSkill;
using Hr_Management_System.Features.Skills.Command.EditSkill;
using Hr_Management_System.Models.Department;
using Hr_Management_System.Models.Entities;
using Hr_Management_System.Models.Role;
using Hr_Management_System.Models.Skill;

namespace Hr_Management_System.MapperProfiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile() 
        {
            CreateMap<CreateSkillViewModel, Skill>().
                 ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                 ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<CreateSkillViewModel, CreateSkillCommand>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<CreateSkillCommand, Skill>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<EditSkillViewModel, EditSkillCommand>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<EditSkillCommand, Skill>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
    }
}
