using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using CultureServices.Resources;
using CultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;
using Xunit;

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
        private ICultureService CultureService { get; set; }
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
        //[InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_CheckFileParameterValue_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string param = "DBFileName";
            string shouldHaveValue = "{AppDataPath}\\CSSP\\ActionCommandDB_NotExist.db";

            validateAppSettingsService.AppSettingParameterList[1].ExpectedValue = shouldHaveValue;

            bool retBool = await validateAppSettingsService.VerifyAppSettings();
            Assert.False(retBool);
            string expected = (new StringBuilder()).AppendLine($"{ CultureServicesRes.Error }\t{ param } != { shouldHaveValue }").ToString();
            string value = actionCommandDBService.ErrorText.ToString();
            Assert.Equal(expected, value);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            serviceCollection = new ServiceCollection();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<ICultureService, CultureService>();
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            ConfigureGenerateCodeStatusContext();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            if (provider == null)
            {
                Assert.NotNull(provider);
            }

            CultureService = provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            if (CultureService.AllowableCultures.Contains(culture))
            {
                Assert.Equal(new CultureInfo(culture), CultureEnumsRes.Culture);
                Assert.Equal(new CultureInfo(culture), CultureModelsRes.Culture);
                Assert.Equal(new CultureInfo(culture), CulturePolSourcesRes.Culture);
                Assert.Equal(new CultureInfo(culture), CultureServicesRes.Culture);
            }
            else
            {
                Assert.Equal(new CultureInfo(CultureService.AllowableCultures[0]), CultureEnumsRes.Culture);
                Assert.Equal(new CultureInfo(CultureService.AllowableCultures[0]), CultureModelsRes.Culture);
                Assert.Equal(new CultureInfo(CultureService.AllowableCultures[0]), CulturePolSourcesRes.Culture);
                Assert.Equal(new CultureInfo(CultureService.AllowableCultures[0]), CultureServicesRes.Culture);
            }

            actionCommandDBService = provider.GetService<IActionCommandDBService>();
            Assert.NotNull(actionCommandDBService);

            validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            Assert.NotNull(validateAppSettingsService);

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\cssp\\cssplocaldatabases\\ActionCommandDB.db", IsFile = true, CheckExist = true },
            };

            return await Task.FromResult(true);
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
