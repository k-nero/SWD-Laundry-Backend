using Invedia.DI.Attributes;
using Serilog;
using SWD_Laundry_Backend.Contract.Service.Interface;

namespace SWD_Laundry_Backend.Service.Services;
[ScopedDependency(ServiceType = typeof(ICancelTransactionService))]
public class CancelTransactionService : ICancelTransactionService
{
    private readonly ITransactionService _transactionService;
    private readonly ILogger _logger;

    public CancelTransactionService(ITransactionService transactionService, ILogger logger)
    {
        _transactionService = transactionService;
        _logger = logger;
    }
    
    public async Task DoWork(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await _transactionService.CancelTransactionAsync(cancellationToken);
            _logger.Information("Cancel transaction service is running");
            await Task.Delay(TimeSpan.FromHours(24), cancellationToken);
        }
    }
}
