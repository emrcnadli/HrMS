using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Skills.Command.DeleteSkill
{
    public class DeleteSkillCommand : IRequest<Skill>
    {
        public Skill Skill { get; set; }
    }
}
