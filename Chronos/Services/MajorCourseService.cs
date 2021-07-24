using Chronos.Models;
using Chronos.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Services
{
    public class MajorCourseService
    {
        private AppDbContext db;
        public MajorCourseService(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<bool> AddCourseToMajorAsync(int courseID, int majorID, bool isCompulsory)
        {
            //Create Object
            MajorCourse c = new MajorCourse()
            {
                CourseID = courseID,
                MajorID = majorID,
                IsCompulsory = isCompulsory
            };

            //Add to DB
            await db.MajorCourses.AddAsync(c);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Course>> GetAllDirectedCoursesAsync(int MajorID)
        {
            //Select all courses where the MajorID is the given ID and return their course IDs
            IEnumerable<int> courseIDs = db.MajorCourses.Where(i => i.MajorID == MajorID).Select(i => i.CourseID);

            //Grabs all courses from the course table  where the ID is in CourseIDs
            return
                from course in db.Courses
                join id in courseIDs on course.CourseID equals id
                select course;
        }

        public async Task<IEnumerable<Course>> GetCompulsoryCoursesAsync(int MajorID)
        {
            //Select all courses where the MajorID is the given ID and return their course IDs
            IEnumerable<int> courseIDs = db.MajorCourses.Where(i => i.MajorID == MajorID && i.IsCompulsory).Select(i => i.CourseID);

            //Grabs all courses from the course table  where the ID is in CourseIDs
            return
                from course in db.Courses
                join id in courseIDs on course.CourseID equals id
                select course;
        }

        public async Task<IEnumerable<Course>> GetNonCompulsoryCoursesAsync(int MajorID)
        {
            //Select all courses where the MajorID is the given ID and return their course IDs
            IEnumerable<int> courseIDs = db.MajorCourses.Where(i => i.MajorID == MajorID && !i.IsCompulsory).Select(i => i.CourseID);

            //Grabs all courses from the course table  where the ID is in CourseIDs
            return
                from course in db.Courses
                join id in courseIDs on course.CourseID equals id
                select course;
        }
    }
}
