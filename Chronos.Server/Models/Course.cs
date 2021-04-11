using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Server.Models
{
    public class Course
    {
        public string Name { get; set; }
        public string CourseCode { get; set; }
        
        public decimal Cost { get; set; }
        public int Units { get; set; }
    }
}
