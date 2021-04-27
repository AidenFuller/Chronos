using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Shared.Models.Enums;

namespace Chronos.Shared.Models
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
