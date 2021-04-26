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
    public class MajorController : ControllerBase
    {
        //This function is going to add a new Major to the database. 
        [HttpPost]
        public bool Post(Major M)
        {
            using var db = new AppDbContext();

            db.Majors.Add(M); //This will add it to the database. 
            db.SaveChanges();

            return true;
        }
        [HttpGet]
        public Major Get(int MajorID)
        {
            using var db = new AppDbContext();

            //Geting just a Single Major degree
            return db.Majors.Find(MajorID);

        }
    }
}
