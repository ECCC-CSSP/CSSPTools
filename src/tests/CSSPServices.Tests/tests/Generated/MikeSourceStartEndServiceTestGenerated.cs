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
    public partial class MikeSourceStartEndServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IMikeSourceStartEndService MikeSourceStartEndService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeSourceStartEnd_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               MikeSourceStartEnd mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd(""); 

               // List<MikeSourceStartEnd>
               var actionMikeSourceStartEndList = await MikeSourceStartEndService.GetMikeSourceStartEndList();
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndList.Result).Value);
               List<MikeSourceStartEnd> mikeSourceStartEndList = (List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value;

               int count = ((List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value).Count();
                Assert.True(count > 0);

               // Post MikeSourceStartEnd
               var actionMikeSourceStartEndAdded = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndAdded.Result).Value);
               MikeSourceStartEnd mikeSourceStartEndAdded = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndAdded.Result).Value;
               Assert.NotNull(mikeSourceStartEndAdded);

               // Put MikeSourceStartEnd
               var actionMikeSourceStartEndUpdated = await MikeSourceStartEndService.Put(mikeSourceStartEnd);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndUpdated.Result).Value);
               MikeSourceStartEnd mikeSourceStartEndUpdated = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndUpdated.Result).Value;
               Assert.NotNull(mikeSourceStartEndUpdated);

               // Delete MikeSourceStartEnd
               var actionMikeSourceStartEndDeleted = await MikeSourceStartEndService.Delete(mikeSourceStartEnd.MikeSourceStartEndID);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionMikeSourceStartEndDeleted.Result).Value;
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
            Services.AddSingleton<IMikeSourceStartEndService, MikeSourceStartEndService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            MikeSourceStartEndService = Provider.GetService<IMikeSourceStartEndService>();
            Assert.NotNull(MikeSourceStartEndService);

            return await Task.FromResult(true);
        }
        private MikeSourceStartEnd GetFilledRandomMikeSourceStartEnd(string OmitPropName)
        {
            MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();

            if (OmitPropName != "MikeSourceID") mikeSourceStartEnd.MikeSourceID = 1;
            if (OmitPropName != "StartDateAndTime_Local") mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateAndTime_Local") mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "SourceFlowStart_m3_day") mikeSourceStartEnd.SourceFlowStart_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceFlowEnd_m3_day") mikeSourceStartEnd.SourceFlowEnd_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourcePollutionStart_MPN_100ml") mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourcePollutionEnd_MPN_100ml") mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourceTemperatureStart_C") mikeSourceStartEnd.SourceTemperatureStart_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceTemperatureEnd_C") mikeSourceStartEnd.SourceTemperatureEnd_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceSalinityStart_PSU") mikeSourceStartEnd.SourceSalinityStart_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "SourceSalinityEnd_PSU") mikeSourceStartEnd.SourceSalinityEnd_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSourceStartEnd.LastUpdateContactTVItemID = 2;

            return mikeSourceStartEnd;
        }
        #endregion Functions private
    }
}
