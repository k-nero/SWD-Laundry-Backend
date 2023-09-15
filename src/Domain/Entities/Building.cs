using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Building : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
}