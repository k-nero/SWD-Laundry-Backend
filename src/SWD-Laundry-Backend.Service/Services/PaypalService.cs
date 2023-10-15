using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Invedia.DI.Attributes;
using Newtonsoft.Json;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Config;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.ValueObject;

namespace SWD_Laundry_Backend.Service.Services;
[ScopedDependency(ServiceType = typeof(IPaypalService))]
public class PaypalService : IPaypalService
{
    public Task<object> CapturePaypalOrderAsync(string orderId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaypalApiObjectModel.PaypalOrder.PaypalOrderResponse> CreatePaypalOrderAsync(TransactionModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private async Task<PaypalApiObjectModel.PaypalAccessTokenResponse?> GetAccessToken()
    {
        const SecurityProtocolType Tls13 = (SecurityProtocolType)12288;
        ServicePointManager.SecurityProtocol = Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        string? client_id = SystemSettingModel.Configs["Paypal:PAYPAL_CLIENT_ID"];
        string? client_secret = SystemSettingModel.Configs["Paypal:PAYPAL_CLIENT_SECRET"];
        if (client_id != null && client_secret != null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Accept-Language", "en_US");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{client_id}:{client_secret}")));
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string?, string?>("grant_type", "client_credentials")
            });
            var response = await client.PostAsync("https://api.sandbox.paypal.com/v1/oauth2/token", formContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaypalApiObjectModel.PaypalAccessTokenResponse>(responseString);
            return result;
        }
        return null;
    }
}
