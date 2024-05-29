using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Roles.Command.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Role>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Role _role;
        public CreateRoleCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            _role = _mapper.Map<Role>(request);
            if(!await _context.Roles.AnyAsync(d=>d.Name == request.Name))
            {
                _context.Add(_role);
                await _context.SaveChangesAsync();
                return _role;
            }
            throw new Exception("Role adding problem");
        }
    }
}
