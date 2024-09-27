using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class CarBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public CarBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var carService = scope.ServiceProvider.GetRequiredService<CarService>();

                try
                {
                    // Fetch and update cars
                    await carService.FetchAndStoreCarsAsync();
                }
                catch (Exception ex)
                {
                    // Log the error (you can add logging here)
                }
            }

            // Wait for 1 hour before the next run
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
