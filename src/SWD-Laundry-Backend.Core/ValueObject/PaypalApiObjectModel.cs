namespace SWD_Laundry_Backend.Core.ValueObject;
public class PaypalApiObjectModel
{
    public readonly struct PaypalAccessTokenResponse
    {
        public string? scope { get; init; }
        public string? access_token { get; init; }
        public string? token_type { get; init; }
        public string? app_id { get; init; }
        public int expires_in { get; init; }
        public string? nonce { get; init; }
    }

    public class PaypalOrder
    {

        public readonly struct PaypalOrderResponse
        {
            public string create_time { get; init; }
            public string id { get; init; }
            public string update_time { get; init; }
            public string processing_instruction { get; init; }
            public PaypalLink[] links { get; init; }
            public string intent { get; init; }
            public string status { get; init; }
        }

        public readonly struct PaypalLink
        {
            public string href { get; init; }
            public string rel { get; init; }
            public string method { get; init; }
        }

        public readonly struct PaypalOrderRequest
        {
            public string intent { get; init; }
            public PaypalPurchaseUnitRequest[] purchase_units { get; init; }
        }

        public readonly struct PaypalApplicationContext
        {

        }

        public readonly struct PaypalPurchaseUnitRequest
        {
            public string? reference_id { get; init; }
            public string? description { get; init; }
            public string? custom_id { get; init; }
            public string? invoice_id { get; init; }
            public string? soft_descriptor { get; init; }
            public PaypalItem[]? items { get; init; }
            public PaypalAmountRequest? amount { get; init; }
        }

        public readonly struct PaypalAmountRequest
        {
            public string currency_code { get; init; }
            public string value { get; init; }
            public PaypalAmountBreakdown? breakdown { get; init; }
        }

        public readonly struct Amount
        {
            public string currency_code { get; init; }
            public string value { get; init; }
        }

        public readonly struct PaypalAmountBreakdown
        {
            public Amount? item_total { get; init; }
            public Amount? shipping { get; init; }
            public Amount? handling { get; init; }
            public Amount? tax_total { get; init; }
            public Amount? insurance { get; init; }
            public Amount? shipping_discount { get; init; }
            public Amount? discount { get; init; }
        }

        public readonly struct PaypalItem
        {
            public string name { get; init; }
            public string? sku { get; init; }
            public string quantity { get; init; }
            public string? category { get; init; }
            public string? description { get; init; }
            public Amount unit_amount { get; init; }
            public Amount? tax { get; init; }
        }
    }
}
