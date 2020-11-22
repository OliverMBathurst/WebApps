using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
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
                    .AddSingleton<IEntropyService<int>, IntEntropyService>()
                    .AddSingleton<IEntropyGenerator<int>, IntEntropyGenerator>()
                    .AddSingleton<IEntropyResultService, EntropyResultService>()
                    .AddSingleton<IEntropyServerBackgroundService, EntropyServerBackgroundService>()
                    .AddSingleton<IHostedService, EntropyServerBackgroundService>()
                    .AddSingleton<IEntropyPool, EntropyPool>()
                    .AddSingleton<IEntropyConfigurationMapper, EntropyConfigurationMapper>()


                    //result types
                    .AddScoped<IEntropyResult<int>, IntEntropyResult>();
                });
    }
}