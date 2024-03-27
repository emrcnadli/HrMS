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
            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonProjects)
                .WithOne(d => d.Person)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Project>()
                .HasMany(e => e.PersonProjects)
                .WithOne(d => d.Project)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonSkills)
                .WithOne(d => d.Person)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.PersonSkill)
                .WithOne(d => d.Skill)
                .OnDelete(DeleteBehavior.SetNull);

        }

    }
}
