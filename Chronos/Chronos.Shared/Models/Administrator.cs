using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chronos.Shared.Models
{
    public class Administrator
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PassHash { get; set; }
    }
}
