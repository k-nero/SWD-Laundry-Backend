namespace SWD_Laundry_Backend.Core.Models;
public class BaseResponseModel<T>
{
    public T? Data { get; set; }
    public object? AdditionalData { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public string Code { get; set; }

    public BaseResponseModel(int statusCode, string code, T? data, object? additionalData = null)
    {
        this.StatusCode = statusCode;
        this.Code = code;
        this.Data = data;
        this.AdditionalData = additionalData;
    }

    public BaseResponseModel(int statusCode, string code, string? message)
    {
        this.StatusCode = statusCode;
        this.Code = code;
        this.Message = message;
    }
}
