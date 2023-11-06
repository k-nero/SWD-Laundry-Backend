using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;
public class Wallet : BaseEntity
{
    public double Balance { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    //public List<Transaction> Transactions { get; set; }
}