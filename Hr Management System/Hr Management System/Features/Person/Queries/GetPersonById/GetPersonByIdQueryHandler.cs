using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Person.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQueryRequest, Hr_Management_System.Models.Entities.Person>
    {
        private readonly ApplicationDBContext _context;
        public GetPersonByIdQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Hr_Management_System.Models.Entities.Person> Handle(GetPersonByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _context.Persons.FindAsync(request.Id);
        }
    }
}
