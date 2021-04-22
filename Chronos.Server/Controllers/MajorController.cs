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
    public class MajorController : ControllerBase
    {
        public IEnumerable<Major> Get(int degreeID)
        {
            using var db = new AppDbContext();
            IEnumerable<int> MajorIDs = db.Degrees.Where(i => i.DegreeID == degreeID).Select(i => i.MajorID);
            
            return
                 from Major in db.Majors
                 join id in MajorIDs on Major.MajorID equals id
                 select Major;
        }
    }
}
