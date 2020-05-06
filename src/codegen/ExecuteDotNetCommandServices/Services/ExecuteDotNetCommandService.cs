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
        private IConfiguration configuration { get; set; }
        private IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        #endregion Variables

        #region Properties
        private DotNetCommand dotNetCommand { get; set; } = new DotNetCommand();
        private List<string> Args0Allowables { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private List<string> Args1Allowables { get; set; } = new List<string>() { "run", "test", "build" };
        private List<string> ArgsRunAllowables { get; set; } = new List<string>() { "EnumsCompareWithOldEnums", "EnumsGenerated_cs", "EnumsTestGenerated_cs", "EnumsPolSourceInfoRelatedFiles" };
        private List<string> ArgsTestAllowables { get; set; } = new List<string>() { "CSSPEnums", "CSSPModels", "CSSPServices" };
        private List<string> ArgsBuildAllowables { get; set; } = new List<string>() { "CSSPEnums", "CSSPModels", "CSSPServices" };
        #endregion Properties

        #region Constructors
        public ExecuteDotNetCommandService(IConfiguration configuration, IGenerateCodeStatusDBService generateCodeStatusDBService, IValidateAppSettingsService validateAppSettingsService)
        {
            this.configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
            this.generateCodeStatusDBService.Culture = new CultureInfo(Args0Allowables[0]);
            this.validateAppSettingsService = validateAppSettingsService;
            this.validateAppSettingsService.Culture = new CultureInfo(Args0Allowables[0]);
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            SetCulture(args);

            ConsoleWriteStart();

            if (!await ReadArgs(args))
            {
                if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
                {
                    Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                }

                Console.WriteLine(generateCodeStatusDBService.Status.ToString());

                return false;
            }

            if (!await Setup()) return false;

            if (!await ExecuteDotNet())
            {
                await ConsoleWriteError("");
                return false;
            }

            await ConsoleWriteEnd();

            return true;
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> ExecuteDotNet()
        {
            generateCodeStatusDBService.Status.AppendLine("ExecuteDotNet Starting...");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"args = { dotNetCommand.CultureName }  { dotNetCommand.Action } { dotNetCommand.SolutionFileName }");
            generateCodeStatusDBService.Status.AppendLine("");
            await generateCodeStatusDBService.Update(0);

            string FileName = configuration.GetValue<string>($"{ dotNetCommand.Action }:{ dotNetCommand.SolutionFileName }");

            string LogFileName = "DotNetCommandLog.txt";
            FileInfo fi = new FileInfo(FileName);
            string currentDirectory = Directory.GetCurrentDirectory();

            if (!fi.Exists)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindSolutionFile_ToCompile, fi.FullName) }");
                return false;
            }

            DirectoryInfo di = fi.Directory;
            if (!di.Exists)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindDirectoryOfSolutionFile_, fi.Directory) }");
                return false;
            }

            Directory.SetCurrentDirectory(di.FullName);

            string command = $"dotnet";
            string arg = $" { dotNetCommand.Action } /flp:v=m; /flp:logfile={ LogFileName }";
            if (dotNetCommand.Action == "run")
            {
                command = fi.Name;
                arg = $"{ dotNetCommand.CultureName }";
            }

            Process process = new Process();
            process = Process.Start($"{ command }", $" { arg }");
            process.WaitForExit();

            Directory.SetCurrentDirectory(currentDirectory);

            if (process.ExitCode != 0)
            {
                generateCodeStatusDBService.Error.AppendLine("");
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.ErrorWhileRunningCommand_UnderDirectory_, command + " " + arg, di.FullName) }");
                return false;
            }

            if (dotNetCommand.Action != "run")
            {
                FileInfo fiLog = new FileInfo(fi.FullName.Replace(fi.Name, LogFileName));

                if (!fiLog.Exists)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindFile_, fiLog.FullName) }");
                    return false;
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
                    return false;
                }
            }

            generateCodeStatusDBService.Status.AppendLine("ExecuteDotNet Finished...");

            return true;
        }
        private async Task<bool> ReadArgs(string[] args)
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
                return false;
            }
            else
            {
                if (!(Args0Allowables.Contains(args[0])))
                {
                    string culture = Args0Allowables[0];

                    if (args.Count() > 0)
                    {
                        if (Args0Allowables.Contains(args[0]))
                        {
                            culture = args[0];
                        }
                    }

                    args[0] = culture;
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
                    return false;
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
                        return false;
                    }
                    else
                    {
                        dotNetCommand.SolutionFileName = args[2];
                    }
                }
                if (args[1] == "test")
                {
                    if (!(ArgsTestAllowables.Contains(args[2])))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"\t#2:\t{ string.Format(AppRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsTestAllowables)) }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        return false;
                    }
                    else
                    {
                        dotNetCommand.SolutionFileName = args[2];
                    }
                }
                if (args[1] == "build")
                {
                    if (!(ArgsBuildAllowables.Contains(args[2])))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"\t#2:\t{ string.Format(AppRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsBuildAllowables)) }");
                        generateCodeStatusDBService.Error.AppendLine("");
                        return false;
                    }
                    else
                    {
                        dotNetCommand.SolutionFileName = args[2];
                    }
                }
            }

            return true;
        }
        private async Task ConsoleWriteEnd()
        {
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            await generateCodeStatusDBService.Update(100);

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            }

            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        private async Task ConsoleWriteError(string errMessage)
        {
            generateCodeStatusDBService.Error.AppendLine(errMessage);
            await generateCodeStatusDBService.Update(0);
            Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        private void ConsoleWriteStart()
        {
            Console.WriteLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Starting } ...");
            Console.WriteLine("");
        }
        private void SetCulture(string[] args)
        {
            string culture = Args0Allowables[0];

            if (args.Count() > 0)
            {
                if (Args0Allowables.Contains(args[0]))
                {
                    culture = args[0];
                }
            }

            AppRes.Culture = new CultureInfo(culture);
        }
        private async Task<bool> Setup()
        {
            generateCodeStatusDBService.Command = $"{ dotNetCommand.Action }:{ dotNetCommand.SolutionFileName}";
            generateCodeStatusDBService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));
            validateAppSettingsService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

            GenerateCodeStatus generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();
            if (generateCodeStatus == null)
            {
                generateCodeStatusDBService.Error.AppendLine("generateCodeStatus == null");
                if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
                {
                    Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                }

                Console.WriteLine(generateCodeStatusDBService.Status.ToString());
                return false;
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
                new AppSettingParameter() { Parameter = "test:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\CSSPEnums.Tests.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPModels.Tests\\CSSPModels.Tests.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPServices.Tests\\CSSPServices.Tests.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\CSSPEnums.sln", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\CSSPModels.sln", IsFile = true, CheckExist = true },
                //new AppSettingParameter() { Parameter = "build:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\CSSPServices.sln", IsFile = true, CheckExist = true },
            };

            validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}