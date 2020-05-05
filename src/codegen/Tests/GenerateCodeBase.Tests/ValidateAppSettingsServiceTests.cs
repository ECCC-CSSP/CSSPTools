using GenerateCodeBase.Models;
using GenerateCodeBase.Resources;
using GenerateCodeStatusDB.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenerateCodeBase.Tests
{
    public partial class GenerateCodeBaseTests
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        //[Fact]
        //public async Task ValidateAppSettingsServiceCheckParameterExistTest()
        //{
        //    foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
        //    {
        //        Init(new CultureInfo(culture));

        //        validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
        //        {
        //            new AppSettingParameter() { Parameter = "Command", ExpectedValue = "GenerateCodeBase.Tests" },
        //            new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
        //            new AppSettingParameter() { Parameter = "DBFileNameTest", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatusTest.db", IsFile = true, CheckExist = true },
        //            //new AppSettingParameter() { Parameter = "DBFileNameTest2", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeBaseTest_NotExist.db", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "run:EnumsCompareWithOldEnums", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsCompareWithOldEnums\\bin\\Debug\\netcoreapp3.1\\EnumsCompareWithOldEnums.exe", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "run:EnumsGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsGenerated_cs.exe", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "run:EnumsTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsTestGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsTestGenerated_cs.exe", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "run:EnumsPolSourceInfoRelatedFiles", ExpectedValue = "C:\\CSSPTools\\src\\codegen\\EnumsPolSourceInfoRelatedFiles\\bin\\Debug\\netcoreapp3.1\\EnumsPolSourceInfoRelatedFiles.exe", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "test:CSSPEnumsTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\CSSPEnums.Tests.sln", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "test:CSSPModelsTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPModels.Tests\\CSSPModels.Tests.sln", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "test:CSSPServicesTests", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPServices.Tests\\CSSPServices.Tests.sln", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "build:CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\CSSPEnums.sln", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "build:CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\CSSPModels.sln", IsFile = true, CheckExist = true },
        //            new AppSettingParameter() { Parameter = "build:CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\CSSPServices.sln", IsFile = true, CheckExist = true },
        //        };

        //        await validateAppSettingsService.CheckParameterExist();
        //        Assert.Equal("", generateCodeStatusDBService.Error.ToString());

        //        Init(new CultureInfo(culture));

        //        validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
        //        {
        //            new AppSettingParameter() { Parameter = "Command_NotExist", ExpectedValue = "GenerateCodeBase.Tests" },
        //        };

        //        await validateAppSettingsService.CheckParameterExist();
        //        StringBuilder expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.Error }\tCommand_NotExist != { AppRes.CouldNotFindParameter }");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Error.ToString());

        //        Init(new CultureInfo(culture));

        //        validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
        //        {
        //            new AppSettingParameter() { Parameter = "Command", ExpectedValue = "GenerateCodeBase.Tests" },
        //        };

        //        await validateAppSettingsService.CheckParameterExist();
        //        expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.OK }\tCommand == { AppRes.Exist}");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Status.ToString());
        //    }
        //}
        //[Fact]
        //public async Task ValidateAppSettingsServiceCheckParameterValueTest()
        //{
        //    foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
        //    {
        //        Init(new CultureInfo(culture));

        //        string param = "Command_NotExist";
        //        string shouldHaveValue = "GenerateCodeBase.Tests";
        //        await validateAppSettingsService.CheckParameterValue(param, shouldHaveValue);
        //        StringBuilder expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Error.ToString());

        //        Init(new CultureInfo(culture));

        //        param = "Command";
        //        shouldHaveValue = "GenerateCodeBase.Tests";
        //        await validateAppSettingsService.CheckParameterValue(param, shouldHaveValue);
        //        expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.OK }\t{ param } == { shouldHaveValue }");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Status.ToString());
        //    }
        //}
        //[Fact]
        //public async Task ValidateAppSettingsServiceCheckCultureParameterValueTest()
        //{
        //    foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
        //    {
        //        Init(new CultureInfo(culture));

        //        string param = "Culture_NotExist";
        //        await validateAppSettingsService.CheckCultureParameterValue(param);
        //        StringBuilder expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.Error }\t{ param } != en-CA || fr-CA");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Error.ToString());

        //        Init(new CultureInfo(culture));

        //        param = "Culture";
        //        await validateAppSettingsService.CheckCultureParameterValue(param);
        //        expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.OK }\t{ param } == en-CA || fr-CA");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Status.ToString());
        //    }
        //}
        //[Fact]
        //public async Task ValidateAppSettingsServiceCheckFileParameterValueTest()
        //{
        //    foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
        //    {
        //        Init(new CultureInfo(culture));

        //        string param = "DBFileNameTest_NotExist";
        //        string shouldHaveValue = "{AppDataPath}\\CSSP\\GenerateCodeStatusTest.db";
        //        bool CheckIfExist = false;
        //        await validateAppSettingsService.CheckFileParameterValue(param, shouldHaveValue, CheckIfExist);
        //        StringBuilder expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Error.ToString());

        //        Init(new CultureInfo(culture));

        //        param = "DBFileNameTest";
        //        shouldHaveValue = "{AppDataPath}\\CSSP\\GenerateCodeStatusTest.db";
        //        CheckIfExist = false;
        //        await validateAppSettingsService.CheckFileParameterValue(param, shouldHaveValue, CheckIfExist);
        //        expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.OK }\t{ param } == { shouldHaveValue }");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Status.ToString());

        //        Init(new CultureInfo(culture));

        //        param = "DBFileNameTest";
        //        shouldHaveValue = "{AppDataPath}\\CSSP\\GenerateCodeStatusTest.db";
        //        CheckIfExist = true;
        //        await validateAppSettingsService.CheckFileParameterValue(param, shouldHaveValue, CheckIfExist);
        //        expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.OK }\t{ param } == { shouldHaveValue }");

        //        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //        FileInfo fiDB = new FileInfo(shouldHaveValue.Replace("{AppDataPath}", appDataPath));

        //        expected.AppendLine($"{ AppRes.OK }\t{ AppRes.Exist }\t{ fiDB.FullName }");
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Status.ToString());

        //        Init(new CultureInfo(culture));

        //        param = "DBFileNameTest2";
        //        shouldHaveValue = "{AppDataPath}\\CSSP\\GenerateCodeStatusTest_NotExist.db";
        //        CheckIfExist = true;
        //        await validateAppSettingsService.CheckFileParameterValue(param, shouldHaveValue, CheckIfExist);
        //        expected = new StringBuilder();
        //        expected.AppendLine($"{ AppRes.OK }\t{ param } == { shouldHaveValue }");

        //        appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //        fiDB = new FileInfo(shouldHaveValue.Replace("{AppDataPath}", appDataPath));

        //        StringBuilder expError = new StringBuilder();
        //        expError.AppendLine($"{ AppRes.Error }\t{ AppRes.DoesNotExist }\t{ fiDB.FullName }");
        //        Assert.Equal(expError.ToString(), generateCodeStatusDBService.Error.ToString());
        //        Assert.Equal(expected.ToString(), generateCodeStatusDBService.Status.ToString());
        //    }
        //}
        [Fact]
        public void ValidateAppSettingsServiceVerifyAppSettingsTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
                {
                    new AppSettingParameter() { Parameter = "Command", ExpectedValue = "GenerateCodeBase.Tests" },
                    new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                    new AppSettingParameter() { Parameter = "DBFileNameTest", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatusTest.db", IsFile = true, CheckExist = true },
                    //new AppSettingParameter() { Parameter = "DBFileNameTest2", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeBaseTest_NotExist.db", IsFile = true, CheckExist = true },
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

                /*await*/ validateAppSettingsService.VerifyAppSettings();
                Assert.Equal("", generateCodeStatusDBService.Error.ToString());
            }
        }
        [Fact]
        public void ValidateAppSettingsServiceSetCultureTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                /*await*/ validateAppSettingsService.SetCulture(new CultureInfo(culture));
                Assert.Equal(new CultureInfo(culture), validateAppSettingsService.Culture);
                Assert.Equal(new CultureInfo(culture), AppRes.Culture);
            }
        }
        #endregion Functions public
    }
}
