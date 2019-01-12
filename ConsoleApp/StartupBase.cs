using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    public abstract class StartupBase
    {
        public void Run()
        {
            BuildHost()
                .Run();
        }

        private IHost BuildHost()
        {
            var host = new HostBuilder()
               .ConfigureLogging((hostContext, configLogging) =>
               {
                   configLogging.AddConsole();
                   configLogging.AddDebug();
               })
               .ConfigureServices((hostContext, services) =>
               {
                   ConfigureServices(services);
               })
               .UseConsoleLifetime()
               .Build();

            return host;
        }

        public abstract void ConfigureServices(IServiceCollection services);
    }
}