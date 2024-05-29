using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Person.Queries.GetPersonById
{
    public class GetPersonByIdQueryRequest : IRequest<Hr_Management_System.Models.Entities.Person>
    {
        public Guid Id { get; set; }
    }
}
