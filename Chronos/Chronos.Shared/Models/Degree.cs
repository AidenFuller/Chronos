using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Chronos.Shared.Models
{
    public class Degree
    {
        [Key]
        public int DegreeID { get; set; } //Primary key

        public int MajorID { get; set; } //Foreign Key

        public string Name { get; set; }
        public int UnitLength { get; set; }
        public bool InternationalsAllowed { get; set; }
    }
}
