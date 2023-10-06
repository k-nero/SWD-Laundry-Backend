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
                    .Zip(System.Enum.GetValues(t).Cast<int>(), (Key, Value) => new EnumObject(Key, Value, ToSentenceCase(Key))).ToArray());
    }

    public static string CreateRandomPassword(int PasswordLength)
    {
        string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ!@#$%^&*()-_=+<,>.";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }
}
