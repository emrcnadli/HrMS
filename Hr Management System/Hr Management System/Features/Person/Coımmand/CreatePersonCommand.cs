using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Person.Commmand
{
    public class CreatePersonCommand : IRequest<Models.Entities.Person>//TRy with ViewModel
    {
        public Guid Id { get; set; } = new Guid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid DepartmentId { get; set; }
        public List<Guid> SkillId { get; set; }
        public Guid RoleId { get; set; }
        public List<Guid> ProjectId { get; set; }
        public int Payment { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
