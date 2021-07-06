using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Models.Enums
{
    public enum CourseRuntime
    {
        Semester1   = 0b_0000_0001,
        Semester2   = 0b_0000_0001,
        SummerCS    = 0b_0000_0001,
        SummerLS    = 0b_0000_0001,
        Winter      = 0b_0000_0001,
        Trimester1  = 0b_0000_0001,  
        Trimester2  = 0b_0000_0001,
        Trimester3  = 0b_0000_0001
    }
}
