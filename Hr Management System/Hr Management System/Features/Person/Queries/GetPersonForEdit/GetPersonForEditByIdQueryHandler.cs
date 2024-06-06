using Hr_Management_System.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Person.Queries.GetPersonForEdit
{
    public class GetPersonForEditByIdQueryHandler : IRequestHandler<GetPersonForEditByIdQueryRequest, Models.Entities.Person>
    {
        private readonly ApplicationDBContext _context;
        public GetPersonForEditByIdQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Models.Entities.Person> Handle(GetPersonForEditByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _context.Persons.
                Include(p => p.PersonProjects).
                ThenInclude(p => p.Project).
                Include(p => p.PersonSkills).
                ThenInclude(p => p.Skill).Include(p => p.Department).Include(p => p.Role).FirstOrDefault(p => p.Id == request.Id);
            return response;
        }
    }
}
