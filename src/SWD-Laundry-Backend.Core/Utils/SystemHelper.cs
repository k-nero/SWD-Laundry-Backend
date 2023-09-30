using Microsoft.Extensions.Configuration;
using SWD_Laundry_Backend.Core.Config;

namespace SWD_Laundry_Backend.Core.Utils;
public class SystemHelper
{
    public static SystemSettingModel Setting => SystemSettingModel.Instance;
    public static IConfiguration Configs => SystemSettingModel.Configs;
    public static string? AppDb => SystemSettingModel.Configs.GetConnectionString("DefaultConnection");
}
