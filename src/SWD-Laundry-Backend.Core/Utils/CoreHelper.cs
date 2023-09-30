using Microsoft.AspNetCore.Http;
using SWD_Laundry_Backend.Core.Constant;
using TimeZoneConverter;

namespace SWD_Laundry_Backend.Core.Utils;
public static class CoreHelper
{
    private static IHttpContextAccessor? _contextAccessor;
    public static HttpContext CurrentHttpContext => Current;

    public static TimeZoneInfo SystemTimeZoneInfo => GetTimeZoneInfo(Formattings.TimeZone);

    public static DateTimeOffset SystemTimeNow => DateTimeOffset.UtcNow;

    public static DateTime UtcToSystemTime(this DateTimeOffset dateTimeOffsetUtc)
    {
        return dateTimeOffsetUtc.UtcDateTime.UtcToSystemTime();
    }

    public static DateTime UtcToSystemTime(this DateTime dateTimeUtc)
    {
        var dateTimeWithTimeZone = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, SystemTimeZoneInfo);

        return dateTimeWithTimeZone;
    }
    public static TimeZoneInfo GetTimeZoneInfo(string timeZoneId)
    {
        return TZConvert.GetTimeZoneInfo(timeZoneId);
    }

    public static HttpContext? Current => _contextAccessor?.HttpContext;
}
