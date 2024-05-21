using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Projects.Command.CreateProject
{
    public class CreateProjectCommand : IRequest<Project>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
}
