using ActionCommandDBServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;

namespace ExecuteDotNetCommandServices.Services
{
    public partial class ExecuteDotNetCommandService : IExecuteDotNetCommandService
    {
        private async Task<bool> Setup()
        {
            ActionCommandDBService.Action = Config.GetValue<string>("Action");
            ActionCommandDBService.Command = Config.GetValue<string>("Command");

            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();
            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return false;
            }

            ValidateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Action", ExpectedValue = "run" },
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "AngularEnumsGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },

                // run

                new AppSettingParameter() { Parameter = "run:AngularEnumsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\AngularEnumsGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:AngularModelsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\AngularModelsGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsCompareWithOldEnums", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\EnumsCompareWithOldEnums.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\EnumsGenerated_cs.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsPolSourceInfoRelatedFiles", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\EnumsPolSourceInfoRelatedFiles.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:EnumsTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\EnumsTestGenerated_cs.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsCompare", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\ModelsCompare.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsCompareDBFieldsAndCSSPModelsDLLProp", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\ModelsCompareDBFieldsAndCSSPModelsDLLProp.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsModelClassNameTest", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\ModelsModelClassNameTest.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ModelsModelClassNameTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\ModelsModelClassNameTestGenerated_cs.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ServicesClassNameServiceGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\ServicesClassNameServiceGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ServicesClassNameServiceTestGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\ServicesClassNameServiceTestGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:ServicesRepopulateTestDB", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\ServicesRepopulateTestDB.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:WebAPIClassNameControllerGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\WebAPIClassNameControllerGenerated.exe", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "run:WebAPIClassNameControllerTestGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\_package\\netcoreapp3.1\\WebAPIClassNameControllerTestGenerated.exe", IsFile = true, CheckExist = true },

                // test

                new AppSettingParameter() { Parameter = "test:ActionCommandDBServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ActionCommandDBServices.Tests\\ActionCommandDBServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ActionCommandServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\tests\\ActionCommandServices.Tests\\ActionCommandServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:AngularEnumsGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\AngularEnumsGeneratedServices.Tests\\AngularEnumsGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:AngularModelsGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\AngularModelsGeneratedServices.Tests\\AngularModelsGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:EnumsCompareWithOldEnumsServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsCompareWithOldEnumsServices.Tests\\EnumsCompareWithOldEnumsServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:EnumsGenerated_csServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsGenerated_csServices.Tests\\EnumsGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:EnumsPolSourceInfoRelatedFilesServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsPolSourceInfoRelatedFilesServices.Tests\\EnumsPolSourceInfoRelatedFilesServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:EnumsTestGenerated_csServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsTestGenerated_csServices.Tests\\EnumsTestGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ExecuteDotNetCommandServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ExecuteDotNetCommandServices.Tests\\ExecuteDotNetCommandServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:GenerateCodeBaseServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\GenerateCodeBaseServices.Tests\\GenerateCodeBaseServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsCompareServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsCompareServices.Tests\\ModelsCompareServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsModelClassNameTestGenerated_csServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsModelClassNameTestGenerated_csServices.Tests\\ModelsModelClassNameTestGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ModelsModelClassNameTestServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsModelClassNameTestServices.Tests\\ModelsModelClassNameTestServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:PolSourceGroupingExcelFileReadServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\PolSourceGroupingExcelFileReadServices.Tests\\PolSourceGroupingExcelFileReadServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ServicesClassNameServiceGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesClassNameServiceGeneratedServices.Tests\\ServicesClassNameServiceGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ServicesClassNameServiceTestGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesClassNameServiceTestGeneratedServices.Tests\\ServicesClassNameServiceTestGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ServicesRepopulateTestDBServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesRepopulateTestDBServices.Tests\\ServicesRepopulateTestDBServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:ValidateAppSettingsServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ValidateAppSettingsServices.Tests\\ValidateAppSettingsServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:WebAPIClassNameControllerGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\WebAPIClassNameControllerGeneratedServices.Tests\\WebAPIClassNameControllerGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:WebAPIClassNameControllerTestGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\WebAPIClassNameControllerTestGeneratedServices.Tests\\WebAPIClassNameControllerTestGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "test:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\CSSPEnums.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPModels.Tests\\CSSPModels.Tests.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "test:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPServices.Tests\\CSSPServices.Tests.csproj", IsFile = true, CheckExist = true },

                // build

