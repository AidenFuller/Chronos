using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Server
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<CoreCourse> CoreCourses { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<MajorCourse> MajorCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=Application.db;Cache=Shared");
        }
    }
}
