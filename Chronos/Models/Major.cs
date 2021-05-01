using System.ComponentModel.DataAnnotations;

namespace Chronos.Models
{
    public class Major
    {
        [Key]
        public int MajorID { get; set; } //Primary Key
        public int DegreeID { get; set; } //Foreign key
        public string Name { get; set; }
    }
}
