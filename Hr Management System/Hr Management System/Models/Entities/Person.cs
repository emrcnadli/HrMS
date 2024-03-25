using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hr_Management_System.Models.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public ICollection<PersonProject> PersonProjects { get; set; }
        public List<Skill> Skills { get; set; }
        public Role Role { get; set; }
        public int Payment { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        

    }
}
