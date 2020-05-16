using ValidateAppSettingsServices.Models;
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
using CultureServices.Resources;

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
            await Setup(new CultureInfo(culture));

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_CheckFileParameterValue_Error_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            string param = "DBFileName";
            string shouldHaveValue = "{AppDataPath}\\CSSP\\ActionCommandDB_NotExist.db";

            validateAppSettingsService.AppSettingParameterList[1].ExpectedValue = shouldHaveValue;

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.False(retBool);
            string expected = (new StringBuilder()).AppendLine($"{ CultureServicesRes.Error }\t{ param } != { shouldHaveValue }").ToString();
            string value = actionCommandDBService.ErrorText.ToString();
            Assert.Equal(expected, value);
        }
        [Theory]
        [InlineData("en-GB")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_CheckCultureParameterValue_Error_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_SetCulture_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await validateAppSettingsService.SetCulture(new CultureInfo(culture));
            Assert.Equal(new CultureInfo(culture), CultureServicesRes.Culture);
        }
        #endregion Functions public

        #region Functions private
        private async Task Setup(CultureInfo culture)
        {
            CultureServicesRes.Culture = culture;
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
            Assert.NotNull(actionCommandDBService);

            await actionCommandDBService.SetCulture(culture);
            Assert.Equal(culture, CultureServicesRes.Culture);

            validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            Assert.NotNull(validateAppSettingsService);

            await validateAppSettingsService.SetCulture(culture);
            Assert.Equal(culture, CultureServicesRes.Culture);

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
            };
        }
        private string ConfigureGenerateCodeStatusContext()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (configuration.GetValue<string>(DBFileName) == null)
            {
                return $"{ String.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }";
            }

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                return $"{ String.Format(CultureServicesRes.CouldNotFindFile_, fiDB.FullName) }";
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
