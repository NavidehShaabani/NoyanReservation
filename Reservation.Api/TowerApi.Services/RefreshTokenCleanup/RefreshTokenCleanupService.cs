using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TowerApi.Repositories.RefreshTokens;

namespace TowerApi.Services.RefreshTokenCleanup
{
    public class RefreshTokenCleanupService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<RefreshTokenCleanupService> _logger;

        public RefreshTokenCleanupService(
            IServiceScopeFactory scopeFactory,
            ILogger<RefreshTokenCleanupService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            // اجرای اولیه پس از شروع برنامه
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();

                    var repository = scope.ServiceProvider
                        .GetRequiredService<IRefreshTokenRepository>();

                    await repository.CleanupExpiredAsync();

                    _logger.LogInformation("Refresh token cleanup completed." );
                }
                catch (OperationCanceledException)
                    when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Refresh token cleanup failed.");
                }

                try
                {
                    await Task.Delay(
                        TimeSpan.FromHours(24),
                        stoppingToken);
                }
                catch (OperationCanceledException)
                    when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
            }
        }
    }
}
