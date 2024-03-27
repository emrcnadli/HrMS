using Hr_Management_System.Models.Entities;

namespace Hr_Management_System.Models
{
    public class CreatePersonViewModel
    {
        internal readonly bool IsValid;
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
