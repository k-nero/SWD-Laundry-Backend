using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Core.Models;
public class TransactionModel
{
    public string? PaymentMethod { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
    public WalletModel? Wallet { get; set; } // Name or identifier of the associated wallet
    public AllowedTransactionType TransactionType { get; set; }
}
