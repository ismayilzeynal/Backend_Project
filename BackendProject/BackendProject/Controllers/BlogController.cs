using BackendProject.DAL;
using BackendProject.ViewModels.Blog;
using BackendProject.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<BlogVM> blogVMs = new();
            var BlogList = _appDbContext.Blogs
                .Include(b=>b.Comments)
                .Take(9)
                .ToList();
            foreach (var blog in BlogList)
            {
                BlogVM blogVM = new();
                blogVM.Id= blog.Id;
                blogVM.ImageUrl= blog.ImageUrl;
                blogVM.Title= blog.Title;
                blogVM.CreatedDate = blog.CreatedDate;
                blogVM.AuthorName= blog.AuthorName;
                blogVM.CommentCount = blog.Comments.Count;
                blogVMs.Add(blogVM);
            }

            return View(blogVMs);
        }
        public IActionResult Detail(int id)
        {
            if(id == null) return NotFound();
            BlogDetailVM blogDetailVM= new();
            blogDetailVM.Blog = _appDbContext.Blogs.FirstOrDefault(b => b.Id == id);
            blogDetailVM.Categories = _appDbContext.Categories
                .Include(c=>c.Courses)
                .Take(6)
                .ToList();
            blogDetailVM.SideBlogs = _appDbContext.Blogs
                .OrderByDescending(b=>b.Id)
                .Take(3)
                .ToList();



            return View(blogDetailVM);
        }
    }
}
