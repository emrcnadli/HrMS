using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.CodeAnalysis;

namespace Hr_Management_System.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryRequest : IRequest<Department>
    {
        public Guid Id { get; set; }
    }
}
