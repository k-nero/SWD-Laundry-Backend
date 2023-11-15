namespace SWD_Laundry_Backend.Contract.Service.Interface;
public interface ICancelTransactionService
{
    Task DoWork(CancellationToken stoppingToken);
}
