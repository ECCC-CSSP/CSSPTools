/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
    public partial class TideSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ITideSiteService TideSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TideSite_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               TideSite tideSite = GetFilledRandomTideSite(""); 

               // List<TideSite>
               var actionTideSiteList = await TideSiteService.GetTideSiteList();
               Assert.Equal(200, ((ObjectResult)actionTideSiteList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSiteList.Result).Value);
               List<TideSite> tideSiteList = (List<TideSite>)((OkObjectResult)actionTideSiteList.Result).Value;

               int count = ((List<TideSite>)((OkObjectResult)actionTideSiteList.Result).Value).Count();
                Assert.True(count > 0);

               // Post TideSite
               var actionTideSiteAdded = await TideSiteService.Post(tideSite);
               Assert.Equal(200, ((ObjectResult)actionTideSiteAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSiteAdded.Result).Value);
               TideSite tideSiteAdded = (TideSite)((OkObjectResult)actionTideSiteAdded.Result).Value;
               Assert.NotNull(tideSiteAdded);

               // Put TideSite
               var actionTideSiteUpdated = await TideSiteService.Put(tideSite);
               Assert.Equal(200, ((ObjectResult)actionTideSiteUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSiteUpdated.Result).Value);
               TideSite tideSiteUpdated = (TideSite)((OkObjectResult)actionTideSiteUpdated.Result).Value;
               Assert.NotNull(tideSiteUpdated);

               // Delete TideSite
               var actionTideSiteDeleted = await TideSiteService.Delete(tideSite.TideSiteID);
               Assert.Equal(200, ((ObjectResult)actionTideSiteDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSiteDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionTideSiteDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
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

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITideSiteService, TideSiteService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            TideSiteService = Provider.GetService<ITideSiteService>();
            Assert.NotNull(TideSiteService);

            return await Task.FromResult(true);
        }
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            TideSite tideSite = new TideSite();

            if (OmitPropName != "TideSiteTVItemID") tideSite.TideSiteTVItemID = 38;
            if (OmitPropName != "TideSiteName") tideSite.TideSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") tideSite.Province = GetRandomString("", 2);
            if (OmitPropName != "sid") tideSite.sid = GetRandomInt(0, 10000);
            if (OmitPropName != "Zone") tideSite.Zone = GetRandomInt(0, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = 2;

            return tideSite;
        }
        #endregion Functions private
    }
}
