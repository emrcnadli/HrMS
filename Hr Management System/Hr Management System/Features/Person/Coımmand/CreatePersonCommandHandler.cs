using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using System;

namespace Hr_Management_System.Features.Person.Coımmand
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Hr_Management_System.Models.Entities.Person>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Hr_Management_System.Models.Entities.Person _person;
        public CreatePersonCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Models.Entities.Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Models.Entities.Person _person = _mapper.Map<Models.Entities.Person>(request);
            foreach (var item in request.ProjectId)
            {
                _person.PersonProjects.Add(new PersonProject()
                {
                    Person = _person,
                    ProjectID = item
                });
            }
            foreach (var item in request.SkillId)
            {
                _person.PersonSkills.Add(new PersonSkill()
                {
                    Person = _person,
                    SkillID = item
                });
            }
            _context.Persons.Add(_person);
            _context.SaveChanges();
            return _person;
        }
    }
}
