using AngularEnumsGeneratedServices.Services;
using CSSPModels;
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

namespace AngularEnumsGeneratedServices.Tests
{
    public class AngularEnumsGeneratedServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IAngularEnumsGeneratedService angularEnumsGeneratedService { get; set; }
        private IServiceProvider provider { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public AngularEnumsGeneratedServicesTests()
        {
            Init();
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public void AngularEnumsGeneratedService_Constructor_Good_Test(string culture)
        {
            Init();

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(provider);
            Assert.NotNull(angularEnumsGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.Equal(culture, args[0]);
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("es-TU")] // good will default to en-CA
        //[InlineData("en-GB")] // good will default to en-CA
        public void AngularEnumsGeneratedService_Run_Good_Test(string culture)
        {
            Init();

            string[] args = new List<string>() { culture }.ToArray();

            bool retBool = angularEnumsGeneratedService.Run(args).GetAwaiter().GetResult();
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
            serviceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            serviceCollection.AddSingleton<IAngularEnumsGeneratedService, AngularEnumsGeneratedService>();

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

            angularEnumsGeneratedService = provider.GetService<IAngularEnumsGeneratedService>();
            Assert.NotNull(angularEnumsGeneratedService);
        }
        #endregion Functions private
    }

}
