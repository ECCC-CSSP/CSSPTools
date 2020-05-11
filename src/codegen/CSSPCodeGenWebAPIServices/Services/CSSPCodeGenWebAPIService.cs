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
    public class CSSPCodeGenWebAPIService : ICSSPCodeGenWebAPIService
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
        private List<string> ArgsRunAllowables { get; set; } = new List<string>() 
        {
            "AngularEnumsGenerated", "AngularInterfacesGenerated", "EnumsCompareWithOldEnums", "EnumsGenerated_cs",
            "EnumsPolSourceInfoRelatedFiles", "EnumsTestGenerated_cs", "ModelsCompare", "ModelsCompareDBFieldsAndCSSPModelsDLLProp",
            "ModelsCSSPModelsRes", "ModelsModelClassNameTest", "ModelsModelClassNameTestGenerated_cs", "ServicesClassNameServiceGenerated",
            "ServicesClassNameServiceTestGenerated", "ServicesExtensionEnumCastingGenerated", "ServicesRepopulateTestDB", "WebAPIClassNameControllerGenerated",
            "WebAPIClassNameControllerTestGenerated" 
        };
        private List<string> ArgsTestAllowables { get; set; } = new List<string>() 
        {
            "AngularEnumsGeneratedServices", "AngularInterfacesGeneratedServices", "EnumsCompareWithOldEnumsServices", "EnumsGenerated_csServices",
            "EnumsPolSourceInfoRelatedFilesServices", "EnumsTestGenerated_csServices", "ExecuteDotNetCommandServices", "GenerateCodeBase",
            "GenerateCodeStatusDB", "ModelsCompareDBFieldsAndCSSPModelsDLLPropServices", "ModelsCompareServices", "ModelsCSSPModelsResServices",
            "ModelsModelClassNameTestGenerated_csServices", "ModelsModelClassNameTestServices", "PolSourceGroupingExcelFileReadServices", "ServicesClassNameServiceGeneratedServices",
            "ServicesClassNameServiceTestGeneratedServices", "ServicesExtensionEnumCastingGeneratedServices", "ServicesRepopulateTestDBServices", "WebAPIClassNameControllerGeneratedServices",
            "WebAPIClassNameControllerTestGeneratedServices", "CSSPEnums", "CSSPModels", "CSSPServices",
        };
        private List<string> ArgsBuildAllowables { get; set; } = new List<string>() 
        {
            "AngularEnumsGenerated", "AngularInterfacesGenerated", "EnumsCompareWithOldEnums", "EnumsGenerated_cs",
            "EnumsPolSourceInfoRelatedFiles", "EnumsTestGenerated_cs", "ExecuteDotNetCommand", "GenerateCodeBase",
            "GenerateCodeStatusDB", "ModelsCompareDBFieldsAndCSSPModelsDLLProp", "ModelsCompare", "ModelsCSSPModelsRes",
            "ModelsModelClassNameTestGenerated_cs", "ModelsModelClassNameTest", "PolSourceGroupingExcelFileRead", "ServicesClassNameServiceGenerated",
            "ServicesClassNameServiceTestGenerated", "ServicesExtensionEnumCastingGenerated", "ServicesRepopulateTestDB", "WebAPIClassNameControllerGenerated",
            "WebAPIClassNameControllerTestGenerated", "CSSPEnums", "CSSPModels", "CSSPServices",

            "AngularEnumsGeneratedServices", "AngularInterfacesGeneratedServices", "EnumsCompareWithOldEnumsServices", "EnumsGenerated_csServices",
            "EnumsPolSourceInfoRelatedFilesServices", "EnumsTestGenerated_csServices", "ExecuteDotNetCommandServices", "GenerateCodeBaseServices",
            "GenerateCodeStatusDBServices", "ModelsCompareDBFieldsAndCSSPModelsDLLPropServices", "ModelsCompareServices", "ModelsCSSPModelsResServices",
            "ModelsModelClassNameTestGenerated_csServices", "ModelsModelClassNameTestServices", "PolSourceGroupingExcelFileReadServices", "ServicesClassNameServiceGeneratedServices",
            "ServicesClassNameServiceTestGeneratedServices", "ServicesExtensionEnumCastingGeneratedServices", "ServicesRepopulateTestDBServices", "WebAPIClassNameControllerGeneratedServices",
            "WebAPIClassNameControllerTestGeneratedServices",
        };
        #endregion Properties

        #region Constructors
        public CSSPCodeGenWebAPIService(IConfiguration configuration, IGenerateCodeStatusDBService generateCodeStatusDBService, IValidateAppSettingsService validateAppSettingsService)
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

            if (!await Setup())
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                Console.WriteLine("");
                Console.WriteLine(generateCodeStatusDBService.Status.ToString());
                return false;
            }

            if (!await ExecuteDotNet())
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                Console.WriteLine("");
                Console.WriteLine(generateCodeStatusDBService.Status.ToString());
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
                new AppSettingParameter() { Parameter = "run:AngularEnumsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularEnumsGenerated\\bin\\Debug\\netcoreapp3.1\\AngularEnumsGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:AngularInterfacesGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularInterfacesGenerated\\bin\\Debug\\netcoreapp3.1\\AngularInterfacesGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsCompareWithOldEnums", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsCompareWithOldEnums\\bin\\Debug\\netcoreapp3.1\\EnumsCompareWithOldEnums.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsGenerated_cs.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsPolSourceInfoRelatedFiles", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsPolSourceInfoRelatedFiles\\bin\\Debug\\netcoreapp3.1\\EnumsPolSourceInfoRelatedFiles.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsTestGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsTestGenerated_cs.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsCompare", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompare\\bin\\Debug\\netcoreapp3.1\\ModelsCompare.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsCompareDBFieldsAndCSSPModelsDLLProp", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompareDBFieldsAndCSSPModelsDLLProp\\bin\\Debug\\netcoreapp3.1\\ModelsCompareDBFieldsAndCSSPModelsDLLProp.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsCSSPModelsRes", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCSSPModelsRes\\bin\\Debug\\netcoreapp3.1\\ModelsCSSPModelsRes.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsModelClassNameTest", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTest\\bin\\Debug\\netcoreapp3.1\\ModelsModelClassNameTest.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsModelClassNameTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTestGenerated_cs\\bin\\Debug\\netcoreapp3.1\\ModelsModelClassNameTestGenerated_cs.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ServicesClassNameServiceGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceGenerated\\bin\\Debug\\netcoreapp3.1\\ServicesClassNameServiceGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ServicesClassNameServiceTestGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceTestGenerated\\bin\\Debug\\netcoreapp3.1\\ServicesClassNameServiceTestGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ServicesExtensionEnumCastingGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesExtensionEnumCastingGenerated\\bin\\Debug\\netcoreapp3.1\\ServicesExtensionEnumCastingGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ServicesRepopulateTestDB", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesRepopulateTestDB\\bin\\Debug\\netcoreapp3.1\\ServicesRepopulateTestDB.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:WebAPIClassNameControllerGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerGenerated\\bin\\Debug\\netcoreapp3.1\\WebAPIClassNameControllerGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:WebAPIClassNameControllerTestGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerTestGenerated\\bin\\Debug\\netcoreapp3.1\\WebAPIClassNameControllerTestGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:AngularEnumsGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\AngularEnumsGeneratedServices.Tests\\AngularEnumsGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:AngularInterfacesGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\AngularInterfacesGeneratedServices.Tests\\AngularInterfacesGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:EnumsCompareWithOldEnumsServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsCompareWithOldEnumsServices.Tests\\EnumsCompareWithOldEnumsServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:EnumsGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsGenerated_csServices.Tests\\EnumsGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:EnumsPolSourceInfoRelatedFilesServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsPolSourceInfoRelatedFilesServices.Tests\\EnumsPolSourceInfoRelatedFilesServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:EnumsTestGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsTestGenerated_csServices.Tests\\EnumsTestGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ExecuteDotNetCommandServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ExecuteDotNetCommandServices.Tests\\ExecuteDotNetCommandServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:GenerateCodeBase", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\GenerateCodeBase.Tests\\GenerateCodeBase.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:GenerateCodeStatusDB", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\GenerateCodeStatusDB.Tests\\GenerateCodeStatusDB.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsCompareDBFieldsAndCSSPModelsDLLPropServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsCompareServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsCompareServices.Tests\\ModelsCompareServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsCSSPModelsResServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsCSSPModelsResServices.Tests\\ModelsCSSPModelsResServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsModelClassNameTestGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsModelClassNameTestGenerated_csServices.Tests\\ModelsModelClassNameTestGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsModelClassNameTestServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsModelClassNameTestServices.Tests\\ModelsModelClassNameTestServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:PolSourceGroupingExcelFileReadServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\PolSourceGroupingExcelFileReadServices.Tests\\PolSourceGroupingExcelFileReadServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ServicesClassNameServiceGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesClassNameServiceGeneratedServices.Tests\\ServicesClassNameServiceGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ServicesClassNameServiceTestGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesClassNameServiceTestGeneratedServices.Tests\\ServicesClassNameServiceTestGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ServicesExtensionEnumCastingGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesExtensionEnumCastingGeneratedServices.Tests\\ServicesExtensionEnumCastingGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ServicesRepopulateTestDBServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesRepopulateTestDBServices.Tests\\ServicesRepopulateTestDBServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:WebAPIClassNameControllerGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\WebAPIClassNameControllerGeneratedServices.Tests\\WebAPIClassNameControllerGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:WebAPIClassNameControllerTestGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\WebAPIClassNameControllerTestGeneratedServices.Tests\\WebAPIClassNameControllerTestGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\CSSPEnums.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPModels.Tests\\CSSPModels.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPServices.Tests\\CSSPServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:AngularEnumsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularEnumsGenerated\\AngularEnumsGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:AngularInterfacesGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularInterfacesGenerated\\AngularInterfacesGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsCompareWithOldEnums", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsCompareWithOldEnums\\EnumsCompareWithOldEnums.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\EnumsGenerated_cs.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsTestGenerated_cs\\EnumsTestGenerated_cs.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ExecuteDotNetCommand", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ExecuteDotNetCommand\\ExecuteDotNetCommand.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:GenerateCodeBase", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\GenerateCodeBase\\GenerateCodeBase.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:GenerateCodeStatusDB", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\GenerateCodeStatusDB\\GenerateCodeStatusDB.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCompareDBFieldsAndCSSPModelsDLLProp", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompareDBFieldsAndCSSPModelsDLLProp\\ModelsCompareDBFieldsAndCSSPModelsDLLProp.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCompare", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompare\\ModelsCompare.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCSSPModelsRes", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCSSPModelsRes\\ModelsCSSPModelsRes.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTestGenerated_cs\\ModelsModelClassNameTestGenerated_cs.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTest", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTest\\ModelsModelClassNameTest.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceGenerated\\ServicesClassNameServiceGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceTestGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceTestGenerated\\ServicesClassNameServiceTestGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesExtensionEnumCastingGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesExtensionEnumCastingGenerated\\ServicesExtensionEnumCastingGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesRepopulateTestDB", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesRepopulateTestDB\\ServicesRepopulateTestDB.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerGenerated\\WebAPIClassNameControllerGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerTestGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerTestGenerated\\WebAPIClassNameControllerTestGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:AngularEnumsGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularEnumsGeneratedServices\\AngularEnumsGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:AngularInterfacesGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularInterfacesGeneratedServices\\AngularInterfacesGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsCompareWithOldEnumsServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsCompareWithOldEnumsServices\\EnumsCompareWithOldEnumsServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_csServices\\EnumsGenerated_csServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsPolSourceInfoRelatedFilesServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsPolSourceInfoRelatedFilesServices\\EnumsPolSourceInfoRelatedFilesServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsTestGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsTestGenerated_csServices\\EnumsTestGenerated_csServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ExecuteDotNetCommandServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ExecuteDotNetCommandServices\\ExecuteDotNetCommandServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCompareDBFieldsAndCSSPModelsDLLPropServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCompareServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompareServices\\ModelsCompareServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCSSPModelsResServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCSSPModelsResServices\\ModelsCSSPModelsResServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTestGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTestGenerated_csServices\\ModelsModelClassNameTestGenerated_csServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTestServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTestServices\\ModelsModelClassNameTestServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:PolSourceGroupingExcelFileReadServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\PolSourceGroupingExcelFileReadServices\\PolSourceGroupingExcelFileReadServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceGeneratedServices\\ServicesClassNameServiceGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceTestGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceTestGeneratedServices\\ServicesClassNameServiceTestGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesExtensionEnumCastingGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesExtensionEnumCastingGeneratedServices\\ServicesExtensionEnumCastingGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesRepopulateTestDBServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesRepopulateTestDBServices\\ServicesRepopulateTestDBServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerGeneratedServices\\WebAPIClassNameControllerGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerTestGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerTestGeneratedServices\\WebAPIClassNameControllerTestGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\CSSPEnums.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\CSSPModels.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\CSSPServices.csproj", IsFile = true, CheckExist = true },
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