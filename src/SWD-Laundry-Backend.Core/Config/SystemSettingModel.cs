using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace SWD_Laundry_Backend.Core.Config;
public class SystemSettingModel
{
    public static SystemSettingModel Instance { get; set; }

    public static IConfiguration Configs { get; set; }
    public string ApplicationName { get; set; } = Assembly.GetEntryAssembly()?.GetName().Name;

    public string? Domain { get; set; }
}
