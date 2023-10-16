using StackExchange.Redis;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD_Laundry_Backend.Core.Models;

public class PaymentModel
{
    public string OrderId { get; set; }
    public double Price { get; set; }

}