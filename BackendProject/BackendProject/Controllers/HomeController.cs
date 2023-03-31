using BackendProject.DAL;
using BackendProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {
            HomeVM homeVM = new();
            homeVM.Sliders = _appDbContext.Sliders.ToList();
            homeVM.Notices = _appDbContext.Notices.OrderByDescending(n=>n.CreatedDate).ToList();
            homeVM.AboutInfos = _appDbContext.AboutInfos.ToList();
            homeVM.AboutEduHome = _appDbContext.AboutEduHomes.FirstOrDefault();

            return View(homeVM);
        }
    }
}
