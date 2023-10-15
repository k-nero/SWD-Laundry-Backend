using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Laundry_Backend.Core.Enum;

public enum LaundryStatus
{
    Pending = 0,
    Received = 1,
    Cleaning = 2,
    Finished = 3,
}