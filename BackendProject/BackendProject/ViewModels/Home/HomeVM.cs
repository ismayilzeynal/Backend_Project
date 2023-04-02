using BackendProject.Models;

namespace BackendProject.ViewModels.Home
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Notice> Notices { get; set; }
        public List<AboutInfo> AboutInfos { get; set; }
        public AboutEduHome AboutEduHome { get; set; }
        public List<Models.Course> Courses { get; set; }
    }
}
