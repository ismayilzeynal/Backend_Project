namespace BackendProject.ViewModels.Blog
{
    public class BlogDetailVM
    {
        public Models.Blog Blog { get; set; }
        public List<Models.Blog> SideBlogs { get; set; }
        public List<Models.Category> Categories { get; set; }
    }
}
