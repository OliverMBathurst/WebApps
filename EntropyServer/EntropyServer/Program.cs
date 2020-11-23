using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.Repositories;
using EntropyServer.Domain.Result;
using EntropyServer.Infrastructure.Data;
using EntropyServer.Infrastructure.Generators;
using EntropyServer.Infrastructure.Mappers;
using EntropyServer.Infrastructure.Services;
using EntropyServer.Infrastructure.Services.EntropyServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntropyServer
{
    public class Program
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
                    services.AddSingleton<IEntropyData<int>, IntEntropyData>()

                    .AddSingleton<IEntropyTypeResultService<int>, IntEntropyTypeResultService>()
                    .AddSingleton<IEntropyTypeGeneratorService<int>, IntEntropyGeneratorService>()

                    .AddSingleton<IEntropyTypeServiceRepository<int>, IntEntropyTypeServiceRepository>()


                    .AddSingleton<IEntropyServerBackgroundService, EntropyServerBackgroundService>()
                    .AddSingleton<IHostedService, EntropyServerBackgroundService>()
                    .AddSingleton<IEntropyPool, EntropyPool>()
                    .AddSingleton<IEntropyTypeConfigurationMapper, EntropyTypeConfigurationMapper>()
                    .AddSingleton<IEntropyResultService, EntropyResultService>()

                    //result types
                    .AddScoped<IEntropyGenerationResult<int>, IntEntropyGenerationResult>();
                });
    }
}