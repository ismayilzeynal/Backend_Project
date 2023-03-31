namespace BackendProject.Models
{
    public class Bio:BaseEntity
    {
        public string HeaderImageUrl { get; set; }
        public string FooterImageUrl { get; set; }
        public string Facebook { get; set; }
        public string Pinterest { get; set; }
        public string Vimeo { get; set; }
        public string Twitter { get; set; }
    }
}
