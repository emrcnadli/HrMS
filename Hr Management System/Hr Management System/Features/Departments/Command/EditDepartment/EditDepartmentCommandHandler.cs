using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Department;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Departments.Command.EditDepartment
{
    public class EditDepartmentCommandHandler : IRequestHandler<EditDepartmentCommand, Department>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Department _department;
        public EditDepartmentCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Department> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                _department = _mapper.Map<Department>(request);
                _context.Update(_department);
                await _context.SaveChangesAsync();
                return _department;
            }
            catch (Exception e)
            {
                throw new Exception("Department name already exists.");
            }
            
        }
    }
}
