using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Departments.Command.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Department>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private Department _department;
        public DeleteDepartmentCommandHandler(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Department> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            try {
                //var response = await _context.Departments.FirstOrDefaultAsync(m => m.Id == request.Id);
                var response = _context.Departments.Remove(request.Department);
                _context.SaveChanges();
                return response.Entity;
            }
            catch (Exception ex) {
                throw new NotImplementedException();
            }



        }
    }
}
