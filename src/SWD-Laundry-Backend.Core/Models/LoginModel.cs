namespace SWD_Laundry_Backend.Core.Models;
public readonly struct LoginModel
{
    public string? AccessToken { get; init; }
    public string? UserName { get; init; }
    public string? Password { get; init; }
}