using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Projects.Command.EditProject
{
    public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand, Project>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Project _project;
        public EditProjectCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Project> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _project = _mapper.Map<Project>(request);
                _context.Update(_project);
                await _context.SaveChangesAsync();
                return _project;
            }
            catch (Exception ex)
            {
                throw new Exception("Project edit error: " + ex);
            }
            
        }
    }
}
