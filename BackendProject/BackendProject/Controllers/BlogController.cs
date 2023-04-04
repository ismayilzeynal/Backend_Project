using BackendProject.DAL;
using BackendProject.Models;
using BackendProject.ViewModels.Blog;
using BackendProject.ViewModels.Course;
using BackendProject.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
        public IActionResult Index(int page = 1, int take = 9)
        {
            var query = _appDbContext.Blogs
                .Include(b => b.Comments);

            var blogs = query.Skip((page - 1) * take)
              .Take(take)
              .ToList();

            int pageCount = CalculatePageCount(query, take);
            PaginationVM<Blog> pagination = new(blogs, pageCount, page);
            return View(pagination);
        }

        private int CalculatePageCount(IIncludableQueryable<Blog, List<Comment>> query, int take)
        {
            return (int)Math.Ceiling((decimal)(query.Count()) / take);
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
