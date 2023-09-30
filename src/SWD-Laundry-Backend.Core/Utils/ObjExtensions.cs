using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Laundry_Backend.Core.Utils;
public static class ObjExtensions
{
    public static string ToJsonString(this object obj)
    {
        return ObjHelper.ToJsonString(obj);
    }

    public static T Clone<T>(this T obj)
    {
        return ObjHelper.Clone(obj);
    }

    public static T ConvertTo<T>(this object obj)
    {
        return ObjHelper.ConvertTo<T>(obj);
    }

    public static T WithoutRefLoop<T>(this T obj)
    {
        return ObjHelper.WithoutRefLoop(obj);
    }
}