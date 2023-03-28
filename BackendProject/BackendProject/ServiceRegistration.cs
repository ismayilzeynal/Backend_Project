using BackendProject.DAL;
using BackendProject.Helpers;
using BackendProject.Models;
using BackendProject.Services.Email;
using Microsoft.AspNetCore.Identity;

namespace BackendProject
{
    public static class ServiceRegistration
    {
        public static void BackendProjectServiceRegistration(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddHttpContextAccessor();
            services.AddScoped<ICreateEmailFile, CreateEmailFile>();
            services.AddScoped<IEmailSend, EmailSend>();

            services.AddIdentity<AppUser, IdentityRole>(options=>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<CustomIdentityErrorDescriber>();

        }
    }
}
