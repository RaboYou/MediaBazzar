using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.ShiftCheckers
{
    enum ConstraintType
    {
        Success = 0x0000,
        MaxAmount = 0x0001,
        MaxHours = 0x0010,
        DailyLimit = 0x0100,
        AlreadyAssigned = 0x1000
    }
}
