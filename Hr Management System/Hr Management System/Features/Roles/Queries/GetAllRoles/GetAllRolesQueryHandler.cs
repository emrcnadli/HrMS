using Hr_Management_System.Data;
using Hr_Management_System.Features.Departments.Queries.GetAllDepartments;
using Hr_Management_System.Features.Roles.Queries.GetAllRoles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Roles.Queries.GetAllQueries
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, IList<GetAllRolesResponse>>
    {
        private readonly ApplicationDBContext _context;
        public GetAllRolesQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IList<GetAllRolesResponse>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.ToListAsync();
            List<GetAllRolesResponse> response = new();
            foreach (var item in roles)
            {
                response.Add(new GetAllRolesResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            return response;
        }
    }
}
