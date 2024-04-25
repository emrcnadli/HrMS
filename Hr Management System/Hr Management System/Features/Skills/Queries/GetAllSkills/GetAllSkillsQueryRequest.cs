using MediatR;

namespace Hr_Management_System.Features.Skills.Queries.GetAllSkills
{
    public class GetAllSkillsQueryRequest : IRequest<IList<GetAllSkillsResponse>>
    {
    }
}
