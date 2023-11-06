using System.Security.Claims;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[TransientDependency(ServiceType = typeof(IIdentityService))]
public class IdentityService : Base_Service.Service, IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);


        return user;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
            CreatedTime = DateTime.Now,
        };

        var result = await _userManager.CreateAsync(user, password);
        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<int> DeleteUserAsync(string userId)
    {
        var row = _userManager.Users.ExecuteUpdate(x => x.SetProperty(x => x.IsDelete, true));

        return row;
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<ApplicationUser?> GetUserByUserNameAsync(string username)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == username);
        return user;
    }

    public async Task SetVerifiedPhoneNumberAsync(ApplicationUser user, string phoneNumber)
    {
        if (user != null)
        {
            await _userManager.SetPhoneNumberAsync(user, phoneNumber);
            user.PhoneNumberConfirmed = true;
            await _userManager.UpdateAsync(user);
        }
        return;
    }

    public async Task<IList<string>?> GetRolesAsync(ApplicationUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public async Task AddToRoleAsync(ApplicationUser user, string role)
    {
        await _userManager.AddToRoleAsync(user, role);
    }

    public async Task SetUserFullNameAsync(ApplicationUser user, string fullName)
    {
        user.Name = fullName;
        await _userManager.UpdateAsync(user);
    }

    public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
    {
        return await _userManager.GetClaimsAsync(user);
    }

    public async Task SetVerfiedEmailAsync(ApplicationUser user, string email)
    {
        await _userManager.SetEmailAsync(user, email);
        user.EmailConfirmed = true;
        await _userManager.UpdateAsync(user);
    }

    public async Task SetUserAvatarUrlAsync(ApplicationUser user, string photoUrl)
    {
        user.ImageUrl = photoUrl;
        await _userManager.UpdateAsync(user);
    }

    public async Task<int> SetWalletAsync(ApplicationUser user, string walletId)
    {
        user.WalletID = walletId;
        var rs = await _userManager.UpdateAsync(user);
        return rs.ToApplicationResult().Succeeded ? 1 : 0;
    }

    public async Task<PaginatedList<ApplicationUser>> GetPaginatedAsync(ApplicationUserQuery query, CancellationToken cancellationToken = default)
    {
        var result = _userManager.Users.AsNoTracking();
        if (query.Email != null)
        {
            result = result.Where(c => c.Email == query.Email
            || c.UserName == query.Email);
        }
        var rs = await result.PaginatedListAsync(query);
        return rs;
    }
}