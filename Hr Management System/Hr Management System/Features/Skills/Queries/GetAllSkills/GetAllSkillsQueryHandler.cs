using Hr_Management_System.Data;
using Hr_Management_System.Features.Roles.Queries.GetAllRoles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Skills.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQueryRequest, IList<GetAllSkillsResponse>>
    {
        private readonly ApplicationDBContext _context;
        public GetAllSkillsQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IList<GetAllSkillsResponse>> Handle(GetAllSkillsQueryRequest request, CancellationToken cancellationToken)
        {
            var skills = await _context.Skills.ToListAsync();
            List<GetAllSkillsResponse> response = new();
            foreach (var item in skills)
            {
                response.Add(new GetAllSkillsResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            return response;
        }
    }
}
