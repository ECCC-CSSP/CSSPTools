using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using ConfigServices.Services;
using CSSPCultureServices.Services;
using ExecuteDotNetCommandServices.Models;
using GenerateCodeBaseServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;

namespace ExecuteDotNetCommandServices.Services
{
    public interface IExecuteDotNetCommandService
    {
        Task<bool> Run(string[] args);
    }
    public partial class ExecuteDotNetCommandService : ConfigService, IExecuteDotNetCommandService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private DotNetCommand dotNetCommand { get; set; } = new DotNetCommand();
        private List<string> Args0Allowables { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private List<string> Args1Allowables { get; set; } = new List<string>() { "run", "test", "build" };
        private List<string> ArgsRunAllowables { get; set; } = new List<string>()
        {
            "AngularEnumsGenerated",
            "AngularModelsGenerated",
            "EnumsCompareWithOldEnums",
            "EnumsGenerated_cs",
            "EnumsPolSourceInfoRelatedFiles",
            "EnumsTestGenerated_cs",
            "ModelsCompare",
            "ModelsCompareDBFieldsAndCSSPModelsDLLProp",
            "ModelsModelClassNameTest",
            "ModelsModelClassNameTestGenerated_cs",
            "ServicesClassNameServiceGenerated",
            "ServicesClassNameServiceTestGenerated",
            "ServicesRepopulateTestDB",
            "WebAPIClassNameControllerGenerated",
            "WebAPIClassNameControllerTestGenerated"
        };
        private List<string> ArgsTestAllowables { get; set; } = new List<string>()
        {
            "ActionCommandDBServices.Tests",
            "ActionCommandServices.Tests",
            "AngularEnumsGeneratedServices.Tests",
            "AngularModelsGeneratedServices.Tests",
            "EnumsCompareWithOldEnumsServices.Tests",
            "EnumsGenerated_csServices.Tests",
            "EnumsPolSourceInfoRelatedFilesServices.Tests",
            "EnumsTestGenerated_csServices.Tests",
            "ExecuteDotNetCommandServices.Tests",
            "GenerateCodeBaseServices.Tests",
            "ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests",
            "ModelsCompareServices.Tests",
            "ModelsModelClassNameTestGenerated_csServices.Tests",
            "ModelsModelClassNameTestServices.Tests",
            "PolSourceGroupingExcelFileReadServices.Tests",
            "ServicesClassNameServiceGeneratedServices.Tests",
            "ServicesClassNameServiceTestGeneratedServices.Tests",
            "ServicesRepopulateTestDBServices.Tests",
            "ValidateAppSettingsServices.Tests",
            "WebAPIClassNameControllerGeneratedServices.Tests",
            "WebAPIClassNameControllerTestGeneratedServices.Tests",

            "CSSPEnums",
            "CSSPModels",
            "CSSPDBServices",
        };
        private List<string> ArgsBuildAllowables { get; set; } = new List<string>()
        {
            "ActionCommandDBServices",
            "ActionCommandDBServices.Tests",

            "ActionCommandServices",
            "ActionCommandServices.Tests",

            "AngularEnumsGenerated",
            "AngularEnumsGeneratedServices",
            "AngularEnumsGeneratedServices.Tests",

            "AngularModelsGenerated",
            "AngularModelsGeneratedServices",
            "AngularModelsGeneratedServices.Tests",

            "EnumsCompareWithOldEnums",
            "EnumsCompareWithOldEnumsServices",
            "EnumsCompareWithOldEnumsServices.Tests",

            "EnumsGenerated_cs",
            "EnumsGenerated_csServices",
            "EnumsGenerated_csServices.Tests",

            "EnumsPolSourceInfoRelatedFiles",
            "EnumsPolSourceInfoRelatedFilesServices",
            "EnumsPolSourceInfoRelatedFilesServices.Tests",

            "EnumsTestGenerated_cs",
            "EnumsTestGenerated_csServices",
            "EnumsTestGenerated_csServices.Tests",

            "ExecuteDotNetCommand",
            "ExecuteDotNetCommandServices",
            "ExecuteDotNetCommandServices.Tests",

            "GenerateCodeBaseServices",
            "GenerateCodeBaseServices.Tests",

            "ModelsCompare",
            "ModelsCompareServices",
            "ModelsCompareServices.Tests",

            "ModelsCompareDBFieldsAndCSSPModelsDLLProp",
            "ModelsCompareDBFieldsAndCSSPModelsDLLPropServices",
            "ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests",

            "ModelsModelClassNameTest",
            "ModelsModelClassNameTestServices",
            "ModelsModelClassNameTestServices.Tests",

            "ModelsModelClassNameTestGenerated_cs",
            "ModelsModelClassNameTestGenerated_csServices",
            "ModelsModelClassNameTestGenerated_csServices.Tests",

            "PolSourceGroupingExcelFileReadServices",
            "PolSourceGroupingExcelFileReadServices.Tests",

            "ServicesClassNameServiceGenerated",
            "ServicesClassNameServiceGeneratedServices",
            "ServicesClassNameServiceGeneratedServices.Tests",

            "ServicesClassNameServiceTestGenerated",
            "ServicesClassNameServiceTestGeneratedServices",
            "ServicesClassNameServiceTestGeneratedServices.Tests",

            "ServicesRepopulateTestDB",
            "ServicesRepopulateTestDBServices",
            "ServicesRepopulateTestDBServices.Tests",

            "ValidateAppSettingsServices",
            "ValidateAppSettingsServices.Tests",

            "WebAPIClassNameControllerGenerated",
            "WebAPIClassNameControllerGeneratedServices",
            "WebAPIClassNameControllerGeneratedServices.Tests",

            "WebAPIClassNameControllerTestGenerated",
            "WebAPIClassNameControllerTestGeneratedServices",
            "WebAPIClassNameControllerTestGeneratedServices.Tests",

            "CSSPEnums",
            "CSSPModels",
            "CSSPDBServices"
        };
        #endregion Properties

        #region Constructors
        public ExecuteDotNetCommandService(IConfiguration Configuration,
            ICSSPCultureService CSSPCultureService,
            IActionCommandDBService ActionCommandDBService,
            IValidateAppSettingsService ValidateAppSettingsService,
            IGenerateCodeBaseService GenerateCodeBaseService) : base(Configuration)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.ActionCommandDBService = ActionCommandDBService;
            this.ValidateAppSettingsService = ValidateAppSettingsService;
            this.GenerateCodeBaseService = GenerateCodeBaseService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            if (!await FillActionAndCommand()) return await Task.FromResult(false);

            await ActionCommandDBService.ConsoleWriteStart();

            if (!await Setup())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            await SetCultureWithArgs(args);

            if (!await ReadArgs(args))
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            if (!await ExecuteDotNet())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            await ActionCommandDBService.ConsoleWriteEnd();

            if (args[1] == "build" || args[1] == "test")
            {
                string ExecutionStatusText = ActionCommandDBService.ExecutionStatusText.ToString();

                ActionCommandDBService.Action = args[1];
                ActionCommandDBService.Command = args[2];

                ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();
                if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
                {
                    await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                    return false;
                }

                await ActionCommandDBService.ConsoleWriteStart();

                ActionCommandDBService.ExecutionStatusText = new StringBuilder(ExecutionStatusText);

                await ActionCommandDBService.ConsoleWriteEnd();
            }

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}