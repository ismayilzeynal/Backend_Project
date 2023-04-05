using BackendProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
{
    public class CommonController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CommonController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Search(string search)
        {
            var courses = _appDbContext.Courses
                .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .Take(4)
                .OrderByDescending(p => p.Id)
                .ToList();                
            return PartialView("_SearchPartial", courses);
        }
    }
}
