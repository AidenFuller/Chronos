using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chronos.Server.Models
{
    public class Administrator
    {
        [Key]
        public Index UserID { get; set; }
        public string Username { get; set; }
        public string PassHash { get; set; }
    }
}
