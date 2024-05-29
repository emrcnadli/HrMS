using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQueryRequest, Project>
    {
        private readonly ApplicationDBContext _context;

        public GetProjectByIdQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<Project> Handle(GetProjectByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _context.Projects.FindAsync(request.Id);
        }
    }
}
