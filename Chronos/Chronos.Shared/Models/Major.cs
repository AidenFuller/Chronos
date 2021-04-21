using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chronos.Shared.Models
{
    public class Major
    {
        [Key]

        public int MajorID { get; set; } //Primary Key

        public int DegreeID { get; set; } //Foreign key

        public string Name { get; set; }

    }
}
