using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Projects.Command.EditProject
{
    public class EditProjectCommand : IRequest<Project>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
