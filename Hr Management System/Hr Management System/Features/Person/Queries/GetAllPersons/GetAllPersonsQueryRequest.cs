using MediatR;

namespace Hr_Management_System.Features.Person.Queries.GetAllPersons
{
    public class GetAllPersonsQueryRequest : IRequest<IList<GetAllPersonsResponse>>
    {
    }
}
