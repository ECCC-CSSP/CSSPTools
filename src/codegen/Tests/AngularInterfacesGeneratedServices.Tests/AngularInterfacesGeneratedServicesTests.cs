using AngularInterfacesGeneratedServices.Services;
using CSSPModels;
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

namespace AngularInterfacesGeneratedServices.Tests
{
    public class AngularInterfacesGeneratedServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IAngularInterfacesGeneratedService angularInterfacesGeneratedService { get; set; }
        private IServiceProvider provider { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public AngularInterfacesGeneratedServicesTests()
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
            Assert.NotNull(angularInterfacesGeneratedService);

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

            bool retBool = angularInterfacesGeneratedService.Run(args).GetAwaiter().GetResult();
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
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            serviceCollection.AddSingleton<IAngularInterfacesGeneratedService, AngularInterfacesGeneratedService>();

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

            angularInterfacesGeneratedService = provider.GetService<IAngularInterfacesGeneratedService>();
            Assert.NotNull(angularInterfacesGeneratedService);
        }
        #endregion Functions private
    }

}
