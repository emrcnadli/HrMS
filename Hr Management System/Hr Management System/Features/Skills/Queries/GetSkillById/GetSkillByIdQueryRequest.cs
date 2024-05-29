using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Skills.Queries.GetSkillById
{
    public class GetSkillByIdQueryRequest : IRequest<Skill>
    {
        public Guid Id { get; set; }
    }
}
