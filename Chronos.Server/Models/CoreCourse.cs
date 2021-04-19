using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Chronos.Server.Models
{
    public class CoreCourse
    {
        [Key]
        public int CoreCourseID { get; set; }
        public int CourseID { get; set; } //Foreign Key
        public int DegreeID { get; set; } //Foreign Key
    }
}
