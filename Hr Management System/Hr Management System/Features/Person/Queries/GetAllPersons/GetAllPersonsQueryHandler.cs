using Hr_Management_System.Data;
using Hr_Management_System.Features.Departments.Queries.GetAllDepartments;
using Hr_Management_System.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Features.Person.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQueryRequest, IList<GetAllPersonsResponse>>
    {
        private readonly ApplicationDBContext _context;
        public GetAllPersonsQueryHandler(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IList<GetAllPersonsResponse>> Handle(GetAllPersonsQueryRequest request, CancellationToken cancellationToken)
        {
            var persons = await _context.Persons.Include(x => x.PersonProjects).
                ThenInclude(a => a.Project).Include(p => p.PersonSkills).
                ThenInclude(p => p.Skill).Include(x => x.Department).Include(r => r.Role).ToListAsync();
            List<GetAllPersonsResponse> response = new();
            foreach (var item in persons)
            {
                response.Add(new GetAllPersonsResponse
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    BirthDay = item.BirthDay,
                    Department = item.Department,
                    DepartmentId = item.DepartmentId,
                    Email = item.Email, 
                    Payment = item.Payment,
                    PersonProjects = item.PersonProjects,
                    PersonSkills = item.PersonSkills,
                    Phone = item.Phone,
                    Role = item.Role,
                    RoleId = item.RoleId
                });
            }
            return response;
        }
    }
}
