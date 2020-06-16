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
    public partial class PolSourceGroupingServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IPolSourceGroupingService PolSourceGroupingService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceGrouping_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               PolSourceGrouping polSourceGrouping = GetFilledRandomPolSourceGrouping(""); 

               // List<PolSourceGrouping>
               var actionPolSourceGroupingList = await PolSourceGroupingService.GetPolSourceGroupingList();
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingList.Result).Value);
               List<PolSourceGrouping> polSourceGroupingList = (List<PolSourceGrouping>)((OkObjectResult)actionPolSourceGroupingList.Result).Value;

               int count = ((List<PolSourceGrouping>)((OkObjectResult)actionPolSourceGroupingList.Result).Value).Count();
                Assert.True(count > 0);

               // Post PolSourceGrouping
               var actionPolSourceGroupingAdded = await PolSourceGroupingService.Post(polSourceGrouping);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingAdded.Result).Value);
               PolSourceGrouping polSourceGroupingAdded = (PolSourceGrouping)((OkObjectResult)actionPolSourceGroupingAdded.Result).Value;
               Assert.NotNull(polSourceGroupingAdded);

               // Put PolSourceGrouping
               var actionPolSourceGroupingUpdated = await PolSourceGroupingService.Put(polSourceGrouping);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingUpdated.Result).Value);
               PolSourceGrouping polSourceGroupingUpdated = (PolSourceGrouping)((OkObjectResult)actionPolSourceGroupingUpdated.Result).Value;
               Assert.NotNull(polSourceGroupingUpdated);

               // Delete PolSourceGrouping
               var actionPolSourceGroupingDeleted = await PolSourceGroupingService.Delete(polSourceGrouping.PolSourceGroupingID);
               Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceGroupingDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionPolSourceGroupingDeleted.Result).Value;
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
            Services.AddSingleton<IPolSourceGroupingService, PolSourceGroupingService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            PolSourceGroupingService = Provider.GetService<IPolSourceGroupingService>();
            Assert.NotNull(PolSourceGroupingService);

            return await Task.FromResult(true);
        }
        private PolSourceGrouping GetFilledRandomPolSourceGrouping(string OmitPropName)
        {
            PolSourceGrouping polSourceGrouping = new PolSourceGrouping();

            if (OmitPropName != "CSSPID") polSourceGrouping.CSSPID = GetRandomInt(10000, 100000);
            if (OmitPropName != "GroupName") polSourceGrouping.GroupName = GetRandomString("", 5);
            if (OmitPropName != "Child") polSourceGrouping.Child = GetRandomString("", 5);
            if (OmitPropName != "Hide") polSourceGrouping.Hide = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceGrouping.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceGrouping.LastUpdateContactTVItemID = 2;

            return polSourceGrouping;
        }
        #endregion Functions private
    }
}
