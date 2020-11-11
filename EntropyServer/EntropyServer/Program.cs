using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.Result;
using EntropyServer.Domain.TypeDefinitions;
using EntropyServer.Infrastructure.Data;
using EntropyServer.Infrastructure.Generators;
using EntropyServer.Infrastructure.Mappers;
using EntropyServer.Infrastructure.Repositories;
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
                    services
                    .AddSingleton<IEntropyData<int>, IntEntropyData>()

                    .AddSingleton<IEntropyTypeDefinition<int>, IntEntropyTypeDefinition>()
                    .AddSingleton<IEntropyTypeDefinition<float>, FloatEntropyTypeDefinition>()
                    .AddSingleton<IEntropyTypeDefinition<string>, HashEntropyTypeDefinition>()
                    .AddSingleton<IEntropyService<int>, IntEntropyService>()
                    .AddSingleton<IEntropyGenerator<int>, IntEntropyGenerator>()
                    .AddSingleton<IEntropyResultService, EntropyResultService>()
                    .AddSingleton<IEntropyServerBackgroundService, EntropyServerBackgroundService>()
                    .AddSingleton<IEntropyServiceMapper, EntropyServiceMapper>()
                    .AddSingleton<IEntropyTypeRepository, EntropyTypeRepository>()
                    .AddSingleton<IEntropyGeneratorRepository, EntropyGeneratorRepository>()
                    .AddSingleton<IHostedService, EntropyServerBackgroundService>()
                    .AddSingleton<IEntropyPool, EntropyPool>()

                    //result types
                    .AddScoped<IEntropyResult<int>, IntEntropyResult>()
                    .AddScoped<IEntropyGenericResult, EntropyGenericResult>();
                });
    }
}