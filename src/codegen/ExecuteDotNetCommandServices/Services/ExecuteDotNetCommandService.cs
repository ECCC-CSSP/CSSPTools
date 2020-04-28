using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Resources;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Services
{
    public class ExecuteDotNetCommandService : IExecuteDotNetCommandService
    {
        #region Variables
        private static IServiceCollection _serviceCollection;
        private static IConfiguration _configuration;
        private static IGenerateCodeStatusDBService _generateCodeStatusDBService;
        private string DBFullName;
        #endregion Variables

        #region Properties
        private DotNetCommand dotNetCommand { get; set; } = new DotNetCommand();
        private List<string> Args0Allowables { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private List<string> Args1Allowables { get; set; } = new List<string>() { "run", "test", "build" };
        private List<string> Args2Allowables { get; set; } = new List<string>() { "CSSPEnums", "CSSPModels", "CSSPServices" };
        #endregion Properties

        #region Constructors
        public ExecuteDotNetCommandService(IConfiguration configuration, IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            _configuration = configuration;
            _generateCodeStatusDBService = generateCodeStatusDBService;
        }
        #endregion Constructors

        #region Functions public
        public async Task Run(string[] args)
        {
            DotNetCommand _dotNetCommand = new DotNetCommand();

            _serviceCollection = new ServiceCollection();
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            // Filling serviceCollection with DI
            ServiceProvider provider = SettingDependencyInjections("DBFileName");
            if (provider == null)
            {
                Console.WriteLine($"provider { AppRes.IsNull }");
                return;
            }

            // getting Generate Code DB status object fom DI and checking if not null
            IGenerateCodeStatusDBService generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            if (generateCodeStatusDBService == null)
            {
                Console.WriteLine($"generateCodeStatusDBService { AppRes.IsNull }");
                return;
            }
            SettingGenerateCodeStatusDBService(generateCodeStatusDBService);

            // setting culture
            SettingCulture(args);

            // getting all other objects fom DI and checking if not null
            IValidateAppSettingsService validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            IExecuteDotNetCommandService executeDotNetService = provider.GetService<IExecuteDotNetCommandService>();

            if (validateAppSettingsService == null)
            {
                ServiceIsNull(generateCodeStatusDBService, "validateAppSettingsService");
                return;
            }
            if (executeDotNetService == null)
            {
                ServiceIsNull(generateCodeStatusDBService, "executeDotNetService");
                return;
            }

            AppRes.Culture = new CultureInfo(_configuration.GetValue<string>("Culture"));

            await ReadArgs(args);
            if (ErrorFound(generateCodeStatusDBService)) return;

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Starting } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            await generateCodeStatusDBService.Update(0);

            Console.WriteLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Starting } ...");
            Console.WriteLine("");

            // checking the appsettings.json parameters
            SettingsValidateAppSettingsService(validateAppSettingsService);
            await validateAppSettingsService.VerifyAppSettings();
            if (ErrorFound(generateCodeStatusDBService)) return;

            await generateCodeStatusDBService.Update(3);

            string FileName = _configuration.GetValue<string>($"{ _dotNetCommand.Action }:{ _dotNetCommand.SolutionFileName }");

            await ExecuteDotNet(FileName);
            if (ErrorFound(generateCodeStatusDBService)) return;

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            await generateCodeStatusDBService.Update(100);

            Console.WriteLine($"{ generateCodeStatusDBService.Status }");

        }
        #endregion Functions public

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
        private async Task ExecuteDotNet(string FileName)
        {
            //string FileName = _configuration.GetValue<string>($"{ dotNetCommand.Action }:{ dotNetCommand.SolutionFileName }");

            string LogFileName = "DotNetCommandLog.txt";
            FileInfo fi = new FileInfo(FileName);
            string currentDirectory = Directory.GetCurrentDirectory();

            if (!fi.Exists)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindSolutionFile_ToCompile, fi.FullName) }");
                return;
            }

            DirectoryInfo di = fi.Directory;
            if (!di.Exists)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindDirectoryOfSolutionFile_, fi.Directory) }");
                return;
            }

            Directory.SetCurrentDirectory(di.FullName);

            string command = $"dotnet";
            string arg = $" { dotNetCommand.Action } /flp:v=m; /flp:logfile={ LogFileName }";
            if (dotNetCommand.Action == "run")
            {
                command = fi.Name;
                arg = dotNetCommand.CultureName;
            }
            _generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.RunningCommand_UnderDirectory_, command + arg, di.FullName) }");

            Process process = new Process();
            process = Process.Start($"{ command }", $" { arg }");
            process.WaitForExit();

            FileInfo fiLog = new FileInfo(fi.FullName.Replace(fi.Name, LogFileName));

            if (!fiLog.Exists)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindFile_, fiLog.FullName) }");
                return;
            }

            StreamReader sr = fiLog.OpenText();
            string logText = sr.ReadToEnd();
            sr.Close();

            _generateCodeStatusDBService.Status.AppendLine($"");
            _generateCodeStatusDBService.Status.AppendLine($"{ logText }");
            _generateCodeStatusDBService.Status.AppendLine($"");

            try
            {
                fiLog.Delete();
            }
            catch (Exception ex)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ ex.Message }");
                return;
            }

            Directory.SetCurrentDirectory(currentDirectory);
        }
        private async Task ReadArgs(string[] args)
        {
            if (args.Count() != 3)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.ApplicationRequires3ParametersSeparatedBySpace }");
                _generateCodeStatusDBService.Error.AppendLine("");
                _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Example } ExecuteDotNetCommand en-CA run CSSPEnums");
                _generateCodeStatusDBService.Error.AppendLine("");
                _generateCodeStatusDBService.Error.AppendLine($"\t#0:\t{ AppRes.CultureOptionsEnCAFrCA }");
                _generateCodeStatusDBService.Error.AppendLine("");
                _generateCodeStatusDBService.Error.AppendLine($"\t#1:\t{ AppRes.ActionOptionsRunTestBuild }");
                _generateCodeStatusDBService.Error.AppendLine("");
                _generateCodeStatusDBService.Error.AppendLine($"\t#2:\t{ AppRes.SolutionFileNameExampleCSSPRunsCSSPModelsCSSPServices }");
                _generateCodeStatusDBService.Error.AppendLine("");
                return;
            }
            else
            {
                if (!(Args0Allowables.Contains(args[0])))
                {
                    _generateCodeStatusDBService.Error.AppendLine($"\t#0:\t{ string.Format(AppRes.Parameter_ShouldBe_, "0", string.Join(" || ", Args0Allowables)) }");
                    _generateCodeStatusDBService.Error.AppendLine("");
                    return;
                }
                else
                {
                    AppRes.Culture = new CultureInfo(args[0]);
                    dotNetCommand.CultureName = args[0];
                }

                if (!(Args1Allowables.Contains(args[1])))
                {
                    _generateCodeStatusDBService.Error.AppendLine($"\t#1:\t{ string.Format(AppRes.Parameter_ShouldBe_, "1", string.Join(" || ", Args1Allowables)) }");
                    _generateCodeStatusDBService.Error.AppendLine("");
                    return;
                }
                else
                {
                    dotNetCommand.Action = args[1];
                }

                if (!(Args2Allowables.Contains(args[2])))
                {
                    _generateCodeStatusDBService.Error.AppendLine($"\t#2:\t{ string.Format(AppRes.Parameter_ShouldBe_, "2", string.Join(" || ", Args2Allowables)) }");
                    _generateCodeStatusDBService.Error.AppendLine("");
                    return;
                }
                else
                {
                    dotNetCommand.SolutionFileName = args[2];
                }
            }
        }
        private void ServiceIsNull(IGenerateCodeStatusDBService generateCodeStatusDBService, string serviceIsNull)
        {
            generateCodeStatusDBService.Error.AppendLine($"{ serviceIsNull } { AppRes.IsNull }");
            ErrorFound(generateCodeStatusDBService);
        }
        private void SettingCulture(string[] args)
        {
            AppRes.Culture = new CultureInfo(_configuration.GetValue<string>("Culture"));

            if (args.Length > 0)
            {
                if (!(args[0] == "en-CA" || args[0] == "fr-CA"))
                {
                    AppRes.Culture = new CultureInfo(args[0]);
                }
            }
        }
        private ServiceProvider SettingDependencyInjections(string DBFileNameParam)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (_configuration.GetValue<string>(DBFileNameParam) == null)
            {
                Console.WriteLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileNameParam) }");
                Console.WriteLine("");

                return null;
            }

            FileInfo fiDB = new FileInfo(_configuration.GetValue<string>("DBFileName").Replace("{AppDataPath}", appDataPath));

            DBFullName = fiDB.FullName;

            _serviceCollection.AddSingleton<IConfiguration>(_configuration);
            _serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });
            _serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            _serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            _serviceCollection.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();

            return _serviceCollection.BuildServiceProvider();
        }
        private void SettingGenerateCodeStatusDBService(IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            generateCodeStatusDBService.DBFileFullName = DBFullName;
            generateCodeStatusDBService.Command = _configuration.GetValue<string>("Command");
            generateCodeStatusDBService.SetCulture(AppRes.Culture);
        }
        private void SettingsValidateAppSettingsService(IValidateAppSettingsService validateAppSettingsService)
        {
            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsGenerated_cs" },
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
                new AppSettingParameter() { Parameter = "build:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\\\CSSPModels.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\\\CSSPServices.sln", IsFile = true, CheckExist = true },
            };
        }
        #endregion Functions private
    }
}