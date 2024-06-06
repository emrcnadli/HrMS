using AutoMapper;
using Hr_Management_System.Features.Person.Coımmand;
using Hr_Management_System.Features.Person.Coımmand.EditPerson;
using Hr_Management_System.Features.Person.Commmand;
using Hr_Management_System.Models.Entities;
using Hr_Management_System.Models.Person;

namespace Hr_Management_System.MapperProfiles
{
    public class PersonProfile :Profile
    {
        public PersonProfile() 
        {
            CreateMap<CreatePersonCommand, Person>().
                ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id)).
                ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId)).
                ForMember(d => d.Email, o => o.MapFrom(s => s.Email)).
                ForMember(d => d.BirthDay, o => o.MapFrom(s => s.BirthDay)).
                ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName)).
                ForMember(d => d.Payment, o => o.MapFrom(s => s.Payment)).
                ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone)).
                ForMember(d => d.RoleId, o => o.MapFrom(s => s.RoleId));
            CreateMap<Person, CreatePersonCommand>().
                ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName)).
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id)).
                ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId)).
                ForMember(d => d.Email, o => o.MapFrom(s => s.Email)).
                ForMember(d => d.BirthDay, o => o.MapFrom(s => s.BirthDay)).
                ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName)).
                ForMember(d => d.Payment, o => o.MapFrom(s => s.Payment)).
                ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone)).
                ForMember(d => d.RoleId, o => o.MapFrom(s => s.RoleId));
            CreateMap<CreatePersonViewModel, CreatePersonCommand>().
                ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName)).
                ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId)).
                ForMember(d => d.Email, o => o.MapFrom(s => s.Email)).
                ForMember(d => d.BirthDay, o => o.MapFrom(s => s.BirthDay)).
                ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName)).
                ForMember(d => d.Payment, o => o.MapFrom(s => s.Payment)).
                ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone)).
                ForMember(d => d.RoleId, o => o.MapFrom(s => s.RoleId));
            CreateMap<CreatePersonCommand, CreatePersonViewModel>().
                ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName)).
                ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId)).
                ForMember(d => d.Email, o => o.MapFrom(s => s.Email)).
                ForMember(d => d.BirthDay, o => o.MapFrom(s => s.BirthDay)).
                ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName)).
                ForMember(d => d.Payment, o => o.MapFrom(s => s.Payment)).
                ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone)).
                ForMember(d => d.RoleId, o => o.MapFrom(s => s.RoleId));
            CreateMap<EditPersonViewModel, EditPersonCommand>().
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id)).
                ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName)).
                ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName)).
                ForMember(d => d.Department, o => o.MapFrom(s => s.Department)).
                ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId)).
                ForMember(d => d.PersonProjects, o => o.MapFrom(s => s.PersonProjects)).
                ForMember(d => d.RoleId, o => o.MapFrom(s => s.RoleId)).
                ForMember(d => d.Role, o => o.MapFrom(s => s.Role)).
                ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone)).
                ForMember(d => d.BirthDay, o => o.MapFrom(s => s.BirthDay)).
                ForMember(d => d.Email, o => o.MapFrom(s => s.Email)).
                ForMember(d => d.Payment, o => o.MapFrom(s => s.Payment)).
                ForMember(d => d.SelectedProjectIds, o => o.MapFrom(s => s.SelectedProjectIds)).
                ForMember(d => d.SelectedSkillIds, o => o.MapFrom(s => s.SelectedSkillIds));
            CreateMap<EditPersonCommand, Person>().
                ForMember(d => d.Id, o => o.MapFrom(s => s.Id)).
                ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName)).
                ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName)).
                ForMember(d => d.Department, o => o.MapFrom(s => s.Department)).
                ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId)).
                ForMember(d => d.PersonProjects, o => o.MapFrom(s => s.PersonProjects)).
                ForMember(d => d.RoleId, o => o.MapFrom(s => s.RoleId)).
                ForMember(d => d.Role, o => o.MapFrom(s => s.Role)).
                ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone)).
                ForMember(d => d.BirthDay, o => o.MapFrom(s => s.BirthDay)).
                ForMember(d => d.Email, o => o.MapFrom(s => s.Email)).
                ForMember(d => d.Payment, o => o.MapFrom(s => s.Payment));
        }
    }
}
