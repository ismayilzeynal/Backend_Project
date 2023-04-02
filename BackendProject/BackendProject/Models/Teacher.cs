namespace BackendProject.Models
{
    public class Teacher : BaseEntity
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImageUrl { get; set; }
        public string Degree { get; set; }
        public string Experience { get; set; }
        public string Hobbies { get; set; }
        public string Faculty { get; set; }

        public Skill Skill { get; set; }
        public Contacts Contacts { get; set; }
    }
}
