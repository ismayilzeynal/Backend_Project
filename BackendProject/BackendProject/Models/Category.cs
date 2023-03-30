namespace BackendProject.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Course> Courses { get; set; }
    }
}
