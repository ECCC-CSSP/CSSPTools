using EnumsPolSourceInfoRelatedFilesServices.Resources;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Models;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public partial class EnumsPolSourceInfoRelatedFilesService : IEnumsPolSourceInfoRelatedFilesService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public EnumsPolSourceInfoRelatedFilesService(IConfiguration configuration,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
            this.validateAppSettingsService = validateAppSettingsService;
            this.polSourceGroupingExcelFileReadService = polSourceGroupingExcelFileReadService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            SetCulture(args);

            ConsoleWriteStart();

            if (!await Setup())
            {
                Console.WriteLine(actionCommandDBService.ErrorText.ToString());
                Console.WriteLine("");
                Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
                return false;
            }

            if (!await Generate())
            {
                Console.WriteLine(actionCommandDBService.ErrorText.ToString());
                Console.WriteLine("");
                Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
                return false;
            }

            await ConsoleWriteEnd();

            return true;
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await actionCommandDBService.GetOrCreate();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ConsoleWriteError("actionCommand == null");
                return false;
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            actionCommandDBService.PercentCompleted = 10;
            await actionCommandDBService.Update();


            actionCommandDBService.ExecutionStatusText.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking }");

            FileInfo fiExcel = new FileInfo(configuration.GetValue<string>("ExcelFileName"));

            if (!await polSourceGroupingExcelFileReadService.ReadExcelSheet(fiExcel.FullName, false))
            {
                return false;
            }

            if (polSourceGroupingExcelFileReadService.groupChoiceChildLevelList.Count() == 0)
            {
                string ErrorText = String.Format(AppRes.ERROR_IsEqualTo0, "_groupChoiceChildLevelList");
                actionCommandDBService.ErrorText.AppendLine($"{ ErrorText }");
                actionCommandDBService.PercentCompleted = 0;
                await actionCommandDBService.Update();


                return false;
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking } { AppRes.Done } ...");

            await Generate_FillPolSourceObsInfoChildService();
            await Generate_EnumsPolSourceInfo();
            await Generate_PolSourceObsInfoEnum();
            await Generate_EnumsPolSourceObsInfoEnumTest();
            await Generate_PolSourceInfoEnumGeneratedRes_resx();
            await Generate_PolSourceInfoEnumGeneratedResFR_resx();

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ AppRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();


            return true;
        }
        private async Task ConsoleWriteEnd()
        {
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"{ AppRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();


            if (!string.IsNullOrWhiteSpace(actionCommandDBService.ErrorText.ToString()))
            {
                Console.WriteLine(actionCommandDBService.ErrorText.ToString());
            }

            Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
        }
        private async Task ConsoleWriteError(string errMessage)
        {
            actionCommandDBService.ErrorText.AppendLine(errMessage);
            actionCommandDBService.PercentCompleted = 0;
            await actionCommandDBService.Update();

            Console.WriteLine(actionCommandDBService.ErrorText.ToString());
            Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
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
            string culture = AllowableCultures[0];

            if (args.Count() > 0)
            {
                if (AllowableCultures.Contains(args[0]))
                {
                    culture = args[0];
                }
            }

            AppRes.Culture = new CultureInfo(culture);
        }
        private async Task<bool> Setup()
        {
            actionCommandDBService.Command = configuration.GetValue<string>("Command");
            await actionCommandDBService.SetCulture(new CultureInfo(configuration.GetValue<string>("Culture")));
            await validateAppSettingsService.SetCulture(new CultureInfo(configuration.GetValue<string>("Culture")));

            try
            {
                await actionCommandDBService.GetOrCreate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsPolSourceInfoRelatedFiles" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "ExcelFileName", ExpectedValue = "C:\\CSSPTools\\src\\assets\\PolSourceGrouping.xlsm", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "FillPolSourceObsInfoChildServiceGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\Generated\\FillPolSourceObsInfoChildServiceGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "EnumsPolSourceInfoGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\EnumsPolSourceInfoGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "PolSourceObsInfoEnumGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\PolSourceObsInfoEnumGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "EnumsPolSourceObsInfoEnumTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\tests\\Generated\\EnumsPolSourceObsInfoEnumTestGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "PolSourceInfoEnumGeneratedRes_resx", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Resources\\Generated\\PolSourceInfoEnumGeneratedRes.resx", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "PolSourceInfoEnumGeneratedResFR_resx", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Resources\\Generated\\PolSourceInfoEnumGeneratedRes.fr.resx", IsFile = true, CheckExist = true },
            };

            await validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(actionCommandDBService.ErrorText.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}