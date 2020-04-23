using EnumsCompareWithOldEnums.Resources;
using EnumsCompareWithOldEnums.Services;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeCompile.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            IGenerateCodeStatusDBService generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            SettingGenerateCodeStatusDBService(generateCodeStatusDBService);

            generateCodeStatusDBService.Update(0);

            IValidateAppSettingsService validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            SettingsValidateAppSettingsService(validateAppSettingsService);

            if (validateAppSettingsService != null)
            {
                validateAppSettingsService.VerifyAppSettings();
            }

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine($"{ generateCodeStatusDBService.Error }");
                Console.WriteLine("");
                Console.WriteLine($"{ generateCodeStatusDBService.Status }");
                Console.WriteLine("");
            }

            generateCodeStatusDBService.Update(3);

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine($"{ generateCodeStatusDBService.Status }");
                Console.WriteLine("");
                return;
            }

            IGenerateCodeCompileService generateCodeCompileService = provider.GetService<IGenerateCodeCompileService>();

            if (generateCodeCompileService != null)
            {
                generateCodeCompileService.Compile(configuration.GetValue<string>("PreBuildNewEnumsDLL")).GetAwaiter().GetResult();
            }

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine($"{ generateCodeStatusDBService.Error }");
            }

            IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService = provider.GetService<IEnumsCompareWithOldEnumsService>();

            if (enumsCompareWithOldEnumsService != null)
            {
                enumsCompareWithOldEnumsService.Start().GetAwaiter().GetResult();
            }

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine($"{ generateCodeStatusDBService.Error }");
            }

            if (generateCodeCompileService != null)
            {
                generateCodeCompileService.Compile(configuration.GetValue<string>("PostBuildNewEnumsDLL")).GetAwaiter().GetResult();
            }

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine($"{ generateCodeStatusDBService.Error }");
            }

            generateCodeStatusDBService.Update(100);

            Console.WriteLine($"{ generateCodeStatusDBService.Status }");
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
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            serviceCollection.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();
            serviceCollection.AddSingleton<IGenerateCodeCompileService, GenerateCodeCompileService>();

            return serviceCollection.BuildServiceProvider();
        }
        private static void SettingGenerateCodeStatusDBService(IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            generateCodeStatusDBService.DBFileFullName = DBFullName;
            generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
            generateCodeStatusDBService.SetCulture(AppRes.Culture);
        }
        private static void SettingsValidateAppSettingsService(IValidateAppSettingsService validateAppSettingsService)
        {
            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsCompareWithOldEnums" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "NewEnumsDLL", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OldEnumsDLL", ExpectedValue = "C:\\CSSP Latest Code Old\\CSSPEnumsDLL\\CSSPEnumsDLL\\bin\\Debug\\CSSPEnumsDLL.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "PreBuildNewEnumsDLL", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\CSSPEnums.sln", IsFile = true, CheckExist = true, PreCompile = true },
                new AppSettingParameter() { Parameter = "PostBuildNewEnumsDLL", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\CSSPEnums.sln", IsFile = true, CheckExist = true, PostCompile = true }
            };
        }
        #endregion Functions private
    }
}
