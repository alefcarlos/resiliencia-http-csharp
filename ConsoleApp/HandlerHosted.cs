using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class HandlerHosted : IHostedService
    {
        private readonly IServiceProvider _provider;

        private readonly ILogger _logger;
        public HandlerHosted(ILogger<HandlerHosted> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            await DoSuccessAsync();

            await DoTimeoutAsync();


            await DoErrorAsync(500, 3);
            await DoErrorAsync(401, 2);
            await DoErrorAsync(404, 2);

            //Esse nunca irá completar, pois o número de tentativas com sucesso é 10. E cofiguramos no máximo 3 retentativas.
            await DoErrorAsync(500, 10);

            // return Task.CompletedTask;
        }

        private async Task DoSuccessAsync()
        {
            var apiService = _provider.GetService<ApiService>();

            _logger.LogInformation("Realizando chamada respondendo sucesso...");

            await apiService.SuccessAsync();
            _logger.LogInformation("Chamado respondendo sucesso... OK");
        }

        private async Task DoTimeoutAsync()
        {
            var apiService = _provider.GetService<ApiService>();

            _logger.LogInformation("Realizando chamada respondendo timeout de 10 segundos e respondendo com sucesso na 2 tentativa...");
            await apiService.TimeoutAsync(10, 2);
            _logger.LogInformation("Chamado respondendo timeout... OK");

        }

        private async Task DoErrorAsync(int errorCode, int success)
        {
            var apiService = _provider.GetService<ApiService>();

            _logger.LogInformation($"Realizando chamada respondendo erro com o status {errorCode} e respondendo com sucesso na {success} tentativa...");
            await apiService.ErrorAsync(errorCode, success);
            _logger.LogInformation("Chamado respondendo error... OK");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}