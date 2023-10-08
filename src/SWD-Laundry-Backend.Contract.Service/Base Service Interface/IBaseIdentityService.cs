using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;
using SWD_Laundry_Backend.Core.Models.Common;

namespace SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
public interface IBaseIdentityService
{
    Task<string?> GetUserNameAsync(string userId);
    Task<ApplicationUser?> GetUserByUserNameAsync(string username);


    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
}
