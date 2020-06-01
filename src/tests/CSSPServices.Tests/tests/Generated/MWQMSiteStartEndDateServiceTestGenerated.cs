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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class MWQMSiteStartEndDateServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IMWQMSiteStartEndDateService mwqmSiteStartEndDateService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSiteStartEndDate_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            MWQMSiteStartEndDate mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate(""); 

            // List<MWQMSiteStartEndDate>
            var actionMWQMSiteStartEndDateList = await mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value);
            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = (List<MWQMSiteStartEndDate>)(((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value);

            int count = ((List<MWQMSiteStartEndDate>)((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value).Count();
            Assert.True(count > 0);

            // Add MWQMSiteStartEndDate
            var actionMWQMSiteStartEndDateAdded = await mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateAdded.Result).Value);
            MWQMSiteStartEndDate mwqmSiteStartEndDateAdded = (MWQMSiteStartEndDate)(((OkObjectResult)actionMWQMSiteStartEndDateAdded.Result).Value);
            Assert.NotNull(mwqmSiteStartEndDateAdded);

            // Update MWQMSiteStartEndDate
            var actionMWQMSiteStartEndDateUpdated = await mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateUpdated.Result).Value);
            MWQMSiteStartEndDate mwqmSiteStartEndDateUpdated = (MWQMSiteStartEndDate)(((OkObjectResult)actionMWQMSiteStartEndDateUpdated.Result).Value);
            Assert.NotNull(mwqmSiteStartEndDateUpdated);

            // Delete MWQMSiteStartEndDate
            var actionMWQMSiteStartEndDateDeleted = await mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateDeleted.Result).Value);
            MWQMSiteStartEndDate mwqmSiteStartEndDateDeleted = (MWQMSiteStartEndDate)(((OkObjectResult)actionMWQMSiteStartEndDateDeleted.Result).Value);
            Assert.NotNull(mwqmSiteStartEndDateDeleted);
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
            Services.AddSingleton<IMWQMSiteStartEndDateService, MWQMSiteStartEndDateService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            mwqmSiteStartEndDateService = Provider.GetService<IMWQMSiteStartEndDateService>();
            Assert.NotNull(mwqmSiteStartEndDateService);
        
            await mwqmSiteStartEndDateService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private MWQMSiteStartEndDate GetFilledRandomMWQMSiteStartEndDate(string OmitPropName)
        {
            MWQMSiteStartEndDate mwqmSiteStartEndDate = new MWQMSiteStartEndDate();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSiteStartEndDate.MWQMSiteTVItemID = 44;
            if (OmitPropName != "StartDate") mwqmSiteStartEndDate.StartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate") mwqmSiteStartEndDate.EndDate = new DateTime(2005, 3, 7);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSiteStartEndDate.LastUpdateContactTVItemID = 2;

            return mwqmSiteStartEndDate;
        }
        #endregion Functions private
    }
}