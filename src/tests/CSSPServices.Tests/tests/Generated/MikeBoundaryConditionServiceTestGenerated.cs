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
    public partial class MikeBoundaryConditionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IMikeBoundaryConditionService MikeBoundaryConditionService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeBoundaryCondition_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               MikeBoundaryCondition mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition(""); 

               // List<MikeBoundaryCondition>
               var actionMikeBoundaryConditionList = await MikeBoundaryConditionService.GetMikeBoundaryConditionList();
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionList.Result).Value);
               List<MikeBoundaryCondition> mikeBoundaryConditionList = (List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionList.Result).Value;

               int count = ((List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionList.Result).Value).Count();
                Assert.True(count > 0);

               // Post MikeBoundaryCondition
               var actionMikeBoundaryConditionAdded = await MikeBoundaryConditionService.Post(mikeBoundaryCondition);
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionAdded.Result).Value);
               MikeBoundaryCondition mikeBoundaryConditionAdded = (MikeBoundaryCondition)((OkObjectResult)actionMikeBoundaryConditionAdded.Result).Value;
               Assert.NotNull(mikeBoundaryConditionAdded);

               // Put MikeBoundaryCondition
               var actionMikeBoundaryConditionUpdated = await MikeBoundaryConditionService.Put(mikeBoundaryCondition);
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionUpdated.Result).Value);
               MikeBoundaryCondition mikeBoundaryConditionUpdated = (MikeBoundaryCondition)((OkObjectResult)actionMikeBoundaryConditionUpdated.Result).Value;
               Assert.NotNull(mikeBoundaryConditionUpdated);

               // Delete MikeBoundaryCondition
               var actionMikeBoundaryConditionDeleted = await MikeBoundaryConditionService.Delete(mikeBoundaryCondition.MikeBoundaryConditionID);
               Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionMikeBoundaryConditionDeleted.Result).Value;
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
            Services.AddSingleton<IMikeBoundaryConditionService, MikeBoundaryConditionService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            MikeBoundaryConditionService = Provider.GetService<IMikeBoundaryConditionService>();
            Assert.NotNull(MikeBoundaryConditionService);

            return await Task.FromResult(true);
        }
        private MikeBoundaryCondition GetFilledRandomMikeBoundaryCondition(string OmitPropName)
        {
            MikeBoundaryCondition mikeBoundaryCondition = new MikeBoundaryCondition();

            if (OmitPropName != "MikeBoundaryConditionTVItemID") mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 52;
            if (OmitPropName != "MikeBoundaryConditionCode") mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionName") mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLength_m") mikeBoundaryCondition.MikeBoundaryConditionLength_m = GetRandomDouble(1.0D, 100000.0D);
            if (OmitPropName != "MikeBoundaryConditionFormat") mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLevelOrVelocity") mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)GetRandomEnumType(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            if (OmitPropName != "WebTideDataSet") mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "NumberOfWebTideNodes") mikeBoundaryCondition.NumberOfWebTideNodes = GetRandomInt(0, 1000);
            if (OmitPropName != "WebTideDataFromStartToEndDate") mikeBoundaryCondition.WebTideDataFromStartToEndDate = GetRandomString("", 20);
            if (OmitPropName != "TVType") mikeBoundaryCondition.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeBoundaryCondition.LastUpdateContactTVItemID = 2;

            return mikeBoundaryCondition;
        }
        #endregion Functions private
    }
}
