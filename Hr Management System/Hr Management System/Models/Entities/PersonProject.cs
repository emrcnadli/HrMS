namespace Hr_Management_System.Models.Entities
{
    public class PersonProject
    {
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }
        public Guid PersonID { get; set; }
        public Person Person { get; set; }
    }
}
