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
    public partial class ExecuteDotNetCommandServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IExecuteDotNetCommandService executeDotNetCommandService { get; set; }
        private IServiceProvider provider { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public ExecuteDotNetCommandServiceTests()
        {
            Init();
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public void ExecuteDotNetCommandServices_Constructors_Good_Test(string culture)
        {
            Init();

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(executeDotNetCommandService);

            string[] args = new List<string>() { culture, "run", "EnumsCompareWithOldEnums" }.ToArray();

            Assert.Equal(culture, args[0]);
        }
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("es-TU")] // good will default to en-CA
        [InlineData("en-GB")] // good will default to en-CA
        public void ExecuteDotNetCommandServices_Run_EnumsCompareWithOldEnums_Good_Test(string culture)
        {
            Init();

            string[] args = new List<string>() { culture, "run", "EnumsCompareWithOldEnums" }.ToArray();

            bool retBool = executeDotNetCommandService.Run(args).GetAwaiter().GetResult();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("es-TU")] // good will default to en-CA
        [InlineData("en-GB")] // good will default to en-CA
        public void ExecuteDotNetCommandServices_Build_CSSPEnums_Good_Test(string culture)
        {
            Init();

            string[] args = new List<string>() { culture, "build", "CSSPEnums" }.ToArray();

            bool retBool = executeDotNetCommandService.Run(args).GetAwaiter().GetResult();
            Assert.True(retBool);
        }
        #endregion Functions public

        #region Functions private
        private void Init()
        {
            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Assert.NotNull(configuration);

            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Assert.False(string.IsNullOrWhiteSpace(appDataPath));

            string fileName = configuration.GetValue<string>(DBFileName);
            Assert.False(string.IsNullOrWhiteSpace(fileName));

            FileInfo fiDB = new FileInfo(fileName.Replace("{AppDataPath}", appDataPath));
            Assert.True(fiDB.Exists);

            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            provider = serviceCollection.BuildServiceProvider();
            Assert.NotNull(provider);

            executeDotNetCommandService = provider.GetService<IExecuteDotNetCommandService>();
            Assert.NotNull(executeDotNetCommandService);
        }
        #endregion Functions private
    }

}
