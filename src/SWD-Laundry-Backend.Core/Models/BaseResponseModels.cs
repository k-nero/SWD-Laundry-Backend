using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Core.Models;
public class BaseResponseModel<T>
{
    public T? Data { get; set; }
    public object? AdditionalData { get; set; }
    public object EnumData { get; set; } = CoreHelper.GetAllEnums();
    public string? Message { get; set; }
    public int StatusCode { get; set; }

    public BaseResponseModel(int statusCode, T? data, object? additionalData = null)
    {
        this.StatusCode = statusCode;
        this.Data = data;
        this.AdditionalData = additionalData;
    }

    public BaseResponseModel(int statusCode, string? message)
    {
        this.StatusCode = statusCode;
        this.Message = message;
    }
}
