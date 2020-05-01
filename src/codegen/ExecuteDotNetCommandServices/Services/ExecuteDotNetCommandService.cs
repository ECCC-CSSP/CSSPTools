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
        private string DBFullName;
        #endregion Variables

        #region Properties
        public IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private DotNetCommand dotNetCommand { get; set; } = new DotNetCommand();
        private List<string> Args0Allowables { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private List<string> Args1Allowables { get; set; } = new List<string>() { "run", "test", "build" };
        private List<string> ArgsRunAllowables { get; set; } = new List<string>() { "EnumsCompareWithOldEnums", "EnumsGenerated_cs", "EnumsTestGenerated_cs", "EnumsPolSourceInfoRelatedFiles" };
        private List<string> ArgsTestAllowables { get; set; } = new List<string>() { "CSSPEnumsTests", "CSSPModelsTests", "CSSPServicesTests" };
        private List<string> ArgsBuildAllowables { get; set; } = new List<string>() { "CSSPEnums", "CSSPModels", "CSSPServices" };
        #endregion Properties

        #region Constructors
        public ExecuteDotNetCommandService(IConfiguration configuration, IGenerateCodeStatusDBService generateCodeStatusDBService, IValidateAppSettingsService validateAppSettingsService)
        {
            _configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
            this.generateCodeStatusDBService.Culture = new CultureInfo(Args0Allowables[0]);
            this.validateAppSettingsService = validateAppSettingsService;
            this.validateAppSettingsService.Culture = new CultureInfo(Args0Allowables[0]);
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            DotNetCommand _dotNetCommand = new DotNetCommand();

            //_serviceCollection = new ServiceCollection();

            //_configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //// setting culture
            //SettingCulture(args);

            //// Filling serviceCollection with DI
            //ServiceProvider provider = SettingDependencyInjections("DBFileName");
            //if (provider == null)
            //{
            //    generateCodeStatusDBService.Error.AppendLine($"provider { AppRes.IsNull }");
            //    return false;
            //}

            //generateCodeStatusDBService.DBFileFullName = DBFullName;
            //generateCodeStatusDBService.Command = _configuration.GetValue<string>("Command");
            //await generateCodeStatusDBService.SetCulture(AppRes.Culture);
            //await validateAppSettingsService.SetCulture(AppRes.Culture);

            // getting Generate Code DB status object fom DI and checking if not null
            //generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            //if (generateCodeStatusDBService == null)
            //{
            //    generateCodeStatusDBService.Error.AppendLine($"provider { AppRes.IsNull }");
            //    Console.WriteLine($"generateCodeStatusDBService { AppRes.IsNull }");
            //    return false;
            //}
            //SettingGenerateCodeStatusDBService();

            // setting culture
            //SettingCulture(args);

            // getting all other objects fom DI and checking if not null
            //IValidateAppSettingsService validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            //IExecuteDotNetCommandService executeDotNetService = provider.GetService<IExecuteDotNetCommandService>();

            //if (validateAppSettingsService == null)
            //{
            //    ServiceIsNull(generateCodeStatusDBService, "validateAppSettingsService");
            //    return false;
            //}
            //if (executeDotNetService == null)
            //{
            //    ServiceIsNull(generateCodeStatusDBService, "executeDotNetService");
            //    return false;
            //}

            //AppRes.Culture = new CultureInfo(_configuration.GetValue<string>("Culture"));

            ReadArgs(args);
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString())) return false;

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Starting } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            //await generateCodeStatusDBService.Update(0);


            // checking the appsettings.json parameters
            //FillAppSettingParameterList();
            //await validateAppSettingsService.VerifyAppSettings();
            //if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            //{
            //    await generateCodeStatusDBService.Update(0);
            //    return false;
            //}

            await generateCodeStatusDBService.Update(3);

            //string FileName = _configuration.GetValue<string>($"{ _dotNetCommand.Action }:{ _dotNetCommand.SolutionFileName }");

            //ExecuteDotNet(FileName);
            ExecuteDotNet();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString())) return false;

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            await generateCodeStatusDBService.Update(100);

            return true;
        }
        #endregion Functions public

        #region Functions private
        //private bool ErrorFound()
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
        private void ExecuteDotNet()
        {
            string FileName = _configuration.GetValue<string>($"{ dotNetCommand.Action }:{ dotNetCommand.SolutionFileName }");

            string LogFileName = "DotNetCommandLog.txt";
            FileInfo fi = new FileInfo(FileName);
            string currentDirectory = Directory.GetCurrentDirectory();

            if (!fi.Exists)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindSolutionFile_ToCompile, fi.FullName) }");
                return;
            }

            DirectoryInfo di = fi.Directory;
            if (!di.Exists)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindDirectoryOfSolutionFile_, fi.Directory) }");
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
            generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.RunningCommand_UnderDirectory_, command + arg, di.FullName) }");

            Process process = new Process();
            process = Process.Start($"{ command }", $" { arg }");
            process.WaitForExit();

            FileInfo fiLog = new FileInfo(fi.FullName.Replace(fi.Name, LogFileName));

            if (!fiLog.Exists)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindFile_, fiLog.FullName) }");
                return;
            }

            StreamReader sr = fiLog.OpenText();
            string logText = sr.ReadToEnd();
            sr.Close();

            generateCodeStatusDBService.Status.AppendLine($"");
            generateCodeStatusDBService.Status.AppendLine($"{ logText }");
            generateCodeStatusDBService.Status.AppendLine($"");

            try
            {
                fiLog.Delete();
            }
            catch (Exception ex)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ ex.Message }");
                return;
            }

            Directory.SetCurrentDirectory(currentDirectory);
        }
        private void ReadArgs(string[] args)
        {
            if (args.Count() != 3)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ AppRes.ApplicationRequires3ParametersSeparatedBySpace }");
                generateCodeStatusDBService.Error.AppendLine("");
                generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Example } ExecuteDotNetCommand en-CA run CSSPEnums");
                generateCodeStatusDBService.Error.AppendLine("");
                generateCodeStatusDBService.Error.AppendLine($"\t#0:\t{ AppRes.CultureOptionsEnCAFrCA }");
                generateCodeStatusDBService.Error.AppendLine("");
                generateCodeStatusDBService.Error.AppendLine($"\t#1:\t{ AppRes.ActionOptionsRunTestBuild }");
                generateCodeStatusDBService.Error.AppendLine("");
                generateCodeStatusDBService.Error.AppendLine($"\t#2:\t{ AppRes.SolutionFileNameExampleCSSPRunsCSSPModelsCSSPServices }");
                generateCodeStatusDBService.Error.AppendLine("");
                return;
            }
            else
            {
                if (!(Args0Allowables.Contains(args[0])))
                {
                    generateCodeStatusDBService.Error.AppendLine($"\t#0:\t{ string.Format(AppRes.Parameter_ShouldBe_, "0", string.Join(" || ", Args0Allowables)) }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    return;
                }
                else
                {
                    AppRes.Culture = new CultureInfo(args[0]);
                    dotNetCommand.CultureName = args[0];
                }

                if (!(Args1Allowables.Contains(args[1])))
                {
                    generateCodeStatusDBService.Error.AppendLine($"\t#1:\t{ string.Format(AppRes.Parameter_ShouldBe_, "1", string.Join(" || ", Args1Allowables)) }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    return;
                }
                else
                {
                    dotNetCommand.Action = args[1];
                }

                if (args[1] == "run")
                {
                    if (!(ArgsRunAllowables.Contains(args[2])))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"\t#2:\t{ string.Format(AppRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsRunAllowables)) }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        return;
                    }
                    else
                    {
                        dotNetCommand.SolutionFileName = args[2];
                    }
                }
                if (args[1] == "test")
                {
                    if (!(ArgsRunAllowables.Contains(args[2])))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"\t#2:\t{ string.Format(AppRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsTestAllowables)) }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        return;
                    }
                    else
                    {
                        dotNetCommand.SolutionFileName = args[2];
                    }
                }
                if (args[1] == "build")
                {
                    if (!(ArgsRunAllowables.Contains(args[2])))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"\t#2:\t{ string.Format(AppRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsBuildAllowables)) }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        return;
                    }
                    else
                    {
                        dotNetCommand.SolutionFileName = args[2];
                    }
                }
            }
        }
        //private void ServiceIsNull(string serviceIsNull)
        //{
        //    generateCodeStatusDBService.Error.AppendLine($"{ serviceIsNull } { AppRes.IsNull }");
        //    ErrorFound(generateCodeStatusDBService);
        //}
        private void SettingCulture(string[] args)
        {
            try
            {
                AppRes.Culture = new CultureInfo(_configuration.GetValue<string>("Culture"));
            }
            catch (Exception)
            {
                // nothing Culture should already be set to en-CA and can still be set with the args[0] parameter
            }

            if (args.Length > 0)
            {
                if (args[0] == "en-CA" || args[0] == "fr-CA")
                {
                    try
                    {
                        AppRes.Culture = new CultureInfo(args[0]);
                    }
                    catch (Exception)
                    {
                        // nothing Culture should already be set to en-CA and can still be set with the args[0] parameter
                    }
                }
            }
        }
        private ServiceProvider SettingDependencyInjections(string DBFileNameParam)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (_configuration.GetValue<string>(DBFileNameParam) == null)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileNameParam) }");
                generateCodeStatusDBService.Error.AppendLine("");

                return null;
            }

            FileInfo fiDB = new FileInfo(_configuration.GetValue<string>(DBFileNameParam).Replace("{AppDataPath}", appDataPath));

            DBFullName = fiDB.FullName;

            if (!fiDB.Exists)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotFindFile_, fiDB.FullName) }");
                generateCodeStatusDBService.Error.AppendLine("");
                return null;
            }

            try
            {
                //_serviceCollection.AddSingleton<IConfiguration>(_configuration);
                _serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });
            }
            catch (Exception ex)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ ex.Message }");
                generateCodeStatusDBService.Error.AppendLine("");
                return null;
            }
            //_serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            //_serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            //_serviceCollection.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();

            return _serviceCollection.BuildServiceProvider();
        }
        //private void SettingGenerateCodeStatusDBService()
        //{
        //}
        //private void FillAppSettingParameterList()
        //{
        //    validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
        //    {
        //        new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ExecuteDotNetCommandServices.Tests" },
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
        //        new AppSettingParameter() { Parameter = "build:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\CSSPModels.sln", IsFile = true, CheckExist = true },
        //        //new AppSettingParameter() { Parameter = "build:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\CSSPServices.sln", IsFile = true, CheckExist = true },
        //    };
        //}
        #endregion Functions private
    }
}