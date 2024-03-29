﻿using System.ComponentModel.DataAnnotations;
using Chronos.Models.Enums;

namespace Chronos.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public double Cost { get; set; } // unused
        public int Units { get; set; }
        public int RequiredCompletedUnits { get; set; }
    }
}
