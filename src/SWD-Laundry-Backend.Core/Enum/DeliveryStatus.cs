using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Laundry_Backend.Core.Enum;
public enum DeliveryStatus
{
    Pending = 0,
    Delivering_Laundry = 1,
    Reached_Laundry = 2,
    Delivering_Customer = 3,
    Reached_Customer = 4,
    Delivered = 5,

}
