﻿namespace Hr_Management_System.Models.Entities
{
    public class PersonSkills
    {
        public Guid SkillID { get; set; }
        public Skill Skill { get; set; }
        public Guid PersonID { get; set; }
        public Person Person { get; set; }
    }
}
