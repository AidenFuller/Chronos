using Chronos.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectivesController : ControllerBase
    {

        public IEnumerable<Course> Get(int DegreeID, int MajorID)
        {

            //Instance of DB
            using var db = new AppDbContext();

            //Select all courseID that IS NOT equal not the given courseID
            IEnumerable<int> notCoreCourseIDs = db.CoreCourses.Where(i => i.DegreeID != DegreeID).Select(i => i.CourseID);
            //Select all courseID where the course IS NOT a core course for the given Major ID
            IEnumerable<int> notMajorCourseIDs = db.MajorCourses.Where(i => i.IsCore == false && i.MajorID == MajorID).Select(i => i.CourseID);

            //These 2 lists now contain
            // - All courses are that are not core for the given ID
            // - All non-core majors for the given majorID

            //Return all courses that are in either of the lists
            return
                from course in db.Courses
                join coreCourseID in notCoreCourseIDs on course.CourseID equals coreCourseID
                join majorCourseID in notMajorCourseIDs on course.CourseID equals majorCourseID
                select course;
        }
    }
}
