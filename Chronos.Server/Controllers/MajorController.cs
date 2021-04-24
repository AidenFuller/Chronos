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
        [HttpGet]
        public Major Get(int MajorID)
        {
            using var db = new AppDbContext();

            //Geting just a Single Major degree
            return db.Majors.Find(MajorID);

            //Alternatively
            //Major sMajor = db.Majors.Find(MajorID);
            //return sMajor;

        }
    }
}
