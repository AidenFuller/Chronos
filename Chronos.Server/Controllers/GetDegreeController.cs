using System;
using Chronos.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDegreeController : ControllerBase
    {
        [HttpGet]
        public Degree Get(int degreeID)
        {
            using var db = new AppDbContext();
            Degree degree = db.Degrees.Find(i => i.DegreeID == degreeID);

            return degree;
        }
    }
}
