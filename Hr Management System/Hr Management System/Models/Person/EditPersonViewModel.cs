using Hr_Management_System.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Hr_Management_System.Models.Entities;

namespace Hr_Management_System.Models.Person;

public class EditPersonViewModel
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
