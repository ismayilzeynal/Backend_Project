namespace BackendProject.Models
{
    public class Comment:BaseEntity
    {
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
