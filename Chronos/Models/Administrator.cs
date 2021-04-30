using System.ComponentModel.DataAnnotations;

namespace Chronos.Models
{
    public class Administrator
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PassHash { get; set; }
    }
}
