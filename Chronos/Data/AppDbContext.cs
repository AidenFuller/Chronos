﻿using Chronos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Course> Courses { get; set; }
       
        public DbSet<Major> Majors { get; set; }
        
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<CoreCourse> CoreCourses { get; set; }
        public DbSet<MajorCourse> MajorCourses { get; set; }
        public DbSet<PrerequisiteCourse> PrerequisiteCourses { get; set; }
        public DbSet<CourseAvailability> CourseAvailabilities { get; set; }
    }
}
