using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Skills.Command.EditSkill
{
    public class EditSkillCommandHandler : IRequestHandler<EditSkillCommand, Skill>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Skill _skill;
        public EditSkillCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<Skill> Handle(EditSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _skill = _mapper.Map<Skill>(request);
                _context.Update(_skill);
                await _context.SaveChangesAsync();
                return _skill;
            }
            catch (Exception e)
            {
                throw new Exception("Department name already exists."+e);
            }
        }
    }
}
