using BackendProject.DAL;
using BackendProject.Models;
using BackendProject.ViewModels.Course;
using BackendProject.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<EventVM> eventVMs = new();
            var EventList = _appDbContext.Events.ToList();
            foreach (var item in EventList)
            {
                EventVM eventVM = new();
                eventVM.Id = item.Id;
                eventVM.Venue = item.Venue;
                eventVM.Title = item.Title;
                eventVM.ImageUrl = item.ImageUrl;
                eventVM.EventDate = item.EventDate;
                eventVM.StartTime = item.StartTime;
                eventVM.EndTime = item.EndTime;

                eventVMs.Add(eventVM);
            }

            return View(eventVMs);
        }

        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            EventDetailVM eventDetailVM = new();

            eventDetailVM.Event = _appDbContext.Events
                .Include(e=>e.EventSpeakers)
                .ThenInclude(es=>es.Speaker)
                .FirstOrDefault(e=>e.Id==id);

            eventDetailVM.Categories = _appDbContext.Categories
                .Include(c => c.Courses)
                .Take(6)
                .ToList();
            eventDetailVM.SideBlogs = _appDbContext.Blogs
                .OrderByDescending(b => b.Id)
                .Take(3)
                .ToList();

            return View(eventDetailVM);
        }
    }
}
