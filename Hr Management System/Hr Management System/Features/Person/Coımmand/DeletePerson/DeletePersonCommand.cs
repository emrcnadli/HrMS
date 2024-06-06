using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Person.Coımmand.DeletePerson
{
    public class DeletePersonCommand : IRequest<Models.Entities.Person>
    {
        public Models.Entities.Person Person { get; set; }
    }
}
