using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Resources;
using ExecuteDotNetCommandServices.Services;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExecuteDotNetCommand
{
    partial class Program
    {
        #region Variables
        public static IServiceCollection serviceCollection;
        public static IConfiguration configuration;
        public static IGenerateCodeStatusDBService generateCodeStatusDBService;
        public static IValidateAppSettingsService validateAppSettingsService;
        public static IExecuteDotNetCommandService executeDotNetCommandService;
        #endregion Variables

        #region Properties
        public static string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

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

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (configuration.GetValue<string>(DBFileName) == null)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }");
                generateCodeStatusDBService.Error.AppendLine("");
            }

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

            //DBFullName = fiDB.FullName;

            if (!fiDB.Exists)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotFindFile_, fiDB.FullName) }");
                generateCodeStatusDBService.Error.AppendLine("");
            }

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            serviceCollection.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            if (generateCodeStatusDBService == null)
            {
                return;
            }

            executeDotNetCommandService = provider.GetService<IExecuteDotNetCommandService>();
            if (executeDotNetCommandService == null)
            {
                return;
            }

            validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            if (validateAppSettingsService == null)
            {
                return;
            }

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ExecuteDotNetCommand" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsCompareWithOldEnums", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsCompareWithOldEnums\\bin\\Debug\\netcoreapp3.1\\EnumsCompareWithOldEnums.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsGenerated_cs.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsTestGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsTestGenerated_cs.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsPolSourceInfoRelatedFiles", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsPolSourceInfoRelatedFiles\\bin\\Debug\\netcoreapp3.1\\EnumsPolSourceInfoRelatedFiles.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPEnumsTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\CSSPEnums.Tests.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPModelsTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPModels.Tests\\CSSPModels.Tests.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPServicesTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPServices.Tests\\CSSPServices.Tests.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\CSSPEnums.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\CSSPModels.sln", IsFile = true, CheckExist = true },
                //new AppSettingParameter() { Parameter = "build:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\CSSPServices.sln", IsFile = true, CheckExist = true },
            };

            validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                generateCodeStatusDBService.Update(0);
                return;
            }

            bool retBool = executeDotNetCommandService.Run(args).GetAwaiter().GetResult();

            if (!retBool)
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            }

            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }

        #endregion Entry

        #region Functions private
        #endregion Functions private
    }
}
