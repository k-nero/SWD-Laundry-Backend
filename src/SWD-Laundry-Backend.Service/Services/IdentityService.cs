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
public class IdentityService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, IAuthorizationService authorizationService) : Base_Service.Service, IIdentityService
{
    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        var user = await userManager.Users.FirstAsync(u => u.Id == userId);


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

        var result = await userManager.CreateAsync(user, password);
        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await userClaimsPrincipalFactory.CreateAsync(user);

        var result = await authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<int> DeleteUserAsync(string userId)
    {
        var row = userManager.Users.ExecuteUpdate(x => x.SetProperty(x => x.IsDelete, true));

        return row;
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<ApplicationUser?> GetUserByUserNameAsync(string username)
    {
        var user = await userManager.Users.SingleOrDefaultAsync(u => u.UserName == username);
        return user;
    }

    public async Task SetVerifiedPhoneNumberAsync(ApplicationUser user, string phoneNumber)
    {
        if (user != null)
        {
            await userManager.SetPhoneNumberAsync(user, phoneNumber);
            user.PhoneNumberConfirmed = true;
            await userManager.UpdateAsync(user);
        }
        return;
    }

    public async Task<IList<string>?> GetRolesAsync(ApplicationUser user)
    {
        return await userManager.GetRolesAsync(user);
    }

    public async Task AddToRoleAsync(ApplicationUser user, string role)
    {
        await userManager.AddToRoleAsync(user, role);
    }

    public async Task SetUserFullNameAsync(ApplicationUser user, string fullName)
    {
        user.Name = fullName;
        await userManager.UpdateAsync(user);
    }

    public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
    {
        return await userManager.GetClaimsAsync(user);
    }

    public async Task SetVerfiedEmailAsync(ApplicationUser user, string email)
    {
        await userManager.SetEmailAsync(user, email);
        user.EmailConfirmed = true;
        await userManager.UpdateAsync(user);
    }

    public async Task SetUserAvatarUrlAsync(ApplicationUser user, string photoUrl)
    {
        user.ImageUrl = photoUrl;
        await userManager.UpdateAsync(user);
    }

    public async Task<int> SetWalletAsync(ApplicationUser user, string walletId)
    {
        user.WalletID = walletId;
        var rs = await userManager.UpdateAsync(user);
        return rs.ToApplicationResult().Succeeded ? 1 : 0;
    }

    public async Task<PaginatedList<ApplicationUser>> GetPaginatedAsync(ApplicationUserQuery query, CancellationToken cancellationToken = default)
    {
        var result = userManager.Users.AsNoTracking();
        if (query.Email != null)
        {
            result = result.Where(c => c.Email == query.Email
            || c.UserName == query.Email);
        }
        var rs = await result.PaginatedListAsync(query);
        return rs;
    }
}