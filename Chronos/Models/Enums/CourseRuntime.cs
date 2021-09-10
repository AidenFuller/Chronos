using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Models.Enums
{
    [Flags]
    public enum CourseRuntime
    {
        Semester1   = 1 << 0,
        Semester2   = 1 << 1
    }
}
