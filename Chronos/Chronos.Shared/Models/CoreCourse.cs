using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chronos.Shared.Models
{
    public class CoreCourse
    {
        [Key]
        public int CoreCourseID { get; set; }
        public int CourseID { get; set; } //Foreign Key
        public int DegreeID { get; set; } //Foreign Key
    }
}
