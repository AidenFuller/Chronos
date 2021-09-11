using Microsoft.AspNetCore.Mvc;
using Chronos.Models;
using Chronos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Models.Enums;

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

        public async Task ReplaceCourseAsync(Course c)
        {
            db.Courses.Update(c);
            await db.SaveChangesAsync();
        }

        public async Task RemoveCourseAsync(Course c)
        {
            db.Courses.Remove(c);
            await db.SaveChangesAsync();
        }

        public async Task AddPrerequisiteAsync(int courseID, int prerequisiteCourseID, RequisiteType type)
        {
            PrerequisiteCourse pc = new PrerequisiteCourse()
            {
                CourseID = courseID,
                PrerequisiteCourseID = prerequisiteCourseID,
                CourseRequisite = type
            };

            await db.PrerequisiteCourses.AddAsync(pc);
            await db.SaveChangesAsync();
        }

        public async Task AddCourseAvailability(CourseAvailability c)
        {
            await db.CourseAvailabilities.AddAsync(c);
            await db.SaveChangesAsync();
        }

        public async Task RemoveCourseAvailability(int courseID, AvailableCampus campus)
        {
            var availability = db.CourseAvailabilities.First(c => c.CourseID == courseID && c.Campus == campus);
            db.CourseAvailabilities.Remove(availability);
            await db.SaveChangesAsync();
        }

        public async Task RemovePrerequisiteAsync(int courseID, int prerequisiteCourseID)
        {
            var pc = db.PrerequisiteCourses.First(c => c.CourseID == courseID && c.PrerequisiteCourseID == prerequisiteCourseID);
            db.PrerequisiteCourses.Remove(pc);

            await db.SaveChangesAsync();
        }

        public async Task<bool> DoesCourseExist(string courseCode)
        {
            return await Task.FromResult(db.Courses.Any(c => c.CourseCode == courseCode)); //This will check if any courses of that courseCode exists in the database. 
        }

        public async Task<Course> GetCourseAsync(int courseID)
        {
            return await db.Courses.FindAsync(courseID); //This will find a specific course in the DB. 
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync(IEnumerable<int> courseIDs)
        {
            return courseIDs.Select(c => db.Courses.Find(c));
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return db.Courses; //This will return all the courses. 
        }

        public async Task<IEnumerable<Course>> GetCoursesByCampusAsync(AvailableCampus campus)
        {
            IEnumerable<int> courseIDs = db.CourseAvailabilities.Where(i => i.Campus == campus).Select(i => i.CourseID);

            return db.Courses.Where(i => courseIDs.Contains(i.CourseID)); //Checks to see if the course exists at the specific Campus. 
        }

        public async Task<IEnumerable<Course>> GetPrerequisiteCoursesAsync(int CourseID)
        {
            IEnumerable<int> courseIDs = db.PrerequisiteCourses.Where(i => i.CourseID == CourseID).Select(i => i.PrerequisiteCourseID); //This will return an IEnumerable of Ints that relates to the specific Preqreuisite Courses in the Database. 

            return db.Courses.Where(i => courseIDs.Contains(i.CourseID)); //This will return the specific Prerequisite courses for that course ID. 
        }

        public async Task<IEnumerable<Course>> GetPrerequisiteCoursesAsync(int CourseID, RequisiteType type)
        {
            IEnumerable<int> courseIDs = db.PrerequisiteCourses.Where(i => i.CourseID == CourseID && i.CourseRequisite == type).Select(i => i.PrerequisiteCourseID); //Returns the courses that have prerequisites to a course. 

            return db.Courses.Where(i => courseIDs.Contains(i.CourseID)); //Returns the specific courses with that requisite and are prerequisite to the chosen course. 
        }

        public async Task<IEnumerable<Course>> GetReliantCoursesAsync(int CourseID, RequisiteType type)
        {
            IEnumerable<int> courseIDs = db.PrerequisiteCourses.Where(i => i.PrerequisiteCourseID == CourseID && i.CourseRequisite == type).Select(i => i.CourseID); //Grabs the ids of the reliant courses to that course and requisite type.
            return db.Courses.Where(i => courseIDs.Contains(i.CourseID)); //Returns the reliant courses. 
        }

        public async Task<CourseRuntime> GetCourseRuntimeAsync(int CourseID, AvailableCampus Campus)
        {
            CourseAvailability availability = await Task.FromResult(db.CourseAvailabilities.FirstOrDefault(i => i.CourseID == CourseID && i.Campus == Campus));
            //Convert to use ?? stuffs
            if (availability == null)
            {
                return 0;
            }
            else
            {
                return availability.Runtime;
            }
        }
    }
}
