namespace BackendProject.ViewModels.Course
{
    public class CourseDetailVM
    {
        public Models.Course Course { get; set; }
        public List<Models.Blog> SideBlogs { get; set; }
        public List<Models.Category> Categories { get; set; }
    }
}
