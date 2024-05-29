using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Projects.Command.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Project>
    {
        public Project Project { get; set; }
    }
}
