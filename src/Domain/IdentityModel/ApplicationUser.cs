using Microsoft.AspNetCore.Identity;
namespace SWD_Laundry_Backend.Domain.IdentityModel;

public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
}