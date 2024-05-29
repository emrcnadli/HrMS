using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Skills.Command.CreateSkill
{
    public class CreateSkillCommand : IRequest<Skill>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
}
