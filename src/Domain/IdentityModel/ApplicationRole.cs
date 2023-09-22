using Microsoft.AspNetCore.Identity;

namespace SWD_Laundry_Backend.Domain.IdentityModel;


public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }
}