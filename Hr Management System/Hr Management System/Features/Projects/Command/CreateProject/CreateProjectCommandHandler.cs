using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Projects.Command.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Project>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Project _project;

        public CreateProjectCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            _project = _mapper.Map<Project>(request);
            if(!await _context.Projects.AnyAsync(d=>d.Name == request.Name))
            {
                _context.Add(_project);
                await _context.SaveChangesAsync();
                return _project;
            }
            throw new Exception("Project name already exists.");
        }
    }
}
