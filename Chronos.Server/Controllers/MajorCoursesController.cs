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
    public class MajorCoursesController : ControllerBase
    {
        public IEnumerable<Course> Get(int MajorID)
        {
            //Instance of DB
            using var db = new AppDbContext();

            //Select all courses where the MajorID is the given ID and return their course IDs
            IEnumerable<int> courseIDs = db.MajorCourses.Where(i => i.MajorID == MajorID).Select(i => i.CourseID);

            //Grabs all courses from the course table  where the ID is in CourseIDs
            return
                from course in db.Courses
                join id in courseIDs on course.CourseID equals id
                select course;
        }
    }
}
