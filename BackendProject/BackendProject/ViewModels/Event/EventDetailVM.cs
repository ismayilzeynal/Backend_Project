using BackendProject.Models;

namespace BackendProject.ViewModels.Event
{
    public class EventDetailVM
    {
        public Models.Event Event { get; set; }
        public List<Models.Blog> SideBlogs { get; set; }
        public List<Models.Category> Categories { get; set; }
    }
}
