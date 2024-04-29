using Hr_Management_System.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hr_Management_System.Models.Person;

public class EditPersonViewModel
{
    public Entities.Person Person { get; set; }
    public Entities.Department Department { get; set; }
    public Entities.Role Role { get; set; }
    public List<Entities.Project> Projects { get; set; }
    public List<Skill> Skills { get; set; }

}
