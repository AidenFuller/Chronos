using Chronos.Areas.Identity;
using Chronos.Data;
using Chronos.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetSection("ConnectionStrings").GetSection("ChronosConnection").Value));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<CourseService>();
            services.AddScoped<DegreeCourseService>();
            services.AddScoped<DegreeService>();
            services.AddScoped<ElectiveService>();
            services.AddScoped<MajorCourseService>();
            services.AddScoped<MajorService>();


            using var db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(Configuration.GetSection("ConnectionStrings").GetSection("ChronosConnection").Value).Options);

            
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [CoreCourses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [MajorCourses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Majors]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Courses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Degrees]");
           
            db.SaveChanges();

            db.Database.Migrate();


            db.Degrees.Add(new Models.Degree() { InternationalsAllowed = true, Name = "Computer Science", UnitLength = 240 });
            db.Degrees.Add(new Models.Degree() { InternationalsAllowed = false, Name = "Software Engineering", UnitLength = 360 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP1010", Name = "Computing Fundamentals", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10});
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2050", Name = "Web Engineering", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1110", Name = "Object Oriented Programming", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });

            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 1, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 3, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 1, DegreeID = 2 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 3, DegreeID = 2 });

            db.Majors.Add(new Models.Major() { DegreeID = 1, Name = "Software Development" });
            db.Majors.Add(new Models.Major() { DegreeID = 1, Name = "Cyber Security" });

            db.MajorCourses.Add(new Models.MajorCourse() { IsCore = false, MajorID = 1, CourseID = 2 });
            db.MajorCourses.Add(new Models.MajorCourse() { IsCore = false, MajorID = 2, CourseID = 2 });

            db.SaveChanges();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
