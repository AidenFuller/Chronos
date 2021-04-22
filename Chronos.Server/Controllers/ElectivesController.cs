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

            //Select all courseID where it is a core course for the given Degree ID
            IEnumerable<int> NotCoreCourseIDs = db.CoreCourses.Where(i => i.DegreeID != DegreeID).Select(i => i.CourseID);
            //Select all courses where it is a  major core course for the given Major ID
            IEnumerable<int> NotMajorCourseIDs = db.MajorCourses.Where(i => i.IsCore == true && i.MajorID == MajorID).Select(i => i.CourseID);

            
            //Return all courses that are NOT in either of the lists.
            return
                from course in db.Courses
                join corecourseID in NotCoreCourseIDs on course.CourseID !equals corecourseID
                join majorcourseID in NotMajorCourseIDs on course.CourseID !equals majorcourseID
                select course;
        }
    }
}
