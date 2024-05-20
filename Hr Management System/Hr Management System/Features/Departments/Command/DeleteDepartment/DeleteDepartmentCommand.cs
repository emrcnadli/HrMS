using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Departments.Command.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<Department>
    {
        public Department Department { get; set; }
    }
}
