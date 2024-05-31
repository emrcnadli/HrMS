using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hr_Management_System.Features.Person.Coımmand.EditPerson
{
    public class EditPersonCommand : IRequest<Models.Entities.Person>
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SelectListItem> DepartmentId { get; set; }
        public List<SelectListItem> SkillId { get; set; }
        public List<SelectListItem> RoleId { get; set; }
        public List<SelectListItem> ProjectId { get; set; }
        public int Payment { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}