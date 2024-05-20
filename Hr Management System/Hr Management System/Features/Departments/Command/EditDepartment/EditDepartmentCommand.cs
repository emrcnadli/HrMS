using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Departments.Command
{
    public class EditDepartmentCommand :IRequest<Department>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
