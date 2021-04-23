using Microsoft.AspNetCore.Mvc;
using Chronos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public Course Get(int courseID)
        {
            using var db = new AppDbContext();
            Course SelectedCourse = db.Courses.Find(courseID);

            return SelectedCourse;
        }
    }
}
