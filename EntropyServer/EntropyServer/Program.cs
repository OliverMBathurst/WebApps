using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Repositories;
using EntropyServer.Infrastructure.Services.BackgroundServices;
using EntropyServer.Infrastructure.Services.GeneratorServices;
using EntropyServer.Infrastructure.Services.MappingServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntropyServer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureServices(services =>
                {
                    // Services types
                    services
                    .AddSingleton(typeof(IEntropyTypeRepository<>), typeof(EntropyTypeRepository<>))
                    .AddSingleton<IEntropyPoolRepository, EntropyPoolRepository>()
                    .AddSingleton<IEntropyServerBackgroundService, EntropyServerBackgroundService>()
                    .AddSingleton<IHostedService, EntropyServerBackgroundService>()
                    .AddSingleton<IEntropyResultMappingService, EntropyResultMappingService>()

                    // Generator services
                    .AddSingleton<IEntropyGeneratorService<int>, IntEntropyGeneratorService>()
                    .AddSingleton<IEntropyGeneratorService<float>, FloatEntropyGeneratorService>()
                    .AddSingleton<IEntropyGeneratorService<string>, HashEntropyGeneratorService>()

                    // Pool types
                    .AddSingleton(typeof(IEntropyPool<>), typeof(EntropyPool<>))

                    // Mapper types
                    .AddSingleton<IEntropyTypeConfigurationMappingService, EntropyTypeConfigurationMappingService>();
                });
    }
}