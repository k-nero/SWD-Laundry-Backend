﻿using System.Globalization;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SWD_Laundry_Backend.Core.Constant;

public static class Formattings
{
    public const string DateTimeOffSetFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

    public const string TimeZone = "Asia/Ho_Chi_Minh"; // "UTC"

    public const string DateFormat = "dd/MM/yyyy";

    public const string TimeFormat = "h:mm:ss tt";

    public const string DateTimeFormat = "dd/MM/yyyy hh:mm:ss tt";

    public const string JsDateFormat = "dd/mm/yyyy";

    public const string JsDateTimeFormat = "dd/mm/yyyy HH:ii:ss P";

    public static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        Formatting = Newtonsoft.Json.Formatting.None,
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        DateFormatHandling = DateFormatHandling.IsoDateFormat,
        DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK",
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Culture = CultureInfo.CurrentCulture
    };
}
