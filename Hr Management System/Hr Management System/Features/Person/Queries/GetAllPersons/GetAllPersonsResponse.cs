using Hr_Management_System.Models.Entities;

namespace Hr_Management_System.Features.Person.Queries.GetAllPersons
{
    public class GetAllPersonsResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<PersonProject>? PersonProjects { get; set; } = new List<PersonProject>();
        public ICollection<PersonSkill>? PersonSkills { get; set; } = new List<PersonSkill>();
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public int Payment { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
