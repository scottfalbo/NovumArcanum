using MechanistTower.Clients;
using MechanistTower.Configuration;
using Microsoft.Azure.Cosmos;

namespace NovumArcanum
{
    public class Program
    {
        private static RitualIncantations _ritualIncantations;
        private static IConfiguration _config;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            _config = builder.Configuration;

            _ritualIncantations = ConfigureServiceConfiguration();

            ConfigureServices(builder);
            ConfigureCosmosClient(builder);

            var app = builder.Build();
            ConfigureAppSettings(app);
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();

            builder.Services.AddSingleton<IRitualIncantations>(_ritualIncantations);
        }

        private static void ConfigureAppSettings(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureCosmosClient(WebApplicationBuilder builder)
        {
            var cosmosEndpoint = _config["Cosmos:Endpoint"];
            var cosmosKey = _config["Cosmos:Key"];
            var cosmosClient = new CosmosClient(cosmosEndpoint, cosmosKey);

            builder.Services.AddSingleton<ICosmosTomeScryer>(
                new CosmosTomeScryer(cosmosClient));
        }

        private static RitualIncantations ConfigureServiceConfiguration()
        {
            var serviceConfiguration = new RitualIncantations()
            {
                CosmosEndpoint = _config["Cosmos:Endpoint"],
                CosmosKey = _config["Cosmos:Key"]
            };

            return serviceConfiguration;
        }
    }
}