using Chronos.Server.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Server.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public AvailableCampus Campus { get; set; }
        public double Cost { get; set; }
        public int Units { get; set; }
    }
}
