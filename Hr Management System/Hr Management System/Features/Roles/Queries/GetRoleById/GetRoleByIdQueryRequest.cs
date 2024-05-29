using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryRequest : IRequest<Role>
    {
        public Guid Id { get; set; }
    }
}
