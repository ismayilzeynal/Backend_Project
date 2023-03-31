using BackendProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CoursDetails { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeaker { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<AboutInfo> AboutInfos { get; set; }

        public DbSet<Notice> Notices { get; set; }

        public DbSet<AboutEduHome> AboutEduHomes { get; set; }

        public DbSet<VideoYT> VideoYTs { get; set; }

        public DbSet<Bio> Bios { get; set; }

    }
}
