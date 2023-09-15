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
        return TransactionStatus.Contains(status);
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
        return TripStatus.Contains(status);
    }

    public bool IsValidPayment(string payment)
    {
        return Payment.Contains(payment);
    }
    //=======================================================
    public string[] Payment = new string[]
    {
        "Cash","Paypal"
    };
    public string[] TripStatus = new string[]
    {
        "Finished","Processing","Cancelled"
    };


    public string[] StaffRole = new string[]
    {
        "Collector","Receiver"
    };


    public string[] AllowedTransactionType = new string[]
    {
        "Deposit","Withdrawal", "Debt", "Paid"
    };

    public string[] TransactionStatus = new string[]
    {
        "Success","Processing","Fail"
    };
}