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
    public partial class MWQMSampleServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IMWQMSampleService MWQMSampleService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSample_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               MWQMSample mwqmSample = GetFilledRandomMWQMSample(""); 

               // List<MWQMSample>
               var actionMWQMSampleList = await MWQMSampleService.GetMWQMSampleList();
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleList.Result).Value);
               List<MWQMSample> mwqmSampleList = (List<MWQMSample>)((OkObjectResult)actionMWQMSampleList.Result).Value;

               int count = ((List<MWQMSample>)((OkObjectResult)actionMWQMSampleList.Result).Value).Count();
                Assert.True(count > 0);

               // Post MWQMSample
               var actionMWQMSampleAdded = await MWQMSampleService.Post(mwqmSample);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleAdded.Result).Value);
               MWQMSample mwqmSampleAdded = (MWQMSample)((OkObjectResult)actionMWQMSampleAdded.Result).Value;
               Assert.NotNull(mwqmSampleAdded);

               // Put MWQMSample
               var actionMWQMSampleUpdated = await MWQMSampleService.Put(mwqmSample);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleUpdated.Result).Value);
               MWQMSample mwqmSampleUpdated = (MWQMSample)((OkObjectResult)actionMWQMSampleUpdated.Result).Value;
               Assert.NotNull(mwqmSampleUpdated);

               // Delete MWQMSample
               var actionMWQMSampleDeleted = await MWQMSampleService.Delete(mwqmSample.MWQMSampleID);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionMWQMSampleDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMSampleService, MWQMSampleService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            MWQMSampleService = Provider.GetService<IMWQMSampleService>();
            Assert.NotNull(MWQMSampleService);

            return await Task.FromResult(true);
        }
        private MWQMSample GetFilledRandomMWQMSample(string OmitPropName)
        {
            MWQMSample mwqmSample = new MWQMSample();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSample.MWQMSiteTVItemID = 44;
            if (OmitPropName != "MWQMRunTVItemID") mwqmSample.MWQMRunTVItemID = 50;
            if (OmitPropName != "SampleDateTime_Local") mwqmSample.SampleDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "TimeText") mwqmSample.TimeText = GetRandomString("", 5);
            if (OmitPropName != "Depth_m") mwqmSample.Depth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "FecCol_MPN_100ml") mwqmSample.FecCol_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Salinity_PPT") mwqmSample.Salinity_PPT = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "WaterTemp_C") mwqmSample.WaterTemp_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "PH") mwqmSample.PH = GetRandomDouble(0.0D, 14.0D);
            if (OmitPropName != "SampleTypesText") mwqmSample.SampleTypesText = GetRandomString("", 5);
            if (OmitPropName != "SampleType_old") mwqmSample.SampleType_old = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "Tube_10") mwqmSample.Tube_10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_1_0") mwqmSample.Tube_1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_0_1") mwqmSample.Tube_0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "ProcessedBy") mwqmSample.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "UseForOpenData") mwqmSample.UseForOpenData = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSample.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSample.LastUpdateContactTVItemID = 2;

            return mwqmSample;
        }
        #endregion Functions private
    }
}
