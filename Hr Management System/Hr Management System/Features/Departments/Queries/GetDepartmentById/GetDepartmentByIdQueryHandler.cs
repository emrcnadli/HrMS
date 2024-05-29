using Hr_Management_System.Data;
using Hr_Management_System.Features.Departments.Queries.GetAllDepartments;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQueryRequest, Department>
    {
        private readonly ApplicationDBContext _context;
        public GetDepartmentByIdQueryHandler(ApplicationDBContext context)
        {
           _context = context;
        }

        public async Task<Department> Handle(GetDepartmentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _context.Departments.FindAsync(request.Id);
        }
    }
}
