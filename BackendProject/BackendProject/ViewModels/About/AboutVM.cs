using BackendProject.Models;

namespace BackendProject.ViewModels.About
{
    public class AboutVM
    {
        public Models.About About { get; set; }
        public List<Models.Teacher> Teachers { get; set; }
        public VideoYT videoYT { get; set; }
        public List<Notice> Notices { get; set; }
    }
}
