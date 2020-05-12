using GenerateCodeBaseServices.Services;
using GenerateCodeBaseServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Xunit;
using ActionCommandDBServices.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GenerateCodeBaseServices.Tests
{
    public partial class GenerateCodeBaseServicesTests
    {
        #region Variables
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IGenerateCodeBaseService generateCodeBaseService { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public GenerateCodeBaseServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public void GenerateCodeBaseService_Constructors_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(actionCommandDBService);
            Assert.NotNull(generateCodeBaseService);

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

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>("DBFileName").Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                Assert.True(fiDB.Exists);
            }

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<ActionCommandContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            serviceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();

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

            generateCodeBaseService = provider.GetService<IGenerateCodeBaseService>();
            if (generateCodeBaseService == null)
            {
                Assert.NotNull(generateCodeBaseService);
            }
            generateCodeBaseService.SetCulture(culture);
        }
        #endregion Functions private
    }

}
