using System.ComponentModel.DataAnnotations;

namespace Chronos.Models
{
    public class Degree
    {
        [Key]
        public int DegreeID { get; set; }
        public string Name { get; set; }
        public int UnitLength { get; set; }
        public bool InternationalsAllowed { get; set; }
        public int ElectiveCount { get; set; }
    }
}
