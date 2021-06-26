using Microsoft.AspNetCore.Mvc;
using Chronos.Models;
using Chronos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Services
{
    public class CourseService
    {
        private AppDbContext db;
        public CourseService(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<bool> AddCourseAsync(Course c) 
        {
            await db.Courses.AddAsync(c);
            await db.SaveChangesAsync();

            return true;
        }
        
        public async Task<Course> GetCourseAsync(int courseID)
        {
            return await db.Courses.FindAsync(courseID);
        }






























































        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return db.Courses;
        }

    }
}
