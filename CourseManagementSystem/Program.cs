using CourseManagementSystem.Models;
using CourseManagementSystem.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CourseManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();           

            builder.Services.AddDbContext<ProjectEntities>(OptionsBuilder =>
            {
                OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
           
            });

            //it must be after SQL DataBase Register Because it inject DataBase inside it
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                option=> option.User.RequireUniqueEmail = true
                ).AddEntityFrameworkStores<ProjectEntities>();

            //add Custom Service
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IinstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<ICourseResultRepository, CourseResultRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
