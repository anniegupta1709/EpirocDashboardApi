using EpirocDashboardApi.Data;
using MongoDB.Driver;

namespace EpirocDashboardApi.Services;

public class SimulationService : BackgroundService
{
    private readonly MongoContext _context;

    public SimulationService(MongoContext context)
    {
        _context = context;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var data = await _context.Dashboard
                .Find(x => x.Id == "1")
                .FirstOrDefaultAsync();

            if (data != null)
            {
                // RPM logic (based on speed)
                data.Rpm = data.Speed * 30;

                // Battery logic
                if (data.IsCharging)
                    data.Battery = Math.Min(100, data.Battery + 1);
                else
                    data.Battery = Math.Max(0, data.Battery - 1);

                // Temperature logic
                data.Temperature = 30 + data.Rpm / 100;

                // Power logic
                data.Power = data.Speed * 2;

                await _context.Dashboard.ReplaceOneAsync(
                    x => x.Id == "1",
                    data
                );
            }

            await Task.Delay(2000); // every 2 seconds
        }
    }
}