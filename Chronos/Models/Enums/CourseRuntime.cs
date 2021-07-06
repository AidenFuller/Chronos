using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Models.Enums
{
    public enum CourseRuntime
    {
        
        Semester1   = 1 << 0,
        Semester2   = 1 << 1,
        SummerCS    = 1 << 2,
        SummerLS    = 1 << 3,
        Winter      = 1 << 4,
        Trimester1  = 1 << 5,  
        Trimester2  = 1 << 6,
        Trimester3  = 1 << 7
    }
}
