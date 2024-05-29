using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Skills.Queries.GetSkillById
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQueryRequest, Skill>
    {
        private readonly ApplicationDBContext _context;
        public GetSkillByIdQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Skill> Handle(GetSkillByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _context.Skills.FindAsync(request.Id);
        }
    }
}
