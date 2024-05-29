using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Skills.Command.EditSkill
{
    public class EditSkillCommand : IRequest<Skill>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
