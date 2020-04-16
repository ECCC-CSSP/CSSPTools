using GenerateCodeBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models_ModelClassName_Test.Resources;
using Models_ModelClassName_Test.Services;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;
using System;
using System.Globalization;
using System.IO;

namespace Models_ModelClassName_Test
{
    partial class Program
    {
        #region Variables
        public static IConfigurationRoot configuration;
        public static IServiceCollection serviceCollection;
        #endregion Variables

        #region Entry
        static void Main(string[] args)
        {
            serviceCollection = new ServiceCollection();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            FileInfo fiDB = new FileInfo($@"{appDataPath}\CSSP\GenerateCodeStatus.db");

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            Console.WriteLine($"{ AppRes.Application } EnumsGenerated_cs");
            Console.WriteLine("");

            if (!string.IsNullOrWhiteSpace(VerifyAppSettings())) return;

            AppRes.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

            if (args.Length == 1)
            {
                if (!(args[0] == "en-CA" || args[0] == "fr-CA"))
                {
                    AppRes.Culture = new CultureInfo(args[0]);
                }
            }


            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            serviceCollection.AddScoped<IGenerateService, GenerateService>();
            serviceCollection.AddScoped<IStatusAndResultsService, StatusAndResultsService>();
            serviceCollection.AddScoped<IGenerateCode, GenerateCodeBase>();

            var provider = serviceCollection.BuildServiceProvider();

            IGenerateService generateService = provider.GetService<IGenerateService>();

            IStatusAndResultsService statusAndResultsService = provider.GetService<IStatusAndResultsService>();

            statusAndResultsService.SetCulture(AppRes.Culture);

            if (generateService != null)
            {
                generateService.Start().GetAwaiter().GetResult();
            }
        }

        #endregion Entry

        #region Functions private
        #endregion Functions private


    }
}
