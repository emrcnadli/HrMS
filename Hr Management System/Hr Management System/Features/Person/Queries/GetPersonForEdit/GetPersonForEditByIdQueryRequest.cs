using MediatR;

namespace Hr_Management_System.Features.Person.Queries.GetPersonForEdit
{
    public class GetPersonForEditByIdQueryRequest : IRequest<Hr_Management_System.Models.Entities.Person>
    {
        public Guid Id { get; set; }
    }
}
