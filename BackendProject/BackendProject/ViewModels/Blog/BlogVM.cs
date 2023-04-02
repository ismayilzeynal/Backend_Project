namespace BackendProject.ViewModels.Blog
{
    public class BlogVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public int CommentCount { get; set; }
    }
}
