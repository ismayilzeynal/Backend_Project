namespace BackendProject.Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
