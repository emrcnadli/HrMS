using Hr_Management_System.Data;
using Hr_Management_System.Features.Departments.Queries.GetAllDepartments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQueryRequest, IList<GetAllProjectsResponse>>
    {
        private readonly ApplicationDBContext _context;
        public GetAllProjectsQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IList<GetAllProjectsResponse>> Handle(GetAllProjectsQueryRequest request, CancellationToken cancellationToken)
        {
            var projects = await _context.Projects.ToListAsync();
            List<GetAllProjectsResponse> response = new();
            foreach (var item in projects)
            {
                response.Add(new GetAllProjectsResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            return response;
        }
    }
}
