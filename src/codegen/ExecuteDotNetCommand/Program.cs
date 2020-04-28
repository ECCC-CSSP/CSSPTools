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
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Entry
        static void Main(string[] args)
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IExecuteDotNetCommandService executeDotNetCommandService = provider.GetService<IExecuteDotNetCommandService>();

            executeDotNetCommandService.Run(args);
        }

        #endregion Entry

        #region Functions private
        //private static bool ErrorFound(IGenerateCodeStatusDBService generateCodeStatusDBService)
        //{
        //    if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
        //    {
        //        Console.WriteLine($"{ generateCodeStatusDBService.Error }");
        //        Console.WriteLine("");
        //        Console.WriteLine($"{ generateCodeStatusDBService.Status }");
        //        Console.WriteLine("");

        //        generateCodeStatusDBService.Update(0);
        //        return true;
        //    }

        //    return false;
        //}
        //private static void ServiceIsNull(IGenerateCodeStatusDBService generateCodeStatusDBService, string serviceIsNull)
        //{
        //    generateCodeStatusDBService.Error.AppendLine($"{ serviceIsNull } { AppRes.IsNull }");
        //    ErrorFound(generateCodeStatusDBService);
        //}
        //private static void SettingCulture(string[] args)
        //{
        //    AppRes.Culture = new CultureInfo(_configuration.GetValue<string>("Culture"));

        //    if (args.Length > 0)
        //    {
        //        if (!(args[0] == "en-CA" || args[0] == "fr-CA"))
        //        {
        //            AppRes.Culture = new CultureInfo(args[0]);
        //        }
        //    }
        //}
        //private static ServiceProvider SettingDependencyInjections(string DBFileNameParam)
        //{
        //    string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //    if (configuration.GetValue<string>(DBFileNameParam) == null)
        //    {
        //        Console.WriteLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileNameParam) }");
        //        Console.WriteLine("");

        //        return null;
        //    }

        //    FileInfo fiDB = new FileInfo(configuration.GetValue<string>("DBFileName").Replace("{AppDataPath}", appDataPath));

        //    DBFullName = fiDB.FullName;

        //    serviceCollection.AddSingleton<IConfiguration>(configuration);
        //    serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
        //    {
        //        options.UseSqlite($"DataSource={fiDB.FullName}");
        //    });
        //    serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
        //    serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
        //    serviceCollection.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();

        //    return serviceCollection.BuildServiceProvider();
        //}
        //private static void SettingGenerateCodeStatusDBService(IGenerateCodeStatusDBService generateCodeStatusDBService)
        //{
        //    generateCodeStatusDBService.DBFileFullName = DBFullName;
        //    generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
        //    generateCodeStatusDBService.SetCulture(AppRes.Culture);
        //}
        //private static void SettingsValidateAppSettingsService(IValidateAppSettingsService validateAppSettingsService)
        //{
        //    validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
        //    {
        //        new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsGenerated_cs" },
        //        new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
        //        new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "run:EnumsCompareWithOldEnums", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsCompareWithOldEnums\\bin\\Debug\\netcoreapp3.1\\EnumsCompareWithOldEnums.exe", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "run:EnumsGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsGenerated_cs.exe", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "run:EnumsTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsTestGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsTestGenerated_cs.exe", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "run:EnumsPolSourceInfoRelatedFiles", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsPolSourceInfoRelatedFiles\\bin\\Debug\\netcoreapp3.1\\EnumsPolSourceInfoRelatedFiles.exe", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "test:CSSPEnumsTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\CSSPEnums.Tests.sln", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "test:CSSPModelsTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPModels.Tests\\CSSPModels.Tests.sln", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "test:CSSPServicesTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPServices.Tests\\CSSPServices.Tests.sln", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "build:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\CSSPEnums.sln", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "build:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\\\CSSPModels.sln", IsFile = true, CheckExist = true },
        //        new AppSettingParameter() { Parameter = "build:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\\\CSSPServices.sln", IsFile = true, CheckExist = true },
        //    };
        //}
        #endregion Functions private
    }
}
