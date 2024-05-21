using AutoMapper;
using Hr_Management_System.Models.Project;
using Hr_Management_System.Models.Entities;
using Hr_Management_System.Features.Projects.Command.CreateProject;

namespace Hr_Management_System.MapperProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<CreateProjectViewModel, Project>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<CreateProjectViewModel, CreateProjectCommand>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<CreateProjectCommand, Project>().
                ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
    }
}
