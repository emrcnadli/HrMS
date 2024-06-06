using AutoMapper;
using Azure.Core;
using Hr_Management_System.Data;
using Hr_Management_System.Features.Person.Queries.GetPersonForEdit;
using Hr_Management_System.Features.Projects.Queries.GetProjectById;
using Hr_Management_System.Features.Skills.Queries.GetSkillById;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hr_Management_System.Features.Person.Coımmand.EditPerson
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand, Models.Entities.Person>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public EditPersonCommandHandler(ApplicationDBContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;   
        }
        public async Task<Models.Entities.Person> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            var existingPerson = await _mediator.Send(new GetPersonForEditByIdQueryRequest() { Id = request.Id });
            existingPerson.Id = request.Id;
            existingPerson.FirstName = request.FirstName;
            existingPerson.LastName = request.LastName;
            existingPerson.DepartmentId = request.DepartmentId;
            existingPerson.RoleId = request.RoleId;
            existingPerson.Email = request.Email;
            existingPerson.Phone = request.Phone;
            existingPerson.BirthDay = request.BirthDay;
            existingPerson.Payment = request.Payment;


            existingPerson.PersonProjects.Clear();
            foreach (var projectId in request.SelectedProjectIds)
            {
                var project = await _mediator.Send(new GetProjectByIdQueryRequest()
                { Id = projectId, });
                existingPerson.PersonProjects.Add(new PersonProject()
                {
                    Person = existingPerson,
                    ProjectID = project.Id,
                });
            }

            existingPerson.PersonSkills.Clear();
            foreach (var skillId in request.SelectedSkillIds)
            {
                var skill = await _mediator.Send(new GetSkillByIdQueryRequest() { Id = skillId });
                existingPerson.PersonSkills.Add(new PersonSkill()
                {
                    Person = existingPerson,
                    SkillID = skill.Id
                });
            }

            _context.Update(existingPerson);
            await _context.SaveChangesAsync();
            return existingPerson;
        }
        public bool PersonExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
        
    }
}
