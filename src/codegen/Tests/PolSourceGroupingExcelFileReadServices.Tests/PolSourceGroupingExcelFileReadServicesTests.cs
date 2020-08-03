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
using PolSourceGroupingExcelFileReadServices.Services;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;

namespace PolSourceGroupingExcelFileReadServices.Tests
{
    public class PolSourceGroupingExcelFileReadServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private IPolSourceGroupingExcelFileReadService PolSourceGroupingExcelFileReadService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IActionCommandDBService ActionCommandDBService { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        private string ExcelFileName { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingExcelFileReadServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task PolSourceGroupingExcelFileReadService_ReadExcelSheet_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(ServiceCollection);
            Assert.NotNull(ServiceProvider);
            Assert.NotNull(PolSourceGroupingExcelFileReadService);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(ActionCommandDBService);

            bool retBool = await PolSourceGroupingExcelFileReadService.ReadExcelSheet(ExcelFileName, false);
            Assert.True(retBool);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            Assert.NotNull(Configuration);

            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            ServiceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            ServiceCollection.AddSingleton<IPolSourceGroupingExcelFileReadService, PolSourceGroupingExcelFileReadService>();

            Assert.NotNull(Configuration.GetValue<string>(DBFileName));

            FileInfo fiDB = new FileInfo(Configuration.GetValue<string>(DBFileName));
            Assert.True(fiDB.Exists);

            ServiceCollection.AddDbContext<ActionCommandContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ActionCommandDBService = ServiceProvider.GetService<IActionCommandDBService>();
            Assert.NotNull(ActionCommandDBService);

            ExcelFileName = Configuration.GetValue<string>("ExcelFileName");
            Assert.False(string.IsNullOrWhiteSpace(ExcelFileName));

            PolSourceGroupingExcelFileReadService = ServiceProvider.GetService<IPolSourceGroupingExcelFileReadService>();
            Assert.NotNull(PolSourceGroupingExcelFileReadService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
