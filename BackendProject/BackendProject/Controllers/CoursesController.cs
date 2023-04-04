using BackendProject.DAL;
using BackendProject.ViewModels.Blog;
using BackendProject.ViewModels.Course;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            CourseDetailVM courseDetailVM = new();
            
            courseDetailVM.Course = _appDbContext.Courses
                .Include(c=>c.CourseDetail)
                .FirstOrDefault(c => c.Id == id);
            courseDetailVM.Categories = _appDbContext.Categories
                .Include(c => c.Courses)
                .Take(6)
                .ToList();
            courseDetailVM.SideBlogs = _appDbContext.Blogs
                .OrderByDescending(b => b.Id)
                .Take(3)
                .ToList();

            return View(courseDetailVM);
        }
    }
}
