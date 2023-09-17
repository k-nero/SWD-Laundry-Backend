using System.Text.RegularExpressions;

namespace SWD_Laundry_Backend.Domain.Entities.Validation;

public class Validate
{
    
    public bool IsValidStaffRole(string roleName)
    {
        return StaffRole.Contains(roleName);
    }

    public bool IsValidTransactionType(string type)
    {
        return AllowedTransactionType.Contains(type);
    }

    public bool IsValidTransactionStatus(string status)
    {
        return Status.Contains(status);
    }

    public bool IsValidPhone(string phone)
    {
        string pattern = @"^(09|01)\d{8,9}$";
        return Regex.IsMatch(phone, pattern);
    }

    public bool IsValidEmail(string email)
    {
        string pattern = @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
        return Regex.IsMatch(email, pattern);
    }

    public bool IsValidTripStatus(string status)
    {
        return Status.Contains(status);
    }

    public bool IsValidPayment(string payment)
    {
        return Payment.Contains(payment);
    }

    public bool IsValidOrderType(string value)
    {
        return  OrderType.Contains(value);
    }

    //=======================================================
    private readonly string[] OrderType = new string[]
    {
        "ONEWAY","TWOWAY"
    };

    private readonly string[] Payment = new string[]
    {
        "CASH","PAYPAL"
    };
    private readonly string[] Status = new string[]
    {
        "FINISHED","PROCESSING","CANCELLED"
    };


    private readonly string[] StaffRole = new string[]
    {
        "COLLECTOR","RECEIVER"
    };


    private readonly string[] AllowedTransactionType = new string[]
    {
        "DEPOSIT","WITHDRAWAL", "DEBT", "PAID"
    };


}