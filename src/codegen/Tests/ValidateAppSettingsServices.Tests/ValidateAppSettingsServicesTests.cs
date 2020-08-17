using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
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
        private IConfiguration Configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IValidateAppSettingsService ValidateAppSettingsService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
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

            bool retBool = await ValidateAppSettingsService.VerifyAppSettings();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ValidateAppSettingsService_VerifyAppSettings_CheckFileParameterValue_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string param = "DBFileName";
            string shouldHaveValue = "C:\\CSSPDesktop\\ActionCommandDB_NotExist.db";

            ValidateAppSettingsService.AppSettingParameterList[1].ExpectedValue = shouldHaveValue;

            bool retBool = await ValidateAppSettingsService.VerifyAppSettings();
            Assert.False(retBool);
            string expected = (new StringBuilder()).AppendLine($"{ CSSPCultureServicesRes.Error }\t{ param } != { shouldHaveValue }").ToString();
            string value = actionCommandDBService.ErrorText.ToString();
            Assert.Equal(expected, value);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            serviceCollection = new ServiceCollection();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(Configuration);
            serviceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            ConfigureGenerateCodeStatusContext();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            if (provider == null)
            {
                Assert.NotNull(provider);
            }

            CSSPCultureService = provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            if (CSSPCultureService.AllowableCultures.Contains(culture))
            {
                Assert.Equal(new CultureInfo(culture), CSSPCultureEnumsRes.Culture);
                Assert.Equal(new CultureInfo(culture), CSSPCultureModelsRes.Culture);
                Assert.Equal(new CultureInfo(culture), CSSPCulturePolSourcesRes.Culture);
                Assert.Equal(new CultureInfo(culture), CSSPCultureServicesRes.Culture);
            }
            else
            {
                Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureEnumsRes.Culture);
                Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureModelsRes.Culture);
                Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCulturePolSourcesRes.Culture);
                Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureServicesRes.Culture);
            }

            actionCommandDBService = provider.GetService<IActionCommandDBService>();
            Assert.NotNull(actionCommandDBService);

            ValidateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            Assert.NotNull(ValidateAppSettingsService);

            ValidateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "CSSPCulture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "C:\\CSSPTools\\src\\assets\\ActionCommandDB.db", IsFile = true, CheckExist = true },
            };

            return await Task.FromResult(true);
        }
        private string ConfigureGenerateCodeStatusContext()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (Configuration.GetValue<string>(DBFileName) == null)
            {
                return $"{ String.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }";
            }

            FileInfo fiDB = new FileInfo(Configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                return $"{ String.Format(CSSPCultureServicesRes.CouldNotFindFile_, fiDB.FullName) }";
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
