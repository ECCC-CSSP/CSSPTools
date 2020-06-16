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
    public partial class TVItemServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ITVItemService TVItemService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItem_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               TVItem tvItem = GetFilledRandomTVItem(""); 

               // List<TVItem>
               var actionTVItemList = await TVItemService.GetTVItemList();
               Assert.Equal(200, ((ObjectResult)actionTVItemList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemList.Result).Value);
               List<TVItem> tvItemList = (List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value;

               int count = ((List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value).Count();
                Assert.True(count > 0);

               // Post TVItem
               var actionTVItemAdded = await TVItemService.Post(tvItem);
               Assert.Equal(200, ((ObjectResult)actionTVItemAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemAdded.Result).Value);
               TVItem tvItemAdded = (TVItem)((OkObjectResult)actionTVItemAdded.Result).Value;
               Assert.NotNull(tvItemAdded);

               // Put TVItem
               var actionTVItemUpdated = await TVItemService.Put(tvItem);
               Assert.Equal(200, ((ObjectResult)actionTVItemUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemUpdated.Result).Value);
               TVItem tvItemUpdated = (TVItem)((OkObjectResult)actionTVItemUpdated.Result).Value;
               Assert.NotNull(tvItemUpdated);

               // Delete TVItem
               var actionTVItemDeleted = await TVItemService.Delete(tvItem.TVItemID);
               Assert.Equal(200, ((ObjectResult)actionTVItemDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionTVItemDeleted.Result).Value;
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
            Services.AddSingleton<ITVItemService, TVItemService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            TVItemService = Provider.GetService<ITVItemService>();
            Assert.NotNull(TVItemService);

            return await Task.FromResult(true);
        }
        private TVItem GetFilledRandomTVItem(string OmitPropName)
        {
            TVItem tvItem = new TVItem();

            if (OmitPropName != "TVLevel") tvItem.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItem.TVPath = GetRandomString("", 5);
            if (OmitPropName != "TVType") tvItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") tvItem.ParentID = 1;
            if (OmitPropName != "IsActive") tvItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = 2;

            return tvItem;
        }
        #endregion Functions private
    }
}
