using GenerateCodeBase.Services;
using GenerateCodeBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace GenerateCodeBase.Tests
{
    public partial class GenerateCodeBaseTests
    {
        #region Variables
        public static IConfiguration configuration;
        public static IServiceCollection serviceCollection;
        public static IGenerateCodeBaseService generateCodeBaseService;
        public static IGenerateCodeStatusDBService generateCodeStatusDBService;
        public static IValidateAppSettingsService validateAppSettingsService;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public GenerateCodeBaseTests()
        {
            Setup();
            Init(new CultureInfo("en-CA"));
        }
        #endregion Constructors

        #region Functions public
        [Fact]
        public void GenerateCodeBaseConstructorsOKTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                Assert.NotNull(configuration);
                Assert.NotNull(serviceCollection);
                Assert.NotNull(generateCodeStatusDBService);
                Assert.NotNull(generateCodeBaseService);
                Assert.NotNull(validateAppSettingsService);

                Assert.Equal(new CultureInfo(culture), generateCodeStatusDBService.Culture);
                Assert.Equal("GenerateCodeBase.Tests", generateCodeStatusDBService.Command);
                Assert.Equal("", generateCodeStatusDBService.Error.ToString());
                Assert.Equal("", generateCodeStatusDBService.Status.ToString());

                Assert.Equal(new List<AppSettingParameter>(), validateAppSettingsService.AppSettingParameterList);
            }
        }
        #endregion Functions public

        #region Functions private
        private void Init(CultureInfo culture)
        {
            generateCodeStatusDBService.Culture = culture;
            generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
            generateCodeStatusDBService.Error = new StringBuilder();
            generateCodeStatusDBService.Status = new StringBuilder();

            validateAppSettingsService.Culture = culture;
            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>();
        }
        private void Setup()
        {
            serviceCollection = new ServiceCollection();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>("DBFileNameTest").Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                Assert.True(fiDB.Exists);
            }

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            serviceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            if (provider == null)
            {
                Assert.NotNull(provider);
            }

            generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            if (generateCodeStatusDBService == null)
            {
                Assert.NotNull(generateCodeStatusDBService);
            }

            generateCodeBaseService = provider.GetService<IGenerateCodeBaseService>();
            if (generateCodeBaseService == null)
            {
                Assert.NotNull(generateCodeBaseService);
            }

            validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            if (validateAppSettingsService == null)
            {
                Assert.NotNull(validateAppSettingsService);
            }
        }
        #endregion Functions private
    }

}
