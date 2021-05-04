using System.ComponentModel.DataAnnotations;

namespace Chronos.Models
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
