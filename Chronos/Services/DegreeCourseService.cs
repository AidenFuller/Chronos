using Chronos.Data;
using Chronos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Services
{
    public class DegreeCourseService
    {
        private AppDbContext db;
        public DegreeCourseService(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<bool> AddCourseToDegreeAsync(int degreeID, int courseID)
        {
            //Create Object
            CoreCourse c = new CoreCourse() 
            { 
                CourseID = courseID, 
                DegreeID = degreeID 
            };

            //Add to DB
            await db.CoreCourses.AddAsync(c);
            await db.SaveChangesAsync();
            
            return true;
        }

        public async Task<IEnumerable<Course>> GetCoreCoursesAsync(int degreeID)
        {
            IEnumerable<int> courseIDs = db.CoreCourses.Where(i => i.DegreeID == degreeID).Select(i => i.CourseID); //This will make an IEnumerable of CourseIDs that are based on Core Courses from the DB. 
            
            return //This will return the Core Courses within that degree. 
                from course in db.Courses
                join id in courseIDs on course.CourseID equals id
                select course;
        }

        public async Task<bool> DoesCourseExistInDegree(string courseCode, int degreeID)
        {
            IEnumerable<Course> courses = await GetCoreCoursesAsync(degreeID);
            foreach(Course c in courses)
            {
                if(c.CourseCode == courseCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
