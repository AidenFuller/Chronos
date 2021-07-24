using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Models.Enums
{
    public enum AvailableCampus
    {
        Callaghan       = 1 << 0,
        Ourimbah        = 1 << 1,
        PortMacquarie   = 1 << 2,
        Sydney          = 1 << 3,
        SingaporePSB    = 1 << 4,
        SingaporeBCA    = 1 << 5,
        NewcastleCity   = 1 << 6,
        Online          = 1 << 7
    }
}
