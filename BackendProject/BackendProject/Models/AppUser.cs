using Microsoft.AspNetCore.Identity;

namespace BackendProject.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsActive { get; set; }
        public string? ConnectionId { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
