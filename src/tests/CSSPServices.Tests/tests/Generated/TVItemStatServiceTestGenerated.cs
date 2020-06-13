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
    public partial class TVItemStatServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ITVItemStatService tvItemStatService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemStat_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               TVItemStat tvItemStat = GetFilledRandomTVItemStat(""); 

               // List<TVItemStat>
               var actionTVItemStatList = await tvItemStatService.GetTVItemStatList();
               Assert.Equal(200, ((ObjectResult)actionTVItemStatList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStatList.Result).Value);
               List<TVItemStat> tvItemStatList = (List<TVItemStat>)((OkObjectResult)actionTVItemStatList.Result).Value;

               int count = ((List<TVItemStat>)((OkObjectResult)actionTVItemStatList.Result).Value).Count();
                Assert.True(count > 0);

               // Add TVItemStat
               var actionTVItemStatAdded = await tvItemStatService.Add(tvItemStat);
               Assert.Equal(200, ((ObjectResult)actionTVItemStatAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStatAdded.Result).Value);
               TVItemStat tvItemStatAdded = (TVItemStat)((OkObjectResult)actionTVItemStatAdded.Result).Value;
               Assert.NotNull(tvItemStatAdded);

               // Update TVItemStat
               var actionTVItemStatUpdated = await tvItemStatService.Update(tvItemStat);
               Assert.Equal(200, ((ObjectResult)actionTVItemStatUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStatUpdated.Result).Value);
               TVItemStat tvItemStatUpdated = (TVItemStat)((OkObjectResult)actionTVItemStatUpdated.Result).Value;
               Assert.NotNull(tvItemStatUpdated);

               // Delete TVItemStat
               var actionTVItemStatDeleted = await tvItemStatService.Delete(tvItemStat.TVItemStatID);
               Assert.Equal(200, ((ObjectResult)actionTVItemStatDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStatDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionTVItemStatDeleted.Result).Value;
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
            Services.AddSingleton<ITVItemStatService, TVItemStatService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            tvItemStatService = Provider.GetService<ITVItemStatService>();
            Assert.NotNull(tvItemStatService);

            return await Task.FromResult(true);
        }
        private TVItemStat GetFilledRandomTVItemStat(string OmitPropName)
        {
            TVItemStat tvItemStat = new TVItemStat();

            if (OmitPropName != "TVItemID") tvItemStat.TVItemID = 1;
            if (OmitPropName != "TVType") tvItemStat.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ChildCount") tvItemStat.ChildCount = GetRandomInt(0, 10000000);
            if (OmitPropName != "LastUpdateDate_UTC") tvItemStat.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemStat.LastUpdateContactTVItemID = 2;

            return tvItemStat;
        }
        #endregion Functions private
    }
}
