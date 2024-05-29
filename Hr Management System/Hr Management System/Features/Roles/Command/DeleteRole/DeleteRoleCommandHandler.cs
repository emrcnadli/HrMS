using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommnand, Role>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Role _role;
        public DeleteRoleCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Role> Handle(DeleteRoleCommnand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
