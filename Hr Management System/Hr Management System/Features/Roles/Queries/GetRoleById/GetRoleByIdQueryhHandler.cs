using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryhHandler : IRequestHandler<GetRoleByIdQueryRequest, Role>
    {
        private readonly ApplicationDBContext _context;
        public GetRoleByIdQueryhHandler(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Role> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _context.Roles.FindAsync(request.Id);
        }
    }
}
