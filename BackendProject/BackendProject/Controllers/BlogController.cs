using BackendProject.DAL;
using BackendProject.Models;
using BackendProject.ViewModels.Blog;
using BackendProject.ViewModels.Course;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;

        public BlogController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
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
        public async Task<IActionResult> Detail(int id)
        {
            if(id == null) return NotFound();


            ViewBag.UserId = null;
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }

            BlogDetailVM blogDetailVM= new();
            blogDetailVM.Blog = _appDbContext.Blogs
                .Include(bm => bm.Comments)
                .ThenInclude(c => c.AppUser)
                .FirstOrDefault(b => b.Id == id);
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


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddComment(string commentMessage, int blogId)
        {
            AppUser user = null;

            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }
            else
            {
                return RedirectToAction("login", "account");
            }

            Comment comment = new();
            comment.Message = commentMessage;
            comment.CreatedDate = DateTime.Now;
            comment.AppUserId = user.Id;
            comment.BlogId = blogId;
            _appDbContext.Comments.Add(comment);
            _appDbContext.SaveChanges();
            return RedirectToAction("Detail", new { id = blogId });
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = _appDbContext.Comments.FirstOrDefault(b => b.Id == id);

            _appDbContext.Comments.Remove(comment);
            _appDbContext.SaveChanges();
            return RedirectToAction("detail", new { id = comment.BlogId });
        }









    }
}
