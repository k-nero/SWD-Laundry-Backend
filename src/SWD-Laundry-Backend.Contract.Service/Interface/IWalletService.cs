using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IWalletService :
    ICreateAble<WalletModel, string>,
    IGetAble<Wallet, string>,
    IDeleteAble<string>,
    IUpdateAble<WalletModel, string>
{
}
