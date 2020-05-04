using EnumsCompareWithOldEnumsServices.Resources;
using EnumsCompareWithOldEnumsServices.Services;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EnumsCompareWithOldEnums
{
    partial class Program
    {
        #region Variables
        #endregion Variables

        #region Properties
        private static IServiceCollection serviceCollection;
        private static IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService;
        private static IConfiguration configuration;
        private static IGenerateCodeStatusDBService generateCodeStatusDBService;
        private static IValidateAppSettingsService validateAppSettingsService;
        private static string DBFileName { get; set; } = "DBFileName";
        private static FileInfo fiDB { get; set; }
        #endregion Properties

        #region Entry
        static int Main(string[] args)
        {
            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (configuration.GetValue<string>(DBFileName) == null)
            {
                Console.WriteLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }");
                return 1;
            }

            fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                Console.WriteLine($"{ String.Format(AppRes.CouldNotFindFile_, fiDB.FullName) }");
                return 1;
            }

            try
            {
                serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });

                //serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            if (provider == null)
            {
                Console.WriteLine("EnumsCompareWithOldEnums provider == null");
                Console.WriteLine("");
            }

            enumsCompareWithOldEnumsService = provider.GetService<IEnumsCompareWithOldEnumsService>();
            if (enumsCompareWithOldEnumsService == null)
            {
                Console.WriteLine("EnumsCompareWithOldEnums enumsCompareWithOldEnumsService == null");
                Console.WriteLine("");
            }

            if (!enumsCompareWithOldEnumsService.Run(args).GetAwaiter().GetResult())
            {
                Console.WriteLine(AppRes.AbnormalCompletion);
                Console.WriteLine("");
                return 1;
            }

            return 0;
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private
    }
}