                new AppSettingParameter() { Parameter = "build:ActionCommandDBServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ActionCommandDBServices\\ActionCommandDBServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ActionCommandDBServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ActionCommandDBServices.Tests\\ActionCommandDBServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ActionCommandServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ActionCommandServices\\ActionCommandServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ActionCommandServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ActionCommandServices.Tests\\ActionCommandServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:AngularEnumsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularEnumsGenerated\\AngularEnumsGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:AngularEnumsGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularEnumsGeneratedServices\\AngularEnumsGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:AngularEnumsGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\AngularEnumsGeneratedServices.Tests\\AngularEnumsGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:AngularModelsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularModelsGenerated\\AngularModelsGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:AngularModelsGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\AngularModelsGeneratedServices\\AngularModelsGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:AngularModelsGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\AngularModelsGeneratedServices.Tests\\AngularModelsGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:EnumsCompareWithOldEnums", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsCompareWithOldEnums\\EnumsCompareWithOldEnums.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsCompareWithOldEnumsServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsCompareWithOldEnumsServices\\EnumsCompareWithOldEnumsServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsCompareWithOldEnumsServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsCompareWithOldEnumsServices.Tests\\EnumsCompareWithOldEnumsServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:EnumsGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\EnumsGenerated_cs.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_csServices\\EnumsGenerated_csServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsGenerated_csServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsGenerated_csServices.Tests\\EnumsGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:EnumsPolSourceInfoRelatedFiles", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsPolSourceInfoRelatedFiles\\EnumsPolSourceInfoRelatedFiles.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsPolSourceInfoRelatedFilesServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsPolSourceInfoRelatedFilesServices\\EnumsPolSourceInfoRelatedFilesServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsPolSourceInfoRelatedFilesServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsPolSourceInfoRelatedFilesServices.Tests\\EnumsPolSourceInfoRelatedFilesServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:EnumsTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsTestGenerated_cs\\EnumsTestGenerated_cs.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsTestGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsTestGenerated_csServices\\EnumsTestGenerated_csServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:EnumsTestGenerated_csServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\EnumsTestGenerated_csServices.Tests\\EnumsTestGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ExecuteDotNetCommand", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ExecuteDotNetCommand\\ExecuteDotNetCommand.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ExecuteDotNetCommandServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ExecuteDotNetCommandServices\\ExecuteDotNetCommandServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ExecuteDotNetCommandServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ExecuteDotNetCommandServices.Tests\\ExecuteDotNetCommandServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:GenerateCodeBaseServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\GenerateCodeBaseServices\\GenerateCodeBaseServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:GenerateCodeBaseServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\GenerateCodeBaseServices.Tests\\GenerateCodeBaseServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ModelsCompare", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompare\\ModelsCompare.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCompareServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompareServices\\ModelsCompareServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCompareServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsCompareServices.Tests\\ModelsCompareServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ModelsCompareDBFieldsAndCSSPModelsDLLProp", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompareDBFieldsAndCSSPModelsDLLProp\\ModelsCompareDBFieldsAndCSSPModelsDLLProp.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCompareDBFieldsAndCSSPModelsDLLPropServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests\\ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTest", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTest\\ModelsModelClassNameTest.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTestServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTestServices\\ModelsModelClassNameTestServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTestServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsModelClassNameTestServices.Tests\\ModelsModelClassNameTestServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTestGenerated_cs\\ModelsModelClassNameTestGenerated_cs.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTestGenerated_csServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ModelsModelClassNameTestGenerated_csServices\\ModelsModelClassNameTestGenerated_csServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ModelsModelClassNameTestGenerated_csServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ModelsModelClassNameTestGenerated_csServices.Tests\\ModelsModelClassNameTestGenerated_csServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:PolSourceGroupingExcelFileReadServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\PolSourceGroupingExcelFileReadServices\\PolSourceGroupingExcelFileReadServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:PolSourceGroupingExcelFileReadServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\PolSourceGroupingExcelFileReadServices.Tests\\PolSourceGroupingExcelFileReadServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceGenerated\\ServicesClassNameServiceGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceGeneratedServices\\ServicesClassNameServiceGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesClassNameServiceGeneratedServices.Tests\\ServicesClassNameServiceGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceTestGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceTestGenerated\\ServicesClassNameServiceTestGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceTestGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesClassNameServiceTestGeneratedServices\\ServicesClassNameServiceTestGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesClassNameServiceTestGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesClassNameServiceTestGeneratedServices.Tests\\ServicesClassNameServiceTestGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ServicesRepopulateTestDB", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesRepopulateTestDB\\ServicesRepopulateTestDB.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesRepopulateTestDBServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ServicesRepopulateTestDBServices\\ServicesRepopulateTestDBServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ServicesRepopulateTestDBServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ServicesRepopulateTestDBServices.Tests\\ServicesRepopulateTestDBServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:ValidateAppSettingsServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\ValidateAppSettingsServices\\ValidateAppSettingsServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:ValidateAppSettingsServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\ValidateAppSettingsServices.Tests\\ValidateAppSettingsServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerGenerated\\WebAPIClassNameControllerGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerGeneratedServices\\WebAPIClassNameControllerGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\WebAPIClassNameControllerGeneratedServices.Tests\\WebAPIClassNameControllerGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },

                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerTestGenerated", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerTestGenerated\\WebAPIClassNameControllerTestGenerated.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerTestGeneratedServices", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\WebAPIClassNameControllerTestGeneratedServices\\WebAPIClassNameControllerTestGeneratedServices.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:WebAPIClassNameControllerTestGeneratedServices.Tests", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\Tests\\WebAPIClassNameControllerTestGeneratedServices.Tests\\WebAPIClassNameControllerTestGeneratedServices.Tests.csproj", IsFile = true, CheckExist = true },



                new AppSettingParameter() { Parameter = "build:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\CSSPEnums.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\CSSPModels.csproj", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "build:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\CSSPServices.csproj", IsFile = true, CheckExist = true },
            };

            await ValidateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(ActionCommandDBService.ErrorText.ToString()))
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
