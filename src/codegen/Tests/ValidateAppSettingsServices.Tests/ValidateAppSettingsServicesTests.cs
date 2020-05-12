using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Resources;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidateAppSettingsServices.Services;
using Microsoft.EntityFrameworkCore;
using ActionCommandDBServices.Services;
using ActionCommandDBServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ValidateAppSettingsServices.Tests
{
    public partial class ValidateAppSettingsServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public ValidateAppSettingsServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_CheckParameterExist_Error_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            string param = "Command_NotExist";

            validateAppSettingsService.AppSettingParameterList[0].Parameter = param;

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.False(retBool);
            string expected = (new StringBuilder()).AppendLine($"{ AppRes.Error }\t{ param } != { AppRes.CouldNotFindParameter }").ToString();
            string value = actionCommandDBService.ErrorText.ToString();
            Assert.Contains(expected, value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_CheckParameterValue_Error_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            string param = "Command";
            string shouldHaveValue = "Error_ValidateAppSettingsServices.Tests";

            validateAppSettingsService.AppSettingParameterList[0].ExpectedValue = shouldHaveValue;

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.False(retBool);
            string expected = (new StringBuilder()).AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }").ToString();
            string value = actionCommandDBService.ErrorText.ToString();
            Assert.Equal(expected, value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_CheckFileParameterValue_Error_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            string param = "DBFileName";
            string shouldHaveValue = "{AppDataPath}\\CSSP\\ActionCommandDB_NotExist.db";

            validateAppSettingsService.AppSettingParameterList[2].ExpectedValue = shouldHaveValue;

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.False(retBool);
            string expected = (new StringBuilder()).AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }").ToString();
            string value = actionCommandDBService.ErrorText.ToString();
            Assert.Equal(expected, value);
        }
        [Theory]
        [InlineData("en-GB")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_CheckCultureParameterValue_Error_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public void ValidateAppSettingsService_SetCulture_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            validateAppSettingsService.SetCulture(new CultureInfo(culture));
            Assert.Equal(new CultureInfo(culture), AppRes.Culture);
        }
        #endregion Functions public

        #region Functions private
        private void Setup(CultureInfo culture)
        {
            AppRes.Culture = culture;
            serviceCollection = new ServiceCollection();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            ConfigureGenerateCodeStatusContext();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            if (provider == null)
            {
                Assert.NotNull(provider);
            }

            actionCommandDBService = provider.GetService<IActionCommandDBService>();
            if (actionCommandDBService == null)
            {
                Assert.NotNull(actionCommandDBService);
            }
            actionCommandDBService.SetCulture(culture);

            validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            if (validateAppSettingsService == null)
            {
                Assert.NotNull(validateAppSettingsService);
            }
            validateAppSettingsService.SetCulture(culture);

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ValidateAppSettingsServices.Tests" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
            };
        }
        private string ConfigureGenerateCodeStatusContext()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (configuration.GetValue<string>(DBFileName) == null)
            {
                return $"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }";
            }

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                return $"{ String.Format(AppRes.CouldNotFindFile_, fiDB.FullName) }";
            }

            try
            {
                serviceCollection.AddDbContext<ActionCommandContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        #endregion Functions private

    }
}
