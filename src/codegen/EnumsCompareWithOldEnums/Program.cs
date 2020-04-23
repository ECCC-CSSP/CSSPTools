using CSSPGenerateCodeBase.Models;
using CSSPGenerateCodeBase.Services;
using EnumsCompareWithOldEnums.Resources;
using EnumsCompareWithOldEnums.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace EnumsCompareWithOldEnums
{
    partial class Program
    {
        #region Variables
        public static IConfigurationRoot configuration;
        public static IServiceCollection serviceCollection;
        private static string DBFullName;
        #endregion Variables

        #region Entry
        static void Main(string[] args)
        {
            Console.WriteLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Starting } ...");
            Console.WriteLine("");

            serviceCollection = new ServiceCollection();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            SettingCulture(args);
            ServiceProvider provider = SettingDependencyInjections("DBFileName");
            if (provider == null)
            {
                return;
            }

            IStatusAndResultsService statusAndResultsService = provider.GetService<IStatusAndResultsService>();
            SettingStatusAndResultsService(statusAndResultsService);

            IValidateAppSettingsService validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            SettingsValidateAppSettingsService(validateAppSettingsService);

            statusAndResultsService.Update(0);

            validateAppSettingsService.VerifyAppSettings();

            statusAndResultsService.Update(0);

            if (!string.IsNullOrWhiteSpace(statusAndResultsService.Error.ToString()))
            {
                Console.WriteLine($"{ statusAndResultsService.Status }");
                Console.WriteLine("");
                return;
            }

            IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService = provider.GetService<IEnumsCompareWithOldEnumsService>();

            if (enumsCompareWithOldEnumsService != null)
            {
                enumsCompareWithOldEnumsService.Start().GetAwaiter().GetResult();
            }

            if (!string.IsNullOrWhiteSpace(statusAndResultsService.Error.ToString()))
            {
                Console.WriteLine($"{ statusAndResultsService.Error }");
            }

            statusAndResultsService.Update(100);

            Console.WriteLine($"{ statusAndResultsService.Status }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Done }");
        }
        #endregion Entry

        #region Functions private
        private static void SettingCulture(string[] args)
        {
            AppRes.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

            if (args.Length == 1)
            {
                if (!(args[0] == "en-CA" || args[0] == "fr-CA"))
                {
                    AppRes.Culture = new CultureInfo(args[0]);
                }
            }
        }
        private static ServiceProvider SettingDependencyInjections(string DBFileNameParam)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (configuration.GetValue<string>(DBFileNameParam) == null)
            {
                Console.WriteLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileNameParam) }");
                Console.WriteLine("");

                return null;
            }

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>("DBFileName").Replace("{AppDataPath}", appDataPath));

            DBFullName = fiDB.FullName;

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });
            serviceCollection.AddSingleton<IStatusAndResultsService, StatusAndResultsService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            serviceCollection.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();

            return serviceCollection.BuildServiceProvider();
        }
        private static void SettingStatusAndResultsService(IStatusAndResultsService statusAndResultsService)
        {
            statusAndResultsService.DBFileFullName = DBFullName;
            statusAndResultsService.Command = configuration.GetValue<string>("Command");
            statusAndResultsService.SetCulture(AppRes.Culture);
        }
        private static void SettingsValidateAppSettingsService(IValidateAppSettingsService validateAppSettingsService)
        {
            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsCompareWithOldEnums", IsCulture = false, IsFile = false, CheckExist = false },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true, IsFile = false, CheckExist = false },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsCulture = false, IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "NewEnumsDLL", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsCulture = false, IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OldEnumsDLL", ExpectedValue = "C:\\CSSP Latest Code Old\\CSSPEnumsDLL\\CSSPEnumsDLL\\bin\\Debug\\CSSPEnumsDLL.dll", IsCulture = false, IsFile = true, CheckExist = true }
            };
        }
        #endregion Functions private
    }
}
