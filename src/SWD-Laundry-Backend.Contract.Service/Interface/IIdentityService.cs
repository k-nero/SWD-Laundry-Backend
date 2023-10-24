using System.Security.Claims;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;

namespace SWD_Laundry_Backend.Contract.Service.Interface;
public interface IIdentityService : IBaseIdentityService
{
    public Task SetVerifiedPhoneNumberAsync(ApplicationUser user, string phoneNumber);
    public Task<IList<string>?>  GetRolesAsync(ApplicationUser user);
    public ApplicationUser GetUserByIdAsync(string userId);

    public Task AddToRoleAsync(ApplicationUser user, string role);

    public Task SetUserFullNameAsync(ApplicationUser user, string fullName);

    public Task<IList<Claim>> GetClaimsAsync(ApplicationUser user);
    public Task SetVerfiedEmailAsync(ApplicationUser user, string email);
    public Task<int> SetWalletAsync(ApplicationUser user, string walletId);
    public Task SetUserAvatarUrlAsync(ApplicationUser identity, string photoUrl);
}
