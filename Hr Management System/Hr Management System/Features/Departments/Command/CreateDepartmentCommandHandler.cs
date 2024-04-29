using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Department;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Departments.Command
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Department>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CreateDepartmentCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (!await _context.Departments.AnyAsync(d => d.Name == request.Name))
            {
                _context.Add(_mapper.Map<Department>(request));
                await _context.SaveChangesAsync();
                return _mapper.Map<Department>(request);
            }
            throw new Exception("Department name already exists.");
        }
    }
}
