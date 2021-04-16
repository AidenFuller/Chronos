using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Chronos.Server.Models
{
    public class Degree
    {
        [Key]
        public int DegreeID { get; set; }
        public string Name { get; set; }
        public int UnitLength { get; set; }
        public bool InternationalsAllowed { get; set; }
    }
}
