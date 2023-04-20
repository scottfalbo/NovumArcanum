///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Mapper;
using NovumArcanum.Processors;
using NovumArcanum.Repository;
using NovumArcanum.Clients;
using NovumArcanum.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using NovumArcanum.Aegis;
using NovumArcanum.Aegis.Sentinals;

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
            builder.Services.AddDbContext<ArcanumAegisDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ArcanumAegisDbContext>();

            builder.Services.AddRazorPages();
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddSingleton<IRitualIncantations>(_ritualIncantations);
            builder.Services.AddTransient<IGaurdianSentinal, GaurdianSentinal>();
            builder.Services.AddTransient<IScribeSentinal, ScribeSentinal>();
            builder.Services.AddTransient<IInscriptioProcessor, InscriptioProcessor>();
            builder.Services.AddTransient<IWizardRepository, WizardRepository>();
            builder.Services.AddTransient<ISecretLairProcessor, SecretLairProcessor>();
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

            app.UseAuthentication();
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