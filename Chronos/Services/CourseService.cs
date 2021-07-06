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
            db = dbContext; //Sets the database as the one passed in. 
        }

        public async Task<bool> AddCourseAsync(Course c)
        {
            await db.Courses.AddAsync(c);
            await db.SaveChangesAsync(); //This will update the DB after a new course has been added. 

            return true;
        }

        public async Task<Course> GetCourseAsync(int courseID)
        {
            return await db.Courses.FindAsync(courseID); //This will find a specific course in the DB. 
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return db.Courses; //This will return all the courses. 
        }

        public async Task<IEnumerable<Course>> GetPrerequisiteCoursesAsync(int CourseID)
        {
            IEnumerable<int> courseIDs = db.PrerequisiteCourses.Where(i => i.CourseID == CourseID).Select(i => i.PrerequisiteCourseID); //This will return an IEnumerable of Ints that relates to the specific Preqreuisite Courses in the Database. 

            return db.Courses.Where(i => courseIDs.Contains(i.CourseID)); //This will return the specific Prerequisite courses for that course ID. 
        }
    }
}
