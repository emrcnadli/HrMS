using AutoMapper;
using Hr_Management_System.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Person.Coımmand.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Models.Entities.Person>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public DeletePersonCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Models.Entities.Person> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var response = await _context.Departments.FirstOrDefaultAsync(m => m.Id == request.Id);
                var response = _context.Persons.Remove(request.Person);
                _context.SaveChanges();
                return response.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
