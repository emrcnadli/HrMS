using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Skills.Command.DeleteSkill
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, Skill>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly Skill _skill;
        public DeleteSkillCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Skill> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var response = await _context.Departments.FirstOrDefaultAsync(m => m.Id == request.Id);
                var response = _context.Skills.Remove(request.Skill);
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
