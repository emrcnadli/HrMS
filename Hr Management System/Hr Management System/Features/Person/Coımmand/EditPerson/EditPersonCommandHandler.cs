using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Person.Coımmand.EditPerson
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand, Models.Entities.Person>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public EditPersonCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Models.Entities.Person> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Update(request.Person);
                await _context.SaveChangesAsync();
                return request.Person;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(request.Person.Id))
                {
                    return request.Person;
                }
                else
                {
                    throw;
                }
           
            }
        }
        public bool PersonExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
        
    }
}
