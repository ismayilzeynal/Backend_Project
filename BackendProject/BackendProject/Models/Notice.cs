namespace BackendProject.Models
{
    public class Notice:BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string Desc { get; set; }
    }
}
