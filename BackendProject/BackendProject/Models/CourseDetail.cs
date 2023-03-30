namespace BackendProject.Models
{
    public class CourseDetail:BaseEntity
    {
        public string CourseDesc { get; set; }
        public string AboutCourse { get; set; }
        public string HowToApply { get; set; }
        public string Certification { get; set; }

        public Course Course { get; set; }
    }
}
