using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chronos.Shared.Models
{
    public class MajorCourse
    {
        [Key]
        public int MajorCourseID { get; set; }
        public int MajorID { get; set; } //Foreign Key
        public int CourseID { get; set; } //Foreign Key
        public bool IsCore { get; set; }
    }
}
