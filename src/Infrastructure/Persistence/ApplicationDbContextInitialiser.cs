using SWD_Laundry_Backend.Domain.Entities;
using SWD_Laundry_Backend.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        {
            // Roles
            var roles = new List<IdentityRole>
        {
            new IdentityRole("Customer"),
            new IdentityRole("Staff"),
            new IdentityRole("Store"),
            new IdentityRole("Admin")
        };

            foreach (var role in roles)
            {

                if (_roleManager.Roles.All(r => r.Name != role.Name))
                {
                    await _roleManager.CreateAsync(role);
                }
            }

            // Manager
            var administrator = new ApplicationUser
            {
                UserName = "@dmin",
                Email = "administrator@localhost",

            };

            if (_userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await _userManager.CreateAsync(administrator, "Aa123@");

                var administratorRole = roles.FirstOrDefault(r => r.Name == "Admin");
                if (administratorRole != null)
                {
                    await _userManager.AddToRoleAsync(administrator, administratorRole.Name);
                }

            }

            // Default data
            // Seed, if necessary
            if (!_context.TodoLists.Any())
            {
                _context.TodoLists.Add(new TodoList
                {
                    Title = "Todo List",
                    Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}