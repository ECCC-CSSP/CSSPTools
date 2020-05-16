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
using Microsoft.AspNetCore.Mvc;
using CultureServices.Resources;

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
        public async Task GenerateCodeBaseService_Constructors_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(actionCommandDBService);
            Assert.NotNull(generateCodeBaseService);

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
            Assert.NotNull(provider);

            actionCommandDBService = provider.GetService<IActionCommandDBService>();
            Assert.NotNull(actionCommandDBService);

            await actionCommandDBService.SetCulture(culture);
            Assert.Equal(culture, CultureServicesRes.Culture);

            generateCodeBaseService = provider.GetService<IGenerateCodeBaseService>();
            Assert.NotNull(generateCodeBaseService);

            await generateCodeBaseService.SetCulture(culture);
            Assert.Equal(culture, CultureServicesRes.Culture);
        }
        #endregion Functions private
    }

}
