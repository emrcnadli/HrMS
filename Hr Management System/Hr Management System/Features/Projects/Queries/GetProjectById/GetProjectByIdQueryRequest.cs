using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQueryRequest : IRequest<Project>
    {
        public Guid Id { get; set; }
    }
}
