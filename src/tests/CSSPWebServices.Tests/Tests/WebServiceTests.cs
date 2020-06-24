using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CSSPWebServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;

namespace CSSPServices.Tests
{
    public partial class WebServiceTests : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IWebService WebService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public WebServiceTests() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebRoot = await WebService.GetWebRoot();
            Assert.Equal(200, ((ObjectResult)actionWebRoot.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebRoot.Result).Value);
            WebRoot webRoot = (WebRoot)((OkObjectResult)actionWebRoot.Result).Value;
            Assert.NotNull(webRoot);
            Assert.NotNull(webRoot.TVItemList);
            Assert.NotNull(webRoot.TVItemLanguageList);
            Assert.NotNull(webRoot.TVItemStatList);
            Assert.NotNull(webRoot.MapInfoList);
            Assert.NotNull(webRoot.MapInfoPointList);
        }
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task GetWebCountry_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    var actionWebCountry = await WebService.GetWebCountry();
        //    Assert.Equal(200, ((ObjectResult)actionWebCountry.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionWebCountry.Result).Value);
        //    WebCountry webCountry = (WebCountry)((OkObjectResult)actionWebCountry.Result).Value;
        //    Assert.NotNull(webCountry);
        //    Assert.NotNull(webCountry.TVItemList);
        //    Assert.NotNull(webCountry.TVItemLanguageList);
        //    Assert.NotNull(webCountry.TVItemStatList);
        //    Assert.NotNull(webCountry.MapInfoList);
        //    Assert.NotNull(webCountry.MapInfoPointList);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task GetWebArea_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    var actionWebArea = await WebService.GetWebArea();
        //    Assert.Equal(200, ((ObjectResult)actionWebArea.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionWebArea.Result).Value);
        //    WebArea webArea = (WebArea)((OkObjectResult)actionWebArea.Result).Value;
        //    Assert.NotNull(webArea);
        //    Assert.NotNull(webArea.TVItemList);
        //    Assert.NotNull(webArea.TVItemLanguageList);
        //    Assert.NotNull(webArea.TVItemStatList);
        //    Assert.NotNull(webArea.MapInfoList);
        //    Assert.NotNull(webArea.MapInfoPointList);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task GetWebSector_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    var actionWebSector = await WebService.GetWebSector();
        //    Assert.Equal(200, ((ObjectResult)actionWebSector.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionWebSector.Result).Value);
        //    WebSector webSector = (WebSector)((OkObjectResult)actionWebSector.Result).Value;
        //    Assert.NotNull(webSector);
        //    Assert.NotNull(webSector.TVItemList);
        //    Assert.NotNull(webSector.TVItemLanguageList);
        //    Assert.NotNull(webSector.TVItemStatList);
        //    Assert.NotNull(webSector.MapInfoList);
        //    Assert.NotNull(webSector.MapInfoPointList);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task GetWebSubsector_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    var actionWebSubsector = await WebService.GetWebSubsector();
        //    Assert.Equal(200, ((ObjectResult)actionWebSubsector.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionWebSubsector.Result).Value);
        //    WebSubsector webSubsector = (WebSubsector)((OkObjectResult)actionWebSubsector.Result).Value;
        //    Assert.NotNull(webSubsector);
        //    Assert.NotNull(webSubsector.TVItemList);
        //    Assert.NotNull(webSubsector.TVItemLanguageList);
        //    Assert.NotNull(webSubsector.TVItemStatList);
        //    Assert.NotNull(webSubsector.MapInfoList);
        //    Assert.NotNull(webSubsector.MapInfoPointList);
        //}
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("CSSPDBConnectionString");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IWebService, WebService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            try
            {
                WebService = Provider.GetService<IWebService>();
                Assert.NotNull(WebService);

            }
            catch (Exception ex)
            {

                throw;
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
