using Hr_Management_System.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hr_Management_System.Models
{
    public class EditPersonViewModel
    {
        public Person Person { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }
        public List<Project> Projects { get; set; }
        public List<Skill> Skills { get; set; }

    }
}
