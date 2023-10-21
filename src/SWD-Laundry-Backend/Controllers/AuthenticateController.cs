using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Config;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Controllers;

public readonly struct LoginModel
{
    public string? AccessToken { get; init; }
    public string? UserName { get; init; }
    public string? Password { get; init; }
}

public readonly struct RegisterRole
{
    public string Email { get; init; }
    public string Role { get; init; }
}

[ApiController]
public class AuthenticateController : ApiControllerBase
{
    private readonly FirebaseApp _firebaseApp;
    private readonly IIdentityService _identityService;
    private readonly FirebaseAuth _firebaseAuth = FirebaseAuth.DefaultInstance;
    private readonly IWalletService _walletService;

    public AuthenticateController(FirebaseApp firebaseApp, IIdentityService identityService, IWalletService walletService)
    {
        _firebaseApp = firebaseApp;
        _identityService = identityService;
        _walletService = walletService;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Login([FromBody] LoginModel token)
    {

        try
        {
            var decodedToken = await _firebaseAuth.VerifyIdTokenAsync(token.AccessToken);
            var uid = decodedToken.Uid;
            var user = await _firebaseAuth.GetUserAsync(uid);
            var identity = await _identityService.GetUserByUserNameAsync(user.Email);
            object? customToken = null;
            if (identity == null)
            {
                var result = await _identityService.CreateUserAsync(user.Email, CoreHelper.CreateRandomPassword(20));
                identity = await _identityService.GetUserByUserNameAsync(user.Email);
                if(identity != null)
                {
                    if (!result.Result.Errors.IsNullOrEmpty())
                    {
                        return BadRequest(result);
                    }
                    if (!user.PhoneNumber.IsNullOrEmpty())
                    {
                        await _identityService.SetVerifiedPhoneNumberAsync(identity, user.PhoneNumber);
                    }
                    if (!user.DisplayName.IsNullOrEmpty())
                    {
                        await _identityService.SetUserFullNameAsync(identity, user.DisplayName);
                    }
                    var walletId = await _walletService.CreateAsync(new WalletModel
                    {
                        Balance = 0,
                    });
                    await _identityService.SetWalletAsync(identity, walletId);
                }
            }
            if (identity != null)
            {
                customToken = await CreateAccessTokenAsync(identity);
                return Ok(customToken);
            }
            return BadRequest();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> AddToRole([FromBody] RegisterRole reg)
    {
        try
        {
            var user = await _identityService.GetUserByUserNameAsync(reg.Email);
            if (user != null)
            {
                await _identityService.AddToRoleAsync(user, reg.Role);
                return Ok();
            }
            return BadRequest();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //create access token 
    private async Task<object> CreateAccessTokenAsync(ApplicationUser user)
    {
        var userClaims = await _identityService.GetClaimsAsync(user);
        var wallet = await _walletService.GetByIdAsync(user.WalletID);
        var roles = await _identityService.GetRolesAsync(user);
        user.Wallet = wallet;
        var roleClaims = new List<Claim>();
        if(roles != null)
        {
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
        }
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Email", user.Email ?? ""),
                new Claim("UserId", user.Id.ToString()),
                new Claim("FullName", user.Name ?? ""),
                new Claim("WalletBalance", user.Wallet.Balance.ToString()),
                new Claim("PhoneNumber", user.PhoneNumber ?? ""),
                new Claim("AvatarUrl", user.ImageUrl ?? ""),
                new Claim("Username", user.UserName ?? ""),
        }.Union(userClaims).Union(roleClaims);
        var key = SystemSettingModel.Configs["Jwt:SecrectKey"];
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: SystemSettingModel.Configs["Jwt:ValidIssuer"],
            audience: SystemSettingModel.Configs["Jwt:ValidAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(240),
            signingCredentials: signingCredentials);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return new { 
            accesstoken = token,
            role = roles
        };
    }
}
