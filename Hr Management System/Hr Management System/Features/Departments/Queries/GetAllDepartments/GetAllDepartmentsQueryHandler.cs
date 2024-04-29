using Hr_Management_System.Data;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQueryRequest, IList<GetAllDepartmentsResponse>>
    {
        private readonly ApplicationDBContext _context;
        public GetAllDepartmentsQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IList<GetAllDepartmentsResponse>> Handle(GetAllDepartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var departments = await _context.Departments.ToListAsync();
            List<GetAllDepartmentsResponse> response = new();
            foreach (var item in departments)
            {
                response.Add(new GetAllDepartmentsResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            return response;
        }

    }
}
