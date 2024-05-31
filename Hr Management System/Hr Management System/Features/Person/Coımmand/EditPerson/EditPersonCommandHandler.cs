using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var person = new Models.Entities.Person();
            try
            {
                
                _context.Update(request);
                var response = await _context.SaveChangesAsync();
                return person;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(request.id))
                {
                    return person;
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
