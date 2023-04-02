using BackendProject.DAL;
using BackendProject.ViewModels.About;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            AboutVM aboutVM = new();
            aboutVM.About = _appDbContext.Abouts.FirstOrDefault();
            aboutVM.Teachers = _appDbContext.Teachers
                .Include(t=>t.Contacts)
                .ToList();
            aboutVM.videoYT = _appDbContext.VideoYTs.FirstOrDefault();
            aboutVM.Notices = _appDbContext.Notices.OrderByDescending(n => n.CreatedDate).ToList();

            return View(aboutVM);
        }
    }
}
