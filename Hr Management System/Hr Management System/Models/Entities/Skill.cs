namespace Hr_Management_System.Models.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Person>? Persons { get; set; }

    }
}
