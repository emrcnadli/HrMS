using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Projects.Command.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Project>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public DeleteProjectCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Project> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = _context.Projects.Remove(request.Project);
                _context.SaveChanges();
                return response.Entity;
            }
            catch (Exception ex) 
            { 
                throw new NotImplementedException(); 
            }
            
        }
    }
}
