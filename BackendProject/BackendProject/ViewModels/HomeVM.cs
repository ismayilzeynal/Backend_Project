using BackendProject.Models;

namespace BackendProject.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Notice> Notices { get; set; }
        public List<AboutInfo> AboutInfos { get; set; }
    }
}
