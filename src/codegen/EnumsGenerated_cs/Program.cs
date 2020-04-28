using EnumsGenerated_cs.Resources;
using EnumsGenerated_cs.Services;
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

namespace EnumsGenerated_cs
{
    partial class Program
    {
        #region Variables
        public static IConfiguration configuration;
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

            // setting culture
            SettingCulture(args);

            // Filling serviceCollection with DI
            ServiceProvider provider = SettingDependencyInjections("DBFileName");
            if (provider == null)
            {
                Console.WriteLine("provider is null");
                return;
            }

            // getting Generate Code DB status object fom DI and checking if not null
            IGenerateCodeStatusDBService generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            if (generateCodeStatusDBService == null)
            {
                Console.WriteLine("generateCodeStatusDBService is null");
                return;
            }
            SettingGenerateCodeStatusDBService(generateCodeStatusDBService);

            // getting all other objects fom DI and checking if not null
            IValidateAppSettingsService validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            IEnumsGenerated_csService enumsGenerated_csService = provider.GetService<IEnumsGenerated_csService>();

            if (validateAppSettingsService == null)
            {
                ServiceIsNull(generateCodeStatusDBService, "validateAppSettingsService");
                return;
            }
            if (enumsGenerated_csService == null)
            {
                ServiceIsNull(generateCodeStatusDBService, "enumsGenerated_csService");
                return;
            }

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Starting } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Update(0);

            // checking the appsettings.json parameters
            SettingsValidateAppSettingsService(validateAppSettingsService);
            validateAppSettingsService.VerifyAppSettings();
            if (ErrorFound(generateCodeStatusDBService)) return;

            generateCodeStatusDBService.Update(3);

            // running the compare with old enums service
            enumsGenerated_csService.Start().GetAwaiter().GetResult();
            if (ErrorFound(generateCodeStatusDBService)) return;

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Update(100);

            Console.WriteLine($"{ generateCodeStatusDBService.Status }");
        }

        #endregion Entry

        #region Functions private
        private static bool ErrorFound(IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine($"{ generateCodeStatusDBService.Error }");
                Console.WriteLine("");
                Console.WriteLine($"{ generateCodeStatusDBService.Status }");
                Console.WriteLine("");

                generateCodeStatusDBService.Update(0);
                return true;
            }

            return false;
        }
        private static void ServiceIsNull(IGenerateCodeStatusDBService generateCodeStatusDBService, string serviceIsNull)
        {
            generateCodeStatusDBService.Error.AppendLine($"{ serviceIsNull } is null");
            ErrorFound(generateCodeStatusDBService);
        }
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

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            serviceCollection.AddSingleton<IEnumsGenerated_csService, EnumsGenerated_csService>();
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsGenerated_cs" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "IEnumsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\IEnumsGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "EnumsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\EnumsGenerated.cs", IsFile = true, CheckExist = true },
            };
        }
        #endregion Functions private
    }
}
