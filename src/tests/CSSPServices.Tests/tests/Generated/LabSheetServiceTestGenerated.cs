/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
    public partial class LabSheetServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ILabSheetService labSheetService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task LabSheet_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               LabSheet labSheet = GetFilledRandomLabSheet(""); 

               // List<LabSheet>
               var actionLabSheetList = await labSheetService.GetLabSheetList();
               Assert.Equal(200, ((ObjectResult)actionLabSheetList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetList.Result).Value);
               List<LabSheet> labSheetList = (List<LabSheet>)(((OkObjectResult)actionLabSheetList.Result).Value);

               int count = ((List<LabSheet>)((OkObjectResult)actionLabSheetList.Result).Value).Count();
                Assert.True(count > 0);

               // Add LabSheet
               var actionLabSheetAdded = await labSheetService.Add(labSheet);
               Assert.Equal(200, ((ObjectResult)actionLabSheetAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetAdded.Result).Value);
               LabSheet labSheetAdded = (LabSheet)(((OkObjectResult)actionLabSheetAdded.Result).Value);
               Assert.NotNull(labSheetAdded);

               // Update LabSheet
               var actionLabSheetUpdated = await labSheetService.Update(labSheet);
               Assert.Equal(200, ((ObjectResult)actionLabSheetUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetUpdated.Result).Value);
               LabSheet labSheetUpdated = (LabSheet)(((OkObjectResult)actionLabSheetUpdated.Result).Value);
               Assert.NotNull(labSheetUpdated);

               // Delete LabSheet
               var actionLabSheetDeleted = await labSheetService.Delete(labSheet);
               Assert.Equal(200, ((ObjectResult)actionLabSheetDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionLabSheetDeleted.Result).Value);
               LabSheet labSheetDeleted = (LabSheet)(((OkObjectResult)actionLabSheetDeleted.Result).Value);
               Assert.NotNull(labSheetDeleted);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
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
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILabSheetService, LabSheetService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            labSheetService = Provider.GetService<ILabSheetService>();
            Assert.NotNull(labSheetService);
        
            await labSheetService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private LabSheet GetFilledRandomLabSheet(string OmitPropName)
        {
            LabSheet labSheet = new LabSheet();

            if (OmitPropName != "OtherServerLabSheetID") labSheet.OtherServerLabSheetID = GetRandomInt(1, 11);
            if (OmitPropName != "SamplingPlanID") labSheet.SamplingPlanID = 1;
            if (OmitPropName != "SamplingPlanName") labSheet.SamplingPlanName = GetRandomString("", 6);
            if (OmitPropName != "Year") labSheet.Year = GetRandomInt(1980, 1990);
            if (OmitPropName != "Month") labSheet.Month = GetRandomInt(1, 12);
            if (OmitPropName != "Day") labSheet.Day = GetRandomInt(1, 31);
            if (OmitPropName != "RunNumber") labSheet.RunNumber = GetRandomInt(1, 100);
            if (OmitPropName != "SubsectorTVItemID") labSheet.SubsectorTVItemID = 11;
            if (OmitPropName != "MWQMRunTVItemID") labSheet.MWQMRunTVItemID = 50;
            if (OmitPropName != "SamplingPlanType") labSheet.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "SampleType") labSheet.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "LabSheetType") labSheet.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "LabSheetStatus") labSheet.LabSheetStatus = (LabSheetStatusEnum)GetRandomEnumType(typeof(LabSheetStatusEnum));
            if (OmitPropName != "FileName") labSheet.FileName = GetRandomString("", 6);
            if (OmitPropName != "FileLastModifiedDate_Local") labSheet.FileLastModifiedDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "FileContent") labSheet.FileContent = GetRandomString("", 20);
            if (OmitPropName != "AcceptedOrRejectedByContactTVItemID") labSheet.AcceptedOrRejectedByContactTVItemID = 2;
            if (OmitPropName != "AcceptedOrRejectedDateTime") labSheet.AcceptedOrRejectedDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "RejectReason") labSheet.RejectReason = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheet.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheet.LastUpdateContactTVItemID = 2;

            return labSheet;
        }
        #endregion Functions private
    }
}
