using Chronos.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Models
{
    public class CourseAvailability
    {
        [Key]
        public int CourseAvailabilityID { get; set; }
        public int CourseID { get; set; }
        public AvailableCampus Campus { get; set; }
        public CourseRuntime Runtime { get; set; }
    }
}
