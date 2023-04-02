using BackendProject.Models;

namespace BackendProject.ViewModels
{
    public class AboutVM
    {
        public About About { get; set; }
        public List<Teacher> Teachers { get; set; }
        public VideoYT videoYT { get; set; }
        public List<Notice> Notices { get; set; }
    }
}
