using Hr_Management_System.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_System.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonProject>()
                .HasKey(cs => new { cs.ProjectID, cs.PersonID });

            modelBuilder.Entity<PersonProject>()
                .HasOne(cs => cs.Project)
                .WithMany(c => c.PersonProjects)
                .HasForeignKey(cs => cs.ProjectID);

            modelBuilder.Entity<PersonProject>()
                .HasOne(cs => cs.Person)
                .WithMany(s => s.PersonProjects)
                .HasForeignKey(cs => cs.PersonID);
            /*
            modelBuilder.Entity<Person>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Persons)
                .HasForeignKey(e => e.DepartmentId);*/
        }

    }
}
