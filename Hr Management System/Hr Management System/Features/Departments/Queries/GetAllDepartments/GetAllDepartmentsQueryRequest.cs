using MediatR;
namespace Hr_Management_System.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryRequest :IRequest<IList<GetAllDepartmentsResponse>>
    {
    }
}
