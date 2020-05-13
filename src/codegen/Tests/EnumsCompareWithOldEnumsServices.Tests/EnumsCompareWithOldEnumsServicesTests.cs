using EnumsCompareWithOldEnumsServices.Resources;
using EnumsCompareWithOldEnumsServices.Services;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAppSettingsServices.Services;
using ActionCommandDBServices.Resources;
using ValidateAppSettingsServices.Resources;

namespace EnumsCompareWithOldEnumsServices.Tests
{
    public class EnumsCompareWithOldEnumsServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IServiceProvider provider { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EnumsCompareWithOldEnumsServices_Constructor_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(provider);
            Assert.NotNull(enumsCompareWithOldEnumsService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.Equal(culture, args[0]);
        }
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("es-TU")] // good will default to en-CA
        [InlineData("en-GB")] // good will default to en-CA
        public async Task EnumsCompareWithOldEnumsServices_Run_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            string[] args = new List<string>() { culture }.ToArray();

            bool retBool = enumsCompareWithOldEnumsService.Run(args).GetAwaiter().GetResult();
            Assert.True(retBool);
        }
        #endregion Functions public

        #region Functions private
        private async Task Setup(CultureInfo culture)
        {
            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Assert.NotNull(configuration);

            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Assert.False(string.IsNullOrWhiteSpace(appDataPath));

            string fileName = configuration.GetValue<string>(DBFileName);
            Assert.False(string.IsNullOrWhiteSpace(fileName));

            FileInfo fiDB = new FileInfo(fileName.Replace("{AppDataPath}", appDataPath));
            Assert.True(fiDB.Exists);

            serviceCollection.AddDbContext<ActionCommandContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            provider = serviceCollection.BuildServiceProvider();
            Assert.NotNull(provider);

            enumsCompareWithOldEnumsService = provider.GetService<IEnumsCompareWithOldEnumsService>();
            Assert.NotNull(enumsCompareWithOldEnumsService);

            await enumsCompareWithOldEnumsService.SetCulture(culture);
            Assert.Equal(culture, EnumsCompareWithOldEnumsServicesRes.Culture);

            actionCommandDBService = provider.GetService<IActionCommandDBService>();
            Assert.NotNull(actionCommandDBService);

            await actionCommandDBService.SetCulture(culture);
            Assert.Equal(culture, ActionCommandDBServicesRes.Culture);

            validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            Assert.NotNull(validateAppSettingsService);

            await validateAppSettingsService.SetCulture(culture);
            Assert.Equal(culture, ValidateAppSettingsServicesRes.Culture);

        }
        #endregion Functions private
    }

}
