using BackendProject.DAL;
using BackendProject.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CoursesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<CourseVM> courseVMs = new();
            var CourseList = _appDbContext.Courses
                .Include(c => c.CourseDetail)
                .ToList();
            foreach (var course in CourseList)
            {
                CourseVM courseVM = new();
                courseVM.Id= course.Id;
                courseVM.Name= course.Name;
                courseVM.Desc = course.CourseDetail.CourseDesc;
                courseVM.ImageUrl = course.ImageUrl;
                courseVMs.Add(courseVM);
            }
            return View(courseVMs);
        }
    }
}
