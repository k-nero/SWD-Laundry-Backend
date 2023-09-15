using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SWD_Laundry_Backend.Infrastructure.Identity;
#nullable disable

public class ApplicationIdentity : IdentityRole
{
    public string Description { get; set; }
}