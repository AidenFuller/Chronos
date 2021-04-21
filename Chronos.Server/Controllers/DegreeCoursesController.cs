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
    public class DegreeCoursesController : ControllerBase
    {
        public IEnumerable<Course> Get(int degreeID)
        {
            using var db = new AppDbContext();
            IEnumerable<int> courseIDs = db.CoreCourses.Where(i => i.DegreeID == degreeID).Select(i => i.CourseID);
            
            return
                from course in db.Courses
                join id in courseIDs on course.CourseID equals id
                select course;
        }
    }
}
