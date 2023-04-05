using BackendProject.DAL;
using BackendProject.Models;
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

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult subscribe(string email)
        {
            SubscribedEmails SEmail = new();
            SEmail.Email = email;
            SEmail.IsDeleted = false;
            _appDbContext.SubscribedEmails.Add(SEmail);
            return Redirect("~/");
        }

        
    }
}
