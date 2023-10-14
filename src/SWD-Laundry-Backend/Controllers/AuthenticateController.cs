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
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Controllers;

public readonly struct Token
{
    public string AccessToken { get; init; }
}

[ApiController]
public class AuthenticateController : ApiControllerBase
{
    private readonly FirebaseApp _firebaseApp;
    private readonly IIdentityService _identityService;
    private readonly FirebaseAuth _firebaseAuth = FirebaseAuth.DefaultInstance;

    public AuthenticateController(FirebaseApp firebaseApp, IIdentityService identityService)
    {
        _firebaseApp = firebaseApp;
        _identityService = identityService;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Login([FromBody] Token token)
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

    //create access token 
    private async Task<object> CreateAccessTokenAsync(ApplicationUser user)
    {
        var userClaims = await _identityService.GetClaimsAsync(user);
        var roles = await _identityService.GetRolesAsync(user);
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
                new Claim("id", user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("04edf27f-5a6c-475c-bd8e-d522473ed5d5"));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: "https://ec2-13-212-24-193.ap-southeast-1.compute.amazonaws.com",
            audience: "None",
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
