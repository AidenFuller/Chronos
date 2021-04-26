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
        //This is a post command that will add a new course to the Database. 
        [HttpPost]
        public bool Post(Course c) 
        {
            using var db = new AppDbContext();

            db.Courses.Add(c);
            db.SaveChanges();

            return true;
        }
        [HttpGet]
        public Course Get(int courseID)
        {
            using var db = new AppDbContext();
            return db.Courses.Find(courseID);
        }
    }
}
