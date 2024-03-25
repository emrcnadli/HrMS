namespace Hr_Management_System.Models.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PersonProject>? PersonProjects { get; set; }

    }
}
