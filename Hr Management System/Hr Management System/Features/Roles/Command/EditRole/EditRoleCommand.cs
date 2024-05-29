using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Roles.Command.EditRole
{
    public class EditRoleCommand : IRequest<Role>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
