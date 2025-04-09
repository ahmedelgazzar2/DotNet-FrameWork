using CourseManagementSystem.Repository;
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
