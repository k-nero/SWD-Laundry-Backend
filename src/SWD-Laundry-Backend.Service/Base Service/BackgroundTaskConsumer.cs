using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SWD_Laundry_Backend.Contract.Service.Interface;

namespace SWD_Laundry_Backend.Service.Base_Service;
public class BackgroundTaskConsumer : BackgroundService
{
    private IServiceProvider Services { get; }

    public BackgroundTaskConsumer(IServiceProvider service)
    {
        Services = service;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {

        using var scope = Services.CreateScope();
        var scopedProcessingService = scope.ServiceProvider.GetRequiredService<ICancelTransactionService>();
        await scopedProcessingService.DoWork(stoppingToken);
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await base.StopAsync(stoppingToken);
    }
}
