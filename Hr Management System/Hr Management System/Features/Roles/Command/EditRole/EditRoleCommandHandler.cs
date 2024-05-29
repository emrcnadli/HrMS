using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Roles.Command.EditRole
{
    public class EditRoleCommandHandler : IRequestHandler<EditRoleCommand, Role>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Role _role;

        public EditRoleCommandHandler(ApplicationDBContext contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
            
        }
        public async Task<Role> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _role = _mapper.Map<Role>(request);
                _context.Update(_role);
                await _context.SaveChangesAsync();
                return _role;
            }
            catch (Exception e)
            {
                throw new Exception("Role name already exists.");
            }
        }
    }
}
