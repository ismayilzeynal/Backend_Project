using BackendProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EventController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {


            return View();
        }
    }
}
