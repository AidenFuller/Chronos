using System.ComponentModel.DataAnnotations;

namespace Chronos.Models
{
    public class CoreCourse
    {
        [Key]
        public int CoreCourseID { get; set; }
        public int CourseID { get; set; } //Foreign Key
        public int DegreeID { get; set; } //Foreign Key
    }
}
