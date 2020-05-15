using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Resources;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
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
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExecuteDotNetCommandServices.Services
{
    public partial class ExecuteDotNetCommandService : IExecuteDotNetCommandService
    {
        #region Variables
        private IConfiguration configuration { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Variables

        #region Properties
        private DotNetCommand dotNetCommand { get; set; } = new DotNetCommand();
        private List<string> Args0Allowables { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private List<string> Args1Allowables { get; set; } = new List<string>() { "run", "test", "build" };
        private List<string> ArgsRunAllowables { get; set; } = new List<string>()
        {
            "AngularEnumsGenerated",
            "AngularInterfacesGenerated",
            "EnumsCompareWithOldEnums",
            "EnumsGenerated_cs",
            "EnumsPolSourceInfoRelatedFiles",
            "EnumsTestGenerated_cs",
            "ModelsCompare",
            "ModelsCompareDBFieldsAndCSSPModelsDLLProp",
            "ModelsCSSPModelsRes",
            "ModelsModelClassNameTest",
            "ModelsModelClassNameTestGenerated_cs",
            "ServicesClassNameServiceGenerated",
            "ServicesClassNameServiceTestGenerated",
            "ServicesExtensionEnumCastingGenerated",
            "ServicesRepopulateTestDB",
            "WebAPIClassNameControllerGenerated",
            "WebAPIClassNameControllerTestGenerated"
        };
        private List<string> ArgsTestAllowables { get; set; } = new List<string>()
        {
            "ActionCommandDBServices.Tests",
            "ActionCommandServices.Tests",
            "AngularEnumsGeneratedServices.Tests",
            "AngularInterfacesGeneratedServices.Tests",
            "EnumsCompareWithOldEnumsServices.Tests",
            "EnumsGenerated_csServices.Tests",
            "EnumsPolSourceInfoRelatedFilesServices.Tests",
            "EnumsTestGenerated_csServices.Tests",
            "ExecuteDotNetCommandServices.Tests",
            "GenerateCodeBaseServices.Tests",
            "ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests",
            "ModelsCompareServices.Tests",
            "ModelsCSSPModelsResServices.Tests",
            "ModelsModelClassNameTestGenerated_csServices.Tests",
            "ModelsModelClassNameTestServices.Tests",
            "PolSourceGroupingExcelFileReadServices.Tests",
            "ServicesClassNameServiceGeneratedServices.Tests",
            "ServicesClassNameServiceTestGeneratedServices.Tests",
            "ServicesExtensionEnumCastingGeneratedServices.Tests",
            "ServicesRepopulateTestDBServices.Tests",
            "ValidateAppSettingsServices.Tests",
            "WebAPIClassNameControllerGeneratedServices.Tests",
            "WebAPIClassNameControllerTestGeneratedServices.Tests",

            "CSSPEnums",
            "CSSPModels",
            "CSSPServices",
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

            "AngularInterfacesGenerated",
            "AngularInterfacesGeneratedServices",
            "AngularInterfacesGeneratedServices.Tests",

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

            "ModelsCSSPModelsRes",
            "ModelsCSSPModelsResServices",
            "ModelsCSSPModelsResServices.Tests",

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

            "ServicesExtensionEnumCastingGenerated",
            "ServicesExtensionEnumCastingGeneratedServices",
            "ServicesExtensionEnumCastingGeneratedServices.Tests",

            "ServicesRepopulateTestDB",
            "ServicesRepopulateTestDBServices",
            "ServicesRepopulateTestDBServices.Tests",

            "UserServices",
            "UserServices.Tests",

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
            "CSSPServices"
        };
        #endregion Properties

        #region Constructors
        public ExecuteDotNetCommandService(IConfiguration configuration, IActionCommandDBService actionCommandDBService, IValidateAppSettingsService validateAppSettingsService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
            this.validateAppSettingsService = validateAppSettingsService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            await actionCommandDBService.ConsoleWriteStart();

            if (!await Setup())
            {
                await actionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            await SetCultureWithArgs(args);

            if (!await ReadArgs(args))
            {
                await actionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            if (!await ExecuteDotNet())
            {
                await actionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            await actionCommandDBService.ConsoleWriteEnd();

            return await Task.FromResult(true);
        }
        public async Task SetCulture(CultureInfo culture)
        {
            await actionCommandDBService.SetCulture(culture);
            await validateAppSettingsService.SetCulture(culture);
            ExecuteDotNetCommandServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private async Task SetCultureWithArgs(string[] args)
        {
            string culture = AllowableCultures[0];

            if (args.Count() > 0)
            {
                if (AllowableCultures.Contains(args[0]))
                {
                    culture = args[0];
                }
            }

            await SetCulture(new CultureInfo(culture));
        }
        #endregion Functions private
    }
}