using SWD_Laundry_Backend.Application.Common.Mappings;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Wallets.Queries;
public class WalletViewModel : IMapFrom<Wallet>
{
    public double Balance { get; set; }
}
