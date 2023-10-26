using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace SWD_Laundry_Backend.Core.Config;
public class SystemSettingModel
{
    public static SystemSettingModel Instance { get; set; }

    public static IConfiguration Configs { get; set; }
    public string ApplicationName { get; set; } = Assembly.GetEntryAssembly()?.GetName().Name;
    public static SecurityKey? RSAPrivateKey { get; set; }
    public static SecurityKey? RSAPublicKey { get; set; }


    public string? Domain { get; set; }
}
