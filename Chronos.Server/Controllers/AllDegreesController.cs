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
    public class AllDegreesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Degree> Get()
        {
            using var db = new AppDbContext();
            return db.Degrees;
        }
    }
}
