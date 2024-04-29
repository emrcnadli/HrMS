using Hr_Management_System.Features.Departments.Queries.GetAllDepartments;
using MediatR;

namespace Hr_Management_System.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQueryRequest : IRequest<IList<GetAllProjectsResponse>>
    {
    }
}
