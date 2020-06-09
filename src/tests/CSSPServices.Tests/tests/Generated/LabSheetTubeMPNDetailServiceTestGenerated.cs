/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
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
    public partial class LabSheetTubeMPNDetailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILabSheetTubeMPNDetailService labSheetTubeMPNDetailService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheetTubeMPNDetail_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               LabSheetTubeMPNDetail labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail(""); 

               // List<LabSheetTubeMPNDetail>
               var actionLabSheetTubeMPNDetailList = await labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList();
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value);
               List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = (List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value;

               int count = ((List<LabSheetTubeMPNDetail>)((OkObjectResult)actionLabSheetTubeMPNDetailList.Result).Value).Count();
                Assert.True(count > 0);

               // Add LabSheetTubeMPNDetail
               var actionLabSheetTubeMPNDetailAdded = await labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailAdded.Result).Value);
               LabSheetTubeMPNDetail labSheetTubeMPNDetailAdded = (LabSheetTubeMPNDetail)((OkObjectResult)actionLabSheetTubeMPNDetailAdded.Result).Value;
               Assert.NotNull(labSheetTubeMPNDetailAdded);

               // Update LabSheetTubeMPNDetail
               var actionLabSheetTubeMPNDetailUpdated = await labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).Value);
               LabSheetTubeMPNDetail labSheetTubeMPNDetailUpdated = (LabSheetTubeMPNDetail)((OkObjectResult)actionLabSheetTubeMPNDetailUpdated.Result).Value;
               Assert.NotNull(labSheetTubeMPNDetailUpdated);

               // Delete LabSheetTubeMPNDetail
               var actionLabSheetTubeMPNDetailDeleted = await labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
               Assert.Equal(200, ((ObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionLabSheetTubeMPNDetailDeleted.Result).Value;
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
            Services.AddSingleton<ILabSheetTubeMPNDetailService, LabSheetTubeMPNDetailService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            labSheetTubeMPNDetailService = Provider.GetService<ILabSheetTubeMPNDetailService>();
            Assert.NotNull(labSheetTubeMPNDetailService);

            return await Task.FromResult(true);
        }
        private LabSheetTubeMPNDetail GetFilledRandomLabSheetTubeMPNDetail(string OmitPropName)
        {
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();

            if (OmitPropName != "LabSheetDetailID") labSheetTubeMPNDetail.LabSheetDetailID = 1;
            if (OmitPropName != "Ordinal") labSheetTubeMPNDetail.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "MWQMSiteTVItemID") labSheetTubeMPNDetail.MWQMSiteTVItemID = 44;
            if (OmitPropName != "SampleDateTime") labSheetTubeMPNDetail.SampleDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "MPN") labSheetTubeMPNDetail.MPN = GetRandomInt(1, 10000000);
            if (OmitPropName != "Tube10") labSheetTubeMPNDetail.Tube10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube1_0") labSheetTubeMPNDetail.Tube1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube0_1") labSheetTubeMPNDetail.Tube0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "Salinity") labSheetTubeMPNDetail.Salinity = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "Temperature") labSheetTubeMPNDetail.Temperature = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "ProcessedBy") labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "SampleType") labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SiteComment") labSheetTubeMPNDetail.SiteComment = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetTubeMPNDetail.LastUpdateContactTVItemID = 2;

            return labSheetTubeMPNDetail;
        }
        #endregion Functions private
    }
}
