using System;
using Chronos.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        [HttpGet]
        public Degree Get(int degreeID)
        {
            using var db = new AppDbContext();
            Degree Degree = db.Degrees.Find(degreeID);

            return Degree;
        }
    }
}
