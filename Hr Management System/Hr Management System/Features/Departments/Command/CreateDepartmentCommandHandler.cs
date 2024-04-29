using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Departments.Command
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Department>
    {
        private readonly ApplicationDBContext _context;
        public CreateDepartmentCommandHandler(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (!await _context.Departments.AnyAsync(d => d.Name == request.Name))
            {
                //request.Id = Guid.NewGuid();
                Department department = new Department()
                {
                    Name = request.Name,
                    Id = request.Id,
                };
                _context.Add(department);
                await _context.SaveChangesAsync();
                return department;
            }
            throw new Exception("Department name already exists.");
        }
    }
}
