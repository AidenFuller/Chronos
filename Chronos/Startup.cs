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
            services.AddTransient((services) => new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(Configuration.GetSection("ConnectionStrings").GetSection("ChronosConnection").Value).Options));
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
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1110", Name = "Object Oriented Programming", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "MATH1110", Name = "Mathematics for Engineering, Science & Technology 1", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG1003", Name = "Introduction to Procedural Programming", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP1140", Name = "Database and Information Management", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "MATH1510", Name = "Discrete Mathematics", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1050", Name = "Web Technologies", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1120", Name = "Data Structures", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });

            db.Courses.Add(new Models.Course() { CourseCode = "SENG2130", Name = "System Analysis and Design", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2031", Name = "System and Network Adminstration", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3260", Name = "Data Security", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2050", Name = "Web Engineering", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP2230", Name = "Algorithms", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP2240", Name = "Operating Systems", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2250", Name = "System and Network Security", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2260", Name = "Human-Computer Interaction", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP2270", Name = "Theory of Computation", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3500", Name = "Security Attacks Analysis and Mitigation Strategies", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3851A", Name = "Computer Science Work Integrated Learning Project Part A", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3330", Name = "Machine Intelligence", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3600", Name = "Security Standards and Practices in Industry", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3851B", Name = "Computer Science Work Integrated Learning Project Part B", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC3500", Name = "Telecommunication Networks", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC1710", Name = "Digital and Computer Electronics 1", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10 });




            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 1, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 2, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 3, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 4, DegreeID = 1 });

            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 5, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 6, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 7, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 8, DegreeID = 1 });

            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 9, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 10, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 11, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 12, DegreeID = 1 });

            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 13, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 14, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 15, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 16, DegreeID = 1 });

            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 17, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 18, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 19, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 20, DegreeID = 1 });

            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 21, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 22, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 23, DegreeID = 1 });
            db.CoreCourses.Add(new Models.CoreCourse() { CourseID = 24, DegreeID = 1 });

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
