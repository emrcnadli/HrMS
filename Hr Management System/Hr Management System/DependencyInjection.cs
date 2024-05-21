using Hr_Management_System.Features;
using Hr_Management_System.Features.Departments.Queries.GetAllDepartments;
using Hr_Management_System.Features.Projects.Queries.GetAllProjects;
using Microsoft.Extensions.DependencyInjection;

namespace Hr_Management_System
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblyContaining<GetAllDepartmentsQueryHandler>());
            

            return services;

        }
    }
}
