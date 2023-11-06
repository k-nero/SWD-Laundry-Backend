using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using SWD_Laundry_Backend.Core.Constant;
using SWD_Laundry_Backend.Core.ValueObject;
using TimeZoneConverter;

namespace SWD_Laundry_Backend.Core.Utils;
public static class CoreHelper
{
    private static readonly IHttpContextAccessor? _contextAccessor;
    public static HttpContext? CurrentHttpContext => Current;

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

    public static string ToSentenceCase(this string str)
    {
        return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
    }

    public static Dictionary<string, EnumObject[]> GetAllEnums()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsEnum)
            .ToDictionary(t => t.Name, t =>
                System.Enum.GetNames(t)
                    .Zip(System.Enum.GetValues(t).Cast<int>(), (key, value) => new EnumObject(key, value, ToSentenceCase(key))).ToArray());
    }

    public static string CreateRandomPassword(int passwordLength)
    {
        string allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ!@#$%^&*()-_=+<,>.";
        var randNum = new Random();
        char[] chars = new char[passwordLength];
        for (int i = 0; i < passwordLength; i++)
        {
            chars[i] = allowedChars[(int)((allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }

    public static string ObjecToQueryString(object obj)
    {
        var objType = obj.GetType();
        var properties = objType.GetProperties();
        var queryString = string.Empty;
        foreach (var property in properties)
        {
            var value = property.GetValue(obj, null);
            if (value != null)
            {
                queryString += $"{property.Name}={value}&";
            }
        }
        queryString = queryString.TrimEnd('&');
        return queryString;
    }
}
