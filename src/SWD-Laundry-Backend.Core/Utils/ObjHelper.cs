﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SWD_Laundry_Backend.Core.Utils;
public class ObjHelper
{
    public static string ToJsonString(object obj)
    {
        JObject? jObject = obj as JObject;
        if (jObject != null)
        {
            return jObject.ToString(Formatting.Indented);
        }

        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }

    public static T? Clone<T>(T obj)
    {
        if (obj == null)
        {
            return default(T);
        }

        string value = JsonConvert.SerializeObject(obj);
        return JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings
        {
            ObjectCreationHandling = ObjectCreationHandling.Replace
        });
    }

    public static T? ConvertTo<T>(object obj)
    {
        if (obj != null)
        {
            if (obj is T)
            {
                return (T)obj;
            }

            Type typeFromHandle = typeof(T);
            Type? underlyingType = Nullable.GetUnderlyingType(typeFromHandle);
            if (underlyingType != null)
            {
                if (underlyingType == typeof(string))
                {
                    return (T)(object)obj.ToString();
                }

                return (T)Convert.ChangeType(obj, underlyingType);
            }

            if (typeFromHandle == typeof(string))
            {
                return (T)(object)obj.ToString();
            }

            if (typeFromHandle.IsPrimitive)
            {
                return (T)Convert.ChangeType(obj.ToString(), typeFromHandle);
            }

            return (T)Convert.ChangeType(obj, typeFromHandle);
        }

        return default(T);
    }

    public static bool TryConvertTo<T>(object obj, T defaultValue, out T value)
    {
        try
        {
            value = ConvertTo<T>(obj);
            return true;
        }
        catch
        {
            value = ((defaultValue == null) ? default(T) : defaultValue);
            return false;
        }
    }

    public static T? WithoutRefLoop<T>(T obj)
    {
        if (obj == null)
        {
            return default(T);
        }

        string value = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        return JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings
        {
            ObjectCreationHandling = ObjectCreationHandling.Replace
        });
    }

    public static T ReplaceNullOrDefault<T>(T value, T newValue)
    {
        if (value == null)
        {
            value = newValue;
        }
        else if (value.Equals(default(T)))
        {
            value = newValue;
        }

        return value;
    }

}
