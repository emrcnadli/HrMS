using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Departments.Command.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<Department>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
}
