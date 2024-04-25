using Hr_Management_System.Features.Roles.Queries.GetAllRoles;
using MediatR;

namespace Hr_Management_System.Features.Roles.Queries.GetAllQueries
{
    public class GetAllRolesQueryRequest : IRequest<IList<GetAllRolesResponse>>
    {
    }
}
