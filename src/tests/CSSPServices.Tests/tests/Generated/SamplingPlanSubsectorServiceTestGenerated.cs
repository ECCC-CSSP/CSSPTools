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
    public partial class SamplingPlanSubsectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ISamplingPlanSubsectorService samplingPlanSubsectorService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanSubsector_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               SamplingPlanSubsector samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector(""); 

               // List<SamplingPlanSubsector>
               var actionSamplingPlanSubsectorList = await samplingPlanSubsectorService.GetSamplingPlanSubsectorList();
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value);
               List<SamplingPlanSubsector> samplingPlanSubsectorList = (List<SamplingPlanSubsector>)((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value;

               int count = ((List<SamplingPlanSubsector>)((OkObjectResult)actionSamplingPlanSubsectorList.Result).Value).Count();
                Assert.True(count > 0);

               // Add SamplingPlanSubsector
               var actionSamplingPlanSubsectorAdded = await samplingPlanSubsectorService.Add(samplingPlanSubsector);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorAdded.Result).Value);
               SamplingPlanSubsector samplingPlanSubsectorAdded = (SamplingPlanSubsector)((OkObjectResult)actionSamplingPlanSubsectorAdded.Result).Value;
               Assert.NotNull(samplingPlanSubsectorAdded);

               // Update SamplingPlanSubsector
               var actionSamplingPlanSubsectorUpdated = await samplingPlanSubsectorService.Update(samplingPlanSubsector);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorUpdated.Result).Value);
               SamplingPlanSubsector samplingPlanSubsectorUpdated = (SamplingPlanSubsector)((OkObjectResult)actionSamplingPlanSubsectorUpdated.Result).Value;
               Assert.NotNull(samplingPlanSubsectorUpdated);

               // Delete SamplingPlanSubsector
               var actionSamplingPlanSubsectorDeleted = await samplingPlanSubsectorService.Delete(samplingPlanSubsector.SamplingPlanSubsectorID);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionSamplingPlanSubsectorDeleted.Result).Value;
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
            Services.AddSingleton<ISamplingPlanSubsectorService, SamplingPlanSubsectorService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            samplingPlanSubsectorService = Provider.GetService<ISamplingPlanSubsectorService>();
            Assert.NotNull(samplingPlanSubsectorService);

            return await Task.FromResult(true);
        }
        private SamplingPlanSubsector GetFilledRandomSamplingPlanSubsector(string OmitPropName)
        {
            SamplingPlanSubsector samplingPlanSubsector = new SamplingPlanSubsector();

            if (OmitPropName != "SamplingPlanID") samplingPlanSubsector.SamplingPlanID = 1;
            if (OmitPropName != "SubsectorTVItemID") samplingPlanSubsector.SubsectorTVItemID = 11;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsector.LastUpdateContactTVItemID = 2;

            return samplingPlanSubsector;
        }
        #endregion Functions private
    }
}
