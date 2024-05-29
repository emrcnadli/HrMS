using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Skills.Command.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Skill>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Skill _skill;
        public CreateSkillCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<Skill> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            _skill = _mapper.Map<Skill>(request);
            if (!await _context.Skills.AnyAsync(d => d.Name == request.Name))
            {
                _context.Add(_skill);
                await _context.SaveChangesAsync();
                return _skill;
            }
            throw new Exception("Department name already exists.");
        }
    }
}
