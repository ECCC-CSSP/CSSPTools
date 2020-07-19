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
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;

namespace GenerateCodeBaseServices.Tests
{
    public partial class GenerateCodeBaseServicesTests
    {
        #region Variables
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IGenerateCodeBaseService GenerateCodeBaseService { get; set; }
        private IActionCommandDBService ActionCommandDBService { get; set; }
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
        //[InlineData("fr-CA")]
        public async Task GenerateCodeBaseService_Constructors_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(ServiceCollection);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(ActionCommandDBService);
            Assert.NotNull(GenerateCodeBaseService);

            Assert.Equal(new CultureInfo(culture), CSSPCultureServicesRes.Culture);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            ServiceCollection = new ServiceCollection();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo(Configuration.GetValue<string>("DBFileName").Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                Assert.True(fiDB.Exists);
            }

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddDbContext<ActionCommandContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
            ServiceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();

            ServiceProvider provider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(provider);

            CSSPCultureService = provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ActionCommandDBService = provider.GetService<IActionCommandDBService>();
            Assert.NotNull(ActionCommandDBService);

            GenerateCodeBaseService = provider.GetService<IGenerateCodeBaseService>();
            Assert.NotNull(GenerateCodeBaseService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
