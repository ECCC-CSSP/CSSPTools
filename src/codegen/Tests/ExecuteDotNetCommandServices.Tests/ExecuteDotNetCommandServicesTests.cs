using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Services;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
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

namespace ExecuteDotNetCommandServices.Tests
{
    public partial class ExecuteDotNetCommandServicesTests
    {
        #region Variables
        public static IConfiguration configuration;
        public static IServiceCollection serviceCollection;
        public static IGenerateCodeStatusDBService generateCodeStatusDBService;
        public static IValidateAppSettingsService validateAppSettingsService;
        public static IExecuteDotNetCommandService executeDotNetCommandService;
        #endregion Variables

        #region Properties
        private DotNetCommand dotNetCommand;
        #endregion Properties

        #region Constructors
        public ExecuteDotNetCommandServicesTests()
        {
            Setup();
            Init(new CultureInfo("en-CA"));
        }
        #endregion Constructors

        #region Functions public
        [Fact]
        public void ExecuteDotNetCommandServicesConstructorsOKTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                Assert.NotNull(configuration);
                Assert.NotNull(serviceCollection);
                Assert.NotNull(generateCodeStatusDBService);
                Assert.NotNull(validateAppSettingsService);
                Assert.NotNull(executeDotNetCommandService);

                Assert.Equal(new CultureInfo(culture), generateCodeStatusDBService.Culture);
                Assert.Equal("ExecuteDotNetCommandServices.Tests", generateCodeStatusDBService.Command);
                Assert.Equal("", generateCodeStatusDBService.Error.ToString());
                Assert.Equal("", generateCodeStatusDBService.Status.ToString());

                Assert.Equal(new List<AppSettingParameter>(), validateAppSettingsService.AppSettingParameterList);
            }
        }
        [Fact]
        public void ExecuteDotNetCommandServicesRunOKTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                string[] args = new List<string>() { culture, "run", "EnumsCompareWithOldEnums" }.ToArray();

                executeDotNetCommandService.Run(args);
                Assert.Equal("", generateCodeStatusDBService.Error.ToString());
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

            FileInfo fiDB = new FileInfo($"{appDataPath}\\CSSP\\GenerateCodeStatusTest.db");

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            serviceCollection.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            executeDotNetCommandService = provider.GetService<IExecuteDotNetCommandService>();

            dotNetCommand = new DotNetCommand()
            {
                CultureName = "en-CA",
                Action = "run",
                SolutionFileName = @"C:\CSSPTools\src\codegen\EnumsCompareWithOldEnums\bin\Debug\netcoreapp3.1\EnumsCompareWithOldEnums.exe"
            };

        }
        #endregion Functions private
    }

}
