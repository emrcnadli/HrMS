using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hr_Management_System.Features.Person.Coımmand.EditPerson
{
    public class EditPersonCommand : IRequest<Models.Entities.Person>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid DepartmentId { get; set; }
        public Models.Entities.Department Department { get; set; }
        public ICollection<PersonProject> PersonProjects { get; set; }
        public ICollection<PersonSkill> PersonSkills { get; set; }
        public Guid RoleId { get; set; }
        public Models.Entities.Role Role { get; set; }
        public int Payment { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Guid> SelectedProjectIds { get; set; }
        public List<Guid> SelectedSkillIds { get; set; }
    }
}