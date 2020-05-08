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
                    new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
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
