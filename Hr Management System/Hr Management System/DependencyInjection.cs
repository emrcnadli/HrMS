using Hr_Management_System.Features;
using Hr_Management_System.Features.Departments.Queries.GetAllDepartments;
using Hr_Management_System.Features.Projects.Queries.GetAllProjects;
using Hr_Management_System.Features.Roles.Queries.GetAllQueries;
using Hr_Management_System.Features.Skills.Queries.GetAllSkills;
using Microsoft.Extensions.DependencyInjection;

namespace Hr_Management_System
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblyContaining<GetAllDepartmentsQueryHandler>());
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblyContaining<GetAllProjectsQueryHandler>());
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblyContaining<GetAllRolesQueryHandler>());
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblyContaining<GetAllSkillsQueryHandler>());


            return services;

        }
    }
}
