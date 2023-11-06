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
            public DateTime? create_time { get; init; }
            public string id { get; init; }
            public DateTime? update_time { get; init; }
            public string processing_instruction { get; init; }
            public PaypalLink[] links { get; init; }
            public string intent { get; init; }
            public string status { get; init; }
        }

        public readonly struct PaypalOrderCaptureResponse
        {
            public string id { get; init; }
            public PaymentSource? payment_source { get; init; }
            public string status { get; init; }
            public DateTime? create_time { get; init; }
            public DateTime? update_time { get; init; }
            public PaypalLink[] links { get; init; }
            public PaypalPayer? payer { get; init; }
            public PaypalPurchaseUnit[] purchase_units { get; init; }
        }

        public readonly struct ShippingDetail
        {
            public PayerName name { get; init; }
            public string type { get; init; }
            public PayerAdress address { get; init; }

        }

        public readonly struct PaymentSource
        {
            public PaymentSourcePaypal? paypal { get; init; }
        }

        public readonly struct PaypalPayer
        {
            public string email_address { get; init; }
            public string payer_id { get; init; }
            public PayerAdress address { get; init; }
            public PayerName name { get; init; }
        }

        public readonly struct PayerAdress
        {
            public string address_line_1 { get; init; }
            public string address_line_2 { get; init; }
            public string admin_area_2 { get; init; }
            public string admin_area_1 { get; init; }
            public string postal_code { get; init; }
            public string country_code { get; init; }
        }

        public readonly struct PayerName
        {
            public string given_name { get; init; }
            public string surname { get; init; }
            public string? full_name { get; init; }
        }

        public readonly struct PaypalLink
        {
            public string href { get; init; }
            public string rel { get; init; }
            public string method { get; init; }
        }

        /// <summary>
        /// Create order request body
        /// </summary>
        public readonly struct PaypalOrderRequest
        {
            public string intent { get; init; }
            public PaypalPurchaseUnit[] purchase_units { get; init; }
            public PaypalPaymentSource? payment_source { get; init; }
        }

        public readonly struct PaypalPaymentSource
        {
           public PaymentSourcePaypal? paypal { get; init; }
        }

        public readonly struct PaymentSourcePaypal
        {
            public PaypalExperienceContext? experience_context { get; init; }
            public string? billing_agreement_id { get; init; }
            public string? vault_id { get; init; }
            public string? email_address { get; init; }
            public string? account_id { get; init; }
            public string? account_status { get; init; }
            public PayerAdress? address { get; init; }

        }

        public readonly struct PaypalExperienceContext
        {
            public string? brand_name { get; init; }
            public string? shipping_preference { get; init; }
            public string? landing_page { get; init; }
            public string? user_action { get; init; }
            public string? return_url { get; init; }
            public string? cancel_url { get; init; }
            public string? payment_method_preference { get; init; }
            public string? locale { get; init; }
        }

        public readonly struct PaypalPurchaseUnit
        {
            public string? reference_id { get; init; }
            public string? description { get; init; }
            public string? custom_id { get; init; }
            public string? invoice_id { get; init; }
            public string? soft_descriptor { get; init; }
            public PaypalItem[]? items { get; init; }
            public PaypalAmountRequest amount { get; init; }
            public ShippingDetail? shipping { get; init; }
            public Payment? payments { get; init; }
        }

        public readonly struct Payment
        {
            public object[]? authorizations { get; init; }
            public object[]? refunds { get; init; }
            public Capture[]? captures { get; init; }

        }

        public readonly struct Capture
        {
            public string status { get; init; }
            public object? status_details { get; init; }
            public string id { get; init; }
            public string? invoice_id { get; init; }
            public string? custom { get; init; }
            public bool? final_capture { get; init; }
            public string? disbursement_mode { get; init; }
            public PaypalLink[]? links { get; init; }
            public Amount? amount { get; init; }
            public DateTime? create_time { get; init; }
            public DateTime? update_time { get; init; }
            public PaypalSellerProtection? seller_protection { get; init; }
            public PaypalSellerReceivableBreakdown? seller_receivable_breakdown { get; init; }
            public object? processor_response { get; init; }
        }

        public readonly struct PaypalSellerReceivableBreakdown
        {
            public Amount? gross_amount { get; init; }
            public Amount? paypal_fee { get; init; }
            public Amount? net_amount { get; init; }
            public Amount? total_refunded_amount { get; init; }
            public Amount? total_charged_back_amount { get; init; }
        }

        public readonly struct PaypalSellerProtection
        {
            public string? status { get; init; }
            public string[]? dispute_categories { get; init; }
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
