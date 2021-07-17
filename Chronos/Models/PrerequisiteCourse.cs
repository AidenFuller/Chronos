using System;
using System.ComponentModel.DataAnnotations;
using Chronos.Models.Enums;

namespace Chronos.Models
{
    public class PrerequisiteCourse
    {
       [Key]
       public int PrerequisiteID { get; set; }      //Primary key
       public int CourseID { get; set; }            //Foreign key reference to Course Table
       public int PrerequisiteCourseID { get; set; }
       public RequisiteType CourseRequisite { get; set; }
    }
}
