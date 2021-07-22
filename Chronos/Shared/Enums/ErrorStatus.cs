using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Shared.Enums
{
    public enum ErrorStatus
    {
        MissingAssumedKnowledge = 1 << 0,
        MissingPrerequisite     = 1 << 1,
        WrongCampus             = 1 << 2,
        WrongSemester           = 1 << 3,
        MissingSiblingCourse    = 1 << 4
    }
}
