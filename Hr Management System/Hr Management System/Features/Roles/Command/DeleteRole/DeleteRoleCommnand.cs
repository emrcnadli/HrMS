using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleCommnand : IRequest<Role>
    {
        public Role Role { get; set; }
    }
}
