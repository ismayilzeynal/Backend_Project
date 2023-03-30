namespace BackendProject.Models
{
    public class Blog:BaseEntity
    {
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
