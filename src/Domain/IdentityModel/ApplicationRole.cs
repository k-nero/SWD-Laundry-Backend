using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SWD_Laundry_Backend.Domain.IdentityModel;


public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }
}