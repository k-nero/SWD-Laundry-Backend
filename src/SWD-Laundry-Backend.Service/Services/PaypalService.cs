using System.Net;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;
using Invedia.DI.Attributes;
using Newtonsoft.Json;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Config;
using SWD_Laundry_Backend.Core.Models;
using static SWD_Laundry_Backend.Core.ValueObject.PaypalApiObjectModel;
using static SWD_Laundry_Backend.Core.ValueObject.PaypalApiObjectModel.PaypalOrder;

namespace SWD_Laundry_Backend.Service.Services;
[ScopedDependency(ServiceType = typeof(IPaypalService))]
public class PaypalService : IPaypalService
{
    private readonly ITransactionService _transactionService;
    private readonly IWalletService _walletService;
    private readonly IMapper _mapper;
    public PaypalService(ITransactionService transactionService, IWalletService walletService, IMapper mapper)
    {
        _transactionService = transactionService;
        _walletService = walletService;
        _mapper = mapper;
    }

    public async Task<object?> CapturePaypalOrderAsync(string orderId, CancellationToken cancellationToken = default)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        string? paypal_api_url = SystemSettingModel.Configs["Paypal:paypal_api"];
        paypal_api_url += "/v2/checkout/orders/" + orderId + "/capture";
        var access_token = await GetAccessToken();
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Accept-Language", "en_US");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token.Value.access_token);
        var response = await client.PostAsync(paypal_api_url, new StringContent("", Encoding.UTF8, "application/json"), cancellationToken);

        Transaction? transaction;
        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = JsonConvert.DeserializeObject<PaypalOrderCaptureResponse>(responseString);

            var transactionId = result.purchase_units[0].reference_id;
            if(transactionId != null)
            {
                transaction = await _transactionService.GetByIdAsync(transactionId, cancellationToken);
                TransactionModel transactionModel;
                if(transaction != null && result.status == "COMPLETED")
                {
                    if(transaction.TransactionType == Core.Enum.AllowedTransactionType.Deposit && transaction.WalletID != null)
                    {
                        var wallet = await _walletService.GetByIdAsync(transaction.WalletID, cancellationToken);
                        if(wallet != null)
                        {
                            var newBalance = wallet.Balance + transaction.Amount;
                            await _walletService.UpdateAsync(transaction.WalletID, new WalletModel() { Balance = newBalance } , cancellationToken);
                            transactionModel = _mapper.Map<TransactionModel>(transaction);
                            transactionModel.Status = Core.Enum.TransactionStatus.Success;
                            await _transactionService.UpdateAsync(transactionId, transactionModel, cancellationToken);
                            return result;
                        }
                    }
                }
                transactionModel = _mapper.Map<TransactionModel>(transaction);
                transactionModel.Status = Core.Enum.TransactionStatus.Failed;
                await _transactionService.UpdateAsync(transactionId, transactionModel, cancellationToken);
            }
        }
        
        return null;
    }

    public async Task<PaypalOrderResponse> CreatePaypalOrderAsync(TransactionModel model, CancellationToken cancellationToken = default)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        string? paypal_api_url = SystemSettingModel.Configs["Paypal:paypal_api"];
        paypal_api_url += "/v2/checkout/orders";
        var access_token = await GetAccessToken();
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Accept-Language", "en_US");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token.Value.access_token);
        model.Status = Core.Enum.TransactionStatus.Pending;
        model.PaymentType = Core.Enum.PaymentType.Paypal;
        model.TransactionType = Core.Enum.AllowedTransactionType.Deposit;
        var transId = await _transactionService.CreateAsync(model, cancellationToken);

        var order = new PaypalOrderRequest()
        {
            intent = "CAPTURE",
            purchase_units = new List<PaypalPurchaseUnit>()
            {
                new PaypalPurchaseUnit()
                {
                    amount = new PaypalAmountRequest()
                    {
                        currency_code = "VND",
                        value = model.Amount.ToString()
                    },
                    reference_id = transId,
                    description = "Deposit money to wallet"
                }
            }.ToArray()
        };

        var response = await client.PostAsync(paypal_api_url, new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json"), cancellationToken);

        var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<PaypalOrderResponse>(responseString);
        if (result.id == null)
        {
            throw new Exception("There is something wrong, cannot create order. Paypal URL: " + paypal_api_url);
        }
        return result;
    }

    private static async Task<PaypalAccessTokenResponse?> GetAccessToken()
    {
        const SecurityProtocolType tls13 = (SecurityProtocolType)12288;
        ServicePointManager.SecurityProtocol = tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        string? client_id = SystemSettingModel.Configs["Paypal:paypal_client_id"];
        string? client_secret = SystemSettingModel.Configs["Paypal:paypal_client_secret"];
        string? paypal_api_url = SystemSettingModel.Configs["Paypal:paypal_api"];
        paypal_api_url += "/v1/oauth2/token";
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
            var response = await client.PostAsync(paypal_api_url, formContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaypalAccessTokenResponse>(responseString);
            if(result.access_token == null)
            {
                throw new Exception("There is something wrong, cannot get access token. ClientId " + client_id + " - ClientSecret: " + client_secret + " - Paypal URL: " + paypal_api_url);
            }
            return result;
        }
        return null;
    }
}
